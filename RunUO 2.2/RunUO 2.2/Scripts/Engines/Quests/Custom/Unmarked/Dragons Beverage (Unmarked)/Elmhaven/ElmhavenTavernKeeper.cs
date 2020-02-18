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
	public class ElmhavenTavernKeeper : BaseVendor 
	{ 
		private List<SBInfo> m_SBInfos = new List<SBInfo>(); 
		protected override List<SBInfo> SBInfos{ get { return m_SBInfos; } } 

		[Constructable]
		public ElmhavenTavernKeeper() : base( "the tavern keeper" ) 
		{ 
		} 

		public override void InitSBInfo() 
		{ 
			m_SBInfos.Add( new SBElmhavenTavernKeeper() ); 
		} 

		public override void InitOutfit()
		{
			Name = "Vivian";
                 	Body = 401;
                        Female = true;
                        Race = Race.Human;
                        Hue = 33821;
                        HairItemID = 8262;
                        HairHue = 1146;

			SetStr( 138 );
			SetDex( 103 );
			SetInt( 57 );

			SetSkill( SkillName.Anatomy, 60.0, 83.0 );
			SetSkill( SkillName.Tactics, 60.0, 83.0 );
			SetSkill( SkillName.Wrestling, 60.0, 83.0 );

			PackGold( 40, 80 );

			AddItem( new Cloak(68) );
			AddItem( new FancyTunic(568) );
			AddItem( new ThighBoots(868) );

			AddItem( new SilverNecklace() );

			LeatherGloves gloves = new LeatherGloves();
			gloves.Hue = 2129;
			gloves.Movable = true;
			AddItem( gloves );
                }

		public ElmhavenTavernKeeper( Serial serial ) : base( serial ) 
		{ 
		} 

		public override void GetContextMenuEntries( Mobile from, List<ContextMenuEntry> list ) 
		{
			base.GetContextMenuEntries( from, list );
			list.Add( new ElmhavenTavernKeeperEntry( from, this ) );
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
		
		public class ElmhavenTavernKeeperEntry : ContextMenuEntry
		{
			private Mobile m_Mobile;
			private Mobile m_Giver;
			
			public ElmhavenTavernKeeperEntry( Mobile from, Mobile giver ) : base( 6146, 3 )
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
					if ( ! mobile.HasGump( typeof( DragonsBeverageElmhavenGump ) ) )
					{
						mobile.SendGump( new DragonsBeverageElmhavenGump( mobile ));
						
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
				if( dropped is DragonfireRedWine )
				{
				if(dropped.Amount!=1)
         			{
                        }
					dropped.Delete();
		                        mobile.AddToBackpack( new ThreeGoldBars() );
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

	public class SBElmhavenTavernKeeper: SBInfo 
	{ 
		private List<GenericBuyInfo> m_BuyInfo = new InternalBuyInfo(); 
		private IShopSellInfo m_SellInfo = new InternalSellInfo(); 

		public SBElmhavenTavernKeeper() 
		{ 
		} 

		public override IShopSellInfo SellInfo { get { return m_SellInfo; } } 
		public override List<GenericBuyInfo> BuyInfo { get { return m_BuyInfo; } } 

		public class InternalBuyInfo : List<GenericBuyInfo> 
		{ 
			public InternalBuyInfo() 
			{ 
				Add( new BeverageBuyInfo( typeof( BeverageBottle ), BeverageType.Ale, 14, 50, 0x99F, 0 ) );
				Add( new BeverageBuyInfo( typeof( BeverageBottle ), BeverageType.Wine, 14, 46, 0x9C7, 0 ) );
				Add( new BeverageBuyInfo( typeof( BeverageBottle ), BeverageType.Liquor, 14, 37, 0x99B, 0 ) );
				Add( new BeverageBuyInfo( typeof( Jug ), BeverageType.Cider, 26, 86, 0x9C8, 0 ) );
				Add( new BeverageBuyInfo( typeof( Pitcher ), BeverageType.Milk, 14, 50, 0x9F0, 0 ) );
				Add( new BeverageBuyInfo( typeof( Pitcher ), BeverageType.Ale, 22, 45, 0x1F95, 0 ) );
				Add( new BeverageBuyInfo( typeof( Pitcher ), BeverageType.Cider, 22, 75, 0x1F97, 0 ) );
				Add( new BeverageBuyInfo( typeof( Pitcher ), BeverageType.Liquor, 22, 61, 0x1F99, 0 ) );
				Add( new BeverageBuyInfo( typeof( Pitcher ), BeverageType.Wine, 22, 39, 0x1F9B, 0 ) );
				Add( new BeverageBuyInfo( typeof( Pitcher ), BeverageType.Water, 22, 82, 0x1F9D, 0 ) );

				Add( new GenericBuyInfo( "Black Panther Tonic", typeof( BlackPantherTonic ), 30, 99, 0x99F, 1904 ) );
				Add( new GenericBuyInfo( "Bum Light", typeof( BumLight ), 22, 99, 0x99F, 2119 ) );
				Add( new GenericBuyInfo( "Crabtree's Cabin Lager", typeof( CrabtreesCabinLager ), 35, 99, 0x99F, 1515 ) );
				Add( new GenericBuyInfo( "Dos Llamas", typeof( DosLlamas ), 26, 99, 0x99F, 45 ) );
				Add( new GenericBuyInfo( "Irish Spirit", typeof( IrishSpirit ), 28, 99, 0x99F, 1368 ) );
				Add( new GenericBuyInfo( "Montoya Rock", typeof( MontoyaRock ), 30, 99, 0x99F, 1861 ) );

				Add( new GenericBuyInfo( typeof( BreadLoaf ), 12, 56, 0x103B, 0 ) );
				Add( new GenericBuyInfo( typeof( CheeseWheel ), 42, 72, 0x97E, 0 ) );
				Add( new GenericBuyInfo( typeof( CookedBird ), 36, 44, 0x9B7, 0 ) );
				Add( new GenericBuyInfo( typeof( LambLeg ), 16, 65, 0x160A, 0 ) );
				Add( new GenericBuyInfo( typeof( ChickenLeg ), 10, 65, 0x1608, 0 ) );
				Add( new GenericBuyInfo( typeof( Ribs ), 14, 70, 0x9F2, 0 ) );

				Add( new GenericBuyInfo( typeof( WoodenBowlOfCarrots ), 25, 100, 0x15F9, 0 ) );
				Add( new GenericBuyInfo( typeof( WoodenBowlOfCorn ), 28, 100, 0x15FA, 0 ) );
				Add( new GenericBuyInfo( typeof( WoodenBowlOfLettuce ), 26, 100, 0x15FB, 0 ) );
				Add( new GenericBuyInfo( typeof( WoodenBowlOfPeas ), 23, 100, 0x15FC, 0 ) );
				Add( new GenericBuyInfo( typeof( EmptyPewterBowl ), 15, 100, 0x15FD, 0 ) );
				Add( new GenericBuyInfo( typeof( PewterBowlOfCorn ), 28, 100, 0x15FE, 0 ) );
				Add( new GenericBuyInfo( typeof( PewterBowlOfLettuce ), 26, 100, 0x15FF, 0 ) );
				Add( new GenericBuyInfo( typeof( PewterBowlOfPeas ), 23, 100, 0x1600, 0 ) );
				Add( new GenericBuyInfo( typeof( PewterBowlOfPotatos ), 25, 100, 0x1601, 0 ) );
				Add( new GenericBuyInfo( typeof( WoodenBowlOfStew ), 27, 100, 0x1604, 0 ) );
				Add( new GenericBuyInfo( typeof( WoodenBowlOfTomatoSoup ), 32, 100, 0x1606, 0 ) );

				Add( new GenericBuyInfo( typeof( ApplePie ), 28, 20, 0x1041, 0 ) ); //OSI just has Pie, not Apple/Fruit/Meat

				Add( new GenericBuyInfo( "1016450", typeof( Chessboard ), 50, 20, 0xFA6, 0 ) );
				Add( new GenericBuyInfo( "1016449", typeof( CheckerBoard ), 50, 20, 0xFA6, 0 ) );
				Add( new GenericBuyInfo( typeof( Backgammon ), 50, 20, 0xE1C, 0 ) );
				Add( new GenericBuyInfo( typeof( Dices ), 100, 20, 0xFA7, 0 ) );
				Add( new GenericBuyInfo( "Yahtzee Dice", typeof( YahtzeeDice ), 300, 50, 4007, 1150 ) );
			}
		}

		public class InternalSellInfo : GenericSellInfo
		{
			public InternalSellInfo()
			{
			}
		}
	}
}

