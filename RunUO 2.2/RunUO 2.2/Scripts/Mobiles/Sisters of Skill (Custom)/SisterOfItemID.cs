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
	public class SisterOfItemID : BaseVendor
	{
		private List<SBInfo> m_SBInfos = new List<SBInfo>(); 
		protected override List<SBInfo> SBInfos{ get { return m_SBInfos; } } 

                public override bool IsInvulnerable{ get{ return true; } }
		public override bool CanTeach { get { return true; } }

		[Constructable]
		public SisterOfItemID() : base( "the Scarlet Sister of Item ID" ) 
		{
                }

		public override void InitSBInfo() 
		{ 
			m_SBInfos.Add( new SBSisterOfItemID() ); 
		}

		public override void InitOutfit()
		{
			Name = "Umarelina";
                 	Body = 401;
                        Female = true;
                        Race = Race.Human;
                        Hue = 1002;
                        HairItemID = 12224;
                        HairHue = 44;

			SetStr( 117 );
			SetDex( 96 );
			SetInt( 54 );

			SetSkill( SkillName.ItemID, 120.0 );

			AddItem( new MedievalLongDress(518) );
			AddItem( new ThighBoots(768) );
                }

		public SisterOfItemID( Serial serial ) : base( serial )
		{
		}

		public override void GetContextMenuEntries( Mobile from, List<ContextMenuEntry> list ) 
		{
			base.GetContextMenuEntries( from, list );
			list.Add( new SisterOfItemIDEntry( from, this ) );
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

		public class SisterOfItemIDEntry : ContextMenuEntry
		{
			private Mobile m_Mobile;
			private Mobile m_Giver;
			
			public SisterOfItemIDEntry( Mobile from, Mobile giver ) : base( 6146, 3 )
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
					if ( ! mobile.HasGump( typeof( SisterOfSkillGump ) ) )
					{
						mobile.SendGump( new SisterOfSkillGump( mobile ));	
					}
				}
			}
		}
        }

	public class SBSisterOfItemID : SBInfo
	{
		private List<GenericBuyInfo> m_BuyInfo = new InternalBuyInfo();
		private IShopSellInfo m_SellInfo = new InternalSellInfo();

		public SBSisterOfItemID()
		{
		}

		public override IShopSellInfo SellInfo { get { return m_SellInfo; } }
		public override List<GenericBuyInfo> BuyInfo { get { return m_BuyInfo; } }

		public class InternalBuyInfo : List<GenericBuyInfo>
		{
			public InternalBuyInfo()
			{
				Add( new GenericBuyInfo( "Scarlet Band Of Item ID", typeof( ScarletBandOfItemID ), 500, 10, 0x1F06, 1608 ) );
			}
		}

		public class InternalSellInfo : GenericSellInfo
		{
			public InternalSellInfo()
			{
				Add( typeof( ScarletBandOfItemID ), 250 );
			}
		}
	}
}