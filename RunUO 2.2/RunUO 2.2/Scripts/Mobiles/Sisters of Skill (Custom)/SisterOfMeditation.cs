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
	public class SisterOfMeditation : BaseVendor
	{
		private List<SBInfo> m_SBInfos = new List<SBInfo>(); 
		protected override List<SBInfo> SBInfos{ get { return m_SBInfos; } } 

                public override bool IsInvulnerable{ get{ return true; } }
		public override bool CanTeach { get { return true; } }

		[Constructable]
		public SisterOfMeditation() : base( "the Scarlet Sister of Meditation" ) 
		{
                }

		public override void InitSBInfo() 
		{ 
			m_SBInfos.Add( new SBSisterOfMeditation() ); 
		}

		public override void InitOutfit()
		{
			Name = "Sorastia Vina";
                 	Body = 401;
                        Female = true;
                        Race = Race.Human;
                        Hue = 33775;
                        HairItemID = 8252;
                        HairHue = 1109;

			SetSkill( SkillName.Meditation, 120.0 );

			LeatherBustierArms chest = new LeatherBustierArms(); 
			chest.Hue = 2211; 
			chest.Movable = false; 
			AddItem( chest );

			LeatherArms arms = new LeatherArms(); 
			arms.Hue = 2211; 
			arms.Movable = false; 
			AddItem( arms );

			LeatherGloves gloves = new LeatherGloves(); 
			gloves.Hue = 2211; 
			gloves.Movable = false; 
			AddItem( gloves );

			LeatherShorts legs = new LeatherShorts(); 
			legs.Hue = 2211; 
			legs.Movable = false; 
			AddItem( legs );

			CloakOfHumility cloak = new CloakOfHumility(); 
			cloak.Hue = 658; 
			cloak.Movable = false; 
			AddItem( cloak );

			WoodlandBelt belt = new WoodlandBelt(); 
			belt.Hue = 658; 
			belt.Movable = false; 
			AddItem( belt ); 

			AddItem( new ThighBoots(658) );
                }

		public SisterOfMeditation( Serial serial ) : base( serial )
		{
		}

		public override void GetContextMenuEntries( Mobile from, List<ContextMenuEntry> list ) 
		{
			base.GetContextMenuEntries( from, list );
			list.Add( new SisterOfMeditationEntry( from, this ) );
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

		public class SisterOfMeditationEntry : ContextMenuEntry
		{
			private Mobile m_Mobile;
			private Mobile m_Giver;
			
			public SisterOfMeditationEntry( Mobile from, Mobile giver ) : base( 6146, 3 )
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

	public class SBSisterOfMeditation : SBInfo
	{
		private List<GenericBuyInfo> m_BuyInfo = new InternalBuyInfo();
		private IShopSellInfo m_SellInfo = new InternalSellInfo();

		public SBSisterOfMeditation()
		{
		}

		public override IShopSellInfo SellInfo { get { return m_SellInfo; } }
		public override List<GenericBuyInfo> BuyInfo { get { return m_BuyInfo; } }

		public class InternalBuyInfo : List<GenericBuyInfo>
		{
			public InternalBuyInfo()
			{
				Add( new GenericBuyInfo( "Scarlet Band Of Meditation", typeof( ScarletBandOfMeditation ), 500, 10, 0x1F06, 1608 ) );
			}
		}

		public class InternalSellInfo : GenericSellInfo
		{
			public InternalSellInfo()
			{
				Add( typeof( ScarletBandOfMeditation ), 250 );
			}
		}
	}
}