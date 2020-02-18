using System;
using System.Collections;
using Server;
using Server.Gumps;
using Server.Multis;
using Server.Network;
using Server.ContextMenus;
using Server.Engines.PartySystem;

namespace Server.Items
{
    	public class SpawningClutterBookcase1 : LockableContainer
    	{
        	public override bool Decays{ get{ return true; } } 

        	public override TimeSpan DecayTime{ get{ return TimeSpan.FromMinutes( Utility.Random( 30, 60 ) ); } }

        	public override int DefaultGumpID{ get{ return 0x4D; } }
        	public override int DefaultDropSound{ get{ return 0x42; } }

        	public override Rectangle2D Bounds
        	{
            		get{ return new Rectangle2D( 18, 105, 144, 73 ); }
        	}

        	[Constructable]
        	public SpawningClutterBookcase1() : base( 0xA99 )
        	{
			Name = "a bookcase";
			Movable = true;
			Weight = 1000.0;

            		TrapPower = 0;
            		Locked = false;

           		RequiredSkill = 0;
            		LockLevel = 0;
            		MaxLockLevel = this.RequiredSkill;

/////////////////////////////////////// Custom Books

			switch ( Utility.Random( 14 ) )
			{
				case 0: DropItem( new CreatureCompendiumVol1() ); break;
				case 1: DropItem( new ModernGenesisC1() ); break;
				case 2: DropItem( new ModernGenesisC2() ); break;
				case 3: DropItem( new ModernGenesisC3() ); break;
				case 4: DropItem( new ModernGenesisC4() ); break;
				case 5: DropItem( new ModernGenesisC5() ); break;
				case 6: DropItem( new NastliasSong() ); break;
				case 7: DropItem( new RacialSlursVol1() ); break;
				case 8: DropItem( new RacialSlursVol2() ); break;
				case 9: DropItem( new ReleaseTheSandKraken() ); break;
				case 10: DropItem( new TaleOfTravelingPants() ); break;
				case 11: DropItem( new TamersHandbookEcology() ); break;
				case 12: DropItem( new BosomBuddies() ); break;
				case 13: DropItem( new ThreeYellowSnakes() ); break;
			}

/////////////////////////////////////// Song Lyrics

			switch ( Utility.Random( 20 ) )
			{
				case 0: DropItem( new BeatItLyrics() ); break;
				case 1: DropItem( new BigIronLyrics() ); break;
				case 2: DropItem( new BlowMeAwayLyrics() ); break;
				case 3: DropItem( new BrokenWingsLyrics() ); break;
				case 4: DropItem( new DownWithTheSicknessLyrics() ); break;
				case 5: DropItem( new DreamsLyrics() ); break;
				case 6: DropItem( new GravityOfLoveLyrics() ); break;
				case 7: DropItem( new HumblingRiverLyrics() ); break;
				case 8: DropItem( new ImMovingOutLyrics() ); break;
				case 9: DropItem( new JingleJangleJingleLyrics() ); break;
				case 10: DropItem( new ListenToTheWindLyrics() ); break;
				case 11: DropItem( new ParticleManLyrics() ); break;
				case 12: DropItem( new RideIntoTheSunsetLyrics() ); break;
				case 13: DropItem( new ShadowOfTheValleyLyrics() ); break;
				case 14: DropItem( new SitOnMyFaceLyrics() ); break;
				case 15: DropItem( new SunlightLivingLyrics() ); break;
				case 16: DropItem( new TheReckoningLyrics() ); break;
				case 17: DropItem( new TheyDontCareAboutUsLyrics() ); break;
				case 18: DropItem( new ThroughFireAndFlamesLyrics() ); break;
				case 19: DropItem( new WhatAWonderfulWorldLyrics() ); break;
			}

/////////////////////////////////////// Books

			switch ( Utility.Random( 14 ) )
			{
				case 0: DropItem( new GrammarOfOrcish() ); break;
				case 1: DropItem( new ArmsAndWeaponsPrimer() ); break;
				case 2: DropItem( new ChildrenTalesVol2() ); break;
				case 3: DropItem( new DimensionalTravel() ); break;
				case 4: DropItem( new EthicalHedonism() ); break;
				case 5: DropItem( new MyStory() ); break;
				case 6: DropItem( new DiversityOfOurLand() ); break;
				case 7: DropItem( new RegardingLlamas() ); break;
				case 8: DropItem( new TalkingToWisps() ); break;
				case 9: DropItem( new TamingDragons() ); break;
				case 10: DropItem( new TheFight() ); break;
				case 11: DropItem( new RankingsOfTrades() ); break;
				case 12: DropItem( new WildGirlOfTheForest() ); break;
				case 13: DropItem( new TreatiseOnAlchemy() ); break;
			}
        	}

        	public SpawningClutterBookcase1( Serial serial ) : base( serial )
        	{
        	}

        	public override void Serialize( GenericWriter writer )
        	{
            		base.Serialize( writer );
            		writer.Write( (int) 1 ); // version
        	}

        	public override void Deserialize( GenericReader reader )
        	{
            		base.Deserialize( reader );
            		int version = reader.ReadInt();
        	}
	}

    	public class SpawningClutterBookcase2 : LockableContainer
    	{
        	public override bool Decays{ get{ return true; } } 

        	public override TimeSpan DecayTime{ get{ return TimeSpan.FromMinutes( Utility.Random( 30, 60 ) ); } }

        	public override int DefaultGumpID{ get{ return 0x4D; } }
        	public override int DefaultDropSound{ get{ return 0x42; } }

        	public override Rectangle2D Bounds
        	{
            		get{ return new Rectangle2D( 18, 105, 144, 73 ); }
        	}

        	[Constructable]
        	public SpawningClutterBookcase2() : base( 0xA98 )
        	{
			Name = "a bookcase";
			Movable = true;
			Weight = 1000.0;

            		TrapPower = 0;
            		Locked = false;

            		RequiredSkill = 0;
            		LockLevel = 0;
            		MaxLockLevel = this.RequiredSkill;

/////////////////////////////////////// Custom Books

			switch ( Utility.Random( 14 ) )
			{
				case 0: DropItem( new CreatureCompendiumVol1() ); break;
				case 1: DropItem( new ModernGenesisC1() ); break;
				case 2: DropItem( new ModernGenesisC2() ); break;
				case 3: DropItem( new ModernGenesisC3() ); break;
				case 4: DropItem( new ModernGenesisC4() ); break;
				case 5: DropItem( new ModernGenesisC5() ); break;
				case 6: DropItem( new NastliasSong() ); break;
				case 7: DropItem( new RacialSlursVol1() ); break;
				case 8: DropItem( new RacialSlursVol2() ); break;
				case 9: DropItem( new ReleaseTheSandKraken() ); break;
				case 10: DropItem( new TaleOfTravelingPants() ); break;
				case 11: DropItem( new TamersHandbookEcology() ); break;
				case 12: DropItem( new BosomBuddies() ); break;
				case 13: DropItem( new ThreeYellowSnakes() ); break;
			}

/////////////////////////////////////// Song Lyrics

			switch ( Utility.Random( 20 ) )
			{
				case 0: DropItem( new BeatItLyrics() ); break;
				case 1: DropItem( new BigIronLyrics() ); break;
				case 2: DropItem( new BlowMeAwayLyrics() ); break;
				case 3: DropItem( new BrokenWingsLyrics() ); break;
				case 4: DropItem( new DownWithTheSicknessLyrics() ); break;
				case 5: DropItem( new DreamsLyrics() ); break;
				case 6: DropItem( new GravityOfLoveLyrics() ); break;
				case 7: DropItem( new HumblingRiverLyrics() ); break;
				case 8: DropItem( new ImMovingOutLyrics() ); break;
				case 9: DropItem( new JingleJangleJingleLyrics() ); break;
				case 10: DropItem( new ListenToTheWindLyrics() ); break;
				case 11: DropItem( new ParticleManLyrics() ); break;
				case 12: DropItem( new RideIntoTheSunsetLyrics() ); break;
				case 13: DropItem( new ShadowOfTheValleyLyrics() ); break;
				case 14: DropItem( new SitOnMyFaceLyrics() ); break;
				case 15: DropItem( new SunlightLivingLyrics() ); break;
				case 16: DropItem( new TheReckoningLyrics() ); break;
				case 17: DropItem( new TheyDontCareAboutUsLyrics() ); break;
				case 18: DropItem( new ThroughFireAndFlamesLyrics() ); break;
				case 19: DropItem( new WhatAWonderfulWorldLyrics() ); break;
			}

/////////////////////////////////////// Books

			switch ( Utility.Random( 14 ) )
			{
				case 0: DropItem( new GrammarOfOrcish() ); break;
				case 1: DropItem( new ArmsAndWeaponsPrimer() ); break;
				case 2: DropItem( new ChildrenTalesVol2() ); break;
				case 3: DropItem( new DimensionalTravel() ); break;
				case 4: DropItem( new EthicalHedonism() ); break;
				case 5: DropItem( new MyStory() ); break;
				case 6: DropItem( new DiversityOfOurLand() ); break;
				case 7: DropItem( new RegardingLlamas() ); break;
				case 8: DropItem( new TalkingToWisps() ); break;
				case 9: DropItem( new TamingDragons() ); break;
				case 10: DropItem( new TheFight() ); break;
				case 11: DropItem( new RankingsOfTrades() ); break;
				case 12: DropItem( new WildGirlOfTheForest() ); break;
				case 13: DropItem( new TreatiseOnAlchemy() ); break;
			}
        	}

        	public SpawningClutterBookcase2( Serial serial ) : base( serial )
        	{
        	}

        	public override void Serialize( GenericWriter writer )
        	{
            		base.Serialize( writer );
            		writer.Write( (int) 1 ); // version
        	}

        	public override void Deserialize( GenericReader reader )
        	{
            		base.Deserialize( reader );
            		int version = reader.ReadInt();
        	}
    	}
}