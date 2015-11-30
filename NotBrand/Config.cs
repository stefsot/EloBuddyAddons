using EloBuddy.SDK.Menu;
using EloBuddy.SDK.Menu.Values;

namespace NotBrand
{
    static class Config
    {
        public static Menu Menu { get; set; }
        public static Menu HarassMenu { get; set; }
        public static Menu LastHitMenu { get; set; }
        public static Menu LaneClearMenu { get; set; }
        public static Menu DrawMenu { get; set; }

        static Config()
        {
            Menu = MainMenu.AddMenu("Not Brand", "NotBrand");

            Menu.AddGroupLabel("Combo");
            Menu.Add("comboQ", new CheckBox("Use Q"));
            Menu.Add("comboW", new CheckBox("Use W"));
            Menu.Add("comboE", new CheckBox("Use E"));
            Menu.Add("comboR", new CheckBox("Use R"));
            Menu.Add("minEnemiesR", new Slider("Minimum enemies to use R", 1, 1, 6));
            Menu.AddSeparator();
            Menu.AddGroupLabel("Killsteal");
            Menu.Add("ksQ", new CheckBox("Use Q"));
            Menu.Add("ksW", new CheckBox("Use W"));
            Menu.Add("ksE", new CheckBox("Use E"));
            Menu.Add("ksR", new CheckBox("Use R"));
            Menu.Add("ksIgnite", new CheckBox("Use Ignite"));

            HarassMenu = Menu.AddSubMenu("Harass");
            HarassMenu.AddGroupLabel("Spells");
            HarassMenu.Add("harassQ", new CheckBox("Use Q"));
            HarassMenu.Add("harassQmana", new Slider("Mininum mana % to use Q", 15, 0, 100));
            HarassMenu.AddSeparator();
            HarassMenu.Add("harassW", new CheckBox("Use W"));
            HarassMenu.Add("harassWmana", new Slider("Mininum mana % to use W", 15, 0, 100));
            HarassMenu.AddSeparator();
            HarassMenu.Add("harassE", new CheckBox("Use E"));
            HarassMenu.Add("harassEmana", new Slider("Mininum mana % to use E", 15, 0, 100));

            //LastHitMenu = Menu.AddSubMenu("Last Hit");
            //LastHitMenu.AddGroupLabel("Spells");
            //LastHitMenu.Add("lastHitQ", new CheckBox("Use Q"));
            //LastHitMenu.Add("minManaQ", new Slider("Mininum mana % to use Q", 15, 0, 100));
            //LastHitMenu.Add("lastHitE", new CheckBox("Use E"));
            //LastHitMenu.Add("minManaE", new Slider("Mininum mana % to use E", 15, 0, 100));

            LaneClearMenu = Menu.AddSubMenu("Lane Clear");
            LaneClearMenu.AddGroupLabel("Spells");
            LaneClearMenu.Add("laneClearW", new CheckBox("Use W"));
            LaneClearMenu.Add("minMinionsW", new Slider("Minimum minions to use W", 2, 1, 6));
            LaneClearMenu.Add("minManaW", new Slider("Mininum mana % to use W", 25, 0, 100));
            LaneClearMenu.AddSeparator();
            LaneClearMenu.Add("laneClearE", new CheckBox("Use E"));
            LaneClearMenu.Add("minMinionsE", new Slider("Minimum minions to use E", 2, 1, 6));
            LaneClearMenu.Add("minManaE", new Slider("Mininum mana % to use E", 25, 0, 100));

            DrawMenu = Menu.AddSubMenu("Drawings");
            DrawMenu.Add("drawQ", new CheckBox("Draw Q"));
            DrawMenu.Add("drawW", new CheckBox("Draw W"));
            DrawMenu.Add("drawE", new CheckBox("Draw E"));
            DrawMenu.Add("drawR", new CheckBox("Draw R"));
        }

        public static void Initialize()
        {
        }
    }
}
