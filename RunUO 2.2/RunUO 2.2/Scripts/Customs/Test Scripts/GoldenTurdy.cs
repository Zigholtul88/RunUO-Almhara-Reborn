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
	[CorpseName( "a turdy corpse" )]	
	public class GoldenTurdy : BaseCreature
	{
		public static TimeSpan TalkDelay = TimeSpan.FromSeconds( 1.0 ); //the delay between talks is 1 second
		public DateTime m_NextTalk;

		[Constructable]
		public GoldenTurdy() : base( AIType.AI_Animal, FightMode.Closest, 16, 1, 0.175, 0.350 )
		{
			CurrentSpeed = BoostedSpeed;
			RangePerception = 200;

			Name = "a golden turdy";
			Body = 6;
                        Hue = 1;

			SetStr( 12, 17 );
			SetDex( 9, 14 );
			SetInt( 5, 8 );

			SetHits( 100 );
			SetMana( 0 );

			SetDamage( 0 );

			SetDamageType( ResistanceType.Physical, 100 );

			SetResistance( ResistanceType.Physical, -50 );
			SetResistance( ResistanceType.Fire, -50 );
			SetResistance( ResistanceType.Cold, -50 );
			SetResistance( ResistanceType.Poison, -50 );
			SetResistance( ResistanceType.Energy, -50 );

			SetSkill( SkillName.Anatomy, 0.0 );
			SetSkill( SkillName.MagicResist, 0.0 );

			Fame = 10;
			Karma = -10;

			switch ( Utility.Random( 6 ))
			{
				case 0: PackItem( new Apple() ); break;
				case 1: PackItem( new Banana() ); break;
				case 2: PackItem( new Grapes() ); break;
				case 3: PackItem( new Lemon() ); break;
				case 4: PackItem( new Lime() ); break;
				case 5: PackItem( new Pear() ); break;
			}
		}

		public override MeatType MeatType{ get{ return MeatType.Bird; } }
		public override int Meat{ get{ return 1; } }
		public override int Feathers{ get{ return 25; } }
		public override FoodType FavoriteFood{ get{ return FoodType.FruitsAndVegies; } }

		public override void OnMovement( Mobile m, Point3D oldLocation )
		{
			if ( DateTime.Now >= m_NextTalk && InRange( m, 30 ) && InLOS( m ) && m is PlayerMobile ) // check if it's time to talk & mobile in range & in los.
			{
 			        if ( Utility.RandomDouble() < 0.25 )
                                {
				        ShootGold( m );

			                RangePerception = 300;
			                CurrentSpeed = BoostedSpeed;
				        this.Combatant = m;

                                        m.AddToBackpack( new Gold( 100 ) );
                                }

 			        if ( Utility.RandomDouble() < 0.01 )
                                {
				        ShootGold( m );

			                RangePerception = 300;
			                CurrentSpeed = BoostedSpeed;
				        this.Combatant = m;

                                        m.AddToBackpack( new Gold( 500 ) );
                                }

 			        if ( Utility.RandomDouble() < 0.01 )
                                {
				        ShootGold( m );

			                RangePerception = 300;
			                CurrentSpeed = BoostedSpeed;
				        this.Combatant = m;

                                        m.AddToBackpack( new Gold( 2000 ) );
                                        m.AddToBackpack( new TurdyKillSwitch( 1 ) );
                                }

				m_NextTalk = DateTime.Now + TalkDelay; // set next talk time 
				switch ( Utility.Random( 83 ) )
				{
					case 0: Say("**");
						PlaySound(0xA8); 
						break;
					case 1: Say("**"); 
						PlaySound(0x99);
						break;	
					case 2: Say("**");
						PlaySound(0x3F3); 
						break;
					case 3: Say("**"); 
						PlaySound(0x462);
						break;
					case 4: Say("**");
						PlaySound(0xC9); 
						break;
					case 5: Say("**"); 
						PlaySound(0xCA);
						break;
					case 6: Say("**"); 
						PlaySound(0xCB);
						break;
					case 7: Say("**"); 
						PlaySound(0xCC);
						break;
					case 8: Say("**"); 
						PlaySound(0xD6);
						break;
					case 9: Say("**"); 
						PlaySound(0xE5);
						break;
					case 10: Say("**"); 
						PlaySound(846);
						break;
					case 11: Say("**"); 
						PlaySound(0x21D);
						break;
					case 12: Say("**"); 
						PlaySound(0x162);
						break;
					case 13: Say("**"); 
						PlaySound(0x163);
						break;
					case 14: Say("**"); 
						PlaySound(0x270);
						break;
					case 15: Say("**"); 
						PlaySound(1511);
						break;
					case 16: Say("**"); 
						PlaySound(1508);
						break;
					case 17: Say("**"); 
						PlaySound(1510);
						break;
					case 18: Say("**"); 
						PlaySound(1509);
						break;
					case 19: Say("**"); 
						PlaySound(456);
						break;
					case 20: Say("**"); 
						PlaySound(0xC9);
						break;
					case 21: Say("**"); 
						PlaySound(0xCA);
						break;
					case 22: Say("**"); 
						PlaySound(0xCB);
						break;
					case 23: Say("**"); 
						PlaySound(0x26B);
						break;
					case 24: Say("**"); 
						PlaySound(0x5A);
						break;
					case 25: Say("**"); 
						PlaySound(0x164);
						break;
					case 26: Say("**"); 
						PlaySound(0x187);
						break;
					case 27: Say("**"); 
						PlaySound(0x1BA);
						break;
					case 28: Say("**"); 
						PlaySound(422);
						break;
					case 29: Say("**"); 
						PlaySound(0x388);
						break;
					case 30: Say("**"); 
						PlaySound(1320);
						break;
					case 31: Say("**"); 
						PlaySound(1354);
						break;
					case 32: Say("**"); 
						PlaySound(0x275);
						break;
					case 33: Say("**"); 
						PlaySound(0xA3);
						break;
					case 34: Say("**"); 
						PlaySound(0xC4);
						break;
					case 35: Say("**"); 
						PlaySound(0x64);
						break;
					case 36: Say("**"); 
						PlaySound(0x69);
						break;
					case 37: Say("**"); 
						PlaySound(0x6E);
						break;
					case 38: Say("**"); 
						PlaySound(0x78);
						break;
					case 39: Say("**"); 
						PlaySound(0x4D7);
						break;
					case 40: Say("**"); 
						PlaySound(0xD9);
						break;
					case 41: Say("**"); 
						PlaySound(0x99);
						break;
					case 42: Say("**"); 
						PlaySound(0x9E);
						break;
					case 43: Say("**"); 
						PlaySound(0x82);
						break;
					case 44: Say("**"); 
						PlaySound(0x83);
						break;
					case 45: Say("**"); 
						PlaySound(0x84);
						break;
					case 46: Say("**"); 
						PlaySound(0x277);
						break;
					case 47: Say("**"); 
						PlaySound(0x270);
						break;
					case 48: Say("**"); 
						PlaySound(0x273);
						break;
					case 49: Say("**"); 
						PlaySound(0x279);
						break;
					case 50: Say("**");
						PlaySound(0x53D); 
						break;
					case 51: Say("**"); 
						PlaySound(0x53E);
						break;	
					case 52: Say("**");
						PlaySound(0x53F); 
						break;
					case 53: Say("**"); 
						PlaySound(0x540);
						break;
					case 54: Say("**");
						PlaySound(0x541); 
						break;
					case 55: Say("**"); 
						PlaySound(0x542);
						break;
					case 56: Say("**"); 
						PlaySound(0x543);
						break;
					case 57: Say("**"); 
						PlaySound(0x544);
						break;
					case 58: Say("**"); 
						PlaySound(0x545);
						break;
					case 59: Say("**"); 
						PlaySound(0x546);
						break;
					case 60: Say("**"); 
						PlaySound(0x547);
						break;
					case 61: Say("**"); 
						PlaySound(0x548);
						break;
					case 62: Say("**"); 
						PlaySound(0x549);
						break;
					case 63: Say("**"); 
						PlaySound(0x54A);
						break;
					case 64: Say("**"); 
						PlaySound(0x54B);
						break;
					case 65: Say("**"); 
						PlaySound(0x54E);
						break;
					case 66: Say("**"); 
						PlaySound(0x54F);
						break;
					case 67: Say("**"); 
						PlaySound(0x551);
						break;
					case 68: Say("**"); 
						PlaySound(0x552);
						break;
					case 69: Say("**"); 
						PlaySound(0x553);
						break;
					case 70: Say("**"); 
						PlaySound(0x554);
						break;
					case 71: Say("**"); 
						PlaySound(0x555);
						break;
					case 72: Say("**"); 
						PlaySound(0x556);
						break;
					case 73: Say("**"); 
						PlaySound(0x558);
						break;
					case 74: Say("**"); 
						PlaySound(0x55A);
						break;
					case 75: Say("**"); 
						PlaySound(0x55B);
						break;
					case 76: Say("**"); 
						PlaySound(0x55D);
						break;
					case 77: Say("**"); 
						PlaySound(0x55E);
						break;
					case 78: Say("**"); 
						PlaySound(0x55F);
						break;
					case 79: Say("**"); 
						PlaySound(0x561);
						break;
					case 80: Say("**"); 
						PlaySound(0x566);
						break;
					case 81: Say("**"); 
						PlaySound(0x568);
						break;
					case 82: Say("**"); 
						PlaySound(0x569);
						break;
				};
			}
		}

//////////////////////////////////////////////////// Shoot Lightning Arrow ////////////////////////////////////////////////////

		#region Randomize
		private static int[] m_ItemID = new int[]
		{
                        3821
		};

		public static int GetRandomItemID()
		{
			return Utility.RandomList( m_ItemID );
		}

		private DateTime m_NextShootGold;
		private int m_Thrown;

		public override void OnActionCombat()
		{
			Mobile combatant = Combatant;

			if ( combatant == null || combatant.Deleted || combatant.Map != Map || !InRange( combatant, 12 ) || !CanBeHarmful( combatant ) || !InLOS( combatant ) )
				return;

			if ( DateTime.Now >= m_NextShootGold )
			{
				ShootGold( combatant );

				m_Thrown++;

				if ( 0.75 >= Utility.RandomDouble() && (m_Thrown % 2) == 1 ) // 75% chance to quickly shoot another pile of gold
					m_NextShootGold = DateTime.Now + TimeSpan.FromSeconds( 10.0 );
				else
					m_NextShootGold = DateTime.Now + TimeSpan.FromSeconds( 15.0 + (10.0 * Utility.RandomDouble()) ); // 15-25 seconds
			}
		}

		public void ShootGold( Mobile m )
		{
			this.MovingEffect( m, Utility.RandomList( m_ItemID ), 10, 0, false, false );
			this.DoHarmful( m );
			this.PlaySound( 0x20A ); // energy bolt

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
				m_Mobile.PlaySound( 741 ); // gold drop
			}
		}
		#endregion

		public GoldenTurdy( Serial serial ) : base( serial )
		{
		}

		public override int GetIdleSound() { return 0x0D1; }
		public override int GetAngerSound() { return 0x0D2; }
		public override int GetAttackSound() { return 0x0D3; }
		public override int GetHurtSound() { return 0x0D4; }
		public override int GetDeathSound() { return 0x0D5; }

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