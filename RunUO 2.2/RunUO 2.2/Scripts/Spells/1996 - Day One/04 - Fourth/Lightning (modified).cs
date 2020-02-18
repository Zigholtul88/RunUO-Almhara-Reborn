using System;
using Server.Targeting;
using Server.Network;

namespace Server.Spells.Fourth
{
	public class LightningSpell : MagerySpell
	{
		private static SpellInfo m_Info = new SpellInfo(
				"Lightning", "Por Ort Grav",
				239,
				9021,
				Reagent.MandrakeRoot,
				Reagent.SulfurousAsh
			);

		public override SpellCircle Circle { get { return SpellCircle.Fourth; } }

		public LightningSpell( Mobile caster, Item scroll ) : base( caster, scroll, m_Info )
		{
		}

		public override void OnCast()
		{
			Caster.Target = new InternalTarget( this );
		}

		public override bool DelayedDamage{ get{ return false; } }

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

				// Algorithm: (18-24) + (25% of alchemy) + (25% of eval int) + (25% of imbuing) + (25% of inscribe)

				if ( Core.AOS )
				{
				        int amount1 = (int)(Caster.Skills[SkillName.Alchemy].Value * 0.25);
				        int amount2 = (int)(Caster.Skills[SkillName.EvalInt].Value * 0.25);
				        int amount3 = (int)(Caster.Skills[SkillName.Imbuing].Value * 0.25);
				        int amount4 = (int)(Caster.Skills[SkillName.Inscribe].Value * 0.25);

                                        // damage = (18-24) + amount1 + amount2 + amount3 + amount4
				        damage = Utility.Random( 18, 24 ) + amount1 + amount2 + amount3 + amount4;
				}
				else
				{
					damage = Utility.Random( 24, 18 );

					if ( CheckResisted( m ) )
					{
						damage *= 0.75;

						m.SendLocalizedMessage( 501783 ); // You feel yourself resisting magical energy.
					}

					damage *= GetDamageScalar( m );
				}

				m.BoltEffect( 0 );

				SpellHelper.Damage( this, m, damage, 0, 0, 0, 0, 100 );
			}

			FinishSequence();
		}

		private class InternalTarget : Target
		{
			private LightningSpell m_Owner;

			public InternalTarget( LightningSpell owner ) : base( Core.ML ? 10 : 12, false, TargetFlags.Harmful )
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