using System;
using Server;
using Server.Items;
using Server.Misc;
using Server.Mobiles;
using Server.Network;
using Server.Spells;
using Server.Spells.Tome;
using Server.Targeting;

namespace Server.Items
{
	public class IceMissileScroll : Item
	{
		[Constructable]
		public IceMissileScroll() : this( 1 )
		{
		}

		[Constructable]
		public IceMissileScroll( int amount ) : base( 0x2261 )
		{
			Name = "Ice Missile - 1st Circle";
			Stackable = true;
			Amount = amount;

			Weight = 0.1;
                        Hue = 1152;

			LootType = LootType.Blessed;
		}

		public override void OnDoubleClick( Mobile from )
		{
                        new IceMissileSpell ( from, this ).Cast();
		}

		public IceMissileScroll( Serial serial ) : base( serial )
		{
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );

			writer.Write( (int) 0 ); // version
		}

		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader );

			int version = reader.ReadInt();
		}
	}
}

namespace Server.Spells.Tome
{
	public class IceMissileSpell : TomeSpell 
	{ 
		private static SpellInfo m_Info = new SpellInfo( 
				"Ice Missile", "ice missile",
				-1,
				9002
		); 

                public override TimeSpan CastDelayBase { get { return TimeSpan.FromSeconds(3); } }
                public override SpellCircle Circle { get { return SpellCircle.First; } }
                public override double RequiredSkill { get { return 0.1; } }
                public override int RequiredMana { get { return 20; } }

		public IceMissileSpell( Mobile caster, Item scroll ): base( caster, scroll, m_Info )
		{ 
		} 
		
                public override bool DelayedDamageStacking { get { return !Core.AOS; } }

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
				
				if ( Core.AOS )
				{
					damage = GetNewAosDamage( 20, 2, 8, m );
				}
				else
				{
					damage = Utility.Random( 8, 8 );

					if ( CheckResisted( m ) )
					{
						damage *= 0.75;

						m.SendLocalizedMessage( 501783 ); // You feel yourself resisting magical energy.
					}

					damage *= GetDamageScalar( m );
				}

				Effects.SendMovingEffect( Caster, m, 0x3678, 7, 0, false, true, 0x47F, 0 ); 
				source.PlaySound( 0x44B );

				SpellHelper.Damage( this, m, damage, 0, 0, 100, 0, 0 );
			}

			FinishSequence();
		}

		private class InternalTarget : Target
		{
			private IceMissileSpell m_Owner;

			public InternalTarget( IceMissileSpell owner ) : base( Core.ML ? 10 : 12, false, TargetFlags.Harmful )
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