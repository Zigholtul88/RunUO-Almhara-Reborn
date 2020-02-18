using System;
using System.Collections.Generic;
using Server.Items;

namespace Server.Mobiles
{
	public class SBRedDaggerKeepHealer2 : SBInfo
	{
		private List<GenericBuyInfo> m_BuyInfo = new InternalBuyInfo();
		private IShopSellInfo m_SellInfo = new InternalSellInfo();

		public SBRedDaggerKeepHealer2()
		{
		}

		public override IShopSellInfo SellInfo { get { return m_SellInfo; } }
		public override List<GenericBuyInfo> BuyInfo { get { return m_BuyInfo; } }

		public class InternalBuyInfo : List<GenericBuyInfo>
		{
			public InternalBuyInfo()
			{
 				Add( new GenericBuyInfo( typeof( GreaterCurePotion ), 300, 500, 0xF07, 0 ) );

 				Add( new GenericBuyInfo( typeof( CurePotion ), 50, 225, 0xF07, 0 ) );
				Add( new GenericBuyInfo( typeof( HealPotion ), 50, 210, 0xF0C, 0 ) );

				Add( new GenericBuyInfo( typeof( Bandage ), 5, 999, 0xE21, 0 ) );
				Add( new GenericBuyInfo( typeof( Bandage ), 5, 999, 0xE21, 0 ) );
				Add( new GenericBuyInfo( typeof( LesserHealPotion ), 25, 350, 0xF0C, 0 ) );
				Add( new GenericBuyInfo( typeof( RefreshPotion ), 25, 325, 0xF0B, 0 ) );
				Add( new GenericBuyInfo( typeof( Ginseng ), 2, 550, 0xF85, 0 ) );
				Add( new GenericBuyInfo( typeof( Garlic ), 2, 550, 0xF84, 0 ) );
			}
		}

		public class InternalSellInfo : GenericSellInfo
		{
			public InternalSellInfo()
			{
				Add( typeof( Bandage ), 2 );
				Add( typeof( LesserHealPotion ), 12 );
				Add( typeof( RefreshPotion ), 12 );
				Add( typeof( Garlic ), 1 );
				Add( typeof( Ginseng ), 1 );
			}
		}
	}
}