using System;
using System.Collections.Generic;
using Server.Items;

namespace Server.Mobiles
{
	public class SBInnKeeper : SBInfo
	{
		private List<GenericBuyInfo> m_BuyInfo = new InternalBuyInfo();
		private IShopSellInfo m_SellInfo = new InternalSellInfo();

		public SBInnKeeper()
		{
		}

		public override IShopSellInfo SellInfo { get { return m_SellInfo; } }
		public override List<GenericBuyInfo> BuyInfo { get { return m_BuyInfo; } }

		public class InternalBuyInfo : List<GenericBuyInfo>
		{
			public InternalBuyInfo()
			{
				Add( new BeverageBuyInfo( typeof( Pitcher ), BeverageType.Milk, 25, 35, 0x9F0, 0 ) );
				Add( new BeverageBuyInfo( typeof( Pitcher ), BeverageType.Cider, 30, 14, 0x1F97, 0 ) );
				Add( new BeverageBuyInfo( typeof( Pitcher ), BeverageType.Water, 30, 48, 0x1F9D, 0 ) );

				Add( new GenericBuyInfo( typeof( BreadLoaf ), 26, 78, 0x103B, 0 ) );
				Add( new GenericBuyInfo( typeof( CheeseWheel ), 28, 69, 0x97E, 0 ) );

				Add( new GenericBuyInfo( typeof( Pouch ), 100, 50, 0xE79, 0 ) );

////////////////////////////////////////////////////// Misc
// All tools sell at a base price of 100 gp
				Add( new GenericBuyInfo( "Candle Boiler", typeof( CandleBoiler ), 100, 500, 0x15F8, 781 ) );
				Add( new GenericBuyInfo( typeof( HeatingStand ), 100, 100, 0x1849, 0 ) ); 
				Add( new GenericBuyInfo( typeof( Candle ), 50, 500, 0xA28, 0 ) );
				Add( new GenericBuyInfo( typeof( Torch ), 50, 500, 0xF6B, 0 ) );

////////////////////////////////////////////////////// Primary Components
				Add( new GenericBuyInfo( "Beeswax", typeof( Beeswax ), 5, 999, 0x1422, 0 ) );
				Add( new GenericBuyInfo( "Iron Ingot", typeof( IronIngot ), 5, 999, 0x1BF2, 0 ) );
				Add( new GenericBuyInfo( "Log", typeof( Log ), 5, 999, 0x1BDD, 0 ) );

////////////////////////////////////////////////////// Secondary Components
				Add( new GenericBuyInfo( "Spool of Thread", typeof( SpoolOfThread ), 1, 999, 0xFA0, 0 ) );

////////////////////////////////////////////////////// Special Components
				Add( new GenericBuyInfo( "Energy Stone", typeof( EnergyStone ), 25, 500, 0xF26, 485 ) );
				Add( new GenericBuyInfo( "Ice Stone", typeof( IceStone ), 25, 500, 0xF26, 1152 ) );
				Add( new GenericBuyInfo( "Serpent Scale", typeof( SerpentScale ), 25, 500, 0x26B4, 69 ) );
			} 
		} 

		public class InternalSellInfo : GenericSellInfo 
		{ 
			public InternalSellInfo() 
			{ 
				Add( typeof( Pouch ), 50 );
				Add( typeof( HeatingStand ), 50 );

				Add( typeof( Beeswax ), 3 );
				Add( typeof( Candle ), 25 );
				Add( typeof( Torch ), 25 );
			}
		}
	}
}