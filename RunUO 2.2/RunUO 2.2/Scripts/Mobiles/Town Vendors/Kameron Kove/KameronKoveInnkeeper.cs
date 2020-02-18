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
	public class KameronKoveInnkeeper : BaseVendor 
	{ 
		private List<SBInfo> m_SBInfos = new List<SBInfo>(); 
		protected override List<SBInfo> SBInfos{ get { return m_SBInfos; } } 

		public override bool InitialInnocent{ get{ return true; } }

		[Constructable]
		public KameronKoveInnkeeper() : base( "the innkeeper" ) 
		{ 
		} 

		public override void InitSBInfo() 
		{ 
			m_SBInfos.Add( new SBKameronKoveInnkeeper() ); 
		} 

		public override void InitOutfit()
		{
			Hue = Utility.RandomList( 3,28,38,48,53,58,63,88,93 );

			SetStr( 300 );
			SetDex( 250 );
			SetInt( 200 );

			SetSkill( SkillName.Anatomy, 60.0, 83.0 );
			SetSkill( SkillName.Tactics, 60.0, 83.0 );
			SetSkill( SkillName.Wrestling, 60.0, 83.0 );

			PackGold( 9, 28 );

			if ( this.Female = Utility.RandomBool() )
			{
				Body = 386;
				Name = NameList.RandomName( "female" );
			}
			else
			{
				Body = 390;
				Name = NameList.RandomName( "male" );
			}
                }

                public override void OnSpeech(SpeechEventArgs e)
                {
                    if ((e.Speech.ToLower() == "rest"))
                    {
                        BeginRepair (e.Mobile);
                    }
                    else
                    {
                        base.OnSpeech(e);
                    }

                }
                public void BeginRepair(Mobile from)
                {
                    if (Deleted || !from.CheckAlive())
                        return;

                    int gold = 0;
                    gold = (from.HitsMax - from.Hits) + (from.StamMax - from.Stam) + (from.ManaMax - from.Mana)* 2;

                    from.SendMessage(String.Format("I can patch you up for a small fee. Your fee based off of your condition is {0}gp.", gold));

                    from.Target = new RepairTarget(this);
                }

                private class RepairTarget : Target
                {
                    private KameronKoveInnkeeper m_InnKeeper;

                    public RepairTarget(KameronKoveInnkeeper innkeeper): base(12, false, TargetFlags.None)
                    {
                        m_InnKeeper = innkeeper;
                    }

                    protected override void OnTarget(Mobile from, object targeted)
                    {
                        if (targeted is PlayerMobile)
                        {
                            PlayerMobile playermobile = targeted as PlayerMobile;
                            Container pack = from.Backpack;
                            int toConsume = 0;
                            toConsume = (playermobile.HitsMax - playermobile.Hits) + (playermobile.StamMax - playermobile.Stam) + (playermobile.ManaMax - playermobile.Mana)* 2; //Adjuct price here by changing 3 to whatever you want.

                            if (toConsume == 0)
                            {
                                m_InnKeeper.SayTo(from, "That being is not damaged.");
                            }
                            else if ( (playermobile.Hits < playermobile.HitsMax) && (playermobile.Stam < playermobile.StamMax) && (playermobile.Mana < playermobile.ManaMax) && (pack.ConsumeTotal(typeof(Gold), toConsume)) )
                            {
			        Item a = from.Backpack.FindItemByType( typeof( Gold ) );
			        if ( a != null )

				a.Consume( toConsume );

                                playermobile.Hits = playermobile.HitsMax;
                                playermobile.Stam = playermobile.StamMax;
                                playermobile.Mana = playermobile.ManaMax;
                                m_InnKeeper.SayTo(from, "You are fully recovered.");
                                from.SendMessage(String.Format("You pay {0}gp.", toConsume));

		                from.FixedParticles( 0x375A, 1, 30, 9966, 88, 2, EffectLayer.Head ); 
           	                from.FixedParticles( 0x37B9, 1, 30, 9502, 85, 3, EffectLayer.Head );
		                from.FixedParticles( 0x376A, 1, 31, 9961, 80, 0, EffectLayer.Waist );
           	                from.FixedParticles( 0x37C4, 1, 31, 9502, 88, 2, EffectLayer.Waist );
				from.PlaySound( 0x202 );
                            }
                            else
                            {
                                m_InnKeeper.SayTo(from, "It will cost you {0}gp to have your body repaired.", toConsume);
                                from.SendMessage("You do not have enough gold.");
                            }
                        }
                    }
                }

		public KameronKoveInnkeeper( Serial serial ) : base( serial ) 
		{ 
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

	public class SBKameronKoveInnkeeper: SBInfo 
	{ 
		private List<GenericBuyInfo> m_BuyInfo = new InternalBuyInfo(); 
		private IShopSellInfo m_SellInfo = new InternalSellInfo(); 

		public SBKameronKoveInnkeeper() 
		{ 
		} 

		public override IShopSellInfo SellInfo { get { return m_SellInfo; } } 
		public override List<GenericBuyInfo> BuyInfo { get { return m_BuyInfo; } } 

		public class InternalBuyInfo : List<GenericBuyInfo> 
		{ 
			public InternalBuyInfo() 
			{ 
				Add( new BeverageBuyInfo( typeof( BeverageBottle ), BeverageType.Ale, 7, 20, 0x99F, 0 ) );
				Add( new BeverageBuyInfo( typeof( BeverageBottle ), BeverageType.Wine, 7, 20, 0x9C7, 0 ) );
				Add( new BeverageBuyInfo( typeof( BeverageBottle ), BeverageType.Liquor, 7, 20, 0x99B, 0 ) );
				Add( new BeverageBuyInfo( typeof( Jug ), BeverageType.Cider, 13, 20, 0x9C8, 0 ) );
				Add( new BeverageBuyInfo( typeof( Pitcher ), BeverageType.Milk, 7, 20, 0x9F0, 0 ) );
				Add( new BeverageBuyInfo( typeof( Pitcher ), BeverageType.Ale, 11, 20, 0x1F95, 0 ) );
				Add( new BeverageBuyInfo( typeof( Pitcher ), BeverageType.Cider, 11, 20, 0x1F97, 0 ) );
				Add( new BeverageBuyInfo( typeof( Pitcher ), BeverageType.Liquor, 11, 20, 0x1F99, 0 ) );
				Add( new BeverageBuyInfo( typeof( Pitcher ), BeverageType.Wine, 11, 20, 0x1F9B, 0 ) );
				Add( new BeverageBuyInfo( typeof( Pitcher ), BeverageType.Water, 11, 20, 0x1F9D, 0 ) );

				Add( new GenericBuyInfo( typeof( BreadLoaf ), 6, 10, 0x103B, 0 ) );
				Add( new GenericBuyInfo( typeof( CheeseWheel ), 21, 10, 0x97E, 0 ) );
				Add( new GenericBuyInfo( typeof( CookedBird ), 17, 20, 0x9B7, 0 ) );
				Add( new GenericBuyInfo( typeof( LambLeg ), 8, 20, 0x160A, 0 ) );
				Add( new GenericBuyInfo( typeof( ChickenLeg ), 5, 20, 0x1608, 0 ) );
				Add( new GenericBuyInfo( typeof( Ribs ), 7, 20, 0x9F2, 0 ) );

				Add( new GenericBuyInfo( typeof( WoodenBowlOfCarrots ), 3, 20, 0x15F9, 0 ) );
				Add( new GenericBuyInfo( typeof( WoodenBowlOfCorn ), 3, 20, 0x15FA, 0 ) );
				Add( new GenericBuyInfo( typeof( WoodenBowlOfLettuce ), 3, 20, 0x15FB, 0 ) );
				Add( new GenericBuyInfo( typeof( WoodenBowlOfPeas ), 3, 20, 0x15FC, 0 ) );
				Add( new GenericBuyInfo( typeof( EmptyPewterBowl ), 2, 20, 0x15FD, 0 ) );
				Add( new GenericBuyInfo( typeof( PewterBowlOfCorn ), 3, 20, 0x15FE, 0 ) );
				Add( new GenericBuyInfo( typeof( PewterBowlOfLettuce ), 3, 20, 0x15FF, 0 ) );
				Add( new GenericBuyInfo( typeof( PewterBowlOfPeas ), 3, 20, 0x1600, 0 ) );
				Add( new GenericBuyInfo( typeof( PewterBowlOfPotatos ), 3, 20, 0x1601, 0 ) );
				Add( new GenericBuyInfo( typeof( WoodenBowlOfStew ), 3, 20, 0x1604, 0 ) );
				Add( new GenericBuyInfo( typeof( WoodenBowlOfTomatoSoup ), 3, 20, 0x1606, 0 ) );

				Add( new GenericBuyInfo( typeof( ApplePie ), 7, 20, 0x1041, 0 ) ); //OSI just has Pie, not Apple/Fruit/Meat

				Add( new GenericBuyInfo( typeof( Peach ), 3, 20, 0x9D2, 0 ) );
				Add( new GenericBuyInfo( typeof( Pear ), 3, 20, 0x994, 0 ) );
				Add( new GenericBuyInfo( typeof( Grapes ), 3, 20, 0x9D1, 0 ) );
				Add( new GenericBuyInfo( typeof( Apple ), 3, 20, 0x9D0, 0 ) );
				Add( new GenericBuyInfo( typeof( Banana ), 2, 20, 0x171F, 0 ) );

				Add( new GenericBuyInfo( "1016450", typeof( Chessboard ), 2, 20, 0xFA6, 0 ) );
				Add( new GenericBuyInfo( "1016449", typeof( CheckerBoard ), 2, 20, 0xFA6, 0 ) );
				Add( new GenericBuyInfo( typeof( Backgammon ), 2, 20, 0xE1C, 0 ) );
				Add( new GenericBuyInfo( typeof( Dices ), 2, 20, 0xFA7, 0 ) );
				Add( new GenericBuyInfo( "1041243", typeof( ContractOfEmployment ), 1252, 20, 0x14F0, 0 ) );
				Add( new GenericBuyInfo( "a barkeep contract", typeof( BarkeepContract ), 1252, 20, 0x14F0, 0 ) );

				if ( Multis.BaseHouse.NewVendorSystem )
					Add( new GenericBuyInfo( "1062332", typeof( VendorRentalContract ), 1252, 20, 0x14F0, 0x672 ) );

				Add( new GenericBuyInfo( typeof( Backpack ), 100, 50, 0x9B2, 0 ) );
				Add( new GenericBuyInfo( typeof( Pouch ), 100, 50, 0xE79, 0 ) );

////////////////////////////////////////////////////// Misc
// All tools sell at a base price of 100 gp
				Add( new GenericBuyInfo( "Candle Boiler", typeof( CandleBoiler ), 100, 500, 0x15F8, 781 ) );
				Add( new GenericBuyInfo( typeof( HeatingStand ), 100, 100, 0x1849, 0 ) ); 
				Add( new GenericBuyInfo( typeof( Candle ), 50, 500, 0xA28, 0 ) );
				Add( new GenericBuyInfo( typeof( Torch ), 50, 500, 0xF6B, 0 ) );

////////////////////////////////////////////////////// Primary Components
				Add( new GenericBuyInfo( "Beeswax", typeof( Beeswax ), 5, 999, 0x1422, 0 ) );
				Add( new GenericBuyInfo( "Iron Ingot", typeof( IronIngot ), 5, 999, 0x1BF2, 0 ) );
				Add( new GenericBuyInfo( "Log", typeof( Log ), 5, 999, 0x1BDD, 0 ) );

////////////////////////////////////////////////////// Secondary Components
				Add( new GenericBuyInfo( "Spool of Thread", typeof( SpoolOfThread ), 1, 999, 0xFA0, 0 ) );

////////////////////////////////////////////////////// Special Components
				Add( new GenericBuyInfo( "Energy Stone", typeof( EnergyStone ), 25, 500, 0xF26, 485 ) );
				Add( new GenericBuyInfo( "Ice Stone", typeof( IceStone ), 25, 500, 0xF26, 1152 ) );
				Add( new GenericBuyInfo( "Serpent Scale", typeof( SerpentScale ), 25, 500, 0x26B4, 69 ) );
			} 
		} 

		public class InternalSellInfo : GenericSellInfo 
		{ 
			public InternalSellInfo() 
			{ 
				Add( typeof( BeverageBottle ), 3 );
				Add( typeof( Jug ), 6 );
				Add( typeof( Pitcher ), 5 );
				Add( typeof( GlassMug ), 1 );
				Add( typeof( BreadLoaf ), 3 );
				Add( typeof( CheeseWheel ), 12 );
				Add( typeof( Ribs ), 6 );
				Add( typeof( Peach ), 1 );
				Add( typeof( Pear ), 1 );
				Add( typeof( Grapes ), 1 );
				Add( typeof( Apple ), 1 );
				Add( typeof( Banana ), 1 );
				Add( typeof( Chessboard ), 1 );
				Add( typeof( CheckerBoard ), 1 );
				Add( typeof( Backgammon ), 1 );
				Add( typeof( Dices ), 1 );
				Add( typeof( ContractOfEmployment ), 626 );
				Add( typeof( WoodenBowlOfCarrots ), 1 );
				Add( typeof( WoodenBowlOfCorn ), 1 );
				Add( typeof( WoodenBowlOfLettuce ), 1 );
				Add( typeof( WoodenBowlOfPeas ), 1 );
				Add( typeof( EmptyPewterBowl ), 1 );
				Add( typeof( PewterBowlOfCorn ), 1 );
				Add( typeof( PewterBowlOfLettuce ), 1 );
				Add( typeof( PewterBowlOfPeas ), 1 );
				Add( typeof( PewterBowlOfPotatos ), 1 );
				Add( typeof( WoodenBowlOfStew ), 1 );
				Add( typeof( WoodenBowlOfTomatoSoup ), 1 );

				Add( typeof( Pouch ), 50 );
				Add( typeof( HeatingStand ), 50 );

				Add( typeof( Beeswax ), 3 );
				Add( typeof( Candle ), 25 );
				Add( typeof( Torch ), 25 );
			} 
		} 
	} 
}
