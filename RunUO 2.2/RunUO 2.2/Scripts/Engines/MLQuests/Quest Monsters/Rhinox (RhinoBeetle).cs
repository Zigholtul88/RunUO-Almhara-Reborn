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
	[CorpseName( "the corpse of Rhinox" )]
	public class Rhinox : BaseCreature
	{
		public override WeaponAbility GetWeaponAbility()
		{
			return WeaponAbility.BleedAttack;
		}

		[Constructable]
		public Rhinox() : base( AIType.AI_Melee, FightMode.Aggressor, 10, 1, 0.175, 0.350 )
		{
			Name = "Rhinox";
			Body = 247;

			SetStr( 79, 92 );
			SetDex( 56, 85 );
			SetInt( 24, 31 );

			SetHits( 700 );
			SetMana( 30 );

			SetDamage( 11, 15 );

			SetDamageType( ResistanceType.Physical, 100 );

			SetResistance( ResistanceType.Physical, 100 );

			SetSkill( SkillName.Bushido, 120.0 );
			SetSkill( SkillName.MagicResist, 15.7, 25.7 );
			SetSkill( SkillName.Parry, 120.0 );
			SetSkill( SkillName.Tactics, 120.0 );
			SetSkill( SkillName.Wrestling, 120.0 );

			Fame = 15000;
			Karma = -15000;

			PackGold( 500, 1000 );
		}

                public override bool OnBeforeDeath()
                {
                        this.Say("OH HELL NO!");

                        return base.OnBeforeDeath();
                }

		public override bool CanRummageCorpses{ get{ return true; } }

		public override bool HasBreath{ get{ return true; } } // rock throw enabled

		public override double BreathMinDelay{ get{ return 20.0; } }
		public override double BreathMaxDelay{ get{ return 30.0; } }

		public override int BreathPhysicalDamage{ get{ return 100; } }
	        public override int BreathFireDamage{ get{ return 0; } }
		public override int BreathColdDamage{ get{ return 0; } }
		public override int BreathPoisonDamage{ get{ return 0; } }
		public override int BreathEnergyDamage{ get{ return 0; } }

		public override int BreathEffectHue{ get{ return 2405; } }
		public override int BreathEffectItemID{ get{ return 0x1363; } }
		public override int BreathEffectSound{ get{ return 0x5D3; } }
		public override int BreathAngerSound{ get{ return 0x21D; } }

		public override int GetAngerSound() { return 0x21D; } 
		public override int GetIdleSound() { return 0x21D; } 
		public override int GetAttackSound() { return 0x162; } 
		public override int GetHurtSound() { return 0x163; } 
		public override int GetDeathSound() { return 0x21D; }

                public override void OnCarve( Mobile from, Corpse corpse, Item with )
		{
			if ( corpse.Carved == false )
			{
			      base.OnCarve( from, corpse, with );

                              corpse.AddCarvedItem( new IronIngot( Utility.RandomMinMax( 500, 800 ) ), from );
                              corpse.AddCarvedItem( new BeetleEgg( Utility.RandomMinMax( 100, 200 ) ), from );

                              from.SendMessage( "You carve up some beetle eggs and in addition some iron ingots." );
                              corpse.Carved = true; 
			}
                }

		public override void OnGaveMeleeAttack(Mobile defender)
 		{
			base.OnGaveMeleeAttack (defender);

			if ( Utility.RandomBool() )
			{
				if ( !IsBeingDrained( defender ) && Mana > 14)
				{
					defender.SendLocalizedMessage( 1070848 ); // You feel your life force being stolen away.
					BeginLifeDrain( defender, this );
					Mana-=15;
				}
			}
		}

		private static Hashtable m_Table = new Hashtable();

		public static bool IsBeingDrained( Mobile m )
		{
			return m_Table.Contains( m );
		}

		public static void BeginLifeDrain( Mobile m, Mobile from )
		{
			Timer t = (Timer)m_Table[m];

			if ( t != null )
				t.Stop();

			t = new InternalTimer( from, m );
			m_Table[m] = t;

			t.Start();
		}

		public static void DrainLife( Mobile m, Mobile from )
		{
			if ( m.Alive )
			{
				int damageGiven = AOS.Damage( m, from, 5, 0, 0, 0, 0, 100 );
				from.Hits += damageGiven;
			}
			else
			{
				EndLifeDrain( m );
			}
		}

		public static void EndLifeDrain( Mobile m )
		{
			Timer t = (Timer)m_Table[m];

			if ( t != null )
				t.Stop();

			m_Table.Remove( m );

			m.SendLocalizedMessage( 1070849 ); // The drain on your life force is gone.
		}

		public Rhinox( Serial serial ) : base( serial )
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
		}

		private class InternalTimer : Timer
		{
			private Mobile m_From;
			private Mobile m_Mobile;
			private int m_Count;

			public InternalTimer( Mobile from, Mobile m ) : base( TimeSpan.FromSeconds( 1.0 ), TimeSpan.FromSeconds( 1.0 ) )
			{
				m_From = from;
				m_Mobile = m;
				Priority = TimerPriority.TwoFiftyMS;
			}

			protected override void OnTick()
			{
				DrainLife( m_Mobile, m_From );

				if ( Running && ++m_Count == 5 )
					EndLifeDrain( m_Mobile );
			}
		}
	}
}