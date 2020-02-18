using System;
using System.Collections.Generic;
using Server.Items;

namespace Server.Mobiles
{
	public class SBBowyer : SBInfo
	{
		private List<GenericBuyInfo> m_BuyInfo = new InternalBuyInfo();
		private IShopSellInfo m_SellInfo = new InternalSellInfo();

		public SBBowyer()
		{
		}

		public override IShopSellInfo SellInfo { get { return m_SellInfo; } }
		public override List<GenericBuyInfo> BuyInfo { get { return m_BuyInfo; } }

		public class InternalBuyInfo : List<GenericBuyInfo>
		{
			public InternalBuyInfo()
			{
////////////////////////////////////////////////////// Misc
// All tools sell at a base price of 100 gp
				Add( new GenericBuyInfo( typeof( FletcherTools ), 100, 378, 0x1022, 0 ) );
				Add( new GenericBuyInfo( typeof( ElvenQuiver ), 100, 20, 0x2FB7, 0 ) );

////////////////////////////////////////////////////// Primary Components
				Add( new GenericBuyInfo( "Iron Ingot", typeof( IronIngot ), 5, 999, 0x1BF2, 0 ) );
				Add( new GenericBuyInfo( "Leather", typeof( Leather ), 5, 999, 0x1081, 0 ) );
				Add( new GenericBuyInfo( "Log", typeof( Log ), 5, 999, 0x1BDD, 0 ) );

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

////////////////////////////////////////////////////// Ammunition
				Add( new GenericBuyInfo( typeof( Arrow ), 8, Utility.Random( 100, 500 ), 0xF3F, 0 ) );
				Add( new GenericBuyInfo( typeof( Arrow ), 8, Utility.Random( 100, 500 ), 0xF3F, 0 ) );
				Add( new GenericBuyInfo( typeof( Arrow ), 8, Utility.Random( 100, 500 ), 0xF3F, 0 ) );
				Add( new GenericBuyInfo( typeof( OakArrow ), 10, Utility.Random( 50, 80 ), 0xF3F, 2010 ) );
				Add( new GenericBuyInfo( typeof( OakArrow ), 10, Utility.Random( 50, 80 ), 0xF3F, 2010 ) );
				Add( new GenericBuyInfo( typeof( YewArrow ), 15, Utility.Random( 50, 80 ), 0xF3F, 1192 ) );
				Add( new GenericBuyInfo( typeof( YewArrow ), 15, Utility.Random( 50, 80 ), 0xF3F, 1192 ) );
				Add( new GenericBuyInfo( typeof( AshArrow ), 20, Utility.Random( 50, 80 ), 0xF3F, 1191 ) );

				Add( new GenericBuyInfo( typeof( Bolt ), 8, Utility.Random( 100, 500 ), 0x1BFB, 0 ) );
				Add( new GenericBuyInfo( typeof( Bolt ), 8, Utility.Random( 100, 500 ), 0x1BFB, 0 ) );
				Add( new GenericBuyInfo( typeof( Bolt ), 8, Utility.Random( 100, 500 ), 0x1BFB, 0 ) );
				Add( new GenericBuyInfo( typeof( DullCopperBolt ), 10, Utility.Random( 50, 100 ), 0x1BFB, 2419 ) );
				Add( new GenericBuyInfo( typeof( DullCopperBolt ), 10, Utility.Random( 50, 100 ), 0x1BFB, 2419 ) );
				Add( new GenericBuyInfo( typeof( ShadowIronBolt ), 15, Utility.Random( 50, 100 ), 0x1BFB, 2406 ) );
				Add( new GenericBuyInfo( typeof( ShadowIronBolt ), 15, Utility.Random( 50, 100 ), 0x1BFB, 2406 ) );
				Add( new GenericBuyInfo( typeof( BronzeBolt ), 20, Utility.Random( 50, 100 ), 0x1BFB, 2418 ) );

				Add( new GenericBuyInfo( typeof( FukiyaDarts ), 8, Utility.Random( 100, 500 ), 0x2806, 0 ) );

////////////////////////////////////////////////////// Weapons
				Add( new GenericBuyInfo( typeof( Fukiya ), 100, 20, 0x27AA, 0 ) );
				Add( new GenericBuyInfo( typeof( Bow ), 155, 20, 0x13B2, 0 ) );
				Add( new GenericBuyInfo( typeof( CompositeBow ), 168, 20, 0x26C2, 0 ) );
				Add( new GenericBuyInfo( typeof( Crossbow ), 143, 20, 0xF50, 0 ) );
				Add( new GenericBuyInfo( "Ebony Crossbow", typeof( EbonyCrossbow ), 143, 20, 15808, 0 ) );
				Add( new GenericBuyInfo( "Ebony Great Bow", typeof( EbonyGreatBow ), 190, 20, 15806, 0 ) );
				Add( new GenericBuyInfo( "Ebony War Bow", typeof( EbonyWarBow ), 189, 20, 15804, 0 ) );
				Add( new GenericBuyInfo( typeof( ElvenCompositeLongbow ), 235, 20, 0x2D1E, 0 ) );
				Add( new GenericBuyInfo( typeof( HeavyCrossbow ), 173, 20, 0x13FD, 0 ) );
				Add( new GenericBuyInfo( typeof( MagicalShortbow ), 196, 20, 0x2D2B, 0 ) );
				Add( new GenericBuyInfo( typeof( RepeatingCrossbow ), 163, 20, 0x26C3, 0 ) );
				Add( new GenericBuyInfo( "Skeletal War Bow", typeof( SkeletalWarBow ), 368, 20, 16179, 0 ) );
				Add( new GenericBuyInfo( typeof( Yumi ), 296, 20, 0x27A5, 0 ) );
			} 
		} 

		public class InternalSellInfo : GenericSellInfo 
		{ 
			public InternalSellInfo() 
			{ 
////////////////////////////////////////////////////// Misc
// (Sell Price = Vendor Price / by 2) 

				Add( typeof( FletcherTools ), 50 );
				Add( typeof( ElvenQuiver ), 50 );

////////////////////////////////////////////////////// Primary Components
// (Sell Price = Harvest component is 5 per cost equal to x amount / by 2 and round up to the nearest 5) 
				Add( typeof( IronIngot ), 3 );
				Add( typeof( Log ), 3 );

////////////////////////////////////////////////////// Components
// (Sell Price = Remains the same as those found on buying menus) 

				Add( typeof( Feather ), 1 );
				Add( typeof( Shaft ), 1 );

////////////////////////////////////////////////////// Ammunition
// (Sell Price = Harvest component is 5 per cost equal to x amount + Secondary component is 1 per cost equal to x amount / by 2) 

				Add( typeof( Arrow ), 4 );
				Add( typeof( Bolt ), 4 );
				Add( typeof( FukiyaDarts ), 4 );

////////////////////////////////////////////////////// Weapons
// (Base Price = 100gp + Harvest component is 5 per cost equal to x amount + Secondary component is 1 per cost equal to x amount)  

				Add( typeof( Fukiya ), 50 );
				Add( typeof( Bow ), 155 );
				Add( typeof( CompositeBow ), 168 );
				Add( typeof( Crossbow ), 143 );
				Add( typeof( EbonyCrossbow ), 143 );
				Add( typeof( EbonyGreatBow ), 190 );
				Add( typeof( EbonyWarBow ), 189 ); 
				Add( typeof( ElvenCompositeLongbow ), 235 ); 
				Add( typeof( HeavyCrossbow ), 173 ); 
				Add( typeof( MagicalShortbow ), 196 );
				Add( typeof( RepeatingCrossbow ), 162 );

////////////////////////// Skeletal War Bow yields a double price sell increase due to high skill ratio
				Add( typeof( SkeletalWarBow ), 368 );

////////////////////////// Yumi yields a +100 to sell increase due to high skill ratio
				Add( typeof( Yumi ), 296 );
			}
		}
	}
}