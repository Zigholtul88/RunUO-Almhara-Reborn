using System;
using System.Collections.Generic;
using Server.Items;

namespace Server.Mobiles
{
	public class SBAnimalTrainer : SBInfo
	{
		private List<GenericBuyInfo> m_BuyInfo = new InternalBuyInfo();
		private IShopSellInfo m_SellInfo = new InternalSellInfo();

		public SBAnimalTrainer()
		{
		}

		public override IShopSellInfo SellInfo { get { return m_SellInfo; } }
		public override List<GenericBuyInfo> BuyInfo { get { return m_BuyInfo; } }

		public class InternalBuyInfo : List<GenericBuyInfo>
		{
			public InternalBuyInfo()
			{
				Add( new AnimalBuyInfo( 1, typeof( Chakla ), 90, 10, 201, 2405 ) );
				Add( new AnimalBuyInfo( 1, typeof( Cinnamologus ), 50, 10, 832, 1608 ) );
				Add( new AnimalBuyInfo( 1, typeof( Dobharchu ), 100, 10, 217, 93 ) );
				Add( new AnimalBuyInfo( 1, typeof( ForestBat ), 160, 10, 317, 0 ) );
				Add( new AnimalBuyInfo( 1, typeof( SilverbackGorilla ), 100, 10, 0x1D, 1154 ) );
				Add( new AnimalBuyInfo( 1, typeof( Taniwha ), 2137, 30, 235, 93 ) );
				Add( new AnimalBuyInfo( 1, typeof( Waitoreke ), 50, 10, 0x117, 0 ) );

				Add( new AnimalBuyInfo( 1, typeof( Goat ), 60, 10, 0xD1, 0 ) );
				Add( new AnimalBuyInfo( 1, typeof( Hind ), 100, 10, 0xED, 0 ) );
				Add( new AnimalBuyInfo( 1, typeof( Pig ), 160, 10, 0xCB, 0 ) );
				Add( new AnimalBuyInfo( 1, typeof( Rabbit ), 60, 10, 205, 0 ) );
				Add( new AnimalBuyInfo( 1, typeof( Rat ), 50, 10, 238, 0 ) );
				Add( new AnimalBuyInfo( 1, typeof( Walrus ), 241, 10, 0xDD, 0 ) );

				Add( new AnimalBuyInfo( 1, typeof( PackHorse ), 500, 15, 291, 0 ) );
				Add( new AnimalBuyInfo( 1, typeof( PackLlama ), 500, 15, 292, 0 ) );
				Add( new AnimalBuyInfo( 1, typeof( Grachiosaur ), 35000, 10, 288, 0 ) );

				Add( new AnimalBuyInfo( 1, typeof( GreatHart ), 1000, 20, 0xEA, 0 ) );
				Add( new AnimalBuyInfo( 1, typeof( Nephropirok ), 2000, 20, 0x112, 0 ) );
				Add( new AnimalBuyInfo( 1, typeof( Shachihoko ), 3000, 20, 0x11C, 88 ) );
					
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
