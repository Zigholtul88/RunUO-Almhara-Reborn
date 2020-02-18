using System;
using System.Collections.Generic;
using Server.Network;
using Server.Items;
using Server.Targeting;

namespace Server.Spells.Seventh
{
	public class MeteorSwarmSpell : MagerySpell
	{
		private static SpellInfo m_Info = new SpellInfo(
				"Meteor Swarm", "Flam Kal Des Ylem",
				233,
				9042,
				false,
				Reagent.Bloodmoss,
				Reagent.MandrakeRoot,
				Reagent.SulfurousAsh,
				Reagent.SpidersSilk
			);

		public override SpellCircle Circle { get { return SpellCircle.Seventh; } }

		public MeteorSwarmSpell( Mobile caster, Item scroll ) : base( caster, scroll, m_Info )
		{
		}

		public override void OnCast()
		{
			Caster.Target = new InternalTarget( this );
		}

		public override bool DelayedDamage{ get{ return true; } }

		public void Target( IPoint3D p )
		{
			if ( !Caster.CanSee( p ) )
			{
				Caster.SendLocalizedMessage( 500237 ); // Target can not be seen.
			}
			else if ( SpellHelper.CheckTown( p, Caster ) && CheckSequence() )
			{
				SpellHelper.Turn( Caster, p );

				if ( p is Item )
					p = ((Item)p).GetWorldLocation();

				List<Mobile> targets = new List<Mobile>();

				Map map = Caster.Map;

				bool playerVsPlayer = false;

				if ( map != null )
				{
					IPooledEnumerable eable = map.GetMobilesInRange( new Point3D( p ), 2 );

					foreach ( Mobile m in eable )
					{
						if ( Caster != m && SpellHelper.ValidIndirectTarget( Caster, m ) && Caster.CanBeHarmful( m, false ) )
						{
							if ( Core.AOS && !Caster.InLOS( m ) )
								continue;

							targets.Add( m );

							if ( m.Player )
								playerVsPlayer = true;
						}
					}

					eable.Free();
				}

				double damage;

				// Algorithm: (65-85) + (25% of alchemy) + (25% of eval int) + (25% of imbuing) + (25% of inscribe)

				if ( Core.AOS )
                                {
				        int amount1 = (int)(Caster.Skills[SkillName.Alchemy].Value * 0.25);
				        int amount2 = (int)(Caster.Skills[SkillName.EvalInt].Value * 0.25);
				        int amount3 = (int)(Caster.Skills[SkillName.Imbuing].Value * 0.25);
				        int amount4 = (int)(Caster.Skills[SkillName.Inscribe].Value * 0.25);

                                        // damage = (65-85) + amount1 + amount2 + amount3 + amount4
				        damage = Utility.Random( 65, 85 ) + amount1 + amount2 + amount3 + amount4;
                                }
				else
                                {
					damage = Utility.Random( 54, 44 );
                                }

				if ( targets.Count > 0 )
				{
					Effects.PlaySound( p, Caster.Map, 0x160 );

					if ( Core.AOS && targets.Count > 2 )
						damage = (damage * 2) / targets.Count;
					else if ( !Core.AOS )
						damage /= targets.Count;
						
					double toDeal;
					for ( int i = 0; i < targets.Count; ++i )
					{
						Mobile m = targets[i];

						toDeal  = damage;

						if ( !Core.AOS && CheckResisted( m ) )
						{
							damage *= 0.5;

							m.SendLocalizedMessage( 501783 ); // You feel yourself resisting magical energy.
						}
						toDeal *= GetDamageScalar( m );
						Caster.DoHarmful( m );
						SpellHelper.Damage( this, m, toDeal, 0, 100, 0, 0, 0 );

						Caster.MovingParticles( m, 0x36D4, 7, 0, false, true, 9501, 1, 0, 0x100 );
					}
				}
			}

			FinishSequence();
		}

		private class InternalTarget : Target
		{
			private MeteorSwarmSpell m_Owner;

			public InternalTarget( MeteorSwarmSpell owner ) : base( Core.ML ? 10 : 12, true, TargetFlags.None )
			{
				m_Owner = owner;
			}

			protected override void OnTarget( Mobile from, object o )
			{
				IPoint3D p = o as IPoint3D;

				if ( p != null )
					m_Owner.Target( p );
			}

			protected override void OnTargetFinish( Mobile from )
			{
				m_Owner.FinishSequence();
			}
		}
	}
}