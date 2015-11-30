using System.Linq;
using EloBuddy;
using EloBuddy.SDK;
using EloBuddy.SDK.Menu.Values;

namespace NotBrand.Modes
{
    public sealed class LaneClear : ModeBase
    {
        public override bool ShouldBeExecuted()
        {
            return Orbwalker.ActiveModesFlags.HasFlag(Orbwalker.ActiveModes.LaneClear);
        }

        public override void Execute()
        {
            if (!SpellManager.ShouldCast())
            {
                return;
            }

            var useW = Config.LaneClearMenu["laneClearW"].Cast<CheckBox>().CurrentValue &&
                       Player.Instance.ManaPercent >= Config.LaneClearMenu["minManaW"].Cast<Slider>().CurrentValue &&
                       Player.CanUseSpell(SpellSlot.W) == SpellState.Ready;
            var useE = Config.LaneClearMenu["laneClearE"].Cast<CheckBox>().CurrentValue &&
                       Player.Instance.ManaPercent >= Config.LaneClearMenu["minManaE"].Cast<Slider>().CurrentValue &&
                       Player.CanUseSpell(SpellSlot.E) == SpellState.Ready;

            if (useW)
            {
                var minions =
                    EntityManager.MinionsAndMonsters.GetLaneMinions(EntityManager.UnitTeam.Enemy,
                        Player.Instance.Position, 1500, false);

                var predictResult =
                    Prediction.Position.PredictCircularMissileAoe(minions.Cast<Obj_AI_Base>().ToArray(), W.Range, W.Radius, W.CastDelay, W.Speed)
                        .OrderByDescending(r => r.GetCollisionObjects<Obj_AI_Minion>().Length).FirstOrDefault();

                if (predictResult != null && predictResult.CollisionObjects.Length >= Config.LaneClearMenu["minMinionsW"].Cast<Slider>().CurrentValue)
                {
                    W.Cast(predictResult.CastPosition);
                    return;
                }
            }

            if (useE)
            {
                var minions =
                 EntityManager.MinionsAndMonsters.GetLaneMinions(EntityManager.UnitTeam.Enemy,
                     Player.Instance.Position, E.Range + 20, false).Where(m => m.IsBlazed());

                var group = Utils.GroupObjects(minions, SpellManager.ConflagrationSpreadRange).FirstOrDefault();

                if (group != null && group.Item1.Length >= Config.LaneClearMenu["minMinionsE"].Cast<Slider>().CurrentValue)
                {
                    var minion = group.Item1.OrderByDescending(m => m.Distance(group.Item2, true)).Last();

                    E.Cast(minion);
                }
            }
        }
    }
}
