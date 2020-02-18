using System; 
using System.Collections.Generic; 
using Server.Items; 

namespace Server.Mobiles 
{ 
	public class SBCook : SBInfo 
	{ 
		private List<GenericBuyInfo> m_BuyInfo = new InternalBuyInfo(); 
		private IShopSellInfo m_SellInfo = new InternalSellInfo(); 

		public SBCook() 
		{ 
		} 

		public override IShopSellInfo SellInfo { get { return m_SellInfo; } } 
		public override List<GenericBuyInfo> BuyInfo { get { return m_BuyInfo; } } 

		public class InternalBuyInfo : List<GenericBuyInfo> 
		{ 
			public InternalBuyInfo() 
			{ 
				Add( new GenericBuyInfo( typeof( SackFlour ), 5, 999, 0x1039, 0 ) );
				Add( new GenericBuyInfo( typeof( JarHoney ), 3, 999, 0x9EC, 0 ) );
				Add( new GenericBuyInfo( typeof( RollingPin ), 2, 999, 0x1043, 0 ) );
				Add( new GenericBuyInfo( typeof( FlourSifter ), 2, 999, 0x103E, 0 ) );
				Add( new GenericBuyInfo( "1044567", typeof( Skillet ), 3, 999, 0x97F, 0 ) );

				Add( new GenericBuyInfo( typeof( FoodPlate ), 5, 999, 0x9D7, 0 ) );

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
			} 
		} 

		public class InternalSellInfo : GenericSellInfo 
		{ 
			public InternalSellInfo() 
			{ 
				Add( typeof( CheeseWheel ), 12 );
				Add( typeof( CookedBird ), 8 );
				Add( typeof( RoastPig ), 53 );
				Add( typeof( Cake ), 5 );
				Add( typeof( JarHoney ), 1 );
				Add( typeof( SackFlour ), 1 );
				Add( typeof( BreadLoaf ), 2 );
				Add( typeof( ChickenLeg ), 3 );
				Add( typeof( LambLeg ), 4 );
				Add( typeof( Skillet ), 1 );
				Add( typeof( FlourSifter ), 1 );
				Add( typeof( RollingPin ), 1 );
				Add( typeof( Muffins ), 1 );
				Add( typeof( ApplePie ), 3 );

				Add( typeof( WoodenBowlOfCarrots ), 1 );
				Add( typeof( WoodenBowlOfCorn ), 1 );
				Add( typeof( WoodenBowlOfLettuce ), 1 );
				Add( typeof( WoodenBowlOfPeas ), 1 );
				Add( typeof( EmptyPewterBowl ), 1 );
				Add( typeof( PewterBowlOfCorn ), 1 );
				Add( typeof( PewterBowlOfLettuce ), 1 );
				Add( typeof( PewterBowlOfPeas ), 1 );
				Add( typeof( PewterBowlOfPotatos ), 1 );
				Add( typeof( WoodenBowlOfStew ), 1 );
				Add( typeof( WoodenBowlOfTomatoSoup ), 1 );
			} 
		} 
	} 
}