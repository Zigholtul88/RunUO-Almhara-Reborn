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
	public class ElmhavenStoneCrafter : BaseVendor 
	{ 
		private List<SBInfo> m_SBInfos = new List<SBInfo>(); 
		protected override List<SBInfo> SBInfos{ get { return m_SBInfos; } } 


		[Constructable]
		public ElmhavenStoneCrafter() : base( "the stone crafter" ) 
		{ 
		} 

		public override void InitSBInfo() 
		{ 
			m_SBInfos.Add( new SBElmhavenStoneCrafter() ); 
		}

		public override void InitOutfit()
		{
			Name = "Timothy";
                 	Body = 400;
                  Female = false;
                  Race = Race.Human;
                  Hue = 33791;
                  HairItemID = 8264;
                  HairHue = 1123;
                  FacialHairItemID = 8269;
                  FacialHairHue = 1123;

			SetStr( 153 );
			SetDex( 107 );
			SetInt( 42 );

			SetSkill( SkillName.Anatomy, 60.0, 83.0 );
			SetSkill( SkillName.Carpentry, 85.0, 100.0 );
			SetSkill( SkillName.Tactics, 60.0, 83.0 );
			SetSkill( SkillName.Wrestling, 60.0, 83.0 );

			PackGold( 54, 72 );

			AddItem( new Shirt(673) );
			AddItem( new FullApron(868) );
			AddItem( new ReinassancePants(563) );
			AddItem( new ShortBoots(863) );
            }

		public ElmhavenStoneCrafter( Serial serial ) : base( serial ) 
		{ 
		}

		public override void GetContextMenuEntries( Mobile from, List<ContextMenuEntry> list ) 
		{
			base.GetContextMenuEntries( from, list );
			list.Add( new ElmhavenStoneCrafterEntry( from, this ) );
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

		public class ElmhavenStoneCrafterEntry : ContextMenuEntry
		{
			private Mobile m_Mobile;
			private Mobile m_Giver;
			
			public ElmhavenStoneCrafterEntry( Mobile from, Mobile giver ) : base( 6146, 3 )
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
					if ( ! mobile.HasGump( typeof( ElmhavenStoneCrafterGump ) ) )
					{
						mobile.SendGump( new ElmhavenStoneCrafterGump( mobile ));
						
					}
				}
			}
		}

	public class SBElmhavenStoneCrafter : SBInfo
	{
		private List<GenericBuyInfo> m_BuyInfo = new InternalBuyInfo();
		private IShopSellInfo m_SellInfo = new InternalSellInfo();

		public SBElmhavenStoneCrafter()
		{
		}

		public override IShopSellInfo SellInfo { get { return m_SellInfo; } }
		public override List<GenericBuyInfo> BuyInfo { get { return m_BuyInfo; } }

		public class InternalBuyInfo : List<GenericBuyInfo>
		{
			public InternalBuyInfo()
			{
				Add( new GenericBuyInfo( "Making Valuables With Stonecrafting", typeof( MasonryBook ), 5000, 10, 0xFBE, 0 ) );
				Add( new GenericBuyInfo( "Mining For Quality Stone", typeof( StoneMiningBook ), 5000, 10, 0xFBE, 0 ) );
				Add( new GenericBuyInfo( "1044515", typeof( MalletAndChisel ), 100, 50, 0x12B3, 0 ) );
			}
		}

		public class InternalSellInfo : GenericSellInfo
		{
			public InternalSellInfo()
			{
				Add( typeof( MasonryBook ), 2500 );
				Add( typeof( StoneMiningBook ), 2500 );
				Add( typeof( MalletAndChisel ), 12 );
			}
		}
	}
}
