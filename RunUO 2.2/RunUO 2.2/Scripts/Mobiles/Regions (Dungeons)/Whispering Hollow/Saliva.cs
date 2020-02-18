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
	[CorpseName( "a Saliva corpse" )]
	public class Saliva : BaseFastEnemy
	{
		public override bool IsScaredOfScaryThings{ get{ return false; } }
		public override bool IsScaryToPets{ get{ return true; } }

		public static TimeSpan TalkDelay = TimeSpan.FromSeconds( 1.0 ); //the delay between talks is 1 second
		public DateTime m_NextTalk;

		public override double BoostedSpeed{ get{ return 0.1; } }
		public override bool ReduceSpeedWithDamage{ get{ return false; } }

		[Constructable]
		public Saliva() : base( AIType.AI_Melee, FightMode.Closest, 8, 1, 0.175, 0.350 )
		{
			CurrentSpeed = BoostedSpeed;
			RangePerception = 200;

			Name = "Saliva";
			Hue = 0x11E;
			Body = 30;
			BaseSoundID = 402;

			SetStr( 110, 206 );
			SetDex( 123, 222 );
			SetInt( 80, 127 );

			SetHits( 4409, 5842 );

			SetDamage( 10, 15 );

			SetDamageType( ResistanceType.Physical, 100 );

			SetResistance( ResistanceType.Physical, 46, 48 );
			SetResistance( ResistanceType.Fire, 32, 40 );
			SetResistance( ResistanceType.Cold, -50 );
			SetResistance( ResistanceType.Poison, 40, 48 );
			SetResistance( ResistanceType.Energy, 35, 39 );

			SetSkill( SkillName.MagicResist, 84.3, 105.0 );
			SetSkill( SkillName.Ninjitsu, 100.0 );
			SetSkill( SkillName.Tactics, 129.9, 141.0 );
			SetSkill( SkillName.Wrestling, 106.4, 128.8 );

			Fame = 52000;
			Karma = -52000;

                        Flying = true;
			FlyTimer.FlyList.Add( this );

			PackGold( 2561, 3938 );
		}

		public override void GenerateLoot()
		{
			AddLoot( LootPack.Gems, 15 );
		}

		public override bool CanRummageCorpses{ get{ return true; } }
		public override bool CanAngerOnTame { get { return true; } }

		public override int GetAttackSound() { return 405; } 
		public override int GetAngerSound() { return 402; } 
		public override int GetDeathSound() { return 406; }
		public override int GetHurtSound() { return 403; } 
		public override int GetIdleSound() { return 404; } 

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
		        public static List<Saliva> FlyList = new List<Saliva>();

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
			        foreach ( Saliva saliva in FlyList )
				        saliva.OnTick();
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
				        m.SendMessage( "Saliva is enraged" );
				        this.Combatant = m;
                                }
 			        else if ( Utility.RandomDouble() < 0.05 )
                                {
			                RangePerception = 300;
				        PlaySound(0x4B2);
				        m.SendMessage( "Saliva is really pissed off" );
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
				from.SendMessage( "Saliva has landed" );
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
				        attacker.SendMessage( "Saliva has landed" );
                                        Flying = false;
				        CurrentSpeed = PassiveSpeed;
			        }
			}
			else if ( Flying )
			{
				attacker.SendMessage( "Your weapon misses Saliva" );
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
                              corpse.AddCarvedItem(new SalivaEye(), from );

                              from.SendMessage( "You carve up feathers, raw harpy ribs, talons, and the eye of Saliva." );
                              corpse.Carved = true; 
			}
                }

                public void AwardDungeonBossKey()
                {
                      List<Mobile> list = new List<Mobile>();

                      foreach ( Mobile m in GetMobilesInRange( 30 ) )
                      {
                             if ( !CanBeHarmful ( m ) )
                             continue;

                             if ( m.Player )
                             list.Add ( m );
                      }

                      foreach ( Mobile m in list )
                      {
                             if ( m == this || !CanBeHarmful( m ) )
                             continue;

                             if ( !m.Player && !( m is BaseCreature && ( (BaseCreature)m).ControlMaster.Player) )
                             continue;

                          if ( m.Player && m.Alive )
                          {
			       m.AddToBackpack( new WhisperingHollowBossKey() );
                               m.SendMessage( "You receive a key needed to get pass the fog gates." );
                               DoHarmful( m );
                          }
                     }
                }

		public override bool OnBeforeDeath( ) //what happens before it dies
		{
		      AwardDungeonBossKey();
                      return base.OnBeforeDeath();
		}

		public Saliva( Serial serial ) : base( serial )
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

			FlyTimer.FlyList.Add(this);
		}
	}
}
