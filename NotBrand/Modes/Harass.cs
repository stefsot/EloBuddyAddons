using System.Linq;
using EloBuddy;
using EloBuddy.SDK;
using EloBuddy.SDK.Menu.Values;

namespace NotBrand.Modes
{
    public sealed class Harass : ModeBase
    {
        public override bool ShouldBeExecuted()
        {
            return Orbwalker.ActiveModesFlags.HasFlag(Orbwalker.ActiveModes.Harass);
        }

        public override void Execute()
        {
            if (!SpellManager.ShouldCast())
            {
                return;
            }

            var useQ = Config.HarassMenu["harassQ"].Cast<CheckBox>().CurrentValue &&
                     Player.Instance.ManaPercent >= Config.HarassMenu["harassQmana"].Cast<Slider>().CurrentValue &&
                     Player.CanUseSpell(SpellSlot.Q) == SpellState.Ready;
            var useW = Config.HarassMenu["harassW"].Cast<CheckBox>().CurrentValue &&
                      Player.Instance.ManaPercent >= Config.HarassMenu["harassWmana"].Cast<Slider>().CurrentValue &&
                      Player.CanUseSpell(SpellSlot.W) == SpellState.Ready;
            var useE = Config.HarassMenu["harassE"].Cast<CheckBox>().CurrentValue &&
                     Player.Instance.ManaPercent >= Config.HarassMenu["harassEmana"].Cast<Slider>().CurrentValue &&
                     Player.CanUseSpell(SpellSlot.E) == SpellState.Ready;

            if (useE)
            {
                Obj_AI_Base selectedTarget = TargetSelector.GetTarget(E.Range, DamageType.Magical);

                if (selectedTarget == null)
                {
                    var extendedTarget = TargetSelector.GetTarget(E.Range + SpellManager.ConflagrationSpreadRange,
                        DamageType.Magical);

                    if (extendedTarget != null)
                    {
                        var minions =
                            EntityManager.MinionsAndMonsters.CombinedAttackable.Where(
                                m =>
                                    m.IsBlazed() && m.IsInRange(extendedTarget, SpellManager.ConflagrationSpreadRange) &&
                                    m.IsInRange(Player.Instance, E.Range));
                        selectedTarget = minions.FirstOrDefault();
                    }
                }

                if (selectedTarget != null)
                {
                    E.Cast(selectedTarget);
                    return;
                }
            }

            if (useW)
            {
                var selectedTarget = TargetSelector.GetTarget(W.Range + W.Radius, DamageType.Magical);

                if (selectedTarget != null)
                {
                    if (W.Cast(selectedTarget))
                    {
                        return;
                    }
                }
            }

            if (useQ)
            {
                var selectedTarget = TargetSelector.GetTarget(Q.Range, DamageType.Magical);

                if (selectedTarget != null)
                {
                    if (Q.Cast(selectedTarget))
                    {
                        return;
                    }
                }
            }
        }
    }
}
