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
	[CorpseName( "an ophidian corpse" )]
	public class OphidianZealot : BaseCreature
	{
		public override WeaponAbility GetWeaponAbility()
		{
			return WeaponAbility.BleedAttack;
		}

		[Constructable]
		public OphidianZealot() : base( AIType.AI_Mage, FightMode.Closest, 10, 1, 0.2, 0.4 )
		{
			Name = NameList.RandomName( "ophidian" );
			Title = "the ophidian zealot"; 
			Body = 85;
			BaseSoundID = 639;

			SetStr( 584, 603 );
			SetDex( 199, 215 );
			SetInt( 826, 948 );

			SetMana( 1126, 1248 );

			SetDamage( 15, 20 );

			SetDamageType( ResistanceType.Physical, 100 );

			SetResistance( ResistanceType.Physical, 44 );
			SetResistance( ResistanceType.Fire, 20 );
			SetResistance( ResistanceType.Cold, 25 );
			SetResistance( ResistanceType.Poison, 35 );
			SetResistance( ResistanceType.Energy, 25 );

			SetSkill( SkillName.Magery, 96.2, 99.6 );
			SetSkill( SkillName.MagicResist, 84.6, 88.7 );
			SetSkill( SkillName.Necromancy, 120.0 );
			SetSkill( SkillName.SpiritSpeak, 120.0 );
			SetSkill( SkillName.Tactics, 74.3, 79.0 );
			SetSkill( SkillName.Wrestling, 33.1, 63.3 );

			Fame = 11500;
			Karma = -11500;

			PackGold( 527, 631 );
			PackReg( 75, 95 );
		}

		public override void GenerateLoot()
		{
			AddLoot( LootPack.Potions, 4 );
			AddLoot( LootPack.LowScrolls, 5 );
			AddLoot( LootPack.MedScrolls, 7 );
			AddLoot( LootPack.HighScrolls, 3 );
		}

		public override bool HasBreath{ get{ return true; } } // energy bolt enabled

		public override double BreathMinDelay{ get{ return 5.0; } }
		public override double BreathMaxDelay{ get{ return 10.0; } }

		public override int BreathPhysicalDamage{ get{ return 0; } }
	        public override int BreathFireDamage{ get{ return 0; } }
		public override int BreathColdDamage{ get{ return 0; } }
		public override int BreathPoisonDamage{ get{ return 0; } }
		public override int BreathEnergyDamage{ get{ return 100; } }

		public override int BreathEffectHue{ get{ return 0; } }
		public override int BreathEffectItemID{ get{ return 0x379F; } }
		public override int BreathEffectSound{ get{ return 0x20A; } }
		public override int BreathAngerSound{ get{ return 639; } }

                public override void OnCarve( Mobile from, Corpse corpse, Item with )
		{
			if (corpse.Carved == false)
			{
			      base.OnCarve( from, corpse, with );

			      int amount = 1 + (int)( from.Skills[SkillName.Forensics].Value / 25 );

                              corpse.AddCarvedItem(new RawRibs( amount ), from );
                              corpse.AddCarvedItem(new SerpentScale( Utility.RandomMinMax( 12, 17 )), from);
                              corpse.AddCarvedItem(new OphidianEye(), from);

                              from.SendMessage( "You carve up raw ribs, serpent scales, and an ophidian eye." );
                              corpse.Carved = true; 
			}
                }

		public override OppositionGroup OppositionGroup
		{
			get{ return OppositionGroup.TerathansAndOphidians; }
		}

		public override void OnDamagedBySpell( Mobile from )
		{
			if( from != null && from.Alive && 0.4 > Utility.RandomDouble() )
			{
				ShootMagicArrow( from );
			}
		}

		public override void OnGotMeleeAttack( Mobile attacker )
		{
			base.OnGotMeleeAttack( attacker );

			if( attacker != null && attacker.Alive && attacker.Weapon is BaseRanged && 0.4 > Utility.RandomDouble() )
			{
				ShootMagicArrow( attacker );
			}
		}

		public void ShootMagicArrow( Mobile to )
		{
			int damage = 25;
			this.MovingEffect( to, 0x36E4, 10, 0, false, false );
			this.DoHarmful( to );
			this.PlaySound( 0x1E5 ); // magic arrow
			AOS.Damage( to, this, damage, 0, 100, 0, 0, 0 );
		}

		public override void OnGaveMeleeAttack( Mobile defender )
		{
			base.OnGaveMeleeAttack( defender );

			if( 0.25 > Utility.RandomDouble() )
			{
				/* Flurry of Twigs
				 * Start cliloc: 1070850
				 * Effect: Physical resistance -50% for 15 seconds
				 * End cliloc: 1070852
				 * Effect: Type: "3" From: "0x57D4F5B" To: "0x0" ItemId: "0x37B9" ItemIdName: "glow" FromLocation: "(1048 779, 6)" ToLocation: "(1048 779, 6)" Speed: "10" Duration: "5" FixedDirection: "True" Explode: "False"
				 */

				ExpireTimer timer = (ExpireTimer)m_FlurryOfTwigsTable[defender];

				if( timer != null )
				{
					timer.DoExpire();
                                        defender.SendMessage( "The ophidian zealot lands another blow in your weakened state." );
				}
				else
                                        defender.SendMessage( "The ophidian zealot's flurry of twigs has made you more susceptible to fire attacks!" );

		                ResistanceMod mod = new ResistanceMod( ResistanceType.Fire, - 50 );

				defender.FixedEffect( 0x37B9, 10, 5 );
				defender.AddResistanceMod( mod );

				timer = new ExpireTimer( defender, mod, m_FlurryOfTwigsTable, TimeSpan.FromSeconds( 15.0 ) );
				timer.Start();
				m_FlurryOfTwigsTable[defender] = timer;
			}
			else if( 0.05 > Utility.RandomDouble() )
			{
				/* Chlorophyl Blast
				 * Start cliloc: 1070827
				 * Effect: Energy resistance -50% for 15 seconds
				 * End cliloc: 1070829
				 * Effect: Type: "3" From: "0x57D4F5B" To: "0x0" ItemId: "0x37B9" ItemIdName: "glow" FromLocation: "(1048 779, 6)" ToLocation: "(1048 779, 6)" Speed: "10" Duration: "5" FixedDirection: "True" Explode: "False"
				 */

				ExpireTimer timer = (ExpireTimer)m_ChlorophylBlastTable[defender];

				if( timer != null )
				{
					timer.DoExpire();
                                        defender.SendMessage( "The ophidian zealot continues to hinder your energy resistance!" );
				}
				else
                                        defender.SendMessage( "The ophidian zealot's attack has made you more susceptible to energy attacks!" );

		                ResistanceMod mod = new ResistanceMod( ResistanceType.Energy, - 50 );

				defender.FixedEffect( 0x37B9, 10, 5 );
				defender.AddResistanceMod( mod );

				timer = new ExpireTimer( defender, mod, m_ChlorophylBlastTable, TimeSpan.FromSeconds( 15.0 ) );
				timer.Start();
				m_ChlorophylBlastTable[defender] = timer;
			}
		}

		private static Hashtable m_FlurryOfTwigsTable = new Hashtable();
		private static Hashtable m_ChlorophylBlastTable = new Hashtable();

		private class ExpireTimer : Timer
		{
			private Mobile m_Mobile;
			private ResistanceMod m_Mod;
			private Hashtable m_Table;

			public ExpireTimer( Mobile m, ResistanceMod mod, Hashtable table, TimeSpan delay ): base( delay )
			{
				m_Mobile = m;
				m_Mod = mod;
				m_Table = table;
				Priority = TimerPriority.TwoFiftyMS;
			}

			public void DoExpire()
			{
				m_Mobile.RemoveResistanceMod( m_Mod );
				Stop();
				m_Table.Remove( m_Mobile );
			}

			protected override void OnTick()
			{
				if( m_Mod.Type == ResistanceType.Physical )
                                        m_Mobile.SendMessage( "Your resistance to fire attacks has returned." );
				else
                                        m_Mobile.SendMessage( "Your resistance to energy attacks has returned." );

				DoExpire();
			}
		}

		public OphidianZealot( Serial serial ) : base( serial )
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