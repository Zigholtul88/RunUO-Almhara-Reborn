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
	public class ElmhavenCobbler : BaseVendor 
	{ 
		private List<SBInfo> m_SBInfos = new List<SBInfo>(); 
		protected override List<SBInfo> SBInfos{ get { return m_SBInfos; } } 


		[Constructable]
		public ElmhavenCobbler() : base( "the cobbler" ) 
		{ 
		} 

		public override void InitSBInfo() 
		{ 
			m_SBInfos.Add( new SBElmhavenCobbler() ); 
		}

		public override void InitOutfit()
		{
			Name = "Brianna";
                 	Body = 401;
                        Female = true;
                        Race = Race.Human;
                        Hue = 33805;
                        HairItemID = 8253;
                        HairHue = 1154;

			SetStr( 117 );
			SetDex( 96 );
			SetInt( 54 );

			SetSkill( SkillName.Anatomy, 60.0, 83.0 );
			SetSkill( SkillName.Tactics, 60.0, 83.0 );
			SetSkill( SkillName.Wrestling, 60.0, 83.0 );

			PackGold( 46, 93 );

			AddItem( new ElegantGown(723) );
			AddItem( new HeavyBoots(753) );
                }

		public ElmhavenCobbler( Serial serial ) : base( serial ) 
		{ 
		} 

		public override void GetContextMenuEntries( Mobile from, List<ContextMenuEntry> list ) 
		{
			base.GetContextMenuEntries( from, list );
			list.Add( new ElmhavenCobblerEntry( from, this ) );
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

		public class ElmhavenCobblerEntry : ContextMenuEntry
		{
			private Mobile m_Mobile;
			private Mobile m_Giver;
			
			public ElmhavenCobblerEntry( Mobile from, Mobile giver ) : base( 6146, 3 )
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
					if ( ! mobile.HasGump( typeof( ElmhavenCobblerGump ) ) )
					{
						mobile.SendGump( new ElmhavenCobblerGump( mobile ));
					}
				}
			}
		}
        }

	public class SBElmhavenCobbler : SBInfo 
	{ 
		private List<GenericBuyInfo> m_BuyInfo = new InternalBuyInfo(); 
		private IShopSellInfo m_SellInfo = new InternalSellInfo(); 

		public SBElmhavenCobbler() 
		{ 
		} 

		public override IShopSellInfo SellInfo { get { return m_SellInfo; } } 
		public override List<GenericBuyInfo> BuyInfo { get { return m_BuyInfo; } } 

		public class InternalBuyInfo : List<GenericBuyInfo> 
		{ 
			public InternalBuyInfo() 
			{
				Add( new GenericBuyInfo( typeof( SwampBoots ), 50, 200, 0x1711, Utility.RandomNeutralHue() ) ); 

				Add( new GenericBuyInfo( typeof( Boots ), 8, 20, 0x170b, Utility.RandomNeutralHue() ) );
				Add( new GenericBuyInfo( typeof( HeavyBoots ), 30, 10, 15864, Utility.RandomNeutralHue() ) );
				Add( new GenericBuyInfo( typeof( HighBoots ), 23, 15, 15865, Utility.RandomNeutralHue() ) );
				Add( new GenericBuyInfo( typeof( LightBoots ), 12, 15, 15867, Utility.RandomNeutralHue() ) );
				Add( new GenericBuyInfo( typeof( Sandals ), 5, 20, 0x170d, Utility.RandomNeutralHue() ) ); 
				Add( new GenericBuyInfo( typeof( Shoes ), 11, 20, 0x170f, Utility.RandomNeutralHue() ) ); 
				Add( new GenericBuyInfo( typeof( ShortBoots ), 14, 15, 15870, Utility.RandomNeutralHue() ) );
				Add( new GenericBuyInfo( typeof( ThighBoots ), 15, 20, 0x1711, Utility.RandomNeutralHue() ) ); 
			} 
		} 

		public class InternalSellInfo : GenericSellInfo 
		{ 
			public InternalSellInfo() 
			{ 
				Add( typeof( Boots ), 5 ); 
				Add( typeof( Sandals ), 5 ); 
				Add( typeof( Shoes ), 5 ); 
				Add( typeof( ThighBoots ), 5 ); 
			} 
		} 
	} 
}
