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
using DamageLibrary = EloBuddy.SDK.DamageLibrary;

using SharpDX;
using Color = System.Drawing.Color;

namespace GodSpeedRengar
{
    public static class Auto
    {
        public static void Initialize()
        {
            Game.OnTick += Game_OnTick;
            Interrupter.OnInterruptableSpell += Interrupter_OnInterruptableSpell;
        }

        private static void Interrupter_OnInterruptableSpell(Obj_AI_Base sender, Interrupter.InterruptableSpellEventArgs e)
        {
            if (Variables.AutoEInterrupt.CurrentValue && Player.Instance.Mana == 5 && Variables.E.IsReady())
            {
                if (sender.IsValidTarget(Variables.E.Range))
                {
                    Variables.E.Cast(sender);
                }
            }
        }

        private static void Game_OnTick(EventArgs args)
        {
            if (Player.Instance.Health * 100 / Player.Instance.MaxHealth <= Variables.AutoWHeal.CurrentValue
                && Player.Instance.Mana == 5 && Variables.W.IsReady())
            {
                Variables.W.Cast(Player.Instance);
            }

            foreach (var hero in EntityManager.Heroes.Enemies.Where(x => x.IsValidCheck()))
            {
                if (Variables.AutoSmiteKS.CurrentValue && Checker.SmiteReady() && Checker.GetSmiteDamage(hero) >= hero.Health
                    && Player.Instance.Position.To2D().Distance(hero.Position.To2D()) 
                    <= 500 + Player.Instance.BoundingRadius + hero.BoundingRadius)
                    Player.Instance.Spellbook.CastSpell(Variables.Smite, hero);

                if (Variables.AutoWKS.CurrentValue && Variables.W.IsReady() && Player.Instance.IsInRange(hero, 500)
                    && DamageLibrary.GetSpellDamage(Player.Instance,hero,SpellSlot.W) > hero.Health )
                {
                    Variables.W.Cast(Player.Instance);
                }

                if (Variables.AutoESK.CurrentValue && Variables.E.IsReady() && Player.Instance.IsInRange(hero, Variables.E.Range)
                    && DamageLibrary.GetSpellDamage(Player.Instance, hero, SpellSlot.E) > hero.Health )
                {
                    Variables.E.Cast(hero);
                }
            }

            if (Variables.AutoSmiteSteal.CurrentValue && Checker.SmiteReady())
            {
                var creep = EntityManager.MinionsAndMonsters.GetJungleMonsters(Player.Instance.Position,800).
                    Where(x => x.BaseSkinName == "SRU_Dragon" || x.BaseSkinName == "SRU_Baron");
                foreach (var x in creep.Where(y => Player.Instance.Distance(y.Position) 
                        <= Player.Instance.BoundingRadius + 500 + y.BoundingRadius))
                {
                    if (x != null && x.Health <= Checker.GetSmiteDamage())
                        Player.Instance.Spellbook.CastSpell(Variables.Smite, x);
                }
            }
        }
    }
}
