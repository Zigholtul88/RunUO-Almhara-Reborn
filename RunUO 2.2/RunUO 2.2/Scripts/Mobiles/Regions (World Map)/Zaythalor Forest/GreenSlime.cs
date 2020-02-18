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
	[CorpseName( "a green slime corpse" )]
	public class GreenSlime : BaseCreature
	{
		[Constructable]
		public GreenSlime() : base( AIType.AI_Melee, FightMode.Aggressor, 5, 1, 0.175, 0.350 )
		{
			Name = "a green slime";
			Body = 51;
			BaseSoundID = 456;
			Hue = 163;

			SetStr( 12, 17 );
			SetDex( 9, 14 );
			SetInt( 5, 8 );

			SetHits( 45, 60 );

			SetDamage( 1, 2 );

			SetDamageType( ResistanceType.Physical, 100 );

			SetResistance( ResistanceType.Physical, 5 );
			SetResistance( ResistanceType.Fire, -50 );
			SetResistance( ResistanceType.Poison, 10 );

			SetSkill( SkillName.Healing, 45.8, 60.2 );
			SetSkill( SkillName.MagicResist, 1.6, 1.9 );
			SetSkill( SkillName.Tactics, 45.6, 54.4 );
			SetSkill( SkillName.Wrestling, 50.7, 59.6 );

			Fame = 100;
			Karma = -100;

			Tamable = true;
			ControlSlots = 0;
			MinTameSkill = 1.0;

			PackReg( 1, 5 );
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
						if ( weapon1 is BaseEquipableLight )
						{
							damage *= 100;
						}
						else if ( weapon1 is BaseAxe )
						{
							damage += 0;
						}
						else if ( weapon1 is BaseBashing )
						{
							damage += 0;
						}
						else if ( weapon1 is BaseKnife )
						{
							damage += 0;
						}
						else if ( weapon1 is BasePoleArm )
						{
							damage += 0;
						}
						else if ( weapon1 is BaseRanged )
						{
							damage += 0;
						}
						else if ( weapon1 is BaseSpear )
						{
							damage += 0;
						}
						else if ( weapon1 is BaseStaff )
						{
							damage += 0;
						}
						else if ( weapon1 is BaseSword )
						{
							damage += 0;
						}
                                                else
                                                {
							damage += 0;
                                                }
					}
					else if ( weapon2 != null )
					{
						if ( weapon2 is BaseEquipableLight )
						{
							damage *= 100;
						}
						else if ( weapon2 is BaseAxe )
						{
							damage += 0;
						}
						else if ( weapon2 is BaseBashing )
						{
							damage += 0;
						}
						else if ( weapon2 is BaseKnife )
						{
							damage += 0;
						}
						else if ( weapon2 is BasePoleArm )
						{
							damage += 0;
						}
						else if ( weapon2 is BaseRanged )
						{
							damage += 0;
						}
						else if ( weapon2 is BaseSpear )
						{
							damage += 0;
						}
						else if ( weapon2 is BaseStaff )
						{
							damage += 0;
						}
						else if ( weapon2 is BaseSword )
						{
							damage += 0;
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
		public override FoodType FavoriteFood{ get{ return FoodType.Meat | FoodType.Fish | FoodType.FruitsAndVegies | FoodType.GrainsAndHay | FoodType.Eggs; } }

		public override bool HasBreath{ get{ return true; } } // green sludge enabled

		public override double BreathMinDelay{ get{ return 15.0; } }
		public override double BreathMaxDelay{ get{ return 20.0; } }

		public override int BreathPhysicalDamage{ get{ return 0; } }
	        public override int BreathFireDamage{ get{ return 0; } }
		public override int BreathColdDamage{ get{ return 0; } }
		public override int BreathPoisonDamage{ get{ return 100; } }
		public override int BreathEnergyDamage{ get{ return 0; } }

		public override int BreathEffectHue{ get{ return 163; } }
		public override int BreathEffectItemID{ get{ return 0x113E; } }
		public override int BreathEffectSound{ get{ return 0x1CA; } }
		public override int BreathAngerSound{ get{ return 0x0C9; } }

		public override void OnGaveMeleeAttack( Mobile defender )
		{
			base.OnGaveMeleeAttack( defender );

			if ( !IsFanned( defender ) && 0.15 > Utility.RandomDouble() )
			{
                                defender.SendMessage( "The green slime sprays you with gas, reducing your resistance to poison attacks." );

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

			      int amount = 1 + (int)( from.Skills[SkillName.Forensics].Value / 25 );

                              corpse.AddCarvedItem(new GreenSlimeVial( amount ), from );

                              from.SendMessage( "You carve up the corpse and notice a vial of green slime." );
                              corpse.Carved = true; 
			}
                }

		public override OppositionGroup OppositionGroup
		{
			get{ return OppositionGroup.ZaythalorPredator; }
		}

		public override bool IsEnemy( Mobile m )
		{
		        PlayerMobile pm = m as PlayerMobile;

			if ( m is PlayerMobile && m.SkillsTotal >= 5000 )
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

		public GreenSlime( Serial serial ) : base( serial )
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

