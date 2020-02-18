using System;
using System.Collections;
using System.Collections.Generic;
using Server;
using Server.ContextMenus;
using Server.Items;
using Server.Mobiles;
using Server.Misc;
using Server.Targeting;
using Server.Engines.Quests;
using Server.Engines.Quests.StaffOfFlyingMonkeys;

namespace Server.Mobiles
{
	[CorpseName( "a cavern mongbat corpse" )]
	public class CavernMongbatElder : BaseCreature
	{
		public override WeaponAbility GetWeaponAbility()
		{
			return WeaponAbility.CrushingBlow;
		}

		[Constructable]
		public CavernMongbatElder() : base( AIType.AI_Melee, FightMode.Closest, 5, 1, 0.175, 0.350 )
		{
			Name = NameList.RandomName( "mongbat" );
			Title = "the cavern mongbat elder"; 
			Body = 39;
			Hue = Utility.RandomList( 1002,1005,1012,1023,1035,1038,1041,1047,1052,1058 );
			BaseSoundID = 422;

			SetStr( 197, 218 );
			SetDex( 104, 117 );
			SetInt( 78, 92 );

			SetHits( 675, 800 );

			SetDamage( 4, 8 );

			SetDamageType( ResistanceType.Physical, 100 );

			SetResistance( ResistanceType.Physical, 30 );

			SetSkill( SkillName.MagicResist, 57.9, 69.2 );
			SetSkill( SkillName.Tactics, 82.3, 91.5 );
			SetSkill( SkillName.Wrestling, 86.9, 93.4 );

			Fame = 15000;
			Karma = -15000;

			PackGold( 425, 532 );

			PackItem( new FishScale( Utility.RandomMinMax( 15, 25 ) ) );

                        if (Utility.RandomDouble() < 0.5 )
                        PackItem( new TreasureMap(1, Map.Malas ) );
		}

		public override bool Unprovokable{ get{ return true; } }

		public override void OnGaveMeleeAttack( Mobile defender )
		{
			base.OnGaveMeleeAttack( defender );

			if( 0.15 > Utility.RandomDouble() )
			{
				/* Blood Bath
				 * Start cliloc 1070826
				 * Sound: 0x52B
				 * 2-3 blood spots
				 * Damage: 1 hps per second for 60 seconds
				 * End cliloc: 1070824
				 */

				ExpireTimer timer = (ExpireTimer)m_Table[defender];

				if( timer != null )
				{
					timer.DoExpire();
                                        defender.SendMessage( "The mongbat elder continues inflicting bleeding damage!" );
				}
				else
                                        defender.SendMessage( "The mongbat elder goes into a rage, inflicting continuous bleeding damage!" );

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
					m_Mobile.Damage( 1, m_From );
				else
					DoExpire();
			}

			protected override void OnTick()
			{
				DrainLife();

				if( ++m_Count >= 60 )
				{
					DoExpire();
                                        m_Mobile.SendMessage( "The blood clouting from the mongbat elder's bite subsides." );
				}
			}
		}

                public override void OnCarve( Mobile from, Corpse corpse, Item with )
		{
			if ( corpse.Carved == false )
			{
			      base.OnCarve( from, corpse, with );

                              corpse.AddCarvedItem( new RawRibs(), from );
                              corpse.AddCarvedItem( new Hides(6), from );
                              corpse.AddCarvedItem( new CavernMongbatClaw(), from );

                              from.SendMessage( "You carve up a raw rib, some hides and a mongbat claw." );
                              corpse.Carved = true;   
			}
                }

                public void AwardLoot()
                {
                      List<Mobile> list = new List<Mobile>();

                      foreach ( Mobile m in GetMobilesInRange( 12 ) )
                      {
                             if ( !CanBeHarmful ( m ) )
                             continue;

                             if ( m.Player )
                             list.Add ( m );
                      }

                      foreach ( Mobile m in list )
                      {
			    StaffOfMongbats staff = new StaffOfMongbats();
			    MongbatHideoutBossKey bosskey = new MongbatHideoutBossKey();
				
		            PlayerMobile player = m as PlayerMobile;
			    QuestSystem qs = player.Quest;

			    if ( qs is StaffOfFlyingMonkeysQuest && qs.IsObjectiveInProgress( typeof( SeekElderObjective ) ) )
			    {
				       qs.AddObjective( new EscapeObjective() );

                                       m.AddToBackpack( new StaffOfMongbats() );
                                       m.SendMessage( "You receive a strange look staff." ); 
                                       DoHarmful( m );
			    }
                            else
                            {
                                       m.AddToBackpack( new MongbatHideoutBossKey() );
                                       m.SendMessage( "You receive a key needed to get pass the fog gates." );
                                       DoHarmful( m ); 
                            }
                      }
                }

		public override bool OnBeforeDeath() //what happens before it dies
		{
		      AwardLoot();
                      return base.OnBeforeDeath();
                }

		public CavernMongbatElder( Serial serial ) : base( serial )
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
