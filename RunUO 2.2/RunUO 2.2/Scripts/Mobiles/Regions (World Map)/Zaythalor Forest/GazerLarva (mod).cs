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
	[CorpseName( "a gazer larva corpse" )]
	public class GazerLarva : BaseCreature
	{
		[Constructable]
		public GazerLarva () : base( AIType.AI_Mage, FightMode.Closest, 5, 1, 0.175, 0.350 )
		{
			Name = "a gazer larva";
			Body = 778;
			BaseSoundID = 377;

			SetStr( 76, 100 );
			SetDex( 51, 75 );
			SetInt( 56, 80 );

			SetMana( 350, 450 );

			SetDamage( 1, 2 );

			SetDamageType( ResistanceType.Physical, 100 );

			SetResistance( ResistanceType.Physical, 15 );

			SetSkill( SkillName.EvalInt, 76.7, 85.7 );
			SetSkill( SkillName.Magery, 80.0, 98.0 );
			SetSkill( SkillName.MagicResist, 83.2, 88.9 );
			SetSkill( SkillName.Meditation, 99.2, 99.9 );
			SetSkill( SkillName.Tactics, 45.6, 54.4 );
			SetSkill( SkillName.Wrestling, 50.7, 59.6 );

			Fame = 900;
			Karma = -900;

			PackGold( 56, 101 );
			PackReg( 3, 6 );

			PackItem( new Nightshade( Utility.RandomMinMax( 25, 50 ) ) );
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
						if ( weapon1 is BaseAxe )
						{
							damage *= 4;
						}
						else if ( weapon1 is BasePoleArm )
						{
							damage *= 4;
						}
						else if ( weapon1 is BaseSword )
						{
							damage *= 2;
						}
                                                else
                                                {
							damage += 0;
                                                }
					}
					else if ( weapon2 != null )
					{
						if ( weapon2 is BaseAxe )
						{
							damage *= 4;
						}
						else if ( weapon2 is BasePoleArm )
						{
							damage *= 4;
						}
						else if ( weapon2 is BaseSword )
						{
							damage *= 2;
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
		public override int Meat{ get{ return 1; } }

		public override bool HasBreath{ get{ return true; } } // energy bolt enabled

		public override double BreathMinDelay{ get{ return 15.0; } }
		public override double BreathMaxDelay{ get{ return 20.0; } }

		public override int BreathPhysicalDamage{ get{ return 0; } }
	        public override int BreathFireDamage{ get{ return 0; } }
		public override int BreathColdDamage{ get{ return 0; } }
		public override int BreathPoisonDamage{ get{ return 0; } }
		public override int BreathEnergyDamage{ get{ return 100; } }

		public override int BreathEffectHue{ get{ return 0; } }
		public override int BreathEffectItemID{ get{ return 0x379F; } }
		public override int BreathEffectSound{ get{ return 0x20A; } }
		public override int BreathAngerSound{ get{ return 377; } }

		public override void OnGaveMeleeAttack( Mobile defender )
		{
			base.OnGaveMeleeAttack( defender );

			if ( !IsFanned( defender ) && 0.15 > Utility.RandomDouble() )
			{
                                defender.SendMessage( "The gazer larva fans you with gas, reducing your resistance to energy attacks." );

		                ResistanceMod mod = new ResistanceMod( ResistanceType.Energy, - 50 );

				defender.FixedParticles( 0x3779, 10, 30, 0x34, EffectLayer.RightFoot );
				defender.PlaySound( 0x1E6 );

				// This should be done in place of the normal attack damage.
				//AOS.Damage( defender, this, Utility.RandomMinMax( 5, 10 ), 0, 0, 0, 0, 100 );

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
                                m_Mobile.SendMessage( "Your resistance to energy attacks has returned." );
				m_Mobile.RemoveResistanceMod( m_Mod );
				Stop();
				m_Table.Remove( m_Mobile );
			}
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

		public GazerLarva( Serial serial ) : base( serial )
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