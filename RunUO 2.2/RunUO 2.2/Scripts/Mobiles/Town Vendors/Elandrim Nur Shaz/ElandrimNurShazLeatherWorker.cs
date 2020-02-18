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
	public class ElandrimNurShazLeatherWorker : BaseVendor 
	{ 
		private List<SBInfo> m_SBInfos = new List<SBInfo>(); 
		protected override List<SBInfo> SBInfos{ get { return m_SBInfos; } } 


		[Constructable]
		public ElandrimNurShazLeatherWorker() : base( "the leather worker" ) 
		{ 
		} 

		public override void InitSBInfo() 
		{ 
			m_SBInfos.Add( new SBElandrimNurShazLeatherWorker() ); 
		}

		public override void InitOutfit()
		{
			Name = "Horis Bartomello";
                 	Body = 605;
                  Female = false;
                  Race = Race.Elf;
                  Hue = 1024;
                  HairItemID = 12225;
                  HairHue = 2216;
                  FacialHairItemID = 0;
                  FacialHairHue = 0;

			SetStr( 268 );
			SetDex( 247 );
			SetInt( 201 );

			SetSkill( SkillName.Anatomy, 60.0, 83.0 );
			SetSkill( SkillName.Tactics, 60.0, 83.0 );
			SetSkill( SkillName.Wrestling, 60.0, 83.0 );

			PackGold( 32, 65 );

			AddItem( new HakamaShita(538) );
			AddItem( new Hakama(738) );
			AddItem( new Waraji(828) );
            }

		public ElandrimNurShazLeatherWorker( Serial serial ) : base( serial ) 
		{ 
		} 

		public override void GetContextMenuEntries( Mobile from, List<ContextMenuEntry> list ) 
		{
			base.GetContextMenuEntries( from, list );
			list.Add( new ElandrimNurShazLeatherWorkerEntry( from, this ) );
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

		public class ElandrimNurShazLeatherWorkerEntry : ContextMenuEntry
		{
			private Mobile m_Mobile;
			private Mobile m_Giver;
			
			public ElandrimNurShazLeatherWorkerEntry( Mobile from, Mobile giver ) : base( 6146, 3 )
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
					if ( ! mobile.HasGump( typeof( ElandrimNurShazLeatherWorkerGump ) ) )
					{
						mobile.SendGump( new ElandrimNurShazLeatherWorkerGump( mobile ));
						
					}
				}
			}
		}

	public class SBElandrimNurShazLeatherWorker : SBInfo
	{
		private List<GenericBuyInfo> m_BuyInfo = new InternalBuyInfo();
		private IShopSellInfo m_SellInfo = new InternalSellInfo();

		public SBElandrimNurShazLeatherWorker()
		{
		}

		public override IShopSellInfo SellInfo { get { return m_SellInfo; } }
		public override List<GenericBuyInfo> BuyInfo { get { return m_BuyInfo; } }

		public class InternalBuyInfo : List<GenericBuyInfo>
		{
			public InternalBuyInfo()
			{
				Add( new GenericBuyInfo( "1041279", typeof( TaxidermyKit ), 5000, 20, 0x1EBA, 0 ) );

			}
		}

		public class InternalSellInfo : GenericSellInfo
		{
			public InternalSellInfo()
			{
				Add( typeof( Leather ), 25 );	
				Add( typeof( SpinedLeather ), 35 );				
				Add( typeof( HornedLeather ), 45 );				
				Add( typeof( BarbedLeather ), 60 );				
			}
		}
	}
}
