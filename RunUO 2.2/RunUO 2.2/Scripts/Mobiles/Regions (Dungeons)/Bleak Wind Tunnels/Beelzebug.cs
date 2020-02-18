using System;
using System.Collections;
using System.Collections.Generic;
using Server.Items;
using Server.Targeting;

namespace Server.Mobiles
{
	[CorpseName( "the corpse of Beelzebug" )]
	public class Beelzebug : BaseCreature
	{
		public override WeaponAbility GetWeaponAbility()
		{
			return WeaponAbility.BleedAttack;
		}

		[Constructable]
		public Beelzebug() : base( AIType.AI_Mage, FightMode.Closest, 10, 1, 0.2, 0.4 )
		{
			Name = "a beelzebug";
			Body = 244;
                        Hue = 1151;

			SetStr( 401, 460 );
			SetDex( 121, 170 );
			SetInt( 376, 450 );

			SetHits( 301, 360 );
			SetMana( 1005, 1125 );

			SetDamage( 12, 20 );

			SetDamageType( ResistanceType.Physical, 25 );
			SetDamageType( ResistanceType.Cold, 75 );

			SetResistance( ResistanceType.Physical, 45 );
			SetResistance( ResistanceType.Fire, 10 );
			SetResistance( ResistanceType.Cold, 70 );
			SetResistance( ResistanceType.Poison, 70 );
			SetResistance( ResistanceType.Energy, 40 );

			SetSkill( SkillName.EvalInt, 80.1, 90.0 );
			SetSkill( SkillName.Magery, 80.1, 90.0 );
			SetSkill( SkillName.MagicResist, 75.1, 85.0 );
			SetSkill( SkillName.Tactics, 80.1, 90.0 );
			SetSkill( SkillName.Wrestling, 80.1, 100.0 );

			Fame = 32000;
			Karma = -32000;
			
			PackGold( 81, 97 );

			if ( Utility.RandomDouble() < .25 )
				PackItem( Engines.Plants.Seed.RandomBonsaiSeed() );
				
			PackItem( new Paraiba() );
			PackItem( new DiamondDust( Utility.RandomMinMax( 17, 23 ) ) );

 			if ( Utility.RandomDouble() < 0.10 )
				PackItem( new SummonDaemonScroll() );

 			if ( Utility.RandomDouble() < 0.05 )
				PackItem( new CrackedResistColdGem() );

 			if ( Utility.RandomDouble() < 0.05 )
				PackItem( new CrackedHitHarmGem() );

			Container pack = new Backpack();
			pack.DropItem( new Gold( Utility.RandomMinMax( 38, 49 ) ) );

			switch ( Utility.Random( 5 ) )
			{
				case 0: PackItem( new HarmScroll(5) );  break;
				case 1: PackItem( new EnergyBoltScroll(3) ); break;
				case 2: PackItem( new PoisonFieldScroll(2) ); break;
				case 3: PackItem( new WallOfStoneScroll(2) ); break;
				case 4: PackItem( new CurseScroll(2) ); break;
			}

			Container bag = new Bag();
			bag.DropItem( new Gold( Utility.RandomMinMax( 12, 27 ) ) );
			bag.DropItem( new Bandage( Utility.RandomMinMax( 12, 19 ) ) );
			bag.DropItem( new HealPotion() );
			bag.DropItem( new HealPotion() );
			bag.DropItem( Loot.RandomGem() );

 		      if ( Utility.RandomDouble() < 0.05 )
                  {
			     BaseArmor armor1 = Loot.RandomArmor( true );
		           BaseRunicTool.ApplyAttributesTo( armor1, 3, 15, 30 );  

                       bag.DropItem( armor1 );
                  }

 		      if ( Utility.RandomDouble() < 0.05 )
                  {
			     BaseArmor armor2 = Loot.RandomArmor( true );
		           BaseRunicTool.ApplyAttributesTo( armor2, 3, 15, 30 );  

                       bag.DropItem( armor2 );
                  }

 		      if ( Utility.RandomDouble() < 0.05 )
                  {
			     BaseClothing clothing1 = Loot.RandomClothing( true );
		           BaseRunicTool.ApplyAttributesTo( clothing1, 3, 15, 30 );  

                       bag.DropItem( clothing1 );
                  }

 		      if ( Utility.RandomDouble() < 0.05 )
                  {
			     BaseClothing clothing2 = Loot.RandomClothing( true );
		           BaseRunicTool.ApplyAttributesTo( clothing2, 3, 15, 30 );  

                       bag.DropItem( clothing2 );
                  }

 		      if ( Utility.RandomDouble() < 0.05 )
                  {
			     BaseJewel bracelet = new GoldBracelet();
			     if ( Core.AOS )
		           BaseRunicTool.ApplyAttributesTo( bracelet, 5, 25, 30 );  

                       bag.DropItem( bracelet );
                  }

                  Item ScrollLoot1 = Loot.RandomScroll( 0, 50, SpellbookType.Regular );
                  ScrollLoot1.Amount = Utility.Random( 2, 5 );
                  bag.DropItem( ScrollLoot1 );

                  Item ScrollLoot2 = Loot.RandomScroll( 0, 50, SpellbookType.Regular );
                  ScrollLoot2.Amount = Utility.Random( 2, 5 );
                  bag.DropItem( ScrollLoot2 );

		  pack.DropItem( bag );

		  PackItem( pack );

		}

		public override int GetAngerSound()
		{
			return 0x4E8;
		}

		public override int GetIdleSound()
		{
			return 0x4E7;
		}

		public override int GetAttackSound()
		{
			return 0x4E6;
		}

		public override int GetHurtSound()
		{
			return 0x4E9;
		}

		public override int GetDeathSound()
		{
			return 0x4E5;
		}
		
		public override void GenerateLoot()
		{
			AddLoot( LootPack.FilthyRich, 2 );
			AddLoot( LootPack.MedScrolls, 1 );

 		if ( Utility.RandomDouble() < 0.10 )
            {
	            BaseWeapon weapon = Loot.RandomWeapon( true );
		      BaseRunicTool.ApplyAttributesTo( weapon, 3, 25, 30 );  

			PackItem( weapon );
		}

 		if ( Utility.RandomDouble() < 0.05 )
            {
			  BaseClothing clothing = Loot.RandomClothing( true );
		        BaseRunicTool.ApplyAttributesTo( clothing, 3, 25, 30 );  

                    PackItem( clothing );
            }

 		if ( Utility.RandomDouble() < 0.05 )
            {
			  BaseShield shield = new ScarabShield();
			  if ( Core.AOS )
		        BaseRunicTool.ApplyAttributesTo( shield, 5, 25, 30 ); 

                    PackItem( shield );
            }

 		if ( Utility.RandomDouble() < 0.05 )
            {
			  BaseJewel bracelet = new GoldBracelet();
			  if ( Core.AOS )
		        BaseRunicTool.ApplyAttributesTo( bracelet, 5, 25, 30 );  

                    PackItem( bracelet );
            }

 		if ( Utility.RandomDouble() < 0.05 )
            {
			  BaseJewel earrings = new GoldEarrings();
			  if ( Core.AOS )
		        BaseRunicTool.ApplyAttributesTo( earrings, 5, 25, 30 ); 

                    PackItem( earrings );
            }

 		if ( Utility.RandomDouble() < 0.05 )
            {
			  BaseJewel necklace = new GoldNecklace();
			  if ( Core.AOS )
		        BaseRunicTool.ApplyAttributesTo( necklace, 5, 25, 30 );      

                    PackItem( necklace );
            }

 		if ( Utility.RandomDouble() < 0.05 )
            {
			  BaseJewel ring = new GoldRing();
			  if ( Core.AOS )
		        BaseRunicTool.ApplyAttributesTo( ring, 5, 25, 30 ); 

                    PackItem( ring );
            }

	}

		public override Poison PoisonImmune{ get{ return Poison.Greater; } }

		public override void OnGaveMeleeAttack( Mobile defender )
		{
			base.OnGaveMeleeAttack( defender );

			if ( 0.05 > Utility.RandomDouble() )
			{
				/* Rune Corruption
				 * Start cliloc: 1070846 "The creature magically corrupts your armor!"
				 * Effect: All resistances -70 (lowest 0) for 5 seconds
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

				timer = new ExpireTimer( defender, mods, TimeSpan.FromSeconds( 5.0 ) );
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

		public Beelzebug( Serial serial ) : base( serial )
		{
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );
			writer.Write( (int) 1 );
		}

		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader );
			int version = reader.ReadInt();

			if( version < 1 )
			{
				for ( int i = 0; i < Skills.Length; ++i )
				{
					Skills[i].Cap = Math.Max( 100.0, Skills[i].Cap * 0.9 );

					if ( Skills[i].Base > Skills[i].Cap )
					{
						Skills[i].Base = Skills[i].Cap;
					}
				}
			}
		}
	}
}