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
using Server.Spells;

namespace Server.Mobiles
{
	[CorpseName( "a deathwatchbeetle corpse" )]
	[TypeAlias( "Server.Mobiles.DeathWatchBeetle" )]
	public class DeathwatchBeetle : BaseCreature
	{
		public override WeaponAbility GetWeaponAbility()
		{
			return WeaponAbility.CrushingBlow;
		}

		[Constructable]
		public DeathwatchBeetle() : base( AIType.AI_Melee, FightMode.Aggressor, 10, 1, 0.2, 0.4 ) 
		{
			Name = "a deathwatch beetle";
			Body = 242;

			SetStr( 136, 160 );
			SetDex( 41, 52 );
			SetInt( 31, 40 );

			SetHits( 700, 850 );
			SetMana( 20 );

			SetDamage( 5, 10 );

			SetDamageType( ResistanceType.Physical, 100 );

			SetResistance( ResistanceType.Physical, 35 );
			SetResistance( ResistanceType.Fire, 15 );
			SetResistance( ResistanceType.Cold, -50 );
			SetResistance( ResistanceType.Poison, 50 );
			SetResistance( ResistanceType.Energy, 20 );

			SetSkill( SkillName.Anatomy, 30.1, 34.0 );
			SetSkill( SkillName.MagicResist, 50.1, 58.0 );
			SetSkill( SkillName.Ninjitsu, 120.0 );
			SetSkill( SkillName.Tactics, 67.1, 77.0 );
			SetSkill( SkillName.Wrestling, 50.1, 60.0 );

			Fame = 1400;
			Karma = -1400;

                        PackGold( 207, 312 ); 

			switch ( Utility.Random( 12 ) )
			{
				case 0: PackItem( new LeatherGorget() ); break;
				case 1: PackItem( new LeatherGloves() ); break;
				case 2: PackItem( new LeatherArms() ); break;
				case 3: PackItem( new LeatherLegs() ); break;
				case 4: PackItem( new LeatherCap() ); break;
				case 5: PackItem( new LeatherChest() ); break;
			}

			if ( Utility.RandomDouble() < .5 )
				PackItem( Engines.Plants.Seed.RandomBonsaiSeed() );

			Tamable = true;
			MinTameSkill = 41.1;
			ControlSlots = 1;
		}

		public override int GetIdleSound() { return 0x4F2; } 
		public override int GetAngerSound() { return 0x4F3; }
		public override int GetAttackSound() { return 0x4F1; }
		public override int GetHurtSound() { return 0x4F4; } 
		public override int GetDeathSound() { return 0x4F0; }

                public override bool HasBreath{ get{ return true; } } // fireball enabled

		public override double BreathMinDelay{ get{ return 5.0; } }
		public override double BreathMaxDelay{ get{ return 10.0; } }

		public override int BreathPhysicalDamage{ get{ return 0; } }
	        public override int BreathFireDamage{ get{ return 100; } }
		public override int BreathColdDamage{ get{ return 0; } }
		public override int BreathPoisonDamage{ get{ return 0; } }
		public override int BreathEnergyDamage{ get{ return 0; } }

		public override int BreathEffectHue{ get{ return 1366; } }
		public override int BreathEffectItemID{ get{ return 0x36D4; } }
		public override int BreathEffectSound{ get{ return 0x15E; } }
		public override int BreathAngerSound{ get{ return 849; } }

		public override void GenerateLoot()
		{
			AddLoot( LootPack.LowScrolls, 1 );
			AddLoot( LootPack.Potions, 1 );
		}

		public override void AlterMeleeDamageTo( Mobile to, ref int damage )
		{
			if ( Utility.RandomBool() && (this.Mana > 14) && to != null )
			{
				damage = (damage + (damage / 2));
				to.SendLocalizedMessage( 1060091 ); // You take extra damage from the crushing attack!
				to.PlaySound( 0x1E1 );
				to.FixedParticles( 0x377A, 1, 32, 0x26da, 0, 0, 0 );
				Mana -= 15;
			}
		}

		public override void OnDamage( int amount, Mobile from, bool willKill )
		{
			Mobile combatant = Combatant;

			if ( combatant == null || combatant.Deleted || combatant.Map != Map || !InRange( combatant, 12 ) || !CanBeHarmful( combatant ) || !InLOS( combatant ) )
				return;

			if( Utility.Random( 10 ) == 0 )
				PoisonAttack( combatant );

			base.OnDamage( amount, from, willKill );
		}

		public void PoisonAttack( Mobile m )
		{
			DoHarmful( m );
			this.MovingParticles( m, 0x36D4, 1, 0, false, false, 0x3F, 0, 0x1F73, 1, 0, (EffectLayer)255, 0x100 );
			m.ApplyPoison( this, Poison.Regular );
			m.SendLocalizedMessage( 1070821, this.Name ); // %s spits a poisonous substance at you!
		}

		public override void AlterDamageScalarFrom( Mobile caster, ref double scalar )
		{
			if ( 0.1 >= Utility.RandomDouble() )
				SpawnHatchlings( caster );
		}

		public override void OnGotMeleeAttack( Mobile attacker )
		{
			base.OnGotMeleeAttack( attacker );

			if ( 0.1 >= Utility.RandomDouble() )
				SpawnHatchlings( attacker );
		}

		public void SpawnHatchlings( Mobile target )
		{
			Map map = this.Map;

			if ( map == null )
				return;

			int newDeathwatchBeetleHatchlings = Utility.RandomMinMax( 1, 4 );

			for ( int i = 0; i < newDeathwatchBeetleHatchlings; ++i )
			{
				DeathwatchBeetleHatchling hatchling = new DeathwatchBeetleHatchling();

				hatchling.Team = this.Team;
				hatchling.FightMode = FightMode.Closest;

				bool validLocation = false;
				Point3D loc = this.Location;

				for ( int j = 0; !validLocation && j < 10; ++j )
				{
					int x = X + Utility.Random( 3 ) - 1;
					int y = Y + Utility.Random( 3 ) - 1;
					int z = map.GetAverageZ( x, y );

					if ( validLocation = map.CanFit( x, y, this.Z, 16, false, false ) )
						loc = new Point3D( x, y, Z );
					else if ( validLocation = map.CanFit( x, y, z, 16, false, false ) )
						loc = new Point3D( x, y, z );
				}

				hatchling.MoveToWorld( loc, map );
				hatchling.Combatant = target;
			}
		}

		public override int Hides{ get{ return 8; } }	

                public override void OnCarve( Mobile from, Corpse corpse, Item with )
		{
			if ( corpse.Carved == false )
			{
			      base.OnCarve( from, corpse, with );

                              corpse.AddCarvedItem( new DeathwatchBeetleEgg(), from );

                              from.SendMessage( "You carve up some deathwatch beetle parts." );
                              corpse.Carved = true; 
			}
                }

		public DeathwatchBeetle( Serial serial ) : base( serial )
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
	}
}