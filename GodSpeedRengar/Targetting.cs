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
    public static class Targetting
    {
        public static AIHeroClient RjumpTarget = null, PassiveJumpTarget =  null;
        public static void Initialize()
        {
            Game.OnTick += Game_OnTick;
            Orbwalker.OnPreAttack += Orbwalker_OnPreAttack;
            Player.OnIssueOrder += Player_OnIssueOrder;
        }

        private static void Player_OnIssueOrder(Obj_AI_Base sender, PlayerIssueOrderEventArgs args)
        {
            if (!sender.IsMe
                || !Orbwalker.ActiveModesFlags.HasFlag(Orbwalker.ActiveModes.Combo)
                || !args.Order.HasFlag(GameObjectOrder.AttackUnit)
                || !Player.HasBuff("RengarR")
                || args.Target == null || !args.Target.IsValid || !(args.Target is AIHeroClient))
                return;
            UltimateTargetingOnIssue(sender, args);
        }

        private static void Orbwalker_OnPreAttack(AttackableUnit target, Orbwalker.PreAttackArgs args)
        {
            if (!Orbwalker.ActiveModesFlags.HasFlag(Orbwalker.ActiveModes.Combo))
                return;
            if (Player.Instance.HasBuff("rengarpassivebuff") && !Player.HasBuff("RengarR"))
            {
                args.Process = false;
                BushTargeting();
            }
        }

        private static void Game_OnTick(EventArgs args)
        {
            if (Player.HasBuff("RengarR"))
            {
                RjumpTarget = GetUltimateTarget();
            }
            else if (Player.Instance.HasBuff("rengarpassivebuff"))
            {
                PassiveJumpTarget = GetBushTarget();
            }
            if (!Orbwalker.ActiveModesFlags.HasFlag(Orbwalker.ActiveModes.Combo))
                return;
            UltimateTargetingOnTick();
        }

        private static void UltimateTargetingOnIssue(Obj_AI_Base sender, PlayerIssueOrderEventArgs args)
        {
            var target = args.Target as AIHeroClient;
            var ultTarget = GetUltimateTarget();
            if (!target.IsValidCheck() || !ultTarget.IsValidTarget() || target.NetworkId != ultTarget.NetworkId)
                args.Process = false;
        }
        private static void UltimateTargetingOnTick()
        {
            if (!Player.HasBuff("RengarR"))
                return;
            var ultTarget = GetUltimateTarget();
            if (!ultTarget.IsValidCheck() || !Player.Instance.IsInAutoAttackRange(ultTarget) || !Orbwalker.CanAutoAttack)
                return;
            Player.IssueOrder(GameObjectOrder.AttackUnit, ultTarget);
        }
        
        private static void BushTargeting()
        {
            var target = GetBushTarget();
            if (!target.IsValidCheck() || !Player.Instance.IsInAutoAttackRange(target) || !Orbwalker.CanAutoAttack)
                return;
            Player.IssueOrder(GameObjectOrder.AttackUnit, target);
        }

        private static AIHeroClient GetUltimateTarget()
        {
            if (Variables.UltSelected.CurrentValue && TargetSelector.SelectedTarget.IsValidCheck())
            {
                return TargetSelector.SelectedTarget;
            }
            var target = EntityManager.Heroes.Enemies.Where(hero => hero.IsValidCheck()
                && Config.Targetting["ulti" + hero.NetworkId].Cast<CheckBox>().CurrentValue)
                .OrderBy(hero => hero.Distance(Player.Instance)).FirstOrDefault();
            return target != null ? target : TargetSelector.SelectedTarget;
        }

        private static AIHeroClient GetBushTarget()
        {
            if (Variables.UltSelected.CurrentValue && TargetSelector.SelectedTarget.IsValidCheck()
                && Player.Instance.IsInAutoAttackRange(TargetSelector.SelectedTarget))
            {
                return TargetSelector.SelectedTarget;
            }
            var target = EntityManager.Heroes.Enemies.Where(hero => hero.IsValidCheck() && Player.Instance.IsInAutoAttackRange(hero))
                        .OrderByDescending(hero => Config.Targetting["bush" + hero.NetworkId].Cast<Slider>().CurrentValue)
                        .ThenBy(hero => hero.Health)
                        .FirstOrDefault();
            return target;
        }
    }
}
