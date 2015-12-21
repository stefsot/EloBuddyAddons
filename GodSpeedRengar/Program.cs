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
    class Program
    {

        static void Main(string[] args)
        {
            Loading.OnLoadingComplete += OnLoadingComplete;
        }

        private static void OnLoadingComplete(EventArgs args)
        {
            if( Player.Instance.ChampionName != "Rengar")
            {
              return;
            }

            Variables.Q = new Spell.Active(SpellSlot.Q);
            Variables.W = new Spell.Skillshot(SpellSlot.W,500,SkillShotType.Circular,250,2000,100);
            Variables.W.AllowedCollisionCount = -1;
            Variables.E = new Spell.Skillshot(SpellSlot.E, 1000, SkillShotType.Linear, 250, 1500, 140);
            Variables.R = new Spell.Active(SpellSlot.R);

            foreach (var spell in
                       Player.Instance.Spellbook.Spells.Where(
                         i =>
                               i.Name.ToLower().Contains("smite") &&
            (i.Slot == SpellSlot.Summoner1 || i.Slot == SpellSlot.Summoner2)))
            {
                Variables.Smite = spell.Slot;
            }

            Config.Initialize();
            subOrb.Initialize();
            Combo.Initialize();
            Harass.Initialize();
            LaneClear.Initialize();
            JungleClear.Initialize();
            Auto.Initialize();
            Drawing.Initialize();
            Magnet.Initialize();
            Targetting.Initialize();
        }
    }
}
