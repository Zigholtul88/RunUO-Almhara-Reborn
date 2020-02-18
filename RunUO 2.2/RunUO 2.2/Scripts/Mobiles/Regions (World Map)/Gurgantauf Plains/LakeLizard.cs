using System;
using System.Collections;
using System.Collections.Generic;
using Server;
using Server.ContextMenus;
using Server.Items;
using Server.Misc;
using Server.Mobiles;
using Server.Network;
using Server.Targeting;

namespace Server.Mobiles
{
	[CorpseName( "a lake lizard corpse" )]
	public class LakeLizard : BaseCreature
	{
		public override WeaponAbility GetWeaponAbility()
		{
			return WeaponAbility.BleedAttack;
		}

		[Constructable]
		public LakeLizard() : base( AIType.AI_Melee, FightMode.Aggressor, 10, 1, 0.2, 0.4 )
		{
			Name = "a lake lizard";
			Body = 734;
			Hue = Utility.RandomList( 2001,2002,2003,2004,2005,2006 );
			BaseSoundID = 0x5A;

			SetStr( 131, 152 );
			SetDex( 48, 61 );
			SetInt( 29, 32 );

			SetHits( 128, 145 );
			SetMana( 100 );

			SetDamage( 6, 9 );

			SetDamageType( ResistanceType.Physical, 100 );

			SetResistance( ResistanceType.Physical, 30 );

			SetSkill( SkillName.MagicResist, 68.9, 79.3 );
			SetSkill( SkillName.Tactics, 93.1, 98.6 );
			SetSkill( SkillName.Wrestling, 93.1, 98.6 );

			Fame = 1000;
			Karma = -1000;

			Tamable = true;
			ControlSlots = 1;
			MinTameSkill = 36.0;

			PackGold( 38, 293 );
		}

		public override FoodType FavoriteFood{ get{ return FoodType.Meat | FoodType.Fish; } }

		public override bool HasBreath{ get{ return true; } } // black cloud enabled

		public override double BreathMinDelay{ get{ return 1.0; } }
		public override double BreathMaxDelay{ get{ return 10.0; } }

		public override int BreathPhysicalDamage{ get{ return 100; } }
	        public override int BreathFireDamage{ get{ return 0; } }
		public override int BreathColdDamage{ get{ return 0; } }
		public override int BreathPoisonDamage{ get{ return 0; } }
		public override int BreathEnergyDamage{ get{ return 0; } }

		public override int BreathEffectHue{ get{ return 2406; } }
		public override int BreathEffectItemID{ get{ return 0x113E; } }
		public override int BreathEffectSound{ get{ return 0x364; } }
		public override int BreathAngerSound{ get{ return 0x1C0; } }

		public override void OnDamagedBySpell( Mobile from )
		{
			if( from != null && from.Alive && 0.4 > Utility.RandomDouble() )
			{
				ShootGrassWind( from );
			}
		}

		public void ShootGrassWind( Mobile to )
		{
			int damage = 8;
			this.MovingEffect( to, 0x0C4E, 10, 0, false, false );
			this.DoHarmful( to );
			this.PlaySound( 0x32F ); // f_shush
			AOS.Damage( to, this, damage, 100, 0, 0, 0, 0 );
		}

		public override void OnGotMeleeAttack( Mobile attacker )
		{
			base.OnGotMeleeAttack( attacker );

			if ( !IsFanned( attacker ) && 0.05 > Utility.RandomDouble() )
			{
                                attacker.SendMessage( "The lake lizard fans you with gas, reducing your resistance to physical attacks." );

		                ResistanceMod mod = new ResistanceMod( ResistanceType.Physical, - 50 );

				attacker.FixedParticles( 0x3779, 10, 30, 0x34, EffectLayer.RightFoot );
				attacker.PlaySound( 0x1E6 );

				// This should be done in place of the normal attack damage.
				//AOS.Damage( attacker, this, Utility.RandomMinMax( 5, 10 ), 0, 0, 0, 100, 0 );

				attacker.AddResistanceMod( mod );
		
				ExpireTimer timer = new ExpireTimer( attacker, mod, TimeSpan.FromSeconds( 10.0 ) );
				timer.Start();
				m_Table[attacker] = timer;
			}
		}

		private static Hashtable m_Table = new Hashtable();

		public bool IsFanned( Mobile m )
		{
			return m_Table.Contains( m );
		}

		private class ExpireTimer : Timer
		{
			private Mobile m_Mobile;
			private ResistanceMod m_Mod;

			public ExpireTimer( Mobile m, ResistanceMod mod, TimeSpan delay ) : base( delay )
			{
				m_Mobile = m;
				m_Mod = mod;
				Priority = TimerPriority.TwoFiftyMS;
		        }

			protected override void OnTick()
			{
                                m_Mobile.SendMessage( "Your resistance to physical attacks has returned." );
				m_Mobile.RemoveResistanceMod( m_Mod );
				Stop();
				m_Table.Remove( m_Mobile );
			}
		}

                public override void OnCarve( Mobile from, Corpse corpse, Item with )
		{
			if (corpse.Carved == false)
			{
			      base.OnCarve( from, corpse, with );

                              corpse.AddCarvedItem(new BlackLizardMeat(), from);
                              corpse.AddCarvedItem(new SpinedHides(12), from);
                              corpse.AddCarvedItem(new SerpentScale( Utility.RandomMinMax( 7, 10 )), from);

                              from.SendMessage( "You carve up some lizard meat, spined hides, and serpent scales." );
                              corpse.Carved = true; 
			}
                }

		public LakeLizard(Serial serial) : base(serial)
		{
		}

		public override void Serialize(GenericWriter writer)
		{
			base.Serialize(writer);

			writer.Write((int) 0);
		}

		public override void Deserialize(GenericReader reader)
		{
			base.Deserialize(reader);

			int version = reader.ReadInt();
		}
	}
}