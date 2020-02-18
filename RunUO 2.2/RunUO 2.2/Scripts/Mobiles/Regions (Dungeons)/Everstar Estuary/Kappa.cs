using System;
using System.Collections;
using Server;
using Server.Network;
using Server.Items;

namespace Server.Mobiles
{
	[CorpseName( "a kappa corpse" )]
	public class Kappa : BaseCreature
	{
		public override double BoostedSpeed{ get{ return 0.1; } }
		public override bool ReduceSpeedWithDamage{ get{ return false; } }

		[Constructable]
		public Kappa() : base( AIType.AI_Melee, FightMode.Closest, 10, 1, 0.2, 0.4 )
		{
			Name = "a kappa";
			Body = 240;

			SetStr( 186, 230 );
			SetDex( 51, 75 );
			SetInt( 41, 55 );

			SetMana ( 30 );

			SetHits( 250, 320 );

			SetDamage( 6, 12 );

			SetDamageType( ResistanceType.Physical, 100 );

			SetResistance( ResistanceType.Physical, 35 );
			SetResistance( ResistanceType.Fire, 35 );
			SetResistance( ResistanceType.Cold, 25 );
			SetResistance( ResistanceType.Poison, 35 );
			SetResistance( ResistanceType.Energy, 5 );

			SetSkill( SkillName.MagicResist, 60.1, 70.0 );
			SetSkill( SkillName.Tactics, 79.1, 89.0 );
			SetSkill( SkillName.Wrestling, 60.1, 70.0 );

			Fame = 13500;
			Karma = -13500;

			Container pack = new Backpack();
			pack.DropItem( new Gold( Utility.RandomMinMax( 16, 32 ) ) );

			if ( 0.04 > Utility.RandomDouble() )
				pack.DropItem( new Amethyst() );

			if ( 0.03 > Utility.RandomDouble() )
				pack.DropItem( Loot.RandomGem() );

 		      if ( Utility.RandomDouble() < 0.15 )
                  {
			     BaseClothing clothing1 = Loot.RandomClothing( true );
		           BaseRunicTool.ApplyAttributesTo( clothing1, 3, 10, 25 );  

                       pack.DropItem( clothing1 );
                  }

 		      if ( Utility.RandomDouble() < 0.15 )
                  {
			     BaseClothing clothing2 = Loot.RandomClothing( true );
		           BaseRunicTool.ApplyAttributesTo( clothing2, 3, 10, 25 );  

                       pack.DropItem( clothing2 );
                  }

 		      if ( Utility.RandomDouble() < 0.15 )
                  {
			     BaseWeapon weapon = Loot.RandomWeapon( true );
		           BaseRunicTool.ApplyAttributesTo( weapon, 3, 10, 25 );  

                       pack.DropItem( weapon );
                  }

 		      if ( Utility.RandomDouble() < 0.15 )
                  {
			     BaseJewel necklace = new GoldNecklace();
			     if ( Core.AOS )
		           BaseRunicTool.ApplyAttributesTo( necklace, 2, 10, 15 ); 

                       pack.DropItem( necklace );
                  }

			PackItem( pack );

			switch ( Utility.Random( 3 ))
			{
				case 0: AddItem( Loot.RandomArmor() ); break;
				case 1: AddItem( Loot.RandomClothing() ); break;
				case 2: AddItem( Loot.RandomWeapon() ); break;
			}
		}

		public override void GenerateLoot()
		{
			AddLoot( LootPack.Rich );
		}
		 
		public override int GetAngerSound()
		{
			return 0x50B;
		}

		public override int GetIdleSound()
		{
			return 0x50A;
		}

		public override int GetAttackSound()
		{
			return 0x509;
		}

		public override int GetHurtSound()
		{
			return 0x50C;
		}

		public override int GetDeathSound()
		{
			return 0x508;
		}

		public override void OnHarmfulSpell( Mobile from )
		{
			if ( !Controlled && ControlMaster == null )
				CurrentSpeed = BoostedSpeed;
		}

		public override void OnCombatantChange()
		{
			if ( Combatant == null && !Controlled && ControlMaster == null )
				CurrentSpeed = PassiveSpeed;
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

		public override void OnDamage( int amount, Mobile from, bool willKill )
		{
			if ( from != null && from.Map != null )
			{
				int amt=0;
				Mobile target = this; 
				int rand = Utility.Random( 1, 100 );
				if ( willKill )
				{
					amt = ((( rand % 5 ) >> 2 ) + 3);
				} 
				if ( ( Hits < 100 ) && ( rand < 21 ) ) 
				{
					target = ( rand % 2 ) < 1 ? this : from;
					amt++;
				}
				if ( amt > 0 )
				{
					SpillAcid( target, amt );
					from.SendLocalizedMessage( 1070820 ); 
					if ( Mana > 14)
						Mana -= 15;
					amt ^= amt;
				}
			}
			base.OnDamage( amount, from, willKill );
		}

		public override Item NewHarmfulItem()
		{
			return new AcidSlime( TimeSpan.FromSeconds(10), 5, 10 );
		}

		public Kappa( Serial serial ) : base( serial )
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

				if ( ++m_Count == 5 )
					EndLifeDrain( m_Mobile );
			}
		}
	}
}
