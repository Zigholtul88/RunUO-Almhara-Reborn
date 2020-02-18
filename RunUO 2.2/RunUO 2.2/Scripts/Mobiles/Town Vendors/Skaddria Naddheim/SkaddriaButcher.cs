using System;
using System.Collections;
using System.Collections.Generic;
using Server;
using Server.Items;
using Server.Targeting;
using Server.Commands;
using Server.ContextMenus;
using Server.Gumps;
using Server.Misc;
using Server.Network;
using Server.Spells;
using Server.Mobiles;

namespace Server.Mobiles 
{ 
	public class SkaddriaButcher : BaseVendor 
	{ 
		private List<SBInfo> m_SBInfos = new List<SBInfo>(); 
		protected override List<SBInfo> SBInfos{ get { return m_SBInfos; } } 

		public override bool InitialInnocent{ get{ return true; } }
		public override bool CanTeach { get { return true; } }

		[Constructable]
		public SkaddriaButcher() : base( "the butcher" ) 
		{ 
		} 

		public override void InitSBInfo() 
		{ 
			m_SBInfos.Add( new SBSkaddriaButcher() ); 
		}

		public override void InitOutfit()
		{
			Name = "Norman Donovan";
                 	Body = 400;
                        Female = false;
                        Race = Race.Human;
                        Hue = 33821;
                        HairItemID = 0;
                        HairHue = 0;
                        FacialHairItemID = 8268;
                        FacialHairHue = 1140;

			SetStr( 90 );
			SetDex( 54 );
			SetInt( 26 );

			SetSkill( SkillName.Anatomy, 59.5, 68.7 );
			SetSkill( SkillName.Tactics, 60.0, 83.0 );

			PackGold( 41, 82 );

			AddItem( new Cleaver() );
			AddItem( new FullApron(905) );
			AddItem( new ShortPants(983) );
			AddItem( new Boots(927) );
                }

		public SkaddriaButcher( Serial serial ) : base( serial ) 
		{ 
		}

		public override void GetContextMenuEntries( Mobile from, List<ContextMenuEntry> list ) 
		{
			base.GetContextMenuEntries( from, list );
			list.Add( new SkaddriaButcherEntry( from, this ) );
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

		public class SkaddriaButcherEntry : ContextMenuEntry
		{
			private Mobile m_Mobile;
			private Mobile m_Giver;
			
			public SkaddriaButcherEntry( Mobile from, Mobile giver ) : base( 6146, 3 )
			{
				m_Mobile = from;
				m_Giver = giver;
			}
			
			public override void OnClick()
			{
				if( !( m_Mobile is PlayerMobile ) )
					return;
				
				PlayerMobile mobile = (PlayerMobile) m_Mobile;	
				{
					if ( ! mobile.HasGump( typeof( SkaddriaButcherGump ) ) )
					{
						mobile.SendGump( new SkaddriaButcherGump( mobile ));
					}
				}
			}
		}
	}

	public class SBSkaddriaButcher : SBInfo 
	{ 
		private List<GenericBuyInfo> m_BuyInfo = new InternalBuyInfo(); 
		private IShopSellInfo m_SellInfo = new InternalSellInfo(); 

		public SBSkaddriaButcher() 
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

   public class SkaddriaButcherGump : Gump 
   { 
      public static void Initialize() 
      { 
         CommandSystem.Register( "SkaddriaButcherGump", AccessLevel.GameMaster, new CommandEventHandler( SkaddriaButcherGump_OnCommand ) ); 
      } 

      private static void SkaddriaButcherGump_OnCommand( CommandEventArgs e ) 
      { 
         e.Mobile.SendGump( new SkaddriaButcherGump( e.Mobile ) ); 
      } 

      public SkaddriaButcherGump( Mobile owner ) : base( 50,50 ) 
      { 
//----------------------------------------------------------------------------------------------------

				AddPage( 0 );
			AddImageTiled(  54, 33, 369, 400, 2624 );
			AddAlphaRegion( 54, 33, 369, 400 );

			AddImageTiled( 416, 39, 44, 389, 203 );
//--------------------------------------Window size bar--------------------------------------------
			
			AddImage( 97, 49, 9005 );
			AddImageTiled( 58, 39, 29, 390, 10460 );
			AddImageTiled( 412, 37, 31, 389, 10460 );
			AddLabel( 140, 60, 0x34, "" );
			
			AddHtml( 107, 140, 300, 230, "<BODY>" +
//----------------------/----------------------------------------------/
"<BASEFONT COLOR=YELLOW>Alas to you, young adventurer. As you <BR>" +
"<BASEFONT COLOR=YELLOW>probably already know my profession<BR>" +
"<BASEFONT COLOR=YELLOW>specializes in cutting up dead animals<BR>" +
"<BASEFONT COLOR=YELLOW>until there's only raw meat left, then <BR>" +
"<BASEFONT COLOR=YELLOW>it is shipped away to various cooks <BR>" +
"<BASEFONT COLOR=YELLOW>where the product will be prepared for<BR>" +
"<BASEFONT COLOR=YELLOW>human consumption. If you have any <BR>" +
"<BASEFONT COLOR=YELLOW>raw meat on you then I will take it off<BR>" +
"<BASEFONT COLOR=YELLOW>of your hands. A butcher's life is not <BR>" +
"<BASEFONT COLOR=YELLOW>a fancy one, but we're the reason why <BR>" +
"<BASEFONT COLOR=YELLOW>you never find a rabbit's foot inside <BR>" +
"<BASEFONT COLOR=YELLOW>of a soup dish Unless that brew came  <BR>" +
"<BASEFONT COLOR=YELLOW>from orcs, in which case you're getting<BR>" +
"<BASEFONT COLOR=YELLOW>screwed over and chances are they're <BR>" +
"<BASEFONT COLOR=YELLOW>probably trying to kill you.<BR>" +
"</BODY>", false, true);
			
//			<BASEFONT COLOR=#7B6D20>			

			AddImage( 430, 9, 10441);
			AddImageTiled( 40, 38, 17, 391, 9263 );
			AddImage( 6, 25, 10421 );
			AddImage( 34, 12, 10420 );
			AddImageTiled( 94, 25, 342, 15, 10304 );
			AddImageTiled( 40, 427, 415, 16, 10304 );
			AddImage( -10, 314, 10402 );
			AddImage( 56, 150, 10411 );
			AddImage( 155, 120, 2103 );
			AddImage( 136, 84, 96 );

			AddButton( 225, 390, 0xF7, 0xF8, 0, GumpButtonType.Reply, 0 ); 

//--------------------------------------------------------------------------------------------------------------
      } 

      public override void OnResponse( NetState state, RelayInfo info ) //Function for GumpButtonType.Reply Buttons 

      { 
         Mobile from = state.Mobile; 

         switch ( info.ButtonID ) 
         { 
            case 0: //Case uses the ActionIDs defenied above. Case 0 defenies the actions for the button with the action id 0 
            { 
               //Cancel 
               break; 
            } 
         }
      }
   }
}
