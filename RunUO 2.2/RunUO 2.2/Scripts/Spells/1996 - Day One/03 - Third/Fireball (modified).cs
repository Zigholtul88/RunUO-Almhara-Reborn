using System;
using Server.Targeting;
using Server.Network;

namespace Server.Spells.Third
{
	public class FireballSpell : MagerySpell
	{
		private static SpellInfo m_Info = new SpellInfo(
				"Fireball", "Vas Flam",
				203,
				9041,
				Reagent.BlackPearl
			);

		public override SpellCircle Circle { get { return SpellCircle.Third; } }

		public FireballSpell( Mobile caster, Item scroll ) : base( caster, scroll, m_Info )
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

				SpellHelper.Turn( source, m );

				SpellHelper.CheckReflect( (int)this.Circle, ref source, ref m );

				double damage;

				// Algorithm: (14-20) + (25% of alchemy) + (25% of eval int) + (25% of imbuing) + (25% of inscribe)

				if ( Core.AOS )
				{
				        int amount1 = (int)(Caster.Skills[SkillName.Alchemy].Value * 0.25);
				        int amount2 = (int)(Caster.Skills[SkillName.EvalInt].Value * 0.25);
				        int amount3 = (int)(Caster.Skills[SkillName.Imbuing].Value * 0.25);
				        int amount4 = (int)(Caster.Skills[SkillName.Inscribe].Value * 0.25);

                                        // damage = (14-20) + amount1 + amount2 + amount3 + amount4
				        damage = Utility.Random( 14, 20 ) + amount1 + amount2 + amount3 + amount4;
				}
				else
				{
					damage = Utility.Random( 20, 14 );

					if ( CheckResisted( m ) )
					{
						damage *= 0.75;

						m.SendLocalizedMessage( 501783 ); // You feel yourself resisting magical energy.
					}

					damage *= GetDamageScalar( m );
				}

				source.MovingParticles( m, 0x36D4, 7, 0, false, true, 9502, 4019, 0x160 );
				source.PlaySound( Core.AOS ? 0x15E : 0x44B );

				SpellHelper.Damage( this, m, damage, 0, 100, 0, 0, 0 );
			}

			FinishSequence();
		}

		private class InternalTarget : Target
		{
			private FireballSpell m_Owner;

			public InternalTarget( FireballSpell owner ) : base( Core.ML ? 10 : 12, false, TargetFlags.Harmful )
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