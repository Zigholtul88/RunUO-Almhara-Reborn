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
	public class BruceDarabontThief : BaseVendor 
	{ 
		private List<SBInfo> m_SBInfos = new List<SBInfo>(); 
		protected override List<SBInfo> SBInfos{ get { return m_SBInfos; } } 

		public override bool CanTeach { get { return true; } }

		[Constructable]
		public BruceDarabontThief() : base( "the thief" ) 
		{ 
		} 

		public override void InitSBInfo() 
		{ 
			m_SBInfos.Add( new SBBruceDarabontThief() ); 
		} 

		public override void InitOutfit()
		{
			Name = "Bruce Darabont";
                 	Body = 605;
                        Female = false;
                        Race = Race.Elf;
                        Hue = 997;
                        HairItemID = 12225;
                        HairHue = 1419;

			SetStr( 297 );
			SetDex( 312 );
			SetInt( 76 );

			SetSkill( SkillName.Archery, 65.0, 88.0 );
			SetSkill( SkillName.Camping, 55.0, 78.0 );
			SetSkill( SkillName.DetectHidden, 65.0, 88.0 );
			SetSkill( SkillName.Hiding, 45.0, 68.0 );
			SetSkill( SkillName.Lockpicking, 60.0, 83.0 );
			SetSkill( SkillName.RemoveTrap, 75.0, 98.0 );
			SetSkill( SkillName.Tracking, 65.0, 88.0 );
			SetSkill( SkillName.Veterinary, 60.0, 83.0 );

			PackGold( 5, 12 );

			AddItem( new Bandana(823) );
			AddItem( new Cloak(848) );
			AddItem( new ClothNinjaJacket(768) );
			AddItem( new TattsukeHakama(768) );
			AddItem( new ShortBoots(848) );

			EbonsilkGloves gloves = new EbonsilkGloves();
			gloves.Hue = 2211;
			gloves.Movable = true;
			AddItem( gloves );
                }

		public BruceDarabontThief( Serial serial ) : base( serial ) 
		{ 
		} 

		public override void GetContextMenuEntries( Mobile from, List<ContextMenuEntry> list ) 
		{
			base.GetContextMenuEntries( from, list );
			list.Add( new BruceDarabontThiefEntry( from, this ) );
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

		public class BruceDarabontThiefEntry : ContextMenuEntry
		{
			private Mobile m_Mobile;
			private Mobile m_Giver;
			
			public BruceDarabontThiefEntry( Mobile from, Mobile giver ) : base( 6146, 3 )
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
					if ( ! mobile.HasGump( typeof( BruceDarabontThiefGump ) ) )
					{
						mobile.SendGump( new BruceDarabontThiefGump( mobile ));
						
					}
				}
			}
		}
        }

	public class SBBruceDarabontThief: SBInfo 
	{ 
		private List<GenericBuyInfo> m_BuyInfo = new InternalBuyInfo(); 
		private IShopSellInfo m_SellInfo = new InternalSellInfo(); 

		public SBBruceDarabontThief()
		{ 
		} 

		public override IShopSellInfo SellInfo { get { return m_SellInfo; } } 
		public override List<GenericBuyInfo> BuyInfo { get { return m_BuyInfo; } } 

		public class InternalBuyInfo : List<GenericBuyInfo> 
		{ 
			public InternalBuyInfo() 
			{ 
				Add( new GenericBuyInfo( typeof( Bandana ), 6, 20, 0x1540, Utility.RandomDyedHue() ) );
				Add( new GenericBuyInfo( typeof( Bandana ), 6, 20, 0x1540, Utility.RandomDyedHue() ) );
				Add( new GenericBuyInfo( typeof( Bandana ), 6, 20, 0x1540, Utility.RandomDyedHue() ) );

				Add( new GenericBuyInfo( typeof( SkullCap ), 7, 20, 0x1544, Utility.RandomDyedHue() ) );
				Add( new GenericBuyInfo( typeof( SkullCap ), 7, 20, 0x1544, Utility.RandomDyedHue() ) );
				Add( new GenericBuyInfo( typeof( SkullCap ), 7, 20, 0x1544, Utility.RandomDyedHue() ) );

				Add( new GenericBuyInfo( typeof( Lockpick ), 200, 20, 0x14FC, 0 ) );
				Add( new GenericBuyInfo( typeof( Pouch ), 10, 50, 0xE79, 0 ) );
				Add( new GenericBuyInfo( typeof( Torch ), 5, 100, 0xF6B, 0 ) );

				Add( new GenericBuyInfo( "Master Lockpickers Ring", typeof( MasterLockpickersRing ), 500, 15, 0x108a, 0 ) );

				Add( new GenericBuyInfo( typeof( Shirt ), 15, 20, 0x1517, Utility.RandomDyedHue() ) );
				Add( new GenericBuyInfo( typeof( Shirt ), 15, 20, 0x1517, Utility.RandomDyedHue() ) );
				Add( new GenericBuyInfo( typeof( Shirt ), 15, 20, 0x1517, Utility.RandomDyedHue() ) );

				Add( new GenericBuyInfo( typeof( Cloak ), 20, 20, 0x1515, Utility.RandomDyedHue() ) );
				Add( new GenericBuyInfo( typeof( Cloak ), 20, 20, 0x1515, Utility.RandomDyedHue() ) );
				Add( new GenericBuyInfo( typeof( Cloak ), 20, 20, 0x1515, Utility.RandomDyedHue() ) );

				Add( new GenericBuyInfo( typeof( PlainDress ), 20, 20, 0x1F01, Utility.RandomDyedHue() ) );
				Add( new GenericBuyInfo( typeof( PlainDress ), 20, 20, 0x1F01, Utility.RandomDyedHue() ) );
				Add( new GenericBuyInfo( typeof( PlainDress ), 20, 20, 0x1F01, Utility.RandomDyedHue() ) );

				Add( new GenericBuyInfo( typeof( Robe ), 20, 20, 0x1F03, Utility.RandomDyedHue() ) );
				Add( new GenericBuyInfo( typeof( Robe ), 20, 20, 0x1F03, Utility.RandomDyedHue() ) );
				Add( new GenericBuyInfo( typeof( Robe ), 20, 20, 0x1F03, Utility.RandomDyedHue() ) );

				Add( new GenericBuyInfo( typeof( ShortPants ), 15, 20, 0x152E, Utility.RandomDyedHue() ) );
				Add( new GenericBuyInfo( typeof( ShortPants ), 15, 20, 0x152E, Utility.RandomDyedHue() ) );
				Add( new GenericBuyInfo( typeof( ShortPants ), 15, 20, 0x152E, Utility.RandomDyedHue() ) );

				Add( new GenericBuyInfo( typeof( Skirt ), 15, 20, 0x1516, Utility.RandomDyedHue() ) );
				Add( new GenericBuyInfo( typeof( Skirt ), 15, 20, 0x1516, Utility.RandomDyedHue() ) );
				Add( new GenericBuyInfo( typeof( Skirt ), 15, 20, 0x1516, Utility.RandomDyedHue() ) );
			} 
		} 

		public class InternalSellInfo : GenericSellInfo 
		{ 
			public InternalSellInfo() 
			{ 
				Add( typeof( Bandana ), 2 );
				Add( typeof( SkullCap ), 2 );

				Add( typeof( Lockpick ), 4 );
				Add( typeof( Pouch ), 3 );
				Add( typeof( Torch ), 1 );

				Add( typeof( MasterLockpickersRing ), 250 );
			} 
		} 
	} 
}
