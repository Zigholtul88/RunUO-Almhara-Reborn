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
	[CorpseName( "a large frog corpse" )]
	public class LargeFrog : BaseCreature
	{
		[Constructable]
		public LargeFrog() : base( AIType.AI_Melee, FightMode.Aggressor, 10, 1, 0.175, 0.350 )
		{
			Name = "a large frog";
			Body = 80;
                        Hue = 663;
			BaseSoundID = 0x26B;

			SetStr( 30, 50 );
			SetDex( 25, 35 );
			SetInt( 15, 30 );

			SetMana( 100 );

			SetDamage( 1, 2 );

			SetDamageType( ResistanceType.Physical, 100 );

			SetResistance( ResistanceType.Physical, 12 );

			SetSkill( SkillName.MagicResist, 7.6, 9.8 );
			SetSkill( SkillName.Tactics, 45.6, 54.4 );
			SetSkill( SkillName.Wrestling, 50.7, 59.6 );

			Fame = 400;
			Karma = -400;

			Tamable = true;
			ControlSlots = 0;
			MinTameSkill = 9.1;

			PackGold( 27, 49 );
		}

		public override void AlterMeleeDamageFrom( Mobile from, ref int damage )
		{
			if ( from != null && from != this )
			{
				if ( from is PlayerMobile )
				{
					PlayerMobile p_PlayerMobile = from as PlayerMobile;
					Item weapon1 = p_PlayerMobile.FindItemOnLayer( Layer.OneHanded );
					Item weapon2 = p_PlayerMobile.FindItemOnLayer( Layer.TwoHanded );

					if ( weapon1 != null )
					{
						if ( weapon1 is BaseKnife )
						{
							damage *= 2;
						}
						else if ( weapon1 is BaseSpear )
						{
							damage *= 4;
						}
                                                else
                                                {
							damage += 0;
                                                }
					}
					else if ( weapon2 != null )
					{
						if ( weapon2 is BaseKnife )
						{
							damage *= 2;
						}
						else if ( weapon2 is BaseSpear )
						{
							damage *= 4;
						}
                                                else
                                                {
							damage += 0;
                                                }
					}
				}
			}
		}

		public override bool CanRummageCorpses{ get{ return true; } }
		public override FoodType FavoriteFood{ get{ return FoodType.Fish | FoodType.Meat; } }

		public override bool HasBreath{ get{ return true; } } // fish throw enabled

		public override double BreathMinDelay{ get{ return 15.0; } }
		public override double BreathMaxDelay{ get{ return 20.0; } }

		public override int BreathPhysicalDamage{ get{ return 100; } }
	        public override int BreathFireDamage{ get{ return 0; } }
		public override int BreathColdDamage{ get{ return 0; } }
		public override int BreathPoisonDamage{ get{ return 0; } }
		public override int BreathEnergyDamage{ get{ return 0; } }

		public override int BreathEffectHue{ get{ return 0; } }
		public override int BreathEffectItemID{ get{ return 0x0DD9; } }
		public override int BreathEffectSound{ get{ return 0x025; } }
		public override int BreathAngerSound{ get{ return 0x64; } }

		public override void OnGaveMeleeAttack( Mobile defender )
		{
			base.OnGaveMeleeAttack( defender );

			if ( !IsFanned( defender ) && 0.15 > Utility.RandomDouble() )
			{
                                defender.SendMessage( "The large frog sprays you with mist, reducing your resistance to physical attacks." );

		                ResistanceMod mod = new ResistanceMod( ResistanceType.Physical, - 50 );

				defender.FixedParticles( 0x3779, 10, 30, 0x34, EffectLayer.RightFoot );
				defender.PlaySound( 0x1E6 );

				// This should be done in place of the normal attack damage.
				//AOS.Damage( defender, this, Utility.RandomMinMax( 5, 10 ), 100, 0, 0, 0, 0 );

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

			      int amount = 1 + (int)( from.Skills[SkillName.Forensics].Value / 25 );

                              corpse.AddCarvedItem(new LargeFrogMeat( amount ), from );
                              corpse.AddCarvedItem(new SpinedHides(2), from);

                              from.SendMessage( "You carve up large frog meat and spined hides." );
                              corpse.Carved = true; 
			}
                }

		public override OppositionGroup OppositionGroup
		{
			get{ return OppositionGroup.ZaythalorPredator; }
		}

		public LargeFrog( Serial serial ) : base( serial )
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
