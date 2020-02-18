using System;
using System.Collections;
using System.Collections.Generic;
using Server;
using Server.Items;
using Server.Targeting;
using Server.ContextMenus;
using Server.Gumps;
using Server.Misc;
using Server.Network;
using Server.Spells;
using Server.Mobiles;

namespace Server.Mobiles 
{ 
	public class YondallButcher : BaseVendor 
	{ 
		private List<SBInfo> m_SBInfos = new List<SBInfo>(); 
		protected override List<SBInfo> SBInfos{ get { return m_SBInfos; } } 

		public override bool InitialInnocent{ get{ return true; } }
		public override bool CanTeach { get { return true; } }

		[Constructable]
		public YondallButcher() : base( "the butcher" ) 
		{ 
		} 

		public override void InitSBInfo() 
		{ 
			m_SBInfos.Add( new SBYondallButcher() ); 
		}

		public override void InitOutfit()
		{
			SetStr( 117 );
			SetDex( 96 );
			SetInt( 54 );

			SetSkill( SkillName.Anatomy, 59.5, 68.7 );
			SetSkill( SkillName.Tactics, 60.0, 83.0 );

			PackGold( 41, 82 );

			if ( this.Female = Utility.RandomBool() ) 
			{ 
				this.Body = 0x191; 
				this.Name = NameList.RandomName( "female" );
			        this.Hue = Utility.RandomSkinHue(); 

                                this.HairHue = Utility.RandomList( 26,44,81,1102,1107,1108,1109,1116,1117,1122,1138,1140,1141,1146,1148,1149,1153 );
                                this.HairItemID = Utility.RandomList( 8251,8252,8253,8260,8261,8262,8263,8264,8265 );

			        switch ( Utility.Random( 17 ) )
			        {
				       case 0: AddItem( new CitizenDress( Utility.RandomBlueHue() ) ); break;
				       case 1: AddItem( new CommonerDress( Utility.RandomGreenHue() ) ); break;
				       case 2: AddItem( new ConfessorDress( Utility.RandomRedHue() ) ); break;
				       case 3: AddItem( new ElegantGown( Utility.RandomYellowHue() ) ); break;
				       case 4: AddItem( new FancyDress( Utility.RandomBlueHue() ) ); break;
				       case 5: AddItem( new FlowerDress( Utility.RandomGreenHue() ) ); break;
				       case 6: AddItem( new FormalDress( Utility.RandomRedHue() ) ); break;
				       case 7: AddItem( new GildedDress( Utility.RandomYellowHue() ) ); break;
				       case 8: AddItem( new MaidensDress( Utility.RandomBlueHue() ) ); break;
				       case 9: AddItem( new MedievalLongDress( Utility.RandomGreenHue() ) ); break;
				       case 10: AddItem( new NobleDress( Utility.RandomRedHue() ) ); break;
				       case 11: AddItem( new NocturnalDress( Utility.RandomYellowHue() ) ); break;
				       case 12: AddItem( new PartyDress( Utility.RandomBlueHue() ) ); break;
				       case 13: AddItem( new PlainDress( Utility.RandomGreenHue() ) ); break;
				       case 14: AddItem( new ReinassanceDress( Utility.RandomRedHue() ) ); break;
				       case 15: AddItem( new TheaterDress( Utility.RandomYellowHue() ) ); break;
				       case 16: AddItem( new VictorianDress( Utility.RandomNeutralHue() ) ); break;
			        }

			        switch ( Utility.Random( 8 ) )
			        {
				       case 0: AddItem( new Boots( Utility.RandomNeutralHue() ) ); break;
				       case 1: AddItem( new FurBoots( Utility.RandomNeutralHue() ) ); break;
				       case 2: AddItem( new LightBoots( Utility.RandomNeutralHue() ) ); break;
				       case 3: AddItem( new Sandals( Utility.RandomNeutralHue() ) ); break;
				       case 4: AddItem( new ShortBoots( Utility.RandomNeutralHue() ) ); break;
				       case 5: AddItem( new ThighBoots( Utility.RandomNeutralHue() ) ); break;
			        }

			        if ( 0.05 > Utility.RandomDouble() )
                                {
			              SilverBracelet bracelet = new SilverBracelet();
                                      bracelet.Hue = Utility.RandomList( 26,44,81,1102,1107,1108,1109,1116,1117,1122,1138,1140,1141,1146,1148,1149,1153 );
			              bracelet.Movable = true;
			              AddItem( bracelet );
                                }

			        if ( 0.05 > Utility.RandomDouble() )
                                {
			              SilverNecklace necklace = new SilverNecklace();
                                      necklace.Hue = Utility.RandomList( 26,44,81,1102,1107,1108,1109,1116,1117,1122,1138,1140,1141,1146,1148,1149,1153 );
			              necklace.Movable = true;
			              AddItem( necklace );
                                }

			        if ( 0.05 > Utility.RandomDouble() )
                                {
			              SilverEarrings earrings = new SilverEarrings();
                                      earrings.Hue = Utility.RandomList( 26,44,81,1102,1107,1108,1109,1116,1117,1122,1138,1140,1141,1146,1148,1149,1153 );
			              earrings.Movable = true;
			              AddItem( earrings );
                                }
			}
			else 
			{ 
				this.Body = 0x190; 
				this.Name = NameList.RandomName( "male" );
			        this.Hue = Utility.RandomSkinHue();

                                this.HairHue = Utility.RandomList( 26,44,81,1102,1107,1108,1109,1116,1117,1122,1138,1140,1141,1146,1148,1149,1153 );
                                this.HairItemID = Utility.RandomList( 8251,8252,8253,8260,8261,8262,8263,8264,8265 );
                                this.FacialHairHue = Utility.RandomList( 26,44,81,1102,1107,1108,1109,1116,1117,1122,1138,1140,1141,1146,1148,1149,1153 );
                                this.FacialHairItemID = Utility.RandomList( 8254,8255,8256,8257,8267,8268,8269 );

			        switch ( Utility.Random( 8 ) )
			        {
				       case 0: AddItem( new FancyShirt( Utility.RandomBlueHue() ) ); break;
				       case 1: AddItem( new FancyTunic( Utility.RandomGreenHue() ) ); break;
				       case 2: AddItem( new FormalShirt( Utility.RandomRedHue() ) ); break;
				       case 3: AddItem( new LeatherShirt( Utility.RandomYellowHue() ) ); break;
				       case 4: AddItem( new ReinassanceShirt( Utility.RandomBlueHue() ) ); break;
				       case 5: AddItem( new Shirt( Utility.RandomGreenHue() ) ); break;
				       case 6: AddItem( new Surcoat( Utility.RandomRedHue() ) ); break;
				       case 7: AddItem( new Tunic( Utility.RandomNeutralHue() ) ); break;
                                }


			        switch ( Utility.Random( 9 ) )
			        {
				       case 0: AddItem( new FancyPants( Utility.RandomNeutralHue() ) ); break;
				       case 1: AddItem( new FurSarong( Utility.RandomNeutralHue() ) ); break;
				       case 2: AddItem( new Hakama( Utility.RandomNeutralHue() ) ); break;
				       case 3: AddItem( new Kilt( Utility.RandomNeutralHue() ) ); break;
				       case 4: AddItem( new LeatherPants( Utility.RandomNeutralHue() ) ); break;
				       case 5: AddItem( new LongPants( Utility.RandomNeutralHue() ) ); break;
				       case 6: AddItem( new ReinassancePants( Utility.RandomNeutralHue() ) ); break;
				       case 7: AddItem( new ShortPants( Utility.RandomNeutralHue() ) ); break;
				       case 8: AddItem( new TattsukeHakama( Utility.RandomNeutralHue() ) ); break;
                                }

			        switch ( Utility.Random( 6 ) )
			        {
				       case 0: AddItem( new Boots( Utility.RandomNeutralHue() ) ); break;
				       case 1: AddItem( new HeavyBoots( Utility.RandomNeutralHue() ) ); break;
				       case 2: AddItem( new HighBoots( Utility.RandomNeutralHue() ) ); break;
				       case 3: AddItem( new Shoes( Utility.RandomNeutralHue() ) ); break;
				       case 4: AddItem( new ShortBoots( Utility.RandomNeutralHue() ) ); break;
				       case 5: AddItem( new ThighBoots( Utility.RandomNeutralHue() ) ); break;
                                }


			        if ( 0.05 > Utility.RandomDouble() )
                                {
			              SilverBracelet bracelet = new SilverBracelet();
                                      bracelet.Hue = Utility.RandomList( 26,44,81,1102,1107,1108,1109,1116,1117,1122,1138,1140,1141,1146,1148,1149,1153 );
			              bracelet.Movable = true;
			              AddItem( bracelet );
                                }

			        if ( 0.05 > Utility.RandomDouble() )
                                {
			              SilverEarrings earrings = new SilverEarrings();
                                      earrings.Hue = Utility.RandomList( 26,44,81,1102,1107,1108,1109,1116,1117,1122,1138,1140,1141,1146,1148,1149,1153 );
			              earrings.Movable = true;
			              AddItem( earrings );
                                }
			} 

			if ( 0.05 > Utility.RandomDouble() )
				AddItem( new BodySash( Utility.RandomDyedHue() ) );

			if ( 0.05 > Utility.RandomDouble() )
                        {
			        switch ( Utility.Random( 6 ) )
			        {
				      case 0: AddItem( new Bandana( Utility.RandomDyedHue() ) ); break;
				      case 1: AddItem( new Bonnet( Utility.RandomDyedHue() ) ); break;
				      case 2: AddItem( new Cap( Utility.RandomDyedHue() ) ); break;
				      case 3: AddItem( new FeatheredHat( Utility.RandomDyedHue() ) ); break;
				      case 4: AddItem( new SkullCap( Utility.RandomDyedHue() ) ); break;
				      case 5: AddItem( new WideBrimHat( Utility.RandomDyedHue() ) ); break;
			        }
                        }
                }

		public YondallButcher( Serial serial ) : base( serial ) 
		{ 
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );
			writer.Write( (int) 0 ); // version
		}

		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader );
			int version = reader.ReadInt();
		}
	}

	public class SBYondallButcher : SBInfo 
	{ 
		private List<GenericBuyInfo> m_BuyInfo = new InternalBuyInfo(); 
		private IShopSellInfo m_SellInfo = new InternalSellInfo(); 

		public SBYondallButcher() 
		{ 
		} 

		public override IShopSellInfo SellInfo { get { return m_SellInfo; } } 
		public override List<GenericBuyInfo> BuyInfo { get { return m_BuyInfo; } } 

		public class InternalBuyInfo : List<GenericBuyInfo> 
		{ 
			public InternalBuyInfo() 
			{
				Add( new GenericBuyInfo( typeof( ButcherKnife ), 50, 20, 0x13F6, 0 ) );
 				Add( new GenericBuyInfo( typeof( Cleaver ), 50, 20, 0xEC3, 0 ) );
				Add( new GenericBuyInfo( typeof( SkinningKnife ), 50, 20, 0xEC4, 0 ) );
			} 
		} 

		public class InternalSellInfo : GenericSellInfo 
		{ 
			public InternalSellInfo() 
			{ 
				Add( typeof( ButcherKnife ), 25 ); 
				Add( typeof( Cleaver ), 25 ); 
				Add( typeof( SkinningKnife ), 25 ); 

//////////////////////////////// Raw Food ////////////////////////////////

				Add( typeof( AlligatorMeat ), 6 ); 
				Add( typeof( BlackLizardMeat ), 7 ); 
				Add( typeof( FaerieBeetleCollectorMeat ), 5 ); 
				Add( typeof( FaerieBeetleMeat ), 12 );
				Add( typeof( GreySquirrelMeat ), 4 );
				Add( typeof( HillToadMeat ), 17 ); 
				Add( typeof( LargeFrogMeat ), 6 ); 
				Add( typeof( RawDireWolfLeg ), 8 ); 
				Add( typeof( RawForestBatRibs ), 3 );
				Add( typeof( RawGizzardRibs ), 6 ); 
				Add( typeof( RawGreyWolfLeg ), 5 ); 
				Add( typeof( RawHarpyRibs ), 16 ); 
				Add( typeof( SandCrabMeat ), 11 ); 
				Add( typeof( SewerBeef ), 4 );
				Add( typeof( WaterLizardMeat ), 9 ); 
				Add( typeof( WyvernMeat ), 25 ); 

//////////////////////////////// Poultry ////////////////////////////////

				Add( typeof( RawBird ), 2 ); 
				Add( typeof( RawChicken ), 5 ); 
				Add( typeof( RawChickenLeg ), 4 ); 
				Add( typeof( RawDuck ), 5 ); 
				Add( typeof( RawDuckLeg ), 4 ); 
				Add( typeof( RawTurkey ), 26 );
				Add( typeof( RawTurkeyLeg ), 14 ); 

//////////////////////////////// Protein Foods ////////////////////////////////

				Add( typeof( RawRibs ), 5 ); 
				Add( typeof( RawLambLeg ), 4 ); 
				Add( typeof( RawChickenLeg ), 3 ); 
				Add( typeof( RawFishSteak ), 3 );

//////////////////////////////// Alytharr Region

				Add( typeof( AlytharrGrassSnakeSkin ), 165 ); 
				Add( typeof( BeachBeetleSerum ), 180 ); 
				Add( typeof( BlackLizardEyeBall ), 175 );
				Add( typeof( CentaurClaw ), 210 );
				Add( typeof( ForestHartShard ), 500 );
				Add( typeof( HillToadEye ), 125 );
				Add( typeof( MinorBloodVial ), 300 );
				Add( typeof( SandCrabCarapace ), 150 );
				Add( typeof( WyvernTooth ), 300 );

//////////////////////////////// Autumnwood

				Add( typeof( HarpyTalon ), 575 );
				Add( typeof( PeltedMinotaurFur ), 600 );
				Add( typeof( RazorbackTooth ), 225 );
				Add( typeof( SahaginScale ), 125 );

//////////////////////////////// Dragonstorm Island

				Add( typeof( DragonHeart ), 500 );

//////////////////////////////// Farron Glades

				Add( typeof( AdamantoiseCarapace ), 2500 );
				Add( typeof( AdamantoiseEgg ), 1500 );
				Add( typeof( AdamantoiseTooth ), 500 );
				Add( typeof( AdjuleTooth ), 450 );
				Add( typeof( AlPacaEye ), 600 );
				Add( typeof( AnnihilationBeetleCarapace ), 1200 );
				Add( typeof( BarghestClaw ), 700 );
				Add( typeof( BarghestTooth ), 350 );
				Add( typeof( GratNectar ), 500 );
				Add( typeof( GreenAllosaurClaw ), 850 );
				Add( typeof( GreenAllosaurTooth ), 450 );
				Add( typeof( KelpieEye ), 550 );

//////////////////////////////// Glimmerwood

 				Add( typeof( AntLionCarapace ), 295 ); 
				Add( typeof( AntLionEgg ), 400 );
				Add( typeof( AntLionTooth ), 175 );
				Add( typeof( ForestOstardEgg ), 500 );
 				Add( typeof( GryphonBeak ), 375 ); 
				Add( typeof( GryphonClaw ), 225 );
				Add( typeof( ImpClaw ), 150 );
				Add( typeof( RidgebackEgg ), 700 );
 				Add( typeof( RoseOfQingniao ), 475 ); 
				Add( typeof( RoseOfShangyang ), 215 );

//////////////////////////////// Harashi Nabi

				Add( typeof( BulletAntStinger ), 325 );
 				Add( typeof( CharredSpriteWings ), 275 ); 
				Add( typeof( DeathwatchBeetleEgg ), 600 );
				Add( typeof( DesertOstardEgg ), 700 );
				Add( typeof( LionPelt ), 1500 );
				Add( typeof( LionTooth ), 450 );
				Add( typeof( MummyBandage ), 485 );
				Add( typeof( OphidianEye ), 565 );
				Add( typeof( RedbarkPoisonGland ), 335 );
				Add( typeof( RedbarkScorpionCarapace ), 550 );
				Add( typeof( RoseOfJubokko ), 750 );
				Add( typeof( SandStreakerWings ), 445 );

//////////////////////////////// Island of Giants

				Add( typeof( EttinTooth ), 285 ); 
				Add( typeof( OgreEye ), 225 );
				Add( typeof( RawDireWolfLeg ), 175 ); 
				Add( typeof( TrollTooth ), 205 );

//////////////////////////////// Oboru Jungle

				Add( typeof( PookahEye ), 200 );

//////////////////////////////// Zaythalor Forest

				Add( typeof( SmallStarLakeCrabEgg ), 250 ); 
				Add( typeof( LargeStarLakeCrabEgg ), 300 ); 

				Add( typeof( AlmirajHorn ), 215 );
				Add( typeof( CliffStriderPowder ), 125 );
				Add( typeof( FaerieBeetleCarapace ), 50 ); 
				Add( typeof( ForestBatClaw ), 50 );
				Add( typeof( GreenSlimeVial ), 125 );
				Add( typeof( LesserAntlionCarapace ), 175 );
				Add( typeof( RawGreyWolfLeg ), 50 );
				Add( typeof( SmallBlackAntEgg ), 200 );
				Add( typeof( SwampVineAppendages ), 125 );
				Add( typeof( VerdantSpriteWings ), 75 );
				Add( typeof( WaterLizardEyeBall ), 50 );

//////////////////////////////// Bharlim Passage

				Add( typeof( GiantToadEye ), 445 );
				Add( typeof( MesmenirHorn ), 475 );

//////////////////////////////// Everstar Estuary

				Add( typeof( RoseOfUmdhlebi ), 975 );

//////////////////////////////// Mongbat Hideout

				Add( typeof( CavernMongbatClaw ), 275 ); 

//////////////////////////////// Murkmere Dwelling

				Add( typeof( RoseOfQuagmire ), 415 );

//////////////////////////////// Stone Burrow Mines

				Add( typeof( CavernScorpionCarapace ), 350 );

//////////////////////////////// Whispering Hollow

				Add( typeof( KitsuneClaw ), 285 );
				Add( typeof( LamiaScale ), 300 );
				Add( typeof( SalivaEye ), 1500 );
				Add( typeof( SeekerEye ), 250 );
				Add( typeof( VampireBatClaw ), 215 );
				Add( typeof( WhippingVineAppendages ), 375 );
			} 
		} 
	} 
}
