using EloBuddy.SDK.Events;

namespace EvadePlus
{
    internal static class Program
    {
        private static SkillshotDetector _skillshotDetector;
        private static EvadePlus _evade;

        private static void Main(string[] args)
        {
            Loading.OnLoadingComplete += delegate
            {
                _skillshotDetector = new SkillshotDetector();
                _evade = new EvadePlus(_skillshotDetector);
                EvadeMenu.CreateMenu();
            };
        }
    }
}
