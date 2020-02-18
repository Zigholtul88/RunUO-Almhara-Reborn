using System;
using Server;
using Server.Targeting;
using Server.Network;
using Server.Mobiles;

namespace Server.Spells.Fourth
{
	public class GreaterHealSpell : MagerySpell
	{
		private static SpellInfo m_Info = new SpellInfo(
				"Greater Heal", "In Vas Mani",
				204,
				9061,
				Reagent.Garlic,
				Reagent.Ginseng,
				Reagent.MandrakeRoot,
				Reagent.SpidersSilk
			);

		public override SpellCircle Circle { get { return SpellCircle.Fourth; } }

		public GreaterHealSpell( Mobile caster, Item scroll ) : base( caster, scroll, m_Info )
		{
		}

		public override void OnCast()
		{
			Caster.Target = new InternalTarget( this );
		}

		public void Target( Mobile m )
		{
			if ( !Caster.CanSee( m ) )
			{
				Caster.SendLocalizedMessage( 500237 ); // Target can not be seen.
			}
			else if ( m is BaseCreature && ((BaseCreature)m).IsAnimatedDead )
			{
				Caster.SendLocalizedMessage( 1061654 ); // You cannot heal that which is not alive.
			}
			else if ( m.IsDeadBondedPet )
			{
				Caster.SendLocalizedMessage( 1060177 ); // You cannot heal a creature that is already dead!
			}
			else if ( m is Golem )
			{
				Caster.LocalOverheadMessage( MessageType.Regular, 0x3B2, 500951 ); // You cannot heal that.
			}
			else if ( m.Poisoned || Server.Items.MortalStrike.IsWounded( m ) )
			{
				Caster.LocalOverheadMessage( MessageType.Regular, 0x22, (Caster == m) ? 1005000 : 1010398 );
			}
			else if ( CheckBSequence( m ) )
			{
				SpellHelper.Turn( Caster, m );

				// Algorithm: (40% of magery) + (50-60) + (25% of alchemy) + (25% of eval int) + (25% of imbuing) + (25% of inscribe)

				int toHeal = (int)(Caster.Skills[SkillName.Magery].Value * 0.4);
				int amount1 = (int)(Caster.Skills[SkillName.Alchemy].Value * 0.25);
				int amount2 = (int)(Caster.Skills[SkillName.EvalInt].Value * 0.25);
				int amount3 = (int)(Caster.Skills[SkillName.Imbuing].Value * 0.25);
				int amount4 = (int)(Caster.Skills[SkillName.Inscribe].Value * 0.25);

                                // 100 Skill * 0.4 = 40 + toHeal + amount1 + amount2 + amount3 + amount4
				toHeal += Utility.Random( 50, 60 ) + amount1 + amount2 + amount3 + amount4;

				//m.Heal( toHeal, Caster );
				SpellHelper.Heal( toHeal, m, Caster );

		                m.FixedParticles( 0x375A, 1, 30, 9966, 88, 2, EffectLayer.Head ); 
           	                m.FixedParticles( 0x37B9, 1, 30, 9502, 85, 3, EffectLayer.Head );
		                m.FixedParticles( 0x376A, 1, 31, 9961, 80, 0, EffectLayer.Waist );
           	                m.FixedParticles( 0x37C4, 1, 31, 9502, 88, 2, EffectLayer.Waist );
				m.PlaySound( 0x202 );
			}

			FinishSequence();
		}

		public class InternalTarget : Target
		{
			private GreaterHealSpell m_Owner;

			public InternalTarget( GreaterHealSpell owner ) : base( Core.ML ? 10 : 12, false, TargetFlags.Beneficial )
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