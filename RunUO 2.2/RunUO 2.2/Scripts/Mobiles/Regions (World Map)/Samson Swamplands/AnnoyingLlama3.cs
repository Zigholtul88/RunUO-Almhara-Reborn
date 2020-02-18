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
	[CorpseName( "a llama corpse" )]
	public class AnnoyingLlama3 : BaseFastEnemy
	{
		public static TimeSpan TalkDelay = TimeSpan.FromSeconds( 1.0 ); //the delay between talks is 1 second
		public DateTime m_NextTalk;

		[Constructable]
		public AnnoyingLlama3() : base( AIType.AI_Animal, FightMode.Aggressor, 16, 1, 0.175, 0.350 )
		{
			CurrentSpeed = BoostedSpeed;
			RangePerception = 200;

			Name = "a bog creeper 3";
			Body = 0xDC;
			BaseSoundID = 0x3F3;
                        Hue = 768;

			SetStr( 25, 48 );
			SetDex( 37, 55 );
			SetInt( 16, 30 );

			SetHits( 50000 );
			SetMana( 0 );

			SetDamage( 0 );

			SetDamageType( ResistanceType.Physical, 100 );

			SetResistance( ResistanceType.Physical, 100 );

			SetSkill( SkillName.Anatomy, 0.0 );
			SetSkill( SkillName.MagicResist, 15.5, 20.0 );

			Fame = 10;
			Karma = -10;

			FlyTimer.FlyList.Add( this );
		}

		public override int Meat{ get{ return 1; } }
		public override int Hides{ get{ return 12; } }

		public void OnTick()
		{
			Effects.PlaySound(Location, Map, 1086);
		}

	        public class FlyTimer : Timer 
	        {
		        public const bool Enabled = true;
		        public static List<AnnoyingLlama3> FlyList = new List<AnnoyingLlama3>();

		        public static void Initialize() 
		        {
			        if (Enabled)
				        new FlyTimer().Start();
		        }

		        public FlyTimer() : base(TimeSpan.FromSeconds( 1.0 ), TimeSpan.FromSeconds( 1.0 )) 
		        {
			        Priority = TimerPriority.OneSecond;
		        }

		        protected override void OnTick() 
		        {
			        foreach (AnnoyingLlama3 annoyingllama3 in FlyList)
				        annoyingllama3.OnTick();
		        }
	        }

		public override void OnMovement( Mobile m, Point3D oldLocation )
		{
			if ( DateTime.Now >= m_NextTalk && InRange( m, 10 ) && InLOS( m ) && m is PlayerMobile && !m.Hidden ) // check if it's time to talk & mobile in range & in los.
			{
				        ThrowJunk( m );

		                        m.Mana -= ( Utility.Random( 5, 10 ) ); 

			                RangePerception = 300;
			                CurrentSpeed = BoostedSpeed;
				        this.Combatant = m;

				m_NextTalk = DateTime.Now + TalkDelay; // set next talk time 
				switch ( Utility.Random( 33 ) )
				{
					case 0: Say("**");
						PlaySound(0x53D); 
						break;
					case 1: Say("**"); 
						PlaySound(0x53E);
						break;	
					case 2: Say("**");
						PlaySound(0x53F); 
						break;
					case 3: Say("**"); 
						PlaySound(0x540);
						break;
					case 4: Say("**");
						PlaySound(0x541); 
						break;
					case 5: Say("**"); 
						PlaySound(0x542);
						break;
					case 6: Say("**"); 
						PlaySound(0x543);
						break;
					case 7: Say("**"); 
						PlaySound(0x544);
						break;
					case 8: Say("**"); 
						PlaySound(0x545);
						break;
					case 9: Say("**"); 
						PlaySound(0x546);
						break;
					case 10: Say("**"); 
						PlaySound(0x547);
						break;
					case 11: Say("**"); 
						PlaySound(0x548);
						break;
					case 12: Say("**"); 
						PlaySound(0x549);
						break;
					case 13: Say("**"); 
						PlaySound(0x54A);
						break;
					case 14: Say("**"); 
						PlaySound(0x54B);
						break;
					case 15: Say("**"); 
						PlaySound(0x54E);
						break;
					case 16: Say("**"); 
						PlaySound(0x54F);
						break;
					case 17: Say("**"); 
						PlaySound(0x551);
						break;
					case 18: Say("**"); 
						PlaySound(0x552);
						break;
					case 19: Say("**"); 
						PlaySound(0x553);
						break;
					case 20: Say("**"); 
						PlaySound(0x554);
						break;
					case 21: Say("**"); 
						PlaySound(0x555);
						break;
					case 22: Say("**"); 
						PlaySound(0x556);
						break;
					case 23: Say("**"); 
						PlaySound(0x558);
						break;
					case 24: Say("**"); 
						PlaySound(0x55A);
						break;
					case 25: Say("**"); 
						PlaySound(0x55B);
						break;
					case 26: Say("**"); 
						PlaySound(0x55D);
						break;
					case 27: Say("**"); 
						PlaySound(0x55E);
						break;
					case 28: Say("**"); 
						PlaySound(0x55F);
						break;
					case 29: Say("**"); 
						PlaySound(0x561);
						break;
					case 30: Say("**"); 
						PlaySound(0x566);
						break;
					case 31: Say("**"); 
						PlaySound(0x568);
						break;
					case 32: Say("**"); 
						PlaySound(0x569);
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
				AOS.Damage( m_Mobile, m_From, Utility.RandomMinMax( 0, 0 ), 100, 0, 0, 0, 0 );
			}
		}
		#endregion

		public AnnoyingLlama3(Serial serial) : base(serial)
		{
		}

		public override void Serialize(GenericWriter writer)
		{
			base.Serialize(writer);

			writer.Write((int) 0);
		}

		public override void Deserialize(GenericReader reader)
		{
			base.Deserialize(reader);
			int version = reader.ReadInt();

			FlyTimer.FlyList.Add(this);
		}
	}
}