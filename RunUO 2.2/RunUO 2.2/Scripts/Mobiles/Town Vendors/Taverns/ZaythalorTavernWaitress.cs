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
	public class ZaythalorTavernWaitress : BaseVendor
	{
		private List<SBInfo> m_SBInfos = new List<SBInfo>();
		protected override List<SBInfo> SBInfos{ get { return m_SBInfos; } }

		public override bool InitialInnocent{ get{ return true; } }
		public override bool CanTeach { get { return true; } }

		[Constructable]
		public ZaythalorTavernWaitress() : base( "the waitress" )
		{
		}

		public override void InitSBInfo()
		{
			m_SBInfos.Add( new SBZaythalorTavernWaitress() );
		}

		public override void InitOutfit()
		{
			SetStr( 154 );
			SetDex( 148 );
			SetInt( 125 );

			SetSkill( SkillName.Alchemy, 85.0, 100.0 );
			SetSkill( SkillName.Anatomy, 60.0, 183.0 );
			SetSkill( SkillName.AnimalLore, 64.0, 100.0 );
			SetSkill( SkillName.AnimalTaming, 90.0, 100.0 );
			SetSkill( SkillName.Cooking, 90.0, 100.0 );
			SetSkill( SkillName.Discordance, 36.0, 68.0 );
			SetSkill( SkillName.Hiding, 60.0, 183.0 );
			SetSkill( SkillName.TasteID, 65.0, 88.0 );
			SetSkill( SkillName.Veterinary, 65.0, 88.0 );
			SetSkill( SkillName.Wrestling, 60.0, 83.0 );

			PackGold( 22, 67 );

			Body = 606;
			Name = NameList.RandomName( "elven female" );
			Hue = Utility.RandomList( 897,898,899,2405 );
                        HairHue = 1153;
                        HairItemID = Utility.RandomList( 12224,12225,12236,12237,12238,12239 );

			switch ( Utility.Random( 18 ) )
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
				case 17: AddItem( new MoonElfPlainDress( Utility.RandomNeutralHue() ) ); break;
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

		public ZaythalorTavernWaitress( Serial serial ) : base( serial )
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

	public class SBZaythalorTavernWaitress : SBInfo
	{
		private List<GenericBuyInfo> m_BuyInfo = new InternalBuyInfo();
		private IShopSellInfo m_SellInfo = new InternalSellInfo();

		public SBZaythalorTavernWaitress()
		{
		}

		public override IShopSellInfo SellInfo { get { return m_SellInfo; } }
		public override List<GenericBuyInfo> BuyInfo { get { return m_BuyInfo; } }

		public class InternalBuyInfo : List<GenericBuyInfo>
		{
			public InternalBuyInfo()
			{
				Add( new BeverageBuyInfo( typeof( BeverageBottle ), BeverageType.Ale, 14, 50, 0x99F, 0 ) );
				Add( new BeverageBuyInfo( typeof( BeverageBottle ), BeverageType.Wine, 14, 46, 0x9C7, 0 ) );
				Add( new BeverageBuyInfo( typeof( BeverageBottle ), BeverageType.Liquor, 14, 37, 0x99B, 0 ) );
				Add( new BeverageBuyInfo( typeof( Jug ), BeverageType.Cider, 26, 86, 0x9C8, 0 ) );
				Add( new BeverageBuyInfo( typeof( Pitcher ), BeverageType.Milk, 14, 50, 0x9F0, 0 ) );
				Add( new BeverageBuyInfo( typeof( Pitcher ), BeverageType.Ale, 22, 45, 0x1F95, 0 ) );
				Add( new BeverageBuyInfo( typeof( Pitcher ), BeverageType.Cider, 22, 75, 0x1F97, 0 ) );
				Add( new BeverageBuyInfo( typeof( Pitcher ), BeverageType.Liquor, 22, 61, 0x1F99, 0 ) );
				Add( new BeverageBuyInfo( typeof( Pitcher ), BeverageType.Wine, 22, 39, 0x1F9B, 0 ) );
				Add( new BeverageBuyInfo( typeof( Pitcher ), BeverageType.Water, 22, 82, 0x1F9D, 0 ) );

				Add( new GenericBuyInfo( "Black Panther Tonic", typeof( BlackPantherTonic ), 30, 99, 0x99F, 1904 ) );
				Add( new GenericBuyInfo( "Bum Light", typeof( BumLight ), 22, 99, 0x99F, 2119 ) );
				Add( new GenericBuyInfo( "Crabtree's Cabin Lager", typeof( CrabtreesCabinLager ), 35, 99, 0x99F, 1515 ) );
				Add( new GenericBuyInfo( "Dos Llamas", typeof( DosLlamas ), 26, 99, 0x99F, 45 ) );
				Add( new GenericBuyInfo( "Irish Spirit", typeof( IrishSpirit ), 28, 99, 0x99F, 1368 ) );
				Add( new GenericBuyInfo( "Montoya Rock", typeof( MontoyaRock ), 30, 99, 0x99F, 1861 ) );

				Add( new GenericBuyInfo( typeof( Meatballs ), 15, 235, 0xE74, 0x475 ) );
				Add( new GenericBuyInfo( typeof( Meatloaf ), 28, 114, 0xE79, 0x475 ) );
				Add( new GenericBuyInfo( typeof( PotatoStrings ), 12, 125, 0x1B8D, 0x225 ) );
				Add( new GenericBuyInfo( typeof( Pancakes ), 20, 105, 0x1E1F, 0x22A ) );
				Add( new GenericBuyInfo( typeof( Waffles ), 18, 105, 0x1E1F, 0x1C7 ) );
				Add( new GenericBuyInfo( typeof( GrilledHam ), 23, 123, 0x1E1F, 0x33D ) );
				Add( new GenericBuyInfo( typeof( Hotwings ), 17, 234, 0x1608, 0x21A ) );
				Add( new GenericBuyInfo( typeof( Taco ), 15, 562, 0x1370, 0x465 ) );
				Add( new GenericBuyInfo( typeof( CornOnCob ), 16, 376, 0xC81, 0x0 ) );
				Add( new GenericBuyInfo( typeof( Hotdog ), 16, 376, 0xC7F, 0x457 ) );

				Add( new GenericBuyInfo( typeof( BreadLoaf ), 12, 56, 0x103B, 0 ) );
				Add( new GenericBuyInfo( typeof( CheeseWheel ), 42, 72, 0x97E, 0 ) );

				Add( new GenericBuyInfo( typeof( FriedChickenEggs ), 15, 500, 0x9B6, 0 ) );
				Add( new GenericBuyInfo( typeof( FriedDuckEggs ), 15, 500, 0x9B6, 0 ) );
				Add( new GenericBuyInfo( typeof( FriedEggs ), 15, 500, 0x9B6, 0 ) );

				Add( new GenericBuyInfo( typeof( ChickenLeg ), 5, 200, 0x1608, 0 ) );
				Add( new GenericBuyInfo( typeof( CookedBird ), 17, 200, 0x9B7, 0 ) );
				Add( new GenericBuyInfo( typeof( DuckLeg ), 7, 200, 0x1608, 0 ) );
				Add( new GenericBuyInfo( typeof( LambLeg ), 8, 200, 0x160A, 0 ) );
				Add( new GenericBuyInfo( typeof( RoastChicken ), 98, 200, 0x9B7, 0 ) );
				Add( new GenericBuyInfo( typeof( RoastDuck ), 103, 200, 0x9B7, 0 ) );
				Add( new GenericBuyInfo( typeof( RoastPig ), 106, 200, 0x9BB, 0 ) );
				Add( new GenericBuyInfo( typeof( RoastTurkey ), 225, 200, 0x9B7, 0 ) );
				Add( new GenericBuyInfo( typeof( SlicedTurkey ), 13, 200, 0x1E1F, 0 ) );

				Add( new GenericBuyInfo( typeof( TurkeyPlatter ), 247, 200, 0x4988, 0 ) );
				Add( new GenericBuyInfo( typeof( TurkeyLeg ), 28, 200, 0x1607, 0 ) );

				Add( new GenericBuyInfo( typeof( AsianVegMix ), 20, 100, 0x15FB, 0 ) );
				Add( new GenericBuyInfo( typeof( BowlCornFlakes ), 20, 100, 0x15FA, 0 ) );
				Add( new GenericBuyInfo( typeof( BowlRiceKrisps ), 20, 100, 0x1602, 0 ) );
				Add( new GenericBuyInfo( typeof( CheeseSauce ), 20, 100, 0x15FA, 0 ) );
				Add( new GenericBuyInfo( typeof( ChocIceCream ), 20, 100, 0x15FA, 0 ) );
				Add( new GenericBuyInfo( typeof( Gravy ), 20, 100, 0x15FD, 1012 ) );
				Add( new GenericBuyInfo( typeof( MixedVegetables ), 20, 100, 0x15FB, 0 ) );
				Add( new GenericBuyInfo( typeof( BroccoliCheese ), 20, 100, 0x15FC, 0 ) );
				Add( new GenericBuyInfo( typeof( BroccoliCaulCheese ), 20, 100, 0x15FB, 0 ) );
				Add( new GenericBuyInfo( typeof( ChickenNoodleSoup ), 20, 100, 0x15FA, 0 ) );
				Add( new GenericBuyInfo( typeof( BowlBeets ), 20, 100, 0x15F9, 0 ) );
				Add( new GenericBuyInfo( typeof( BowlBroccoli ), 20, 100, 0x15FB, 0 ) );
				Add( new GenericBuyInfo( typeof( BowlCauliflower ), 20, 100, 0x15FA, 0 ) );
				Add( new GenericBuyInfo( typeof( BowlGreenBeans ), 20, 100, 0x15FC, 0 ) );
				Add( new GenericBuyInfo( typeof( BowlSpinach ), 20, 100, 0x15FC, 0 ) );
				Add( new GenericBuyInfo( typeof( BowlTurnips ), 20, 100, 0x15F9, 0 ) );
				Add( new GenericBuyInfo( typeof( BowlMashedPotatos ), 20, 100, 0x15FB, 0 ) );
				Add( new GenericBuyInfo( typeof( MacaroniCheese ), 20, 100, 0x15FF, 0 ) );
				Add( new GenericBuyInfo( typeof( CauliflowerCheese ), 20, 100, 0x1602, 0 ) );
				Add( new GenericBuyInfo( typeof( PotatoFries ), 15, 100, 0x160C, 0 ) );
				Add( new GenericBuyInfo( typeof( BowlOatmeal ), 20, 100, 0x1602, 0 ) );
				Add( new GenericBuyInfo( typeof( TomatoRice ), 20, 100, 0x1606, 0 ) );
				Add( new GenericBuyInfo( typeof( Popcorn ), 20, 100, 0x1602, 0 ) );

				Add( new GenericBuyInfo( typeof( BowlRice ), 20, 200, 0x15FB, 0 ) );
				Add( new GenericBuyInfo( typeof( BowlCookedVeggies ), 20, 200, 0x15FB, 0 ) );
				Add( new GenericBuyInfo( typeof( WoodenBowlOfCarrots ), 20, 200, 0x15F9, 0 ) );
				Add( new GenericBuyInfo( typeof( WoodenBowlOfCorn ), 20, 200, 0x15FA, 0 ) );
				Add( new GenericBuyInfo( typeof( WoodenBowlOfLettuce ), 20, 200, 0x15FB, 0 ) );
				Add( new GenericBuyInfo( typeof( WoodenBowlOfPeas ), 20, 200, 0x15FC, 0 ) );
				Add( new GenericBuyInfo( typeof( EmptyPewterBowl ), 5, 500, 0x15FD, 0 ) );

				Add( new GenericBuyInfo( typeof( PewterBowlOfCorn ), 20, 200, 0x15FE, 0 ) );
				Add( new GenericBuyInfo( typeof( PewterBowlOfLettuce ), 20, 200, 0x15FF, 0 ) );
				Add( new GenericBuyInfo( typeof( PewterBowlOfPeas ), 20, 200, 0x1600, 0 ) );
				Add( new GenericBuyInfo( typeof( PewterBowlOfPotatos ), 20, 200, 0x1601, 0 ) );
				Add( new GenericBuyInfo( typeof( BowlOfStew ), 20, 200, 0x1604, 0 ) );
				Add( new GenericBuyInfo( typeof( WoodenBowlOfStew ), 20, 200, 0x1604, 0 ) );
				Add( new GenericBuyInfo( typeof( WoodenBowlOfTomatoSoup ), 200, 20, 0x1606, 0 ) );

				Add( new GenericBuyInfo( typeof( ApplePie ), 28, 20, 0x1041, 0 ) ); //OSI just has Pie, not Apple/Fruit/Meat
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
