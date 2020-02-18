using System; 
using System.Collections.Generic; 
using Server.Items; 
using Server.ACC.CSS.Systems.Bard;

namespace Server.Mobiles 
{ 
	public class SBBard: SBInfo 
	{ 
		private List<GenericBuyInfo> m_BuyInfo = new InternalBuyInfo(); 
		private IShopSellInfo m_SellInfo = new InternalSellInfo(); 

		public SBBard() 
		{ 
		} 

		public override IShopSellInfo SellInfo { get { return m_SellInfo; } } 
		public override List<GenericBuyInfo> BuyInfo { get { return m_BuyInfo; } } 

		public class InternalBuyInfo : List<GenericBuyInfo> 
		{ 
			public InternalBuyInfo() 
			{ 
				Add( new GenericBuyInfo( "Bard Spellbook", typeof( BardSpellbook ), 800, 10, 0xEFA, 0x96 ) );

				Add( new GenericBuyInfo( "Energy Carol Scroll", typeof( BardEnergyCarolScroll ), 200, 244, 0x14ED, 0x96 ) );
				Add( new GenericBuyInfo( "Fire Carol Scroll", typeof( BardFireCarolScroll ), 200, 368, 0x14ED, 0x96 ) );
				Add( new GenericBuyInfo( "Ice Carol Scroll", typeof( BardIceCarolScroll ), 200, 368, 0x14ED, 0x96 ) );
				Add( new GenericBuyInfo( "Poison Carol Scroll", typeof( BardPoisonCarolScroll ), 200, 251, 0x14ED, 0x96 ) );

				Add( new GenericBuyInfo( typeof( Drums ), 500, ( 20 ), 0x0E9C, 0 ) ); 
				Add( new GenericBuyInfo( typeof( Tambourine ), 500, ( 20 ), 0x0E9E, 0 ) ); 
				Add( new GenericBuyInfo( typeof( LapHarp ), 500, ( 20 ), 0x0EB2, 0 ) ); 
				Add( new GenericBuyInfo( typeof( Lute ), 500, ( 20 ), 0x0EB3, 0 ) ); 
 
			} 
		} 

		public class InternalSellInfo : GenericSellInfo 
		{ 
			public InternalSellInfo() 
			{ 
				Add( typeof( BardSpellbook ), 250 ); 

				Add( typeof( BardEnergyCarolScroll ), 50 ); 
				Add( typeof( BardFireCarolScroll ), 50 ); 
				Add( typeof( BardIceCarolScroll ), 50 ); 
				Add( typeof( BardPoisonCarolScroll ), 50 ); 

				Add( typeof( LapHarp ), 100 ); 
				Add( typeof( Lute ), 100 ); 
				Add( typeof( Drums ), 100 ); 
				Add( typeof( Harp ), 100 ); 
				Add( typeof( Tambourine ), 100 ); 
			} 
		} 
	} 
}