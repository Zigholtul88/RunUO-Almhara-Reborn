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
	public class ElmhavenTinker : BaseVendor 
	{ 
		private List<SBInfo> m_SBInfos = new List<SBInfo>(); 
		protected override List<SBInfo> SBInfos{ get { return m_SBInfos; } } 

		public override bool InitialInnocent{ get{ return true; } }
		public override bool CanTeach { get { return true; } }

		[Constructable]
		public ElmhavenTinker() : base( "the tinker" ) 
		{ 
		} 

		public override void InitSBInfo() 
		{ 
			m_SBInfos.Add( new SBElmhavenTinker() ); 
		}

		public override void InitOutfit()
		{
			Name = "Imus Grant";
                 	Body = 400;
                        Female = false;
                        Race = Race.Human;
                        Hue = 33807;
                        HairItemID = 8253;
                        HairHue = 1116;
                        FacialHairItemID = 8269;
                        FacialHairHue = 1116;

			SetStr( 134 );
			SetDex( 103 );
			SetInt( 47 );

			SetSkill( SkillName.Anatomy, 60.0, 83.0 );
			SetSkill( SkillName.Lockpicking, 60.0, 83.0 );
			SetSkill( SkillName.RemoveTrap, 75.0, 98.0 );
			SetSkill( SkillName.Tactics, 60.0, 83.0 );
			SetSkill( SkillName.Tinkering, 64.0, 100.0 );
			SetSkill( SkillName.Wrestling, 60.0, 83.0 );

			PackGold( 21, 64 );

			AddItem( new Shirt(738) );
			AddItem( new LongPants(703) );
			AddItem( new HalfApron(823) );
			AddItem( new Shoes(738) );
                }

		public ElmhavenTinker( Serial serial ) : base( serial ) 
		{ 
		}

		public override void GetContextMenuEntries( Mobile from, List<ContextMenuEntry> list ) 
		{
			base.GetContextMenuEntries( from, list );
			list.Add( new ElmhavenTinkerEntry( from, this ) );
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

		public class ElmhavenTinkerEntry : ContextMenuEntry
		{
			private Mobile m_Mobile;
			private Mobile m_Giver;
			
			public ElmhavenTinkerEntry( Mobile from, Mobile giver ) : base( 6146, 3 )
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
					if ( ! mobile.HasGump( typeof( ElmhavenTinkerGump ) ) )
					{
						mobile.SendGump( new ElmhavenTinkerGump( mobile ));	
					}
				}
			}
		}
        }

	public class SBElmhavenTinker : SBInfo
	{
		private List<GenericBuyInfo> m_BuyInfo = new InternalBuyInfo();
		private IShopSellInfo m_SellInfo = new InternalSellInfo();

		public SBElmhavenTinker()
		{
		}

		public override IShopSellInfo SellInfo { get { return m_SellInfo; } }
		public override List<GenericBuyInfo> BuyInfo { get { return m_BuyInfo; } }

		public class InternalBuyInfo : List<GenericBuyInfo>
		{
			public InternalBuyInfo()
			{
				Add( new GenericBuyInfo( "Amelias Toolbox", typeof( AmeliasToolbox ), 1500, 200, 0x1EBC, 1895 ) );

				Add( new GenericBuyInfo( typeof( TinkersTools ), 100, 500, 0x1EBC, 0 ) );

				Add( new GenericBuyInfo( typeof( Clock ), 22, 20, 0x104B, 0 ) );
				Add( new GenericBuyInfo( typeof( ClockParts ), 5, 500, 0x104F, 0 ) );
				Add( new GenericBuyInfo( typeof( AxleGears ), 5, 500, 0x1051, 0 ) );
				Add( new GenericBuyInfo( typeof( Gears ), 5, 500, 0x1053, 0 ) );
				Add( new GenericBuyInfo( typeof( Hinge ), 5, 500, 0x1055, 0 ) );

				Add( new GenericBuyInfo( typeof( Sextant ), 13, 48, 0x1057, 0 ) );
				Add( new GenericBuyInfo( typeof( SextantParts ), 5, 79, 0x1059, 0 ) );
				Add( new GenericBuyInfo( typeof( Axle ), 5, 250, 0x105B, 0 ) );
				Add( new GenericBuyInfo( typeof( Springs ), 5, 300, 0x105D, 0 ) );

				Add( new GenericBuyInfo( "1024111", typeof( Key ), 8, 20, 0x100F, 0 ) );
				Add( new GenericBuyInfo( "1024112", typeof( Key ), 8, 20, 0x1010, 0 ) );
				Add( new GenericBuyInfo( "1024115", typeof( Key ), 8, 20, 0x1013, 0 ) );
				Add( new GenericBuyInfo( typeof( KeyRing ), 8, 20, 0x1010, 0 ) );
			}
		}

		public class InternalSellInfo : GenericSellInfo
		{
			public InternalSellInfo()
			{
				Add( typeof( Key ), 1 );

				Add( typeof( Clock ), 11 );
				Add( typeof( ClockParts ), 5 );
				Add( typeof( AxleGears ), 5 );
				Add( typeof( Gears ), 5 );
				Add( typeof( Hinge ), 5 );
				Add( typeof( Sextant ), 6 );
				Add( typeof( SextantParts ), 2 );
				Add( typeof( Axle ), 5 );
				Add( typeof( Springs ), 5 );

				Add( typeof( TinkerTools ), 12 );
			}
		}
	}
}
