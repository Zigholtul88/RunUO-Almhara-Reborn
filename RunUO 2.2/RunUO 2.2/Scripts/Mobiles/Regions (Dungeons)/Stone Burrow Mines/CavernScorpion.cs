using System;
using System.Collections;
using System.Collections.Generic;
using Server;
using Server.ContextMenus;
using Server.Items;
using Server.Misc;
using Server.Mobiles;
using Server.Targeting;

namespace Server.Mobiles
{
	[CorpseName( "a cavern scorpion corpse" )]
	public class CavernScorpion : BaseCreature
	{
		public override WeaponAbility GetWeaponAbility()
		{
			switch ( Utility.Random( 3 ) )
			{
				default:
				case 0: return WeaponAbility.DoubleStrike;
				case 1: return WeaponAbility.WhirlwindAttack;
				case 2: return WeaponAbility.CrushingBlow;
			}
		}

		[Constructable]
		public CavernScorpion() : base( AIType.AI_Melee, FightMode.Closest, 4, 1, 0.3, 0.6 )
		{
			Name = "a cavern scorpion";
			Body = 48;
                        Hue = 2103;
			BaseSoundID = 397;

			SetStr( 82, 108 );
			SetDex( 78, 94 );
			SetInt( 17, 29 );

			SetHits( 300, 326 );
			SetMana( 0 );

			SetDamage( 4, 5 );

			SetDamageType( ResistanceType.Physical, 60 );
			SetDamageType( ResistanceType.Poison, 40 );

			SetResistance( ResistanceType.Physical, 28 );
			SetResistance( ResistanceType.Fire, 10 );
			SetResistance( ResistanceType.Cold, 20 );
			SetResistance( ResistanceType.Poison, 40 );
			SetResistance( ResistanceType.Energy, 10 );

			SetSkill( SkillName.Poisoning, 83.4, 99.1 );
			SetSkill( SkillName.MagicResist, 30.1, 34.9 );
			SetSkill( SkillName.Ninjitsu, 100.0 );
			SetSkill( SkillName.Tactics, 72.4, 83.5 );
			SetSkill( SkillName.Wrestling, 87.6, 96.0 );

			Fame = 13000;
			Karma = -13000;

			Tamable = true;
			ControlSlots = 1;
			MinTameSkill = 25.5;

			PackGold( 213, 316 );
			PackReg( 42, 76 );

			PackItem( new ChromeDiopside() );
			PackItem( new PoisonScroll() );
			PackItem( new PoisonPotion() );
		}

		public override void GenerateLoot()
		{
			AddLoot( LootPack.Potions );
		}

		public override FoodType FavoriteFood{ get{ return FoodType.Meat; } }
		public override PackInstinct PackInstinct{ get{ return PackInstinct.Arachnid; } }
		public override Poison PoisonImmune{ get{ return Poison.Regular; } }
		public override Poison HitPoison{ get{ return Poison.Regular; } }

		public override void OnGaveMeleeAttack( Mobile defender )
		{
			base.OnGaveMeleeAttack( defender );

			if ( !IsFanned( defender ) && 0.15 > Utility.RandomDouble() )
			{
                                defender.SendMessage( "The cavern scorpion fans you with gas, reducing your resistance to poison attacks." );

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

                public override void OnCarve( Mobile from, Corpse corpse, Item with )
		{
			if ( corpse.Carved == false )
			{
			      base.OnCarve( from, corpse, with );

                              corpse.AddCarvedItem( new RawRibs(), from );
                              corpse.AddCarvedItem( new CavernScorpionCarapace(), from );

                              from.SendMessage( "You carve up a raw rib and a cavern scorpion carapace." ); 
                              corpse.Carved = true;
			}
                }

		public CavernScorpion( Serial serial ) : base( serial )
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
		}
	}
}