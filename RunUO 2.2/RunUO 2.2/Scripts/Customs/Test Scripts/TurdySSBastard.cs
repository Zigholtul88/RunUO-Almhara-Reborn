using System;
using System.Collections;
using System.Collections.Generic;
using Server;
using Server.ContextMenus;
using Server.Items;
using Server.Misc;
using Server.Mobiles;
using Server.Network;
using Server.Spells;
using Server.Targeting;
using Server.Regions; 
using Server.SkillHandlers; 

namespace Server.Mobiles
{
	[CorpseName( "smoke weed everyday" )]	
	public class TurdySSBastard : BaseAssholeEnemy
	{
                private readonly Timer m_Timer;

		[Constructable]
		public TurdySSBastard() : base( AIType.AI_Animal, FightMode.Closest, 16, 1, 0.175, 0.350 )
		{
			Name = "a turdy ss bastard";
			Body = 6;
                        Hue = 1;

			SetStr( 12, 17 );
			SetDex( 9, 14 );
			SetInt( 5, 8 );

			SetHits( 50 );
			SetMana( 0 );

			SetDamage( 0 );

			SetDamageType( ResistanceType.Physical, 100 );

			SetResistance( ResistanceType.Physical, 80 );
			SetResistance( ResistanceType.Fire, 80 );
			SetResistance( ResistanceType.Cold, 80 );
			SetResistance( ResistanceType.Poison, 80 );
			SetResistance( ResistanceType.Energy, 80 );

			SetSkill( SkillName.Anatomy, 0.0 );
			SetSkill( SkillName.Archery, 100.0 );
			SetSkill( SkillName.MagicResist, 200.0 );
			SetSkill( SkillName.Tactics, 200.0 );
			SetSkill( SkillName.Wrestling, 200.0 );

			Fame = 420;
			Karma = -420;

                        this.m_Timer = new InternalTimer(this);
                        this.m_Timer.Start();

			FlyTimer.FlyList.Add( this );
		}

		public override FoodType FavoriteFood{ get{ return FoodType.FruitsAndVegies; } }

		public override void OnMovement( Mobile sucka, Point3D oldLocation )
		{
			if ( InRange( sucka, 15 ) && InLOS( sucka ) && !sucka.Hidden )
			{
				ExpireTimer timer = (ExpireTimer)m_Table[sucka];

				if( timer != null )
				{
					timer.DoExpire();
                                        sucka.SendMessage( "The turdy ss bastard continues annoying the hell out of you!" );
				}
				else
                                        sucka.SendMessage( "The turdy ss bastard goes into a spastic fit, reducing you to sheer insanity!" );

				timer = new ExpireTimer( sucka, this );
				timer.Start();
				m_Table[sucka] = timer;
			}
		}

		private static Hashtable m_Table = new Hashtable();

		private class ExpireTimer : Timer
		{
			private Mobile m_Mobile;
			private Mobile m_From;
			private int m_Count;

			public ExpireTimer( Mobile m, Mobile from ): base( TimeSpan.FromSeconds( 5.0 ), TimeSpan.FromSeconds( 5.0 ) )
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
				{
					switch ( Utility.Random( 40 ) )
					{
					case 0: 
                        			m_Mobile.BodyMod = 46;
                        			m_Mobile.HueMod = 0;
						m_Mobile.LightLevel = 0;
						break;
					case 1: 
                        			m_Mobile.BodyMod = 75;
                        			m_Mobile.HueMod = 0;
						m_Mobile.LightLevel = 16;
						break;
					case 2: 
                        			m_Mobile.BodyMod = 60;
                        			m_Mobile.HueMod = 0;
						m_Mobile.LightLevel = 26;
						break;
					case 3: 
                        			m_Mobile.BodyMod = 123;
                        			m_Mobile.HueMod = 0;
						m_Mobile.LightLevel = 30;
						break;
					case 4: 
                        			m_Mobile.BodyMod = 30;
                        			m_Mobile.HueMod = 0;
						m_Mobile.LightLevel = 0;
						break;
					case 5: 
                        			m_Mobile.BodyMod = 0x109;
                        			m_Mobile.HueMod = 0;
						m_Mobile.LightLevel = 16;
						break;
					case 6: 
                        			m_Mobile.BodyMod = 85;
                        			m_Mobile.HueMod = 0;
						m_Mobile.LightLevel = 26;
						break;
					case 7: 
                        			m_Mobile.BodyMod = 87;
                        			m_Mobile.HueMod = 0;
						m_Mobile.LightLevel = 30;
						break;	
					case 8: 
                        			m_Mobile.BodyMod = 86;
                        			m_Mobile.HueMod = 0;
						m_Mobile.LightLevel = 0;
						break;
					case 9: 
                        			m_Mobile.BodyMod = 213;
                        			m_Mobile.HueMod = 0;
						m_Mobile.LightLevel = 16;
						break;
					case 10: 
                        			m_Mobile.BodyMod = 789;
                        			m_Mobile.HueMod = 0;
						m_Mobile.LightLevel = 26;
						break;
					case 11: 
                        			m_Mobile.BodyMod = 430;
                        			m_Mobile.HueMod = 0;
						m_Mobile.LightLevel = 30;
						break;
					case 12: 
                        			m_Mobile.BodyMod = 104;
                        			m_Mobile.HueMod = 0;
						m_Mobile.LightLevel = 0;
						break;	
					case 13: 
                        			m_Mobile.BodyMod = 149;
                        			m_Mobile.HueMod = 0;
						m_Mobile.LightLevel = 16;
						break;
					case 14: 
                        			m_Mobile.BodyMod = 76;
                        			m_Mobile.HueMod = 0;
						m_Mobile.LightLevel = 26;
						break;
					case 15: 
                        			m_Mobile.BodyMod = 1026;
                        			m_Mobile.HueMod = 0;
						m_Mobile.LightLevel = 30;
						break;
					case 16: 
                        			m_Mobile.BodyMod = 738;
                        			m_Mobile.HueMod = 0;
						m_Mobile.LightLevel = 0;
						break;
					case 17: 
                        			m_Mobile.BodyMod = 242;
                        			m_Mobile.HueMod = 0;
						m_Mobile.LightLevel = 16;
						break;
					case 18: 
                        			m_Mobile.BodyMod = 18;
                        			m_Mobile.HueMod = 0;
						m_Mobile.LightLevel = 26;
						break;
					case 19: 
                        			m_Mobile.BodyMod = 1;
                        			m_Mobile.HueMod = 0;
						m_Mobile.LightLevel = 30;
						break;
					case 20: 
                        			m_Mobile.BodyMod = 54;
                        			m_Mobile.HueMod = 0;
						m_Mobile.LightLevel = 0;
						break;
					case 21: 
                        			m_Mobile.BodyMod = 735;
                        			m_Mobile.HueMod = 0;
						m_Mobile.LightLevel = 16;
						break;
					case 22: 
                        			m_Mobile.BodyMod = 248;
                        			m_Mobile.HueMod = 0;
						m_Mobile.LightLevel = 26;
						break;
					case 23: 
                        			m_Mobile.BodyMod = 716;
                        			m_Mobile.HueMod = 0;
						m_Mobile.LightLevel = 30;
						break;
					case 24: 
                        			m_Mobile.BodyMod = 51;
                        			m_Mobile.HueMod = 0;
						m_Mobile.LightLevel = 0;
						break;
					case 25: 
                        			m_Mobile.BodyMod = 0xED;
                        			m_Mobile.HueMod = 0;
						m_Mobile.LightLevel = 16;
						break;
					case 26: 
                        			m_Mobile.BodyMod = 80;
                        			m_Mobile.HueMod = 0;
						m_Mobile.LightLevel = 26;
						break;
					case 27: 
                        			m_Mobile.BodyMod = 787;
                        			m_Mobile.HueMod = 0; 
						m_Mobile.LightLevel = 30;
						break;
					case 28: 
                        			m_Mobile.BodyMod = 1247;
                        			m_Mobile.HueMod = 0;
						m_Mobile.LightLevel = 0;
						break;
					case 29: 
                        			m_Mobile.BodyMod = 39;
                        			m_Mobile.HueMod = 0;
						m_Mobile.LightLevel = 16;
						break;
					case 30: 
                        			m_Mobile.BodyMod = 264;
                        			m_Mobile.HueMod = 0;
						m_Mobile.LightLevel = 26;
						break;
					case 31: 
                        			m_Mobile.BodyMod = 0xCA;
                        			m_Mobile.HueMod = 0;
						m_Mobile.LightLevel = 30;
						break;
					case 32: 
                        			m_Mobile.BodyMod = 249;
                        			m_Mobile.HueMod = 0;
						m_Mobile.LightLevel = 0;
						break;
					case 33: 
                        			m_Mobile.BodyMod = 244;
                        			m_Mobile.HueMod = 0;
						m_Mobile.LightLevel = 16;
						break;
					case 34: 
                        			m_Mobile.BodyMod = 255;
                        			m_Mobile.HueMod = 0;
						m_Mobile.LightLevel = 26;
						break;
					case 35: 
                        			m_Mobile.BodyMod = 308;
                        			m_Mobile.HueMod = 0;
						m_Mobile.LightLevel = 30;
						break;
					case 36: 
                        			m_Mobile.BodyMod = 305;
                        			m_Mobile.HueMod = 0;
						m_Mobile.LightLevel = 0;
						break;
					case 37: 
                        			m_Mobile.BodyMod = 313;
                        			m_Mobile.HueMod = 0;
						m_Mobile.LightLevel = 16;
						break;
					case 38: 
                        			m_Mobile.BodyMod = 311;
                        			m_Mobile.HueMod = 0;
						m_Mobile.LightLevel = 26;
						break;
					case 39: 
                        			m_Mobile.BodyMod = 306;
                        			m_Mobile.HueMod = 0;
						m_Mobile.LightLevel = 30;
						break;
					};
				}
				else
				{
					DoExpire();
				}
			}

			protected override void OnTick()
			{
				DrainLife();

				if( ++m_Count >= 300 )
				{
					DoExpire();
                                        m_Mobile.SendMessage( "The insanity has subsided." );
                        		m_Mobile.BodyMod = 0;
                        		m_Mobile.HueMod = -1;
				}
			}
		}

		public override void OnThink()
		{
			base.OnThink();

			Undress( Combatant );
		}

		#region Undress
		private DateTime m_NextUndress;

		public void Undress( Mobile target )
		{
			if ( target == null || Deleted || !Alive || m_NextUndress > DateTime.Now || 0.05 < Utility.RandomDouble() )
				return;

			if ( target.Player && !target.Hidden && CanBeHarmful( target ) )
			{
				UndressItem( target, Layer.OuterTorso );
				UndressItem( target, Layer.InnerTorso );
				UndressItem( target, Layer.MiddleTorso );
				UndressItem( target, Layer.Pants );
				UndressItem( target, Layer.Shirt );
				UndressItem( target, Layer.OneHanded );
				UndressItem( target, Layer.TwoHanded );
				UndressItem( target, Layer.Bracelet );
				UndressItem( target, Layer.Earrings );
				UndressItem( target, Layer.Neck );
				UndressItem( target, Layer.Ring );
				UndressItem( target, Layer.Arms );
				UndressItem( target, Layer.Cloak );
				UndressItem( target, Layer.Gloves );
				UndressItem( target, Layer.Helm );
				UndressItem( target, Layer.InnerLegs );
				UndressItem( target, Layer.OuterLegs );
				UndressItem( target, Layer.Shoes );

                                target.SendMessage( "This turdy sonavabiche's music makes it hot in here. Your clothing is too restrictive." );
			}

			m_NextUndress = DateTime.Now + TimeSpan.FromSeconds( 5 );
		}

		public void UndressItem( Mobile m, Layer layer )
		{
			Item item = m.FindItemOnLayer( layer );

			if ( item != null && item.Movable )
				m.PlaceInBackpack( item );
		}
		#endregion

//////////////////////////////////////////////////// Throw Junk ////////////////////////////////////////////////////

		#region Randomize
		private static int[] m_ItemID = new int[]
		{
3097, 3098, 3215, 3644, 3646, 3647, 3650, 3651, 3365, 3703, 3710, 3715, 3799, 3800, 3823, 3897, 3942, 3944, 4006, 4015, 4016, 4029, 4030, 4170, 4453, 4454, 4457, 4550, 4551, 4555, 4604, 4643, 4963, 4964, 4966, 5030, 5035, 5367, 5369, 11594, 11696, 11739
		};

		public static int GetRandomItemID()
		{
			return Utility.RandomList( m_ItemID );
		}

		public void ThrowJunk( Mobile to )
		{
			this.MovingEffect( to, Utility.RandomList( m_ItemID ), 10, 0, false, false );
			this.DoHarmful( to );
                        AOS.Damage( to, this, Utility.Random( 0, 1 ), 100, 0, 0, 0, 0 );
			this.PlaySound( 0x5D2 ); // throwH
		}
		#endregion

                public override void OnCarve( Mobile from, Corpse corpse, Item with )
		{
			if (corpse.Carved == false)
			{
			      base.OnCarve( from, corpse, with );

                        corpse.AddCarvedItem(new RawRibs(5), from );
                        corpse.AddCarvedItem(new RawRibs(4), from );
                        corpse.AddCarvedItem(new RawRibs(3), from );
                        corpse.AddCarvedItem(new RawRibs(2), from );
                        corpse.AddCarvedItem(new Hides(12), from );
                        corpse.AddCarvedItem(new Hides(6), from );
                        corpse.AddCarvedItem(new Hides(4), from );
                        corpse.AddCarvedItem(new Spear(), from );
                        corpse.AddCarvedItem(new Spear(), from );
                        corpse.AddCarvedItem(new Spear(), from );
                        corpse.AddCarvedItem(new Spear(), from );
                        corpse.AddCarvedItem(new Spear(), from );
                        corpse.AddCarvedItem(new Spear(), from );
                        corpse.AddCarvedItem(new Spear(), from );
                        corpse.AddCarvedItem(new Spear(), from );
                        corpse.AddCarvedItem(new Spear(), from );
                        corpse.AddCarvedItem(new Spear(), from );
                        corpse.AddCarvedItem(new Spear(), from );
                        corpse.AddCarvedItem(new Spear(), from );
                        corpse.AddCarvedItem(new Spear(), from );
                        corpse.AddCarvedItem(new Spear(), from );
                        corpse.AddCarvedItem(new Spear(), from );
                        corpse.AddCarvedItem(new Spear(), from );
                        corpse.AddCarvedItem(new Spear(), from );
                        corpse.AddCarvedItem(new Spear(), from );
                        corpse.AddCarvedItem(new Gold( Utility.RandomMinMax( 1, 5 ) ), from );
                        corpse.AddCarvedItem(new Gold( Utility.RandomMinMax( 1, 5 ) ), from );
                        corpse.AddCarvedItem(new Gold( Utility.RandomMinMax( 1, 5 ) ), from );
                        corpse.AddCarvedItem(new Gold( Utility.RandomMinMax( 1, 5 ) ), from );
                        corpse.AddCarvedItem(new Gold( Utility.RandomMinMax( 1, 5 ) ), from );

		        from.Hits -= ( Utility.Random( 4, 20 ) ); 
		        from.Stam -= ( Utility.Random( 4, 20 ) );
		        from.Mana -= ( Utility.Random( 4, 20 ) ); 

			from.Say( "*flaming farts*" );
                        from.SendMessage( "Ouch! Flamed, and farted upon!" );
		        from.FixedParticles( 0x3709, 10, 30, 5052, EffectLayer.LeftFoot );
                        from.FixedParticles(0x36B0, 1, 14, 0x26BB, 0x3F, 0x7, EffectLayer.Waist);
		        from.PlaySound( from.Female ? 814 : 1088 );
                        from.PlaySound( from.Female ? 792 : 1064 );

                        World.Broadcast( 0x35, true, string.Format( "This pathetic turdy was just carved up by {0}. Enjoy the loot, asshole!", from.Name ) );
                        corpse.Carved = true;
			}
                }

		public void OnTick()
		{
			Effects.PlaySound(Location, Map, Utility.RandomList( 0x428,1053,1086,0xA8,0x99,0x3F3,0x462,0xC9,0xCA,0xCB,0xCC,0xD6,0xE5,846,0x21D,0x162,0x163,0x270,1511,1508,1510,1509,456,0xC9,0xCA,0xCB,0x26B,0x5A,0x164,0x187,0x1BA,422,0x388,1320,1354,0x275,0xA3,0xC4,0x64,0x69,0x6E,0x78,0x4D7,0xD9,0x99,0x9E,0x82,0x83,0x84,0x277,0x270,0x273,0x279,0x53D,0x53E,0x53F,0x540,0x541,0x542,0x543,0x544,0x545,0x546,0x547,0x548,0x549,0x54A,0x54B,0x54E,0x54F,0x551,0x552,0x553,0x554,0x555,0x556,0x558,0x55A,0x55B,0x55D,0x55E,0x55F,0x561,0x566,0x568,0x569 ) );
		}

	        public class FlyTimer : Timer 
	        {
		        public const bool Enabled = true;
		        public static List<TurdySSBastard> FlyList = new List<TurdySSBastard>();

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
			        foreach (TurdySSBastard turdyssbastard in FlyList)
				        turdyssbastard.OnTick();
		        }
	        }

		public override bool OnBeforeDeath( ) //what happens before it dies
		{
			Map map = this.Map; //set variable map to hold the current map

			if ( map != null ) //if the map isn't null (anti crash check) continue
			{
				for ( int x = -8; x <= 8; ++x ) //for 8x8 location
				{
					for ( int y = -8; y <= 8; ++y )
					{
						double dist = Math.Sqrt(x*x+y*y);

						if ( dist <= 8 )
							new CheeseWheelTimer( map, X + x, Y + y ).Start(); //spawn cheese on timers
					}
				}
			}
			return true;
		}

		public TurdySSBastard( Serial serial ) : base( serial )
		{
                        this.m_Timer = new InternalTimer(this);
                        this.m_Timer.Start();
		}

                public override void OnDelete()
                {
                        this.m_Timer.Stop();

                        base.OnDelete();
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

			FlyTimer.FlyList.Add(this);
		}

		private class InternalTimer : Timer
		{
			private TurdySSBastard m_Owner;
			private int m_Count = 0;

			public InternalTimer( TurdySSBastard owner ) : base( TimeSpan.FromSeconds( 0.1 ), TimeSpan.FromSeconds( 0.1 ) )
			{
				m_Owner = owner;
			}

			protected override void OnTick()
			{
				if ( (m_Count++ & 0x30) == 0 )
				{
					m_Owner.Direction = (Direction)(Utility.Random( 16 ) | 0x80);
				}

				m_Owner.Move( m_Owner.Direction );
			}
		}

//////////////////////////////////////////////////////// Spawn Cheese Wheel ////////////////////////////////////////////////////////
		private class CheeseWheelTimer : Timer
		{
			private Map m_Map;
			private int m_X, m_Y;

			public CheeseWheelTimer( Map map, int x, int y ) : base( TimeSpan.FromSeconds( Utility.RandomDouble() * 60.0 ) )
			{
				m_Map = map;
				m_X = x;
				m_Y = y;
			}

			protected override void OnTick()
			{
				int z = m_Map.GetAverageZ( m_X, m_Y );
				bool canFit = m_Map.CanFit( m_X, m_Y, z, 6, false, false );

				for ( int i = -3; !canFit && i <= 3; ++i )
				{
					canFit = m_Map.CanFit( m_X, m_Y, z + i, 6, false, false );

					if ( canFit )
						z += i;
				}

				if ( !canFit )
					return;

				CheeseWheel c = new CheeseWheel();
				
				c.MoveToWorld( new Point3D( m_X, m_Y, z ), m_Map );

				if ( 0.5 >= Utility.RandomDouble() )
				{
					switch ( Utility.Random( 7 ) )
					{
						case 0: // Fire column
						{
						Effects.SendLocationParticles( EffectItem.Create( c.Location, c.Map, EffectItem.DefaultDuration ), 0x3709, 10, 30, 9966 );
						Effects.PlaySound( c, c.Map, 782 ); // female burp

							break;
						}
						case 1: // Explosion
						{
						Effects.SendLocationParticles( EffectItem.Create( c.Location, c.Map, EffectItem.DefaultDuration ), 0x36BD, 10, 20, 9502 );
						Effects.PlaySound( c, c.Map, 792 ); // female fart

							break;
						}
						case 2: // Ball of fire
						{
						Effects.SendLocationParticles( EffectItem.Create( c.Location, c.Map, EffectItem.DefaultDuration ), 0x36FE, 10, 30, 9961 );
						Effects.PlaySound( c, c.Map, 1064 ); // male fart

							break;
						}
						case 3: // Greater Heal 1
						{
						Effects.SendLocationParticles( EffectItem.Create( c.Location, c.Map, EffectItem.DefaultDuration ), 0x375A, 10, 20, 9966 );
						Effects.PlaySound( c, c.Map, 1095 ); // male whistle

							break;
						}
						case 4: // Greater Heal 2
						{
						Effects.SendLocationParticles( EffectItem.Create( c.Location, c.Map, EffectItem.DefaultDuration ), 0x37B9, 10, 30, 9502 );
						Effects.PlaySound( c, c.Map, 1053 ); // male burp

							break;
						}
						case 5: // Greater Heal 3
						{
						Effects.SendLocationParticles( EffectItem.Create( c.Location, c.Map, EffectItem.DefaultDuration ), 0x376A, 10, 20, 9961 );
						Effects.PlaySound( c, c.Map, 783 ); // female woohoo

							break;
						}
						case 6: // Greater Heal 4
						{
						Effects.SendLocationParticles( EffectItem.Create( c.Location, c.Map, EffectItem.DefaultDuration ), 0x37C4, 10, 30, 9502 );
						Effects.PlaySound( c, c.Map, 821 ); // female whistle

							break;
						}
					}
				}
			}
		}
	}
}