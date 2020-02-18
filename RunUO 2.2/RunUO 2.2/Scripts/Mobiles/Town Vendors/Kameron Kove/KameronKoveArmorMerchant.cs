using System;
using System.Collections;
using System.Collections.Generic;
using Server;
using Server.Items;
using Server.Targeting;
using Server.ContextMenus;
using Server.Gumps;
using Server.Misc;
using Server.Network;
using Server.Spells;
using Server.Mobiles;

namespace Server.Mobiles
{
	public class KameronKoveArmorMerchant : BaseVendor
	{
		private List<SBInfo> m_SBInfos = new List<SBInfo>();
		protected override List<SBInfo> SBInfos{ get { return m_SBInfos; } }

		public override bool InitialInnocent{ get{ return true; } }
		public override bool CanTeach { get { return true; } }

		[Constructable]
		public KameronKoveArmorMerchant() : base( "the armor merchant" )
		{
                }

		public override void InitSBInfo()
		{
			m_SBInfos.Add( new SBKameronKoveArmorMerchant() );
		}

		public override void InitOutfit()
		{
			Hue = Utility.RandomList( 3,28,38,48,53,58,63,88,93 );

			SetStr( 143 );
			SetDex( 100 );
			SetInt( 42 );

			SetSkill( SkillName.Anatomy, 60.0, 83.0 );
			SetSkill( SkillName.ArmsLore, 64.0, 100.0 );
			SetSkill( SkillName.Tactics, 60.0, 83.0 );
			SetSkill( SkillName.Parry, 61.0, 93.0 );
			SetSkill( SkillName.Wrestling, 60.0, 83.0 );

			PackGold( 13, 27 );

			if ( this.Female = Utility.RandomBool() )
			{
				Body = 386;
				Name = NameList.RandomName( "female" );
			}
			else
			{
				Body = 390;
				Name = NameList.RandomName( "male" );
			}
                }

		public KameronKoveArmorMerchant( Serial serial ) : base( serial )
		{
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );
			writer.Write( (int) 0 ); // version
		}

		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader );
			int version = reader.ReadInt();
		}
	}

	public class SBKameronKoveArmorMerchant : SBInfo
	{
		private List<GenericBuyInfo> m_BuyInfo = new InternalBuyInfo();
		private IShopSellInfo m_SellInfo = new InternalSellInfo();

		public SBKameronKoveArmorMerchant()
		{
		}

		public override IShopSellInfo SellInfo { get { return m_SellInfo; } }
		public override List<GenericBuyInfo> BuyInfo { get { return m_BuyInfo; } }

		public class InternalBuyInfo : List<GenericBuyInfo>
		{
			public InternalBuyInfo()
			{
////////////////////////////////////////////////////// Level 1
				Add( new GenericBuyInfo( typeof( FemaleLeatherChest ), 100, 500, 0x1C06, 0 ) );
				Add( new GenericBuyInfo( typeof( LeatherArms ), 50, 500, 0x13CD, 0 ) );
				Add( new GenericBuyInfo( typeof( LeatherBustierArms ), 100, 500, 0x1C0A, 0 ) );
				Add( new GenericBuyInfo( typeof( LeatherCap ), 20, 500, 0x1DB9, 0 ) );
				Add( new GenericBuyInfo( typeof( LeatherChest ), 100, 500, 0x13CC, 0 ) );
				Add( new GenericBuyInfo( typeof( LeatherGloves ), 20, 500, 0x13C6, 0 ) );
				Add( new GenericBuyInfo( typeof( LeatherGorget ), 40, 500, 0x13C7, 0 ) );
				Add( new GenericBuyInfo( typeof( LeatherLegs ), 80, 500, 0x13CB, 0 ) );
				Add( new GenericBuyInfo( typeof( LeatherShorts ), 80, 500, 0x1C00, 0 ) );
				Add( new GenericBuyInfo( typeof( LeatherSkirt ), 80, 500, 0x1C08, 0 ) );

////////////////////////////////////////////////////// Level 3
				Add( new GenericBuyInfo( typeof( FemaleLeafChest ), 200, 50, 0x2FCB, 0 ) );
				Add( new GenericBuyInfo( typeof( LeafArms ), 100, 500, 0x2FC8, 0 ) );
				Add( new GenericBuyInfo( typeof( LeafChest ), 200, 500, 0x2FC5, 0 ) );
				Add( new GenericBuyInfo( typeof( LeafGloves ), 40, 500, 0x2FC6, 0 ) );
				Add( new GenericBuyInfo( typeof( LeafGorget ), 80, 500, 0x2FC7, 0 ) );
				Add( new GenericBuyInfo( typeof( LeafLegs ), 160, 500, 0x2FC9, 0 ) );
				Add( new GenericBuyInfo( typeof( LeafTonlet ), 160, 500, 0x2FCA, 0 ) );

////////////////////////////////////////////////////// Level 6
				Add( new GenericBuyInfo( typeof( LeatherDo ), 300, 500, 0x277B, 0 ) );
				Add( new GenericBuyInfo( typeof( LeatherHaidate ), 300, 500, 0x278A, 0 ) );
				Add( new GenericBuyInfo( typeof( LeatherHiroSode ), 300, 500, 0x277E, 0 ) );
				Add( new GenericBuyInfo( typeof( LeatherJingasa ), 300, 500, 0x2776, 0 ) );
				Add( new GenericBuyInfo( typeof( LeatherMempo ), 300, 500, 0x277A, 0 ) );
				Add( new GenericBuyInfo( typeof( LeatherNinjaHood ), 300, 500, 0x278E, 0 ) );
				Add( new GenericBuyInfo( typeof( LeatherNinjaJacket ), 300, 500, 0x2793, 0 ) );
				Add( new GenericBuyInfo( typeof( LeatherNinjaMitts ), 300, 500, 0x2792, 0 ) );
				Add( new GenericBuyInfo( typeof( LeatherNinjaPants ), 300, 500, 0x2791, 0 ) );
				Add( new GenericBuyInfo( typeof( LeatherSuneate ), 300, 500, 0x2786, 0 ) );

////////////////////////////////////////////////////// Level 9
				Add( new GenericBuyInfo( typeof( EbonsilkArms ), 400, 500, 15852, 0 ) );
				Add( new GenericBuyInfo( typeof( EbonsilkChest ), 400, 500, 15855, 0 ) );
				Add( new GenericBuyInfo( typeof( EbonsilkGloves ), 400, 500, 15856, 0 ) );
				Add( new GenericBuyInfo( typeof( EbonsilkGorget ), 400, 500, 15859, 0 ) );
				Add( new GenericBuyInfo( typeof( EbonsilkLegs ), 400, 500, 15860, 0 ) );
				Add( new GenericBuyInfo( typeof( EbonsilkTiara ), 400, 500, 15862, 0 ) );

////////////////////////////////////////////////////// Level 12
				Add( new GenericBuyInfo( typeof( ChitinArms ), 500, 500, 15329, 0 ) );
				Add( new GenericBuyInfo( typeof( ChitinChest ), 500, 500, 15332, 0 ) );
				Add( new GenericBuyInfo( typeof( ChitinGloves ), 500, 500, 15333, 0 ) );
				Add( new GenericBuyInfo( typeof( ChitinGorget ), 500, 500, 15335, 0 ) );
				Add( new GenericBuyInfo( typeof( ChitinHelmet ), 500, 500, 15336, 0 ) );
				Add( new GenericBuyInfo( typeof( ChitinLegs ), 500, 500, 15337, 0 ) );

////////////////////////////////////////////////////// Level 15
				Add( new GenericBuyInfo( typeof( FemaleStuddedChest ), 600, 500, 0x1C02, 0 ) );
				Add( new GenericBuyInfo( typeof( StuddedArms ), 600, 500, 0x13DC, 0 ) );
				Add( new GenericBuyInfo( typeof( StuddedBustierArms ), 600, 500, 0x1C0C, 0 ) );
				Add( new GenericBuyInfo( typeof( StuddedChest ), 600, 500, 0x13DB, 0 ) );
				Add( new GenericBuyInfo( typeof( StuddedGloves ), 600, 500, 0x13D5, 0 ) );
				Add( new GenericBuyInfo( typeof( StuddedGorget ), 600, 500, 0x13D6, 0 ) );
				Add( new GenericBuyInfo( typeof( StuddedLegs ), 600, 500, 0x13DA, 0 ) );

////////////////////////////////////////////////////// Level 18
				Add( new GenericBuyInfo( typeof( HideFemaleChest ), 700, 500, 0x2B79, 0 ) );
				Add( new GenericBuyInfo( typeof( HideChest ), 700, 500, 0x2B74, 0 ) );
				Add( new GenericBuyInfo( typeof( HideGloves ), 700, 500, 0x2B75, 0 ) );
				Add( new GenericBuyInfo( typeof( HideGorget ), 700, 500, 0x2B76, 0 ) );
				Add( new GenericBuyInfo( typeof( HidePants ), 700, 500, 0x2B78, 0 ) );
				Add( new GenericBuyInfo( typeof( HidePauldrons ), 700, 500, 0x2B77, 0 ) );

////////////////////////////////////////////////////// Level 21
				Add( new GenericBuyInfo( typeof( StuddedDo ), 800, 500, 0x277C, 0 ) );
				Add( new GenericBuyInfo( typeof( StuddedHaidate ), 800, 500, 0x278B, 0 ) );
				Add( new GenericBuyInfo( typeof( StuddedHiroSode ), 800, 500, 0x277F, 0 ) );
				Add( new GenericBuyInfo( typeof( StuddedMempo ), 800, 500, 0x279D, 0 ) );
				Add( new GenericBuyInfo( typeof( StuddedSuneate ), 800, 500, 0x2787, 0 ) );

////////////////////////////////////////////////////// Level 24
				Add( new GenericBuyInfo( typeof( VikingStuddedArms ), 900, 500, 15345, 0 ) );
				Add( new GenericBuyInfo( typeof( VikingStuddedCap ), 900, 500, 15348, 0 ) );
				Add( new GenericBuyInfo( typeof( VikingStuddedChest ), 900, 500, 15349, 0 ) );
				Add( new GenericBuyInfo( typeof( VikingStuddedLegs ), 900, 500, 15352, 0 ) );

////////////////////////////////////////////////////// Level 27
				Add( new GenericBuyInfo( typeof( ChainChest ), 1000, 500, 0x13BF, 0 ) );
				Add( new GenericBuyInfo( typeof( ChainCoif ), 1000, 500, 0x13BB, 0 ) );
				Add( new GenericBuyInfo( typeof( ChainLegs ), 1000, 500, 0x13BE, 0 ) );

////////////////////////////////////////////////////// Level 30
				Add( new GenericBuyInfo( typeof( WeldedChainArms ), 1100, 500, 15339, 0 ) );
				Add( new GenericBuyInfo( typeof( WeldedChainChest ), 1100, 500, 15342, 0 ) );
				Add( new GenericBuyInfo( typeof( WeldedChainLegs ), 1100, 500, 15343, 0 ) );

////////////////////////////////////////////////////// Level 33
				Add( new GenericBuyInfo( typeof( ElvenChainArms ), 1200, 500, 15317, 0 ) );
				Add( new GenericBuyInfo( typeof( ElvenChainChest ), 1200, 500, 15320, 0 ) );
				Add( new GenericBuyInfo( typeof( ElvenChainGloves ), 1200, 500, 15321, 0 ) );
				Add( new GenericBuyInfo( typeof( ElvenChainGorget ), 1200, 500, 15323, 0 ) );
				Add( new GenericBuyInfo( typeof( ElvenChainHelmet ), 1200, 500, 15326, 0 ) );
				Add( new GenericBuyInfo( typeof( ElvenChainLegs ), 1200, 500, 15327, 0 ) );

////////////////////////////////////////////////////// Level 36
				Add( new GenericBuyInfo( typeof( RingmailArms ), 1300, 500, 0x13EE, 0 ) );
				Add( new GenericBuyInfo( typeof( RingmailChest ), 1300, 500, 0x13ec, 0 ) );
				Add( new GenericBuyInfo( typeof( RingmailGloves ), 1300, 500, 0x13eb, 0 ) );
				Add( new GenericBuyInfo( typeof( RingmailLegs ), 1300, 500, 0x13F0, 0 ) );

////////////////////////////////////////////////////// Level 39
				Add( new GenericBuyInfo( typeof( ScalemailArms ), 1400, 500, 15309, 0 ) );
				Add( new GenericBuyInfo( typeof( ScalemailChest ), 1400, 500, 15312, 0 ) );
				Add( new GenericBuyInfo( typeof( ScalemailGloves ), 1400, 500, 15313, 0 ) );
				Add( new GenericBuyInfo( typeof( ScalemailGorget ), 1400, 500, 15314, 0 ) );
				Add( new GenericBuyInfo( typeof( ScalemailLegs ), 1400, 500, 15315, 0 ) );

////////////////////////////////////////////////////// Shields
				Add( new GenericBuyInfo( typeof( Buckler ), 100, 500, 0x1B73, 0 ) ); // Level 1
				Add( new GenericBuyInfo( typeof( WoodenShield ), 200, 500, 0x1B7A, 0 ) ); // Level 3
				Add( new GenericBuyInfo( typeof( AmmoniteShield ), 300, 500, 14404, 0 ) ); // Level 6
				Add( new GenericBuyInfo( typeof( BronzeShield ), 400, 500, 0x1B72, 0 ) ); // Level 9
				Add( new GenericBuyInfo( typeof( MetalShield ), 500, 500, 0x1B7B, 0 ) ); // Level 12
				Add( new GenericBuyInfo( typeof( WoodenKiteShield ), 600, 500, 0x1B78, 0 ) ); // Level 15
				Add( new GenericBuyInfo( typeof( MetalKiteShield ), 700, 500, 0x1B74, 0 ) ); // Level 18
				Add( new GenericBuyInfo( typeof( ElvenShield ), 800, 500, 16361, 0 ) ); // Level 21
				Add( new GenericBuyInfo( typeof( InfantryShield ), 900, 500, 16359, 0 ) ); // Level 24
				Add( new GenericBuyInfo( typeof( SpiderShield ), 1000, 500, 14408, 0 ) ); // Level 27
				Add( new GenericBuyInfo( typeof( GrassShield ), 1100, 500, 14413, 0 ) ); // Level 30
				Add( new GenericBuyInfo( typeof( MercenaryShield ), 1200, 500, 14406, 0 ) ); // Level 33
				Add( new GenericBuyInfo( typeof( NymphShield ), 1300, 500, 14401, 0 ) ); // Level 36
				Add( new GenericBuyInfo( typeof( ScarabShield ), 1400, 500, 14414, 0 ) ); // Level 39

////////////////////////////////////////////////////// Unique Helmets
				Add( new GenericBuyInfo( typeof( RavenHelm ), 500, 500, 0x2B71, 0 ) );
				Add( new GenericBuyInfo( typeof( VultureHelm ), 500, 500, 0x2B72, 0 ) );
				Add( new GenericBuyInfo( typeof( WingedHelm ), 500, 500, 0x2B73, 0 ) );

				Add( new GenericBuyInfo( typeof( Circlet ), 800, 500, 0x2B6E, 0 ) );
				Add( new GenericBuyInfo( typeof( RoyalCirclet ), 800, 500, 0x2B6F, 0 ) );
				Add( new GenericBuyInfo( typeof( GemmedCirclet ), 800, 500, 0x2B70, 0 ) );
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
