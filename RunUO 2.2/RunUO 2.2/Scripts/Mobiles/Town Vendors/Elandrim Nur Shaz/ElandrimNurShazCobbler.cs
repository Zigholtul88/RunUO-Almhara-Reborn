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
	public class ElandrimNurShazCobbler : BaseVendor 
	{ 
		private List<SBInfo> m_SBInfos = new List<SBInfo>(); 
		protected override List<SBInfo> SBInfos{ get { return m_SBInfos; } } 


		[Constructable]
		public ElandrimNurShazCobbler() : base( "the cobbler" ) 
		{ 
		} 

		public override void InitSBInfo() 
		{ 
			m_SBInfos.Add( new SBElandrimNurShazCobbler() ); 
		}

		public override void InitOutfit()
		{
			Name = "Aurora Galemine";
                 	Body = 606;
                        Female = true;
                        Race = Race.Elf;
                        Hue = 1023;
                        HairItemID = 12240;
                        HairHue = 1419;

			SetStr( 241 );
			SetDex( 196 );
			SetInt( 228 );

			SetSkill( SkillName.Anatomy, 60.0, 83.0 );
			SetSkill( SkillName.Tactics, 60.0, 83.0 );
			SetSkill( SkillName.Wrestling, 60.0, 83.0 );

			PackGold( 46, 93 );

			AddItem( new SunElfPlainDress(788) );
			AddItem( new Cloak(778) );
			AddItem( new ElvenBoots(788) );
                }

		public ElandrimNurShazCobbler( Serial serial ) : base( serial ) 
		{ 
		} 

		public override void GetContextMenuEntries( Mobile from, List<ContextMenuEntry> list ) 
		{
			base.GetContextMenuEntries( from, list );
			list.Add( new ElandrimNurShazCobblerEntry( from, this ) );
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

		public class ElandrimNurShazCobblerEntry : ContextMenuEntry
		{
			private Mobile m_Mobile;
			private Mobile m_Giver;
			
			public ElandrimNurShazCobblerEntry( Mobile from, Mobile giver ) : base( 6146, 3 )
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
					if ( ! mobile.HasGump( typeof( ElandrimNurShazCobblerGump ) ) )
					{
						mobile.SendGump( new ElandrimNurShazCobblerGump( mobile ));
					}
				}
			}
		}
        }

	public class SBElandrimNurShazCobbler : SBInfo 
	{ 
		private List<GenericBuyInfo> m_BuyInfo = new InternalBuyInfo(); 
		private IShopSellInfo m_SellInfo = new InternalSellInfo(); 

		public SBElandrimNurShazCobbler() 
		{ 
		} 

		public override IShopSellInfo SellInfo { get { return m_SellInfo; } } 
		public override List<GenericBuyInfo> BuyInfo { get { return m_BuyInfo; } } 

		public class InternalBuyInfo : List<GenericBuyInfo> 
		{ 
			public InternalBuyInfo() 
			{
				Add( new GenericBuyInfo( typeof( SwampBoots ), 50, 200, 0x1711, Utility.RandomNeutralHue() ) ); 

				Add( new GenericBuyInfo( typeof( Boots ), 16, 20, 0x170b, Utility.RandomNeutralHue() ) );
 				Add( new GenericBuyInfo( typeof( ElvenBoots ), 20, 20, 0x2FC4, Utility.RandomNeutralHue() ) );
				Add( new GenericBuyInfo( typeof( HeavyBoots ), 60, 10, 15864, Utility.RandomNeutralHue() ) );
				Add( new GenericBuyInfo( typeof( HighBoots ), 46, 15, 15865, Utility.RandomNeutralHue() ) );
				Add( new GenericBuyInfo( typeof( LightBoots ), 24, 15, 15867, Utility.RandomNeutralHue() ) );
				Add( new GenericBuyInfo( typeof( Sandals ), 10, 20, 0x170d, Utility.RandomNeutralHue() ) ); 
				Add( new GenericBuyInfo( typeof( Shoes ), 22, 20, 0x170f, Utility.RandomNeutralHue() ) ); 
				Add( new GenericBuyInfo( typeof( ShortBoots ), 28, 15, 15870, Utility.RandomNeutralHue() ) );
				Add( new GenericBuyInfo( typeof( ThighBoots ), 30, 20, 0x1711, Utility.RandomNeutralHue() ) ); 
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
				Add( typeof( ElvenBoots ), 5 ); 
			} 
		} 
	} 
}
