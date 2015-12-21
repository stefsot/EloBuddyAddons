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
    public static class Magnet
    {
        public static int LastMove;
        public static void Initialize()
        {
            Game.OnTick += Game_OnTick;
        }

        private static void Game_OnTick(EventArgs args)
        {
            if (Variables.MagnetEnable.CurrentValue && Orbwalker.ActiveModesFlags.HasFlag(Orbwalker.ActiveModes.Combo))
            {
                MagnetSelected();
            }
            else
            {
                Variables.IsDoingMagnet = false;
                if (Orbwalker.DisableMovement)
                    Orbwalker.DisableMovement = false; 
            }
        }

        private static void MagnetSelected()
        {
            var target = TargetSelector.SelectedTarget;
            if (target.IsValidCheck(Variables.MagnetRange.CurrentValue))
            {
                Variables.IsDoingMagnet = true;
                if (!Orbwalker.DisableMovement)
                    Orbwalker.DisableMovement = true;
                if (Checker.CanMove() && Environment.TickCount - LastMove >= 50)
                {
                    Player.IssueOrder(GameObjectOrder.MoveTo,target.Position);
                    LastMove = Environment.TickCount;
                }
            }
            else
            {
                Variables.IsDoingMagnet = false;
                if (Orbwalker.DisableMovement)
                    Orbwalker.DisableMovement = false;
            }
        }
    }
}
