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
	[CorpseName( "a Star Lake crab corpse" )]
	public class StarLakeCrab : BaseCreature
	{
		[Constructable]
		public StarLakeCrab() : base( AIType.AI_Melee, FightMode.Aggressor, 10, 1, 0.2, 0.4 )
		{
			Name = "a Star Lake crab";
			Body = 357;
                        Hue = 723;

			SetStr( 63, 81 );
			SetDex( 43, 79 );
			SetInt( 17, 33 );

			SetHits( 75, 85 );
			SetMana( 0 );

			SetDamage( 1, 3 );

			SetDamageType( ResistanceType.Physical, 100 );

			SetResistance( ResistanceType.Physical, 15 );

			SetSkill( SkillName.MagicResist, 12.1, 22.2 );
			SetSkill( SkillName.Tactics, 45.6, 54.4 );
			SetSkill( SkillName.Wrestling, 50.7, 59.6 );

			Fame = 450;
			Karma = -450;

			Tamable = true;
			ControlSlots = 1;
			MinTameSkill = 20.8;

                        PackGold( 16, 32 ); 
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
						if ( weapon1 is BaseBashing )
						{
							damage *= 2;
						}
						else if ( weapon1 is BaseStaff )
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
						if ( weapon2 is BaseBashing )
						{
							damage *= 2;
						}
						else if ( weapon2 is BaseStaff )
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

		public override int GetAttackSound() { return 563; } 
		public override int GetIdleSound() { return 1561; } 
		public override int GetAngerSound() { return 1558; } 
		public override int GetHurtSound() { return 1560; } 
		public override int GetDeathSound() { return 1559; }

		public override bool HasBreath{ get{ return true; } } // water gun enabled

		public override double BreathMinDelay{ get{ return 15.0; } }
		public override double BreathMaxDelay{ get{ return 20.0; } }

		public override int BreathPhysicalDamage{ get{ return 0; } }
	        public override int BreathFireDamage{ get{ return 0; } }
		public override int BreathColdDamage{ get{ return 100; } }
		public override int BreathPoisonDamage{ get{ return 0; } }
		public override int BreathEnergyDamage{ get{ return 0; } }

		public override int BreathEffectHue{ get{ return 1266; } }
		public override int BreathEffectItemID{ get{ return 0x1E28; } }
		public override int BreathEffectSound{ get{ return 0x364; } }
		public override int BreathAngerSound{ get{ return 1558; } }

		public override FoodType FavoriteFood{ get{ return FoodType.Meat; } }

		private DateTime m_NextAttack;

		public override void OnActionCombat()
		{
			Mobile combatant = Combatant;

			if ( combatant == null || combatant.Deleted || combatant.Map != Map || !InRange( combatant, 12 ) || !CanBeHarmful( combatant ) || !InLOS( combatant ) )
				return;

			if ( DateTime.Now >= m_NextAttack )
			{
				SandAttack( combatant );
				m_NextAttack = DateTime.Now + TimeSpan.FromSeconds( 10.0 + (10.0 * Utility.RandomDouble()) );
			}
		}

		public void SandAttack( Mobile m )
		{
			DoHarmful( m );

			m.FixedParticles( 0x36B0, 10, 25, 9540, 2413, 0, EffectLayer.Waist );

			new InternalTimer( m, this ).Start();
		}

		private class InternalTimer : Timer
		{
			private Mobile m_Mobile, m_From;

			public InternalTimer( Mobile m, Mobile from ) : base( TimeSpan.FromSeconds( 1.0 ) )
			{
				m_Mobile = m;
				m_From = from;
				Priority = TimerPriority.TwoFiftyMS;
			}

			protected override void OnTick()
			{
				m_Mobile.PlaySound( 0x4CF );
				AOS.Damage( m_Mobile, m_From, Utility.RandomMinMax( 1, 30 ), 90, 10, 0, 0, 0 );
			}
		}

		public override void OnGaveMeleeAttack( Mobile defender )
		{
			base.OnGaveMeleeAttack( defender );

			if ( !IsFanned( defender ) && 0.15 > Utility.RandomDouble() )
			{
                                defender.SendMessage( "The star lake crab fans you with gas, reducing your resistance to physical attacks." );

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

		public StarLakeCrab( Serial serial ) : base( serial )
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