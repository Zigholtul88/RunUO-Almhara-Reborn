using System;
using System.Collections;
using System.Collections.Generic;
using Server;
using Server.ContextMenus;
using Server.Items;
using Server.Mobiles;
using Server.Misc;
using Server.Network;
using Server.Spells;
using Server.Targeting;

namespace Server.Mobiles
{
	[CorpseName( "the corpse of either a lemon or petunia" )]
	public class FluffySnapperSpearThruster : BaseCreature
	{
		public override double BoostedSpeed{ get{ return 0.05; } }
		public override bool ReduceSpeedWithDamage{ get{ return false; } }

		public override WeaponAbility GetWeaponAbility()
		{
			return WeaponAbility.BleedAttack;
		}

		[Constructable]
		public FluffySnapperSpearThruster() : base( AIType.AI_Melee, FightMode.Closest, 5, 1, 0.05, 0.05 )
		{
			Name = NameList.RandomName( "parrot" );
			Title = "fluffy snapper spear thruster";
			Body = 205;
			Hue = Utility.RandomList( 44, 1102, 1109, 1111, 1141, 1148, 1153, 2213 );
			AddItem( new LightSource() );

			SetStr( 123, 246 );
			SetDex( 36, 59 );
			SetInt( 5, 8 );

			SetHits( 200, 300 );

			SetDamage( 6, 9 );

			SetDamageType( ResistanceType.Physical, 100 );

			SetResistance( ResistanceType.Physical, 70 );
			SetResistance( ResistanceType.Fire, 0 );
			SetResistance( ResistanceType.Cold, 0 );
			SetResistance( ResistanceType.Poison, 0 );
			SetResistance( ResistanceType.Energy, 0 );

			SetSkill( SkillName.MagicResist, 31.2, 34.8 );
			SetSkill( SkillName.Tactics, 41.9, 50.2 );
			SetSkill( SkillName.Wrestling, 50.4, 56.7 );

			Fame = 420;
			Karma = -420;

			VirtualArmor = 25;

			Tamable = true;
			ControlSlots = 3;
			MinTameSkill = 42.0;

			PackItem( new BreadLoaf( 6 ) );
			PackItem( new CheeseWheel() );
			PackItem( new ChainCoif() );
		}

		public override bool HasBreath{ get{ return true; } } // fire breath enabled

		public override int BreathPhysicalDamage{ get{ return 100; } }
		public override int BreathFireDamage{ get{ return 0; } }
		public override int BreathColdDamage{ get{ return 0; } }
		public override int BreathPoisonDamage{ get{ return 0; } }
		public override int BreathEnergyDamage{ get{ return 0; } }

		public override int BreathEffectItemID{ get{ return 0xF62; } }
		public override int BreathEffectSound{ get{ return 792; } }
		public override int BreathAngerSound{ get{ return 809; } }

		public override FoodType FavoriteFood{ get{ return FoodType.FruitsAndVegies; } }

		private DateTime m_LastRadiated;
	        private Hashtable m_Mobiles = new Hashtable();

		protected override bool OnMove( Direction d )
		{
			if ( !IsDeadBondedPet )
			{
				if ( m_LastRadiated <= DateTime.Now )
					m_LastRadiated = DateTime.Now.AddSeconds( Utility.Random( 2 ) );
				IPooledEnumerable eable = GetMobilesInRange( 2 );
				foreach( Mobile m in eable )
					if ( m_Mobiles[m] == null )
						m_Mobiles[m] = Timer.DelayCall( TimeSpan.Zero, TimeSpan.FromSeconds( 1.0 ), new TimerStateCallback( RadiationCallBack ), m );
			}

			return base.OnMove( d );
		}

		public override void OnMovement( Mobile m, Point3D oldLocation )
		{
			if ( m_LastRadiated <= DateTime.Now )
					m_LastRadiated = DateTime.Now.AddSeconds( Utility.Random( 2 ) );
			if ( !IsDeadBondedPet && m_Mobiles[m] == null && Utility.InRange( Location, m.Location, 2 ) && !Utility.InRange( Location, oldLocation, 2 ) )
				m_Mobiles[m] = Timer.DelayCall( TimeSpan.Zero, TimeSpan.FromSeconds( 1.0 ), new TimerStateCallback( RadiationCallBack ), m );

			base.OnMovement( m, oldLocation );
		}

		public void RadiationCallBack( object state )
		{
			Mobile m = (Mobile)state;

			if ( Deleted || !Alive || !Utility.InRange( Location, m.Location, 2 ) )
			{
				((Timer)m_Mobiles[m]).Stop();
				m_Mobiles[m] = null;
				return;
			}

			if ( this != m && m.Player && m.Alive && m_LastRadiated <= DateTime.Now && Server.Spells.SpellHelper.ValidIndirectTarget( m, this ) && CanBeHarmful( m, false, false ) )
			{
	                        AOS.Damage( m, this, 0, 0, 0, 0, 0, 0, true );
		                m.Hits -= ( Utility.Random( 1, 2 ) );
		                m.Stam -= ( Utility.Random( 1, 2 ) );
		                m.Mana -= ( Utility.Random( 1, 2 ) );

                                m.FixedParticles(0x36B0, 1, 14, 0x26BB, 0x3F, 0x7, EffectLayer.Waist);
		                m.ApplyPoison( m, Poison.Regular );
                                m.PlaySound( m.Female ? 792 : 1064 );

				DoHarmful( m );
				m.RevealingAction();

				m.SendMessage( "{0} has been shatterned!", m.Name );
				m_LastRadiated = DateTime.Now.AddSeconds( Utility.Random( 5, 5 ) );
			}
		}

		public override int GetIdleSound() { return 819; } 
		public override int GetAttackSound() { return 800; } 
		public override int GetHurtSound() { return 787; } 
		public override int GetAngerSound() { return 783; } 
		public override int GetDeathSound() { return 1364; } 

		public override bool AlwaysMurderer{ get{ return true; } }
		public override Poison PoisonImmune{ get{ return Poison.Lethal; } }
		public override bool Unprovokable{ get{ return true; } }

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

		        from.RawStr -= ( Utility.Random( 1, 5 ) );

		        from.ApplyPoison( from, Poison.Regular );

			from.Say( "*flaming farts*" );
                        from.SendMessage( "Ouch! Flamed, and farted upon!" );
		        from.FixedParticles( 0x3709, 10, 30, 5052, EffectLayer.LeftFoot );
                        from.FixedParticles(0x36B0, 1, 14, 0x26BB, 0x3F, 0x7, EffectLayer.Waist);
		        from.PlaySound( from.Female ? 814 : 1088 );
                        from.PlaySound( from.Female ? 792 : 1064 );

                        World.Broadcast( 0x35, true, string.Format( "This poor innocent bunny's corpse was just then carved up by {0}. Enjoy the loot, asshole!", from.Name ) );
                        corpse.Carved = true;
			}
                }

		private DateTime m_NextAbilityTime;

		public override void OnThink()
		{
			if ( DateTime.Now >= m_NextAbilityTime )
			{
				Mobile combatant = this.Combatant;

				if ( combatant != null && combatant.Map == this.Map && combatant.InRange( this, 12 ) && IsEnemy( combatant ) && !UnderEffect( combatant ) )
				{
					m_NextAbilityTime = DateTime.Now + TimeSpan.FromSeconds( Utility.RandomMinMax( 10, 15 ) );

					if( combatant is BaseCreature )
					{
						BaseCreature bc = (BaseCreature)combatant;

						if( bc.Controlled && bc.ControlMaster != null && !bc.ControlMaster.Deleted && bc.ControlMaster.Alive )
						{
							if ( bc.ControlMaster.Map == this.Map && bc.ControlMaster.InRange( this, 12 ) && !UnderEffect( bc.ControlMaster ) )
							{
								combatant = bc.ControlMaster;
							}
						}
					}

					if( Utility.RandomDouble() < .5 )
					{
						int[][] coord = 
						{
							new int[]{-4,-6}, new int[]{4,-6}, new int[]{0,-8}, new int[]{-5,5}, new int[]{5,5}
						};

						BaseCreature rabid;

						for( int i=0; i<5; i++ )
						{
							switch( i )
							{
								case 0: rabid = new EnragedRunningPants( this ); break;
								case 1: rabid = new EnragedRunningPants( this ); break;
								case 2: rabid = new EnragedRunningPants( this ); break;
								case 3: rabid = new EnragedRunningPants( this ); break;
								default: rabid = new EnragedRunningPants( this ); break;
							}

							rabid.FocusMob = combatant;

							int x = combatant.X + coord[i][0];
							int y = combatant.Y + coord[i][1];

							/*
								Once in a while OSI's dont spawn all 5, and
								I can only attribute this to a bad spawn location
								so I will do this.
							*/

							Point3D loc = new Point3D( x, y,  combatant.Map.GetAverageZ( x, y ));
							if ( combatant.Map.CanSpawnMobile( loc ) )
							{
								rabid.MoveToWorld( loc, combatant.Map ) ;
							}
							else
							{
								rabid.Delete();
							}
						}
                                        this.Say( true, "Rejoice men! For tonight we dine in Tartarrix!" );
					}
					else
					{
						this.Say( true, "Pry apart their flesh!" );
						m_Table[combatant] = Timer.DelayCall( TimeSpan.FromSeconds( 5.0 ), TimeSpan.FromSeconds( 10.0 ), new TimerStateCallback( DoEffect ), new object[]{ combatant, 0 } );
					}
				}
			}

			base.OnThink();
		}

		private static Hashtable m_Table = new Hashtable();

		public static bool UnderEffect( Mobile m )
		{
			return m_Table.Contains( m );
		}

		public static void StopEffect( Mobile m, bool message )
		{
			Timer t = (Timer)m_Table[m];

			if ( t != null )
			{
				if ( message )
					m.PublicOverheadMessage( Network.MessageType.Emote, m.SpeechHue, true, "* The open flame begins to scatter away the wasps *" );

				t.Stop();
				m_Table.Remove( m );
			}
		}

		public void DoEffect( object state )
		{
			object[] states = (object[])state;

			Mobile m = (Mobile)states[0];
			int count = (int)states[1];

			if ( !m.Alive )
			{
				StopEffect( m, false );
			}
			else
			{
				Torch torch = m.FindItemOnLayer( Layer.TwoHanded ) as Torch;

				if ( torch != null && torch.Burning )
				{
					StopEffect( m, true );
				}
				else
				{
					if ( (count % 4) == 0 )
					{
						m.LocalOverheadMessage( Network.MessageType.Emote, m.SpeechHue, true, "* The wasps sting viciously at your flesh! *" );
						m.NonlocalOverheadMessage( Network.MessageType.Emote, m.SpeechHue, true, String.Format( "* {0} is stung viciously by asshole wasps *", m.Name ) );
					}

					m.FixedParticles( 0x91C, 10, 180, 9539, EffectLayer.Waist );
                                        m.PlaySound( m.Female ? 792 : 1064 );
					m.PlaySound( 0x00E );
					m.PlaySound( 0x1BC );

					AOS.Damage( m, this, Utility.RandomMinMax( 2, 10 ) - (Core.AOS ? 0 : 10), 100, 0, 0, 0, 0 );

					states[1] = count + 1;

					if ( !m.Alive )
						StopEffect( m, false );
				}
			}
		}

		public override void OnHarmfulSpell( Mobile from )
		{
			if ( !Controlled && ControlMaster == null )
				CurrentSpeed = BoostedSpeed;
		}

		public override void OnCombatantChange()
		{
			if ( Combatant == null && !Controlled && ControlMaster == null )
				CurrentSpeed = PassiveSpeed;
		}

		public override void OnDamagedBySpell( Mobile from )
		{
			if( from != null && from.Alive && 0.5 > Utility.RandomDouble() )
			{
				ThrowJunk( from );
			}
		}

		public override void OnGotMeleeAttack( Mobile attacker )
		{
			base.OnGotMeleeAttack( attacker );

			if( attacker != null && attacker.Alive && attacker.Weapon is BaseRanged && 0.5 > Utility.RandomDouble() )
			{
				ThrowJunk( attacker );
			}
		}

                public override void OnGaveMeleeAttack( Mobile defender )
                {
                        base.OnGaveMeleeAttack( defender );

                        if (0.5 >= Utility.RandomDouble())
		                ThrowJunk( defender );
                }

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
                        AOS.Damage( to, this, Utility.Random( 2, 5 ), 100, 0, 0, 0, 0 );
			this.PlaySound( 0x5D2 ); // throwH
		}
		#endregion

                public void PlayVictoryTheme()
                {
                      List<Mobile> list = new List<Mobile>();

                      foreach ( Mobile m in GetMobilesInRange( 12 ) )
                      {
                             if ( !CanBeHarmful ( m ) )
                             continue;

                             if ( m.Player )
                             list.Add ( m );
                      }

                      foreach ( Mobile m in list )
                      {
                          if ( m == this || !CanBeHarmful( m ) )
                          continue;

                          if ( !m.Player && !( m is BaseCreature && ( (BaseCreature)m).ControlMaster.Player) )
                          continue;

                          if ( m.Player && m.Alive )
                          {
                               m.Hits += 420;
                               m.Stam += 420;
                               m.Mana += 420;

                               m.Say( "Yee!!!!!!!!!!!!" );
                               // woohoo!
			       m.PlaySound( m.Female ? 783 : 1054 );
                               m.Send( Network.PlayMusic.GetInstance( MusicName.Victory ) );
		               m.FixedParticles( 0x3709, 10, 30, 5052, EffectLayer.LeftFoot );
                               World.Broadcast( 0x35, true, string.Format( "This poor innocent bunny was recently taken from us by {0}. Please, ransack their house when they're not looking!", m.Name ) );
                               DoHarmful( m );
                          }
                     }
                }

		public override bool OnBeforeDeath( ) //what happens before it dies
		{
		        PlayVictoryTheme();

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

		public FluffySnapperSpearThruster( Serial serial ) : base( serial )
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