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

using SharpDX;
using Color = System.Drawing.Color;

namespace GodSpeedRengar
{
    public class subOrb
    {
        public static float LastAATick;
        public static AttackableUnit DashTarget;
        public static float DashTick, DashDur;
        public static bool Dashing;

        public static void Initialize()
        {
            Obj_AI_Base.OnProcessSpellCast += Obj_AI_Base_OnProcessSpellCast;
            Dash.OnDash += Dash_OnDash;
            Game.OnTick += Game_OnTick;
            Obj_AI_Base.OnBuffLose += Obj_AI_Base_OnBuffLose;
        }

        private static void Obj_AI_Base_OnBuffLose(Obj_AI_Base sender, Obj_AI_BaseBuffLoseEventArgs args)
        {
            if (!sender.IsMe)
                return;
            if (args.Buff.Name == "rengarqbase" || args.Buff.Name == "rengarqemp")
            {
                if (Orbwalker.LastTarget != null && Orbwalker.LastTarget.IsVisible 
                    && Orbwalker.LastTarget.Distance(Player.Instance.Position) <= 300)
                Core.DelayAction(() =>
                                {
                                    Combo.BuffRemove_OnBuffReMove(Orbwalker.LastTarget, args);
                                }
                                , 250);
            }
        }
        public static void Orbwalker_OnPostAttack(AttackableUnit target, EventArgs args)
        {
            Combo.Orbwalker_OnPostAttack(target, args);
            Harass.Orbwalker_OnPostAttack(target, args);
            LaneClear.Orbwalker_OnPostAttack(target, args);
            JungleClear.Orbwalker_OnPostAttack(target, args);
        }
        public static void Obj_AI_Base_OnProcessSpellCast(Obj_AI_Base sender, GameObjectProcessSpellCastEventArgs args)
        {
            if (!sender.IsMe)
                return;
            if (args.Slot == SpellSlot.Q && Dashing == false)
            {
                Orbwalker.ResetAutoAttack();
                Orbwalker.DisableAttacking = false;
            }
            if (args.SData.Name == "ItemTitanicHydraCleave")
            {
                Orbwalker.ResetAutoAttack();
            }
        }

        public static void Dash_OnDash(Obj_AI_Base sender, Dash.DashEventArgs e)
        {
            if (!sender.IsMe)
                return;
            LastAATick = Game.Time * 1000 - Game.Ping / 2 - (int)Player.Instance.AttackCastDelay * 1000 + e.Duration;
            DashTarget = Orbwalker.LastTarget;
            DashTick = Game.Time * 1000 - Game.Ping / 2;
            Dashing = true;
            DashDur = e.Duration;
            Orbwalker.DisableAttacking = true;
        }

        public static void Game_OnTick(EventArgs args)
        {
            if (Dashing == true)
            {
                if (DashTarget != null && !Player.Instance.IsDashing() && Player.Instance.IsInAutoAttackRange(DashTarget))
                {
                    Core.DelayAction(() => { Orbwalker_OnPostAttack(DashTarget, args); Dashing = false; }, 
                                    150 - Game.Ping > 0 ? 150 - Game.Ping : 0);
                }
                else if (Game.Time * 1000 - DashTick + Game.Ping / 2 + 50 >= DashDur)
                {
                    Orbwalker_OnPostAttack(DashTarget, args);
                    Dashing = false;
                }
            }
            if (Orbwalker.DisableAttacking == true && CanAttack())
            {
                Orbwalker.ResetAutoAttack();
                Orbwalker.DisableAttacking = false;
            }
        }

        public static bool CanAttack()
        {
            return Game.Time * 1000 + Game.Ping / 2 + 25 >= LastAATick + Player.Instance.AttackDelay * 1000;
        }
    }
}
