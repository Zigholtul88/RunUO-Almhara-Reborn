using System;
using Server;
using Server.Items;
using Server.Mobiles;

namespace Server
{
    public class Setup
    {
        //Basic
        public int StartingLevelCap = 100;
        public int EndingLevelCap = 120;

        public int StatCap = 1500;
        public int TotalStatExp = 5000;//When you are at your stat cap you will have gained Input amount of EXP from Stats.

        public int SkillCap = 120;
        public int SkillTotal = 6480;//Skill Cap * # of Skills
        public int TotalSkillExp = 7500;//When you reach your skill total you will have gained input amount of EXP from Skills.

        public int NextLevelAt = 200;//OnLevel the next LevelAt is OldLevelAt + NextLevelAt
        //This way is:
        //Level 1 : LevelAt 200
        //Level 2 : LevelAt 400
        //Level 3 : LevelAt 600
        //Level 4 : LevelAt 800
        public bool AccumulativeExp = false;
        //while true, when you level your 'exp' doesnt drop back to 0 it stays at what it was when you leveled.
        //while false, when you level your 'exp' drops back to 0.
        //EXP is interchangeable. it will be the same amount to level if Accumulative or not...

        public int PartyRange = 15;
        public int ChanceForBonusStat = 33; //input is %Chance

        public bool TimeSave = true;
        public bool TimeReload = true;

        //Exp Setups
        public const KillType active = KillType.OnlyNPC; // -None, OnlyPk, OnlyNPC, AllKills //./

        public bool ExpFromStats = false;
        public bool ExpFromSkills = false;
        public bool ExpFromOnlyFightSkills = false;//ExpFromSkills must be true for this to work.
        public bool ExpFromPetKills = true;
        public bool ExpFromCrafting = true;
        public bool ExpPartyShare = true;
        public bool ExpEvenPartyShare = true;//ExpPartyShare must be true for this to work.
        public bool ExpFilterByLevel = true;
        public bool ReverseRangeEffect = true;//Killing Something More than 15 levels higher will add instead of Subtract EXP
        public int FilterByLevelRange = 15;//100% Exp Gain while your level is within the input
        public int ExpLostPerLevelDiff = 4;//Foreach level out of FilterByLevelRange they will loose input EXP per level diff.

        //View Configs
        public bool AllowExpBar = true;
        public bool RefreshExpBarOnGain = true;
        public bool ShowLevelInName = true;
        public bool ShowLevelBelowName = true;
        public bool ShowStaffLevel = true;
        public bool ShowLevelCap = true;
        public bool ShowLevelPaperdoll = true;
        public bool ShowNPCLevel = true;
        public bool ShowVendorLevels = false;//ShowNPCLevel must be true for this to work. 

        //Misc Configs
        public bool BonusStatOnLevel = true;
        public bool StatRefillOnLevel = true;

        //Level To Ride (LTR) Mounts
        public int LTREveryMount = 0; //Set EVERY mount rideable at this level

        public int LTRBeetle = 0;
        public int LTRDesertOstard = 0;
        public int LTRFireSteed = 0;
        public int LTRForestOstard = 0;
        public int LTRFrenziedOstard = 0;
        public int LTRHellSteed = 0;
        public int LTRHiryu = 0;
        public int LTRHorse = 0;
        public int LTRKirin = 0;
        public int LTRLesserHiryu = 0;
        public int LTRNightMare = 0;
        public int LTRRidableLlama = 0;
        public int LTRRidgeback = 0;
        public int LTRSavageRidgeback = 0;
        public int LTRScaledSwampDragon = 0;
        public int LTRSeaHorse = 0;
        public int LTRSilverSteed = 0;
        public int LTRSkeletalMount = 0;
        public int LTRSwampDragon = 0;
        public int LTRUnicorn = 0;
    }

    public class NoKillType
    {
        public static bool Enabled { get { return Setup.active == KillType.None; } }
    }

    public class KillTypePK
    {
        public static bool Enabled { get { return Setup.active == KillType.OnlyPK; } }
    }

    public class KillTypeNPC
    {
        public static bool Enabled { get { return Setup.active == KillType.OnlyNPC; } }
    }

    public class KillTypeAll
    {
        public static bool Enabled { get { return Setup.active == KillType.AllKills; } }
    }

    public enum KillType
    {
        None,
        OnlyPK,
        OnlyNPC,
        AllKills
    }
}