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
	public class ElmhavenInnKeeper : BaseVendor 
	{ 
		private List<SBInfo> m_SBInfos = new List<SBInfo>(); 
		protected override List<SBInfo> SBInfos{ get { return m_SBInfos; } } 


		[Constructable]
		public ElmhavenInnKeeper() : base( "the innkeeper" ) 
		{ 
		} 

		public override void InitSBInfo() 
		{ 
			m_SBInfos.Add( new SBElmhavenInnKeeper() ); 
		} 

		public override void InitOutfit()
		{
			Name = "Jermaine";
                 	Body = 400;
                        Female = false;
                        Race = Race.Human;
                        Hue = 33791;
                        HairItemID = 8264;
                        HairHue = 1108;
                        FacialHairItemID = 8255;
                        FacialHairHue = 1108;

			SetStr( 112 );
			SetDex( 57 );
			SetInt( 23 );

			SetSkill( SkillName.Anatomy, 60.0, 83.0 );
			SetSkill( SkillName.Tactics, 60.0, 83.0 );
			SetSkill( SkillName.Wrestling, 60.0, 83.0 );

			PackGold( 9, 28 );

			AddItem( new StrawHat(653) );
			AddItem( new Cloak(808) );
			AddItem( new FancyShirt(523) );
			AddItem( new ReinassancePants(788) );
			AddItem( new ShortBoots(883) );
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
                    private ElmhavenInnKeeper m_InnKeeper;

                    public RepairTarget(ElmhavenInnKeeper innkeeper): base(12, false, TargetFlags.None)
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

		public ElmhavenInnKeeper( Serial serial ) : base( serial ) 
		{ 
		} 

		public override void GetContextMenuEntries( Mobile from, List<ContextMenuEntry> list ) 
		{
			base.GetContextMenuEntries( from, list );
			list.Add( new ElmhavenInnKeeperEntry( from, this ) );
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

		public class ElmhavenInnKeeperEntry : ContextMenuEntry
		{
			private Mobile m_Mobile;
			private Mobile m_Giver;
			
			public ElmhavenInnKeeperEntry( Mobile from, Mobile giver ) : base( 6146, 3 )
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
					if ( ! mobile.HasGump( typeof( ElmhavenInnKeeperGump ) ) )
					{
						mobile.SendGump( new ElmhavenInnKeeperGump( mobile ));
						
					}
				}
			}
		}
        }

	public class SBElmhavenInnKeeper: SBInfo 
	{ 
		private List<GenericBuyInfo> m_BuyInfo = new InternalBuyInfo(); 
		private IShopSellInfo m_SellInfo = new InternalSellInfo(); 

		public SBElmhavenInnKeeper() 
		{ 
		} 

		public override IShopSellInfo SellInfo { get { return m_SellInfo; } } 
		public override List<GenericBuyInfo> BuyInfo { get { return m_BuyInfo; } } 

		public class InternalBuyInfo : List<GenericBuyInfo> 
		{ 
			public InternalBuyInfo() 
			{ 
				Add( new GenericBuyInfo( "Ring of Minor Revigoration", typeof( RingOfMinorRevigoration ), 750, 10, 0x108a, 2597 ) );

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
