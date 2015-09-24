using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ezEvade;
using EloBuddy;
using EloBuddy.SDK.Menu;
using SharpDX;

namespace EzEvade
{
    public static class Burrito
    {
        public static SpellSlot GetSpellSlot(this AIHeroClient unit, string name)
        {
            foreach (var spell in
                unit.Spellbook.Spells.Where(
                    spell => String.Equals(spell.Name, name, StringComparison.CurrentCultureIgnoreCase)))
            {
                return spell.Slot;
            }

            return SpellSlot.Unknown;
        }

        public static Menu AddSubMenuEx(this Menu menu, string display, string unique)
        {
            var submenu = menu.AddSubMenu(display, unique);
            ObjectCache.menuCache.AddMenuToCache(submenu);
            return submenu;
        }
    }
}
