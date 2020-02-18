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
	[CorpseName( "the corpse of Vollie" )]
	public class Vollie : BaseCreature
	{
		public override WeaponAbility GetWeaponAbility()
		{
			return WeaponAbility.ArmorIgnore;
		}

		[Constructable]
		public Vollie() : base( AIType.AI_Melee, FightMode.Aggressor, 10, 1, 0.2, 0.4 )
		{
			Name = "Vollie";
			Body = 806;
                        Hue = 251;

			SetStr( 79, 92 );
			SetDex( 56, 85 );
			SetInt( 24, 31 );

			SetHits( 424, 536 );
			SetMana( 100 );

			SetDamage( 1, 5 );

			SetDamageType( ResistanceType.Physical, 100 );

			SetResistance( ResistanceType.Physical, 17 );

			SetSkill( SkillName.MagicResist, 15.7, 25.7 );
			SetSkill( SkillName.Tactics, 93.1, 98.6 );
			SetSkill( SkillName.Wrestling, 93.1, 98.6 );

			Fame = 1000;
			Karma = -1000;
		}

		public override int GetAngerSound() { return 0x21D; } 
		public override int GetIdleSound() { return 0x21D; } 
		public override int GetAttackSound() { return 0x162; } 
		public override int GetHurtSound() { return 0x163; } 
		public override int GetDeathSound() { return 0x21D; }

		public override FoodType FavoriteFood{ get{ return FoodType.Meat; } }

		public override bool HasBreath{ get{ return true; } } // thunder ball enabled

		public override double BreathMinDelay{ get{ return 15.0; } }
		public override double BreathMaxDelay{ get{ return 25.0; } }

		public override int BreathPhysicalDamage{ get{ return 0; } }
	        public override int BreathFireDamage{ get{ return 0; } }
		public override int BreathColdDamage{ get{ return 0; } }
		public override int BreathPoisonDamage{ get{ return 0; } }
		public override int BreathEnergyDamage{ get{ return 100; } }

		public override int BreathEffectHue{ get{ return 86; } }
		public override int BreathEffectItemID{ get{ return 0x36FE; } }
		public override int BreathEffectSound{ get{ return 0x51D; } }
		public override int BreathAngerSound{ get{ return 0x2A8; } }

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
                                        defender.SendMessage( "Vollie another blow in your weakened state." );
				}
				else
                                        defender.SendMessage( "Vollie's flurry of twigs has made you more susceptible to physical attacks!" );

		                ResistanceMod mod = new ResistanceMod( ResistanceType.Physical, - 50 );

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
                                        defender.SendMessage( "Vollie continues to hinder your energy resistance!" );
				}
				else
                                        defender.SendMessage( "Vollie's attack has made you more susceptible to energy attacks!" );

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
                                        m_Mobile.SendMessage( "Your resistance to physical attacks has returned." );
				else
                                        m_Mobile.SendMessage( "Your resistance to energy attacks has returned." );

				DoExpire();
			}
		}

                public override void OnCarve( Mobile from, Corpse corpse, Item with )
		{
			if ( corpse.Carved == false )
			{
			      base.OnCarve( from, corpse, with );

                              corpse.AddCarvedItem( new BeetleEgg( Utility.RandomMinMax( 55, 99 ) ), from );

                              from.SendMessage( "You carve up some beetle eggs." );
                              corpse.Carved = true; 
			}
                }

		public Vollie( Serial serial ) : base( serial )
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