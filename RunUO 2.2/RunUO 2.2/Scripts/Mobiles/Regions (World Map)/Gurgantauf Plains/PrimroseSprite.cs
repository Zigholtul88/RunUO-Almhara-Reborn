using System;
using System.Collections;
using System.Collections.Generic;
using Server;
using Server.ContextMenus;
using Server.Items;
using Server.Misc;
using Server.Mobiles;
using Server.Spells;
using Server.Targeting;

namespace Server.Mobiles
{
	[CorpseName( "a primrose sprite corpse" )]
	public class PrimroseSprite : BaseCreature
	{
                private static readonly int[] m_North = new int[]
                {
                       -1, -1,
                        1, -1,
                       -1, 2,
                        1, 2
                };
                private static readonly int[] m_East = new int[]
                {
                       -1, 0,
                        2, 0
                };

		[Constructable]
		public PrimroseSprite() : base( AIType.AI_Melee, FightMode.Aggressor, 10, 1, 0.175, 0.350 )
		{
			Name = "a primrose sprite";
			Body = 264;
			Hue = Utility.RandomList( 1276,1287,1266,232,83,1408 );

			SetStr( 147, 170 );
			SetDex( 21, 26 );
			SetInt( 32, 44 );

			SetHits( 150, 200 );
			SetMana( 100 );

			SetDamage( 6, 12 );

			SetDamageType( ResistanceType.Physical, 100 );

			SetResistance( ResistanceType.Physical, 25 );
			SetResistance( ResistanceType.Fire, 10 );
			SetResistance( ResistanceType.Cold, 10 );
			SetResistance( ResistanceType.Poison, 10 );
			SetResistance( ResistanceType.Energy, 10 );

			SetSkill( SkillName.Healing, 45.8, 60.2 );
			SetSkill( SkillName.MagicResist, 39.1, 51.3 );
			SetSkill( SkillName.Tactics, 93.1, 98.6 );
			SetSkill( SkillName.Wrestling, 93.1, 98.6 );

			Fame = 1500;
			Karma = -1500;

			AddItem( new LightSource() );

			PackGold( 78, 158 );
			PackReg( 15, 50 );
			PackItem( new FertileDirt( Utility.RandomMinMax( 1, 5 ) ) );

			switch ( Utility.Random( 7 ) )
			{
				case 0: PackItem( new Apple() );  break;
				case 1: PackItem( new Banana() );  break;
				case 3: PackItem( new HoneydewMelon() ); break;
				case 4: PackItem( new Lemon() );  break;
				case 5: PackItem( new Pear() ); break;
				case 6: PackItem( new Watermelon() ); break;
			}
		}

                public override void OnThink()
                {
                        base.OnThink();

                        SparkleRing();
                }

                public virtual void SparkleRing()
                {
                        for (int i = 0; i < m_North.Length; i += 2)
                        {
                                Point3D p = Location;

                                p.X += m_North[i];
                                p.Y += m_North[i + 1];

                                IPoint3D po = p as IPoint3D;

                                SpellHelper.GetSurfaceTop(ref po);

                                Effects.SendLocationEffect(po, Map, 0x373A, 50);
                        }

                        for (int i = 0; i < m_East.Length; i += 2)
                        {
                                Point3D p = Location;

                                p.X += m_East[i];
                                p.Y += m_East[i + 1];

                                IPoint3D po = p as IPoint3D;

                                SpellHelper.GetSurfaceTop(ref po);

                                Effects.SendLocationEffect(po, Map, 0x375A, 50);
                        }
                }

		public override bool CanRummageCorpses{ get{ return true; } }

                public override bool HasBreath{ get{ return true; } } // seaweed throw enabled

		public override double BreathMinDelay{ get{ return 5.0; } }
		public override double BreathMaxDelay{ get{ return 15.0; } }

		public override int BreathPhysicalDamage{ get{ return 0; } }
	        public override int BreathFireDamage{ get{ return 0; } }
		public override int BreathColdDamage{ get{ return 0; } }
		public override int BreathPoisonDamage{ get{ return 0; } }
		public override int BreathEnergyDamage{ get{ return 100; } }

		public override int BreathEffectHue{ get{ return 71; } }
		public override int BreathEffectItemID{ get{ return 14509; } }
		public override int BreathEffectSound{ get{ return 0x1E5; } }
		public override int BreathAngerSound{ get{ return 0x57B; } }

		public override int GetIdleSound() { return 794; } //play female giggle
		public override int GetHurtSound() { return 806; } //play female oomph 3
		public override int GetAngerSound() { return 824; } //play female yell
		public override int GetDeathSound() { return 790; } //play female death 3

		private DateTime m_NextBomb;
		private int m_Thrown;

		public override void OnActionCombat()
		{
			Mobile combatant = Combatant;

			if ( combatant == null || combatant.Deleted || combatant.Map != Map || !InRange( combatant, 12 ) || !CanBeHarmful( combatant ) || !InLOS( combatant ) )
				return;

			if ( DateTime.Now >= m_NextBomb )
			{
				ThrowBomb( combatant );

				m_Thrown++;

				if ( 0.75 >= Utility.RandomDouble() && (m_Thrown % 2) == 1 ) // 75% chance to quickly throw another bomb
					m_NextBomb = DateTime.Now + TimeSpan.FromSeconds( 10.0 );
				else
					m_NextBomb = DateTime.Now + TimeSpan.FromSeconds( 15.0 + (10.0 * Utility.RandomDouble()) ); // 15-25 seconds
			}
		}

		public void ThrowBomb( Mobile m )
		{
			DoHarmful( m );

			this.MovingParticles( m, 0x1C19, 1, 0, false, true, 0, 0, 9502, 6014, 0x11D, EffectLayer.Waist, 0 );

			new InternalTimer( m, this ).Start();
		}

		private class InternalTimer : Timer
		{
			private Mobile m_Mobile, m_From;

			public InternalTimer( Mobile m, Mobile from ) : base( TimeSpan.FromSeconds( 1.0 ) )
			{
				m_Mobile = m;
				m_From = from;
				Priority = TimerPriority.TwoFiftyMS;
			}

			protected override void OnTick()
			{
				m_Mobile.PlaySound( 0x11D );
				AOS.Damage( m_Mobile, m_From, Utility.RandomMinMax( 5, 15 ), 0, 100, 0, 0, 0 );
			}
		}

		public PrimroseSprite( Serial serial ) : base( serial )
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