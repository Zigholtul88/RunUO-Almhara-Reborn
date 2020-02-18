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
	[CorpseName( "an ophidian corpse" )]
	public class OphidianEnforcer : BaseCreature
	{
		public override WeaponAbility GetWeaponAbility()
		{
			return WeaponAbility.ArmorIgnore;
		}

		[Constructable]
		public OphidianEnforcer() : base( AIType.AI_Melee, FightMode.Closest, 10, 1, 0.2, 0.4 )
		{
			Name = NameList.RandomName( "ophidian" );
			Title = "the ophidian enforcer"; 
			Body = 86;
			BaseSoundID = 634;

			SetStr( 197, 294 );
			SetDex( 117, 159 );
			SetInt( 78, 134 );

			SetHits( 256, 310 );

			SetDamage( 5, 11 );

			SetDamageType( ResistanceType.Physical, 100 );

			SetResistance( ResistanceType.Physical, 36 );
			SetResistance( ResistanceType.Fire, 20 );
			SetResistance( ResistanceType.Cold, 25 );
			SetResistance( ResistanceType.Poison, 30 );
			SetResistance( ResistanceType.Energy, 25 );

			SetSkill( SkillName.Ninjitsu, 100.0 );
			SetSkill( SkillName.MagicResist, 71.5, 82.8 );
			SetSkill( SkillName.Tactics, 75.7, 89.4 );
			SetSkill( SkillName.Wrestling, 100.0, 120.0 );

			Fame = 4500;
			Karma = -4500;

			PackGold( 226, 329 );

			PackItem( new Pearl() );
		}

		public override void OnGaveMeleeAttack( Mobile defender )
		{
			base.OnGaveMeleeAttack( defender );

			if( 0.5 > Utility.RandomDouble() )
			{
				/* Blood Bath
				 * Start cliloc 1070826
				 * Sound: 0x52B
				 * 2-3 blood spots
				 * Damage: 5 hps per second for 15 seconds
				 * End cliloc: 1070824
				 */

				ExpireTimer timer = (ExpireTimer)m_Table[defender];

				if( timer != null )
				{
					timer.DoExpire();
                                        defender.SendMessage( "The ophidian enforcer continues inflicting bleeding damage!" );
				}
				else
                                        defender.SendMessage( "The ophidian enforcer goes into a rage, inflicting continuous bleeding damage!" );

				timer = new ExpireTimer( defender, this );
				timer.Start();
				m_Table[defender] = timer;
			}
		}

		private static Hashtable m_Table = new Hashtable();

		private class ExpireTimer : Timer
		{
			private Mobile m_Mobile;
			private Mobile m_From;
			private int m_Count;

			public ExpireTimer( Mobile m, Mobile from ): base( TimeSpan.FromSeconds( 1.0 ), TimeSpan.FromSeconds( 1.0 ) )
			{
				m_Mobile = m;
				m_From = from;
				Priority = TimerPriority.TwoFiftyMS;
			}

			public void DoExpire()
			{
				Stop();
				m_Table.Remove( m_Mobile );
			}

			public void DrainLife()
			{
				if( m_Mobile.Alive )
					m_Mobile.Damage( 5, m_From );
				else
					DoExpire();
			}

			protected override void OnTick()
			{
				DrainLife();

				if( ++m_Count >= 15 )
				{
					DoExpire();
                                        m_Mobile.SendMessage( "The blood clouting from the ophidian enforcer's sting subsides." );
				}
			}
		}

                public override void OnCarve( Mobile from, Corpse corpse, Item with )
		{
			if ( corpse.Carved == false )
			{
			      base.OnCarve( from, corpse, with );

			      int amount = 1 + (int)( from.Skills[SkillName.Forensics].Value / 25 );

                              corpse.AddCarvedItem( new RawRibs( amount ), from );
                              corpse.AddCarvedItem( new SerpentScale( Utility.RandomMinMax( 12, 17 ) ), from );
                              corpse.AddCarvedItem( new OphidianEye(), from );

                              from.SendMessage( "You carve up raw ribs, serpent scales, and an ophidian eye." ); 
                              corpse.Carved = true;
			}
                }

		public override OppositionGroup OppositionGroup
		{
			get{ return OppositionGroup.TerathansAndOphidians; }
		}

		public OphidianEnforcer( Serial serial ) : base( serial )
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