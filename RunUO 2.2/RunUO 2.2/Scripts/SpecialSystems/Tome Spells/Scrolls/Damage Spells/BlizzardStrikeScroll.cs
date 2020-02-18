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
	public class BlizzardStrikeScroll : Item
	{
		[Constructable]
		public BlizzardStrikeScroll() : this( 1 )
		{
		}

		[Constructable]
		public BlizzardStrikeScroll( int amount ) : base( 0x2261 )
		{
			Name = "Blizzard Strike - 3th Circle";
			Stackable = true;
			Amount = amount;

			Weight = 0.1;
                        Hue = 1152;

			LootType = LootType.Blessed;
		}

		public override void OnDoubleClick( Mobile from )
		{
                        new BlizzardStrikeSpell ( from, this ).Cast();
		}

		public BlizzardStrikeScroll( Serial serial ) : base( serial )
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
	public class BlizzardStrikeSpell : TomeSpell 
	{ 
		private static SpellInfo m_Info = new SpellInfo( 
				"Blizzard Strike", "blizzard strike",
				-1,
				9002
		); 

                public override TimeSpan CastDelayBase { get { return TimeSpan.FromSeconds(5); } }
                public override SpellCircle Circle { get { return SpellCircle.Third; } }
                public override double RequiredSkill { get { return 10.1; } }
                public override int RequiredMana { get { return 30; } }

		public BlizzardStrikeSpell( Mobile caster, Item scroll ): base( caster, scroll, m_Info )
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
			else if ( CheckHSequence( m ) )
			{
				Mobile source = Caster;

				SpellHelper.Turn( source, m );

				SpellHelper.CheckReflect( (int)this.Circle, ref source, ref m );

				double damage;

				if ( Core.AOS )
				{
					damage = GetNewAosDamage( 38, 5, 15, m );
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

				m.FixedParticles( 0x374A, 10, 30, 5013, 1153, 2, EffectLayer.Waist );

				Effects.SendMovingEffect( Caster, m, 0x3660, 7, 0, false, true, 0x47e, 3 ); 
				Effects.SendMovingEffect( Caster, m, 0x3678, 7, 0, false, true, 0x47e, 3 ); 
				Effects.SendMovingEffect( Caster, m, 0x3678, 7, 0, false, true, 0x47e, 3 ); 
				source.PlaySound( 0x15E );

				SpellHelper.Damage( this, m, damage, 0, 0, 100, 0, 0 );
			} 

			FinishSequence(); 
		} 

		private class InternalTarget : Target 
		{ 
			private BlizzardStrikeSpell m_Owner; 

			public InternalTarget( BlizzardStrikeSpell owner ) : base( 12, false, TargetFlags.Harmful ) 
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
