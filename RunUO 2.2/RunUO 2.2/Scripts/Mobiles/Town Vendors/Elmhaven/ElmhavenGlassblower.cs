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
	public class ElmhavenGlassblower : BaseVendor 
	{ 
		private List<SBInfo> m_SBInfos = new List<SBInfo>(); 
		protected override List<SBInfo> SBInfos{ get { return m_SBInfos; } } 


		[Constructable]
		public ElmhavenGlassblower() : base( "the glassblower" ) 
		{ 
		} 

		public override void InitSBInfo() 
		{ 
			m_SBInfos.Add( new SBElmhavenGlassblower() ); 
		}

		public override void InitOutfit()
		{
			Name = "Vairon";
                 	Body = 400;
                  Female = false;
                  Race = Race.Human;
                  Hue = 33770;
                  HairItemID = 8260;
                  HairHue = 1126;
                  FacialHairItemID = 8257;
                  FacialHairHue = 1126;

			SetStr( 126 );
			SetDex( 109 );
			SetInt( 38 );

			SetSkill( SkillName.Alchemy, 85.0, 100.0 );
			SetSkill( SkillName.Tactics, 60.0, 83.0 );
			SetSkill( SkillName.TasteID, 85.0, 100.0 );
			SetSkill( SkillName.Wrestling, 60.0, 83.0 );

			PackGold( 47, 82 );

			AddItem( new ReinassanceShirt(763) );
			AddItem( new FullApron(768) );
			AddItem( new ShortPants(763) );
			AddItem( new Boots(863) );

			LeatherGloves gloves = new LeatherGloves();
			gloves.Hue = 2209;
			gloves.Movable = true;
			AddItem( gloves );
            }

		public ElmhavenGlassblower( Serial serial ) : base( serial ) 
		{ 
		}

		public override void GetContextMenuEntries( Mobile from, List<ContextMenuEntry> list ) 
		{
			base.GetContextMenuEntries( from, list );
			list.Add( new ElmhavenGlassblowerEntry( from, this ) );
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

		public class ElmhavenGlassblowerEntry : ContextMenuEntry
		{
			private Mobile m_Mobile;
			private Mobile m_Giver;
			
			public ElmhavenGlassblowerEntry( Mobile from, Mobile giver ) : base( 6146, 3 )
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
					if ( ! mobile.HasGump( typeof( ElmhavenGlassblowerGump ) ) )
					{
						mobile.SendGump( new ElmhavenGlassblowerGump( mobile ));
						
					}
				}
			}
		}

	public class SBElmhavenGlassblower : SBInfo
	{
		private List<GenericBuyInfo> m_BuyInfo = new InternalBuyInfo();
		private IShopSellInfo m_SellInfo = new InternalSellInfo();

		public SBElmhavenGlassblower()
		{
		}

		public override IShopSellInfo SellInfo { get { return m_SellInfo; } }
		public override List<GenericBuyInfo> BuyInfo { get { return m_BuyInfo; } }

		public class InternalBuyInfo : List<GenericBuyInfo>
		{
			public InternalBuyInfo()
			{
				Add( new GenericBuyInfo( typeof( Bottle ), 5, 999, 0xF0E, 0 ) ); 

				Add( new GenericBuyInfo( typeof( HeatingStand ), 2, 100, 0x1849, 0 ) ); 

				Add( new GenericBuyInfo( "Crafting Glass With Glassblowing", typeof( GlassblowingBook ), 5000, 30, 0xFF4, 0 ) );
				Add( new GenericBuyInfo( "Finding Glass-Quality Sand", typeof( SandMiningBook ), 5000, 30, 0xFF4, 0 ) );
				Add( new GenericBuyInfo( "1044608", typeof( Blowpipe ), 100, 100, 0xE8A, 0x3B9 ) );
			}
		}

		public class InternalSellInfo : GenericSellInfo
		{
			public InternalSellInfo()
			{
				Add( typeof( Bottle ), 2 );

				Add( typeof( HeatingStand ), 1 );

				Add( typeof( GlassblowingBook ), 2500 );
				Add( typeof( SandMiningBook ), 2500 );
				Add( typeof( Blowpipe ), 12 );
			}
		}
	}
}
