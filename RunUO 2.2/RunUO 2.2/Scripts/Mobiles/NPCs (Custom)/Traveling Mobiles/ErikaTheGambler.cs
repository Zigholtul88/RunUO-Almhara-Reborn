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
    public class ErikaTheGambler : BaseGuardian
    {
        Point3D[] MoveLocations =
        {
            new Point3D( 468, 1945, 20 ),//Harashi Nabi Desert [Orwick Farmhouse]
            new Point3D( 1850, 434, 35 ),//Coven's Landing [The Winchester]
            new Point3D( 712, 802, 4 ),//Alytharr Tavern
            new Point3D( 1134, 938, 15 ),//Zaythalor Tavern
            new Point3D( 509, 866, -5 ),//Alytharr Beach Home
            new Point3D( 125, 1575, 0 ),//St. Abitha Monastery
            new Point3D( 125, 967, 5 ),//Tiki Hut
            new Point3D( 1361, 1106, 2 ) //Zaythalor Zoo
        };

        private MoveTimer m_Timer;

		[Constructable]
		public ErikaTheGambler() : base( AIType.AI_Mage, FightMode.Closest, 10, 1, 0.2, 0.4 )
		{
			Name = "Erika";
			Title = "the Gambler"; 
                 	Body = 401;
                        Female = true;
                        Race = Race.Human;
                        Hue = 33820;
                        HairItemID = 8265;
                        HairHue = 1109;

			SetStr( 157 );
			SetDex( 91 );
			SetInt( 168 );

			SetHits( 250 );
			SetMana( 500 );

			SetDamage( 5, 10 );

			SetSkill( SkillName.EvalInt, 55.5, 75.0 );
			SetSkill( SkillName.Magery, 76.7, 82.3 );
			SetSkill( SkillName.MagicResist, 25.5, 30.0 );
			SetSkill( SkillName.Meditation, 68.1, 73.4 );
			SetSkill( SkillName.Wrestling, 85.5, 90.5 );

			Karma = 2000;

			AddItem( new BodySash(2405) );
			AddItem( new FancyShirt(53) );
			AddItem( new WoodlandBelt(2405) );
			AddItem( new FancyPants(53) );
			AddItem( new LightBoots(2405) );

			LeatherGloves gloves = new LeatherGloves();
			gloves.Hue = 2405;
			gloves.Movable = true;
			AddItem( gloves );

			Container pack = new Backpack();

			pack.DropItem( new Gold( Utility.RandomMinMax( 125, 175 ) ) );
			pack.DropItem( new BlackPearl( Utility.RandomMinMax( 5, 10 ) ) );
			pack.DropItem( new Bloodmoss( Utility.RandomMinMax( 5, 10 ) ) );
			pack.DropItem( new Garlic( Utility.RandomMinMax( 5, 10 ) ) );
			pack.DropItem( new Ginseng( Utility.RandomMinMax( 5, 10 ) ) );
			pack.DropItem( new MandrakeRoot( Utility.RandomMinMax( 5, 10 ) ) );
			pack.DropItem( new Nightshade( Utility.RandomMinMax( 5, 10 ) ) );
			pack.DropItem( new SpidersSilk( Utility.RandomMinMax( 5, 10 ) ) );
			pack.DropItem( new SulfurousAsh( Utility.RandomMinMax( 5, 10 ) ) );

			PackItem( pack );

			switch ( Utility.Random( 32 ))
			{
					case 0: PackItem( new ClumsyScroll() ); break;
					case 1: PackItem( new CreateFoodScroll() ); break;
					case 2: PackItem( new FeeblemindScroll() ); break;
					case 3: PackItem( new HealScroll() ); break;
					case 4: PackItem( new MagicArrowScroll() ); break;
					case 5: PackItem( new NightSightScroll() ); break;
					case 6: PackItem( new ReactiveArmorScroll() ); break;
					case 7: PackItem( new WeakenScroll() ); break;
					case 8: PackItem( new AgilityScroll() ); break;
					case 9: PackItem( new CunningScroll() ); break;
					case 10: PackItem( new CureScroll() ); break;
					case 11: PackItem( new HarmScroll() ); break;
					case 12: PackItem( new MagicTrapScroll() ); break;
					case 13: PackItem( new MagicUnTrapScroll() ); break;
					case 14: PackItem( new ProtectionScroll() ); break;
					case 15: PackItem( new StrengthScroll() ); break;
					case 16: PackItem( new BlessScroll() ); break;
					case 17: PackItem( new FireballScroll() ); break;
					case 18: PackItem( new MagicLockScroll() ); break;
					case 19: PackItem( new PoisonScroll() ); break;
					case 20: PackItem( new TelekinisisScroll() ); break;
					case 21: PackItem( new TeleportScroll() ); break;
					case 22: PackItem( new UnlockScroll() ); break;
					case 23: PackItem( new WallOfStoneScroll() ); break;
					case 24: PackItem( new ArchCureScroll() ); break;
					case 25: PackItem( new ArchProtectionScroll() ); break;
					case 26: PackItem( new CurseScroll() ); break;
					case 27: PackItem( new FireFieldScroll() ); break;
					case 28: PackItem( new GreaterHealScroll() ); break;
					case 29: PackItem( new LightningScroll() ); break;
					case 30: PackItem( new ManaDrainScroll() ); break;
					case 31: PackItem( new RecallScroll() ); break;
			}

                 m_Timer = new MoveTimer( this );
                 ChangeLocation();

		}

        public void ChangeLocation()
        {
            this.MoveToWorld(MoveLocations[Utility.Random(MoveLocations.Length)], Map.Malas);
            this.Hidden = true; //Arrives Hidden
        }

		public override void OnDamage( int amount, Mobile from, bool willKill )
		{
			if ( from != null && !willKill && amount > 5 && from.Player && 5 > Utility.Random( 100 ) )
			{
				string[] toSay = new string[]
					{
						"{0}!!  My hair demands that you bow down to my glorious reign!",
						"{0}!!  Oh fuck off you hairy bastard!",
						"{0}!!  Prepare to savor a mere taste of my supreme power!",
						"{0}!!  Not losing to some ill-gotten buffoon tonight!"
					};

				this.Say( true, String.Format( toSay[Utility.Random( toSay.Length )], from.Name ) );
			}

			base.OnDamage( amount, from, willKill );
		}

		public override bool BardImmune{ get{ return !Core.AOS; } }
		public override bool Unprovokable{ get{ return Core.AOS; } }
		public override bool AreaPeaceImmune{ get{ return Core.AOS; } }

		public ErikaTheGambler( Serial serial ) : base( serial ) 
		{ 
		} 

		public override void GetContextMenuEntries( Mobile from, List<ContextMenuEntry> list ) 
		{
			base.GetContextMenuEntries( from, list );
			list.Add( new ErikaTheGamblerEntry( from, this ) );
		}

		public class ErikaTheGamblerEntry : ContextMenuEntry
		{
			private Mobile m_Mobile;
			private Mobile m_Giver;
			
			public ErikaTheGamblerEntry( Mobile from, Mobile giver ) : base( 6146, 3 )
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
					if ( ! mobile.HasGump( typeof( ErikaTheGamblerGump ) ) )
					{
						mobile.SendGump( new ErikaTheGamblerGump( mobile ));
						
					}
				}
			}
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
            m_Timer = new MoveTimer( this );
        }

        private class MoveTimer : Timer
        {
            private ErikaTheGambler m_Owner;

            public MoveTimer( ErikaTheGambler owner ) : base( TimeSpan.FromHours( 1 ), TimeSpan.FromHours( 1 ) )
            {
                m_Owner = owner;
                TimerThread.PriorityChange( this, 7 );
            }

            protected override void OnTick()
            {
                if ( m_Owner == null )
                {
                    Stop();
                    return;
                }
                else if ( m_Owner.Hits == m_Owner.HitsMax ) 
                {
                    m_Owner.ChangeLocation();
                }
            }
        }
    }
}