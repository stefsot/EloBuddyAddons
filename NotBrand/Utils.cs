using System;
using System.Collections.Generic;
using System.Linq;
using EloBuddy;
using EloBuddy.SDK;
using SharpDX;

namespace NotBrand
{
    static class Utils
    {
        internal static Tuple<T[], Vector2>[] GroupObjects<T>(IEnumerable<T> objects, float range) where T : GameObject
        {
            var groups = new List<List<T>>();

            foreach (var obj in objects)
            {
                var newGroup = new List<T> {obj};

                newGroup.AddRange(objects.Where(r => r.Index != obj.Index && r.Position.Distance(obj.Position, true) <= range.Pow()));

                if (groups.All(g => g.Count(p => newGroup.Contains(p)) != newGroup.Count))
                {
                    groups.Add(newGroup);
                }
            }

            var result =
                groups.Select(
                    group =>
                        new Tuple<T[], Vector2>(group.ToArray(),
                            CenterPoint(group.Select(obj => obj.Position.To2D()).ToArray())))
                    .OrderByDescending(g => g.Item1.Length);

            return result.ToArray();
        }

        internal static Vector2 CenterPoint(Vector2[] points)
        {
            if (!points.Any())
                return Vector2.Zero;

            return new Vector2(points.Sum(v => v.X)/points.Length, points.Sum(v => v.Y)/points.Length);
        }
    }
}
