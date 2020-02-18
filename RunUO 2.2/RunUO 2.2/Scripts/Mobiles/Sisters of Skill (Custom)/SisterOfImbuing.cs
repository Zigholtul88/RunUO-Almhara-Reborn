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
	public class SisterOfImbuing : BaseVendor
	{
		private List<SBInfo> m_SBInfos = new List<SBInfo>(); 
		protected override List<SBInfo> SBInfos{ get { return m_SBInfos; } } 

                public override bool IsInvulnerable{ get{ return true; } }
		public override bool CanTeach { get { return true; } }

		[Constructable]
		public SisterOfImbuing() : base( "the Scarlet Sister of Imbuing" ) 
		{
                }

		public override void InitSBInfo() 
		{ 
			m_SBInfos.Add( new SBSisterOfImbuing() ); 
		}

		public override void InitOutfit()
		{
			Name = "Adrianna Ministra";
                 	Body = 401;
                        Female = true;
                        Race = Race.Human;
                        Hue = 33784;
                        HairItemID = 8261;
                        HairHue = 1110;

			SetSkill( SkillName.Imbuing, 120.0 );

			FemaleStuddedChest chest = new FemaleStuddedChest(); 
			chest.Hue = 2213; 
			chest.Movable = false; 
			AddItem( chest );

			StuddedArms arms = new StuddedArms(); 
			arms.Hue = 2213; 
			arms.Movable = false; 
			AddItem( arms );

			StuddedGloves gloves = new StuddedGloves(); 
			gloves.Hue = 2213; 
			gloves.Movable = false; 
			AddItem( gloves );

			CloakOfHumility cloak = new CloakOfHumility(); 
			cloak.Hue = 553; 
			cloak.Movable = false; 
			AddItem( cloak );

			WoodlandBelt belt = new WoodlandBelt(); 
			belt.Hue = 553; 
			belt.Movable = false; 
			AddItem( belt ); 

			AddItem( new BodySash(553) );
			AddItem( new ThighBoots(553) );
                }

		public SisterOfImbuing( Serial serial ) : base( serial )
		{
		}

		public override void GetContextMenuEntries( Mobile from, List<ContextMenuEntry> list ) 
		{
			base.GetContextMenuEntries( from, list );
			list.Add( new SisterOfImbuingEntry( from, this ) );
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

		public class SisterOfImbuingEntry : ContextMenuEntry
		{
			private Mobile m_Mobile;
			private Mobile m_Giver;
			
			public SisterOfImbuingEntry( Mobile from, Mobile giver ) : base( 6146, 3 )
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

	public class SBSisterOfImbuing : SBInfo
	{
		private List<GenericBuyInfo> m_BuyInfo = new InternalBuyInfo();
		private IShopSellInfo m_SellInfo = new InternalSellInfo();

		public SBSisterOfImbuing()
		{
		}

		public override IShopSellInfo SellInfo { get { return m_SellInfo; } }
		public override List<GenericBuyInfo> BuyInfo { get { return m_BuyInfo; } }

		public class InternalBuyInfo : List<GenericBuyInfo>
		{
			public InternalBuyInfo()
			{
				Add( new GenericBuyInfo( "Scarlet Band Of Imbuing", typeof( ScarletBandOfImbuing ), 500, 10, 0x1F06, 1608 ) );
			}
		}

		public class InternalSellInfo : GenericSellInfo
		{
			public InternalSellInfo()
			{
				Add( typeof( ScarletBandOfImbuing ), 250 );
			}
		}
	}
}