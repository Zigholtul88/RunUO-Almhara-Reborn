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
	public class ElmhavenHairstylist : BaseVendor
	{
		private List<SBInfo> m_SBInfos = new List<SBInfo>();
		protected override List<SBInfo> SBInfos{ get { return m_SBInfos; } }


		[Constructable]
		public ElmhavenHairstylist() : base( "the hair stylist" )
		{
		}

		public override void InitSBInfo()
		{
			m_SBInfos.Add( new SBElmhavenHairstylist() );
		}

		public override void InitOutfit()
		{
			Name = "Azuralin";
                 	Body = 401;
                  Female = true;
                  Race = Race.Human;
                  Hue = 33791;
                  HairItemID = 8262;
                  HairHue = 1110;

			SetStr( 137 );
			SetDex( 104 );
			SetInt( 42 );

			SetSkill( SkillName.Anatomy, 60.0, 83.0 );
			SetSkill( SkillName.ArmsLore, 64.0, 100.0 );
			SetSkill( SkillName.Tactics, 60.0, 83.0 );
			SetSkill( SkillName.Wrestling, 60.0, 83.0 );

			PackGold( 58, 78 );

			AddItem( new BodySash(658) );
			AddItem( new CommonerDress(648) );
			AddItem( new LightBoots(893) );
            }

		public ElmhavenHairstylist( Serial serial ) : base( serial )
		{
		}

		public override void GetContextMenuEntries( Mobile from, List<ContextMenuEntry> list ) 
		{
			base.GetContextMenuEntries( from, list );
			list.Add( new ElmhavenHairstylistEntry( from, this ) );
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

		public class ElmhavenHairstylistEntry : ContextMenuEntry
		{
			private Mobile m_Mobile;
			private Mobile m_Giver;
			
			public ElmhavenHairstylistEntry( Mobile from, Mobile giver ) : base( 6146, 3 )
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
					if ( ! mobile.HasGump( typeof( ElmhavenHairstylistGump ) ) )
					{
						mobile.SendGump( new ElmhavenHairstylistGump( mobile ));
						
					}
				}
			}
		}

	public class SBElmhavenHairstylist : SBInfo 
	{ 
		private List<GenericBuyInfo> m_BuyInfo = new InternalBuyInfo(); 
		private IShopSellInfo m_SellInfo = new InternalSellInfo(); 

		public SBElmhavenHairstylist() 
		{ 
		} 

		public override IShopSellInfo SellInfo { get { return m_SellInfo; } } 
		public override List<GenericBuyInfo> BuyInfo { get { return m_BuyInfo; } } 

		public class InternalBuyInfo : List<GenericBuyInfo> 
		{ 
			public InternalBuyInfo() 
			{ 
				Add( new GenericBuyInfo( "1041060", typeof( HairDye ), 50, 20, 0xEFF, 0 ) ); 
				Add( new GenericBuyInfo( "special hair dye",  typeof( SpecialHairDye ), 100, 20, 0xE26, 0 ) ); 
				Add( new GenericBuyInfo( "special beard dye", typeof( SpecialBeardDye ), 100, 20, 0xE26, 0 ) );

 				Add( new GenericBuyInfo( "hair restyling deed",  typeof( HairRestylingDeed ), 300, 20, 0x14F0, 0 ) ); 

			} 
		} 

		public class InternalSellInfo : GenericSellInfo 
		{ 
			public InternalSellInfo() 
			{ 
				Add( typeof( SpecialHairDye ), 50 ); 
				Add( typeof( SpecialBeardDye ), 50 ); 
			} 
		} 
	} 
}
