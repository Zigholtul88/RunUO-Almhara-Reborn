using System; 
using System.Collections.Generic; 
using Server.Items; 

namespace Server.Mobiles 
{ 
	public class SBCobbler : SBInfo 
	{ 
		private List<GenericBuyInfo> m_BuyInfo = new InternalBuyInfo(); 
		private IShopSellInfo m_SellInfo = new InternalSellInfo(); 

		public SBCobbler() 
		{ 
		} 

		public override IShopSellInfo SellInfo { get { return m_SellInfo; } } 
		public override List<GenericBuyInfo> BuyInfo { get { return m_BuyInfo; } } 

		public class InternalBuyInfo : List<GenericBuyInfo> 
		{ 
			public InternalBuyInfo() 
			{ 	
				Add( new GenericBuyInfo( "Daemonhide Stitched Boots", typeof( DaemonhideStitchedBoots ), 1250, 100, 0x170b, 1461 ) );
				Add( new GenericBuyInfo( "Draconian Scaled Boots", typeof( DraconianScaledBoots ), 1300, 100, 15865, 2119 ) );
				Add( new GenericBuyInfo( "Snow Crusted Boots", typeof( SnowCrustedBoots ), 800, 100, 15864, 1150 ) );

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
}