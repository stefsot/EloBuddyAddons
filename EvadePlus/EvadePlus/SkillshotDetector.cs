using System;
using System.Collections.Generic;
using System.Linq;
using EloBuddy;
using SharpDX;

namespace EvadePlus
{
    public class SkillshotDetector
    {
        #region "Events"

        public delegate void OnSkillshotDetectedDelegate(EvadeSkillshot skillshot, bool isProcessSpell);

        public event OnSkillshotDetectedDelegate OnSkillshotDetected;

        public delegate void OnSkillshotDeletedDelegate(EvadeSkillshot skillshot);

        public event OnSkillshotDeletedDelegate OnSkillshotDeleted;

        public delegate void OnUpdateSkillshotsDelegate(EvadeSkillshot skillshot, bool remove, bool isProcessSpell);

        public event OnUpdateSkillshotsDelegate OnUpdateSkillshots;

        #endregion

        public readonly List<EvadeSkillshot> DetectedSkillshots = new List<EvadeSkillshot>();
        public DetectionTeam TeamDetect;
        public bool EnableFoWDetection;

        public SkillshotDetector(DetectionTeam teamDetect = DetectionTeam.EnemyTeam, bool enableFoWDetection = true)
        {
            TeamDetect = teamDetect;
            EnableFoWDetection = enableFoWDetection;

            Game.OnTick += OnTick;
            GameObject.OnCreate += GameObjectOnCreate;
            GameObject.OnDelete += GameObjectOnDelete;
            Obj_AI_Base.OnProcessSpellCast += OnProcessSpellCast;
            Spellbook.OnStopCast += OnStopCast;
            Drawing.OnDraw += OnDraw;
        }

        public bool IsValidTeam(GameObjectTeam team)
        {
            if (team == GameObjectTeam.Unknown)
                return true;

            switch (TeamDetect)
            {
                case DetectionTeam.AllyTeam:
                    return team == Utils.PlayerTeam();
                case DetectionTeam.EnemyTeam:
                    return team != Utils.PlayerTeam();
                case DetectionTeam.AnyTeam:
                    return true;
            }

            return false;
        }

        private void OnTick(EventArgs args)
        {
            foreach (var skillshot in DetectedSkillshots.Where(v => !v.IsValid))
            {
                if (OnSkillshotDeleted != null)
                    OnSkillshotDeleted(skillshot);

                if (OnUpdateSkillshots != null)
                    OnUpdateSkillshots(skillshot, true, false);

                skillshot.OnDispose();
            }

            DetectedSkillshots.RemoveAll(v => !v.IsValid);

            foreach (var c in DetectedSkillshots)
                c.OnTick();
        }

        private void OnProcessSpellCast(Obj_AI_Base sender, GameObjectProcessSpellCastEventArgs args)
        {
            if (args.IsToggle)
            {
                return;
            }

            var skillshot =
                SkillshotDatabase.Database.FirstOrDefault(
                    evadeSkillshot => evadeSkillshot.SpellData.SpellName == args.SData.Name);

            if (skillshot != null)
            {
                var nSkillshot = skillshot.NewInstance();
                nSkillshot.SkillshotDetector = this;
                nSkillshot.Caster = sender;
                nSkillshot.CastArgs = args;
                nSkillshot.SData = args.SData;
                nSkillshot.Team = sender.Team;

                if (IsValidTeam(nSkillshot.Team))
                {
                    DetectedSkillshots.Add(nSkillshot);
                    nSkillshot.OnCreate(null);
                    nSkillshot.OnSpellDetection(sender, args);

                    if (OnSkillshotDetected != null)
                        OnSkillshotDetected(nSkillshot, true);

                    if (OnUpdateSkillshots != null)
                        OnUpdateSkillshots(nSkillshot, false, true);
                }
            }
        }

        private void GameObjectOnCreate(GameObject sender, EventArgs args)
        {
            // if (Utils.GetTeam(sender) == Utils.PlayerTeam())
            //Chat.Print("create {0} {1} {2} {3}", sender.Team, sender.GetType().ToString(), Utils.GetGameObjectName(sender), sender.Index);

            var skillshot =
                SkillshotDatabase.Database.FirstOrDefault(
                    evadeSkillshot => evadeSkillshot.SpellData.MissileSpellName == Utils.GetGameObjectName(sender));

            if (skillshot != null)
            {
                var nSkillshot = skillshot.NewInstance();
                nSkillshot.SkillshotDetector = this;
                nSkillshot.SpawnObject = sender;
                nSkillshot.Team = Utils.GetTeam(sender);

                if (IsValidTeam(nSkillshot.Team) && (EnableFoWDetection || !nSkillshot.IsFromFow()))
                {
                    DetectedSkillshots.Add(nSkillshot);
                    nSkillshot.OnCreate(sender);

                    if (OnSkillshotDetected != null)
                        OnSkillshotDetected(nSkillshot, false);

                    if (OnUpdateSkillshots != null)
                        OnUpdateSkillshots(nSkillshot, false, false);
                }
            }

            foreach (var c in DetectedSkillshots)
                c.OnCreateObject(sender);
        }

        private void GameObjectOnDelete(GameObject sender, EventArgs args)
        {
            //if (Utils.GetTeam(sender) == Utils.PlayerTeam())
            //Chat.Print("delete {0} {1} {2} {3}", sender.Team, sender.GetType().ToString(), Utils.GetGameObjectName(sender), sender.Index);

            foreach (
                var c in DetectedSkillshots.Where(v => v.SpawnObject != null && v.SpawnObject.Index == sender.Index))
            {
                if (c.OnDelete(sender))
                    c.IsValid = false;
            }

            foreach (var c in DetectedSkillshots)
                c.OnDeleteObject(sender);
        }

        private void OnStopCast(Obj_AI_Base sender, SpellbookStopCastEventArgs args)
        {
            if (sender == null)
            {
                return;
            }

            if (args.ForceStop || args.StopAnimation)
            {
                foreach (
                    var c in
                        DetectedSkillshots.Where(
                            v => v.SpawnObject == null && v.Caster != null && v.Caster.IsMe))
                {
                    c.IsValid = false;
                }
            }
        }

        private void OnDraw(EventArgs args)
        {
            foreach (var c in DetectedSkillshots)
                c.OnDraw();
        }
    }

    public enum DetectionTeam
    {
        AllyTeam,
        EnemyTeam,
        AnyTeam,
    }
}