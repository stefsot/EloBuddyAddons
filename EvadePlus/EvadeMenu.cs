using System.Collections.Generic;
using System.Linq;
using EloBuddy.SDK;
using EloBuddy.SDK.Menu;
using EloBuddy.SDK.Menu.Values;

namespace EvadePlus
{
    internal class EvadeMenu
    {
        public static Menu MainMenu { get; private set; }
        public static Menu SkillshotMenu { get; private set; }
        public static Menu SpellMenu { get; private set; }
        public static Menu DrawMenu { get; private set; }
        public static Menu HotkeysMenu { get; private set; }

        public static readonly Dictionary<string, EvadeSkillshot> MenuSkillshots = new Dictionary<string, EvadeSkillshot>();

        public static void CreateMenu()
        {
            if (MainMenu != null)
            {
                return;
            }

            MainMenu = EloBuddy.SDK.Menu.MainMenu.AddMenu("Evade+", "EvadePlus");

            // Set up main menu
            MainMenu.AddGroupLabel("General Settings");
            MainMenu.Add("fowDetection", new CheckBox("Enable FOW detection"));
            MainMenu.AddLabel("On: for dodging through fog of war, Off: for more human behaviour");
            MainMenu.AddSeparator(3);

            MainMenu.Add("processSpellDetection", new CheckBox("Enable Process Spell Detection"));
            MainMenu.AddLabel("skillshot detection before the missile is created, recommended: On");
            MainMenu.AddSeparator(3);

            MainMenu.Add("limitDetectionRange", new CheckBox("Limit Spell Detection Range"));
            MainMenu.AddLabel("detect only skillshots near you, recommended: On");
            MainMenu.AddSeparator(3);

            MainMenu.Add("recalculatePosition", new CheckBox("Allow recalculation of evade position", false));
            MainMenu.AddLabel("allow change of evading path, recommended: Off");
            MainMenu.AddSeparator(3);

            MainMenu.Add("moveToInitialPosition", new CheckBox("Move to desired position after evade.", false));
            MainMenu.AddLabel("move to your desired location after evading");
            MainMenu.AddSeparator(3);

            MainMenu.Add("serverTimeBuffer", new Slider("Server Time Buffer", 0, 0, 200));
            MainMenu.AddLabel("the extra time it is included during evade calculation");
            MainMenu.AddSeparator();

            MainMenu.AddGroupLabel("Humanizer");
            MainMenu.Add("skillshotActivationDelay", new Slider("Evade delay", 0, 0, 400));
            MainMenu.AddSeparator(10);

            MainMenu.Add("extraEvadeRange", new Slider("Extra Evade Range", 0, 0, 300));
            MainMenu.Add("randomizeExtraEvadeRange", new CheckBox("Randomize Extra Evade Range", false));

            // Set up skillshot menu
            var heroes = Program.DeveloperMode ? EntityManager.Heroes.AllHeroes : EntityManager.Heroes.Enemies;
            var heroNames = heroes.Select(obj => obj.ChampionName).ToArray();
            var skillshots =
                SkillshotDatabase.Database.Where(s => heroNames.Contains(s.SpellData.ChampionName)).ToList();
            skillshots.AddRange(
                SkillshotDatabase.Database.Where(
                    s =>
                        s.SpellData.ChampionName == "AllChampions" &&
                        heroes.Any(obj => obj.Spellbook.Spells.Select(c => c.Name).Contains(s.SpellData.SpellName))));

            SkillshotMenu = MainMenu.AddSubMenu("Skillshots");
            SkillshotMenu.AddLabel(string.Format("Skillshots Loaded {0}", skillshots.Count));
            SkillshotMenu.AddSeparator();

            foreach (var c in skillshots)
            {
                var skillshotString = c.ToString().ToLower();

                if (MenuSkillshots.ContainsKey(skillshotString))
                    continue;

                MenuSkillshots.Add(skillshotString, c);

                SkillshotMenu.AddGroupLabel(c.DisplayText);
                SkillshotMenu.Add(skillshotString + "/enable", new CheckBox("Dodge"));
                SkillshotMenu.Add(skillshotString + "/draw", new CheckBox("Draw"));

                var dangerous = new CheckBox("Dangerous", c.SpellData.IsDangerous);
                dangerous.OnValueChange += delegate(ValueBase<bool> sender, ValueBase<bool>.ValueChangeArgs args)
                {
                    GetSkillshot(sender.SerializationId).SpellData.IsDangerous = args.NewValue;
                };
                SkillshotMenu.Add(skillshotString + "/dangerous", dangerous);

                var dangerValue = new Slider("Danger Value", c.SpellData.DangerValue, 1, 5);
                dangerValue.OnValueChange += delegate(ValueBase<int> sender, ValueBase<int>.ValueChangeArgs args)
                {
                    GetSkillshot(sender.SerializationId).SpellData.DangerValue = args.NewValue;
                };
                SkillshotMenu.Add(skillshotString + "/dangervalue", dangerValue);

                SkillshotMenu.AddSeparator();
            }

            // Set up spell menu
            SpellMenu = MainMenu.AddSubMenu("Evading Spells");
            SpellMenu.AddGroupLabel("Flash");
            SpellMenu.Add("flash", new Slider("Danger Value", 5, 0, 5));

            // Set up draw menu
            DrawMenu = MainMenu.AddSubMenu("Drawings");
            DrawMenu.AddGroupLabel("Evade Drawings");
            DrawMenu.Add("disableAllDrawings", new CheckBox("Disable All Drawings", false));
            DrawMenu.Add("drawEvadePoint", new CheckBox("Draw Evade Point"));
            DrawMenu.Add("drawEvadeStatus", new CheckBox("Draw Evade Status"));
            DrawMenu.Add("drawDangerPolygon", new CheckBox("Draw Danger Polygon", false));
            DrawMenu.AddSeparator();
            DrawMenu.Add("drawPath", new CheckBox("Draw Autpathing Path"));

            // Set up controls menu
            HotkeysMenu = MainMenu.AddSubMenu("Hotkeys");
            HotkeysMenu.AddGroupLabel("Hotkeys");
            HotkeysMenu.Add("enableEvade", new KeyBind("Enable Evade", true, KeyBind.BindTypes.PressToggle, 'M'));
            HotkeysMenu.Add("dodgeOnlyDangerous", new KeyBind("Dodge Only Dangerous", false, KeyBind.BindTypes.HoldActive));
        }

        private static EvadeSkillshot GetSkillshot(string s)
        {
            return MenuSkillshots[s.ToLower().Split('/')[0]];
        }

        public static bool IsSkillshotEnabled(EvadeSkillshot skillshot)
        {
            var valueBase = SkillshotMenu[skillshot + "/enable"];
            return valueBase != null && valueBase.Cast<CheckBox>().CurrentValue;
        }

        public static bool IsSkillshotDrawingEnabled(EvadeSkillshot skillshot)
        {
            var valueBase = SkillshotMenu[skillshot + "/draw"];
            return valueBase != null && valueBase.Cast<CheckBox>().CurrentValue;
        }
    }
}