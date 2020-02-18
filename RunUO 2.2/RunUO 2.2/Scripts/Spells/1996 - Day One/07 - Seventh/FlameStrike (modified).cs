using System;
using Server.Targeting;
using Server.Network;

namespace Server.Spells.Seventh
{
	public class FlameStrikeSpell : MagerySpell
	{
		private static SpellInfo m_Info = new SpellInfo(
				"Flame Strike", "Kal Vas Flam",
				245,
				9042,
				Reagent.SpidersSilk,
				Reagent.SulfurousAsh
			);

		public override SpellCircle Circle { get { return SpellCircle.Seventh; } }

		public FlameStrikeSpell( Mobile caster, Item scroll ) : base( caster, scroll, m_Info )
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
				SpellHelper.Turn( Caster, m );

				SpellHelper.CheckReflect( (int)this.Circle, Caster, ref m );

				double damage;

				// Algorithm: (55-65) + (25% of alchemy) + (25% of eval int) + (25% of imbuing) + (25% of inscribe)

				if ( Core.AOS )
				{
				        int amount1 = (int)(Caster.Skills[SkillName.Alchemy].Value * 0.25);
				        int amount2 = (int)(Caster.Skills[SkillName.EvalInt].Value * 0.25);
				        int amount3 = (int)(Caster.Skills[SkillName.Imbuing].Value * 0.25);
				        int amount4 = (int)(Caster.Skills[SkillName.Inscribe].Value * 0.25);

                                        // damage = (55-65) + amount1 + amount2 + amount3 + amount4
				        damage = Utility.Random( 55, 65 ) + amount1 + amount2 + amount3 + amount4;
				}
				else
				{
					damage = Utility.Random( 54, 44 );

					if ( CheckResisted( m ) )
					{
						damage *= 0.6;

						m.SendLocalizedMessage( 501783 ); // You feel yourself resisting magical energy.
					}

					damage *= GetDamageScalar( m );
				}

				m.FixedParticles( 0x3709, 10, 30, 5052, EffectLayer.LeftFoot );
				m.PlaySound( 0x208 );

				SpellHelper.Damage( this, m, damage, 0, 100, 0, 0, 0 );
			}

			FinishSequence();
		}

		private class InternalTarget : Target
		{
			private FlameStrikeSpell m_Owner;

			public InternalTarget( FlameStrikeSpell owner ) : base( Core.ML ? 10 : 12, false, TargetFlags.Harmful )
			{
				m_Owner = owner;
			}

			protected override void OnTarget( Mobile from, object o )
			{
				if ( o is Mobile )
				{
					m_Owner.Target( (Mobile)o );
				}
			}

			protected override void OnTargetFinish( Mobile from )
			{
				m_Owner.FinishSequence();
			}
		}
	}
}