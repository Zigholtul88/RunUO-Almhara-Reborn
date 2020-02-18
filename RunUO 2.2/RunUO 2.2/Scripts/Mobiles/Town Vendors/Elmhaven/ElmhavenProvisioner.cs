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
using Server.Guilds;

namespace Server.Mobiles 
{ 
	public class ElmhavenProvisioner : BaseVendor 
	{ 
		private List<SBInfo> m_SBInfos = new List<SBInfo>(); 
		protected override List<SBInfo> SBInfos{ get { return m_SBInfos; } } 


		[Constructable]
		public ElmhavenProvisioner() : base( "the provisioner" ) 
		{ 
		} 

		public override void InitSBInfo() 
		{ 
			m_SBInfos.Add( new SBElmhavenProvisioner() ); 
		}

		public override void InitOutfit()
		{
			Name = "Morokail";
                 	Body = 400;
                        Female = false;
                        Race = Race.Human;
                        Hue = 33784;
                        HairItemID = 8252;
                        HairHue = 1120;
                        FacialHairItemID = 8257;
                        FacialHairHue = 1120;

			SetStr( 125 );
			SetDex( 101 );
			SetInt( 36 );

			SetSkill( SkillName.Anatomy, 60.0, 83.0 );
			SetSkill( SkillName.Camping, 45.0, 68.0 );
			SetSkill( SkillName.Tactics, 60.0, 83.0 );
			SetSkill( SkillName.Wrestling, 60.0, 83.0 );

			PackGold( 23, 31 );

			AddItem( new Shirt(898) );
			AddItem( new BodySash(783) );
			AddItem( new LongPants(838) );
			AddItem( new Shoes(903) );
                }

		public ElmhavenProvisioner( Serial serial ) : base( serial ) 
		{ 
		} 

		public override void GetContextMenuEntries( Mobile from, List<ContextMenuEntry> list ) 
		{
			base.GetContextMenuEntries( from, list );
			list.Add( new ElmhavenProvisionerEntry( from, this ) );
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

		public class ElmhavenProvisionerEntry : ContextMenuEntry
		{
			private Mobile m_Mobile;
			private Mobile m_Giver;
			
			public ElmhavenProvisionerEntry( Mobile from, Mobile giver ) : base( 6146, 3 )
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
					if ( ! mobile.HasGump( typeof( ElmhavenProvisionerGump ) ) )
					{
						mobile.SendGump( new ElmhavenProvisionerGump( mobile ));
					}
				}
			}
		}
        }

	public class SBElmhavenProvisioner : SBInfo
	{
		private List<GenericBuyInfo> m_BuyInfo = new InternalBuyInfo();
		private IShopSellInfo m_SellInfo = new InternalSellInfo();

		public SBElmhavenProvisioner()
		{
		}

		public override IShopSellInfo SellInfo { get { return m_SellInfo; } }
		public override List<GenericBuyInfo> BuyInfo { get { return m_BuyInfo; } }

		public class InternalBuyInfo : List<GenericBuyInfo>
		{
			public InternalBuyInfo()
			{
				Add( new GenericBuyInfo( typeof( Backpack ), 15, 250, 0x9B2, 0 ) );
				Add( new GenericBuyInfo( typeof( Pouch ), 6, 250, 0xE79, 0 ) );
				Add( new GenericBuyInfo( typeof( Bag ), 6, 250, 0xE76, 0 ) );
				
				Add( new GenericBuyInfo( typeof( Candle ), 6, 50, 0xA28, 0 ) );
				Add( new GenericBuyInfo( typeof( Torch ), 8, 50, 0xF6B, 0 ) );
				Add( new GenericBuyInfo( typeof( Lantern ), 2, 50, 0xA25, 0 ) );

				Add( new GenericBuyInfo( typeof( Lockpick ), 10, 999, 0x14FC, 0 ) );

				Add( new GenericBuyInfo( typeof( BreadLoaf ), 6, 69, 0x103B, 0 ) );

				Add( new BeverageBuyInfo( typeof( Jug ), BeverageType.Cider, 13, 45, 0x9C8, 0 ) );

				Add( new GenericBuyInfo( typeof( Beeswax ), 1, 79, 0x1422, 0 ) );

				Add( new GenericBuyInfo( typeof( Garlic ), 3, 999, 0xF84, 0 ) );
				Add( new GenericBuyInfo( typeof( Ginseng ), 3, 999, 0xF85, 0 ) );

				Add( new GenericBuyInfo( typeof( Bottle ), 5, 687, 0xF0E, 0 ) );

				Add( new GenericBuyInfo( typeof( RedBook ), 15, 20, 0xFF1, 0 ) );
				Add( new GenericBuyInfo( typeof( BlueBook ), 15, 20, 0xFF2, 0 ) );
				Add( new GenericBuyInfo( typeof( TanBook ), 15, 20, 0xFF0, 0 ) );

				Add( new GenericBuyInfo( typeof( WoodenBox ), 14, 100, 0xE7D, 0 ) );
				Add( new GenericBuyInfo( typeof( Key ), 2, 100, 0x100E, 0 ) );

				Add( new GenericBuyInfo( typeof( Bedroll ), 5, 35, 0xA59, 0 ) );
				Add( new GenericBuyInfo( typeof( Kindling ), 2, 99, 0xDE1, 0 ) );

				Add( new GenericBuyInfo( typeof( SmallBagBall ), 3, 30, 0x2256, 0 ) );
				Add( new GenericBuyInfo( typeof( LargeBagBall ), 3, 30, 0x2257, 0 ) );

				if( !Guild.NewGuildSystem )
					Add( new GenericBuyInfo( "1041055", typeof( GuildDeed ), 12450, 25, 0x14F0, 0 ) );
			}
		}

		public class InternalSellInfo : GenericSellInfo
		{
			public InternalSellInfo()
			{
				Add( typeof( Backpack ), 7 );
				Add( typeof( Pouch ), 3 );
				Add( typeof( Bag ), 3 );
				Add( typeof( Candle ), 3 );
				Add( typeof( Torch ), 4 );
				Add( typeof( Lantern ), 1 );

				Add( typeof( Lockpick ), 5 );

				Add( typeof( RedBook ), 7 );
				Add( typeof( BlueBook ), 7 );
				Add( typeof( TanBook ), 7 );
				Add( typeof( WoodenBox ), 7 );
				Add( typeof( Kindling ), 1 );

				Add( typeof( Beeswax ), 1 );

				if( !Guild.NewGuildSystem )
					Add( typeof( GuildDeed ), 6225 );
			}
		}
	}
}
