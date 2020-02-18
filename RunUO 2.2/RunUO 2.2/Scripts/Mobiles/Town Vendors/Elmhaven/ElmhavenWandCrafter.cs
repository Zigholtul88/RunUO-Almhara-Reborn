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
using Server.Spells.First;
using Server.Spells.Second;
using Server.Spells.Third;
using Server.Mobiles;

namespace Server.Mobiles 
{ 
	public class ElmhavenWandCrafter : BaseVendor 
	{ 
		private List<SBInfo> m_SBInfos = new List<SBInfo>(); 
		protected override List<SBInfo> SBInfos{ get { return m_SBInfos; } } 


		[Constructable]
		public ElmhavenWandCrafter() : base( "the wand crafter" ) 
		{ 
		} 

		public override void InitSBInfo() 
		{ 
			m_SBInfos.Add( new SBElmhavenWandCrafter() ); 
		}

		public override void InitOutfit()
		{
			Name = "Gregory Henderson";
                 	Body = 400;
                  Female = false;
                  Race = Race.Human;
                  Hue = 33785;
                  HairItemID = 8264;
                  HairHue = 1116;
                  FacialHairItemID = 8267;
                  FacialHairHue = 1116;

			SetStr( 175 );
			SetDex( 105 );
			SetInt( 182 );

			SetSkill( SkillName.Anatomy, 60.0, 83.0 );
			SetSkill( SkillName.Blacksmith, 65.0, 88.0 );
			SetSkill( SkillName.Tactics, 60.0, 83.0 );
			SetSkill( SkillName.Wrestling, 60.0, 83.0 );

			PackGold( 56, 96 );

			AddItem( new FancyRobe(788) );
			AddItem( new Cloak(878) );
			AddItem( new ThighBoots(898) );

			LeatherGloves gloves = new LeatherGloves();
			gloves.Hue = 2219;
			gloves.Movable = true;
			AddItem( gloves );
            }

		public ElmhavenWandCrafter( Serial serial ) : base( serial ) 
		{ 
		} 

		public override void GetContextMenuEntries( Mobile from, List<ContextMenuEntry> list ) 
		{
			base.GetContextMenuEntries( from, list );
			list.Add( new ElmhavenWandCrafterEntry( from, this ) );
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

		public class ElmhavenWandCrafterEntry : ContextMenuEntry
		{
			private Mobile m_Mobile;
			private Mobile m_Giver;
			
			public ElmhavenWandCrafterEntry( Mobile from, Mobile giver ) : base( 6146, 3 )
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
					if ( ! mobile.HasGump( typeof( ElmhavenWandCrafterGump ) ) )
					{
						mobile.SendGump( new ElmhavenWandCrafterGump( mobile ));
						
					}
				}
			}
		}

	public class SBElmhavenWandCrafter : SBInfo
	{
		private List<GenericBuyInfo> m_BuyInfo = new InternalBuyInfo();
		private IShopSellInfo m_SellInfo = new InternalSellInfo();

		public SBElmhavenWandCrafter()
		{
		}

		public override IShopSellInfo SellInfo { get { return m_SellInfo; } }
		public override List<GenericBuyInfo> BuyInfo { get { return m_BuyInfo; } }

		public class InternalBuyInfo : List<GenericBuyInfo>
		{
			public InternalBuyInfo()
			{
				Add( new GenericBuyInfo( "Magic Hammer", typeof( MagicHammer ), 100, 500, 0x13E4, 0x492 ) );
			}
		}

		public class InternalSellInfo : GenericSellInfo
		{
			public InternalSellInfo()
			{
				Add( typeof( MagicHammer ), 50 );
			}
		}
	}
}
