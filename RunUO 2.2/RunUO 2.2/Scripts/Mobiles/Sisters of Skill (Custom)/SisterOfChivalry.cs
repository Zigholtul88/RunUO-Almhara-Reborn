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
	public class SisterOfChivalry : BaseVendor
	{
		private List<SBInfo> m_SBInfos = new List<SBInfo>(); 
		protected override List<SBInfo> SBInfos{ get { return m_SBInfos; } } 

                public override bool IsInvulnerable{ get{ return true; } }
		public override bool CanTeach { get { return true; } }

		[Constructable]
		public SisterOfChivalry() : base( "the Scarlet Sister of Chivalry" ) 
		{
                }

		public override void InitSBInfo() 
		{ 
			m_SBInfos.Add( new SBSisterOfChivalry() ); 
		}

		public override void InitOutfit()
		{
			Name = "Kasslenn Yharnam";
                 	Body = 401;
                        Female = true;
                        Race = Race.Human;
                        Hue = 33815;
                        HairItemID = 8261;
                        HairHue = 18;

			SetSkill( SkillName.Chivalry, 120.0 );

			FemalePlateChest chest = new FemalePlateChest(); 
			chest.Hue = 2662; 
			chest.Movable = false; 
			AddItem( chest );

			PlateGloves gloves = new PlateGloves(); 
			gloves.Hue = 2662; 
			gloves.Movable = false; 
			AddItem( gloves );

			PlateLegs legs = new PlateLegs(); 
			legs.Hue = 2662; 
			legs.Movable = false; 
			AddItem( legs );

			CloakOfHumility cloak = new CloakOfHumility(); 
			cloak.Hue = 2533; 
			cloak.Movable = false; 
			AddItem( cloak );

			WoodlandBelt belt = new WoodlandBelt(); 
			belt.Hue = 2533; 
			belt.Movable = false; 
			AddItem( belt ); 
                }

		public SisterOfChivalry( Serial serial ) : base( serial )
		{
		}

		public override void GetContextMenuEntries( Mobile from, List<ContextMenuEntry> list ) 
		{
			base.GetContextMenuEntries( from, list );
			list.Add( new SisterOfChivalryEntry( from, this ) );
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

		public class SisterOfChivalryEntry : ContextMenuEntry
		{
			private Mobile m_Mobile;
			private Mobile m_Giver;
			
			public SisterOfChivalryEntry( Mobile from, Mobile giver ) : base( 6146, 3 )
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

	public class SBSisterOfChivalry : SBInfo
	{
		private List<GenericBuyInfo> m_BuyInfo = new InternalBuyInfo();
		private IShopSellInfo m_SellInfo = new InternalSellInfo();

		public SBSisterOfChivalry()
		{
		}

		public override IShopSellInfo SellInfo { get { return m_SellInfo; } }
		public override List<GenericBuyInfo> BuyInfo { get { return m_BuyInfo; } }

		public class InternalBuyInfo : List<GenericBuyInfo>
		{
			public InternalBuyInfo()
			{
				Add( new GenericBuyInfo( "Scarlet Band Of Chivalry", typeof( ScarletBandOfChivalry ), 500, 10, 0x1F06, 1608 ) );
				Add( new GenericBuyInfo( typeof( BookOfChivalry ), 100, 20, 0x2252, 0 ) );
			}
		}

		public class InternalSellInfo : GenericSellInfo
		{
			public InternalSellInfo()
			{
				Add( typeof( ScarletBandOfChivalry ), 250 );
			}
		}
	}
}