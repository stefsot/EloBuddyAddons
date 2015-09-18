using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EloBuddy;
using EloBuddy.SDK.Menu;
using EloBuddy.SDK.Menu.Values;
using EvadePlus;

namespace Elobuddy.Testing
{
    static class EvadeMenu
    {
        public static Menu Menu;

        public static void CreateMenu()
        {
            Menu = MainMenu.AddMenu("Evade+", "EvadePlus");
            Menu.AddGroupLabel("EvadePlus");
            Menu.AddLabel("Evade+ for EloBuddy bla bla bla");
            Menu.AddSeparator();
            Menu.AddLabel("Text here.");
            Menu.AddLabel("Whatever.");

            var skillshotMenu = Menu.AddSubMenu("Enemy Skillshots");
            var enemyChampions =
                ObjectManager.Get<AIHeroClient>().Where(obj => obj.IsEnemy).Select(obj => obj.ChampionName).ToArray();

            foreach (var c in SkillshotDatabase.Database.Where(s => enemyChampions.Contains(s.SpellData.ChampionName)))
            {
                Console.WriteLine(c);
                skillshotMenu.AddGroupLabel(c.DisplayText);
                skillshotMenu.Add(c + "_enable", new CheckBox("Enable", true));
                skillshotMenu.Add(c + "_draw", new CheckBox("Draw", true));
                skillshotMenu.Add(c + "_dangerValue", new Slider("Danger Value", c.SpellData.DangerValue, 0, 5));
            }
        }
    }
}
