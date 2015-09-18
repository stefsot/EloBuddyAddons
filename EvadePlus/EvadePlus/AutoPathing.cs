using System;
using System.Collections.Generic;
using System.Linq;
using EloBuddy;
using EloBuddy.SDK;
using EvadePlus;
using SharpDX;
using Color = System.Drawing.Color;

namespace EvedePlus
{
    public static class AutoPathing
    {
        public static Vector2[] Path { get; private set; }
        public static bool IsPathing { get; private set; }
        public static int Index;

        public static Vector2 CurrentPoint
        {
            get { return Path[Index]; }
        }

        public static float SwitchDistance
        {
            get { return (Game.Ping)*Player.Instance.MoveSpeed/1000 + 90; }
        }

        static AutoPathing()
        {
            Game.OnTick += OnTick;
            Drawing.OnDraw += OnDraw;
        }

        private static void OnDraw(EventArgs args)
        {
            if (Path == null || !IsPathing)
                return;

            Utils.DrawPath(Path, Color.Aqua);
            //Utils.DrawPath(Player.Instance.Path.ToVector2(), Color.Red);

            //if (Index <= Path.Length - 1)
            //    Drawing.DrawCircle(CurrentPoint.To3DWorld(), 90, Color.Blue);
        }

        private static void OnTick(EventArgs args)
        {
            if (Path == null || Index > Path.Length - 1 || Player.Instance.IsDead)
                StopPath();

            if (!IsPathing || !Player.Instance.CanMove)
                return;

            if (Player.Instance.ServerPosition.To2D().Distance(CurrentPoint, true) <= SwitchDistance.Pow())
            {
                Index += 1;
            }

            if (Index <= Path.Length - 1 &&
                (Player.Instance.Path.Last().Distance(CurrentPoint, true) > SwitchDistance.Pow()))
            {
                Player.IssueOrder(GameObjectOrder.MoveTo, CurrentPoint.To3DWorld(), false);
            }
        }

        public static void StopPath()
        {
            Path = null;
            IsPathing = false;
        }

        public static void DoPath(Vector2[] path)
        {
            if (path == null || path.Length == 0)
                return;

            path = CleanPath(path);

            Path = path;
            IsPathing = true;
            Index = 0;
        }

        public static Vector2[] CleanPath(Vector2[] path, float tolerance = 100)
        {
            var cleanPath = new List<Vector2> {path.First()};
            for (var i = 1; i < path.Length - 1; i++)
            {
                if (path[i].Distance(cleanPath.Last(), true) > tolerance.Pow())
                    cleanPath.Add(path[i]);
            }
            cleanPath.Add(path.Last());

            //cleanPath.RemoveAt(0);
            return cleanPath.ToArray();
        }

        public static void DoPath(Vector2 end)
        {
            DoPath(new[] {end});
        }

        public static bool ReachedPoint(Vector2 point)
        {
            const int compareDistance = 80*80;

            for (var i = 0; i < Index; i++)
            {
                if (Path[i].Distance(point, true) <= compareDistance)
                    return true;
            }

            return CurrentPoint.Distance(point, true) < compareDistance;
        }

        public static bool IsMovingTowards(Vector2 point)
        {
            if (!IsPathing)
                return false;

            if (Index > Path.Length - 1)
                return false;

            return CurrentPoint.Distance(point, true) <= SwitchDistance;
        }
    }
}