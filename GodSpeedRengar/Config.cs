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

using SharpDX;
using Color = System.Drawing.Color;

namespace GodSpeedRengar
{
    public class Config
    {
        public static Menu Menu, Modes, Draw, Magnet, Targetting;
        private static int _lastSwitchTick;
        public static void Initialize()
        {
            Menu = MainMenu.AddMenu(Player.Instance.ChampionName, "GodSpeedRengar");
            Menu.AddGroupLabel("Introduction");
            Menu.AddLabel("Don't be a scary cat!");
            
            // Modes
            Modes = Menu.AddSubMenu("Modes", "modes");

            // Combo
            Modes.AddGroupLabel("Combo");
            Variables.ComboSmite =  Modes.Add("comboUseSmite", new CheckBox("Use Smite"));
            Variables.ComboYoumuu = Modes.Add("comboUseYoumuu", new CheckBox("Use Youmuu's while steath"));
            Modes.AddLabel("Modes (1-Snare;2- OneShoot;3- Snare on Jump;4- Q always)");
            Variables.ComboMode = Modes.Add("comboMode", new Slider("Mode",2,1,4));
            Variables.ComboSwitchKey = Modes.Add("comboSwitch", new KeyBind("Modes Switch Key", false, KeyBind.BindTypes.HoldActive, 'T'));

            Modes.AddSeparator();

            //Harass
            Modes.AddGroupLabel("Harass");
            Variables.HarassW = Modes.Add("harassUseW", new CheckBox("Use W"));
            Variables.HarassE = Modes.Add("harassUseE", new CheckBox("Use E"));

            Modes.AddSeparator();

            //LaneClear
            Modes.AddGroupLabel("LaneClear");
            Variables.LaneQ = Modes.Add("laneUseQ", new CheckBox("Use Q"));
            Variables.LaneW = Modes.Add("laneUseW", new CheckBox("Use W"));
            Variables.LaneE = Modes.Add("laneUseE", new CheckBox("Use E"));
            Variables.LaneTiamat = Modes.Add("laneUseTiamat", new CheckBox("Use Tiamat/Hydra"));
            Variables.LaneSave = Modes.Add("laneSave", new CheckBox("Save 5  FEROCITY",false));

            Modes.AddSeparator();

            //JungleClear
            Modes.AddGroupLabel("JungleClear");
            Variables.JungQ = Modes.Add("jungUseQ", new CheckBox("Use Q"));
            Variables.JungW = Modes.Add("jungUseW", new CheckBox("Use W"));
            Variables.JungE = Modes.Add("jungUseE", new CheckBox("Use E"));
            Variables.JungTiamat = Modes.Add("jungUseTiamat", new CheckBox("Use Tiamat/Hydra"));
            Variables.JungSave = Modes.Add("jungSave", new CheckBox("Save 5  FEROCITY", false));

            Modes.AddSeparator();

            //Auto
            Modes.AddGroupLabel("Auto");
            Variables.AutoWHeal = Modes.Add("autoWHeal", new Slider("W Heal if HP <",20,0,100));
            Variables.AutoEInterrupt = Modes.Add("autoEInterrupt", new CheckBox("Interrupt with E"));
            Variables.AutoSmiteKS = Modes.Add("autoSmiteKS", new CheckBox("Smite KS (blue/red)"));
            Variables.AutoESK = Modes.Add("autoEKS", new CheckBox("E Ks"));
            Variables.AutoWKS = Modes.Add("autoWKS", new CheckBox("W Ks"));
            Variables.AutoSmiteSteal = Modes.Add("autoSteal", new CheckBox("Smite steal Drake/Baron"));

            //drawing
            Draw = Menu.AddSubMenu("Drawing","drawing");

            Variables.DrawMode = Draw.Add("drawMode", new CheckBox("Draw Mode"));
            //Variables.DrawSelectedTarget = Draw.Add("drawSelected", new CheckBox("Notify Selected Target While Steath"));

            Magnet = Menu.AddSubMenu("Magnet", "magnet");
            Magnet.AddLabel("Magnet will only works on selected target");
            Variables.MagnetEnable = Magnet.Add("magnetEnable", new CheckBox("Enable", false));
            Variables.MagnetRange = Magnet.Add("magnetRange", new Slider("Magnet Range", 300, 150, 500));

            Targetting = Menu.AddSubMenu("Targetting", "targetting");

            Targetting.AddGroupLabel("Ultimate Jump Targeting");
            Variables.UltSelected = Targetting.Add("ultiSelected", new CheckBox("Priority Selected Target"));
            foreach (var hero in EntityManager.Heroes.Enemies)
            {
                Targetting.Add("ulti" + hero.NetworkId, 
                    new CheckBox(hero.ChampionName + "(" + hero.Name + ")"));
            }

            Targetting.AddGroupLabel("Bush Jump Targeting");
            Variables.BushSelected = Targetting.Add("bushSelected", new CheckBox("Priority Selected Target"));
            foreach (var hero in EntityManager.Heroes.Enemies)
            {
                Targetting.Add("bush" + hero.NetworkId,
                    new Slider(hero.ChampionName + "(" + hero.Name + ")",TargetSelector.GetPriority(hero),1,5));
            }

            Game.OnTick += Game_OnTick;
        }

        private static void Game_OnTick(EventArgs args)
        {
            ComboModeSwitch();
        }

        private static void ComboModeSwitch()
        {
            var lasttime = Environment.TickCount - _lastSwitchTick;
            if (!Variables.ComboSwitchKey.CurrentValue ||
                lasttime <= Game.Ping)
            {
                return;
            }

            switch (Variables.ComboMode.CurrentValue)
            {
                case 1:
                    Variables.ComboMode.CurrentValue = 2;
                    _lastSwitchTick = Environment.TickCount + 300;
                    break;
                case 2:
                    Variables.ComboMode.CurrentValue = 3;
                    _lastSwitchTick = Environment.TickCount + 300;
                    break;
                case 3:
                    Variables.ComboMode.CurrentValue = 4;
                    _lastSwitchTick = Environment.TickCount + 300;
                    break;
                case 4:
                    Variables.ComboMode.CurrentValue = 1;
                    _lastSwitchTick = Environment.TickCount + 300;
                    break;
            }
        }
    }
}
