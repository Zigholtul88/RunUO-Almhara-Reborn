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
	public class ThunderBoltScroll : Item
	{
		[Constructable]
		public ThunderBoltScroll() : this( 1 )
		{
		}

		[Constructable]
		public ThunderBoltScroll( int amount ) : base( 0x2261 )
		{
			Name = "Thunder Bolt - 5th Circle";
			Stackable = true;
			Amount = amount;

			Weight = 0.1;
                        Hue = 1164;

			LootType = LootType.Blessed;
		}

		public override void OnDoubleClick( Mobile from )
		{
                        new ThunderBoltSpell ( from, this ).Cast();
		}

		public ThunderBoltScroll( Serial serial ) : base( serial )
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
	public class ThunderBoltSpell : TomeSpell 
	{ 
		private static SpellInfo m_Info = new SpellInfo( 
				"Thunder Bolt", "thunderbolt",
				-1,
				9002
			); 

                public override TimeSpan CastDelayBase { get { return TimeSpan.FromSeconds(5); } }
                public override SpellCircle Circle { get { return SpellCircle.Fifth; } }
                public override double RequiredSkill { get { return 38.1; } }
                public override int RequiredMana { get { return 50; } }

		public ThunderBoltSpell( Mobile caster, Item scroll ): base( caster, scroll, m_Info )
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
					damage = GetNewAosDamage( 80, 8, 18, m );
				}
				else
				{
					damage = Utility.Random( 48, 36 );
            			
					if ( CheckResisted( m ) )
					{
						damage *= 0.75;

						m.SendLocalizedMessage( 501783 ); // You feel yourself resisting magical energy.
					}

					damage *= GetDamageScalar( m );
				}

                                source.BoltEffect( 0 );
				Effects.SendMovingEffect( Caster, m, 0x379F, 7, 0, false, true ,0x47e,3); 
				source.PlaySound( 0x20A );

				SpellHelper.Damage( this, m, damage, 0, 0, 0, 0, 100 );
			} 

			FinishSequence(); 
		} 

		private class InternalTarget : Target 
		{ 
			private ThunderBoltSpell m_Owner; 

			public InternalTarget( ThunderBoltSpell owner ) : base( 12, false, TargetFlags.Harmful ) 
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
