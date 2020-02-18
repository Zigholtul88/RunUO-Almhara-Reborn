using System; 
using System.Collections.Generic; 
using Server.Items; 
using Server.ACC.CSS.Systems.Bard;
using Server.ACC.CSS.Systems.Druid;

namespace Server.Mobiles 
{ 
	public class SBVarietyDealer : SBInfo
	{
		private List<GenericBuyInfo> m_BuyInfo = new InternalBuyInfo();
		private IShopSellInfo m_SellInfo = new InternalSellInfo();

		public SBVarietyDealer()
		{
		}

		public override IShopSellInfo SellInfo { get { return m_SellInfo; } }
		public override List<GenericBuyInfo> BuyInfo { get { return m_BuyInfo; } }

		public class InternalBuyInfo : List<GenericBuyInfo>
		{
			public InternalBuyInfo()
			{
////////////////////////////////////////////////////// Tools
// All tools sell at a base price of 100 gp
				Add( new GenericBuyInfo( typeof( ElvenQuiver ), 100, 20, 0x2FB7, 0 ) );
				Add( new GenericBuyInfo( typeof( FletcherTools ), 100, 378, 0x1022, 0 ) );
				Add( new GenericBuyInfo( typeof( HeatingStand ), 100, 100, 0x1849, 0 ) ); 
				Add( new GenericBuyInfo( typeof( JuicersTools ), 100, 20, 0xE4F, 0 ) );
				Add( new GenericBuyInfo( typeof( MortarPestle ), 100, 100, 0xE9B, 0 ) );
		                Add( new GenericBuyInfo( typeof( Scissors ), 100, 40, 0xF9F, 0 ) );
				Add( new GenericBuyInfo( typeof( SewingKit ), 100, 500, 0xF9D, 0 ) );
				Add( new GenericBuyInfo( typeof( SmithHammer ), 100, 999, 0x13E3, 0 ) );
				Add( new GenericBuyInfo( typeof( Tongs ), 100, 999, 0xFBB, 0 ) ); 

////////////////////////////////////////////////////// Primary Components
				Add( new GenericBuyInfo( "Board", typeof( Board ), 5, 999, 0x1BD7, 0 ) );
				Add( new GenericBuyInfo( "Iron Ingot", typeof( IronIngot ), 5, 999, 0x1BF2, 0 ) );
				Add( new GenericBuyInfo( "Leather", typeof( Leather ), 5, 999, 0x1081, 0 ) );
				Add( new GenericBuyInfo( "Log", typeof( Log ), 5, 999, 0x1BDD, 0 ) );

				Add( new GenericBuyInfo( typeof( Cotton ), 5, 999, 0xDF9, 0 ) );
				Add( new GenericBuyInfo( "Dark Yarn", typeof( DarkYarn ), 5, 999, 0xE1D, 0 ) );
				Add( new GenericBuyInfo( "Light Yarn", typeof( LightYarn ), 5, 999, 0xE1E, 0 ) );

				Add( new GenericBuyInfo( typeof( Flax ), 5, 999, 0x1A9C, 0 ) );
				Add( new GenericBuyInfo( typeof( SpoolOfThread ), 5, 999, 0xFA0, 0 ) );
				Add( new GenericBuyInfo( typeof( Wool ), 5, 999, 0xDF8, 0 ) );

////////////////////////////////////////////////////// Secondary Components
				Add( new GenericBuyInfo( "Copper Wire", typeof( CopperWire ), 1, 999, 0x1879, 0 ) );
				Add( new GenericBuyInfo( "Feather", typeof( Feather ), 1, 999, 0x1BD1, 0 ) );
				Add( new GenericBuyInfo( "Gears", typeof( Gears ), 1, 999, 0x1053, 0 ) );
				Add( new GenericBuyInfo( "Gold Wire", typeof( GoldWire ), 1, 999, 0x1878, 0 ) );
				Add( new GenericBuyInfo( "Iron Wire", typeof( IronWire ), 1, 999, 0x1876, 0 ) );
				Add( new GenericBuyInfo( "Shaft", typeof( Shaft ), 1, 999, 0x1BD4, 0 ) );
				Add( new GenericBuyInfo( "Silver Wire", typeof( SilverWire ), 1, 999, 0x1877, 0 ) );
				Add( new GenericBuyInfo( "Spool of Thread", typeof( SpoolOfThread ), 1, 999, 0xFA0, 0 ) );
				Add( new GenericBuyInfo( "Springs", typeof( Springs ), 1, 999, 0x105D, 0 ) );

////////////////////////////////////////////////////// Bard Items
				Add( new GenericBuyInfo( "Bard Spellbook", typeof( BardSpellbook ), 800, 10, 0xEFA, 0x96 ) );

				Add( new GenericBuyInfo( "Energy Carol Scroll", typeof( BardEnergyCarolScroll ), 200, 244, 0x14ED, 0x96 ) );
				Add( new GenericBuyInfo( "Fire Carol Scroll", typeof( BardFireCarolScroll ), 200, 368, 0x14ED, 0x96 ) );
				Add( new GenericBuyInfo( "Ice Carol Scroll", typeof( BardIceCarolScroll ), 200, 368, 0x14ED, 0x96 ) );
				Add( new GenericBuyInfo( "Poison Carol Scroll", typeof( BardPoisonCarolScroll ), 200, 251, 0x14ED, 0x96 ) );

				Add( new GenericBuyInfo( typeof( Drums ), 500, ( 20 ), 0x0E9C, 0 ) ); 
				Add( new GenericBuyInfo( typeof( Tambourine ), 500, ( 20 ), 0x0E9E, 0 ) ); 
				Add( new GenericBuyInfo( typeof( LapHarp ), 500, ( 20 ), 0x0EB2, 0 ) ); 
				Add( new GenericBuyInfo( typeof( Lute ), 500, ( 20 ), 0x0EB3, 0 ) ); 

////////////////////////////////////////////////////// Ammunition
				Add( new GenericBuyInfo( typeof( Arrow ), 5, Utility.Random( 80, 100 ), 0xF3F, 0 ) );
				Add( new GenericBuyInfo( typeof( OakArrow ), 10, Utility.Random( 50, 80 ), 0xF3F, 2010 ) );
				Add( new GenericBuyInfo( typeof( YewArrow ), 15, Utility.Random( 50, 80 ), 0xF3F, 1192 ) );
				Add( new GenericBuyInfo( typeof( AshArrow ), 20, Utility.Random( 50, 80 ), 0xF3F, 1191 ) );

				Add( new GenericBuyInfo( typeof( Bolt ), 5, Utility.Random( 80, 100 ), 0x1BFB, 0 ) );
				Add( new GenericBuyInfo( typeof( DullCopperBolt ), 10, Utility.Random( 50, 100 ), 0x1BFB, 2419 ) );
				Add( new GenericBuyInfo( typeof( ShadowIronBolt ), 15, Utility.Random( 50, 100 ), 0x1BFB, 2406 ) );
				Add( new GenericBuyInfo( typeof( BronzeBolt ), 20, Utility.Random( 50, 100 ), 0x1BFB, 2418 ) );

////////////////////////////////////////////////////// Potions
				Add( new GenericBuyInfo( "Your Trusty Potion Guide", typeof( YourTrustyPotionGuide ), 50, 100, 0xFBD, 0 ) );

				Add( new GenericBuyInfo( typeof( AgilityPotion ), 200, 100, 0xF08, 0 ) );
				Add( new GenericBuyInfo( "Teal Potion", typeof( MindPotion ), 200, 100, 0xF04, 1173 ) );
				Add( new GenericBuyInfo( typeof( StrengthPotion ), 200, 100, 0xF09, 0 ) );

				Add( new GenericBuyInfo( typeof( LesserHealPotion ), 200, 100, 0xF0C, 0 ) );
				Add( new GenericBuyInfo( "Lesser Sky Blue Potion", typeof( LesserManaPotion ), 300, 100, 0xF03, 1266 ) );

 				Add( new GenericBuyInfo( typeof( LesserCurePotion ), 200, 100, 0xF07, 0 ) );

				Add( new GenericBuyInfo( typeof( LesserExplosionPotion ), 200, 100, 0xF0D, 0 ) );
				Add( new GenericBuyInfo( "Lesser Ice Blue Potion", typeof( LesserShatterPotion ), 200, 100, 0xF0D, 1152 ) );
				Add( new GenericBuyInfo( "Lesser Magenta Potion", typeof( LesserLightningPotion ), 200, 100, 0xF0D, 23 ) );
				Add( new GenericBuyInfo( typeof( LesserPoisonPotion ), 200, 100, 0xF0A, 0 ) );

				Add( new GenericBuyInfo( typeof( NightSightPotion ), 200, 100, 0xF06, 0 ) );
				Add( new GenericBuyInfo( typeof( RefreshPotion ), 200, 100, 0xF0B, 0 ) );

////////////////////////////////////////////////////// Reagents
				Add( new GenericBuyInfo( typeof( BlackPearl ), 5, 999, 0xF7A, 0 ) ); 
				Add( new GenericBuyInfo( typeof( Bloodmoss ), 5, 999, 0xF7B, 0 ) ); 
				Add( new GenericBuyInfo( typeof( MandrakeRoot ), 3, 999, 0xF86, 0 ) ); 
				Add( new GenericBuyInfo( typeof( Garlic ), 3, 999, 0xF84, 0 ) ); 
				Add( new GenericBuyInfo( typeof( Ginseng ), 3, 999, 0xF85, 0 ) ); 
				Add( new GenericBuyInfo( typeof( Nightshade ), 3, 999, 0xF88, 0 ) ); 
				Add( new GenericBuyInfo( typeof( SpidersSilk ), 3, 999, 0xF8D, 0 ) ); 
				Add( new GenericBuyInfo( typeof( SulfurousAsh ), 3, 999, 0xF8C, 0 ) ); 

				Add( new GenericBuyInfo( typeof( BatWing ), 8, 999, 0xF78, 0 ) );
				Add( new GenericBuyInfo( typeof( DaemonBlood ), 8, 999, 0xF7D, 0 ) );
				Add( new GenericBuyInfo( typeof( GraveDust ), 8, 999, 0xF8F, 0 ) );
				Add( new GenericBuyInfo( typeof( NoxCrystal ), 8, 999, 0xF8E, 0 ) );
				Add( new GenericBuyInfo( typeof( PigIron ), 8, 999, 0xF8A, 0 ) );

				Add( new GenericBuyInfo( "Destroying Angel", typeof( DestroyingAngel ), 8, 999, 0xE1F, 0x290 ) );
				Add( new GenericBuyInfo( "Petrafied Wood", typeof( PetrafiedWood ), 8, 999, 0x97A, 0x46C ) );
				Add( new GenericBuyInfo( "Spring Water", typeof( SpringWater ), 8, 999, 0xE24, 0x47F ) );

////////////////////////////////////////////////////// Scrolls
				Add( new GenericBuyInfo( typeof( BlankScroll ), 5, 999, 0x0E34, 0 ) );

				Type[] types = Loot.RegularScrollTypes;

				int circles = 3;

				for ( int i = 0; i < circles*8 && i < types.Length; ++i )
				{
					int itemID = 0x1F2E + i;

					if ( i == 6 )
						itemID = 0x1F2D;
					else if ( i > 6 )
						--itemID;

					Add( new GenericBuyInfo( types[i], 12 + ((i / 8) * 10), 20, itemID, 0 ) );
				}

////////////////////////////////////////////////////// Misc
				Add( new GenericBuyInfo( typeof( Backpack ), 25, 50, 0x9B2, 0 ) );
				Add( new GenericBuyInfo( typeof( Bandage ), 5, 999, 0xE21, 0 ) );
				Add( new GenericBuyInfo( typeof( BookOfZooTravel ), 1000, 50, 17080, 0 ) );
				Add( new GenericBuyInfo( typeof( EmptyJuiceBottle ), 20, 999, 0x99B, 0 ) );
				Add( new GenericBuyInfo( typeof( RecallRune ), 100, 999, 0x1f14, 0 ) );
				Add( new GenericBuyInfo( typeof( Spellbook ), 100, 55, 0xEFA, 0 ) );
				Add( new GenericBuyInfo( typeof( NecromancerSpellbook ), 115, 67, 0x2253, 0 ) );

				Add( new GenericBuyInfo( "1041072", typeof( MagicWizardsHat ), 11, 10, 0x1718, 0 ) );

////////////////////////////////////////////////////// Drinks
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

////////////////////////////////////////////////////// Food
				Add( new GenericBuyInfo( typeof( BreadLoaf ), 12, 56, 0x103B, 0 ) );
				Add( new GenericBuyInfo( typeof( CheeseWheel ), 42, 72, 0x97E, 0 ) );
				Add( new GenericBuyInfo( typeof( CookedBird ), 36, 44, 0x9B7, 0 ) );
				Add( new GenericBuyInfo( typeof( LambLeg ), 16, 65, 0x160A, 0 ) );
				Add( new GenericBuyInfo( typeof( ChickenLeg ), 10, 65, 0x1608, 0 ) );
				Add( new GenericBuyInfo( typeof( Ribs ), 14, 70, 0x9F2, 0 ) );

				Add( new GenericBuyInfo( typeof( WoodenBowlOfCarrots ), 25, 100, 0x15F9, 0 ) );
				Add( new GenericBuyInfo( typeof( WoodenBowlOfCorn ), 28, 100, 0x15FA, 0 ) );
				Add( new GenericBuyInfo( typeof( WoodenBowlOfLettuce ), 26, 100, 0x15FB, 0 ) );
				Add( new GenericBuyInfo( typeof( WoodenBowlOfPeas ), 23, 100, 0x15FC, 0 ) );
				Add( new GenericBuyInfo( typeof( EmptyPewterBowl ), 15, 100, 0x15FD, 0 ) );
				Add( new GenericBuyInfo( typeof( PewterBowlOfCorn ), 28, 100, 0x15FE, 0 ) );
				Add( new GenericBuyInfo( typeof( PewterBowlOfLettuce ), 26, 100, 0x15FF, 0 ) );
				Add( new GenericBuyInfo( typeof( PewterBowlOfPeas ), 23, 100, 0x1600, 0 ) );
				Add( new GenericBuyInfo( typeof( PewterBowlOfPotatos ), 25, 100, 0x1601, 0 ) );
				Add( new GenericBuyInfo( typeof( WoodenBowlOfStew ), 27, 100, 0x1604, 0 ) );
				Add( new GenericBuyInfo( typeof( WoodenBowlOfTomatoSoup ), 32, 100, 0x1606, 0 ) );

				Add( new GenericBuyInfo( typeof( ApplePie ), 28, 20, 0x1041, 0 ) ); //OSI just has Pie, not Apple/Fruit/Meat
			}
		}

		public class InternalSellInfo : GenericSellInfo
		{
			public InternalSellInfo()
			{
				Add( typeof( Bandage ), 1 );

				Add( typeof( BlankScroll ), 3 );

				Add( typeof( NightSightPotion ), 7 );
				Add( typeof( AgilityPotion ), 7 );
				Add( typeof( StrengthPotion ), 7 );
				Add( typeof( RefreshPotion ), 7 );
				Add( typeof( LesserCurePotion ), 7 );
				Add( typeof( LesserHealPotion ), 7 );
				Add( typeof( LesserPoisonPotion ), 7 );
				Add( typeof( LesserExplosionPotion ), 10 );

				Add( typeof( Bolt ), 3 );
				Add( typeof( Arrow ), 2 );

				Add( typeof( BlackPearl ), 3 );
				Add( typeof( Bloodmoss ), 3 );
				Add( typeof( MandrakeRoot ), 2 );
				Add( typeof( Garlic ), 2 );
				Add( typeof( Ginseng ), 2 );
				Add( typeof( Nightshade ), 2 );
				Add( typeof( SpidersSilk ), 2 );
				Add( typeof( SulfurousAsh ), 2 );

				Add( typeof( BreadLoaf ), 3 );
				Add( typeof( Backpack ), 7 );
				Add( typeof( RecallRune ), 8 );
				Add( typeof( Spellbook ), 9 );
				Add( typeof( BlankScroll ), 3 );

				if ( Core.AOS )
				{
					Add( typeof( BatWing ), 2 );
					Add( typeof( GraveDust ), 2 );
					Add( typeof( DaemonBlood ), 3 );
					Add( typeof( NoxCrystal ), 3 );
					Add( typeof( PigIron ), 3 );
				}

				Type[] types = Loot.RegularScrollTypes;

				for ( int i = 0; i < types.Length; ++i )
					Add( types[i], ((i / 8) + 2) * 5 );
			}
		}
	}
}