using System;
using Server.Targeting;
using Server.Network;

namespace Server.Spells.Sixth
{
	public class EnergyBoltSpell : MagerySpell
	{
		private static SpellInfo m_Info = new SpellInfo(
				"Energy Bolt", "Corp Por",
				230,
				9022,
				Reagent.BlackPearl,
				Reagent.Nightshade
			);

		public override SpellCircle Circle { get { return SpellCircle.Sixth; } }

		public EnergyBoltSpell( Mobile caster, Item scroll ) : base( caster, scroll, m_Info )
		{
		}

		public override void OnCast()
		{
			Caster.Target = new InternalTarget( this );
		}

		public override bool DelayedDamage{ get{ return true; } }

		public void Target( Mobile m )
		{
			if ( !Caster.CanSee( m ) )
			{
				Caster.SendLocalizedMessage( 500237 ); // Target can not be seen.
			}
			else if ( CheckHSequence( m ) )
			{
				Mobile source = Caster;

				SpellHelper.Turn( Caster, m );

				SpellHelper.CheckReflect( (int)this.Circle, ref source, ref m );

				double damage;

				// Algorithm: (36-48) + (25% of alchemy) + (25% of eval int) + (25% of imbuing) + (25% of inscribe)

				if ( Core.AOS )
				{
				        int amount1 = (int)(Caster.Skills[SkillName.Alchemy].Value * 0.25);
				        int amount2 = (int)(Caster.Skills[SkillName.EvalInt].Value * 0.25);
				        int amount3 = (int)(Caster.Skills[SkillName.Imbuing].Value * 0.25);
				        int amount4 = (int)(Caster.Skills[SkillName.Inscribe].Value * 0.25);

                                        // damage = (36-48) + amount1 + amount2 + amount3 + amount4
				        damage = Utility.Random( 36, 48 ) + amount1 + amount2 + amount3 + amount4;
				}
				else
				{
					damage = Utility.Random( 48, 36 );

					if ( CheckResisted( m ) )
					{
						damage *= 0.75;

						m.SendLocalizedMessage( 501783 ); // You feel yourself resisting magical energy.
					}

					// Scale damage based on evalint and resist
					damage *= GetDamageScalar( m );
				}

				// Do the effects
				source.MovingParticles( m, 0x379F, 7, 0, false, true, 3043, 4043, 0x211 );
				source.PlaySound( 0x20A );

				// Deal the damage
				SpellHelper.Damage( this, m, damage, 0, 0, 0, 0, 100 );
			}

			FinishSequence();
		}

		private class InternalTarget : Target
		{
			private EnergyBoltSpell m_Owner;

			public InternalTarget( EnergyBoltSpell owner ) : base( Core.ML ? 10 : 12, false, TargetFlags.Harmful )
			{
				m_Owner = owner;
			}

			protected override void OnTarget( Mobile from, object o )
			{
				if ( o is Mobile )
					m_Owner.Target( (Mobile)o );
			}

			protected override void OnTargetFinish( Mobile from )
			{
				m_Owner.FinishSequence();
			}
		}
	}
}