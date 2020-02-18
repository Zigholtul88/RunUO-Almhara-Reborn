using System;
using System.Collections.Generic;
using Server.Items;

namespace Server.Mobiles
{
	public class SBJewel: SBInfo
	{
		private List<GenericBuyInfo> m_BuyInfo = new InternalBuyInfo();
		private IShopSellInfo m_SellInfo = new InternalSellInfo();

		public SBJewel()
		{
		}

		public override IShopSellInfo SellInfo { get { return m_SellInfo; } }
		public override List<GenericBuyInfo> BuyInfo { get { return m_BuyInfo; } }

		public class InternalBuyInfo : List<GenericBuyInfo>
		{
			public InternalBuyInfo()
			{
				Add( new GenericBuyInfo( "Blazing Onyx Bracelet", typeof( BlazingOnyxBracelet ), 500, 500, 0x1086, 1161 ) );
				Add( new GenericBuyInfo( "Blazing Onyx Earrings", typeof( BlazingOnyxEarrings ), 500, 500, 0x1087, 1161 ) );
				Add( new GenericBuyInfo( "Blazing Onyx Necklace", typeof( BlazingOnyxNecklace ), 500, 500, 0x1085, 1161 ) );
				Add( new GenericBuyInfo( "Blazing Onyx Ring", typeof( BlazingOnyxRing ), 500, 500, 0x108a, 1161 ) );
				Add( new GenericBuyInfo( "Sun Maggot Bracelet", typeof( SunMaggotBracelet ), 700, 500, 0x1086, 2413 ) );
				Add( new GenericBuyInfo( "Sun Maggot Earrings", typeof( SunMaggotEarrings ), 700, 500, 0x1087, 2413 ) );
				Add( new GenericBuyInfo( "Sun Maggot Necklace", typeof( SunMaggotNecklace ), 700, 500, 0x1085, 2413 ) );
				Add( new GenericBuyInfo( "Sun Maggot Ring", typeof( SunMaggotRing ), 700, 500, 0x108a, 2413 ) );
				Add( new GenericBuyInfo( "Tundra Pearl Bracelet", typeof( TundraPearlBracelet ), 500, 500, 0x1086, 1151 ) );
				Add( new GenericBuyInfo( "Tundra Pearl Earrings", typeof( TundraPearlEarrings ), 500, 500, 0x1087, 1151 ) );
				Add( new GenericBuyInfo( "Tundra Pearl Necklace", typeof( TundraPearlNecklace ), 500, 500, 0x1085, 1151 ) );
				Add( new GenericBuyInfo( "Tundra Pearl Ring", typeof( TundraPearlRing ), 500, 500, 0x108a, 1151 ) );

				Add( new GenericBuyInfo( typeof( GoldRing ), 50, 20, 0x108A, 0 ) );
				Add( new GenericBuyInfo( typeof( Necklace ), 100, 20, 0x1085, 0 ) );
				Add( new GenericBuyInfo( typeof( GoldNecklace ), 100, 20, 0x1088, 0 ) );
				Add( new GenericBuyInfo( typeof( GoldBeadNecklace ), 100, 20, 0x1089, 0 ) );
				Add( new GenericBuyInfo( typeof( Beads ), 50, 20, 0x108B, 0 ) );
				Add( new GenericBuyInfo( typeof( GoldBracelet ), 80, 20, 0x1086, 0 ) );
				Add( new GenericBuyInfo( typeof( GoldEarrings ), 60, 20, 0x1087, 0 ) );

				Add( new GenericBuyInfo( typeof( Amber ), 243, 20, 0xF25, 0 ) );
				Add( new GenericBuyInfo( typeof( Amethyst ), 242, 20, 0xF16, 0 ) );
				Add( new GenericBuyInfo( typeof( Citrine ), 169, 20, 0xF15, 0 ) );
				Add( new GenericBuyInfo( typeof( Diamond ), 495, 20, 0xF26, 0 ) );
				Add( new GenericBuyInfo( typeof( Emerald ), 440, 20, 0xF10, 0 ) );
				Add( new GenericBuyInfo( typeof( Ruby ), 392, 20, 0xF13, 0 ) );
				Add( new GenericBuyInfo( typeof( Sapphire ), 304, 20, 0xF19, 0 ) );
				Add( new GenericBuyInfo( typeof( StarSapphire ), 463, 20, 0xF21, 0 ) );
				Add( new GenericBuyInfo( typeof( Tourmaline ), 206, 20, 0xF2D, 0 ) );

				Add( new GenericBuyInfo( "1060740", typeof( BroadcastCrystal ),  100, 20, 0x1ED0, 0, new object[] {  500 } ) ); // 500 charges
				Add( new GenericBuyInfo( "1060740", typeof( BroadcastCrystal ), 200, 20, 0x1ED0, 0, new object[] { 1000 } ) ); // 1000 charges
				Add( new GenericBuyInfo( "1060740", typeof( BroadcastCrystal ), 300, 20, 0x1ED0, 0, new object[] { 2000 } ) ); // 2000 charges

				Add( new GenericBuyInfo( "1060740", typeof( ReceiverCrystal ), 50, 20, 0x1ED0, 0 ) );
			} 
		} 

		public class InternalSellInfo : GenericSellInfo 
		{ 
			public InternalSellInfo() 
			{ 
				Add( typeof( Agate ), 30 );
				Add( typeof( Beryl ), 47 );
				Add( typeof( ChromeDiopside ), 70 );
				Add( typeof( FireOpal ), 95 );
				Add( typeof( MoonstoneCustom ), 35 );
				Add( typeof( Onyx ), 43 );
				Add( typeof( Opal ), 15 );
				Add( typeof( Pearl ), 31 );
				Add( typeof( TurquoiseCustom ), 53 );

				Add( typeof( Bloodstone ), 162 );
				Add( typeof( Citrine ), 169 );
				Add( typeof( Demantoid ), 134 );
				Add( typeof( Jasper ), 165 );
				Add( typeof( Lolite ), 181 );
				Add( typeof( Lupis ), 144 );
				Add( typeof( Peridot ), 120 );
				Add( typeof( Tsavorite ), 193 );
				Add( typeof( Zircon ), 112 );

				Add( typeof( Amber ), 243 );
				Add( typeof( Amethyst ), 242 );
				Add( typeof( Andalusite ), 264 );
				Add( typeof( Chrysoberyl ), 288 );
				Add( typeof( Garnet ), 238 );
				Add( typeof( Jade ), 205 );
				Add( typeof( Mandarin ), 232 );
				Add( typeof( Morganite ), 252 );
				Add( typeof( Paraiba ), 291 );
				Add( typeof( TigerEye ), 281 );
				Add( typeof( Tourmaline ), 206 );

				Add( typeof( Alexandrite ), 360 );
				Add( typeof( Ametrine ), 353 );
				Add( typeof( Kunzite ), 359 );
				Add( typeof( Ruby ), 392 );
				Add( typeof( Sapphire ), 304 );
				Add( typeof( Tanzanite ), 377 );
				Add( typeof( Topaz ), 386 );
				Add( typeof( Zultanite ), 354 );

				Add( typeof( Diamond ), 495 );
				Add( typeof( Emerald ), 440 );
				Add( typeof( PinkQuartz ), 454 );
				Add( typeof( StarSapphire ), 463 );

				Add( typeof( GoldRing ), 25 );
				Add( typeof( SilverRing ), 25 );

				Add( typeof( Necklace ), 50 );
				Add( typeof( GoldNecklace ), 50 );
				Add( typeof( GoldBeadNecklace ), 50 );
				Add( typeof( SilverNecklace ), 50 );
				Add( typeof( SilverBeadNecklace ), 50 );

				Add( typeof( Beads ), 25 );

				Add( typeof( GoldBracelet ), 40 );
				Add( typeof( SilverBracelet ), 40 );

				Add( typeof( GoldEarrings ), 30 );
				Add( typeof( SilverEarrings ), 30 );
			}
		}
	}
}
