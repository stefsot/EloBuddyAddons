using System;
using System.Linq;
using EloBuddy;
using EloBuddy.SDK;
using EloBuddy.SDK.Events;
using EloBuddy.SDK.Menu;
using EloBuddy.SDK.Menu.Values;
using SharpDX;

namespace SmoothCamera
{
    class Program
    {
        internal enum CameraMode
        {
            Player,
            Teamfight
        }

        internal static Menu Menu;

        internal static Vector2 CameraPos
        {
            get { return new Vector2(Camera.CameraX, Camera.CameraY); }
            set
            {
                Camera.CameraX = value.X;
                Camera.CameraY = value.Y;
            }
        }

        internal static CameraMode Mode = CameraMode.Teamfight;

        internal static float Speed = 0.2f;
        internal static float SpeedScale = 0.0007f;
        internal static float MaxSpeed = 20;

        static void Main(string[] args)
        {
            Loading.OnLoadingComplete += OnLoadingComplete;
        }

        private static void OnLoadingComplete(EventArgs args)
        {
            Menu = MainMenu.AddMenu("Smooth Camera", "smooth camera");

            Menu.Add("keyBindOnly", new CheckBox("Use only with keybind", false));
            Menu.Add("keyBind", new KeyBind("Hold keybind", false, KeyBind.BindTypes.HoldActive));
            Menu.AddSeparator(1);

            Menu.Add("lockCamera", new CheckBox("Lock Camera", false));
            Menu.AddSeparator(1);
            Menu.Add("allowNavigation", new CheckBox("Allow camera navigation"));
            Menu.AddSeparator(1);

            var combobox = new ComboBox("Camera Mode", Enum.GetNames(typeof (CameraMode)), (int) Mode);
            combobox.OnValueChange += delegate(ValueBase<int> sender, ValueBase<int>.ValueChangeArgs changeArgs)
            {
                Mode = (CameraMode) changeArgs.NewValue;
            };
            Menu.Add("cameraMode", combobox);
            Menu.AddSeparator();

            var slider = new Slider("Camera Speed", 20, 1, 100);
            slider.OnValueChange += delegate(ValueBase<int> sender, ValueBase<int>.ValueChangeArgs changeArgs)
            {
                MaxSpeed = changeArgs.NewValue;
            };
            Menu.Add("maximumSpeed", slider);

            slider = new Slider("Camera Smoothing", 70, 10, 1000);
            slider.OnValueChange += delegate(ValueBase<int> sender, ValueBase<int>.ValueChangeArgs changeArgs)
            {
                SpeedScale = changeArgs.NewValue / 100000f;
            };
            Menu.Add("cameraSmoothing", slider);

            //slider = new Slider("Zoom", 2250, 2250, 7000);
            //slider.OnValueChange += delegate(ValueBase<int> sender, ValueBase<int>.ValueChangeArgs changeArgs)
            //{
            //    Camera.SetZoomDistance(changeArgs.NewValue);
            //};
            //Menu.Add("zoom", slider);

            Game.OnUpdate += OnTick;
            Drawing.OnDraw += OnDraw;
        }

        private static void OnDraw(EventArgs args)
        {
        }

        private static void OnTick(EventArgs args)
        {
            if (Game.Mode != GameMode.Running)
            {
                return;
            }

            if (Menu["keyBindOnly"].Cast<CheckBox>().CurrentValue && !Menu["keyBind"].Cast<KeyBind>().CurrentValue)
            {
                return;
            }

            if (Menu["allowNavigation"].Cast<CheckBox>().CurrentValue && IsOnScreenBounds(Game.CursorPos2D))
            {
                return;
            }

            if (Menu["lockCamera"].Cast<CheckBox>().CurrentValue)
            {
                CameraSetTo(Player.Instance.Position);
                return;
            }

            switch (Mode)
            {
                case CameraMode.Player:
                    CameraMoveTo(Player.Instance.Position);
                    break;
                case CameraMode.Teamfight:
                    var range = Player.Instance.IsDead || CameraPos.Distance(Player.Instance, true) > 4000.Pow() ? float.MaxValue : Drawing.Width * 5f;
                    var objects = EntityManager.Heroes.AllHeroes.Where(h => h.IsValidTarget()
                        && h.IsInRange(Player.Instance, range) 
                        && !IsOnScreenBounds(h.Position.WorldToScreen(), 90));
                    var point = objects.Select(h => h.Position.To2D()).ToArray().CenterPoint();

                    if (point.IsZero)
                    {
                        point = Player.Instance.Position.To2D();
                    }

                    CameraMoveTo(point);
                    break;
            }
        }

        internal static void CameraMoveTo(Vector3 point)
        {
            CameraMoveTo(point.To2D());
        }

        internal static void CameraMoveTo(Vector2 point)
        {
            var distance = CameraPos.Distance(point);

            if (distance <= 1)
            {
                return;
            }

            var speed = Math.Max(Speed, Math.Min(MaxSpeed, distance * SpeedScale * MaxSpeed));
            var direction = (point - CameraPos).Normalized() * (speed);

            CameraSetTo(direction + CameraPos);
        }

        internal static void CameraSetTo(Vector3 point)
        {
            CameraSetTo(point.To2D());
        }

        internal static void CameraSetTo(Vector2 point)
        {
            CameraPos = point;
        }

        internal static bool IsOnScreenBounds(Vector2 point, int tolerance = 10)
        {
            return point.X <= tolerance || point.X >= Drawing.Width - tolerance || point.Y <= tolerance || point.Y >= Drawing.Height - tolerance;
        }
    }
}