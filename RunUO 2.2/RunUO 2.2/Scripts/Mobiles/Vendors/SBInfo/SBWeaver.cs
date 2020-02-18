using System; 
using System.Collections.Generic; 
using Server.Items; 

namespace Server.Mobiles 
{ 
	public class SBWeaver: SBInfo 
	{ 
		private List<GenericBuyInfo> m_BuyInfo = new InternalBuyInfo(); 
		private IShopSellInfo m_SellInfo = new InternalSellInfo(); 

		public SBWeaver() 
		{ 
		} 

		public override IShopSellInfo SellInfo { get { return m_SellInfo; } } 
		public override List<GenericBuyInfo> BuyInfo { get { return m_BuyInfo; } } 

		public class InternalBuyInfo : List<GenericBuyInfo> 
		{ 
			public InternalBuyInfo() 
			{ 
				Add( new GenericBuyInfo( typeof( BoltOfCloth ), 50, 500, 0xf95, Utility.RandomDyedHue() ) ); 

				Add( new GenericBuyInfo( typeof( Cloth ), 10, 999, 0x1766, Utility.RandomDyedHue() ) ); 
				Add( new GenericBuyInfo( typeof( UncutCloth ), 10, 999, 0x1767, Utility.RandomDyedHue() ) ); 

				Add( new GenericBuyInfo( typeof( Cotton ), 10, 999, 0xDF9, 0 ) );
				Add( new GenericBuyInfo( "Dark Yarn", typeof( DarkYarn ), 10, 999, 0xE1D, 0 ) );
				Add( new GenericBuyInfo( "Light Yarn", typeof( LightYarn ), 10, 999, 0xE1E, 0 ) );

				Add( new GenericBuyInfo( typeof( Flax ), 10, 999, 0x1A9C, 0 ) );
				Add( new GenericBuyInfo( typeof( SpoolOfThread ), 10, 999, 0xFA0, 0 ) );
				Add( new GenericBuyInfo( typeof( Wool ), 10, 999, 0xDF8, 0 ) );

				Add( new GenericBuyInfo( typeof( DyeTub ), 5000, 20, 0xFAB, 0 ) ); 
				Add( new GenericBuyInfo( typeof( Dyes ), 2500, 20, 0xFA9, 0 ) ); 
		                Add( new GenericBuyInfo( typeof( Scissors ), 100, 40, 0xF9F, 0 ) );
				Add( new GenericBuyInfo( typeof( SewingKit ), 100, 500, 0xF9D, 0 ) );
			} 
		} 

		public class InternalSellInfo : GenericSellInfo 
		{ 
			public InternalSellInfo() 
			{ 
				Add( typeof( Dyes ), 1200 );
				Add( typeof( DyeTub ), 2500 );
				Add( typeof( Scissors ), 10 );
				Add( typeof( SewingKit ), 12 );

				Add( typeof( Doublet ), 7 );
				Add( typeof( FormalShirt ), 10 );
				Add( typeof( Shirt ), 7 );
				Add( typeof( RogueGarb ), 15 );

				Add( typeof( Bandana ), 5 );
				Add( typeof( Cap ), 5 );
				Add( typeof( StrawHat ), 5 );

				Add( typeof( Cloak ), 10 );
				Add( typeof( FurCape ), 15 );
				Add( typeof( HalfApron ), 10 );
				Add( typeof( PlainDress ), 10 );
				Add( typeof( Robe ), 10 );
				Add( typeof( FancyRobe ), 10 );
				Add( typeof( Trenchcoat ), 15 );

				Add( typeof( FancyPants ), 15 );
				Add( typeof( ShortPants ), 7 );
				Add( typeof( Skirt ), 7 );

				Add( typeof( BoltOfCloth ), 25 );
				Add( typeof( Cloth ), 5 );
				Add( typeof( UncutCloth ), 5 );

				Add( typeof( Cotton ), 5 );
				Add( typeof( DarkYarn ), 5 );
				Add( typeof( Flax ), 5 );
				Add( typeof( LightYarn ), 5 );
				Add( typeof( LightYarnUnraveled ), 5 );
				Add( typeof( SpoolOfThread ), 5 );
				Add( typeof( Wool ), 5 );
			} 
		} 
	} 
}