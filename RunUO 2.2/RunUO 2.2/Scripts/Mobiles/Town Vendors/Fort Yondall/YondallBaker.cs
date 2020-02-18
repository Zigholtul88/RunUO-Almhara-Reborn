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
	public class YondallBaker : BaseVendor 
	{ 
		private List<SBInfo> m_SBInfos = new List<SBInfo>(); 
		protected override List<SBInfo> SBInfos{ get { return m_SBInfos; } } 

		public override bool InitialInnocent{ get{ return true; } }
		public override bool CanTeach { get { return true; } }

		[Constructable]
		public YondallBaker() : base( "the baker" ) 
		{ 
		} 

		public override void InitSBInfo() 
		{ 
			m_SBInfos.Add( new SBYondallBaker() ); 
		}

		public override void InitOutfit()
		{
			SetStr( 117 );
			SetDex( 96 );
			SetInt( 54 );

			SetSkill( SkillName.Cooking, 75.0, 98.0 );
			SetSkill( SkillName.TasteID, 36.0, 68.0 );

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

		public YondallBaker( Serial serial ) : base( serial ) 
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

	public class SBYondallBaker : SBInfo 
	{ 
		private List<GenericBuyInfo> m_BuyInfo = new InternalBuyInfo(); 
		private IShopSellInfo m_SellInfo = new InternalSellInfo(); 

		public SBYondallBaker() 
		{ 
		} 

		public override IShopSellInfo SellInfo { get { return m_SellInfo; } } 
		public override List<GenericBuyInfo> BuyInfo { get { return m_BuyInfo; } } 

		public class InternalBuyInfo : List<GenericBuyInfo> 
		{ 
			public InternalBuyInfo() 
			{
				Add( new GenericBuyInfo( typeof( RollingPin ), 10, 100, 0x1043, 0 ) );

                                Add( new GenericBuyInfo( typeof( Batter ), 5, 500, 0xE23, 0x227 ) );
				Add (new GenericBuyInfo( typeof( BowlFlour ), 7, 500, 0xA1E, 0 ) );
				Add (new GenericBuyInfo( typeof( ChocolateMix ), 12, 500, 0xE23, 0x414 ) );
				Add( new GenericBuyInfo( typeof( Dough ), 3, 500, 0x103d, 0 ) );
				Add( new GenericBuyInfo( typeof( SweetDough ), 3, 500, 0x103d, 51 ) );
				Add( new GenericBuyInfo( typeof( JarHoney ), 3, 500, 0x9ec, 0 ) ); 
				Add( new GenericBuyInfo( typeof( PastaNoodles ), 5, 500, 0x1038, 0x100 ) );
				Add( new GenericBuyInfo( typeof( PieMix ), 5, 500, 0x103F, 0x45A ) );
				Add( new GenericBuyInfo( typeof( SackcornFlour ), 5, 500, 0x1039, 0 ) );
				Add( new GenericBuyInfo( typeof( SackFlour ), 3, 500, 0x1039, 0 ) );
				Add( new GenericBuyInfo( typeof( Tofu ), 10, 500, 0x1044, 0x38F ) );
				Add( new GenericBuyInfo( typeof( Tortilla ), 7, 500, 0x973, 0x22C ) );
				Add( new GenericBuyInfo( typeof( WaffleMix ), 3, 500, 0x103F, 0x227 ) );

                                Add( new GenericBuyInfo( typeof( BagOfCocoa ), 10, 500, 0x1045, 1141 ) );
                                Add( new GenericBuyInfo( typeof( BagOfCoffee ), 10, 500, 0x1045, 1130 ) );
                                Add( new GenericBuyInfo( typeof( BagOfCornmeal ), 10, 500, 0x1045, 0x466 ) );
                                Add( new GenericBuyInfo( typeof( BagOfOats ), 10, 500, 0x1045, 0x45E ) );
                                Add( new GenericBuyInfo( typeof( BagOfRicemeal ), 10, 500, 0x1045, 0x303 ) );
                                Add( new GenericBuyInfo( typeof( BagOfSoy ), 10, 500, 0x1045, 0x3D5 ) );
                                Add( new GenericBuyInfo( typeof( BagOfSugar ), 10, 500, 0x1045, 0x430 ) );

                                Add( new GenericBuyInfo( "Butter", typeof( Butter ), 5, 500, 0x1044, 55 ) );
                                Add( new GenericBuyInfo( "Cream", typeof( Cream ), 5, 500, 0x1F8C, 0x0 ) );
                                Add( new GenericBuyInfo( "Milk", typeof( Milk ), 5, 500, 0x1F8C, 0x0 ) );

				Add( new GenericBuyInfo( typeof( CheeseSlice ), 6, 400, 0x97C, 0 ) );
				Add( new GenericBuyInfo( typeof( CheeseWedge ), 18, 400, 0x97D, 0 ) );
				Add( new GenericBuyInfo( typeof( CheeseWedgeSmall ), 12, 400, 0x97C, 0 ) );
				Add( new GenericBuyInfo( typeof( CheeseWheel ), 66, 300, 0x97E, 0 ) );

				Add( new GenericBuyInfo( typeof( Brownies ), 15, 260, 0x160B, 0x47D ) );
             		        Add( new GenericBuyInfo( typeof( Cookies ), 3, 350, 0x160b, 0 ) ); 
             		        Add( new GenericBuyInfo( typeof( Donuts ), 15,485, 0x1AD3, 0 ) );
             		        Add( new GenericBuyInfo( typeof( RiceKrispTreat ), 15,485, 0x1044, 0x9B ) ); 

				Add( new GenericBuyInfo( typeof( BlueberryMuffins ), 5, 62, 0x9EB, 0x1FC ) );
				Add( new GenericBuyInfo( typeof( Muffins ), 3, 62, 0x9EA, 0 ) );
				Add( new GenericBuyInfo( typeof( PumpkinMuffins ), 5, 62, 0x9EB, 0x1C0 ) );

				Add( new GenericBuyInfo( typeof( BreadLoaf ), 6, 78, 0x103B, 0 ) );
				Add( new GenericBuyInfo( typeof( BreadLoaf ), 5, 63, 0x103C, 0 ) );
				Add( new GenericBuyInfo( typeof( CornBread ), 4, 62, 0x103C, 0x1C7 ) );
				Add( new GenericBuyInfo( typeof( FrenchBread ), 5, 48, 0x98C, 0 ) );
				Add( new GenericBuyInfo( typeof( GarlicBread ), 5, 48, 0x98C, 0x1C8 ) );
				Add( new GenericBuyInfo( typeof( PumpkinBread ), 5, 48, 0x103B, 0x1C1 ) );

				Add( new GenericBuyInfo( typeof( BananaCake ), 100, 71, 0x9E9, 354 ) );
				Add( new GenericBuyInfo( typeof( BirthdayCake ), 100, 71, 0x3BBD, 0 ) );
				Add( new GenericBuyInfo( typeof( CantaloupeCake ), 100, 71, 0x9E9, 145 ) );
				Add( new GenericBuyInfo( typeof( CarrotCake ), 100, 71, 0x9E9, 248 ) );
				Add( new GenericBuyInfo( typeof( ChocolateCake ), 100, 71, 0x9E9, 0x45D ) );
				Add( new GenericBuyInfo( typeof( CoconutCake ), 100, 71, 0x9E9, 556 ) );
				Add( new GenericBuyInfo( typeof( FruitCake ), 100, 71, 0x9E9, 0 ) );
				Add( new GenericBuyInfo( typeof( GrapeCake ), 100, 71, 0x9E9, 21 ) );
				Add( new GenericBuyInfo( typeof( HoneydewMelonCake ), 100, 71, 0x9E9, 61 ) );
				Add( new GenericBuyInfo( typeof( KeyLimeCake ), 100, 71, 0x9E9, 71 ) );
				Add( new GenericBuyInfo( typeof( LemonCake ), 100, 71, 0x9E9, 53 ) );
				Add( new GenericBuyInfo( typeof( PeachCake ), 100, 71, 0x9E9, 46 ) );
				Add( new GenericBuyInfo( typeof( PumpkinCake ), 100, 71, 0x9E9, 243 ) );
				Add( new GenericBuyInfo( typeof( WatermelonCake ), 100, 71, 0x9E9, 34 ) );

				Add( new GenericBuyInfo( typeof( SliceOfCake ), 10, 71, 0x3BC5, 0 ) );
				Add( new GenericBuyInfo( typeof( SliceOfWeddingCake ), 15, 71, 0x3BCB, 0 ) );
				Add( new GenericBuyInfo( typeof( WeddingCake ), 150, 71, 0x3BCC, 0 ) );

				Add( new GenericBuyInfo( typeof( ApplePie ), 7, 69, 0x1041, 0 ) ); //OSI just has Pie, not Apple/Fruit/Meat
			} 
		} 

		public class InternalSellInfo : GenericSellInfo 
		{ 
			public InternalSellInfo() 
			{ 
				Add( typeof( BreadLoaf ), 3 ); 
				Add( typeof( FrenchBread ), 1 ); 
				Add( typeof( Cake ), 5 ); 
				Add( typeof( Cookies ), 3 ); 
				Add( typeof( Muffins ), 2 ); 
				Add( typeof( ApplePie ), 5 ); 
				Add( typeof( PeachCobbler ), 5 ); 
				Add( typeof( Quiche ), 6 ); 
				Add( typeof( Dough ), 4 ); 
				Add( typeof( JarHoney ), 1 ); 
				Add( typeof( Pitcher ), 5 );
				Add( typeof( SackFlour ), 1 ); 
				Add( typeof( Eggs ), 1 ); 
				Add( typeof( RollingPin ), 5 );
			} 
		} 
	} 
}
