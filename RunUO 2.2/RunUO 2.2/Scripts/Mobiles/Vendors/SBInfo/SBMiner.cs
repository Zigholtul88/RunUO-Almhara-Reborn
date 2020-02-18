using System;
using System.Collections.Generic;
using Server.Items;

namespace Server.Mobiles
{
	public class SBMiner: SBInfo
	{
		private List<GenericBuyInfo> m_BuyInfo = new InternalBuyInfo();
		private IShopSellInfo m_SellInfo = new InternalSellInfo();

		public SBMiner()
		{
		}

		public override IShopSellInfo SellInfo { get { return m_SellInfo; } }
		public override List<GenericBuyInfo> BuyInfo { get { return m_BuyInfo; } }

		public class InternalBuyInfo : List<GenericBuyInfo>
		{
			public InternalBuyInfo()
			{
				Add( new GenericBuyInfo( "Jacobs Pickaxe", typeof( JacobsPickaxe ), 500, 300, 0xE86, 0 ) );

				Add( new GenericBuyInfo( typeof( Pickaxe ), 100, 900, 0xE86, 0 ) );
				Add( new GenericBuyInfo( typeof( Shovel ), 100, 950, 0xF39, 0 ) );

				Add( new GenericBuyInfo( typeof( SturdyPickaxe ), 300, 800, 0xE86, 0x973 ) );
				Add( new GenericBuyInfo( typeof( SturdyShovel ), 300, 850, 0xF39, 0x973 ) );

				Add( new GenericBuyInfo( "Miner's Ingot Pouch", typeof( MinersIngotPouch ), 5000, 500, 0xE79, 0 ) );
				Add( new GenericBuyInfo( typeof( Pouch ), 25, 250, 0xE79, 0 ) );
			}
		}

		public class InternalSellInfo : GenericSellInfo
		{
			public InternalSellInfo()
			{
				Add( typeof( Pickaxe ), 12 );
				Add( typeof( Shovel ), 6 );
				Add( typeof( Lantern ), 1 );
				//Add( typeof( OilFlask ), 4 );
				Add( typeof( Torch ), 3 );
				Add( typeof( Bag ), 3 );
				Add( typeof( Candle ), 3 );
			}
		}
	}
}