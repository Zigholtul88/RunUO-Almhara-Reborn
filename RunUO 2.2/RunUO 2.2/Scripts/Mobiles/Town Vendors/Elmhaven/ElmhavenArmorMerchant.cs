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
	public class ElmhavenArmorMerchant : BaseVendor
	{
		private List<SBInfo> m_SBInfos = new List<SBInfo>();
		protected override List<SBInfo> SBInfos{ get { return m_SBInfos; } }

		[Constructable]
		public ElmhavenArmorMerchant() : base( "the armor merchant" )
		{
                }

		public override void InitSBInfo()
		{
			m_SBInfos.Add( new SBElmhavenArmorMerchant() );
		}

		public override void InitOutfit()
		{
			Name = "Lorenzo";
                 	Body = 400;
                        Female = false;
                        Race = Race.Human;
                        Hue = 33794;
                        HairItemID = 8255;
                        HairHue = 1153;
                        FacialHairItemID = 8267;
                        FacialHairHue = 1153;

			SetStr( 143 );
			SetDex( 100 );
			SetInt( 42 );

			SetSkill( SkillName.Anatomy, 60.0, 83.0 );
			SetSkill( SkillName.ArmsLore, 64.0, 100.0 );
			SetSkill( SkillName.Tactics, 60.0, 83.0 );
			SetSkill( SkillName.Parry, 61.0, 93.0 );
			SetSkill( SkillName.Wrestling, 60.0, 83.0 );

			PackGold( 13, 27 );

			AddItem( new Boots() );

			StuddedArms arms = new StuddedArms();
			arms.Movable = true;
			AddItem( arms );

			StuddedChest chest = new StuddedChest();
			chest.Movable = true;
			AddItem( chest );

			StuddedGloves gloves = new StuddedGloves();
			gloves.Movable = true;
			AddItem( gloves );

			StuddedGorget gorget = new StuddedGorget();
			gorget.Movable = true;
			AddItem( gorget );

			StuddedLegs legs = new StuddedLegs();
			legs.Movable = true;
			AddItem( legs );
                }

		public ElmhavenArmorMerchant( Serial serial ) : base( serial )
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

	public class SBElmhavenArmorMerchant : SBInfo
	{
		private List<GenericBuyInfo> m_BuyInfo = new InternalBuyInfo();
		private IShopSellInfo m_SellInfo = new InternalSellInfo();

		public SBElmhavenArmorMerchant()
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

////////////////////////////////////////////////////// Shields
				Add( new GenericBuyInfo( typeof( Buckler ), 100, 500, 0x1B73, 0 ) ); // Level 1
				Add( new GenericBuyInfo( typeof( WoodenShield ), 200, 500, 0x1B7A, 0 ) ); // Level 3
				Add( new GenericBuyInfo( typeof( AmmoniteShield ), 300, 500, 14404, 0 ) ); // Level 6
				Add( new GenericBuyInfo( typeof( BronzeShield ), 400, 500, 0x1B72, 0 ) ); // Level 9
				Add( new GenericBuyInfo( typeof( MetalShield ), 500, 500, 0x1B7B, 0 ) ); // Level 12
				Add( new GenericBuyInfo( typeof( WoodenKiteShield ), 600, 500, 0x1B78, 0 ) ); // Level 15
				Add( new GenericBuyInfo( typeof( MetalKiteShield ), 700, 500, 0x1B74, 0 ) ); // Level 18
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
