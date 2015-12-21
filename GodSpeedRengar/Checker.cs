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
    public static class Checker
    {
        public static bool CanAttack()
        {
            return Orbwalker.CanAutoAttack &&
                Game.Time * 1000 + Game.Ping / 2 >= subOrb.LastAATick + Player.Instance.AttackDelay * 1000; 
        }
        public static bool CanMove()
        {
            return Orbwalker.CanMove &&
                !subOrb.Dashing;
        }
        public static Vector2 GetPredictedPosition(this Obj_AI_Base target, float delayInSecond)
        {
            var waypoints = new List<Vector2>();
            if (target == null)
                return new Vector2();
            if (target.IsVisible)
            {
                waypoints.Add(target.ServerPosition.To2D());
                var path = target.Path;
                if (path.Length > 0)
                {
                    var first = path[0].To2D();
                    if (first.Distance(waypoints[0], true) > 40)
                    {
                        waypoints.Add(first);
                    }

                    for (int i = 1; i < path.Length; i++)
                    {
                        waypoints.Add(path[i].To2D());
                    }
                }
                if (waypoints.Count <= 1)
                    return target.Position.To2D();
                var tDistance = (delayInSecond + Game.Ping/1000)* target.MoveSpeed;
                for (var i = 0; i < waypoints.Count - 1; i++)
                {
                    var a = waypoints[i];
                    var b = waypoints[i + 1];
                    var d = a.Distance(b);

                    if (d >= tDistance)
                    {
                        var direction = (b - a).Normalized();

                         return a + direction * tDistance;
                    }
                    tDistance -= d;
                }
                return waypoints.LastOrDefault();

            }
            return new Vector2();
        }
        public static bool IsValidCheck(this AIHeroClient target,float? range = null)
        {
            return target.IsValidTarget(range) && !target.IsZombie;
        }
        public static bool HasItem()
        {
            //timat/ravenous/titanic
            if (Item.CanUseItem(3077) || Item.CanUseItem(3074) || Item.CanUseItem(3748))
            {
                return true;
            }
            return false;
        }
        public static void CastItem()
        {
            Item.UseItem(3077);
            Item.UseItem(3074);
            Item.UseItem(3748);
        }
        public static bool HasYoumuu()
        {
            return Item.CanUseItem(3142);
        }
        public static void CastYoumuu()
        {
            Item.UseItem(3142);
        }
        public static int GetSmiteDamage()
        {
            return new int[] { 390, 410, 430, 450, 480, 510, 540, 570, 600, 640, 680, 720, 760, 800, 850, 900, 950, 1000 }
                [Player.Instance.Level - 1];
        }

        public static bool HasSmiteRed
        { get { return (new string[] { "s5_summonersmiteduel" }).Contains(Player.GetSpell(Variables.Smite).Name); } }
        public static bool HasSmiteBlue
        {
            get
            {
                return (new string[] { "s5_summonersmiteplayerganker" }).Contains(Player.GetSpell(Variables.Smite).Name);
            }
        }
        public static int GetSmiteDamage(AIHeroClient target)
        {
            return HasSmiteBlue ? 20 + 8 * ObjectManager.Player.Level :
                   0;
        }
        public static bool SmiteReady()
        {
            return Player.GetSpell(Variables.Smite).IsReady;
        }
    }
}
