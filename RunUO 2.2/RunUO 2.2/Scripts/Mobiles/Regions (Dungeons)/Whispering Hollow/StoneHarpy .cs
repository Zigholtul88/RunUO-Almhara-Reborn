using System;
using System.Collections;
using System.Collections.Generic;
using Server;
using Server.ContextMenus;
using Server.Items;
using Server.Misc;
using Server.Mobiles;
using Server.Network;
using Server.Targeting;

namespace Server.Mobiles
{
	[CorpseName( "a stone harpy corpse" )]
	public class StoneHarpy : BaseFastEnemy
	{
		public override bool IsScaredOfScaryThings{ get{ return false; } }
		public override bool IsScaryToPets{ get{ return true; } }

		public static TimeSpan TalkDelay = TimeSpan.FromSeconds( 1.0 ); //the delay between talks is 1 second
		public DateTime m_NextTalk;

		public override double BoostedSpeed{ get{ return 0.1; } }
		public override bool ReduceSpeedWithDamage{ get{ return false; } }

		[Constructable]
		public StoneHarpy() : base( AIType.AI_Melee, FightMode.Closest, 8, 1, 0.175, 0.350 )
		{
			CurrentSpeed = BoostedSpeed;
			RangePerception = 200;

			Name = "a stone harpy";
			Body = 73;
			BaseSoundID = 402;

			SetStr( 296, 320 );
			SetDex( 86, 110 );
			SetInt( 51, 75 );

			SetHits( 756, 884 );
			SetMana( 0 );

			SetDamage( 5, 10 );

			SetDamageType( ResistanceType.Physical, 75 );
			SetDamageType( ResistanceType.Poison, 25 );

			SetResistance( ResistanceType.Physical, 50 );
			SetResistance( ResistanceType.Fire, -50 );
			SetResistance( ResistanceType.Cold, 10 );
			SetResistance( ResistanceType.Poison, 30 );
			SetResistance( ResistanceType.Energy, 30 );

			SetSkill( SkillName.MagicResist, 50.1, 65.0 );
			SetSkill( SkillName.Tactics, 70.1, 100.0 );
			SetSkill( SkillName.Wrestling, 70.1, 100.0 );

			Fame = 24500;
			Karma = -24500;

			PackGold( 1224, 2030 );

			PackItem( new Zircon() );

			PackItem( new FishScale( Utility.RandomMinMax( 11, 15 ) ) );

			PackItem( new AgilityScroll() );

                        Flying = true;
			FlyTimer.FlyList.Add( this );
		}

		public override bool CanRummageCorpses{ get{ return true; } }
		public override bool CanAngerOnTame { get { return true; } }

		public override int GetAttackSound() { return 916; } 
		public override int GetAngerSound() { return 916; } 
		public override int GetDeathSound() { return 917; }
		public override int GetHurtSound() { return 919; } 
		public override int GetIdleSound() { return 918; } 

		public void OnTick()
		{
			if ( Flying )
                        {
			        Effects.PlaySound(Location, Map, 0x5FC);
				CurrentSpeed = BoostedSpeed;
                        }
		}

	        public class FlyTimer : Timer 
	        {
		        public const bool Enabled = true;
		        public static List<StoneHarpy> FlyList = new List<StoneHarpy>();

		        public static void Initialize() 
		        {
			        if (Enabled)
				        new FlyTimer().Start();
		        }

		        public FlyTimer() : base(TimeSpan.FromSeconds( 1.0 ), TimeSpan.FromSeconds( 1.0 ) ) 
		        {
			        Priority = TimerPriority.OneSecond;
		        }

		        protected override void OnTick() 
		        {
			        foreach ( StoneHarpy stoneharpy in FlyList )
				        stoneharpy.OnTick();
		        }
	        }

		public override void OnMovement( Mobile m, Point3D oldLocation )
		{
			if ( DateTime.Now >= m_NextTalk && InRange( m, 5 ) && InLOS( m ) && m is PlayerMobile && !m.Hidden ) // check if it's time to talk & mobile in range & in los.
			{
 			        if ( Utility.RandomDouble() < 0.05 )
                                {
			                RangePerception = 200;
				        PlaySound(0x4B2);
				        m.SendMessage( "The stone harpy is enraged" );
				        this.Combatant = m;
                                }
 			        else if ( Utility.RandomDouble() < 0.05 )
                                {
			                RangePerception = 300;
				        PlaySound(0x4B2);
				        m.SendMessage( "The stone harpy is really pissed off" );
				        this.Combatant = m;
                                        this.Flying = true;
                                }

				m_NextTalk = DateTime.Now + TalkDelay; // set next talk time 
				switch ( Utility.Random( 6 ) )
				{
					case 0: Say("*SCREECH*");
						PlaySound(405); 
						break;
					case 1: Say("*EEECHKK*"); 
						PlaySound(402);
						break;	
					case 2: Say("*SCREECH*");
						PlaySound(0x4B2); 
						break;
					case 3: Say("*EEECHKK*"); 
						PlaySound(0x4B3);
						break;
					case 4: Say("*SCREECH*");
						PlaySound(824); 
						break;
					case 5: Say("*EEECHKK*"); 
						PlaySound(794);
						break;
				};
			}
		}

		public override void OnDamage( int amount, Mobile from, bool willKill )
		{
 			if ( Utility.RandomDouble() < 0.25 )
                        {
                                this.Flying = true;
			        this.CurrentSpeed = BoostedSpeed;
			}
		}

		public override void OnDamagedBySpell( Mobile from )
		{
			if ( Flying )
			{
                                Flying = false;
				from.SendMessage( "The stone harpy has landed" );
				CurrentSpeed = PassiveSpeed;
			}
		}

		public override void OnGotMeleeAttack( Mobile attacker )
		{
			base.OnGotMeleeAttack( attacker );

			if( attacker != null && attacker.Alive && attacker.Weapon is BaseRanged )
			{
			        if ( Flying )
			        {
				        attacker.SendMessage( "The stone harpy has landed" );
                                        Flying = false;
				        CurrentSpeed = PassiveSpeed;
			        }
			}
			else if ( Flying )
			{
				attacker.SendMessage( "Your weapon misses the stone harpy" );
			}
		}

		public override void AlterMeleeDamageFrom( Mobile from, ref int damage )
		{
			if ( Flying )
				damage = 0; // no melee damage when flying

			if ( from != null && from != this )
			{
				if ( from is PlayerMobile )
				{
					PlayerMobile p_PlayerMobile = from as PlayerMobile;
					Item weapon1 = p_PlayerMobile.FindItemOnLayer( Layer.OneHanded );
					Item weapon2 = p_PlayerMobile.FindItemOnLayer( Layer.TwoHanded );

					if ( weapon1 != null )
					{
						if ( weapon1 is BaseRanged )
						{
							damage *= 50;
						}
                                                else
                                                {
							damage -= 5;
                                                }
					}
					else if ( weapon2 != null )
					{
						if ( weapon2 is BaseRanged )
						{
							damage *= 50;
						}
                                                else
                                                {
							damage -= 5;
                                                }
					}
				}
			}
		}

                public override void OnCarve( Mobile from, Corpse corpse, Item with )
		{
			if ( corpse.Carved == false )
			{
			      base.OnCarve( from, corpse, with );

			      int amount = 1 + (int)( from.Skills[SkillName.Forensics].Value / 25 );

                              corpse.AddCarvedItem(new Feather(50), from );
                              corpse.AddCarvedItem(new RawHarpyRibs(), from );
                              corpse.AddCarvedItem(new HarpyTalon( amount ), from );

                              from.SendMessage( "You carve up feathers, raw harpy ribs and a talon." );
                              corpse.Carved = true; 
			}
                }

		public StoneHarpy( Serial serial ) : base( serial )
		{
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

			FlyTimer.FlyList.Add(this);
		}
	}
}