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
	public class HammerhillInnKeeper : BaseVendor 
	{ 
		private List<SBInfo> m_SBInfos = new List<SBInfo>(); 
		protected override List<SBInfo> SBInfos{ get { return m_SBInfos; } } 

		public override bool InitialInnocent{ get{ return true; } }

		[Constructable]
		public HammerhillInnKeeper() : base( "the innkeeper" ) 
		{ 
		} 

		public override void InitSBInfo() 
		{ 
			m_SBInfos.Add( new SBHammerhillInnKeeper() ); 
		} 

		public override void InitOutfit()
		{
			SetStr( 117 );
			SetDex( 96 );
			SetInt( 54 );

			PackGold( 41, 82 );

			if ( this.Female = Utility.RandomBool() ) 
			{ 
				this.Body = 0x191; 
				this.Name = NameList.RandomName( "female" );
			        this.Hue = Utility.RandomSkinHue(); 

                                this.HairHue = Utility.RandomList( 26,44,81,1102,1107,1108,1109,1116,1117,1122,1138,1140,1141,1146,1148,1149,1153 );
                                this.HairItemID = Utility.RandomList( 8251,8252,8253,8260,8261,8262,8263,8264,8265 );

			        switch ( Utility.Random( 17 ) )
			        {
				       case 0: AddItem( new CitizenDress( Utility.RandomBlueHue() ) ); break;
				       case 1: AddItem( new CommonerDress( Utility.RandomGreenHue() ) ); break;
				       case 2: AddItem( new ConfessorDress( Utility.RandomRedHue() ) ); break;
				       case 3: AddItem( new ElegantGown( Utility.RandomYellowHue() ) ); break;
				       case 4: AddItem( new FancyDress( Utility.RandomBlueHue() ) ); break;
				       case 5: AddItem( new FlowerDress( Utility.RandomGreenHue() ) ); break;
				       case 6: AddItem( new FormalDress( Utility.RandomRedHue() ) ); break;
				       case 7: AddItem( new GildedDress( Utility.RandomYellowHue() ) ); break;
				       case 8: AddItem( new MaidensDress( Utility.RandomBlueHue() ) ); break;
				       case 9: AddItem( new MedievalLongDress( Utility.RandomGreenHue() ) ); break;
				       case 10: AddItem( new NobleDress( Utility.RandomRedHue() ) ); break;
				       case 11: AddItem( new NocturnalDress( Utility.RandomYellowHue() ) ); break;
				       case 12: AddItem( new PartyDress( Utility.RandomBlueHue() ) ); break;
				       case 13: AddItem( new PlainDress( Utility.RandomGreenHue() ) ); break;
				       case 14: AddItem( new ReinassanceDress( Utility.RandomRedHue() ) ); break;
				       case 15: AddItem( new TheaterDress( Utility.RandomYellowHue() ) ); break;
				       case 16: AddItem( new VictorianDress( Utility.RandomNeutralHue() ) ); break;
			        }

			        switch ( Utility.Random( 8 ) )
			        {
				       case 0: AddItem( new Boots( Utility.RandomNeutralHue() ) ); break;
				       case 1: AddItem( new FurBoots( Utility.RandomNeutralHue() ) ); break;
				       case 2: AddItem( new LightBoots( Utility.RandomNeutralHue() ) ); break;
				       case 3: AddItem( new Sandals( Utility.RandomNeutralHue() ) ); break;
				       case 4: AddItem( new ShortBoots( Utility.RandomNeutralHue() ) ); break;
				       case 5: AddItem( new ThighBoots( Utility.RandomNeutralHue() ) ); break;
			        }

			        if ( 0.05 > Utility.RandomDouble() )
                                {
			              SilverBracelet bracelet = new SilverBracelet();
                                      bracelet.Hue = Utility.RandomList( 26,44,81,1102,1107,1108,1109,1116,1117,1122,1138,1140,1141,1146,1148,1149,1153 );
			              bracelet.Movable = true;
			              AddItem( bracelet );
                                }

			        if ( 0.05 > Utility.RandomDouble() )
                                {
			              SilverNecklace necklace = new SilverNecklace();
                                      necklace.Hue = Utility.RandomList( 26,44,81,1102,1107,1108,1109,1116,1117,1122,1138,1140,1141,1146,1148,1149,1153 );
			              necklace.Movable = true;
			              AddItem( necklace );
                                }

			        if ( 0.05 > Utility.RandomDouble() )
                                {
			              SilverEarrings earrings = new SilverEarrings();
                                      earrings.Hue = Utility.RandomList( 26,44,81,1102,1107,1108,1109,1116,1117,1122,1138,1140,1141,1146,1148,1149,1153 );
			              earrings.Movable = true;
			              AddItem( earrings );
                                }
			}
			else 
			{ 
				this.Body = 0x190; 
				this.Name = NameList.RandomName( "male" );
			        this.Hue = Utility.RandomSkinHue();

                                this.HairHue = Utility.RandomList( 26,44,81,1102,1107,1108,1109,1116,1117,1122,1138,1140,1141,1146,1148,1149,1153 );
                                this.HairItemID = Utility.RandomList( 8251,8252,8253,8260,8261,8262,8263,8264,8265 );
                                this.FacialHairHue = Utility.RandomList( 26,44,81,1102,1107,1108,1109,1116,1117,1122,1138,1140,1141,1146,1148,1149,1153 );
                                this.FacialHairItemID = Utility.RandomList( 8254,8255,8256,8257,8267,8268,8269 );

			        switch ( Utility.Random( 8 ) )
			        {
				       case 0: AddItem( new FancyShirt( Utility.RandomBlueHue() ) ); break;
				       case 1: AddItem( new FancyTunic( Utility.RandomGreenHue() ) ); break;
				       case 2: AddItem( new FormalShirt( Utility.RandomRedHue() ) ); break;
				       case 3: AddItem( new LeatherShirt( Utility.RandomYellowHue() ) ); break;
				       case 4: AddItem( new ReinassanceShirt( Utility.RandomBlueHue() ) ); break;
				       case 5: AddItem( new Shirt( Utility.RandomGreenHue() ) ); break;
				       case 6: AddItem( new Surcoat( Utility.RandomRedHue() ) ); break;
				       case 7: AddItem( new Tunic( Utility.RandomNeutralHue() ) ); break;
                                }


			        switch ( Utility.Random( 9 ) )
			        {
				       case 0: AddItem( new FancyPants( Utility.RandomNeutralHue() ) ); break;
				       case 1: AddItem( new FurSarong( Utility.RandomNeutralHue() ) ); break;
				       case 2: AddItem( new Hakama( Utility.RandomNeutralHue() ) ); break;
				       case 3: AddItem( new Kilt( Utility.RandomNeutralHue() ) ); break;
				       case 4: AddItem( new LeatherPants( Utility.RandomNeutralHue() ) ); break;
				       case 5: AddItem( new LongPants( Utility.RandomNeutralHue() ) ); break;
				       case 6: AddItem( new ReinassancePants( Utility.RandomNeutralHue() ) ); break;
				       case 7: AddItem( new ShortPants( Utility.RandomNeutralHue() ) ); break;
				       case 8: AddItem( new TattsukeHakama( Utility.RandomNeutralHue() ) ); break;
                                }

			        switch ( Utility.Random( 6 ) )
			        {
				       case 0: AddItem( new Boots( Utility.RandomNeutralHue() ) ); break;
				       case 1: AddItem( new HeavyBoots( Utility.RandomNeutralHue() ) ); break;
				       case 2: AddItem( new HighBoots( Utility.RandomNeutralHue() ) ); break;
				       case 3: AddItem( new Shoes( Utility.RandomNeutralHue() ) ); break;
				       case 4: AddItem( new ShortBoots( Utility.RandomNeutralHue() ) ); break;
				       case 5: AddItem( new ThighBoots( Utility.RandomNeutralHue() ) ); break;
                                }


			        if ( 0.05 > Utility.RandomDouble() )
                                {
			              SilverBracelet bracelet = new SilverBracelet();
                                      bracelet.Hue = Utility.RandomList( 26,44,81,1102,1107,1108,1109,1116,1117,1122,1138,1140,1141,1146,1148,1149,1153 );
			              bracelet.Movable = true;
			              AddItem( bracelet );
                                }

			        if ( 0.05 > Utility.RandomDouble() )
                                {
			              SilverEarrings earrings = new SilverEarrings();
                                      earrings.Hue = Utility.RandomList( 26,44,81,1102,1107,1108,1109,1116,1117,1122,1138,1140,1141,1146,1148,1149,1153 );
			              earrings.Movable = true;
			              AddItem( earrings );
                                }
			} 

			if ( 0.05 > Utility.RandomDouble() )
				AddItem( new BodySash( Utility.RandomDyedHue() ) );

			if ( 0.05 > Utility.RandomDouble() )
                        {
			        switch ( Utility.Random( 6 ) )
			        {
				      case 0: AddItem( new Bandana( Utility.RandomDyedHue() ) ); break;
				      case 1: AddItem( new Bonnet( Utility.RandomDyedHue() ) ); break;
				      case 2: AddItem( new Cap( Utility.RandomDyedHue() ) ); break;
				      case 3: AddItem( new FeatheredHat( Utility.RandomDyedHue() ) ); break;
				      case 4: AddItem( new SkullCap( Utility.RandomDyedHue() ) ); break;
				      case 5: AddItem( new WideBrimHat( Utility.RandomDyedHue() ) ); break;
			        }
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
                    private HammerhillInnKeeper m_InnKeeper;

                    public RepairTarget(HammerhillInnKeeper innkeeper): base(12, false, TargetFlags.None)
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

		public HammerhillInnKeeper( Serial serial ) : base( serial ) 
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

	public class SBHammerhillInnKeeper: SBInfo 
	{ 
		private List<GenericBuyInfo> m_BuyInfo = new InternalBuyInfo(); 
		private IShopSellInfo m_SellInfo = new InternalSellInfo(); 

		public SBHammerhillInnKeeper() 
		{ 
		} 

		public override IShopSellInfo SellInfo { get { return m_SellInfo; } } 
		public override List<GenericBuyInfo> BuyInfo { get { return m_BuyInfo; } } 

		public class InternalBuyInfo : List<GenericBuyInfo> 
		{ 
			public InternalBuyInfo() 
			{ 
				Add( new BeverageBuyInfo( typeof( Pitcher ), BeverageType.Milk, 25, 35, 0x9F0, 0 ) );
				Add( new BeverageBuyInfo( typeof( Pitcher ), BeverageType.Cider, 30, 14, 0x1F97, 0 ) );
				Add( new BeverageBuyInfo( typeof( Pitcher ), BeverageType.Water, 30, 48, 0x1F9D, 0 ) );

				Add( new GenericBuyInfo( typeof( BreadLoaf ), 26, 78, 0x103B, 0 ) );
				Add( new GenericBuyInfo( typeof( CheeseWheel ), 28, 69, 0x97E, 0 ) );

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
				Add( typeof( Pouch ), 50 );
				Add( typeof( HeatingStand ), 50 );

				Add( typeof( Beeswax ), 3 );
				Add( typeof( Candle ), 25 );
				Add( typeof( Torch ), 25 );
			} 
		} 
	} 
}
