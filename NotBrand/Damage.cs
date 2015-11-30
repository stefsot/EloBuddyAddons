using System;
using System.Collections.Generic;
using EloBuddy;
using EloBuddy.SDK;

namespace NotBrand
{
    static class Damage
    {
        private static readonly Dictionary<SpellSlot, int[]> BaseDamage = new Dictionary<SpellSlot, int[]>();
        private static readonly Dictionary<SpellSlot, float[]> BonusDamage = new Dictionary<SpellSlot, float[]>();

        static Damage()
        {
            BaseDamage.Add(SpellSlot.Q, new[] {80, 120, 160, 200, 240});
            BaseDamage.Add(SpellSlot.W, new[] {75, 120, 165, 210, 255});
            BaseDamage.Add(SpellSlot.E, new[] {70, 105, 140, 175, 210});
            BaseDamage.Add(SpellSlot.R, new[] {150, 250, 350});

            BonusDamage.Add(SpellSlot.Q, new[] {0.65f, 0.65f, 0.65f, 0.65f, 0.65f});
            BonusDamage.Add(SpellSlot.W, new[] {0.6f, 0.6f, 0.6f, 0.6f, 0.6f});
            BonusDamage.Add(SpellSlot.E, new[] {0.55f, 0.55f, 0.55f, 0.55f, 0.55f});
            BonusDamage.Add(SpellSlot.R, new[] {0.5f, 0.5f, 0.5f});
        }

        public static float CalculateDamage(SpellSlot slot, Obj_AI_Base unit)
        {
            if (slot == SpellSlot.Internal)
            {
                return Player.Instance.CalculateDamageOnUnit(unit, DamageType.Magical, unit.MaxHealth*0.08f) - unit.FlatHPRegenMod*4;
            }

            var spellLevel = Player.GetSpell(slot).Level;
            var abilityPower = Player.Instance.TotalMagicalDamage;
            var baseDmg = BaseDamage[slot];
            var bonusDmg = BonusDamage[slot];

            if (spellLevel == 0)
            {
                return 0;
            }

            return Player.Instance.CalculateDamageOnUnit(unit, DamageType.Magical,
                baseDmg[spellLevel - 1] + bonusDmg[spellLevel - 1]*abilityPower);
        }

        public static float TotalDamage(SpellSlot slot, Obj_AI_Base unit)
        {
            return CalculateDamage(slot, unit) + CalculateDamage(SpellSlot.Internal, unit);
        }

        public static bool Killable(this Obj_AI_Base target, SpellSlot slot)
        {
            return TotalDamage(slot, target) >= target.Health;
        }

        public static float GetIgniteDamage()
        {
            return (10 + Player.Instance.Level*4)*5;
        }

        public static float GetBlazeRemainingDamage(Obj_AI_Base unit)
        {
            var buff = unit.GetBuff("BrandAblaze");

            if (buff == null)
            {
                return 0;
            }

            return Player.Instance.CalculateDamageOnUnit(unit, DamageType.Magical,
                unit.MaxHealth*0.02f*(float) Math.Floor(buff.EndTime - Game.Time));
        }

        public static bool WillDie(this Obj_AI_Base unit)
        {
            return GetBlazeRemainingDamage(unit) >= unit.Health;
        }
    }
}
