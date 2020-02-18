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
	public class AcidSplashScroll : Item
	{
		[Constructable]
		public AcidSplashScroll() : this( 1 )
		{
		}

		[Constructable]
		public AcidSplashScroll( int amount ) : base( 0x2261 )
		{
			Name = "Acid Splash - 1st Circle";
			Stackable = true;
			Amount = amount;

			Weight = 0.1;
                        Hue = 78;

			LootType = LootType.Blessed;
		}

		public override void OnDoubleClick( Mobile from )
		{
                        new AcidSplashSpell ( from, this ).Cast();
		}

		public AcidSplashScroll( Serial serial ) : base( serial )
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
	public class AcidSplashSpell : TomeSpell 
	{ 
		private static SpellInfo m_Info = new SpellInfo( 
				"Acid Splash", "acid splash",
				-1,
				9002
			); 

                public override TimeSpan CastDelayBase { get { return TimeSpan.FromSeconds(3); } }
                public override SpellCircle Circle { get { return SpellCircle.First; } }
                public override double RequiredSkill { get { return 0.1; } }
                public override int RequiredMana { get { return 20; } }

		public AcidSplashSpell( Mobile caster, Item scroll ): base( caster, scroll, m_Info )
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

				Effects.SendMovingEffect( Caster, m, 0x36B0, 7, 0, false, true, 0x4E, 0 ); 
                                source.PlaySound( 0x364 );

				SpellHelper.Damage( this, m, damage, 0, 0, 0, 100, 0 );
			} 

			FinishSequence(); 
		} 

		private class InternalTarget : Target 
		{ 
			private AcidSplashSpell m_Owner; 

			public InternalTarget( AcidSplashSpell owner ) : base( 12, false, TargetFlags.Harmful ) 
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
