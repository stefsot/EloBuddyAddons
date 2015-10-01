using System.Collections.Generic;
using EloBuddy;

namespace EvadePlus
{
    internal static class SkillshotDatabase
    {
        public static readonly List<EvadeSkillshot> Database;

        static SkillshotDatabase()
        {
            Database = new List<EvadeSkillshot>
            {
                new LinearMissileSkillshot
                {
                    SpellData = new SpellData
                    {
                        ChampionName = "AllChampions",
                        SpellName = "summonersnowball",
                        Slot = SpellSlot.Summoner1,
                        Delay = 0,
                        Range = 1600,
                        Radius = 60,
                        MissileSpeed = 1300,
                        DangerValue = 3,
                        MissileSpellName = "SummonerSnowball"
                    }
                },
                new CircularMissileSkillshot
                {
                    SpellData = new SpellData
                    {
                        ChampionName = "Aatrox",
                        SpellName = "AatroxQ",
                        Slot = SpellSlot.Q,
                        Delay = 250,
                        Range = 650,
                        Radius = 285,
                        MissileSpeed = 450,
                        DangerValue = 3,
                        MissileSpellName = "AatroxQ"
                    }
                },
                new LinearMissileSkillshot
                {
                    SpellData = new SpellData
                    {
                        ChampionName = "Aatrox",
                        SpellName = "AatroxE",
                        Slot = SpellSlot.E,
                        Delay = 250,
                        Range = 1075,
                        Radius = 100,
                        MissileSpeed = 1200,
                        DangerValue = 3,
                        MissileSpellName = "AatroxE"
                    }
                },
                new LinearMissileSkillshot
                {
                    SpellData = new SpellData
                    {
                        ChampionName = "Ahri",
                        SpellName = "AhriOrbofDeception",
                        Slot = SpellSlot.Q,
                        Delay = 250,
                        Range = 925,
                        Radius = 100,
                        MissileSpeed = 1750,
                        DangerValue = 3,
                        MissileSpellName = "AhriOrbMissile"
                    }
                },
                new LinearMissileSkillshot
                {
                    SpellData = new SpellData
                    {
                        ChampionName = "Ahri",
                        SpellName = "AhriSeduce",
                        Slot = SpellSlot.E,
                        Delay = 250,
                        Range = 1000,
                        Radius = 60,
                        MissileSpeed = 1550,
                        DangerValue = 3,
                        MissileSpellName = "AhriSeduceMissile"
                    }
                },
                new LinearMissileSkillshot
                {
                    SpellData = new SpellData
                    {
                        ChampionName = "Ahri",
                        SpellName = "AhriOrbofDeception2",
                        Slot = SpellSlot.Q,
                        Delay = 250,
                        Range = 925,
                        Radius = 100,
                        MissileSpeed = 915,
                        DangerValue = 3,
                        MissileSpellName = "AhriOrbofDeception2"
                    }
                },
                new CircularMissileSkillshot
                {
                    SpellData = new SpellData
                    {
                        ChampionName = "Alistar",
                        SpellName = "Pulverize",
                        Slot = SpellSlot.Q,
                        Delay = 0,
                        Range = 365,
                        Radius = 365,
                        MissileSpeed = 0,
                        DangerValue = 3,
                        MissileSpellName = "Pulverize"
                    }
                },
                new CircularMissileSkillshot
                {
                    SpellData = new SpellData
                    {
                        ChampionName = "Amumu",
                        SpellName = "CurseoftheSadMummy",
                        Slot = SpellSlot.R,
                        Delay = 250,
                        Range = 560,
                        Radius = 560,
                        MissileSpeed = 0,
                        DangerValue = 3,
                        MissileSpellName = "CurseoftheSadMummy"
                    }
                },
                new LinearMissileSkillshot
                {
                    SpellData = new SpellData
                    {
                        ChampionName = "Amumu",
                        SpellName = "BandageToss",
                        Slot = SpellSlot.Q,
                        Delay = 250,
                        Range = 1100,
                        Radius = 80,
                        MissileSpeed = 2000,
                        DangerValue = 3,
                        MissileSpellName = "SadMummyBandageToss"
                    }
                },
                new LinearMissileSkillshot
                {
                    SpellData = new SpellData
                    {
                        ChampionName = "Anivia",
                        SpellName = "FlashFrostSpell",
                        Slot = SpellSlot.Q,
                        Delay = 250,
                        Range = 1250,
                        Radius = 110,
                        MissileSpeed = 850,
                        DangerValue = 3,
                        MissileSpellName = "FlashFrostSpell"
                    }
                },
                new CircularMissileSkillshot
                {
                    SpellData = new SpellData
                    {
                        ChampionName = "Annie",
                        SpellName = "Incinerate",
                        Slot = SpellSlot.W,
                        Delay = 250,
                        Range = 625,
                        Radius = 80,
                        MissileSpeed = 0,
                        DangerValue = 3,
                        MissileSpellName = "Incinerate"
                    }
                },
                new CircularMissileSkillshot
                {
                    SpellData = new SpellData
                    {
                        ChampionName = "Annie",
                        SpellName = "InfernalGuardian",
                        Slot = SpellSlot.R,
                        Delay = 250,
                        Range = 600,
                        Radius = 290,
                        MissileSpeed = 0,
                        DangerValue = 3,
                        MissileSpellName = "InfernalGuardian"
                    }
                },
                new LinearMissileSkillshot
                {
                    SpellData = new SpellData
                    {
                        ChampionName = "Ashe",
                        SpellName = "EnchantedCrystalArrow",
                        Slot = SpellSlot.R,
                        Delay = 250,
                        Range = 12500,
                        Radius = 130,
                        MissileSpeed = 1600,
                        DangerValue = 3,
                        MissileSpellName = "EnchantedCrystalArrow"
                    }
                },
                //new LinearMissileSkillshot
                //{
                //    SpellData = new SpellData
                //    {
                //        ChampionName = "Ashe",
                //        SpellName = "Volley",
                //        Slot = SpellSlot.W,
                //        Delay = 250,
                //        Range = 1150,
                //        Radius = 20,
                //        MissileSpeed = 1500,
                //        DangerValue = 3,
                //        MissileSpellName = "VolleyAttack",
                //        ExtraMissiles = 8
                //    }
                //},
                new LinearMissileSkillshot
                {
                    SpellData = new SpellData
                    {
                        ChampionName = "Azir",
                        SpellName = "AzirQ",
                        Slot = SpellSlot.Q,
                        Delay = 250,
                        Range = 800,
                        Radius = 80,
                        MissileSpeed = 1000,
                        DangerValue = 3,
                        MissileSpellName = "AzirQ"
                    }
                },
                new LinearMissileSkillshot
                {
                    SpellData = new SpellData
                    {
                        ChampionName = "Bard",
                        SpellName = "BardQ",
                        Slot = SpellSlot.Q,
                        Delay = 250,
                        Range = 950,
                        Radius = 60,
                        MissileSpeed = 1600,
                        DangerValue = 3,
                        MissileSpellName = "BardQMissile"
                    }
                },
                new LinearMissileSkillshot
                {
                    SpellData = new SpellData
                    {
                        ChampionName = "Blitzcrank",
                        SpellName = "RocketGrab",
                        Slot = SpellSlot.Q,
                        Delay = 250,
                        Range = 1050,
                        Radius = 70,
                        MissileSpeed = 1800,
                        DangerValue = 3,
                        MissileSpellName = "RocketGrabMissile"
                    }
                },
                new LinearMissileSkillshot
                {
                    SpellData = new SpellData
                    {
                        ChampionName = "Brand",
                        SpellName = "BrandBlaze",
                        Slot = SpellSlot.Q,
                        Delay = 250,
                        Range = 1100,
                        Radius = 60,
                        MissileSpeed = 1600,
                        DangerValue = 3,
                        MissileSpellName = "BrandBlazeMissile"
                    }
                },
                new CircularMissileSkillshot
                {
                    SpellData = new SpellData
                    {
                        ChampionName = "Brand",
                        SpellName = "BrandFissure",
                        Slot = SpellSlot.W,
                        Delay = 850,
                        Range = 1100,
                        Radius = 250,
                        MissileSpeed = 0,
                        DangerValue = 3,
                        MissileSpellName = "BrandFissure"
                    }
                },
                new LinearMissileSkillshot
                {
                    SpellData = new SpellData
                    {
                        ChampionName = "Braum",
                        SpellName = "BraumRWrapper",
                        Slot = SpellSlot.R,
                        Delay = 500,
                        Range = 1250,
                        Radius = 100,
                        MissileSpeed = 1125,
                        DangerValue = 3,
                        MissileSpellName = "BraumRWrapper"
                    }
                },
                new LinearMissileSkillshot
                {
                    SpellData = new SpellData
                    {
                        ChampionName = "Braum",
                        SpellName = "BraumQ",
                        Slot = SpellSlot.Q,
                        Delay = 30000,
                        Range = 1000,
                        Radius = 100,
                        MissileSpeed = 1200,
                        DangerValue = 3,
                        MissileSpellName = "BraumQMissile"
                    }
                },
                new LinearMissileSkillshot
                {
                    SpellData = new SpellData
                    {
                        ChampionName = "Caitlyn",
                        SpellName = "CaitlynPiltoverPeacemaker",
                        Slot = SpellSlot.Q,
                        Delay = 625,
                        Range = 1300,
                        Radius = 90,
                        MissileSpeed = 2200,
                        DangerValue = 3,
                        MissileSpellName = "CaitlynPiltoverPeacemaker"
                    }
                },
                new LinearMissileSkillshot
                {
                    SpellData = new SpellData
                    {
                        ChampionName = "Caitlyn",
                        SpellName = "CaitlynEntrapment",
                        Slot = SpellSlot.E,
                        Delay = 125,
                        Range = 950,
                        Radius = 80,
                        MissileSpeed = 2000,
                        DangerValue = 3,
                        MissileSpellName = "CaitlynEntrapmentMissile"
                    }
                },
                new CircularMissileSkillshot
                {
                    SpellData = new SpellData
                    {
                        ChampionName = "Cassiopeia",
                        SpellName = "CassiopeiaPetrifyingGaze",
                        Slot = SpellSlot.R,
                        Delay = 500,
                        Range = 825,
                        Radius = 20,
                        MissileSpeed = 0,
                        DangerValue = 3,
                        MissileSpellName = "CassiopeiaPetrifyingGaze"
                    }
                },
                new CircularMissileSkillshot
                {
                    SpellData = new SpellData
                    {
                        ChampionName = "Cassiopeia",
                        SpellName = "CassiopeiaNoxiousBlast",
                        Slot = SpellSlot.Q,
                        Delay = 825,
                        Range = 600,
                        Radius = 200,
                        MissileSpeed = 0,
                        DangerValue = 3,
                        MissileSpellName = "CassiopeiaNoxiousBlast"
                    }
                },
                new CircularMissileSkillshot
                {
                    SpellData = new SpellData
                    {
                        ChampionName = "Cassiopeia",
                        SpellName = "CassiopeiaMiasma",
                        Slot = SpellSlot.W,
                        Delay = 250,
                        Range = 850,
                        Radius = 220,
                        MissileSpeed = 2500,
                        DangerValue = 3,
                        MissileSpellName = "CassiopeiaMiasma"
                    }
                },
                new CircularMissileSkillshot
                {
                    SpellData = new SpellData
                    {
                        ChampionName = "Chogath",
                        SpellName = "FeralScream",
                        Slot = SpellSlot.W,
                        Delay = 250,
                        Range = 650,
                        Radius = 20,
                        MissileSpeed = 0,
                        DangerValue = 3,
                        MissileSpellName = "FeralScream"
                    }
                },
                new CircularMissileSkillshot
                {
                    SpellData = new SpellData
                    {
                        ChampionName = "Chogath",
                        SpellName = "Rupture",
                        Slot = SpellSlot.Q,
                        Delay = 1200,
                        Range = 950,
                        Radius = 250,
                        MissileSpeed = 0,
                        DangerValue = 3,
                        MissileSpellName = "Rupture"
                    }
                },
                new LinearMissileSkillshot
                {
                    SpellData = new SpellData
                    {
                        ChampionName = "Corki",
                        SpellName = "MissileBarrage2",
                        Slot = SpellSlot.R,
                        Delay = 175,
                        Range = 1500,
                        Radius = 40,
                        MissileSpeed = 2000,
                        DangerValue = 3,
                        MissileSpellName = "MissileBarrageMissile2"
                    }
                },
                new CircularMissileSkillshot
                {
                    SpellData = new SpellData
                    {
                        ChampionName = "Corki",
                        SpellName = "PhosphorusBomb",
                        Slot = SpellSlot.Q,
                        Delay = 500,
                        Range = 825,
                        Radius = 270,
                        MissileSpeed = 1125,
                        DangerValue = 3,
                        MissileSpellName = "PhosphorusBombMissile"
                    }
                },
                new LinearMissileSkillshot
                {
                    SpellData = new SpellData
                    {
                        ChampionName = "Corki",
                        SpellName = "MissileBarrage",
                        Slot = SpellSlot.R,
                        Delay = 175,
                        Range = 1300,
                        Radius = 40,
                        MissileSpeed = 2000,
                        DangerValue = 3,
                        MissileSpellName = "MissileBarrageMissile"
                    }
                },
                new CircularMissileSkillshot
                {
                    SpellData = new SpellData
                    {
                        ChampionName = "Darius",
                        SpellName = "DariusAxeGrabCone",
                        Slot = SpellSlot.E,
                        Delay = 320,
                        Range = 570,
                        Radius = 20,
                        MissileSpeed = 0,
                        DangerValue = 3,
                        MissileSpellName = "DariusAxeGrabCone"
                    }
                },
                new CircularMissileSkillshot //Unknown:SpellType.Arc
                {
                    SpellData = new SpellData
                    {
                        ChampionName = "Diana",
                        SpellName = "DianaArc",
                        Slot = SpellSlot.Q,
                        Delay = 250,
                        Range = 850,
                        Radius = 50,
                        MissileSpeed = 1400,
                        DangerValue = 3,
                        MissileSpellName = "DianaArc"
                    }
                },
                new LinearMissileSkillshot
                {
                    SpellData = new SpellData
                    {
                        ChampionName = "DrMundo",
                        SpellName = "InfectedCleaverMissileCast",
                        Slot = SpellSlot.Q,
                        Delay = 250,
                        Range = 1050,
                        Radius = 60,
                        MissileSpeed = 2000,
                        DangerValue = 3,
                        MissileSpellName = "InfectedCleaverMissile"
                    }
                },
                new LinearMissileSkillshot
                {
                    SpellData = new SpellData
                    {
                        ChampionName = "Draven",
                        SpellName = "DravenRCast",
                        Slot = SpellSlot.R,
                        Delay = 500,
                        Range = 12500,
                        Radius = 160,
                        MissileSpeed = 2000,
                        DangerValue = 3,
                        MissileSpellName = "DravenR"
                    }
                },
                new LinearMissileSkillshot
                {
                    SpellData = new SpellData
                    {
                        ChampionName = "Draven",
                        SpellName = "DravenDoubleShot",
                        Slot = SpellSlot.E,
                        Delay = 250,
                        Range = 1100,
                        Radius = 130,
                        MissileSpeed = 1400,
                        DangerValue = 3,
                        MissileSpellName = "DravenDoubleShotMissile"
                    }
                },
                new LinearMissileSkillshot
                {
                    SpellData = new SpellData
                    {
                        ChampionName = "Ekko",
                        SpellName = "EkkoQ",
                        Slot = SpellSlot.Q,
                        Delay = 250,
                        Range = 950,
                        Radius = 60,
                        MissileSpeed = 1650,
                        DangerValue = 3,
                        MissileSpellName = "ekkoqmis"
                    }
                },
                new CircularMissileSkillshot
                {
                    SpellData = new SpellData
                    {
                        ChampionName = "Ekko",
                        SpellName = "EkkoW",
                        Slot = SpellSlot.W,
                        Delay = 3750,
                        Range = 1600,
                        Radius = 375,
                        MissileSpeed = 0,
                        DangerValue = 3,
                        MissileSpellName = "EkkoW"
                    }
                },
                new CircularMissileSkillshot
                {
                    SpellData = new SpellData
                    {
                        ChampionName = "Ekko",
                        SpellName = "EkkoR",
                        Slot = SpellSlot.R,
                        Delay = 250,
                        Range = 1600,
                        Radius = 375,
                        MissileSpeed = 0,
                        DangerValue = 3,
                        MissileSpellName = "EkkoR"
                    }
                },
                new LinearMissileSkillshot
                {
                    SpellData = new SpellData
                    {
                        ChampionName = "Elise",
                        SpellName = "EliseHumanE",
                        Slot = SpellSlot.E,
                        Delay = 250,
                        Range = 1100,
                        Radius = 70,
                        MissileSpeed = 1600,
                        DangerValue = 3,
                        MissileSpellName = "EliseHumanE"
                    }
                },
                new CircularMissileSkillshot
                {
                    SpellData = new SpellData
                    {
                        ChampionName = "Evelynn",
                        SpellName = "EvelynnR",
                        Slot = SpellSlot.R,
                        Delay = 250,
                        Range = 650,
                        Radius = 350,
                        MissileSpeed = 0,
                        DangerValue = 3,
                        MissileSpellName = "EvelynnR"
                    }
                },
                new LinearMissileSkillshot //Unknown:
                {
                    SpellData = new SpellData
                    {
                        ChampionName = "Ezreal",
                        SpellName = "EzrealMysticShot",
                        Slot = SpellSlot.Q,
                        Delay = 250,
                        Range = 1200,
                        Radius = 60,
                        MissileSpeed = 2000,
                        DangerValue = 3,
                        MissileSpellName = "EzrealMysticShotMissile"
                    }
                },
                new LinearMissileSkillshot
                {
                    SpellData = new SpellData
                    {
                        ChampionName = "Ezreal",
                        SpellName = "EzrealTrueshotBarrage",
                        Slot = SpellSlot.R,
                        Delay = 1000,
                        Range = 20000,
                        Radius = 160,
                        MissileSpeed = 2000,
                        DangerValue = 3,
                        MissileSpellName = "EzrealTrueshotBarrage"
                    }
                },
                new LinearMissileSkillshot
                {
                    SpellData = new SpellData
                    {
                        ChampionName = "Ezreal",
                        SpellName = "EzrealEssenceFlux",
                        Slot = SpellSlot.W,
                        Delay = 250,
                        Range = 1050,
                        Radius = 80,
                        MissileSpeed = 1600,
                        DangerValue = 3,
                        MissileSpellName = "EzrealEssenceFluxMissile"
                    }
                },
                new LinearMissileSkillshot
                {
                    SpellData = new SpellData
                    {
                        ChampionName = "Fizz",
                        SpellName = "FizzPiercingStrike",
                        Slot = SpellSlot.Q,
                        Delay = 0,
                        Range = 550,
                        Radius = 150,
                        MissileSpeed = 1400,
                        DangerValue = 3,
                        MissileSpellName = "FizzPiercingStrike"
                    }
                },
                new LinearMissileSkillshot
                {
                    SpellData = new SpellData
                    {
                        ChampionName = "Fizz",
                        SpellName = "FizzMarinerDoom",
                        Slot = SpellSlot.R,
                        Delay = 250,
                        Range = 1275,
                        Radius = 120,
                        MissileSpeed = 1350,
                        DangerValue = 3,
                        MissileSpellName = "FizzMarinerDoomMissile"
                    }
                },
                new LinearMissileSkillshot
                {
                    SpellData = new SpellData
                    {
                        ChampionName = "Galio",
                        SpellName = "GalioRighteousGust",
                        Slot = SpellSlot.E,
                        Delay = 0,
                        Range = 1280,
                        Radius = 160,
                        MissileSpeed = 1300,
                        DangerValue = 3,
                        MissileSpellName = "GalioRighteousGust"
                    }
                },
                new CircularMissileSkillshot
                {
                    SpellData = new SpellData
                    {
                        ChampionName = "Galio",
                        SpellName = "GalioResoluteSmite",
                        Slot = SpellSlot.Q,
                        Delay = 250,
                        Range = 1040,
                        Radius = 235,
                        MissileSpeed = 1200,
                        DangerValue = 3,
                        MissileSpellName = "GalioResoluteSmite"
                    }
                },
                new CircularMissileSkillshot
                {
                    SpellData = new SpellData
                    {
                        ChampionName = "Galio",
                        SpellName = "GalioIdolOfDurand",
                        Slot = SpellSlot.R,
                        Delay = 0,
                        Range = 600,
                        Radius = 600,
                        MissileSpeed = 0,
                        DangerValue = 3,
                        MissileSpellName = "GalioIdolOfDurand"
                    }
                },
                new LinearMissileSkillshot
                {
                    SpellData = new SpellData
                    {
                        ChampionName = "Gnar",
                        SpellName = "gnarbigq",
                        Slot = SpellSlot.Q,
                        Delay = 500,
                        Range = 1150,
                        Radius = 90,
                        MissileSpeed = 2000,
                        DangerValue = 3,
                        MissileSpellName = "gnarbigq"
                    }
                },
                new CircularMissileSkillshot
                {
                    SpellData = new SpellData
                    {
                        ChampionName = "Gnar",
                        SpellName = "GnarR",
                        Slot = SpellSlot.R,
                        Delay = 250,
                        Range = 500,
                        Radius = 500,
                        MissileSpeed = 0,
                        DangerValue = 3,
                        MissileSpellName = "GnarR"
                    }
                },
                new LinearMissileSkillshot
                {
                    SpellData = new SpellData
                    {
                        ChampionName = "Gnar",
                        SpellName = "gnarbigw",
                        Slot = SpellSlot.W,
                        Delay = 600,
                        Range = 600,
                        Radius = 100,
                        MissileSpeed = 0,
                        DangerValue = 3,
                        MissileSpellName = "gnarbigw"
                    }
                },
                new LinearMissileSkillshot
                {
                    SpellData = new SpellData
                    {
                        ChampionName = "Gnar",
                        SpellName = "GnarQ",
                        Slot = SpellSlot.Q,
                        Delay = 250,
                        Range = 1185,
                        Radius = 60,
                        MissileSpeed = 2400,
                        DangerValue = 3,
                        MissileSpellName = "GnarQ"
                    }
                },
                new CircularMissileSkillshot
                {
                    SpellData = new SpellData
                    {
                        ChampionName = "Gnar",
                        SpellName = "GnarE",
                        Slot = SpellSlot.E,
                        Delay = 0,
                        Range = 475,
                        Radius = 150,
                        MissileSpeed = 900,
                        DangerValue = 3,
                        MissileSpellName = "GnarE"
                    }
                },
                new CircularMissileSkillshot
                {
                    SpellData = new SpellData
                    {
                        ChampionName = "Gnar",
                        SpellName = "gnarbige",
                        Slot = SpellSlot.E,
                        Delay = 0,
                        Range = 475,
                        Radius = 100,
                        MissileSpeed = 800,
                        DangerValue = 3,
                        MissileSpellName = "gnarbige"
                    }
                },
                new CircularMissileSkillshot
                {
                    SpellData = new SpellData
                    {
                        ChampionName = "Gragas",
                        SpellName = "GragasQ",
                        Slot = SpellSlot.Q,
                        Delay = 500,
                        Range = 975,
                        Radius = 250,
                        MissileSpeed = 1000,
                        DangerValue = 3,
                        MissileSpellName = "GragasQ"
                    }
                },
                new LinearMissileSkillshot
                {
                    SpellData = new SpellData
                    {
                        ChampionName = "Gragas",
                        SpellName = "GragasE",
                        Slot = SpellSlot.E,
                        Delay = 0,
                        Range = 950,
                        Radius = 200,
                        MissileSpeed = 1200,
                        DangerValue = 3,
                        MissileSpellName = "GragasE"
                    }
                },
                new CircularMissileSkillshot
                {
                    SpellData = new SpellData
                    {
                        ChampionName = "Gragas",
                        SpellName = "GragasR",
                        Slot = SpellSlot.R,
                        Delay = 250,
                        Range = 1050,
                        Radius = 350,
                        MissileSpeed = 1750,
                        DangerValue = 3,
                        MissileSpellName = "GragasR"
                    }
                },
                new LinearMissileSkillshot
                {
                    SpellData = new SpellData
                    {
                        ChampionName = "Graves",
                        SpellName = "GravesClusterShot",
                        Slot = SpellSlot.Q,
                        Delay = 250,
                        Range = 1025,
                        Radius = 60,
                        MissileSpeed = 2000,
                        DangerValue = 3,
                        MissileSpellName = "GravesClusterShotAttack",
                        ExtraMissiles = 2
                    }
                },
                new LinearMissileSkillshot
                {
                    SpellData = new SpellData
                    {
                        ChampionName = "Graves",
                        SpellName = "GravesChargeShot",
                        Slot = SpellSlot.R,
                        Delay = 250,
                        Range = 1000,
                        Radius = 100,
                        MissileSpeed = 2100,
                        DangerValue = 3,
                        MissileSpellName = "GravesChargeShotShot"
                    }
                },
                new CircularMissileSkillshot
                {
                    SpellData = new SpellData
                    {
                        ChampionName = "Hecarim",
                        SpellName = "HecarimUlt",
                        Slot = SpellSlot.R,
                        Delay = 10,
                        Range = 1500,
                        Radius = 300,
                        MissileSpeed = 1100,
                        DangerValue = 3,
                        MissileSpellName = "HecarimUlt"
                    }
                },
                new CircularMissileSkillshot
                {
                    SpellData = new SpellData
                    {
                        ChampionName = "Heimerdinger",
                        SpellName = "HeimerdingerE",
                        Slot = SpellSlot.E,
                        Delay = 325,
                        Range = 925,
                        Radius = 135,
                        MissileSpeed = 1750,
                        DangerValue = 3,
                        MissileSpellName = "HeimerdingerESpell"
                    }
                },
                new LinearMissileSkillshot
                {
                    SpellData = new SpellData
                    {
                        ChampionName = "Irelia",
                        SpellName = "IreliaTranscendentBlades",
                        Slot = SpellSlot.R,
                        Delay = 0,
                        Range = 1200,
                        Radius = 120,
                        MissileSpeed = 1600,
                        DangerValue = 3,
                        MissileSpellName = "ireliatranscendentbladesspell"
                    }
                },
                new LinearMissileSkillshot
                {
                    SpellData = new SpellData
                    {
                        ChampionName = "Janna",
                        SpellName = "HowlingGale",
                        Slot = SpellSlot.Q,
                        Delay = 0,
                        Range = 1700,
                        Radius = 120,
                        MissileSpeed = 900,
                        DangerValue = 3,
                        MissileSpellName = "HowlingGaleSpell"
                    }
                },
                new LinearMissileSkillshot
                {
                    SpellData = new SpellData
                    {
                        ChampionName = "JarvanIV",
                        SpellName = "JarvanIVDragonStrike",
                        Slot = SpellSlot.Q,
                        Delay = 250,
                        Range = 845,
                        Radius = 80,
                        MissileSpeed = 2000,
                        DangerValue = 3,
                        MissileSpellName = "JarvanIVDragonStrike"
                    }
                },
                new LinearMissileSkillshot
                {
                    SpellData = new SpellData
                    {
                        ChampionName = "JarvanIV",
                        SpellName = "JarvanIVDragonStrike2",
                        Slot = SpellSlot.Q,
                        Delay = 250,
                        Range = 845,
                        Radius = 120,
                        MissileSpeed = 1800,
                        DangerValue = 3,
                        MissileSpellName = "JarvanIVDragonStrike2"
                    }
                },
                new CircularMissileSkillshot
                {
                    SpellData = new SpellData
                    {
                        ChampionName = "JarvanIV",
                        SpellName = "JarvanIVCataclysm",
                        Slot = SpellSlot.R,
                        Delay = 0,
                        Range = 825,
                        Radius = 350,
                        MissileSpeed = 1900,
                        DangerValue = 3,
                        MissileSpellName = "JarvanIVCataclysm"
                    }
                },
                new LinearMissileSkillshot
                {
                    SpellData = new SpellData
                    {
                        ChampionName = "Jayce",
                        SpellName = "JayceShockBlastWall",
                        Slot = SpellSlot.Q,
                        Delay = 250,
                        Range = 1170,
                        Radius = 70,
                        MissileSpeed = 2350,
                        DangerValue = 3,
                        MissileSpellName = "JayceShockBlastWallMis"
                    }
                },
                new LinearMissileSkillshot
                {
                    SpellData = new SpellData
                    {
                        ChampionName = "Jayce",
                        SpellName = "jayceshockblast",
                        Slot = SpellSlot.Q,
                        Delay = 250,
                        Range = 1050,
                        Radius = 70,
                        MissileSpeed = 1450,
                        DangerValue = 3,
                        MissileSpellName = "JayceShockBlastMis"
                    }
                },
                new LinearMissileSkillshot
                {
                    SpellData = new SpellData
                    {
                        ChampionName = "Jinx",
                        SpellName = "JinxR",
                        Slot = SpellSlot.R,
                        Delay = 600,
                        Range = 25000,
                        Radius = 120,
                        MissileSpeed = 1700,
                        DangerValue = 3,
                        MissileSpellName = "JinxR"
                    }
                },
                new LinearMissileSkillshot
                {
                    SpellData = new SpellData
                    {
                        ChampionName = "Jinx",
                        SpellName = "JinxWMissile",
                        Slot = SpellSlot.W,
                        Delay = 600,
                        Range = 1500,
                        Radius = 60,
                        MissileSpeed = 3300,
                        DangerValue = 3,
                        MissileSpellName = "JinxWMissile"
                    }
                },
                new LinearMissileSkillshot
                {
                    SpellData = new SpellData
                    {
                        ChampionName = "Kalista",
                        SpellName = "KalistaMysticShot",
                        Slot = SpellSlot.Q,
                        Delay = 350,
                        Range = 1200,
                        Radius = 70,
                        MissileSpeed = 2000,
                        DangerValue = 3,
                        MissileSpellName = "kalistamysticshotmistrue"
                    }
                },
                new LinearMissileSkillshot
                {
                    SpellData = new SpellData
                    {
                        ChampionName = "Karma",
                        SpellName = "KarmaQ",
                        Slot = SpellSlot.Q,
                        Delay = 250,
                        Range = 1050,
                        Radius = 90,
                        MissileSpeed = 1700,
                        DangerValue = 3,
                        MissileSpellName = "KarmaQMissile"
                    }
                },
                new LinearMissileSkillshot
                {
                    SpellData = new SpellData
                    {
                        ChampionName = "Karma",
                        SpellName = "KarmaQMissileMantra",
                        Slot = SpellSlot.Q,
                        Delay = 250,
                        Range = 1050,
                        Radius = 90,
                        MissileSpeed = 1700,
                        DangerValue = 3,
                        MissileSpellName = "KarmaQMissileMantra"
                    }
                },
                new CircularMissileSkillshot
                {
                    SpellData = new SpellData
                    {
                        ChampionName = "Karthus",
                        SpellName = "KarthusLayWasteA1",
                        Slot = SpellSlot.Q,
                        Delay = 900,
                        Range = 875,
                        Radius = 190,
                        MissileSpeed = 0,
                        DangerValue = 3,
                        MissileSpellName = "KarthusLayWasteA1"
                    }
                },
                new CircularMissileSkillshot
                {
                    SpellData = new SpellData
                    {
                        ChampionName = "Kassadin",
                        SpellName = "RiftWalk",
                        Slot = SpellSlot.R,
                        Delay = 250,
                        Range = 700,
                        Radius = 270,
                        MissileSpeed = 0,
                        DangerValue = 3,
                        MissileSpellName = "RiftWalk"
                    }
                },
                new CircularMissileSkillshot
                {
                    SpellData = new SpellData
                    {
                        ChampionName = "Kassadin",
                        SpellName = "ForcePulse",
                        Slot = SpellSlot.E,
                        Delay = 250,
                        Range = 700,
                        Radius = 20,
                        MissileSpeed = 0,
                        DangerValue = 3,
                        MissileSpellName = "ForcePulse"
                    }
                },
                new LinearMissileSkillshot
                {
                    SpellData = new SpellData
                    {
                        ChampionName = "Kennen",
                        SpellName = "KennenShurikenHurlMissile1",
                        Slot = SpellSlot.Q,
                        Delay = 180,
                        Range = 1175,
                        Radius = 50,
                        MissileSpeed = 1700,
                        DangerValue = 3,
                        MissileSpellName = "KennenShurikenHurlMissile1"
                    }
                },
                new LinearMissileSkillshot
                {
                    SpellData = new SpellData
                    {
                        ChampionName = "Khazix",
                        SpellName = "KhazixW",
                        Slot = SpellSlot.W,
                        Delay = 250,
                        Range = 1100,
                        Radius = 70,
                        MissileSpeed = 1700,
                        DangerValue = 3,
                        MissileSpellName = "KhazixWMissile"
                    }
                },
                new LinearMissileSkillshot
                {
                    SpellData = new SpellData
                    {
                        ChampionName = "Khazix",
                        SpellName = "khazixwlong",
                        Slot = SpellSlot.W,
                        Delay = 250,
                        Range = 1025,
                        Radius = 70,
                        MissileSpeed = 1700,
                        DangerValue = 3,
                        MissileSpellName = "khazixwlong"
                    }
                },
                new LinearMissileSkillshot
                {
                    SpellData = new SpellData
                    {
                        ChampionName = "KogMaw",
                        SpellName = "KogMawQ",
                        Slot = SpellSlot.Q,
                        Delay = 250,
                        Range = 1125,
                        Radius = 70,
                        MissileSpeed = 1650,
                        DangerValue = 3,
                        MissileSpellName = "KogMawQ"
                    }
                },
                new LinearMissileSkillshot
                {
                    SpellData = new SpellData
                    {
                        ChampionName = "KogMaw",
                        SpellName = "KogMawVoidOoze",
                        Slot = SpellSlot.E,
                        Delay = 250,
                        Range = 1360,
                        Radius = 120,
                        MissileSpeed = 1400,
                        DangerValue = 3,
                        MissileSpellName = "KogMawVoidOoze"
                    }
                },
                new CircularMissileSkillshot
                {
                    SpellData = new SpellData
                    {
                        ChampionName = "KogMaw",
                        SpellName = "KogMawLivingArtillery",
                        Slot = SpellSlot.R,
                        Delay = 1100,
                        Range = 2200,
                        Radius = 235,
                        MissileSpeed = 0,
                        DangerValue = 3,
                        MissileSpellName = "KogMawLivingArtillery"
                    }
                },
                new LinearMissileSkillshot
                {
                    SpellData = new SpellData
                    {
                        ChampionName = "Leblanc",
                        SpellName = "LeblancSoulShackleM",
                        Slot = SpellSlot.R,
                        Delay = 250,
                        Range = 960,
                        Radius = 70,
                        MissileSpeed = 1600,
                        DangerValue = 3,
                        MissileSpellName = "LeblancSoulShackleM"
                    }
                },
                new LinearMissileSkillshot
                {
                    SpellData = new SpellData
                    {
                        ChampionName = "Leblanc",
                        SpellName = "LeblancSoulShackle",
                        Slot = SpellSlot.E,
                        Delay = 250,
                        Range = 960,
                        Radius = 70,
                        MissileSpeed = 1600,
                        DangerValue = 3,
                        MissileSpellName = "LeblancSoulShackle"
                    }
                },
                new CircularMissileSkillshot
                {
                    SpellData = new SpellData
                    {
                        ChampionName = "Leblanc",
                        SpellName = "LeblancSlideM",
                        Slot = SpellSlot.R,
                        Delay = 250,
                        Range = 725,
                        Radius = 250,
                        MissileSpeed = 1600,
                        DangerValue = 3,
                        MissileSpellName = "LeblancSlideM"
                    }
                },
                new CircularMissileSkillshot
                {
                    SpellData = new SpellData
                    {
                        ChampionName = "Leblanc",
                        SpellName = "LeblancSlide",
                        Slot = SpellSlot.W,
                        Delay = 250,
                        Range = 725,
                        Radius = 250,
                        MissileSpeed = 1600,
                        DangerValue = 3,
                        MissileSpellName = "LeblancSlide"
                    }
                },
                new LinearMissileSkillshot
                {
                    SpellData = new SpellData
                    {
                        ChampionName = "LeeSin",
                        SpellName = "BlindMonkQOne",
                        Slot = SpellSlot.Q,
                        Delay = 250,
                        Range = 1100,
                        Radius = 60,
                        MissileSpeed = 1800,
                        DangerValue = 3,
                        MissileSpellName = "BlindMonkQOne"
                    }
                },
                new CircularMissileSkillshot
                {
                    SpellData = new SpellData
                    {
                        ChampionName = "Leona",
                        SpellName = "LeonaSolarFlare",
                        Slot = SpellSlot.R,
                        Delay = 1000,
                        Range = 1200,
                        Radius = 300,
                        MissileSpeed = 0,
                        DangerValue = 3,
                        MissileSpellName = "LeonaSolarFlare"
                    }
                },
                new LinearMissileSkillshot
                {
                    SpellData = new SpellData
                    {
                        ChampionName = "Leona",
                        SpellName = "LeonaZenithBlade",
                        Slot = SpellSlot.E,
                        Delay = 200,
                        Range = 975,
                        Radius = 70,
                        MissileSpeed = 2000,
                        DangerValue = 3,
                        MissileSpellName = "FlashFrostSpell"
                    }
                },
                new CircularMissileSkillshot
                {
                    SpellData = new SpellData
                    {
                        ChampionName = "Lissandra",
                        SpellName = "LissandraW",
                        Slot = SpellSlot.W,
                        Delay = 250,
                        Range = 725,
                        Radius = 450,
                        MissileSpeed = 0,
                        DangerValue = 3,
                        MissileSpellName = "LissandraW"
                    }
                },
                new LinearMissileSkillshot
                {
                    SpellData = new SpellData
                    {
                        ChampionName = "Lissandra",
                        SpellName = "LissandraQ",
                        Slot = SpellSlot.Q,
                        Delay = 250,
                        Range = 825,
                        Radius = 75,
                        MissileSpeed = 2250,
                        DangerValue = 3,
                        MissileSpellName = "LissandraQ"
                    }
                },
                new LinearMissileSkillshot
                {
                    SpellData = new SpellData
                    {
                        ChampionName = "Lucian",
                        SpellName = "LucianW",
                        Slot = SpellSlot.W,
                        Delay = 300,
                        Range = 1000,
                        Radius = 80,
                        MissileSpeed = 1600,
                        DangerValue = 3,
                        MissileSpellName = "LucianW"
                    }
                },
                new LinearMissileSkillshot
                {
                    SpellData = new SpellData
                    {
                        ChampionName = "Lucian",
                        SpellName = "LucianQ",
                        Slot = SpellSlot.Q,
                        Delay = 350,
                        Range = 1140,
                        Radius = 65,
                        MissileSpeed = 0,
                        DangerValue = 3,
                        MissileSpellName = "LucianQ",
                        AddHitbox = false
                    }
                },
                new LinearMissileSkillshot
                {
                    SpellData = new SpellData
                    {
                        ChampionName = "Lulu",
                        SpellName = "LuluQ",
                        Slot = SpellSlot.Q,
                        Delay = 250,
                        Range = 925,
                        Radius = 80,
                        MissileSpeed = 1450,
                        DangerValue = 3,
                        MissileSpellName = "LuluQMissile"
                    }
                },
                new CircularMissileSkillshot
                {
                    SpellData = new SpellData
                    {
                        ChampionName = "Lux",
                        SpellName = "LuxLightStrikeKugel",
                        Slot = SpellSlot.E,
                        Delay = 250,
                        Range = 1100,
                        Radius = 340,
                        MissileSpeed = 1400,
                        DangerValue = 3,
                        MissileSpellName = "LuxLightStrikeKugel"
                    }
                },
                new LinearMissileSkillshot
                {
                    SpellData = new SpellData
                    {
                        ChampionName = "Lux",
                        SpellName = "LuxMaliceCannon",
                        Slot = SpellSlot.R,
                        Delay = 1000,
                        Range = 3500,
                        Radius = 110,
                        MissileSpeed = 0,
                        DangerValue = 3,
                        MissileSpellName = "LuxMaliceCannon"
                    }
                },
                new LinearMissileSkillshot
                {
                    SpellData = new SpellData
                    {
                        ChampionName = "Lux",
                        SpellName = "LuxLightBinding",
                        Slot = SpellSlot.Q,
                        Delay = 250,
                        Range = 1300,
                        Radius = 70,
                        MissileSpeed = 1200,
                        DangerValue = 3,
                        MissileSpellName = "LuxLightBindingMis"
                    }
                },
                new CircularMissileSkillshot
                {
                    SpellData = new SpellData
                    {
                        ChampionName = "Malphite",
                        SpellName = "UFSlash",
                        Slot = SpellSlot.R,
                        Delay = 0,
                        Range = 1000,
                        Radius = 300,
                        MissileSpeed = 2000,
                        DangerValue = 3,
                        MissileSpellName = "UFSlash"
                    }
                },
                new LinearMissileSkillshot
                {
                    SpellData = new SpellData
                    {
                        ChampionName = "Malzahar",
                        SpellName = "AlZaharCalloftheVoid",
                        Slot = SpellSlot.Q,
                        Delay = 1000,
                        Range = 900,
                        Radius = 85,
                        MissileSpeed = 1600,
                        DangerValue = 3,
                        MissileSpellName = "AlZaharCalloftheVoidMissile"
                    }
                },
                new CircularMissileSkillshot
                {
                    SpellData = new SpellData
                    {
                        ChampionName = "MonkeyKing",
                        SpellName = "MonkeyKingSpinToWin",
                        Slot = SpellSlot.R,
                        Delay = 250,
                        Range = 300,
                        Radius = 225,
                        MissileSpeed = 0,
                        DangerValue = 3,
                        MissileSpellName = "MonkeyKingSpinToWin"
                    }
                },
                new LinearMissileSkillshot
                {
                    SpellData = new SpellData
                    {
                        ChampionName = "Morgana",
                        SpellName = "DarkBindingMissile",
                        Slot = SpellSlot.Q,
                        Delay = 250,
                        Range = 1300,
                        Radius = 80,
                        MissileSpeed = 1200,
                        DangerValue = 3,
                        MissileSpellName = "DarkBindingMissile"
                    }
                },
                new CircularMissileSkillshot
                {
                    SpellData = new SpellData
                    {
                        ChampionName = "Nami",
                        SpellName = "NamiQ",
                        Slot = SpellSlot.Q,
                        Delay = 1000,
                        Range = 875,
                        Radius = 200,
                        MissileSpeed = 0,
                        DangerValue = 3,
                        MissileSpellName = "NamiQ"
                    }
                },
                new LinearMissileSkillshot
                {
                    SpellData = new SpellData
                    {
                        ChampionName = "Nami",
                        SpellName = "NamiR",
                        Slot = SpellSlot.R,
                        Delay = 500,
                        Range = 2750,
                        Radius = 250,
                        MissileSpeed = 850,
                        DangerValue = 3,
                        MissileSpellName = "NamiRMissile"
                    }
                },
                new LinearMissileSkillshot
                {
                    SpellData = new SpellData
                    {
                        ChampionName = "Nautilus",
                        SpellName = "NautilusAnchorDrag",
                        Slot = SpellSlot.Q,
                        Delay = 250,
                        Range = 1080,
                        Radius = 90,
                        MissileSpeed = 2000,
                        DangerValue = 3,
                        MissileSpellName = "NautilusAnchorDragMissile"
                    }
                },
                new LinearMissileSkillshot
                {
                    SpellData = new SpellData
                    {
                        ChampionName = "Nidalee",
                        SpellName = "JavelinToss",
                        Slot = SpellSlot.Q,
                        Delay = 125,
                        Range = 1500,
                        Radius = 40,
                        MissileSpeed = 1300,
                        DangerValue = 3,
                        MissileSpellName = "JavelinToss"
                    }
                },
                new LinearMissileSkillshot
                {
                    SpellData = new SpellData
                    {
                        ChampionName = "Nocturne",
                        SpellName = "NocturneDuskbringer",
                        Slot = SpellSlot.Q,
                        Delay = 250,
                        Range = 1125,
                        Radius = 60,
                        MissileSpeed = 1400,
                        DangerValue = 3,
                        MissileSpellName = "NocturneDuskbringer"
                    }
                },
                new LinearMissileSkillshot
                {
                    SpellData = new SpellData
                    {
                        ChampionName = "Olaf",
                        SpellName = "OlafAxeThrowCast",
                        Slot = SpellSlot.Q,
                        Delay = 250,
                        Range = 1000,
                        Radius = 90,
                        MissileSpeed = 1600,
                        DangerValue = 3,
                        MissileSpellName = "OlafAxeThrowCast"
                    }
                },
                new LinearMissileSkillshot
                {
                    SpellData = new SpellData
                    {
                        ChampionName = "Orianna",
                        SpellName = "OrianaIzunaCommand",
                        Slot = SpellSlot.Q,
                        Delay = 0,
                        Range = 2000,
                        Radius = 80,
                        MissileSpeed = 1200,
                        DangerValue = 3,
                        MissileSpellName = "OrianaIzunaCommand"
                    }
                },
                new CircularMissileSkillshot
                {
                    SpellData = new SpellData
                    {
                        ChampionName = "Orianna",
                        SpellName = "OrianaDetonateCommand",
                        Slot = SpellSlot.R,
                        Delay = 500,
                        Range = 410,
                        Radius = 410,
                        MissileSpeed = 0,
                        DangerValue = 3,
                        MissileSpellName = "OrianaDetonateCommand"
                    }
                },
                new CircularMissileSkillshot
                {
                    SpellData = new SpellData
                    {
                        ChampionName = "Orianna",
                        SpellName = "OrianaDissonanceCommand",
                        Slot = SpellSlot.W,
                        Delay = 0,
                        Range = 1825,
                        Radius = 250,
                        MissileSpeed = 0,
                        DangerValue = 3,
                        MissileSpellName = "OrianaDissonanceCommand"
                    }
                },
                new CircularMissileSkillshot
                {
                    SpellData = new SpellData
                    {
                        ChampionName = "Pantheon",
                        SpellName = "PantheonE",
                        Slot = SpellSlot.E,
                        Delay = 1000,
                        Range = 650,
                        Radius = 100,
                        MissileSpeed = 0,
                        DangerValue = 3,
                        MissileSpellName = "PantheonE"
                    }
                },
                new LinearMissileSkillshot
                {
                    SpellData = new SpellData
                    {
                        ChampionName = "Quinn",
                        SpellName = "QuinnQ",
                        Slot = SpellSlot.Q,
                        Delay = 250,
                        Range = 1050,
                        Radius = 80,
                        MissileSpeed = 1550,
                        DangerValue = 3,
                        MissileSpellName = "QuinnQMissile"
                    }
                },
                new LinearMissileSkillshot
                {
                    SpellData = new SpellData
                    {
                        ChampionName = "RekSai",
                        SpellName = "reksaiqburrowed",
                        Slot = SpellSlot.E,
                        Delay = 125,
                        Range = 1500,
                        Radius = 65,
                        MissileSpeed = 1950,
                        DangerValue = 3,
                        MissileSpellName = "RekSaiQBurrowedMis"
                    }
                },
                new LinearMissileSkillshot
                {
                    SpellData = new SpellData
                    {
                        ChampionName = "Rengar",
                        SpellName = "RengarE",
                        Slot = SpellSlot.E,
                        Delay = 250,
                        Range = 1000,
                        Radius = 70,
                        MissileSpeed = 1500,
                        DangerValue = 3,
                        MissileSpellName = "RengarEFinal"
                    }
                },
                new LinearMissileSkillshot
                {
                    SpellData = new SpellData
                    {
                        ChampionName = "Riven",
                        SpellName = "rivenizunablade",
                        Slot = SpellSlot.R,
                        Delay = 250,
                        Range = 1100,
                        Radius = 100,
                        MissileSpeed = 1600,
                        DangerValue = 3,
                        MissileSpellName = "rivenizunablade"
                    }
                },
                new CircularMissileSkillshot
                {
                    SpellData = new SpellData
                    {
                        ChampionName = "Riven",
                        SpellName = "RivenMartyr",
                        Slot = SpellSlot.W,
                        Delay = 267,
                        Range = 650,
                        Radius = 280,
                        MissileSpeed = 1500,
                        DangerValue = 3,
                        MissileSpellName = "RivenMartyr"
                    }
                },
                new LinearMissileSkillshot
                {
                    SpellData = new SpellData
                    {
                        ChampionName = "Rumble",
                        SpellName = "RumbleGrenade",
                        Slot = SpellSlot.E,
                        Delay = 250,
                        Range = 950,
                        Radius = 90,
                        MissileSpeed = 2000,
                        DangerValue = 3,
                        MissileSpellName = "RumbleGrenadeMissile"
                    }
                },
                new LinearMissileSkillshot
                {
                    SpellData = new SpellData
                    {
                        ChampionName = "Ryze",
                        SpellName = "RyzeQ",
                        Slot = SpellSlot.Q,
                        Delay = 250,
                        Range = 900,
                        Radius = 60,
                        MissileSpeed = 1700,
                        DangerValue = 3,
                        MissileSpellName = "RyzeQ"
                    }
                },
                new LinearMissileSkillshot
                {
                    SpellData = new SpellData
                    {
                        ChampionName = "Sejuani",
                        SpellName = "SejuaniGlacialPrisonCast",
                        Slot = SpellSlot.R,
                        Delay = 250,
                        Range = 1200,
                        Radius = 110,
                        MissileSpeed = 1600,
                        DangerValue = 3,
                        MissileSpellName = "SejuaniGlacialPrison"
                    }
                },
                new LinearMissileSkillshot
                {
                    SpellData = new SpellData
                    {
                        ChampionName = "Shen",
                        SpellName = "ShenShadowDash",
                        Slot = SpellSlot.E,
                        Delay = 0,
                        Range = 700,
                        Radius = 75,
                        MissileSpeed = 1250,
                        DangerValue = 3,
                        MissileSpellName = "ShenShadowDash"
                    }
                },
                new LinearMissileSkillshot
                {
                    SpellData = new SpellData
                    {
                        ChampionName = "Shyvana",
                        SpellName = "ShyvanaFireball",
                        Slot = SpellSlot.E,
                        Delay = 0,
                        Range = 950,
                        Radius = 60,
                        MissileSpeed = 1700,
                        DangerValue = 3,
                        MissileSpellName = "ShyvanaFireball"
                    }
                },
                new LinearMissileSkillshot
                {
                    SpellData = new SpellData
                    {
                        ChampionName = "Shyvana",
                        SpellName = "ShyvanaTransformCast",
                        Slot = SpellSlot.R,
                        Delay = 10,
                        Range = 1000,
                        Radius = 160,
                        MissileSpeed = 1100,
                        DangerValue = 3,
                        MissileSpellName = "ShyvanaTransformCast"
                    }
                },
                new LinearMissileSkillshot
                {
                    SpellData = new SpellData
                    {
                        ChampionName = "Sion",
                        SpellName = "SionE",
                        Slot = SpellSlot.E,
                        Delay = 250,
                        Range = 800,
                        Radius = 80,
                        MissileSpeed = 1800,
                        DangerValue = 3,
                        MissileSpellName = "SionEMissile"
                    }
                },
                new LinearMissileSkillshot
                {
                    SpellData = new SpellData
                    {
                        ChampionName = "Sivir",
                        SpellName = "SivirQ",
                        Slot = SpellSlot.Q,
                        Delay = 250,
                        Range = 1275,
                        Radius = 100,
                        MissileSpeed = 1350,
                        DangerValue = 3,
                        MissileSpellName = "SivirQMissile"
                    }
                },
                new LinearMissileSkillshot
                {
                    SpellData = new SpellData
                    {
                        ChampionName = "Skarner",
                        SpellName = "SkarnerFracture",
                        Slot = SpellSlot.E,
                        Delay = 250,
                        Range = 1000,
                        Radius = 60,
                        MissileSpeed = 1400,
                        DangerValue = 3,
                        MissileSpellName = "SkarnerFractureMissile"
                    }
                },
                new LinearMissileSkillshot
                {
                    SpellData = new SpellData
                    {
                        ChampionName = "Sona",
                        SpellName = "SonaR",
                        Slot = SpellSlot.R,
                        Delay = 250,
                        Range = 1000,
                        Radius = 150,
                        MissileSpeed = 2400,
                        DangerValue = 3,
                        MissileSpellName = "SonaR"
                    }
                },
                new CircularMissileSkillshot
                {
                    SpellData = new SpellData
                    {
                        ChampionName = "Soraka",
                        SpellName = "SorakaQ",
                        Slot = SpellSlot.Q,
                        Delay = 250,
                        Range = 970,
                        Radius = 260,
                        MissileSpeed = 1100,
                        DangerValue = 3,
                        MissileSpellName = "SorakaQ"
                    }
                },
                new CircularMissileSkillshot
                {
                    SpellData = new SpellData
                    {
                        ChampionName = "Soraka",
                        SpellName = "SorakaE",
                        Slot = SpellSlot.E,
                        Delay = 1750,
                        Range = 925,
                        Radius = 275,
                        MissileSpeed = 0,
                        DangerValue = 3,
                        MissileSpellName = "SorakaE"
                    }
                },
                new CircularMissileSkillshot
                {
                    SpellData = new SpellData
                    {
                        ChampionName = "Swain",
                        SpellName = "SwainShadowGrasp",
                        Slot = SpellSlot.W,
                        Delay = 1100,
                        Range = 900,
                        Radius = 250,
                        MissileSpeed = 0,
                        DangerValue = 3,
                        MissileSpellName = "SwainShadowGrasp"
                    }
                },
                new LinearMissileSkillshot
                {
                    SpellData = new SpellData
                    {
                        ChampionName = "Syndra",
                        SpellName = "SyndraE",
                        Slot = SpellSlot.E,
                        Delay = 250,
                        Range = 800,
                        Radius = 140,
                        MissileSpeed = 1500,
                        DangerValue = 3,
                        MissileSpellName = "SyndraE"
                    }
                },
                new CircularMissileSkillshot
                {
                    SpellData = new SpellData
                    {
                        ChampionName = "Syndra",
                        SpellName = "syndrawcast",
                        Slot = SpellSlot.W,
                        Delay = 0,
                        Range = 925,
                        Radius = 220,
                        MissileSpeed = 1450,
                        DangerValue = 3,
                        MissileSpellName = "syndrawcast"
                    }
                },
                new CircularMissileSkillshot
                {
                    SpellData = new SpellData
                    {
                        ChampionName = "Syndra",
                        SpellName = "SyndraQ",
                        Slot = SpellSlot.Q,
                        Delay = 600,
                        Range = 800,
                        Radius = 210,
                        MissileSpeed = 0,
                        DangerValue = 3,
                        MissileSpellName = "SyndraQ"
                    }
                },
                new LinearMissileSkillshot
                {
                    SpellData = new SpellData
                    {
                        ChampionName = "TahmKench",
                        SpellName = "TahmKenchQ",
                        Slot = SpellSlot.Q,
                        Delay = 250,
                        Range = 951,
                        Radius = 90,
                        MissileSpeed = 2000,
                        DangerValue = 3,
                        MissileSpellName = "tahmkenchqmissile"
                    }
                },
                new LinearMissileSkillshot
                {
                    SpellData = new SpellData
                    {
                        ChampionName = "Talon",
                        SpellName = "TalonRake",
                        Slot = SpellSlot.W,
                        Delay = 0,
                        Range = 780,
                        Radius = 75,
                        MissileSpeed = 2300,
                        DangerValue = 3,
                        MissileSpellName = "TalonRake"
                    }
                },
                new LinearMissileSkillshot
                {
                    SpellData = new SpellData
                    {
                        ChampionName = "Thresh",
                        SpellName = "ThreshQ",
                        Slot = SpellSlot.Q,
                        Delay = 500,
                        Range = 1100,
                        Radius = 70,
                        MissileSpeed = 1900,
                        DangerValue = 3,
                        MissileSpellName = "ThreshQMissile"
                    }
                },
                new LinearMissileSkillshot
                {
                    SpellData = new SpellData
                    {
                        ChampionName = "Thresh",
                        SpellName = "ThreshE",
                        Slot = SpellSlot.E,
                        Delay = 0,
                        Range = 1075,
                        Radius = 110,
                        MissileSpeed = 2000,
                        DangerValue = 3,
                        MissileSpellName = "ThreshEMissile1"
                    }
                },
                new LinearMissileSkillshot
                {
                    SpellData = new SpellData
                    {
                        ChampionName = "TwistedFate",
                        SpellName = "WildCards",
                        Slot = SpellSlot.Q,
                        Delay = 250,
                        Range = 1450,
                        Radius = 40,
                        MissileSpeed = 1000,
                        DangerValue = 3,
                        MissileSpellName = "SealFateMissile"
                    }
                },
                new LinearMissileSkillshot
                {
                    SpellData = new SpellData
                    {
                        ChampionName = "Urgot",
                        SpellName = "UrgotHeatseekingLineMissile",
                        Slot = SpellSlot.Q,
                        Delay = 175,
                        Range = 1000,
                        Radius = 60,
                        MissileSpeed = 1600,
                        DangerValue = 3,
                        MissileSpellName = "UrgotHeatseekingLineMissile"
                    }
                },
                new CircularMissileSkillshot
                {
                    SpellData = new SpellData
                    {
                        ChampionName = "Urgot",
                        SpellName = "UrgotPlasmaGrenade",
                        Slot = SpellSlot.E,
                        Delay = 250,
                        Range = 900,
                        Radius = 250,
                        MissileSpeed = 1750,
                        DangerValue = 3,
                        MissileSpellName = "UrgotPlasmaGrenade"
                    }
                },
                new CircularMissileSkillshot
                {
                    SpellData = new SpellData
                    {
                        ChampionName = "Varus",
                        SpellName = "VarusE",
                        Slot = SpellSlot.E,
                        Delay = 250,
                        Range = 925,
                        Radius = 235,
                        MissileSpeed = 1500,
                        DangerValue = 3,
                        MissileSpellName = "VarusE"
                    }
                },
                new LinearMissileSkillshot
                {
                    SpellData = new SpellData
                    {
                        ChampionName = "Varus",
                        SpellName = "varusq",
                        Slot = SpellSlot.Q,
                        Delay = 0,
                        Range = 1600,
                        Radius = 70,
                        MissileSpeed = 1900,
                        DangerValue = 3,
                        MissileSpellName = "VarusQMissile"
                    }
                },
                new LinearMissileSkillshot
                {
                    SpellData = new SpellData
                    {
                        ChampionName = "Varus",
                        SpellName = "VarusR",
                        Slot = SpellSlot.R,
                        Delay = 250,
                        Range = 1200,
                        Radius = 100,
                        MissileSpeed = 1950,
                        DangerValue = 3,
                        MissileSpellName = "VarusR"
                    }
                },
                new LinearMissileSkillshot
                {
                    SpellData = new SpellData
                    {
                        ChampionName = "Veigar",
                        SpellName = "VeigarBalefulStrike",
                        Slot = SpellSlot.Q,
                        Delay = 250,
                        Range = 950,
                        Radius = 70,
                        MissileSpeed = 1750,
                        DangerValue = 3,
                        MissileSpellName = "VeigarBalefulStrikeMis"
                    }
                },
                new CircularMissileSkillshot
                {
                    SpellData = new SpellData
                    {
                        ChampionName = "Veigar",
                        SpellName = "VeigarDarkMatter",
                        Slot = SpellSlot.W,
                        Delay = 1350,
                        Range = 900,
                        Radius = 225,
                        MissileSpeed = 0,
                        DangerValue = 3,
                        MissileSpellName = "VeigarDarkMatter"
                    }
                },
                new CircularMissileSkillshot
                {
                    SpellData = new SpellData
                    {
                        ChampionName = "Veigar",
                        SpellName = "VeigarEventHorizon",
                        Slot = SpellSlot.E,
                        Delay = 500,
                        Range = 700,
                        Radius = 425,
                        MissileSpeed = 0,
                        DangerValue = 3,
                        MissileSpellName = "VeigarEventHorizon"
                    }
                },
                new CircularMissileSkillshot
                {
                    SpellData = new SpellData
                    {
                        ChampionName = "Velkoz",
                        SpellName = "VelkozE",
                        Slot = SpellSlot.E,
                        Delay = 0,
                        Range = 950,
                        Radius = 225,
                        MissileSpeed = 1500,
                        DangerValue = 3,
                        MissileSpellName = "VelkozE"
                    }
                },
                new LinearMissileSkillshot
                {
                    SpellData = new SpellData
                    {
                        ChampionName = "Velkoz",
                        SpellName = "VelkozW",
                        Slot = SpellSlot.W,
                        Delay = 0,
                        Range = 1100,
                        Radius = 90,
                        MissileSpeed = 1200,
                        DangerValue = 3,
                        MissileSpellName = "VelkozW"
                    }
                },
                new LinearMissileSkillshot
                {
                    SpellData = new SpellData
                    {
                        ChampionName = "Velkoz",
                        SpellName = "VelkozQMissileSplit",
                        Slot = SpellSlot.Q,
                        Delay = 0,
                        Range = 900,
                        Radius = 90,
                        MissileSpeed = 2100,
                        DangerValue = 3,
                        MissileSpellName = "VelkozQMissileSplit"
                    }
                },
                new LinearMissileSkillshot
                {
                    SpellData = new SpellData
                    {
                        ChampionName = "Velkoz",
                        SpellName = "VelkozQ",
                        Slot = SpellSlot.Q,
                        Delay = 0,
                        Range = 1200,
                        Radius = 90,
                        MissileSpeed = 1300,
                        DangerValue = 3,
                        MissileSpellName = "VelkozQMissile"
                    }
                },
                new LinearMissileSkillshot
                {
                    SpellData = new SpellData
                    {
                        ChampionName = "Vi",
                        SpellName = "ViQMissile",
                        Slot = SpellSlot.Q,
                        Delay = 0,
                        Range = 725,
                        Radius = 90,
                        MissileSpeed = 1500,
                        DangerValue = 3,
                        MissileSpellName = "ViQMissile"
                    }
                },
                new LinearMissileSkillshot //Unknown:
                {
                    SpellData = new SpellData
                    {
                        ChampionName = "Viktor",
                        SpellName = "ViktorDeathRay",
                        Slot = SpellSlot.E,
                        Delay = 0,
                        Range = 800,
                        Radius = 80,
                        MissileSpeed = 780,
                        DangerValue = 3,
                        MissileSpellName = "ViktorDeathRayMissile"
                    }
                },
                new LinearMissileSkillshot
                {
                    SpellData = new SpellData
                    {
                        ChampionName = "Viktor",
                        SpellName = "ViktorDeathRay3",
                        Slot = SpellSlot.E,
                        Delay = 500,
                        Range = 800,
                        Radius = 80,
                        MissileSpeed = 0,
                        DangerValue = 3,
                        MissileSpellName = "ViktorDeathRay3"
                    }
                },
                new LinearMissileSkillshot
                {
                    SpellData = new SpellData
                    {
                        ChampionName = "Viktor",
                        SpellName = "ViktorDeathRay2",
                        Slot = SpellSlot.E,
                        Delay = 0,
                        Range = 800,
                        Radius = 80,
                        MissileSpeed = 1500,
                        DangerValue = 3,
                        MissileSpellName = "ViktorDeathRayMissile2"
                    }
                },
                new CircularMissileSkillshot
                {
                    SpellData = new SpellData
                    {
                        ChampionName = "Viktor",
                        SpellName = "ViktorGravitonField",
                        Slot = SpellSlot.W,
                        Delay = 1500,
                        Range = 625,
                        Radius = 300,
                        MissileSpeed = 0,
                        DangerValue = 3,
                        MissileSpellName = "ViktorGravitonField"
                    }
                },
                new CircularMissileSkillshot
                {
                    SpellData = new SpellData
                    {
                        ChampionName = "Vladimir",
                        SpellName = "VladimirHemoplague",
                        Slot = SpellSlot.R,
                        Delay = 389,
                        Range = 700,
                        Radius = 375,
                        MissileSpeed = 0,
                        DangerValue = 3,
                        MissileSpellName = "VladimirHemoplague"
                    }
                },
                new CircularMissileSkillshot
                {
                    SpellData = new SpellData
                    {
                        ChampionName = "Xerath",
                        SpellName = "XerathArcaneBarrage2",
                        Slot = SpellSlot.W,
                        Delay = 750,
                        Range = 1100,
                        Radius = 270,
                        MissileSpeed = 0,
                        DangerValue = 3,
                        MissileSpellName = "XerathArcaneBarrage2"
                    }
                },
                new LinearMissileSkillshot
                {
                    SpellData = new SpellData
                    {
                        ChampionName = "Xerath",
                        SpellName = "xeratharcanopulse2",
                        Slot = SpellSlot.Q,
                        Delay = 450,
                        Range = 1525,
                        Radius = 80,
                        MissileSpeed = 0,
                        DangerValue = 3,
                        MissileSpellName = "xeratharcanopulse2"
                    }
                },
                new CircularMissileSkillshot
                {
                    SpellData = new SpellData
                    {
                        ChampionName = "Xerath",
                        SpellName = "xerathrmissilewrapper",
                        Slot = SpellSlot.R,
                        Delay = 600,
                        Range = 5600,
                        Radius = 200,
                        MissileSpeed = 0,
                        DangerValue = 3,
                        MissileSpellName = "xerathrmissilewrapper"
                    }
                },
                new LinearMissileSkillshot
                {
                    SpellData = new SpellData
                    {
                        ChampionName = "Xerath",
                        SpellName = "XerathMageSpear",
                        Slot = SpellSlot.E,
                        Delay = 200,
                        Range = 1125,
                        Radius = 60,
                        MissileSpeed = 1600,
                        DangerValue = 3,
                        MissileSpellName = "XerathMageSpearMissile"
                    }
                },
                new LinearMissileSkillshot
                {
                    SpellData = new SpellData
                    {
                        ChampionName = "Yasuo",
                        SpellName = "yasuoq3w",
                        Slot = SpellSlot.Q,
                        Delay = 250,
                        Range = 1025,
                        Radius = 90,
                        MissileSpeed = 1500,
                        DangerValue = 3,
                        MissileSpellName = "yasuoq3w"
                    }
                },
                new LinearMissileSkillshot
                {
                    SpellData = new SpellData
                    {
                        ChampionName = "Yasuo",
                        SpellName = "YasuoQW",
                        Slot = SpellSlot.Q,
                        Delay = 250,
                        Range = 500,
                        Radius = 35,
                        MissileSpeed = 0,
                        DangerValue = 3,
                        MissileSpellName = "YasuoQW"
                    }
                },
                new LinearMissileSkillshot
                {
                    SpellData = new SpellData
                    {
                        ChampionName = "Zed",
                        SpellName = "ZedShuriken",
                        Slot = SpellSlot.Q,
                        Delay = 250,
                        Range = 925,
                        Radius = 50,
                        MissileSpeed = 1700,
                        DangerValue = 3,
                        MissileSpellName = "ZedShuriken"
                    }
                },
                new CircularMissileSkillshot
                {
                    SpellData = new SpellData
                    {
                        ChampionName = "Zed",
                        SpellName = "ZedPBAOEDummy",
                        Slot = SpellSlot.E,
                        Delay = 0,
                        Range = 290,
                        Radius = 290,
                        MissileSpeed = 0,
                        DangerValue = 3,
                        MissileSpellName = "ZedPBAOEDummy"
                    }
                },
                new CircularMissileSkillshot
                {
                    SpellData = new SpellData
                    {
                        ChampionName = "Ziggs",
                        SpellName = "ZiggsE",
                        Slot = SpellSlot.E,
                        Delay = 250,
                        Range = 2000,
                        Radius = 235,
                        MissileSpeed = 3000,
                        DangerValue = 3,
                        MissileSpellName = "ZiggsE"
                    }
                },
                new CircularMissileSkillshot
                {
                    SpellData = new SpellData
                    {
                        ChampionName = "Ziggs",
                        SpellName = "ZiggsW",
                        Slot = SpellSlot.W,
                        Delay = 250,
                        Range = 2000,
                        Radius = 275,
                        MissileSpeed = 3000,
                        DangerValue = 3,
                        MissileSpellName = "ZiggsW"
                    }
                },
                new CircularMissileSkillshot
                {
                    SpellData = new SpellData
                    {
                        ChampionName = "Ziggs",
                        SpellName = "ZiggsQ",
                        Slot = SpellSlot.Q,
                        Delay = 250,
                        Range = 850,
                        Radius = 150,
                        MissileSpeed = 1700,
                        DangerValue = 3,
                        MissileSpellName = "ZiggsQ"
                    }
                },
                new CircularMissileSkillshot
                {
                    SpellData = new SpellData
                    {
                        ChampionName = "Ziggs",
                        SpellName = "ZiggsR",
                        Slot = SpellSlot.R,
                        Delay = 1500,
                        Range = 5300,
                        Radius = 550,
                        MissileSpeed = 1500,
                        DangerValue = 3,
                        MissileSpellName = "ZiggsR"
                    }
                },
                new CircularMissileSkillshot
                {
                    SpellData = new SpellData
                    {
                        ChampionName = "Zilean",
                        SpellName = "ZileanQ",
                        Slot = SpellSlot.Q,
                        Delay = 300,
                        Range = 900,
                        Radius = 250,
                        MissileSpeed = 2000,
                        DangerValue = 3,
                        MissileSpellName = "ZileanQ"
                    }
                },
                new LinearMissileSkillshot
                {
                    SpellData = new SpellData
                    {
                        ChampionName = "Zyra",
                        SpellName = "ZyraGraspingRoots",
                        Slot = SpellSlot.E,
                        Delay = 250,
                        Range = 1150,
                        Radius = 70,
                        MissileSpeed = 1150,
                        DangerValue = 3,
                        MissileSpellName = "ZyraGraspingRoots"
                    }
                },
                new LinearMissileSkillshot
                {
                    SpellData = new SpellData
                    {
                        ChampionName = "Zyra",
                        SpellName = "zyrapassivedeathmanager",
                        Slot = SpellSlot.Q,
                        Delay = 500,
                        Range = 1474,
                        Radius = 80,
                        MissileSpeed = 2000,
                        DangerValue = 3,
                        MissileSpellName = "ZyraPassiveDeathMissile"
                    }
                },
                new CircularMissileSkillshot
                {
                    SpellData = new SpellData
                    {
                        ChampionName = "Zyra",
                        SpellName = "ZyraQFissure",
                        Slot = SpellSlot.Q,
                        Delay = 800,
                        Range = 825,
                        Radius = 260,
                        MissileSpeed = 0,
                        DangerValue = 3,
                        MissileSpellName = "ZyraQFissure"
                    }
                },
                new CircularMissileSkillshot
                {
                    SpellData = new SpellData
                    {
                        ChampionName = "Zyra",
                        SpellName = "ZyraBrambleZone",
                        Slot = SpellSlot.R,
                        Delay = 500,
                        Range = 700,
                        Radius = 525,
                        MissileSpeed = 0,
                        DangerValue = 3,
                        MissileSpellName = "ZyraBrambleZone"
                    }
                }
            };
        }
    }
}