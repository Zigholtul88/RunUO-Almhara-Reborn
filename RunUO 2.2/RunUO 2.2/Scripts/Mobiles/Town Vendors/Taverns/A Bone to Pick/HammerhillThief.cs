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
	public class HammerhillThief : BaseVendor 
	{ 
		private List<SBInfo> m_SBInfos = new List<SBInfo>(); 
		protected override List<SBInfo> SBInfos{ get { return m_SBInfos; } } 

		[Constructable]
		public HammerhillThief() : base( "the thief" ) 
		{ 
		} 

		public override void InitSBInfo() 
		{ 
			m_SBInfos.Add( new SBHammerhillThief() ); 
		} 

		public override void InitOutfit()
		{
			Name = "Lauren";
                 	Body = 401;
                        Female = true;
                        Race = Race.Human;
                        Hue = 33770;
                        HairItemID = 8260;
                        HairHue = 1327;

			SetStr( 58 );
			SetDex( 75 );
			SetInt( 24 );

			SetSkill( SkillName.Camping, 55.0, 78.0 );
			SetSkill( SkillName.DetectHidden, 65.0, 88.0 );
			SetSkill( SkillName.Hiding, 45.0, 68.0 );
			SetSkill( SkillName.Archery, 65.0, 88.0 );
			SetSkill( SkillName.Tracking, 65.0, 88.0 );
			SetSkill( SkillName.Veterinary, 60.0, 83.0 );

			PackGold( 17, 34 );

			AddItem( new BodySash(913) );
			AddItem( new FancyShirt(808) );
			AddItem( new FancyPants(808) );
			AddItem( new ThighBoots(893) );

			LeatherGloves gloves = new LeatherGloves();
			gloves.Hue = 2412;
			gloves.Movable = true;
			AddItem( gloves );
            }

		public HammerhillThief( Serial serial ) : base( serial ) 
		{ 
		} 

		public override void GetContextMenuEntries( Mobile from, List<ContextMenuEntry> list ) 
		{
			base.GetContextMenuEntries( from, list );
			list.Add( new HammerhillThiefEntry( from, this ) );
		}
		
		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );
			writer.Write( (int) 0 );
		}
		
		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader );
			int version = reader.ReadInt();
		}
		
		public class HammerhillThiefEntry : ContextMenuEntry
		{
			private Mobile m_Mobile;
			private Mobile m_Giver;
			
			public HammerhillThiefEntry( Mobile from, Mobile giver ) : base( 6146, 3 )
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
					if ( ! mobile.HasGump( typeof( HammerhillThiefGump ) ) )
					{
						mobile.SendGump( new HammerhillThiefGump( mobile ));
						
					}
				}
			}
		}
		
		public override bool OnDragDrop( Mobile from, Item dropped )
		{
			Mobile m = from;
			PlayerMobile mobile = m as PlayerMobile;
			
			if( mobile != null )
			{
				if( dropped is LargeFrogBoneShards )
				{
				if(dropped.Amount!=1)
         			{
                                }
					dropped.Delete();
		                         mobile.AddToBackpack( new Lockpick( 5 ) );
					return true;
				}			
					else
					{
						mobile.SendMessage("I have no need for this item.");
					}
				}
		return false;
		}
	}

	public class SBHammerhillThief: SBInfo 
	{ 
		private List<GenericBuyInfo> m_BuyInfo = new InternalBuyInfo(); 
		private IShopSellInfo m_SellInfo = new InternalSellInfo(); 

		public SBHammerhillThief() 
		{ 
		} 

		public override IShopSellInfo SellInfo { get { return m_SellInfo; } } 
		public override List<GenericBuyInfo> BuyInfo { get { return m_BuyInfo; } } 

		public class InternalBuyInfo : List<GenericBuyInfo> 
		{ 
			public InternalBuyInfo() 
			{ 
				Add( new GenericBuyInfo( typeof( Bandana ), 6, 20, 0x1540, Utility.RandomDyedHue() ) );
				Add( new GenericBuyInfo( typeof( SkullCap ), 7, 20, 0x1544, Utility.RandomDyedHue() ) );

				Add( new GenericBuyInfo( typeof( Pouch ), 10, 50, 0xE79, 0 ) );
				Add( new GenericBuyInfo( typeof( Torch ), 5, 100, 0xF6B, 0 ) );

				Add( new GenericBuyInfo( "Master Lockpickers Ring", typeof( MasterLockpickersRing ), 500, 15, 0x108a, 0 ) );
				Add( new GenericBuyInfo( "Grave Robbers Shovel", typeof( GraveRobbersShovel ), 100, 200, 0xF39, 1109 ) );
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
