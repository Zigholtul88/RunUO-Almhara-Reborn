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
	public class KameronKoveReagentSeller : BaseVendor 
	{ 
		private List<SBInfo> m_SBInfos = new List<SBInfo>(); 
		protected override List<SBInfo> SBInfos{ get { return m_SBInfos; } } 

		public override bool InitialInnocent{ get{ return true; } }
		public override bool CanTeach { get { return true; } }

		[Constructable]
		public KameronKoveReagentSeller() : base( "the reagent seller" ) 
		{ 
		} 

		public override void InitSBInfo() 
		{ 
			m_SBInfos.Add( new SBKameronKoveReagentSeller() ); 
		}

		public override void InitOutfit()
		{
			Hue = Utility.RandomList( 3,28,38,48,53,58,63,88,93 );

			SetStr( 242 );
			SetDex( 199 );
			SetInt( 292 );

			SetSkill( SkillName.Anatomy, 60.0, 83.0 );
			SetSkill( SkillName.Tactics, 60.0, 83.0 );
			SetSkill( SkillName.Wrestling, 60.0, 83.0 );
			SetSkill( SkillName.Alchemy, 85.0, 100.0 );
			SetSkill( SkillName.TasteID, 65.0, 88.0 );

			PackGold( 44, 88 );

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

		public KameronKoveReagentSeller( Serial serial ) : base( serial ) 
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

	public class SBKameronKoveReagentSeller : SBInfo
	{
		private List<GenericBuyInfo> m_BuyInfo = new InternalBuyInfo();
		private IShopSellInfo m_SellInfo = new InternalSellInfo();

		public SBKameronKoveReagentSeller()
		{
		}

		public override IShopSellInfo SellInfo { get { return m_SellInfo; } }
		public override List<GenericBuyInfo> BuyInfo { get { return m_BuyInfo; } }

		public class InternalBuyInfo : List<GenericBuyInfo>
		{
			public InternalBuyInfo()
			{
				Add( new GenericBuyInfo( "Reagent Harvesting Axe", typeof( ReagentAxe ), 100, 999, 0xF43, 64 ) );
				Add( new GenericBuyInfo( "Bag of Reagents", typeof( BagOfReagents ), 5000, 20, 0xE76, 0 ) );

				Add( new GenericBuyInfo( typeof( BlackPearl ), 5, 999, 0xF7A, 0 ) );
				Add( new GenericBuyInfo( typeof( Bloodmoss ), 5, 999, 0xF7B, 0 ) );
				Add( new GenericBuyInfo( typeof( Garlic ), 5, 999, 0xF84, 0 ) );
				Add( new GenericBuyInfo( typeof( Ginseng ), 5, 999, 0xF85, 0 ) );
				Add( new GenericBuyInfo( typeof( MandrakeRoot ), 5, 999, 0xF86, 0 ) );
				Add( new GenericBuyInfo( typeof( Nightshade ), 5, 999, 0xF88, 0 ) );
				Add( new GenericBuyInfo( typeof( SpidersSilk ), 5, 999, 0xF8D, 0 ) );
				Add( new GenericBuyInfo( typeof( SulfurousAsh ), 5, 999, 0xF8C, 0 ) );
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
