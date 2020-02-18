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
using Server.Mobiles;

namespace Server.Mobiles 
{ 
	public class RedDaggerKeepCartographer : BaseVendor 
	{ 
		private List<SBInfo> m_SBInfos = new List<SBInfo>(); 
		protected override List<SBInfo> SBInfos{ get { return m_SBInfos; } } 

		public override bool InitialInnocent{ get{ return true; } }

		[Constructable]
		public RedDaggerKeepCartographer() : base( "the cartographer" ) 
		{ 
		} 

		public override void InitSBInfo() 
		{ 
			m_SBInfos.Add( new SBRedDaggerKeepCartographer() ); 
		} 

		public override void InitOutfit()
		{
			Name = "Gavin";
                 	Body = 400;
                        Female = false;
                        Race = Race.Human;
                        Hue = 33808;
                        HairItemID = 8261;
                        HairHue = 1113;
                        FacialHairItemID = 8256;
                        FacialHairHue = 1113;

			SetStr( 300 );
			SetDex( 250 );
			SetInt( 200 );

			SetSkill( SkillName.Anatomy, 60.0, 83.0 );
			SetSkill( SkillName.Cartography, 90.0, 100.0 );
			SetSkill( SkillName.Tactics, 60.0, 83.0 );
			SetSkill( SkillName.Wrestling, 60.0, 83.0 );

			PackGold( 9, 28 );

			AddItem( new FurCape(788) );
			AddItem( new ReinassanceShirt(693) );
			AddItem( new ReinassancePants(788) );
			AddItem( new FurBoots(693) );
                }

		public RedDaggerKeepCartographer( Serial serial ) : base( serial ) 
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

	public class SBRedDaggerKeepCartographer: SBInfo 
	{ 
		private List<GenericBuyInfo> m_BuyInfo = new InternalBuyInfo(); 
		private IShopSellInfo m_SellInfo = new InternalSellInfo(); 

		public SBRedDaggerKeepCartographer() 
		{ 
		} 

		public override IShopSellInfo SellInfo { get { return m_SellInfo; } } 
		public override List<GenericBuyInfo> BuyInfo { get { return m_BuyInfo; } } 

		public class InternalBuyInfo : List<GenericBuyInfo> 
		{ 
			public InternalBuyInfo() 
			{ 
				Add( new GenericBuyInfo( typeof( BlankMap ), 5, 40, 0x14EC, 0 ) );
				Add( new GenericBuyInfo( typeof( MapmakersPen ), 8, 20, 0x0FBF, 0 ) );
				Add( new GenericBuyInfo( typeof( BlankScroll ), 12, 40, 0xEF3, 0 ) );
				
			} 
		} 

		public class InternalSellInfo : GenericSellInfo 
		{ 
			public InternalSellInfo() 
			{ 
				Add( typeof( BlankScroll ), 6 );
				Add( typeof( MapmakersPen ), 4 );
				Add( typeof( BlankMap ), 2 );
				Add( typeof( CityMap ), 3 );
				Add( typeof( LocalMap ), 3 );
				Add( typeof( WorldMap ), 3 );
				Add( typeof( PresetMapEntry ), 3 );
			} 
		} 
	} 
}
