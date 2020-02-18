using System;
using System.Collections;
using System.Collections.Generic;
using Server;
using Server.ContextMenus;
using Server.Items;
using Server.Mobiles;
using Server.Misc;
using Server.Network;
using Server.Targeting;

namespace Server.Mobiles
{
	[CorpseName( "the corpse of Taurion" )]
	public class Taurion : BaseCreature
	{
		public override WeaponAbility GetWeaponAbility()
		{
			return WeaponAbility.ParalyzingBlow;
		}

		[Constructable]
		public Taurion() : base( AIType.AI_Melee, FightMode.Closest, 10, 1, 0.2, 0.4 ) // NEED TO CHECK
		{
			Name = "Taurion";
			Body = 263;

			SetStr( 600 );
			SetDex( 450 );
			SetInt( 350 );

			SetHits( 3000, 3500 );

			SetDamage( 4, 8 );

			SetDamageType( ResistanceType.Physical, 100 );

			SetResistance( ResistanceType.Physical, 50 );
			SetResistance( ResistanceType.Fire, 20 );
			SetResistance( ResistanceType.Cold, 0 );
			SetResistance( ResistanceType.Poison, 20 );
			SetResistance( ResistanceType.Energy, 20 );

			SetSkill( SkillName.Anatomy, 50.0 );
			SetSkill( SkillName.MagicResist, 50.0 );
			SetSkill( SkillName.Tactics, 150.0 );
			SetSkill( SkillName.Wrestling, 150.0 );

			Fame = 7000;
			Karma = -7000;
		}

                public override bool OnBeforeDeath()
                {
                        this.Say("MOOOOOOOOOOOOOOOOOOOOOOOOO! THIS WAS NOT SUPPOSE TO HAPPEN!");

                        return base.OnBeforeDeath();
                }

		public override bool CanRummageCorpses{ get{ return true; } }
		public override int Meat{ get{ return 10; } }
		public override int Hides{ get{ return 15; } }

		public override int GetAttackSound() { return 0x599; } 
		public override int GetIdleSound() { return 0x596; } 
		public override int GetAngerSound() { return 0x597; } 
		public override int GetHurtSound() { return 0x59a; } 
		public override int GetDeathSound() { return 0x59c; }

		private DateTime m_NextBomb;
		private int m_Thrown;

		public override void OnActionCombat()
		{
			Mobile combatant = Combatant;

			if ( combatant == null || combatant.Deleted || combatant.Map != Map || !InRange( combatant, 12 ) || !CanBeHarmful( combatant ) || !InLOS( combatant ) )
				return;

			if ( DateTime.Now >= m_NextBomb )
			{
				ThrowBomb( combatant );

				m_Thrown++;

				if ( 0.75 >= Utility.RandomDouble() && (m_Thrown % 2) == 1 ) // 75% chance to quickly throw another bomb
					m_NextBomb = DateTime.Now + TimeSpan.FromSeconds( 3.0 );
				else
					m_NextBomb = DateTime.Now + TimeSpan.FromSeconds( 5.0 + (10.0 * Utility.RandomDouble()) ); // 5-15 seconds
			}
		}

		public void ThrowBomb( Mobile m )
		{
			DoHarmful( m );

			this.MovingParticles( m, 0x1C19, 1, 0, false, true, 0, 0, 9502, 6014, 0x11D, EffectLayer.Waist, 0 );

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
				m_Mobile.PlaySound( 0x11D );
				AOS.Damage( m_Mobile, m_From, Utility.RandomMinMax( 15, 20 ), 0, 100, 0, 0, 0 );
			}
		}

		public Taurion( Serial serial ) : base( serial )
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
