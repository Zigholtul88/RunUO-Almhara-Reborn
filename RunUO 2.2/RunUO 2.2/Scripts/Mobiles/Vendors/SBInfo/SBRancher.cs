
using System;
using System.Collections.Generic;
using Server.Items;

namespace Server.Mobiles
{
	public class SBRancher : SBInfo
	{
		private List<GenericBuyInfo> m_BuyInfo = new InternalBuyInfo();
		private IShopSellInfo m_SellInfo = new InternalSellInfo();

		public SBRancher()
		{
		}

		public override IShopSellInfo SellInfo { get { return m_SellInfo; } }
		public override List<GenericBuyInfo> BuyInfo { get { return m_BuyInfo; } }

		public class InternalBuyInfo : List<GenericBuyInfo>
		{
			public InternalBuyInfo()
			{
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