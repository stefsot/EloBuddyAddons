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
    public static class LaneClear
    {
        public static void Initialize()
        {
            Game.OnTick += Game_OnTick;
            Orbwalker.OnPostAttack += Orbwalker_OnPostAttack;
        }

        public static void Orbwalker_OnPostAttack(AttackableUnit target, EventArgs args)
        {
            if (!Orbwalker.ActiveModesFlags.HasFlag(Orbwalker.ActiveModes.LaneClear))
                return;
            if (Player.Instance.Mana < 5 || (Player.Instance.Mana == 5 && !Variables.LaneSave.CurrentValue))
            {
                if (Variables.LaneQ.CurrentValue && Variables.Q.IsReady())
                {
                    Variables.Q.Cast();
                }
                else
                {
                    if (Variables.LaneTiamat.CurrentValue && Checker.HasItem())
                        Checker.CastItem();
                }
            }
            else
            {
                if (Variables.LaneTiamat.CurrentValue && Checker.HasItem())
                    Checker.CastItem();
            }

        }

        private static void Game_OnTick(EventArgs args)
        {
            if (!Orbwalker.ActiveModesFlags.HasFlag(Orbwalker.ActiveModes.LaneClear))
                return;
            if (Player.Instance.Mana < 5 || (Player.Instance.Mana == 5 && !Variables.LaneSave.CurrentValue))
            {
                if (Variables.LaneW.CurrentValue && Variables.W.IsReady())
                {
                    var minion = EntityManager.MinionsAndMonsters
                        .GetLaneMinions(EntityManager.UnitTeam.Enemy,Player.Instance.Position,400,true)
                        .OrderBy(x => x.Health).FirstOrDefault();
                    if (minion.IsValidTarget())
                        Variables.W.Cast(Player.Instance);
                }
                if (Variables.LaneE.CurrentValue && Variables.E.IsReady())
                {
                    var minion = EntityManager.MinionsAndMonsters
                        .GetLaneMinions(EntityManager.UnitTeam.Enemy, Player.Instance.Position, Variables.E.Range, true)
                        .OrderBy(x => x.Health).FirstOrDefault();
                    if (minion.IsValidTarget())
                        Variables.E.Cast(minion);
                }
            }
        }
    }
    public static class JungleClear
    {
        public static void Initialize()
        {
            Game.OnTick += Game_OnTick;
            Orbwalker.OnPostAttack += Orbwalker_OnPostAttack;
        }

        public static void Orbwalker_OnPostAttack(AttackableUnit target, EventArgs args)
        {
            if (!Orbwalker.ActiveModesFlags.HasFlag(Orbwalker.ActiveModes.JungleClear))
                return;

            if (Player.Instance.Mana < 5 || (Player.Instance.Mana == 5 && !Variables.JungSave.CurrentValue))
            {
                if (Variables.JungQ.CurrentValue && Variables.Q.IsReady())
                {
                    Variables.Q.Cast();
                }
                else
                {
                    if (Variables.JungTiamat.CurrentValue && Checker.HasItem())
                        Checker.CastItem();
                }
            }
            else
            {
                if (Variables.JungTiamat.CurrentValue && Checker.HasItem())
                    Checker.CastItem();
            }

        }

        private static void Game_OnTick(EventArgs args)
        {
            if (!Orbwalker.ActiveModesFlags.HasFlag(Orbwalker.ActiveModes.JungleClear))
                return;

            if (Player.Instance.Mana < 5 || (Player.Instance.Mana == 5 && !Variables.JungSave.CurrentValue))
            {
                if (Variables.JungW.CurrentValue && Variables.W.IsReady())
                {
                    var minion = EntityManager.MinionsAndMonsters
                        .GetJungleMonsters(Player.Instance.Position, 400, true)
                        .OrderBy(x => x.Health).FirstOrDefault();
                    if (minion.IsValidTarget())
                    {
                        Variables.W.Cast(Player.Instance);
                    }
                }
                if (Variables.JungE.CurrentValue && Variables.E.IsReady())
                {
                    var minion = EntityManager.MinionsAndMonsters
                        .GetJungleMonsters(Player.Instance.Position, Variables.E.Range, true)
                        .OrderBy(x => x.Health).FirstOrDefault();
                    if (minion.IsValidTarget())
                        Variables.E.Cast(minion);
                }
            }
        }
    }
}
