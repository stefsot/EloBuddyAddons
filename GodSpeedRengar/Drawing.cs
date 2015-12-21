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
    public static class Drawing
    {
        public static void Initialize()
        {
            EloBuddy.Drawing.OnDraw += Drawing_OnDraw;
        }

        private static void Drawing_OnDraw(EventArgs args)
        {
            if (Player.Instance.IsDead)
                return;

            var x = EloBuddy.Drawing.WorldToScreen(Player.Instance.Position);
            var head = EloBuddy.Drawing.WorldToScreen((Player.Instance.Position.To2D() + new Vector2(0, 250)).To3D());
            if (Variables.DrawMode.CurrentValue)
            {
                EloBuddy.Drawing.DrawText(x[0], x[1], Color.White, 
                    new string[] {"Snare","One Shoot","Snare on Jump","Q always" } [Variables.ComboMode.CurrentValue -1]);
            }
            if (Variables.IsDoingMagnet)
            {
                var target = TargetSelector.SelectedTarget;
                if (target.IsValidCheck())
                {
                    var y = EloBuddy.Drawing.WorldToScreen(target.Position);
                    EloBuddy.Drawing.DrawLine(x[0],x[1],y[0],y[1],2,Color.Red);
                }
            }
            if (Player.HasBuff("RengarR"))
            {
                if (Targetting.RjumpTarget.IsValidCheck())
                {
                    var y = EloBuddy.Drawing.WorldToScreen(Targetting.RjumpTarget.Position);
                    EloBuddy.Drawing.DrawLine(x, y, 2, Color.Pink);
                    EloBuddy.Drawing.DrawText(head[0],head[1],Color.Yellow,"R target is: " + Targetting.RjumpTarget.ChampionName);
                }
                else
                {
                    EloBuddy.Drawing.DrawText(head[0], head[1], Color.Yellow, "Please Select Target");
                }
            }
            if (Player.Instance.HasBuff("rengarpassivebuff") && !Player.HasBuff("RengarR") 
                && Targetting.PassiveJumpTarget.IsValidCheck())
            {
                var y = EloBuddy.Drawing.WorldToScreen(Targetting.PassiveJumpTarget.Position);
                EloBuddy.Drawing.DrawLine(x, y, 2, Color.Pink);
            }
        }
    }
}
