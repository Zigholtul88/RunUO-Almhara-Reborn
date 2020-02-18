using System;
using System.Collections;
using Server;
using Server.Items;
using Server.Misc;
using Server.Mobiles;
using Server.Network;

namespace Server.Mobiles
{
	[CorpseName( "a grat corpse" )]
	public class Grat : BaseCreature
	{
		private bool m_Stunning;

		[Constructable]
		public Grat() : base( AIType.AI_Melee, FightMode.Closest, 10, 1, 0.4, 0.8 )
		{
			Name = "a grat";
			Body = 789;
			Hue = Utility.RandomList( 1276,1287,1266,232,83,1408 );

			SetStr( 412, 471 );
			SetDex( 146, 200 );
			SetInt( 144, 185 );

			SetHits( 405, 425 );

			SetDamage( 16, 21 );

			SetDamageType( ResistanceType.Physical, 60 );
			SetDamageType( ResistanceType.Poison, 40 );

			SetResistance( ResistanceType.Physical, 45 );
			SetResistance( ResistanceType.Fire, 40 );
			SetResistance( ResistanceType.Cold, 40 );
			SetResistance( ResistanceType.Poison, -50 );
			SetResistance( ResistanceType.Energy, 40 );

			SetSkill( SkillName.MagicResist, 45.1, 55.0 );
			SetSkill( SkillName.Tactics, 90.1, 100.0 );
			SetSkill( SkillName.Wrestling, 60.1, 80.0 );

			Fame = 9000;
			Karma = -9000;

			m_NextAbilityTime = DateTime.UtcNow + TimeSpan.FromSeconds( Utility.RandomMinMax( 5, 30 ) );
		}

		public override void GenerateLoot()
		{
			AddLoot( LootPack.MedScrolls, 2 );
			AddLoot( LootPack.LowScrolls, 3 );
			AddLoot( LootPack.Gems, 2 );
	        }

		public override int GetIdleSound() { return 0x017; }
		public override int GetAngerSound() { return 0x018; }
		public override int GetAttackSound() { return 0x01E; }
		public override int GetHurtSound() { return 0x01D; }
		public override int GetDeathSound() { return 0x01A; }

		public override void OnGaveMeleeAttack( Mobile defender )
		{
			base.OnGaveMeleeAttack( defender );

			if ( !m_Stunning && 0.3 > Utility.RandomDouble() )
			{
				m_Stunning = true;

				defender.Animate( 21, 6, 1, true, false, 0 );
				this.PlaySound( 0xEE );
				defender.LocalOverheadMessage( MessageType.Regular, 0x3B2, false, "You have been stunned by a colossal blow!" );

				BaseWeapon weapon = this.Weapon as BaseWeapon;
				if ( weapon != null )
					weapon.OnHit( this, defender );

				if ( defender.Alive )
				{
					defender.Frozen = true;
					Timer.DelayCall( TimeSpan.FromSeconds( 5.0 ), new TimerStateCallback( Recover_Callback ), defender );
				}
			}
		}

		private void Recover_Callback( object state )
		{
			Mobile defender = state as Mobile;

			if ( defender != null )
			{
				defender.Frozen = false;
				defender.Combatant = null;
				defender.LocalOverheadMessage( MessageType.Regular, 0x3B2, false, "You recover your senses." );
			}

			m_Stunning = false;
		}

		private DateTime m_NextAbilityTime;

		public override void OnActionCombat()
		{
			Mobile combatant = Combatant;

			if ( DateTime.UtcNow < m_NextAbilityTime || combatant == null || combatant.Deleted || combatant.Map != Map || !InRange( combatant, 5 ) || !CanBeHarmful( combatant ) || !InLOS( combatant ) )
				return;

			m_NextAbilityTime = DateTime.UtcNow + TimeSpan.FromSeconds( Utility.RandomMinMax( 5, 30 ) );

			if ( Utility.RandomBool() )
			{
				this.FixedParticles( 0x376A, 9, 32, 0x2539, EffectLayer.LeftHand );
				this.PlaySound( 0x1DE );

				foreach ( Mobile m in this.GetMobilesInRange( 5 ) )
				{
					if ( m != this && IsEnemy( m ) )
					{
						m.ApplyPoison( this, Poison.Deadly );
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

                              corpse.AddCarvedItem( new Gold( Utility.RandomMinMax( 1225, 2342 ) ), from );
                              corpse.AddCarvedItem( new Nirnroot( Utility.RandomMinMax( 15, 27 ) ), from );

                              corpse.AddCarvedItem( new GratNectar( amount ), from );

                              from.SendMessage( "Upon finding gold, you also carve up some nirnroot and some grat nectar." );
                              corpse.Carved = true;
			}
                }

		public Grat( Serial serial ) : base( serial )
		{
		}

		public override void Serialize(GenericWriter writer)
		{
			base.Serialize(writer);

			writer.Write((int) 0);
		}

		public override void Deserialize(GenericReader reader)
		{
			base.Deserialize(reader);

			int version = reader.ReadInt();
		}
	}
}