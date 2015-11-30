using System.Linq;
using EloBuddy;
using EloBuddy.SDK;
using EloBuddy.SDK.Menu.Values;

namespace NotBrand.Modes
{
    public sealed class Combo : ModeBase
    {
        public override int Delay
        {
            get { return Game.Ping/2; }
        }

        public override bool ShouldBeExecuted()
        {
            return Orbwalker.ActiveModesFlags.HasFlag(Orbwalker.ActiveModes.Combo);
        }

        public override void Execute()
        {
            if (!SpellManager.ShouldCast(false))
            {
                return;
            }

            const int range = 1100;
            const float hitchance = 56f;
            const float aoeratio = 0.2f;

            var enemies = EntityManager.Heroes.Enemies.Where(n => n.IsValidTarget(range));
            var selectedTarget = TargetSelector.GetTarget(range, DamageType.Magical);
            var allTargets =
                new[] {selectedTarget}.Concat(
                    enemies.Where(n => n.Index != selectedTarget.Index)
                        .OrderByDescending(n => Damage.TotalDamage(SpellSlot.Q, n)/n.Health)).Where(n => n.IsValidTarget() && !n.WillDie());

            if (selectedTarget == null && !enemies.Any())
            {
                return;
            }

            #region Killsteal logic

            var ksQ = Config.Menu["ksQ"].Cast<CheckBox>().CurrentValue &&
                      Player.CanUseSpell(SpellSlot.Q) == SpellState.Ready;
            var ksW = Config.Menu["ksW"].Cast<CheckBox>().CurrentValue &&
                      Player.CanUseSpell(SpellSlot.W) == SpellState.Ready;
            var ksE = Config.Menu["ksE"].Cast<CheckBox>().CurrentValue &&
                      Player.CanUseSpell(SpellSlot.E) == SpellState.Ready;
            var ksR = Config.Menu["ksR"].Cast<CheckBox>().CurrentValue &&
                      Player.CanUseSpell(SpellSlot.R) == SpellState.Ready;

            foreach (var enemy in allTargets)
            {
                if (ksE && Player.Instance.IsInRange(enemy, E.Range) && enemy.Killable(SpellSlot.E))
                {
                    E.Cast(enemy);
                    return;
                }

                if (ksW && Player.Instance.IsInRange(enemy, W.Range + W.Radius) && enemy.Killable(SpellSlot.W))
                {
                    var prediction = W.GetPrediction(enemy);

                    if (prediction.HitChancePercent >= hitchance)
                    {
                        W.Cast(prediction.CastPosition);
                        return;
                    }
                }

                if (ksQ && Player.Instance.IsInRange(enemy, Q.Range) && enemy.Killable(SpellSlot.Q))
                {
                    var prediction = Q.GetPrediction(enemy);

                    if (prediction.HitChancePercent >= hitchance)
                    {
                        Q.Cast(prediction.CastPosition);
                        return;
                    }
                }

                if (ksR && Player.Instance.IsInRange(enemy, R.Range) && enemy.Killable(SpellSlot.R))
                {
                    R.Cast(enemy);
                    return;
                }
            }

            #endregion

            #region Combo logic

            var useQ = Config.Menu["comboQ"].Cast<CheckBox>().CurrentValue &&
                       Player.CanUseSpell(SpellSlot.Q) == SpellState.Ready;
            var useW = Config.Menu["comboW"].Cast<CheckBox>().CurrentValue &&
                       Player.CanUseSpell(SpellSlot.W) == SpellState.Ready;
            var useE = Config.Menu["comboE"].Cast<CheckBox>().CurrentValue &&
                       Player.CanUseSpell(SpellSlot.E) == SpellState.Ready;
            var useR = Config.Menu["comboR"].Cast<CheckBox>().CurrentValue &&
                       Player.CanUseSpell(SpellSlot.R) == SpellState.Ready;

            // check for AOE then single target burst        
            // check W first
            if (enemies.Count() > 1)
            {
                if (useW)
                {
                    var aoePrediction =
                        Prediction.Position.PredictCircularMissileAoe(enemies.Cast<Obj_AI_Base>().ToArray(), W.Range,
                            W.Radius, W.CastDelay, W.Speed)
                            .OrderByDescending(r => r.GetCollisionObjects<Obj_AI_Minion>().Length)
                            .FirstOrDefault();

                    if (aoePrediction != null)
                    {
                        var predictedHeroes = aoePrediction.GetCollisionObjects<AIHeroClient>();

                        if (predictedHeroes.Length > 1 && (float) predictedHeroes.Length/enemies.Count() >= aoeratio)
                        {
                            W.Cast(aoePrediction.CastPosition);
                            return;
                        }
                    }
                }

                // check E next
                if (useE)
                {
                    var enemyE =
                        enemies.Where(n => n.IsValidTarget(E.Range) && n.IsBlazed())
                            .OrderByDescending(n => n.CountEnemiesInRange(SpellManager.ConflagrationSpreadRange))
                            .FirstOrDefault();

                    if (enemyE != null && enemyE.CountEnemiesInRange(SpellManager.ConflagrationSpreadRange) > 1)
                    {
                        E.Cast(enemyE);
                        return;
                    }
                }
            }

            // single target burst
            if (useE)
            {
                var targets = allTargets.Where(n => Player.Instance.IsInRange(n, E.Range));

                foreach (var target in targets)
                {
                    E.Cast(target);
                    return;
                }
            }

            if (useW)
            {
                foreach (var target in allTargets)
                {
                    if (W.Cast(target))
                    {
                        return;
                    }
                }
            }

            if (useQ)
            {
                foreach (var target in allTargets.Where(n => n.IsBlazed()))
                {
                    if (Q.Cast(target))
                    {
                        return;
                    }
                }
            }

            if (useR)
            {
                var bestTarget =
                    allTargets.Where(n => Player.Instance.IsInRange(n, R.Range))
                        .OrderByDescending(n => n.CountEnemiesInRange(SpellManager.PyroclasmSpreadRange))
                        .FirstOrDefault();

                if (bestTarget != null &&
                    bestTarget.CountEnemiesInRange(SpellManager.PyroclasmSpreadRange) >=
                    Config.Menu["minEnemiesR"].Cast<Slider>().CurrentValue)
                {
                    if ((!useW && !useE || bestTarget.IsBlazed()))
                    {
                        R.Cast(bestTarget);
                    }
                }
            }

            #endregion
        }
    }
}