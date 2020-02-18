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
	public class ElmhavenArchitect : BaseVendor 
	{ 
		private List<SBInfo> m_SBInfos = new List<SBInfo>(); 
		protected override List<SBInfo> SBInfos{ get { return m_SBInfos; } } 


		[Constructable]
		public ElmhavenArchitect() : base( "the architect" ) 
		{ 
		} 

		public override void InitSBInfo() 
		{ 
			m_SBInfos.Add( new SBElmhavenArchitect() ); 
		}

		public override void InitOutfit()
		{
			Name = "Raglurr";
                 	Body = 400;
                  Female = false;
                  Race = Race.Human;
                  Hue = 33793;
                  HairItemID = 8251;
                  HairHue = 1110;
                  FacialHairItemID = 8255;
                  FacialHairHue = 1110;

			SetStr( 156 );
			SetDex( 98 );
			SetInt( 67 );

			SetSkill( SkillName.Anatomy, 60.0, 83.0 );
			SetSkill( SkillName.Tactics, 60.0, 83.0 );
			SetSkill( SkillName.Wrestling, 60.0, 83.0 );

			PackGold( 40, 80 );

			AddItem( new ReinassanceShirt(858) );
			AddItem( new ReinassancePants(888) );
			AddItem( new LightBoots(823) );
            }

		public ElmhavenArchitect( Serial serial ) : base( serial ) 
		{ 
		} 

		public override void GetContextMenuEntries( Mobile from, List<ContextMenuEntry> list ) 
		{
			base.GetContextMenuEntries( from, list );
			list.Add( new ElmhavenArchitectEntry( from, this ) );
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

		public class ElmhavenArchitectEntry : ContextMenuEntry
		{
			private Mobile m_Mobile;
			private Mobile m_Giver;
			
			public ElmhavenArchitectEntry( Mobile from, Mobile giver ) : base( 6146, 3 )
			{
				m_Mobile = from;
				m_Giver = giver;
			}
			
			public override void OnClick()
			{
				
				
				if( !( m_Mobile is PlayerMobile ) )
					return;
				
				PlayerMobile mobile = (PlayerMobile) m_Mobile;
				
				{
					if ( ! mobile.HasGump( typeof( ElmhavenArchitectGump ) ) )
					{
						mobile.SendGump( new ElmhavenArchitectGump( mobile ));
						
					}
				}
			}
		}

	public class SBElmhavenArchitect : SBInfo
	{
		private List<GenericBuyInfo> m_BuyInfo = new InternalBuyInfo();
		private IShopSellInfo m_SellInfo = new InternalSellInfo();

		public SBElmhavenArchitect()
		{
		}

		public override IShopSellInfo SellInfo { get { return m_SellInfo; } }
		public override List<GenericBuyInfo> BuyInfo { get { return m_BuyInfo; } }

		public class InternalBuyInfo : List<GenericBuyInfo>
		{
			public InternalBuyInfo()
			{
				Add( new GenericBuyInfo( "1041280", typeof( InteriorDecorator ), 10000, 20, 0xFC1, 0 ) );
				Add( new GenericBuyInfo( "1060651", typeof( HousePlacementTool ), 1000, 20, 0x14F6, 0 ));
			}
		}

		public class InternalSellInfo : GenericSellInfo
		{
			public InternalSellInfo()
			{
				Add( typeof( InteriorDecorator ), 5000 );
				Add( typeof( HousePlacementTool ), 500 );

			}
		}
	}
}
