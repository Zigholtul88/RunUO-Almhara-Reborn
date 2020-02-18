using System;
using System.Collections;
using System.Collections.Generic;
using Server;
using Server.ContextMenus;
using Server.Engines.Craft;
using Server.Gumps;
using Server.Items;
using Server.Misc;
using Server.Mobiles;
using Server.Network;
using Server.Spells;
using Server.Targeting;

namespace Server.Mobiles 
{ 
	public class RedDaggerKeepRancher : BaseVendor 
	{ 
		private List<SBInfo> m_SBInfos = new List<SBInfo>(); 
		protected override List<SBInfo> SBInfos{ get { return m_SBInfos; } } 

		public override bool InitialInnocent{ get{ return true; } }
		public override bool CanTeach { get { return true; } }

		[Constructable]
		public RedDaggerKeepRancher() : base( "the rancher" ) 
		{ 
		} 

		public override void InitSBInfo() 
		{ 
			m_SBInfos.Add( new SBRedDaggerKeepRancher() ); 
		}

		public override void InitOutfit()
		{
			SetStr( 117 );
			SetDex( 96 );
			SetInt( 54 );

			SetSkill( SkillName.AnimalLore, 55.0, 78.0 );
			SetSkill( SkillName.AnimalTaming, 55.0, 78.0 );
			SetSkill( SkillName.Herding, 64.0, 100.0 );
			SetSkill( SkillName.Veterinary, 60.0, 83.0 );

			PackGold( 23, 35 );

			AddItem( new StrawHat(2405) );

			if ( this.Female = Utility.RandomBool() ) 
			{ 
				this.Body = 606;
				this.Name = NameList.RandomName( "elven female" );
			        this.Hue = Utility.RandomList( 1002,1003,1009,1010,1011,1016,1017,1023,1030 );

                                this.HairHue = Utility.RandomList( 1502,1507,1513,2213,2216,2218 );
                                this.HairItemID = Utility.RandomList( 12224,12225,12236,12237,12238,12239 );

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

		public RedDaggerKeepRancher( Serial serial ) : base( serial ) 
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

	public class SBRedDaggerKeepRancher : SBInfo 
	{ 
		private List<GenericBuyInfo> m_BuyInfo = new InternalBuyInfo(); 
		private IShopSellInfo m_SellInfo = new InternalSellInfo(); 

		public SBRedDaggerKeepRancher() 
		{ 
		} 

		public override IShopSellInfo SellInfo { get { return m_SellInfo; } } 
		public override List<GenericBuyInfo> BuyInfo { get { return m_BuyInfo; } } 

		public class InternalBuyInfo : List<GenericBuyInfo> 
		{ 
			public InternalBuyInfo() 
			{ 	
				Add( new GenericBuyInfo( typeof( Pitchfork ), 10, 20, 0xE87, 0 ) );

				Add( new GenericBuyInfo( typeof( Eggs ), 6, 87, 0x9B5, 0 ) );

				Add( new BeverageBuyInfo( typeof( Pitcher ), BeverageType.Milk, 14, 106, 0x9AD, 0 ) );
				Add( new GenericBuyInfo( typeof( SheafOfHay ), 4, 100, 0xF36, 0 ) );

				Add( new GenericBuyInfo( typeof( Apple ), 7, 69, 0x9D0, 0 ) );
				Add( new GenericBuyInfo( typeof( Apricot ), 8, 69, 0x9D2, 0x31 ) );
				Add( new GenericBuyInfo( typeof( Blackberry ), 5, 78, 0x9D1, 0x25A ) );
				Add( new GenericBuyInfo( typeof( Blueberry ), 5, 78, 0x9D1, 0x62 ) );
				Add( new GenericBuyInfo( typeof( Cantaloupe ), 12, 120, 0xC79, 0 ) );
				Add( new GenericBuyInfo( typeof( Cherry ), 5, 78, 0x9D1, 0x85 ) );
				Add( new GenericBuyInfo( typeof( CoffeeBean ), 5, 78, 0xC64, 0x46A ) );
				Add( new GenericBuyInfo( typeof( Cranberry ), 5, 78, 0x9D1, 0xE8 ) );
				Add( new GenericBuyInfo( typeof( Elderberries ), 5, 78, 0x9D1, 0x200 ) );
				Add( new GenericBuyInfo( typeof( Grapefruit ), 12, 78, 0x9D0, 0x15E ) );
				Add( new GenericBuyInfo( typeof( Grapes ), 5, 76, 0x9D1, 0 ) );
				Add( new GenericBuyInfo( typeof( Kiwi ), 11, 78, 0xF8B, 0x458 ) );
				Add( new GenericBuyInfo( typeof( Lemon ), 9, 48, 0x1728, 0 ) );
				Add( new GenericBuyInfo( typeof( Lime ), 7, 26, 0x172A, 0 ) );
				Add( new GenericBuyInfo( typeof( Mango ), 14, 95, 0x9D0, 0x489 ) );
				Add( new GenericBuyInfo( typeof( Orange ), 7, 67, 0x9D0, 48 ) );
				Add( new GenericBuyInfo( typeof( Peach ), 8, 69, 0x9D2, 0 ) );
				Add( new GenericBuyInfo( typeof( Pear ), 6, 77, 0x994, 0 ) );
				Add( new GenericBuyInfo( typeof( Pineapple ), 15, 58, 0xFC4, 0x46E ) );
				Add( new GenericBuyInfo( typeof( Plum ), 9, 81, 0x9D2, 0x264 ) );
				Add( new GenericBuyInfo( typeof( Pomegranate ), 13, 51, 0x9D0, 0x215 ) );
				Add( new GenericBuyInfo( typeof( Prune ), 8, 95, 0xF2B, 0x205 ) );
				Add( new GenericBuyInfo( typeof( BlackRaspberry ), 8, 72, 0x9D1, 1175 ) );
				Add( new GenericBuyInfo( typeof( RedRaspberry ), 8, 74, 0x9D1, 0x26 ) );
				Add( new GenericBuyInfo( typeof( Squash ), 6, 49, 0xC72, 0 ) );
				Add( new GenericBuyInfo( typeof( Strawberry ), 5, 78, 0xF2A, 0x85 ) );
				Add( new GenericBuyInfo( typeof( Watermelon ), 14, 39, 0xC5C, 0 ) );

				Add( new GenericBuyInfo( typeof( Asparagus ), 9, 78, 0xC77, 0x1D3 ) );
				Add( new GenericBuyInfo( typeof( Avocado ), 10, 78, 0xC80, 0x483 ) );
				Add( new GenericBuyInfo( typeof( Beet ), 10, 55, 0xD39, 0x1B ) );
				Add( new GenericBuyInfo( typeof( Broccoli ), 7, 55, 0xC78, 0x48F ) );
				Add( new GenericBuyInfo( typeof( Cabbage ), 10, 78, 0xC7B, 0 ) );
				Add( new GenericBuyInfo( typeof( Carrot ), 6, 107, 0xC78, 0 ) );
				Add( new GenericBuyInfo( typeof( Cauliflower ), 10, 78, 0xC7B, 0x47E ) );
				Add( new GenericBuyInfo( typeof( Celery ), 6, 107, 0xC77, 0xAA ) );
				Add( new GenericBuyInfo( typeof( ChiliPepper ), 5, 200, 0xC6D, 0x10C ) );
				Add( new GenericBuyInfo( typeof( Cucumber ), 14, 78, 0xC81, 0x2FF ) );
				Add( new GenericBuyInfo( typeof( Eggplant ), 16, 78, 0xD3A, 0x72 ) );
				Add( new GenericBuyInfo( typeof( GreenBean ), 5, 78, 0xF80, 0x483 ) );
				Add( new GenericBuyInfo( typeof( GreenGourd ), 10, 45, 0xC66, 0 ) );
				Add( new GenericBuyInfo( typeof( GreenPepper ), 5, 200, 0xC75, 0x1D3 ) );
				Add( new GenericBuyInfo( typeof( HoneydewMelon ), 14, 111, 0xC74, 0 ) );
				Add( new GenericBuyInfo( typeof( Lettuce ), 10, 55, 0xC70, 0 ) );
				Add( new GenericBuyInfo( typeof( Onion ), 6, 46, 0xC6D, 0 ) );
				Add( new GenericBuyInfo( typeof( OrangePepper ), 5, 200, 0xC75, 0x30 ) );
				Add( new GenericBuyInfo( typeof( Peas ), 2, 500, 0xF2F, 0x42 ) );
				Add( new GenericBuyInfo( typeof( Potato ), 5, 55, 0xC5D, 0x6C0 ) );
				Add( new GenericBuyInfo( typeof( Pumpkin ), 22, 34, 0xC6A, 0 ) );
				Add( new GenericBuyInfo( typeof( Radish ), 8, 45, 0xD39, 0x1B9 ) );
				Add( new GenericBuyInfo( typeof( RedPepper ), 5, 200, 0xC75, 0xE9 ) );
				Add( new GenericBuyInfo( typeof( SnowPeas ), 2, 500, 0xF2F, 0x29A ) );
				Add( new GenericBuyInfo( typeof( Soybean ), 5, 78, 0x1EBD, 0x292 ) );
				Add( new GenericBuyInfo( typeof( Spinach ), 6, 46, 0xD09, 0x29D ) );
				Add( new GenericBuyInfo( typeof( SweetPotato ), 6, 55, 0xC64, 0x45E ) );
				Add( new GenericBuyInfo( typeof( TanGinger ), 5, 200, 0xF85, 0x413 ) );
				Add( new GenericBuyInfo( typeof( TeaLeaves ), 5, 200, 0x1AA2, 0x44 ) );
				Add( new GenericBuyInfo( typeof( Tomato ), 6, 46, 0x9D0, 0x8F ) );
				Add( new GenericBuyInfo( typeof( Turnip ), 6, 69, 0xD3A, 0 ) );
				Add( new GenericBuyInfo( typeof( YellowGourd ), 6, 54, 0xC64, 0 ) );
				Add( new GenericBuyInfo( typeof( YellowPepper ), 5, 200, 0xC75, 0x000 ) );
			}
		}

		public class InternalSellInfo : GenericSellInfo
		{
			public InternalSellInfo()
			{
			} 
		} 
	} 
}
