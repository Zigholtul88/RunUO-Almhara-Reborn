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
	[CorpseName( "a darkrose corpse" )]
	public class DarkRose : BaseCreature
	{
		public override WeaponAbility GetWeaponAbility()
		{
			return WeaponAbility.BleedAttack;
		}

		[Constructable]
		public DarkRose() : base( AIType.AI_Melee, FightMode.Closest, 5, 1, 0.3, 0.6 )
		{
			Name = "a darkrose";
			Body = 789;
                        Hue = 1172; 

			SetStr( 102, 131 );
			SetDex( 67, 86 );
			SetInt( 32, 56 );

			SetHits( 155, 170 );

			SetDamage( 3, 6 );

			SetDamageType( ResistanceType.Physical, 70 );
			SetDamageType( ResistanceType.Poison, 30 );

			SetResistance( ResistanceType.Physical, 15 );
			SetResistance( ResistanceType.Fire, 10 );
			SetResistance( ResistanceType.Cold, 10 );
			SetResistance( ResistanceType.Poison, 100 );
			SetResistance( ResistanceType.Energy, 20 );

			SetSkill( SkillName.Poisoning, 57.5, 62.6 );
			SetSkill( SkillName.MagicResist, 59.2, 68.2 );
			SetSkill( SkillName.Tactics, 47.5, 57.9 );
			SetSkill( SkillName.Wrestling, 56.8, 63.7 );

			Fame = 500;
			Karma = -500;

			Tamable = true;
			ControlSlots = 1;
			MinTameSkill = 32.0;

			PackGold( 119, 213 );

			PackItem( new Engines.Plants.Seed() );
			PackItem( new LesserToxicPotion() );
		}

		public override FoodType FavoriteFood{ get{ return FoodType.Fish | FoodType.Meat; } }

		public override void GenerateLoot()
		{
			AddLoot( LootPack.Meager );
		}

		public override int GetIdleSound() { return 0x017; }
		public override int GetAngerSound() { return 0x018; }
		public override int GetAttackSound() { return 0x01E; }
		public override int GetHurtSound() { return 0x01D; }
		public override int GetDeathSound() { return 0x01A; }

		public override Poison PoisonImmune{ get{ return Poison.Lethal; } }
		public override Poison HitPoison{ get{ return Poison.Lesser; } }

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
		public override int BreathAngerSound{ get{ return 0x018; } }

		public override void OnGaveMeleeAttack( Mobile defender )
		{
			base.OnGaveMeleeAttack( defender );

			if ( !IsFanned( defender ) && 0.15 > Utility.RandomDouble() )
			{
                                defender.SendMessage( "The dark rose fans you with gas, reducing your resistance to poison attacks." );

		                ResistanceMod mod = new ResistanceMod( ResistanceType.Poison, - 50 );

				defender.FixedParticles( 0x3779, 10, 30, 0x34, EffectLayer.RightFoot );
				defender.PlaySound( 0x1E6 );

				// This should be done in place of the normal attack damage.
				//AOS.Damage( defender, this, Utility.RandomMinMax( 5, 10 ), 0, 0, 0, 100, 0 );

				defender.AddResistanceMod( mod );
		
				ExpireTimer timer = new ExpireTimer( defender, mod, TimeSpan.FromSeconds( 10.0 ) );
				timer.Start();
				m_Table[defender] = timer;
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
                                m_Mobile.SendMessage( "Your resistance to poison attacks has returned." );
				m_Mobile.RemoveResistanceMod( m_Mod );
				Stop();
				m_Table.Remove( m_Mobile );
			}
		}

		public DarkRose( Serial serial ) : base( serial )
		{
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );
			writer.Write( (int) 0 );
		}

		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader );
			int version = reader.ReadInt();

			if ( BaseSoundID == -1 )
				BaseSoundID = 352;
		}
	}
}