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
    public static class Combo
    {
        public static void Initialize()
        {
            Game.OnTick += Game_OnTick;
            Orbwalker.OnPostAttack += Orbwalker_OnPostAttack;
            Orbwalker.OnAttack += Orbwalker_OnAttack;
            Orbwalker.OnPreAttack += Orbwalker_OnPreAttack;
            Dash.OnDash += Dash_OnDash;
        }
        public static void BuffRemove_OnBuffReMove(AttackableUnit target, Obj_AI_BaseBuffLoseEventArgs args)
        {
            if (!Orbwalker.ActiveModesFlags.HasFlag(Orbwalker.ActiveModes.Combo))
                return;
            if (!(target is AIHeroClient) || !(target as AIHeroClient).IsValidCheck())
                return;
            if (Variables.ComboMode.CurrentValue == 1 && Player.Instance.Mana == 5)
                return;
            if (Variables.Q.IsReady())
            {
                Variables.Q.Cast();
            }
        }
        private static void Orbwalker_OnPreAttack(AttackableUnit target, Orbwalker.PreAttackArgs args)
        {
            if (!(target is Obj_AI_Base))
                return;
            if (!Orbwalker.ActiveModesFlags.HasFlag(Orbwalker.ActiveModes.Combo))
                return;
            if (!Player.Instance.HasBuff("rengarpassivebuff") && Variables.Q.IsReady() &&
                !(Variables.ComboMode.CurrentValue == 1 && Player.Instance.Mana == 5))
            {
                var enemy = target as Obj_AI_Base; 
                var x = Prediction.Position.PredictUnitPosition(enemy, (int)(Player.Instance.AttackCastDelay * 1000));
                var distance = (Player.Instance.Position.To2D().Distance(x)
                                - Player.Instance.BoundingRadius - enemy.BoundingRadius - Player.Instance.AttackRange);
                var speed = (Player.Instance.MoveSpeed - enemy.MoveSpeed);
                var time = distance / speed;
                if (x.IsValid() && Player.Instance.Position.To2D().Distance(x)
                    >= Player.Instance.BoundingRadius + Player.Instance.AttackRange + args.Target.BoundingRadius
                    && (time >= Player.Instance.AttackCastDelay || time < 0))
                {
                    args.Process = false;
                    Variables.Q.Cast();
                }
            }
        }

        private static void Dash_OnDash(Obj_AI_Base sender, Dash.DashEventArgs e)
        {
            if (!sender.IsMe)
                return;
            if (!Orbwalker.ActiveModesFlags.HasFlag(Orbwalker.ActiveModes.Combo))
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

        private static void Orbwalker_OnAttack(AttackableUnit target, EventArgs args)
        {
            if (!Orbwalker.ActiveModesFlags.HasFlag(Orbwalker.ActiveModes.Combo))
                return;
            if (Checker.HasYoumuu())
                Checker.CastYoumuu();
        }
        public static void Orbwalker_OnPostAttack(AttackableUnit target, EventArgs args)
        {
            if (!Orbwalker.ActiveModesFlags.HasFlag(Orbwalker.ActiveModes.Combo))
                return;
            if (Variables.ComboMode.CurrentValue == 1 && Player.Instance.Mana == 5)
            {
                if (Checker.HasItem())
                    Checker.CastItem();
            }
            else if (Variables.Q.IsReady())
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
            if (!Orbwalker.ActiveModesFlags.HasFlag(Orbwalker.ActiveModes.Combo))
                return;
            combo();
        }

        public static void combo()
        {
            if (Checker.SmiteReady() && Variables.ComboSmite.CurrentValue)
            {
                if (Checker.HasSmiteBlue || Checker.HasSmiteRed)
                {
                    var target = TargetSelector.GetTarget(650, DamageType.Physical);
                    if (target.IsValidCheck() && Player.Instance.Distance(target.Position) 
                        <= Player.Instance.BoundingRadius + 500 + target.BoundingRadius)
                    {
                        Player.Instance.Spellbook.CastSpell(Variables.Smite, target);
                    }
                }
            }

            if (Player.HasBuff("RengarR") && Checker.HasYoumuu() && Variables.ComboYoumuu.CurrentValue)
            {
                Checker.CastYoumuu();
            }
            if (!Player.HasBuff("RengarR"))
            {
                if (Variables.ComboMode.CurrentValue == 1)
                {
                    if (Player.Instance.Mana < 5)
                    {
                        var targetW = TargetSelector.GetTarget(500, DamageType.Physical);
                        if (Variables.W.IsReady() && targetW.IsValidCheck())
                        {
                            Variables.W.Cast(targetW);
                        }
                        if (Variables.E.IsReady())
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
                    else
                    {
                        if (Player.Instance.IsDashing() || Orbwalker.CanMove
                            && !(Checker.CanAttack() && EntityManager.Heroes.Enemies.Any(x => x.IsValidCheck()
                            && Player.Instance.IsInAutoAttackRange(x))))
                        {
                            var targetE = TargetSelector.GetTarget(Variables.E.Range, DamageType.Physical);
                            if (Variables.E.IsReady() && targetE.IsValidCheck())
                            {
                                Variables.E.Cast(targetE);
                            }
                            foreach (var target in EntityManager.Heroes.Enemies.Where(x => x.IsValidTarget(Variables.E.Range) && !x.IsZombie))
                            {
                                if (Variables.E.IsReady())
                                    Variables.E.Cast(target);
                            }
                        }
                    }
                }
                else if (Variables.ComboMode.CurrentValue == 2)
                {
                    if (Player.Instance.Mana < 5)
                    {
                        var targetW = TargetSelector.GetTarget(500, DamageType.Physical);
                        if (Variables.W.IsReady() && targetW.IsValidCheck())
                        {
                            Variables.W.Cast(targetW);
                        }
                        if (Variables.E.IsReady())
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
             
                    else
                    {
                        if (Variables.Q.IsReady() && Player.Instance.CountEnemiesInRange(Player.Instance.AttackRange
                            + Player.Instance.BoundingRadius + 100) != 0)
                        {
                            if (Checker.CanMove() && !Checker.CanAttack())
                            {
                                Variables.Q.Cast();
                            }
                        }
                        if (Variables.Q.IsReady() && Player.Instance.IsDashing())
                        {
                            Variables.Q.Cast();
                        }
                        if (Variables.E.IsReady())
                        {
                            if (Player.Instance.CountEnemiesInRange(Player.Instance.AttackRange + Player.Instance.BoundingRadius + 100) 
                                == 0 && !Player.HasBuff("rengarpassivebuff") && !Player.Instance.IsDashing()
                                && Orbwalker.CanMove)
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
                    }
                }
                else if (Variables.ComboMode.CurrentValue == 3)
                {
                    if (Player.Instance.Mana < 5)
                    {
                        var targetW = TargetSelector.GetTarget(500, DamageType.Physical);
                        if (Variables.W.IsReady() && targetW.IsValidCheck())
                        {
                            Variables.W.Cast(targetW);
                        }
                        if (Variables.E.IsReady())
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
                    else
                    {
                        if (Variables.Q.IsReady() && Player.Instance.CountEnemiesInRange(Player.Instance.AttackRange
                           + Player.Instance.BoundingRadius + 100) != 0)
                        {
                            if (Checker.CanMove() && !Checker.CanAttack())
                            {
                                Variables.Q.Cast();
                            }
                        }
                        if (Variables.E.IsReady() && Player.Instance.IsDashing())
                        {
                            var targetE = TargetSelector.GetTarget(Variables.E.Range, DamageType.Physical);
                            if (Variables.E.IsReady() && targetE.IsValidTarget() && !targetE.IsZombie)
                            {
                                Variables.E.Cast(targetE);
                            }
                            foreach (var target in EntityManager.Heroes.Enemies.Where(x => x.IsValidTarget(Variables.E.Range) && !x.IsZombie))
                            {
                                if (Variables.E.IsReady())
                                    Variables.E.Cast(target);
                            }
                        }
                        if (Variables.E.IsReady())
                        {
                            if (Player.Instance.CountEnemiesInRange(Player.Instance.AttackRange + Player.Instance.BoundingRadius + 100)
                                == 0 && !Player.HasBuff("rengarpassivebuff") && !Player.Instance.IsDashing()
                                && Orbwalker.CanMove)
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
                    }
                }
                else if (Variables.ComboMode.CurrentValue == 4)
                {
                    if (Player.Instance.Mana < 5)
                    {
                        var targetW = TargetSelector.GetTarget(500, DamageType.Physical);
                        if (Variables.W.IsReady() && targetW.IsValidCheck())
                        {
                            Variables.W.Cast(targetW);
                        }
                        if (Variables.E.IsReady())
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
                    else
                    {
                        if (Variables.Q.IsReady() && Player.Instance.CountEnemiesInRange(Player.Instance.AttackRange
                            + Player.Instance.BoundingRadius + 100) != 0)
                        {
                            if (Checker.CanMove() && !Checker.CanAttack())
                            {
                                Variables.Q.Cast();
                            }
                        }
                        if (Variables.Q.IsReady() && Player.Instance.IsDashing())
                        {
                            Variables.Q.Cast();
                        }
                    }
                }

                else Chat.Print("Noob Dev");
            }
        }
    }
}
