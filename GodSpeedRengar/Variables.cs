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
    public static class Variables
    {
        public static Spell.Active Q;
        public static Spell.Skillshot W; 
        public static Spell.Skillshot E; 
        public static Spell.Active R;
        public static SpellSlot Smite;


        // menu
        public static CheckBox ComboSmite;
        public static CheckBox ComboYoumuu;
        public static Slider ComboMode;
        public static KeyBind ComboSwitchKey;
        public static CheckBox HarassW;
        public static CheckBox HarassE;
        public static CheckBox LaneQ;
        public static CheckBox LaneW;
        public static CheckBox LaneE;
        public static CheckBox LaneTiamat;
        public static CheckBox LaneSave;
        public static CheckBox JungQ;
        public static CheckBox JungW;
        public static CheckBox JungE;
        public static CheckBox JungTiamat;
        public static CheckBox JungSave;
        public static Slider AutoWHeal;
        public static CheckBox AutoEInterrupt;
        public static CheckBox AutoWKS;
        public static CheckBox AutoESK;
        public static CheckBox AutoSmiteKS;
        public static CheckBox AutoSmiteSteal;
        public static CheckBox DrawMode;
        public static CheckBox DrawSelectedTarget;

        public static CheckBox MagnetEnable;
        public static Slider MagnetRange;

        public static bool IsDoingMagnet = false;

        public static CheckBox UltSelected;
        public static CheckBox BushSelected;


    }
}
