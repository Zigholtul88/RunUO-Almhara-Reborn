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
	public class SkaddriaCobbler : BaseVendor 
	{ 
		private List<SBInfo> m_SBInfos = new List<SBInfo>(); 
		protected override List<SBInfo> SBInfos{ get { return m_SBInfos; } } 

		public override bool InitialInnocent{ get{ return true; } }
		public override bool CanTeach { get { return true; } }

		[Constructable]
		public SkaddriaCobbler() : base( "the cobbler" ) 
		{ 
		} 

		public override void InitSBInfo() 
		{ 
			m_SBInfos.Add( new SBSkaddriaCobbler() ); 
		}

		public override void InitOutfit()
		{
			SetStr( 42 );
			SetDex( 51 );
			SetInt( 16 );

			SetSkill( SkillName.Tailoring, 60.0, 83.0 );

			PackGold( 23, 35 );

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

		public SkaddriaCobbler( Serial serial ) : base( serial ) 
		{ 
		} 

		public override void GetContextMenuEntries( Mobile from, List<ContextMenuEntry> list ) 
		{
			base.GetContextMenuEntries( from, list );
			list.Add( new SkaddriaCobblerEntry( from, this ) );
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

		public class SkaddriaCobblerEntry : ContextMenuEntry
		{
			private Mobile m_Mobile;
			private Mobile m_Giver;
			
			public SkaddriaCobblerEntry( Mobile from, Mobile giver ) : base( 6146, 3 )
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
					if ( ! mobile.HasGump( typeof( SkaddriaCobblerGump ) ) )
					{
						mobile.SendGump( new SkaddriaCobblerGump( mobile ));
					}
				}
			}
		}
        }

	public class SBSkaddriaCobbler : SBInfo 
	{ 
		private List<GenericBuyInfo> m_BuyInfo = new InternalBuyInfo(); 
		private IShopSellInfo m_SellInfo = new InternalSellInfo(); 

		public SBSkaddriaCobbler() 
		{ 
		} 

		public override IShopSellInfo SellInfo { get { return m_SellInfo; } } 
		public override List<GenericBuyInfo> BuyInfo { get { return m_BuyInfo; } } 

		public class InternalBuyInfo : List<GenericBuyInfo> 
		{ 
			public InternalBuyInfo() 
			{
				Add( new GenericBuyInfo( typeof( SwampBoots ), 50, 200, 0x1711, Utility.RandomNeutralHue() ) ); 

				Add( new GenericBuyInfo( typeof( Boots ), 8, 20, 0x170b, Utility.RandomNeutralHue() ) );
				Add( new GenericBuyInfo( typeof( HeavyBoots ), 30, 10, 15864, Utility.RandomNeutralHue() ) );
				Add( new GenericBuyInfo( typeof( HighBoots ), 23, 15, 15865, Utility.RandomNeutralHue() ) );
				Add( new GenericBuyInfo( typeof( LightBoots ), 12, 15, 15867, Utility.RandomNeutralHue() ) );
				Add( new GenericBuyInfo( typeof( Sandals ), 5, 20, 0x170d, Utility.RandomNeutralHue() ) ); 
				Add( new GenericBuyInfo( typeof( Shoes ), 11, 20, 0x170f, Utility.RandomNeutralHue() ) ); 
				Add( new GenericBuyInfo( typeof( ShortBoots ), 14, 15, 15870, Utility.RandomNeutralHue() ) );
				Add( new GenericBuyInfo( typeof( ThighBoots ), 15, 20, 0x1711, Utility.RandomNeutralHue() ) ); 
			} 
		} 

		public class InternalSellInfo : GenericSellInfo 
		{ 
			public InternalSellInfo() 
			{ 
				Add( typeof( Boots ), 5 ); 
				Add( typeof( Sandals ), 5 ); 
				Add( typeof( Shoes ), 5 ); 
				Add( typeof( ThighBoots ), 5 ); 
			} 
		} 
	} 

   public class SkaddriaCobblerGump : Gump 
   { 
      public static void Initialize() 
      { 
         CommandSystem.Register( "SkaddriaCobblerGump", AccessLevel.GameMaster, new CommandEventHandler( SkaddriaCobblerGump_OnCommand ) ); 
      } 

      private static void SkaddriaCobblerGump_OnCommand( CommandEventArgs e ) 
      { 
         e.Mobile.SendGump( new SkaddriaCobblerGump( e.Mobile ) ); 
      } 

      public SkaddriaCobblerGump( Mobile owner ) : base( 50,50 ) 
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
"<BASEFONT COLOR=YELLOW>Oh hello there pal. All I do is sell<BR>" +
"<BASEFONT COLOR=YELLOW>boots and shoes. That's right, boots <BR>" +
"<BASEFONT COLOR=YELLOW>and shoes. Nothing but boots and shoes.<BR>" +
"<BASEFONT COLOR=YELLOW><BR>" +
"<BASEFONT COLOR=YELLOW>Fuck me, my profession sucks.<BR>" +
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
