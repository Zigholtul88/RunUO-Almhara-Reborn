using System;
using System.Collections.Generic;
using Server.Items;
using Server.ACC.CSS.Systems.Druid;

namespace Server.Mobiles
{
	public class SBDruidPetHealer : SBInfo
	{
		private List<GenericBuyInfo> m_BuyInfo = new InternalBuyInfo();
		private IShopSellInfo m_SellInfo = new InternalSellInfo();

		public SBDruidPetHealer()
		{
		}

		public override IShopSellInfo SellInfo { get { return m_SellInfo; } }
		public override List<GenericBuyInfo> BuyInfo { get { return m_BuyInfo; } }

		public class InternalBuyInfo : List<GenericBuyInfo>
		{
			public InternalBuyInfo()
			{
				Add( new GenericBuyInfo( "Druid Spellbook", typeof( DruidSpellbook ), 500, 10, 0xEFA, 0x48C ) );

				Add( new GenericBuyInfo( "Familiar Scroll", typeof( DruidFamiliarScroll ), 300, 100, 0xE39, 0x58B ) );
				Add( new GenericBuyInfo( "Hollow Reed Scroll", typeof( DruidHollowReedScroll ), 300, 100, 0xE39, 0x58B ) );
				Add( new GenericBuyInfo( "Lure Stone Scroll", typeof( DruidLureStoneScroll ), 200, 100, 0xE39, 0x58B ) );
				Add( new GenericBuyInfo( "Shield of Earth Scroll", typeof( DruidShieldOfEarthScroll ), 200, 100, 0xE39, 0x58B ) );

				Add( new GenericBuyInfo( typeof( Bandage ), 5, 999, 0xE21, 0 ) );
				Add( new GenericBuyInfo( typeof( Bandage ), 5, 999, 0xE21, 0 ) );

				Add( new GenericBuyInfo( typeof( LesserHealPotion ), 25, 350, 0xF0C, 0 ) );
				Add( new GenericBuyInfo( typeof( RefreshPotion ), 25, 325, 0xF0B, 0 ) );

				Add( new GenericBuyInfo( typeof( BlackPearl ), 3, 100, 0xF7A, 0 ) );
				Add( new GenericBuyInfo( typeof( Bloodmoss ), 3, 100, 0xF7B, 0 ) );
				Add( new GenericBuyInfo( typeof( Garlic ), 3, 100, 0xF84, 0 ) );
				Add( new GenericBuyInfo( typeof( Ginseng ), 3, 100, 0xF85, 0 ) );
				Add( new GenericBuyInfo( typeof( MandrakeRoot ), 3, 100, 0xF86, 0 ) );
				Add( new GenericBuyInfo( typeof( Nightshade ), 3, 100, 0xF88, 0 ) );
				Add( new GenericBuyInfo( typeof( SpidersSilk ), 3, 100, 0xF8D, 0 ) );
				Add( new GenericBuyInfo( typeof( SulfurousAsh ), 3, 100, 0xF8C, 0 ) );

				Add( new GenericBuyInfo( "Destroying Angel", typeof( DestroyingAngel ), 5, 999, 0xE1F, 0x290 ) );
				Add( new GenericBuyInfo( "Petrafied Wood", typeof( PetrafiedWood ), 5, 999, 0x97A, 0x46C ) );
				Add( new GenericBuyInfo( "Spring Water", typeof( SpringWater ), 5, 999, 0xE24, 0x47F ) );
			}
		}

		public class InternalSellInfo : GenericSellInfo
		{
			public InternalSellInfo()
			{
				Add( typeof( Bandage ), 2 );

				Add( typeof( LesserHealPotion ), 12 );
				Add( typeof( RefreshPotion ), 12 );

				Add( typeof( BlackPearl ), 1 ); 
				Add( typeof( Bloodmoss ), 1 ); 
				Add( typeof( MandrakeRoot ), 1 ); 
				Add( typeof( Garlic ), 1 ); 
				Add( typeof( Ginseng ), 1 ); 
				Add( typeof( Nightshade ), 1 ); 
				Add( typeof( SpidersSilk ), 1 ); 
				Add( typeof( SulfurousAsh ), 1 ); 

				Add( typeof( DestroyingAngel ), 1 ); 
				Add( typeof( PetrafiedWood ), 1 ); 
				Add( typeof( SpringWater ), 1 ); 
			}
		}
	}
}