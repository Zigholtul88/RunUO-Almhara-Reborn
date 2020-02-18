using System;
using System.Collections;
using System.Collections.Generic;
using Server;
using Server.Items;
using Server.Targeting;
using Server.Commands;
using Server.ContextMenus;
using Server.Gumps;
using Server.Misc;
using Server.Network;
using Server.Spells;
using Server.Mobiles;

namespace Server.Mobiles
{
	public class SkaddriaArmorMerchant : BaseVendor
	{
		private List<SBInfo> m_SBInfos = new List<SBInfo>();
		protected override List<SBInfo> SBInfos{ get { return m_SBInfos; } }

		public override bool InitialInnocent{ get{ return true; } }
		public override bool CanTeach { get { return true; } }

		[Constructable]
		public SkaddriaArmorMerchant() : base( "the armor merchant" )
		{
                }

		public override void InitSBInfo()
		{
			m_SBInfos.Add( new SBSkaddriaArmorMerchant() );
		}

		public override void InitOutfit()
		{
			Name = "Gemma Underhill";
                 	Body = 400;
                        Female = false;
                        Race = Race.Human;
                        Hue = 33794;
                        HairItemID = 8264;
                        HairHue = 1153;
                        FacialHairItemID = 8267;
                        FacialHairHue = 1153;

			SetStr( 84 );
			SetDex( 46 );
			SetInt( 65 );

			SetSkill( SkillName.Tactics, 60.0, 83.0 );
			SetSkill( SkillName.Parry, 61.0, 93.0 );

			PackGold( 13, 27 );

			AddItem( new Boots() );

			LeatherArms arms = new LeatherArms();
			arms.Movable = true;
			AddItem( arms );

			LeatherChest chest = new LeatherChest();
			chest.Movable = true;
			AddItem( chest );

			LeatherGloves gloves = new LeatherGloves();
			gloves.Movable = true;
			AddItem( gloves );

			LeatherGorget gorget = new LeatherGorget();
			gorget.Movable = true;
			AddItem( gorget );

			LeatherLegs legs = new LeatherLegs();
			legs.Movable = true;
			AddItem( legs );
                }

		public SkaddriaArmorMerchant( Serial serial ) : base( serial )
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

	public class SBSkaddriaArmorMerchant : SBInfo
	{
		private List<GenericBuyInfo> m_BuyInfo = new InternalBuyInfo();
		private IShopSellInfo m_SellInfo = new InternalSellInfo();

		public SBSkaddriaArmorMerchant()
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

////////////////////////////////////////////////////// Shields
				Add( new GenericBuyInfo( typeof( Buckler ), 100, 500, 0x1B73, 0 ) ); // Level 1
				Add( new GenericBuyInfo( typeof( WoodenShield ), 200, 500, 0x1B7A, 0 ) ); // Level 3
				Add( new GenericBuyInfo( typeof( AmmoniteShield ), 300, 500, 14404, 0 ) ); // Level 6

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