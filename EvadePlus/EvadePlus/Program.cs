using System.Drawing;
using System.Linq;
using Elobuddy.Testing;
using EloBuddy;
using EloBuddy.SDK;
using EloBuddy.SDK.Events;

namespace EvadePlus
{
    internal class Program
    {
        private static SkillshotDetector Detector;
        private static EvadePlus Evade;

        private static void Main(string[] args)
        {
            Hacks.AntiAFK = true;
            Bootstrap.Init(null);

            Loading.OnLoadingComplete += delegate
            {
                Detector = new SkillshotDetector(DetectionTeam.EnemyTeam);
                Evade = new EvadePlus(Detector);
                EvadeMenu.CreateMenu();
            };

            Drawing.OnDraw += delegate
            {
                foreach (var tower in ObjectManager.Get<Obj_AI_Turret>().Where(t => t.IsEnemy && !t.IsDead && t.Distance(Player.Instance, true) < 1200.Pow()))
                {
                    Drawing.DrawCircle(tower.Position, 800 + Player.Instance.BoundingRadius, Color.Red);
                }
            };
        }
    }
}