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
	public class ElmhavenWaitress : BaseVendor
	{
		private List<SBInfo> m_SBInfos = new List<SBInfo>();
		protected override List<SBInfo> SBInfos{ get { return m_SBInfos; } }


		[Constructable]
		public ElmhavenWaitress() : base( "the waitress" )
		{
			SetSkill( SkillName.Discordance, 36.0, 68.0 );
		}

		public override void InitSBInfo()
		{
			m_SBInfos.Add( new SBElmhavenWaitress() );
		}

		public override void InitOutfit()
		{
			Name = "Henrietta";
                 	Body = 401;
                        Female = true;
                        Race = Race.Human;
                        Hue = 33801;
                        HairItemID = 8265;
                        HairHue = 1148;

			SetStr( 127 );
			SetDex( 99 );
			SetInt( 54 );

			SetSkill( SkillName.Anatomy, 60.0, 83.0 );
			SetSkill( SkillName.Tactics, 60.0, 83.0 );
			SetSkill( SkillName.Wrestling, 60.0, 83.0 );

			PackGold( 2, 4 );

			AddItem( new FeatheredHat(668) );
			AddItem( new CitizenDress(723) );
			AddItem( new LightBoots(853) );

			AddItem( new Necklace() );

			LeatherGloves gloves = new LeatherGloves();
			gloves.Hue = 2211;
			gloves.Movable = true;
			AddItem( gloves );
                }

		public ElmhavenWaitress( Serial serial ) : base( serial )
		{
		}

		public override void GetContextMenuEntries( Mobile from, List<ContextMenuEntry> list ) 
		{
			base.GetContextMenuEntries( from, list );
			list.Add( new ElmhavenWaitressEntry( from, this ) );
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

		public class ElmhavenWaitressEntry : ContextMenuEntry
		{
			private Mobile m_Mobile;
			private Mobile m_Giver;
			
			public ElmhavenWaitressEntry( Mobile from, Mobile giver ) : base( 6146, 3 )
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
					if ( ! mobile.HasGump( typeof( ElmhavenWaitressGump ) ) )
					{
						mobile.SendGump( new ElmhavenWaitressGump( mobile ));
					}
				}
			}
		}
        }

	public class SBElmhavenWaitress : SBInfo
	{
		private List<GenericBuyInfo> m_BuyInfo = new InternalBuyInfo();
		private IShopSellInfo m_SellInfo = new InternalSellInfo();

		public SBElmhavenWaitress()
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

				Add( new GenericBuyInfo( typeof( Meatballs ), 15, 235, 0xE74, 0x475 ) );
				Add( new GenericBuyInfo( typeof( Meatloaf ), 28, 114, 0xE79, 0x475 ) );
				Add( new GenericBuyInfo( typeof( PotatoStrings ), 12, 125, 0x1B8D, 0x225 ) );
				Add( new GenericBuyInfo( typeof( Pancakes ), 20, 105, 0x1E1F, 0x22A ) );
				Add( new GenericBuyInfo( typeof( Waffles ), 18, 105, 0x1E1F, 0x1C7 ) );
				Add( new GenericBuyInfo( typeof( GrilledHam ), 23, 123, 0x1E1F, 0x33D ) );
				Add( new GenericBuyInfo( typeof( Hotwings ), 17, 234, 0x1608, 0x21A ) );
				Add( new GenericBuyInfo( typeof( Taco ), 15, 562, 0x1370, 0x465 ) );
				Add( new GenericBuyInfo( typeof( CornOnCob ), 16, 376, 0xC81, 0x0 ) );
				Add( new GenericBuyInfo( typeof( Hotdog ), 16, 376, 0xC7F, 0x457 ) );

				Add( new GenericBuyInfo( typeof( BreadLoaf ), 12, 56, 0x103B, 0 ) );
				Add( new GenericBuyInfo( typeof( CheeseWheel ), 42, 72, 0x97E, 0 ) );

				Add( new GenericBuyInfo( typeof( FriedChickenEggs ), 15, 500, 0x9B6, 0 ) );
				Add( new GenericBuyInfo( typeof( FriedDuckEggs ), 15, 500, 0x9B6, 0 ) );
				Add( new GenericBuyInfo( typeof( FriedEggs ), 15, 500, 0x9B6, 0 ) );

				Add( new GenericBuyInfo( typeof( ChickenLeg ), 5, 200, 0x1608, 0 ) );
				Add( new GenericBuyInfo( typeof( CookedBird ), 17, 200, 0x9B7, 0 ) );
				Add( new GenericBuyInfo( typeof( DuckLeg ), 7, 200, 0x1608, 0 ) );
				Add( new GenericBuyInfo( typeof( LambLeg ), 8, 200, 0x160A, 0 ) );
				Add( new GenericBuyInfo( typeof( RoastChicken ), 98, 200, 0x9B7, 0 ) );
				Add( new GenericBuyInfo( typeof( RoastDuck ), 103, 200, 0x9B7, 0 ) );
				Add( new GenericBuyInfo( typeof( RoastPig ), 106, 200, 0x9BB, 0 ) );
				Add( new GenericBuyInfo( typeof( RoastTurkey ), 225, 200, 0x9B7, 0 ) );
				Add( new GenericBuyInfo( typeof( SlicedTurkey ), 13, 200, 0x1E1F, 0 ) );

				Add( new GenericBuyInfo( typeof( TurkeyPlatter ), 247, 200, 0x4988, 0 ) );
				Add( new GenericBuyInfo( typeof( TurkeyLeg ), 28, 200, 0x1607, 0 ) );

				Add( new GenericBuyInfo( typeof( AsianVegMix ), 20, 100, 0x15FB, 0 ) );
				Add( new GenericBuyInfo( typeof( BowlCornFlakes ), 20, 100, 0x15FA, 0 ) );
				Add( new GenericBuyInfo( typeof( BowlRiceKrisps ), 20, 100, 0x1602, 0 ) );
				Add( new GenericBuyInfo( typeof( CheeseSauce ), 20, 100, 0x15FA, 0 ) );
				Add( new GenericBuyInfo( typeof( ChocIceCream ), 20, 100, 0x15FA, 0 ) );
				Add( new GenericBuyInfo( typeof( Gravy ), 20, 100, 0x15FD, 1012 ) );
				Add( new GenericBuyInfo( typeof( MixedVegetables ), 20, 100, 0x15FB, 0 ) );
				Add( new GenericBuyInfo( typeof( BroccoliCheese ), 20, 100, 0x15FC, 0 ) );
				Add( new GenericBuyInfo( typeof( BroccoliCaulCheese ), 20, 100, 0x15FB, 0 ) );
				Add( new GenericBuyInfo( typeof( ChickenNoodleSoup ), 20, 100, 0x15FA, 0 ) );
				Add( new GenericBuyInfo( typeof( BowlBeets ), 20, 100, 0x15F9, 0 ) );
				Add( new GenericBuyInfo( typeof( BowlBroccoli ), 20, 100, 0x15FB, 0 ) );
				Add( new GenericBuyInfo( typeof( BowlCauliflower ), 20, 100, 0x15FA, 0 ) );
				Add( new GenericBuyInfo( typeof( BowlGreenBeans ), 20, 100, 0x15FC, 0 ) );
				Add( new GenericBuyInfo( typeof( BowlSpinach ), 20, 100, 0x15FC, 0 ) );
				Add( new GenericBuyInfo( typeof( BowlTurnips ), 20, 100, 0x15F9, 0 ) );
				Add( new GenericBuyInfo( typeof( BowlMashedPotatos ), 20, 100, 0x15FB, 0 ) );
				Add( new GenericBuyInfo( typeof( MacaroniCheese ), 20, 100, 0x15FF, 0 ) );
				Add( new GenericBuyInfo( typeof( CauliflowerCheese ), 20, 100, 0x1602, 0 ) );
				Add( new GenericBuyInfo( typeof( PotatoFries ), 15, 100, 0x160C, 0 ) );
				Add( new GenericBuyInfo( typeof( BowlOatmeal ), 20, 100, 0x1602, 0 ) );
				Add( new GenericBuyInfo( typeof( TomatoRice ), 20, 100, 0x1606, 0 ) );
				Add( new GenericBuyInfo( typeof( Popcorn ), 20, 100, 0x1602, 0 ) );

				Add( new GenericBuyInfo( typeof( BowlRice ), 20, 200, 0x15FB, 0 ) );
				Add( new GenericBuyInfo( typeof( BowlCookedVeggies ), 20, 200, 0x15FB, 0 ) );
				Add( new GenericBuyInfo( typeof( WoodenBowlOfCarrots ), 20, 200, 0x15F9, 0 ) );
				Add( new GenericBuyInfo( typeof( WoodenBowlOfCorn ), 20, 200, 0x15FA, 0 ) );
				Add( new GenericBuyInfo( typeof( WoodenBowlOfLettuce ), 20, 200, 0x15FB, 0 ) );
				Add( new GenericBuyInfo( typeof( WoodenBowlOfPeas ), 20, 200, 0x15FC, 0 ) );
				Add( new GenericBuyInfo( typeof( EmptyPewterBowl ), 5, 500, 0x15FD, 0 ) );

				Add( new GenericBuyInfo( typeof( PewterBowlOfCorn ), 20, 200, 0x15FE, 0 ) );
				Add( new GenericBuyInfo( typeof( PewterBowlOfLettuce ), 20, 200, 0x15FF, 0 ) );
				Add( new GenericBuyInfo( typeof( PewterBowlOfPeas ), 20, 200, 0x1600, 0 ) );
				Add( new GenericBuyInfo( typeof( PewterBowlOfPotatos ), 20, 200, 0x1601, 0 ) );
				Add( new GenericBuyInfo( typeof( BowlOfStew ), 20, 200, 0x1604, 0 ) );
				Add( new GenericBuyInfo( typeof( WoodenBowlOfStew ), 20, 200, 0x1604, 0 ) );
				Add( new GenericBuyInfo( typeof( WoodenBowlOfTomatoSoup ), 200, 20, 0x1606, 0 ) );

				Add( new GenericBuyInfo( typeof( ApplePie ), 28, 20, 0x1041, 0 ) ); //OSI just has Pie, not Apple/Fruit/Meat
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
