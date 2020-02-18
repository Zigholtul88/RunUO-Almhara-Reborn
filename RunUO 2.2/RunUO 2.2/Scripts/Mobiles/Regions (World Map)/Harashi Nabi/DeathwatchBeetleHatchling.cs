using System;
using System.Collections;
using System.Collections.Generic;
using Server;
using Server.ContextMenus;
using Server.Items;
using Server.Misc;
using Server.Mobiles;
using Server.Targeting;

namespace Server.Mobiles
{
	[CorpseName( "a deathwatchbeetle hatchling corpse" )]
	[TypeAlias( "Server.Mobiles.DeathWatchBeetleHatchling" )]
	public class DeathwatchBeetleHatchling : BaseCreature
	{
		public override WeaponAbility GetWeaponAbility()
		{
			return WeaponAbility.BleedAttack;
		}

		[Constructable]
		public DeathwatchBeetleHatchling() : base( AIType.AI_Melee, FightMode.Aggressor, 10, 1, 0.2, 0.4 )
		{
			Name = "a deathwatch beetle hatchling";
			Body = 242;

			SetStr( 26, 50 );
			SetDex( 41, 52 );
			SetInt( 21, 30 );

			SetHits( 400, 550 );
			SetMana( 20 );

			SetDamage( 2, 8 );

			SetDamageType( ResistanceType.Physical, 100 );

			SetResistance( ResistanceType.Physical, 35 );
			SetResistance( ResistanceType.Fire, 15 );
			SetResistance( ResistanceType.Cold, -50 );
			SetResistance( ResistanceType.Poison, 20 );
			SetResistance( ResistanceType.Energy, 20 );

			SetSkill( SkillName.Anatomy, 20.1, 24.0 );
			SetSkill( SkillName.MagicResist, 30.1, 38.0 );
			SetSkill( SkillName.Ninjitsu, 100.0 );
			SetSkill( SkillName.Tactics, 97.1, 99.0 );
			SetSkill( SkillName.Wrestling, 90.1, 100.0 );

			Fame = 700;
			Karma = -700;

                        PackGold( 107, 212 ); 

			if( Utility.RandomBool() )
			{
				Item i = Loot.RandomReagent();
				i.Amount = 25;
				PackItem( i );
			}
		}

		public override int GetIdleSound() { return 0x4F2; } 
		public override int GetAngerSound() { return 0x4F3; }
		public override int GetAttackSound() { return 0x4F1; }
		public override int GetHurtSound() { return 0x4F4; } 
		public override int GetDeathSound() { return 0x4F0; }

		public override void GenerateLoot()
		{
			AddLoot( LootPack.LowScrolls, 1 );
			AddLoot( LootPack.Potions, 1 );
		}

		private DateTime m_NextAttack;

		public override void OnActionCombat()
		{
			Mobile combatant = Combatant;

			if ( combatant == null || combatant.Deleted || combatant.Map != Map || !InRange( combatant, 12 ) || !CanBeHarmful( combatant ) || !InLOS( combatant ) )
				return;

			if ( DateTime.Now >= m_NextAttack )
			{
				SandAttack( combatant );
				m_NextAttack = DateTime.Now + TimeSpan.FromSeconds( 10.0 + (10.0 * Utility.RandomDouble()) );
			}
		}

		public void SandAttack( Mobile m )
		{
			DoHarmful( m );

			m.FixedParticles( 0x36B0, 10, 25, 9540, 2413, 0, EffectLayer.Waist );

			new InternalTimer( m, this ).Start();
		}

		private class InternalTimer : Timer
		{
			private Mobile m_Mobile, m_From;

			public InternalTimer( Mobile m, Mobile from ) : base( TimeSpan.FromSeconds( 1.0 ) )
			{
				m_Mobile = m;
				m_From = from;
				Priority = TimerPriority.TwoFiftyMS;
			}

			protected override void OnTick()
			{
				m_Mobile.PlaySound( 0x4CF );
				AOS.Damage( m_Mobile, m_From, Utility.RandomMinMax( 1, 30 ), 90, 10, 0, 0, 0 );
			}
		}

		public DeathwatchBeetleHatchling( Serial serial ) : base( serial )
		{
		}
		public override int Hides{ get{ return 8; } }
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