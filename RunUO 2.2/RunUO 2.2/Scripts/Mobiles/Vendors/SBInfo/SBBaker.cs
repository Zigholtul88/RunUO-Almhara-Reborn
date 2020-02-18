using System; 
using System.Collections.Generic; 
using Server.Items; 

namespace Server.Mobiles 
{ 
	public class SBBaker : SBInfo 
	{ 
		private List<GenericBuyInfo> m_BuyInfo = new InternalBuyInfo(); 
		private IShopSellInfo m_SellInfo = new InternalSellInfo(); 

		public SBBaker() 
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