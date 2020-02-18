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
	public class OphidianAvenger : BaseCreature
	{
		public override WeaponAbility GetWeaponAbility()
		{
			return WeaponAbility.WhirlwindAttack;
		}

		[Constructable]
		public OphidianAvenger() : base( AIType.AI_Melee, FightMode.Closest, 10, 1, 0.2, 0.4 )
		{
			Name = NameList.RandomName( "ophidian" );
			Title = "the ophidian avenger"; 
			Body = 86;
			BaseSoundID = 634;

			SetStr( 417, 595 );
			SetDex( 166, 175 );
			SetInt( 46, 70 );

			SetHits( 532, 684 );

			SetDamage( 16, 19 );

			SetDamageType( ResistanceType.Physical, 100 );

			SetResistance( ResistanceType.Physical, 40 );
			SetResistance( ResistanceType.Fire, 30 );
			SetResistance( ResistanceType.Cold, 35 );
			SetResistance( ResistanceType.Poison, 90 );
			SetResistance( ResistanceType.Energy, 35 );

			SetSkill( SkillName.Poisoning, 60.1, 80.0 );
			SetSkill( SkillName.MagicResist, 65.1, 80.0 );
			SetSkill( SkillName.Tactics, 90.1, 100.0 );
			SetSkill( SkillName.Wrestling, 90.1, 100.0 );

			Fame = 10000;
			Karma = -10000;

			PackGold( 562, 671 );

			PackItem( new GreaterPoisonPotion() );
			PackItem( new PoisonPotion() );
		}

		public override void GenerateLoot()
		{
			AddLoot( LootPack.Potions, 4 );
		}

                public override void OnCarve( Mobile from, Corpse corpse, Item with )
		{
			if (corpse.Carved == false)
			{
			      base.OnCarve( from, corpse, with );

			      int amount = 1 + (int)( from.Skills[SkillName.Forensics].Value / 25 );

                              corpse.AddCarvedItem(new RawRibs( amount ), from );
                              corpse.AddCarvedItem(new SerpentScale( Utility.RandomMinMax( 19, 25 )), from);
                              corpse.AddCarvedItem(new OphidianEye(), from);

                              from.SendMessage( "You carve up raw ribs, serpent scales, and an ophidian eye." );
                              corpse.Carved = true; 
			}
                }

		public override Poison PoisonImmune{ get{ return Poison.Lethal; } }
		public override Poison HitPoison{ get{ return Poison.Lethal; } }

		public override OppositionGroup OppositionGroup
		{
			get{ return OppositionGroup.TerathansAndOphidians; }
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
                                        defender.SendMessage( "The ophidian avenger lands another blow in your weakened state." );
				}
				else
                                        defender.SendMessage( "The ophidian avenger's flurry of twigs has made you more susceptible to fire attacks!" );

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
                                        defender.SendMessage( "The ophidian avenger continues to hinder your energy resistance!" );
				}
				else
                                        defender.SendMessage( "The ophidian avenger's attack has made you more susceptible to energy attacks!" );

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

		public OphidianAvenger( Serial serial ) : base( serial )
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