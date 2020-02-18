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
	[CorpseName( "a tsuchigumo corpse" )]
	public class Tsuchigumo : BaseCreature
	{
		public override WeaponAbility GetWeaponAbility()
		{
			return WeaponAbility.BleedAttack;
		}

		[Constructable]
		public Tsuchigumo() : base( AIType.AI_Melee, FightMode.Closest, 5, 1, 0.175, 0.350 )
		{
			Name = "a tsuchigumo";
			Body = 735;
                        Hue = 1058;

			SetStr( 295, 300 );
			SetDex( 127, 187 );
			SetInt( 102, 134 );

			SetHits( 200, 300 );
			SetMana( 0 );

			SetDamage( 5, 10 );

			SetDamageType( ResistanceType.Physical, 20 );
			SetDamageType( ResistanceType.Poison, 80 );

			SetResistance( ResistanceType.Physical, 45 );
			SetResistance( ResistanceType.Fire, -25 );
			SetResistance( ResistanceType.Cold, 15 );
			SetResistance( ResistanceType.Poison, 100 );
			SetResistance( ResistanceType.Energy, 15 );

			SetSkill( SkillName.MagicResist, 55.5, 65.0 );
			SetSkill( SkillName.Tactics, 59.4, 65.9 );
			SetSkill( SkillName.Wrestling, 63.7, 75.8 );

			Fame = 5000;
			Karma = -5000;

			PackItem( new ChromeDiopside() );
		}

		public override void GenerateLoot()
		{
			AddLoot( LootPack.Gems, 5 );
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

		public override int GetIdleSound() { return 1605; } 
		public override int GetAngerSound() { return 1602; } 
		public override int GetHurtSound() { return 1604; } 
		public override int GetDeathSound() { return 1603; }

		public override PackInstinct PackInstinct{ get{ return PackInstinct.Arachnid; } }
		public override Poison PoisonImmune{ get{ return Poison.Greater; } }
		public override Poison HitPoison{ get{ return Poison.Regular; } }

		public override bool HasBreath{ get{ return true; } } // spider web enabled

		public override double BreathMinDelay{ get{ return 15.0; } }
		public override double BreathMaxDelay{ get{ return 20.0; } }

		public override int BreathPhysicalDamage{ get{ return 0; } }
	        public override int BreathFireDamage{ get{ return 0; } }
		public override int BreathColdDamage{ get{ return 0; } }
		public override int BreathPoisonDamage{ get{ return 100; } }
		public override int BreathEnergyDamage{ get{ return 0; } }

		public override int BreathEffectHue{ get{ return 0; } }
		public override int BreathEffectItemID{ get{ return 3811; } }
		public override int BreathEffectSound{ get{ return 0x382; } }
		public override int BreathAngerSound{ get{ return 1602; } }

                public override void OnCarve( Mobile from, Corpse corpse, Item with )
		{
			if ( corpse.Carved == false )
			{
			      base.OnCarve( from, corpse, with );

                              corpse.AddCarvedItem( new Gold( Utility.RandomMinMax( 325, 475 ) ), from );
                              corpse.AddCarvedItem( new SpidersSilk( Utility.RandomMinMax( 57, 108 ) ), from );
                              corpse.AddCarvedItem( new SpiderEgg( Utility.RandomMinMax( 16, 27 ) ), from );

                              from.SendMessage( "You carve up some gold, spider silk and spider eggs." );
                              corpse.Carved = true; 
			}
                }

		public override void OnDamagedBySpell( Mobile from )
		{
			if( from != null && from.Alive && 0.5 > Utility.RandomDouble() )
			{
				ThrowWeb( from );
				Animate( 18, 5, 1, true, false, 0 );
			}
		}

		public override void OnGotMeleeAttack( Mobile attacker )
		{
			base.OnGotMeleeAttack( attacker );

                        if (0.5 >= Utility.RandomDouble())
		                ThrowWeb( attacker );
				Animate( 18, 5, 1, true, false, 0 );
		}

                public override void OnGaveMeleeAttack( Mobile defender )
                {
                        base.OnGaveMeleeAttack( defender );

                        if (0.5 >= Utility.RandomDouble())
		                ThrowWeb( defender );
				Animate( 18, 5, 1, true, false, 0 );
                }

//////////////////////////////////////////////////// Throw Web ////////////////////////////////////////////////////

		#region Randomize
		private static int[] m_ItemID = new int[]
		{
                        3811, 3812, 3813, 3814
		};

		public static int GetRandomItemID()
		{
			return Utility.RandomList( m_ItemID );
		}

		private DateTime m_NextWeb;
		private int m_Thrown;

		public override void OnActionCombat()
		{
			Mobile combatant = Combatant;

			if ( combatant == null || combatant.Deleted || combatant.Map != Map || !InRange( combatant, 12 ) || !CanBeHarmful( combatant ) || !InLOS( combatant ) )
				return;

			if ( DateTime.Now >= m_NextWeb )
			{
				ThrowWeb( combatant );

				m_Thrown++;

				if ( 0.75 >= Utility.RandomDouble() && (m_Thrown % 2) == 1 ) // 75% chance to quickly throw another piece of web
					m_NextWeb = DateTime.Now + TimeSpan.FromSeconds( 10.0 );
				else
					m_NextWeb = DateTime.Now + TimeSpan.FromSeconds( 15.0 + (10.0 * Utility.RandomDouble()) ); // 15-25 seconds
			}
		}

		public void ThrowWeb( Mobile m )
		{
			this.MovingEffect( m, Utility.RandomList( m_ItemID ), 10, 0, false, false );
			this.DoHarmful( m );
			this.PlaySound( 0x382 ); // giant_snail1

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
				m_Mobile.PlaySound( 0x025 ); // splash01
		                m_Mobile.Hits -= ( Utility.Random( 15, 35 ) );
		                m_Mobile.Stam -= ( Utility.Random( 15, 35 ) );
		                m_Mobile.Mana -= ( Utility.Random( 15, 35 ) );
			}
		}
		#endregion

		public Tsuchigumo( Serial serial ) : base( serial )
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