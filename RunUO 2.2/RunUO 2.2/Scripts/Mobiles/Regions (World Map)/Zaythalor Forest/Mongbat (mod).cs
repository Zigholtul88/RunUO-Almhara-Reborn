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
	[CorpseName( "a mongbat corpse" )]
	public class Mongbat : BaseCreature
	{
		public static TimeSpan TalkDelay = TimeSpan.FromSeconds( 60.0 ); //the delay between talks is 60 seconds
		public DateTime m_NextTalk;

		[Constructable]
		public Mongbat() : base( AIType.AI_Melee, FightMode.Closest, 10, 1, 0.175, 0.350 )
		{
			Name = "a mongbat";
			Body = 39;
			BaseSoundID = 422;

			SetStr( 50 );
			SetDex( 26, 37 );
			SetInt( 10, 13 );

			SetDamage( 1, 2 );

			SetDamageType( ResistanceType.Physical, 100 );

			SetResistance( ResistanceType.Physical, 10 );

			SetSkill( SkillName.MagicResist, 5.3, 12.0 );
			SetSkill( SkillName.Tactics, 45.6, 54.4 );
			SetSkill( SkillName.Wrestling, 50.7, 59.6 );

			Fame = 150;
			Karma = -150;

			PackGold( 97, 126 );
			PackItem( new FishScale( Utility.RandomMinMax( 1, 2 ) ) );
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
		public override FoodType FavoriteFood{ get{ return FoodType.Meat; } }

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

		public override void OnMovement( Mobile m, Point3D oldLocation )
		{
			if ( DateTime.Now >= m_NextTalk && InRange( m, 4 ) && InLOS( m ) && m is PlayerMobile && !m.Hidden ) // check if it's time to talk & mobile in range & in los.
			{
				        ThrowJunk( m );

			                RangePerception = 300;
			                CurrentSpeed = BoostedSpeed;
				        this.Combatant = m;

				m_NextTalk = DateTime.Now + TalkDelay; // set next talk time 
				switch ( Utility.Random( 33 ) )
				{
					case 0: Say("**");
						break;
					case 1: Say("**"); 
						break;	
				};
			}
		}

//////////////////////////////////////////////////// Throw Junk ////////////////////////////////////////////////////

		#region Randomize
		private static int[] m_ItemID = new int[]
		{
3097, 3098, 3215, 3644, 3646, 3647, 3650, 3651, 3365, 3703, 3710, 3715, 3799, 3800, 3823, 3897, 3942, 3944, 4006, 4015, 4016, 4029, 4030, 4170, 4453, 4454, 4457, 4550, 4551, 4555, 4604, 4643, 4963, 4964, 4966, 5030, 5035, 5367, 5369, 11594, 11696, 11739, 15119, 16894, 16895, 17074, 14458, 14459, 14470, 14473, 14474, 14487, 14488, 14493, 14494, 14497, 14498, 14520, 14533
		};

		public static int GetRandomItemID()
		{
			return Utility.RandomList( m_ItemID );
		}

		private DateTime m_NextJunk;
		private int m_Thrown;

		public override void OnActionCombat()
		{
			Mobile combatant = Combatant;

			if ( combatant == null || combatant.Deleted || combatant.Map != Map || !InRange( combatant, 12 ) || !CanBeHarmful( combatant ) || !InLOS( combatant ) )
				return;

			if ( DateTime.Now >= m_NextJunk )
			{
				ThrowJunk( combatant );

				m_Thrown++;

				if ( 0.75 >= Utility.RandomDouble() && (m_Thrown % 2) == 1 ) // 75% chance to quickly throw another piece of junk
					m_NextJunk = DateTime.Now + TimeSpan.FromSeconds( 1.0 );
				else
					m_NextJunk = DateTime.Now + TimeSpan.FromSeconds( 1.0 + (1.0 * Utility.RandomDouble()) ); // 1-2 seconds
			}
		}

		public void ThrowJunk( Mobile m )
		{
			this.MovingEffect( m, Utility.RandomList( m_ItemID ), 10, 0, false, false );
			this.DoHarmful( m );
			this.PlaySound( 0x5D2 ); // throwH

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
				m_Mobile.FixedParticles( 0x36BD, 20, 10, 5044, EffectLayer.Head );
				m_Mobile.PlaySound( 0x307 );

				m_Mobile.PlaySound( 0x11D );
				AOS.Damage( m_Mobile, m_From, Utility.RandomMinMax( 1, 4 ), 100, 0, 0, 0, 0 );
			}
		}
		#endregion

		public Mongbat( Serial serial ) : base( serial )
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