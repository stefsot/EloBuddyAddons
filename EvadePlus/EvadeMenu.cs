using System;
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
        public static Menu ControlsMenu { get; private set; }

        private static readonly Dictionary<string, EvadeSkillshot> MenuSkillshots =
            new Dictionary<string, EvadeSkillshot>();

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
            MainMenu.Add("processSpellDetection", new CheckBox("Enable Process Spell Detection"));
            MainMenu.Add("limitDetectionRange", new CheckBox("Limit Detection Range"));
            MainMenu.Add("serverBuffer", new Slider("Server Buffer", 30));
            MainMenu.AddSeparator();
            MainMenu.AddSeparator();

            MainMenu.AddGroupLabel("Humanizer");
            MainMenu.Add("skillshotActivationDelay", new Slider("Skillshot Activation Delay", 0, 0, 400));
            MainMenu.AddSeparator(10);
            MainMenu.Add("extraEvadeRange", new Slider("Extra Evade Range", 50, 0, 200));
            MainMenu.Add("randomizeExtraEvadeRange", new CheckBox("Randomize Extra Evade Range", false));

            // Set up skillshot menu
            var enemyChampions = HeroManager.Enemies.Select(obj => obj.ChampionName).ToArray();
            var skillshots =
                SkillshotDatabase.Database.Where(s => enemyChampions.Contains(s.SpellData.ChampionName)).ToArray();

            SkillshotMenu = MainMenu.AddSubMenu("Skillshots");
            SkillshotMenu.AddLabel(string.Format("Skillshots Loaded {0}", skillshots.Length));
            SkillshotMenu.AddSeparator();

            foreach (var c in skillshots)
            {
                var skillshotString = c.ToString().ToLower();

                if (MenuSkillshots.ContainsKey(skillshotString))
                    continue;

                MenuSkillshots.Add(skillshotString, c);

                SkillshotMenu.AddGroupLabel(c.DisplayText);
                SkillshotMenu.Add(skillshotString + "/enable", new CheckBox("Enable"));
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
            SpellMenu = MainMenu.AddSubMenu("Spells");
            SpellMenu.AddGroupLabel("Flash");
            SpellMenu.Add("flash", new Slider("Danger Value", 5, 0, 5));

            // Set up draw menu
            DrawMenu = MainMenu.AddSubMenu("Drawings");
            DrawMenu.AddGroupLabel("Evade Drawings");
            DrawMenu.Add("drawEvadePoint", new CheckBox("Draw Evade Point"));
            DrawMenu.Add("drawEvadeStatus", new CheckBox("Draw Evade Status"));
            DrawMenu.Add("drawDangerPolygon", new CheckBox("Draw Danger Polygon", false));
            DrawMenu.AddSeparator();
            DrawMenu.Add("drawPath", new CheckBox("Draw Autpathing Path"));

            // Set up controls menu
            ControlsMenu = MainMenu.AddSubMenu("Controls");
            ControlsMenu.AddGroupLabel("Controls");
            ControlsMenu.Add("enableEvade", new KeyBind("Enable Evade", true, KeyBind.BindTypes.PressToggle, 'M'));
            ControlsMenu.Add("dodgeOnlyDangerous", new KeyBind("Dodge Only Dangerous", false, KeyBind.BindTypes.HoldActive));
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