using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using EloBuddy;
using EloBuddy.SDK;
using EvedePlus;
using SharpDX;
using Color = System.Drawing.Color;

namespace EvadePlus
{
    internal class EvadePlus
    {
        public SkillshotDetector SkillshotDetector { get; private set; }

        public List<Geometry.Polygon> Polygons
        {
            get
            {
                return SkillshotDetector.DetectedSkillshots.Where(c => c.IsValid).Select(c => c.ToPolygon()).ToList();
            }
        }

        public List<Geometry.Polygon> DangerPolygons
        {
            get { return Geometry.ClipPolygons(Polygons).ToPolygons(); }
        }

        private Vector2 _lastIssueOrderPos;
        private EvadeResult _lastEvadeResult;

        public EvadePlus(SkillshotDetector skillshotDetector)
        {
            Player.OnIssueOrder += OnIssueOrder;
            Spellbook.OnCastSpell += OnCastSpell;
            Drawing.OnDraw += OnDraw;
            Game.OnTick += OnTick;

            SkillshotDetector = skillshotDetector;
            SkillshotDetector.OnSkillshotDetected += OnSkillshotDetected;
            SkillshotDetector.OnSkillshotDeleted += OnSkillshotDeleted;
            SkillshotDetector.OnUpdateSkillshots += OnUpdateSkillshots;
        }

        private void OnIssueOrder(Obj_AI_Base sender, PlayerIssueOrderEventArgs args)
        {
            if (args.Order == GameObjectOrder.AttackUnit)
            {
                _lastIssueOrderPos = Player.Instance.Distance(args.Target, true) >=
                                     Player.Instance.GetAutoAttackRange((AttackableUnit) args.Target).Pow()
                    ? args.Target.Position.To2D()
                    : Player.Instance.Position.To2D();
            }
            else
            {
                _lastIssueOrderPos = (args.Target != null ? args.Target.Position : args.TargetPosition).To2D();
            }

            switch (args.Order)
            {
                case GameObjectOrder.Stop:
                    if (IsChampionInDanger())
                        args.Process = false;
                    else
                        AutoPathing.StopPath();
                    break;

                case GameObjectOrder.HoldPosition:
                    if (IsChampionInDanger())
                        args.Process = false;
                    else
                        AutoPathing.StopPath();
                    break;

                case GameObjectOrder.AttackUnit:
                    if ((Player.Instance.Distance(args.Target, true) >=
                         Player.Instance.GetAutoAttackRange((AttackableUnit) args.Target).Pow() &&
                         !IsPathSafe(Player.Instance.GetPath(_lastIssueOrderPos.To3DWorld(), true).ToVector2())) ||
                        IsChampionInDanger())
                    {
                        AutoPathing.DoPath(GetPath(Player.Instance.ServerPosition.To2D(), _lastIssueOrderPos));
                        args.Process = false;
                    }
                    else
                    {
                        AutoPathing.StopPath();
                    }
                    break;

                default:
                    if (IsChampionInDanger() ||
                        !IsPathSafe(Player.Instance.GetPath(_lastIssueOrderPos.To3DWorld(), true).ToVector2()))
                    {
                        DoEvade(true);
                        args.Process = false;
                    }
                    else
                    {
                        //AutoPathing.DoPath(GetPath(Player.Instance.ServerPosition.To2D(), _lastIssueOrderPos));
                        AutoPathing.StopPath();
                    }
                    //args.Process = false;
                    break;
            }
        }

        private void OnCastSpell(Spellbook sender, SpellbookCastSpellEventArgs args)
        {
            if (args.Slot == SpellSlot.Recall)
            {
                _lastIssueOrderPos = Player.Instance.ServerPosition.To2D();
                AutoPathing.StopPath();
            }

            if (_lastEvadeResult == null)
                return;

            if (AutoPathing.IsMovingTowards(_lastEvadeResult.EvadePoint))
            {
                var sdata = Player.Instance.Spellbook.GetSpell(args.Slot).SData;
                var castTime = sdata.CastTime*1000;

                if (castTime > GetTimeAvailable() - GetWalkingTime(_lastEvadeResult.EvadePoint) && castTime > 0)
                {
                    //args.Process = false;
                    return;
                }
            }

            AutoPathing.StopPath();
        }

        private void OnDraw(EventArgs args)
        {
            Drawing.DrawText(Drawing.WorldToScreen(Player.Instance.Position) - new Vector2(30, 0),
                IsChampionInDanger() ? Color.Red : Color.White, "Evade+ Enabled", 15);

            if (_lastEvadeResult != null)
            {
                Drawing.DrawLine(Drawing.WorldToScreen(_lastEvadeResult.PlayerPos.To3DWorld()),
                    Drawing.WorldToScreen(_lastEvadeResult.EvadePoint.To3DWorld()), 4, Color.DarkRed);
                Drawing.DrawCircle(_lastEvadeResult.EvadePoint.To3DWorld(), 100, Color.Red);
            }
        }

        private void OnTick(EventArgs args)
        {
            if (_lastEvadeResult != null && !IsChampionInDanger())
            {
                if(Player.Instance.IsMoving && !Player.Instance.Spellbook.IsAutoAttacking)
                    AutoPathing.DoPath(GetPath(_lastEvadeResult.EvadePoint, _lastIssueOrderPos));

                _lastEvadeResult = null;
            }
        }

        private void OnSkillshotDetected(EvadeSkillshot skillshot, bool isProcessSpell)
        {
            _lastEvadeResult = null;
            DoEvade();
        }

        private void OnSkillshotDeleted(EvadeSkillshot skillshot)
        {
            //if (Player.Instance.IsMoving &&
            //    IsPathSafe(Player.Instance.GetPath(_lastIssueOrderPos.To3DWorld(), true).ToVector2()))
            //{
            //    AutoPathing.StopPath();

            //    if (!Orbwalker.IsAutoAttacking || Orbwalker.CanBeAborted)
            //        Player.IssueOrder(GameObjectOrder.MoveTo, _lastIssueOrderPos.To3DWorld(), false);
            //}
        }

        private void OnUpdateSkillshots(EvadeSkillshot skillshot, bool remove, bool isProcessSpell)
        {
        }

        public bool IsChampionInDanger(AIHeroClient champion = null)
        {
            champion = champion ?? Player.Instance;
            return DangerPolygons.Any(pol => pol.IsInside(champion.ServerPosition));
        }

        public bool IsPointSafe(Vector2 point)
        {
            return !DangerPolygons.Any(p => p.IsInside(point));
        }

        public bool IsPathSafe(Vector2[] path)
        {
            var cachedPolygons = DangerPolygons;
            for (var i = 0; i < path.Length - 1; i++)
            {
                var lineStart = path[i];
                var lineEnd = path[i + 1];

                if (cachedPolygons.Any(pol =>
                    pol.IsIntersectingWithLineSegment(lineStart, lineEnd) || pol.IsInside(lineEnd) ||
                    pol.IsInside(lineStart)))
                {
                    return false;
                }
            }
            return true;
        }

        public int GetWalkingTime(Vector2 point, AIHeroClient champion = null)
        {
            champion = champion ?? Player.Instance;
            return (int) (champion.ServerPosition.Distance(point)/champion.MoveSpeed*1000);
        }

        public int GetTimeAvailable(AIHeroClient champion = null)
        {
            champion = champion ?? Player.Instance;
            var skillshots =
                SkillshotDetector.DetectedSkillshots.Where(c => c.ToPolygon().IsInside(champion.Position)).ToArray();

            if (skillshots.Length == 0)
                return int.MaxValue;

            var timeAvailable = skillshots.First().GetAvailableTime(champion);

            foreach (var c in skillshots)
            {
                var currentTime = c.GetAvailableTime(champion);
                if (currentTime > 0 && currentTime < timeAvailable)
                {
                    timeAvailable = currentTime;
                }
            }

            return timeAvailable;
        }

        public Vector2[] GetPath(Vector2 start, Vector2 end)
        {
            var extraWidth = 30; //Player.Instance.BoundingRadius + 10;
            var walkPolygons = Geometry.ClipPolygons(
                SkillshotDetector.DetectedSkillshots.Where(c => c.IsValid).Select(c => c.ToPolygon(extraWidth)).ToList())
                .ToPolygons();

            //if (walkPolygons.Any(pol => pol.IsInside(start)))
            //{
            //    Chat.Print("start");
            //    var polPoints =
            //        Geometry.ClipPolygons(
            //            SkillshotDetector.DetectedSkillshots.Where(c => c.IsValid)
            //                .Select(c => c.ToPolygon(extraWidth))
            //                .ToList())
            //            .ToPolygons()
            //            .Where(pol => pol.IsInside(start))
            //            .SelectMany(pol => pol.Points)
            //            .ToList();
            //    polPoints.Sort((p1, p2) => p1.Distance(start, true).CompareTo(p2.Distance(start, true)));
            //    start = polPoints.First().Extend(start, -150);
            //}

            if (walkPolygons.Any(pol => pol.IsInside(end)))
            {
                var polPoints =
                    Geometry.ClipPolygons(
                        SkillshotDetector.DetectedSkillshots.Where(c => c.IsValid)
                            .Select(c => c.ToPolygon(extraWidth))
                            .ToList())
                        .ToPolygons()
                        .Where(pol => pol.IsInside(end))
                        .SelectMany(pol => pol.Points)
                        .ToList();
                polPoints.Sort((p1, p2) => p1.Distance(end, true).CompareTo(p2.Distance(end, true)));
                end = polPoints.First().Extend(end, -extraWidth);
            }

            var ritoPath =
                Player.Instance.GetPath(start.To3DWorld(), end.To3DWorld()).ToArray().ToVector2().ToList();
            var pathPoints = new List<Vector2>();
            var polygonDictionary = new Dictionary<Vector2, Geometry.Polygon>();
            for (var i = 0; i < ritoPath.Count - 1; i++)
            {
                var lineStart = ritoPath[i];
                var lineEnd = ritoPath[i + 1];

                foreach (var pol in walkPolygons)
                {
                    var intersectionPoints = pol.GetIntersectionPointsWithLineSegment(lineStart, lineEnd);
                    foreach (var p in intersectionPoints)
                    {
                        if (!polygonDictionary.ContainsKey(p))
                        {
                            polygonDictionary.Add(p, pol);
                            pathPoints.Add(p);
                        }
                    }
                }
            }
            ritoPath.RemoveAll(p => walkPolygons.Any(pol => pol.IsInside(p)));
            pathPoints.AddRange(ritoPath);
            pathPoints.SortPath(start);

            var path = new List<Vector2>();

            while (pathPoints.Count > 0)
            {
                if (pathPoints.Count == 1)
                {
                    path.Add(pathPoints[0]);
                    break;
                }

                var current = pathPoints[0];
                var next = pathPoints[1];

                Geometry.Polygon pol1;
                Geometry.Polygon pol2;

                if (polygonDictionary.TryGetValue(current, out pol1) && polygonDictionary.TryGetValue(next, out pol2) &&
                    pol1.Equals(pol2))
                {
                    var detailedPolygon = pol1.ToDetailedPolygon();
                    detailedPolygon.Points.Sort(
                        (p1, p2) => p1.Distance(current, true).CompareTo(p2.Distance(current, true)));
                    current = detailedPolygon.Points.First();

                    detailedPolygon.Points.Sort((p1, p2) => p1.Distance(next, true).CompareTo(p2.Distance(next, true)));
                    next = detailedPolygon.Points.First();

                    detailedPolygon = pol1.ToDetailedPolygon();
                    var index = detailedPolygon.Points.FindIndex(p => p == current);
                    var linkedList = new LinkedList<Vector2>(detailedPolygon.Points, index);

                    var nextPath = new List<Vector2>();
                    var previousPath = new List<Vector2>();
                    var nextLength = 0F;
                    var previousLength = 0F;
                    var nextWall = false;
                    var previousWall = false;

                    while (true)
                    {
                        var c = linkedList.Next();

                        if (c.IsWall())
                        {
                            nextWall = true;
                            break;
                        }

                        nextPath.Add(c);

                        if (nextPath.Count > 1)
                            nextLength += nextPath[nextPath.Count - 2].Distance(c, true);

                        if (c == next)
                            break;
                    }

                    linkedList.Index = index;
                    while (true)
                    {
                        var c = linkedList.Previous();

                        if (c.IsWall())
                        {
                            previousWall = true;
                            break;
                        }

                        previousPath.Add(c);

                        if (previousPath.Count > 1)
                            previousLength += previousPath[previousPath.Count - 2].Distance(c, true);

                        if (c == next)
                            break;
                    }

                    var shortest = nextWall && previousWall
                        ? (nextLength > previousLength ? nextPath : previousPath)
                        : (nextWall || previousWall
                            ? (nextWall ? previousPath : nextPath)
                            : nextLength < previousLength ? nextPath : previousPath);
                    path.AddRange(shortest);

                    if (previousWall && nextWall)
                        break;
                }
                else
                {
                    path.Add(current);
                    path.Add(next);
                }

                pathPoints.RemoveRange(0, 2);
            }

            return path.ToArray();
        }

        public EvadeResult GetEvadeResult(Vector2 anchorPoint)
        {

            var serverBuffer = -(Game.Ping/2 + 50);
            var playerPos = Player.Instance.Position.To2D();

            var polygons = DangerPolygons.Where(p => p.IsInside(playerPos)).ToArray();
            var actualTimeAvailable = GetTimeAvailable();
            var timeAvailable = actualTimeAvailable - (Game.Ping/2 + serverBuffer);

            var maxMoveDistance = (timeAvailable/1000F)*Player.Instance.MoveSpeed;
            maxMoveDistance += 20F;
            var potentialSegments = new List<Vector2[]>();

            foreach (var pol in polygons)
            {
                for (var i = 0; i < pol.Points.Count; i++)
                {
                    var lineStart = pol.Points[i];
                    var lineEnd = i == pol.Points.Count - 1 ? pol.Points[0] : pol.Points[i + 1];

                    var result = Utils.GetLineCircleIntersectionPoints(playerPos,
                        maxMoveDistance, lineStart, lineEnd).Where(p => p.IsInLineSegment(lineStart, lineEnd)).ToList();

                    if (result.Count == 0)
                    {
                        if (lineStart.Distance(playerPos, true) < maxMoveDistance.Pow() &&
                            lineEnd.Distance(playerPos, true) < maxMoveDistance.Pow())
                        {
                            result = new[] {lineStart, lineEnd}.ToList();
                        }
                        else
                        {
                            continue;
                        }
                    }

                    if (result.Count == 1)
                    {
                        result.Add(playerPos.Distance(lineStart, true) > playerPos.Distance(lineEnd, true)
                            ? lineEnd
                            : lineStart);
                    }

                    potentialSegments.Add(result.ToArray());
                }
            }

            potentialSegments.RemoveAll(c => c.Length < 2);

            if (potentialSegments.Count == 0)
            {
                //not enough time
                var polygonPoints =
                    polygons.Select(pol => pol.ToDetailedPolygon()).SelectMany(pol => pol.Points).ToList();
                if (polygonPoints.Count > 1)
                {
                    polygonPoints.Sort((p1, p2) => p1.Distance(playerPos, true).CompareTo(p2.Distance(playerPos, true)));
                }

                if (polygonPoints.Count > 0)
                {
                    Console.WriteLine("Evade debug info <no segments>: {0} {1} {2} {3}",
                        GetWalkingTime(polygonPoints.First()), timeAvailable, actualTimeAvailable,
                        polygonPoints.First().Distance(playerPos));
                    return new EvadeResult(polygonPoints.First(), anchorPoint, actualTimeAvailable, timeAvailable, false);
                }

                Chat.Print("[Evade+] warning, no point found!");
                return new EvadeResult(playerPos, anchorPoint, actualTimeAvailable, timeAvailable, false);
            }

            var points = new List<Vector2>();
            foreach (var segment in potentialSegments)
            {
                const int division = 40;
                const int maxdist = 2000;

                var dist = segment[0].Distance(segment[1]);
                if (dist > maxdist)
                {
                    segment[0] = segment[0].Extend(segment[1], dist/2 - maxdist/2);
                    segment[1] = segment[1].Extend(segment[1], dist/2 - maxdist/2);
                    dist = maxdist;
                }

                dist /= division;

                for (var i = 0; i < division; i++)
                {
                    var point = segment[0].Extend(segment[1], i*dist);
                    if (!point.IsWall())
                    {
                        points.Add(point);
                    }
                }
            }

            if (points.Count == 0)
            {
                Chat.Print("[Evade+] no point found....");
                return new EvadeResult(playerPos, anchorPoint, actualTimeAvailable, timeAvailable, true);
            }

            return new EvadeResult(points.OrderByDescending(p => p.Distance(anchorPoint) + p.Distance(playerPos)).Last(), anchorPoint,
                actualTimeAvailable, timeAvailable, true);
        }

        public void DoEvade(bool move = false)
        {
            if (IsChampionInDanger())
            {
                if (_lastEvadeResult == null)
                {
                    _lastEvadeResult = GetEvadeResult(_lastIssueOrderPos);
                    if (!_lastEvadeResult.EnoughTime)
                    {
                        Chat.Print("[Evade+] Not enough time to walk.");
                    }
                    _lastEvadeResult.EvadePoint = _lastEvadeResult.EvadePoint.Extend(Player.Instance, -40);
                    var path = GetPath(_lastEvadeResult.EvadePoint, _lastIssueOrderPos);
                    AutoPathing.DoPath(path);
                    //Player.IssueOrder(GameObjectOrder.MoveTo, _lastEvadeResult.EvadePoint.To3DWorld(), false);
                }
            }
            else
            {
                if (_lastEvadeResult == null && (move || !IsPathSafe(Player.Instance.GetPath(_lastIssueOrderPos.To3DWorld(), true).ToVector2())))
                {
                    var path = GetPath(Player.Instance.ServerPosition.To2D(), _lastIssueOrderPos);
                    path = new[] {Player.Instance.ServerPosition.To2D()}.Concat(path).ToArray();
                    if (IsPathSafe(path))
                        AutoPathing.DoPath(path);
                }
            }
        }

        public class EvadeResult
        {
            public Vector2 PlayerPos { get; set; }
            public Vector2 EvadePoint { get; set; }
            public Vector2 AnchorPoint { get; set; }
            public int TimeAvailable { get; set; }
            public int ActualTimeAvailable { get; set; }
            public bool EnoughTime { get; set; }
            public int TimeCreated { get; set; }

            public EvadeResult(Vector2 evadePoint, Vector2 anchorPoint, int actualTimeAvailable, int timeAvailable,
                bool enoughTime)
            {
                EvadePoint = evadePoint;
                AnchorPoint = anchorPoint;
                ActualTimeAvailable = actualTimeAvailable;
                TimeAvailable = timeAvailable;
                EnoughTime = enoughTime;
                PlayerPos = Player.Instance.Position.To2D();
                TimeCreated = Environment.TickCount;
            }
        }
    }
}