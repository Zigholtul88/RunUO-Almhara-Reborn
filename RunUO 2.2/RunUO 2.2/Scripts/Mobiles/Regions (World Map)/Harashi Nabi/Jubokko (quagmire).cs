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
	[CorpseName( "a jubokko corpse" )]
	public class Jubokko : BaseCreature
	{
		public override WeaponAbility GetWeaponAbility()
		{
			return WeaponAbility.BleedAttack;
		}

		[Constructable]
		public Jubokko() : base( AIType.AI_Melee, FightMode.Closest, 5, 1, 0.3, 0.6 )
		{
			Name = "a jubokko";
			Body = 789;
                        Hue = 251;
			BaseSoundID = 352;

			SetStr( 402, 431 );
			SetDex( 167, 186 );
			SetInt( 132, 156 );

			SetHits( 555, 670 );

			SetDamage( 3, 6 );

			SetDamageType( ResistanceType.Physical, 70 );
			SetDamageType( ResistanceType.Fire, 30 );

			SetResistance( ResistanceType.Physical, 15 );
			SetResistance( ResistanceType.Fire, 70 );
			SetResistance( ResistanceType.Cold, -50 );
			SetResistance( ResistanceType.Poison, 100 );
			SetResistance( ResistanceType.Energy, 20 );

			SetSkill( SkillName.MagicResist, 59.2, 68.2 );
			SetSkill( SkillName.Tactics, 47.5, 57.9 );
			SetSkill( SkillName.Wrestling, 76.8, 83.7 );

			Fame = 800;
			Karma = -800;

			Tamable = true;
			ControlSlots = 1;
			MinTameSkill = 32.0;

                        PackGold( 107, 212 );

			PackItem( new Engines.Plants.Seed() );
		}

		public override FoodType FavoriteFood{ get{ return FoodType.Fish | FoodType.Meat; } }

		public override void GenerateLoot()
		{
			AddLoot( LootPack.Meager );
		}

		public override int GetAngerSound()
		{
			return 353;
		}

		public override Poison PoisonImmune{ get{ return Poison.Lethal; } }

		public override OppositionGroup OppositionGroup
		{
			get{ return OppositionGroup.HarashiNabiPredator; }
		}

		public override bool IsEnemy( Mobile m )
		{
		        PlayerMobile pm = m as PlayerMobile;

			if ( m is PlayerMobile && m.SkillsTotal >= 7000 )
				return false;

                        if ( m is PlayerVendor || m is TownCrier || m is BaseSpecialCreature )
				return false;

			if ( m is BaseCreature )
			{
				BaseCreature c = (BaseCreature)m;

				if( c.Controlled || c.FightMode == FightMode.Aggressor || c.FightMode == FightMode.Closest || c.FightMode == FightMode.None )

					return false;
			}

			return true;
		}

		public override void OnGaveMeleeAttack( Mobile defender )
		{
			base.OnGaveMeleeAttack( defender );

			if ( 0.05 > Utility.RandomDouble() )
			{
				/* Rune Corruption
				 * Start cliloc: 1070846 "The creature magically corrupts your armor!"
				 * Effect: All resistances -70 (lowest 0) for 15 seconds
				 * End ASCII: "The corruption of your armor has worn off"
				 */

				ExpireTimer timer = (ExpireTimer)m_Table[defender];

				if ( timer != null )
				{
					timer.DoExpire();
					defender.SendLocalizedMessage( 1070845 ); // The creature continues to corrupt your armor!
				}
				else
					defender.SendLocalizedMessage( 1070846 ); // The creature magically corrupts your armor!

				List<ResistanceMod> mods = new List<ResistanceMod>();

				if ( Core.ML )
				{
					if ( defender.PhysicalResistance > 0 )
						mods.Add( new ResistanceMod( ResistanceType.Physical, -(defender.PhysicalResistance / 2) ) );

					if ( defender.FireResistance > 0 )
						mods.Add( new ResistanceMod( ResistanceType.Fire, -(defender.FireResistance / 2) ) );

					if ( defender.ColdResistance > 0 )
						mods.Add( new ResistanceMod( ResistanceType.Cold, -(defender.ColdResistance / 2) ) );

					if ( defender.PoisonResistance > 0 )
						mods.Add( new ResistanceMod( ResistanceType.Poison, -(defender.PoisonResistance / 2) ) );

					if ( defender.EnergyResistance > 0 )
						mods.Add( new ResistanceMod( ResistanceType.Energy, -(defender.EnergyResistance / 2) ) );
				}
				else
				{
					if ( defender.PhysicalResistance > 0 )
						mods.Add( new ResistanceMod( ResistanceType.Physical, (defender.PhysicalResistance > 70) ? -70 : -defender.PhysicalResistance ) );

					if ( defender.FireResistance > 0 )
						mods.Add( new ResistanceMod( ResistanceType.Fire, (defender.FireResistance > 70) ? -70 : -defender.FireResistance ) );

					if ( defender.ColdResistance > 0 )
						mods.Add( new ResistanceMod( ResistanceType.Cold, (defender.ColdResistance > 70) ? -70 : -defender.ColdResistance ) );

					if ( defender.PoisonResistance > 0 )
						mods.Add( new ResistanceMod( ResistanceType.Poison, (defender.PoisonResistance > 70) ? -70 : -defender.PoisonResistance ) );

					if ( defender.EnergyResistance > 0 )
						mods.Add( new ResistanceMod( ResistanceType.Energy, (defender.EnergyResistance > 70) ? -70 : -defender.EnergyResistance ) );
				}

				for ( int i = 0; i < mods.Count; ++i )
					defender.AddResistanceMod( mods[i] );

				defender.FixedEffect( 0x37B9, 10, 5 );

				timer = new ExpireTimer( defender, mods, TimeSpan.FromSeconds( 15.0 ) );
				timer.Start();
				m_Table[defender] = timer;
			}
		}

		private static Hashtable m_Table = new Hashtable();

		private class ExpireTimer : Timer
		{
			private Mobile m_Mobile;
			private List<ResistanceMod> m_Mods;

			public ExpireTimer( Mobile m, List<ResistanceMod> mods, TimeSpan delay ) : base( delay )
			{
				m_Mobile = m;
				m_Mods = mods;
				Priority = TimerPriority.TwoFiftyMS;
			}

			public void DoExpire()
			{
				for ( int i = 0; i < m_Mods.Count; ++i )
					m_Mobile.RemoveResistanceMod( m_Mods[i] );

				Stop();
				m_Table.Remove( m_Mobile );
			}

			protected override void OnTick()
			{
				m_Mobile.SendMessage( "The corruption of your armor has worn off" );
				DoExpire();
			}
		}

                public override void OnCarve( Mobile from, Corpse corpse, Item with )
		{
			if ( corpse.Carved == false )
			{
			      base.OnCarve( from, corpse, with );

                              corpse.AddCarvedItem( new RoseOfJubokko(), from );

                              from.SendMessage( "You carve up some jubokko parts." );
                              corpse.Carved = true; 
			}
                }

		public Jubokko( Serial serial ) : base( serial )
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