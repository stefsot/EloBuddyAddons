using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EloBuddy;
using EloBuddy.SDK;
using EloBuddy.SDK.Enumerations;
using EloBuddy.SDK.Events;
using EloBuddy.SDK.Rendering;
using EloBuddy.SDK.Utils;
using EloBuddy.SDK.Menu;
using EloBuddy.SDK.Menu.Values;

using SharpDX;
using Color = System.Drawing.Color;

namespace GodSpeedRengar
{
    public static class Harass
    {
        public static void Initialize()
        {
            Game.OnTick += Game_OnTick;
            Orbwalker.OnPostAttack += Orbwalker_OnPostAttack;
            Dash.OnDash += Dash_OnDash;
        }

        private static void Dash_OnDash(Obj_AI_Base sender, Dash.DashEventArgs e)
        {
            if (!sender.IsMe)
                return;
            if (!Orbwalker.ActiveModesFlags.HasFlag(Orbwalker.ActiveModes.Harass))
                return;
            if (!Checker.HasItem() || Item.CanUseItem(3748))
                return;
            if (!(Orbwalker.LastTarget is AIHeroClient))
                return;
            if (!Checker.HasItem() || Item.CanUseItem(3748))
                return;
            if (e.Duration - 100 - Game.Ping / 2 > 0)
            {
                Core.DelayAction(() => Checker.CastItem(),
                                (int)(e.Duration - 100 - Game.Ping / 2));
            }
            else
            {
                Checker.CastItem();
            }
        }

        public static void Orbwalker_OnPostAttack(AttackableUnit target, EventArgs args)
        {
            if (!Orbwalker.ActiveModesFlags.HasFlag(Orbwalker.ActiveModes.Harass))
                return;
            if (!(target is AIHeroClient))
                return;

            if (Variables.Q.IsReady())
            {
                Variables.Q.Cast();
            }
            else if (Checker.HasItem())
            {
                Checker.CastItem();
            }
            else if (Variables.E.IsReady())
            {
                var targetE = TargetSelector.GetTarget(Variables.E.Range, DamageType.Physical);
                if (Variables.E.IsReady() && targetE.IsValidCheck())
                {
                    Variables.E.Cast(targetE);
                }
                foreach (var tar in EntityManager.Heroes.Enemies.Where(x => x.IsValidCheck(Variables.E.Range)))
                {
                    if (Variables.E.IsReady())
                        Variables.E.Cast(tar);
                }
            }
        }

        private static void Game_OnTick(EventArgs args)
        {
            if (!Orbwalker.ActiveModesFlags.HasFlag(Orbwalker.ActiveModes.Harass))
                return;

            var targetW = TargetSelector.GetTarget(500, DamageType.Physical);
            if (Variables.HarassW.CurrentValue && Variables.W.IsReady() && targetW.IsValidCheck())
            {
                Variables.W.Cast(targetW);
            }
            if (Variables.HarassE.CurrentValue && Variables.E.IsReady())
            {
                if (Player.Instance.IsDashing() || Orbwalker.CanMove
                    && !(Checker.CanAttack() && EntityManager.Heroes.Enemies.Any(x => x.IsValidCheck()
                    && Player.Instance.IsInAutoAttackRange(x))))
                {
                    var targetE = TargetSelector.GetTarget(Variables.E.Range, DamageType.Physical);
                    if (targetE.IsValidCheck())
                    {
                        Variables.E.Cast(targetE);
                    }
                    foreach (var target in EntityManager.Heroes.Enemies.Where(x => x.IsValidTarget(Variables.E.Range) && !x.IsZombie))
                    {
                        Variables.E.Cast(target);
                    }
                }
            }
            if (Variables.Q.IsReady() && Player.Instance.CountEnemiesInRange(Player.Instance.AttackRange
                + Player.Instance.BoundingRadius + 100) != 0)
            {
                if (Checker.CanMove() && !Checker.CanAttack())
                {
                    Variables.Q.Cast();
                }
            }
        }
    }
}
