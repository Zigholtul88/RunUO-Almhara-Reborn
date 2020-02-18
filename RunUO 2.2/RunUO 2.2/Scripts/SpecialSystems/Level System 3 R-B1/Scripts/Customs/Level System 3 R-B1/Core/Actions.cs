using System;
using Server;
using Server.Gumps;
using Server.Items;
using Server.Mobiles;
using Server.Network;
using Server.Engines.Craft;
using Server.Engines.PartySystem;

namespace Server
{
    public class Actions
    {
        public static void StartGain(Mobile killer, Mobile killed)
        {
            Setup set = new Setup();
            PlayerMobile pm = null;

            if (killer is PlayerMobile) //Find & Set killer
                pm = killer as PlayerMobile;
            else
            {
                BaseCreature bc = killer as BaseCreature;

                if (bc.Controlled && set.ExpFromPetKills)
                    pm = bc.GetMaster() as PlayerMobile;
            }

            if (pm == null) //if no killer Exit system
                return;

            double Gain = Figures.GetKillExp(pm, killed, new Setup()); //Get the exp for the kill

            FinalizeExp(pm, killed, Gain, new Setup());
        }

        public static void ExpPlugin(Mobile m, double Gain)
        {
            Setup set = new Setup();
            FinalizeExp(m, null, Gain, false, new Setup());
        }

        public static void FinalizeExp(Mobile m, Mobile killed, double Gain, Setup set)//for kills (no Craft bool)
        {
            FinalizeExp(m, killed, Gain, false, new Setup());
        }

        public static void FinalizeExp(Mobile m, double Gain, bool Craft, Setup set)//for craft (no killed Mobile)
        {
            FinalizeExp(m, null, Gain, Craft, new Setup());
        }

        public static void FinalizeExp(Mobile m, Mobile killed, double Gain, bool Craft, Setup set)
        {
            double BeforeFilter;//used only for party exp system
            double AfterLevelDiffFilter;
            double AfterCapFilter;
            Party party = Party.Get(m);

            if (!Craft && killed != null && party != null && set.ExpPartyShare)
            {
                int PlayersInRange = 0;

                foreach (PartyMemberInfo info in party.Members)
                {
                    PlayerMobile pm = info.Mobile as PlayerMobile;

                    if (pm.Alive && pm.InRange(killed, set.PartyRange))
                        PlayersInRange++;
                }//Dumb that I have to count players this way....

                if (set.ExpEvenPartyShare)
                    BeforeFilter = Gain / PlayersInRange;
                else
                    BeforeFilter = Gain;

                foreach (PartyMemberInfo info in party.Members)
                {
                    PlayerMobile pm = info.Mobile as PlayerMobile;

                    if (pm.Alive && pm.InRange(killed, set.PartyRange))
                    {
                        AfterLevelDiffFilter = Figures.LevelDiffFilter(pm, killed, BeforeFilter, new Setup());
                        AfterCapFilter = Figures.CapFilter(pm, AfterLevelDiffFilter, new Setup());
                        AddExp(pm, AfterCapFilter, new Setup());
                    }
                }
            }
            else
            {
                PlayerMobile pm = m as PlayerMobile;
                AfterLevelDiffFilter = Figures.LevelDiffFilter(pm, killed, Gain, new Setup());
                AfterCapFilter = Figures.CapFilter(pm, AfterLevelDiffFilter, new Setup());

                AddExp(pm, AfterCapFilter, new Setup());
            }
        }

        public static void AddExp(Mobile m, double Gain, Setup set)
        {
            PlayerMobile pm = m as PlayerMobile;

            if (Gain > 0)
                pm.SendMessage("You've gained {0} exp.", Math.Round(Gain, 2));

            pm.KillExp += Math.Round(Gain, 2);
            pm.AccKillExp += Math.Round(Gain, 2);

            if (set.RefreshExpBarOnGain && pm.HasGump(typeof(ExpBar)))
            {
                pm.CloseGump(typeof(ExpBar));
                pm.SendGump(new ExpBar(pm));
            }

            if (pm.Level < pm.LevelCap && pm.Exp >= pm.LevelAt)
                DoLevel(pm, new Setup());
        }

        public static void DoLevel(Mobile m, Setup set)
        {
            double TimesLeveled = 0;
            PlayerMobile pm = m as PlayerMobile;

            pm.PlaySound( 0x5B4 );
            Effects.SendLocationParticles( EffectItem.Create( pm.Location, pm.Map, EffectItem.DefaultDuration ), 0, 0, 0, 0, 0, 5060, 0 );
            Effects.PlaySound( pm.Location, pm.Map, 0x243 );
            Effects.SendMovingParticles( new Entity( Serial.Zero, new Point3D( pm.X - 6, pm.Y - 6, pm.Z + 15 ), pm.Map ), pm, 0x36D4, 7, 0, false, true, 0x497, 0, 9502, 1, 0, (EffectLayer)255, 0x100 );
            Effects.SendMovingParticles( new Entity( Serial.Zero, new Point3D( pm.X - 4, pm.Y - 6, pm.Z + 15 ), pm.Map ), pm, 0x36D4, 7, 0, false, true, 0x497, 0, 9502, 1, 0, (EffectLayer)255, 0x100 );
            Effects.SendMovingParticles( new Entity( Serial.Zero, new Point3D( pm.X - 6, pm.Y - 4, pm.Z + 15 ), pm.Map ), pm, 0x36D4, 7, 0, false, true, 0x497, 0, 9502, 1, 0, (EffectLayer)255, 0x100 );

            pm.PlaySound( 0x20F );
            pm.FixedParticles( 0x376A, 1, 31, 9961, 1160, 0, EffectLayer.Waist );
            pm.FixedParticles( 0x37C4, 1, 31, 9502, 43, 2, EffectLayer.Waist );

            if (set.StatRefillOnLevel)
            {
                if (pm.Hits < pm.HitsMax)
                    pm.Hits = pm.HitsMax;

                if (pm.Mana < pm.ManaMax)
                    pm.Mana = pm.ManaMax;

                if (pm.Stam < pm.StamMax)
                    pm.Stam = pm.StamMax;
            }


            /*
            while (pm.Exp >= pm.LevelAt && pm.Level != pm.LevelCap)
            {
                if (set.AccumulativeExp)
                    return;

                int newexp = 0;

                if (pm.Exp > pm.LevelAt)
                    newexp = pm.Exp - pm.LevelAt;

                pm.Exp = newexp;
                TimesLeveled++;
            }
            */

            for (int i = 1; pm.Exp >= pm.LevelAt; i++)
            {
                pm.LevelAt += set.NextLevelAt;
                pm.AccLevelAt += (int)(set.NextLevelAt + pm.AccKillExp);

                pm.Exp = 0;
                pm.KillExp = 0;

                if ( pm.Profession == 1 )
                {
                        pm.RawStr += 4;
                        pm.RawDex += 1;
                        pm.RawInt += 0;
                }

                else if ( pm.Profession == 2 )
                {
                        pm.RawStr += 1;
                        pm.RawDex += 1;
                        pm.RawInt += 3;
                }

                else if ( pm.Profession == 3 )
                {
                        pm.RawStr += 3;
                        pm.RawDex += 1;
                        pm.RawInt += 1;
                }

                else if ( pm.Profession == 4 )
                {
                        pm.RawStr += 2;
                        pm.RawDex += 1;
                        pm.RawInt += 2;
                }

                else if ( pm.Profession == 5 )
                {
                        pm.RawStr += 2;
                        pm.RawDex += 1;
                        pm.RawInt += 2;
                }

                else if ( pm.Profession == 6 )
                {
                        pm.RawStr += 3;
                        pm.RawDex += 1;
                        pm.RawInt += 1;
                }

                else if ( pm.Profession == 7 )
                {
                        pm.RawStr += 1;
                        pm.RawDex += 3;
                        pm.RawInt += 1;
                }

                else if ( pm.Profession == 8 )
                {
                        pm.RawStr += 1;
                        pm.RawDex += 1;
                        pm.RawInt += 3;
                }

                else if ( pm.Profession == 9 )
                {
                        pm.RawStr += 2;
                        pm.RawDex += 1;
                        pm.RawInt += 2;
                }

                else if ( pm.Profession == 10 )
                {
                        pm.RawStr += 1;
                        pm.RawDex += 2;
                        pm.RawInt += 2;
                }

                else if ( pm.Profession == 11 )
                {
                        pm.RawStr += 1;
                        pm.RawDex += 3;
                        pm.RawInt += 1;
                }

                else if ( pm.Profession == 12 )
                {
                        pm.RawStr += 1;
                        pm.RawDex += 3;
                        pm.RawInt += 1;
                }

                else if ( pm.Profession == 666 ) // Running Pants
                {
                        pm.RawStr += 1;
                        pm.RawDex += 1;
                        pm.RawInt += 1;
                }

                if (set.BonusStatOnLevel && pm.RawStatTotal != pm.StatCap && set.ChanceForBonusStat < Utility.Random(100))
                {
                    switch (Utility.Random(3))
                    {
                        case 0: pm.RawStr += 1; break;
                        case 1: pm.RawDex += 1; break;
                        case 2: pm.RawInt += 1; break;
                    }
                }

                TimesLeveled = i;
            }

            if (set.RefreshExpBarOnGain && pm.HasGump(typeof(ExpBar)))
            {
                pm.CloseGump(typeof(ExpBar));
                pm.SendGump(new ExpBar(pm));
            }

            pm.SendMessage("You're Level has increased by {0}", TimesLeveled);
            pm.Level += (int)TimesLeveled;
        }
    }
}