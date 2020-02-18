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
using Server.ACC.CSS.Systems.Druid;

namespace Server.Mobiles 
{ 
	public class RedDaggerKeepReagentSeller1 : BaseVendor 
	{ 
		private List<SBInfo> m_SBInfos = new List<SBInfo>(); 
		protected override List<SBInfo> SBInfos{ get { return m_SBInfos; } } 

		public override bool InitialInnocent{ get{ return true; } }
		public override bool CanTeach { get { return true; } }

		[Constructable]
		public RedDaggerKeepReagentSeller1() : base( "the reagent seller" ) 
		{ 
		} 

		public override void InitSBInfo() 
		{ 
			m_SBInfos.Add( new SBRedDaggerKeepReagentSeller1() ); 
		}

		public override void InitOutfit()
		{
			Name = "Syskamore";
			Body = 28;
			BaseSoundID = 0x388;

			SetStr( 102 );
			SetDex( 87 );
			SetInt( 195 );

			SetDamageType( ResistanceType.Physical, 100 );

			SetResistance( ResistanceType.Physical, 16 );
			SetResistance( ResistanceType.Poison, 25 );

			SetSkill( SkillName.Anatomy, 60.0, 83.0 );
			SetSkill( SkillName.Poisoning, 60.4, 79.2 );
			SetSkill( SkillName.Tactics, 60.0, 83.0 );
			SetSkill( SkillName.Wrestling, 60.0, 83.0 );
			SetSkill( SkillName.Alchemy, 85.0, 100.0 );
			SetSkill( SkillName.TasteID, 65.0, 88.0 );

			PackGold( 44, 88 );

 			if ( Utility.RandomDouble() < 0.10 )
				PackItem( new CureScroll() );
                }

		public RedDaggerKeepReagentSeller1( Serial serial ) : base( serial ) 
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

	public class SBRedDaggerKeepReagentSeller1 : SBInfo
	{
		private List<GenericBuyInfo> m_BuyInfo = new InternalBuyInfo();
		private IShopSellInfo m_SellInfo = new InternalSellInfo();

		public SBRedDaggerKeepReagentSeller1()
		{
		}

		public override IShopSellInfo SellInfo { get { return m_SellInfo; } }
		public override List<GenericBuyInfo> BuyInfo { get { return m_BuyInfo; } }

		public class InternalBuyInfo : List<GenericBuyInfo>
		{
			public InternalBuyInfo()
			{
				Add( new GenericBuyInfo( "Mage's Pouch", typeof( MagesPouch ), 5000, 20, 0xE79, 0 ) );
				Add( new GenericBuyInfo( typeof( Pouch ), 25, 250, 0xE79, 0 ) );

				Add( new GenericBuyInfo( "Reagent Harvesting Axe", typeof( ReagentAxe ), 100, 999, 0xF43, 64 ) );

				Add( new GenericBuyInfo( typeof( BlackPearl ), 6, 999, 0xF7A, 0 ) );
				Add( new GenericBuyInfo( typeof( Bloodmoss ), 6, 999, 0xF7B, 0 ) );
				Add( new GenericBuyInfo( typeof( Garlic ), 6, 999, 0xF84, 0 ) );
				Add( new GenericBuyInfo( typeof( Ginseng ), 6, 999, 0xF85, 0 ) );
				Add( new GenericBuyInfo( typeof( MandrakeRoot ), 6, 999, 0xF86, 0 ) );
				Add( new GenericBuyInfo( typeof( Nightshade ), 6, 999, 0xF88, 0 ) );
				Add( new GenericBuyInfo( typeof( SpidersSilk ), 6, 999, 0xF8D, 0 ) );
				Add( new GenericBuyInfo( typeof( SulfurousAsh ), 6, 999, 0xF8C, 0 ) );
			}
		}

		public class InternalSellInfo : GenericSellInfo
		{
			public InternalSellInfo()
			{
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
