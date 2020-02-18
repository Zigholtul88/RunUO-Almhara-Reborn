using System;
using System.Collections;
using System.Collections.Generic;
using System.Xml;
using Server.ContextMenus;
using Server.Items;
using Server.Mobiles;
using Server.Network;
using Server.Spells;
using Server.Spells.First;
using Server.Spells.Third;
using Server.Spells.Fourth;
using Server.Spells.Sixth;
using Server.Spells.Seventh;
using Server.Targeting;
using AMT = Server.Items.ArmorMaterialType;

namespace Server.Regions
{
     public class TestingGroundsRegion : LandscapeRegion
     {
	     public TestingGroundsRegion( XmlElement xml, Map map, Region parent ) : base( xml, map, parent )
	     {
	     }

	     public override void AlterLightLevel( Mobile m, ref int global, ref int personal )
	     {
		    global = LightCycle.DungeonLevel;
	     }

             public override TimeSpan DamageInterval
             {
                 get
                 {
                     return TimeSpan.FromSeconds(5);
                 }
             }

             public override void OnEnter( Mobile m )
             {
        	    m.SendMessage("You have entered Poultry Paradise.");

                    base.OnEnter( m );
             }

             public override void OnExit( Mobile m )
             {
        	    m.SendMessage("You have left Poultry Paradise.");

                    base.OnExit( m );
             }

	     public virtual void AlterSpellDamageFrom( Mobile from, ref int damage, ISpell s )
	     {
		    if ( from is PlayerMobile )
	            {
			   PlayerMobile p_PlayerMobile = from as PlayerMobile;

		           if ( s is MagicArrowSpell )
		           {
                                damage += 25;
                           }
		           else if ( ( s is FireballSpell || s is FireFieldSpell || s is ExplosionSpell ) )
		           {
                                damage += 50;
                           }
		           else if ( s is FlameStrikeSpell )
		           {
                                damage += 75;
                           }
		           else if ( s is MeteorSwarmSpell )
		           {
                                damage *= 2;
                           }
                    }
             }

             public override void Damage( Mobile m )
             {
                  
             base.Damage(m );

             if (m.Alive)
             {
		  Item item = m.FindItemOnLayer( Layer.OuterTorso );

	          if ( item is GMRobe )
	          {
	                    AOS.Damage(m, 0, 0, 0, 0, 0, 0 );
                  }
                  else
                  {
                            // Bank Music
		            if ( Utility.RandomDouble() < 0.001 )
                            {
                                 m.Send( Network.PlayMusic.GetInstance( MusicName.Stones2 ) );
	                         AOS.Damage(m, 0, 0, 0, 0, 0, 0 );
                            }

                            // Flamestrike
		            if ( Utility.RandomDouble() < 0.01 )
                            {
		                 m.Stam -= 20;
		                 m.Mana -= 25;
		                 m.FixedParticles( 0x3709, 10, 30, 5052, EffectLayer.LeftFoot );
		                 m.PlaySound( 0x208 );
		                 m.PlaySound( m.Female ? 814 : 1088 );
		                 m.Say( "*ahhhh!*" );
                                 AOS.Damage(m, Utility.Random(15, 25), 0, 100, 0, 0, 0);
                            }

                            // Forest Music
		            if ( Utility.RandomDouble() < 0.001 )
                            {
                                 m.Send( Network.PlayMusic.GetInstance( MusicName.Linelle ) );
	                         AOS.Damage(m, 0, 0, 0, 0, 0, 0 );
                            }

                            // Greater Heal
		            if ( Utility.RandomDouble() < 0.01 )
                            {
		                 m.Hits += ( Utility.Random( 250, 300 ) ); 
		                 m.Stam += ( Utility.Random( 250, 300 ) );
		                 m.Mana += ( Utility.Random( 250, 300 ) ); 
		                 m.FixedParticles( 0x375A, 1, 30, 9966, 88, 2, EffectLayer.Head ); 
           	                 m.FixedParticles( 0x37B9, 1, 30, 9502, 85, 3, EffectLayer.Head );
		                 m.FixedParticles( 0x376A, 1, 31, 9961, 80, 0, EffectLayer.Waist );
           	                 m.FixedParticles( 0x37C4, 1, 31, 9502, 88, 2, EffectLayer.Waist );
				 m.PlaySound( 0x202 );
	                         AOS.Damage(m, 0, 0, 0, 0, 0, 0 );
                            }

                            // Ice Blast
		            if ( Utility.RandomDouble() < 0.01 )
                            {
		                 m.Stam -= 10;
		                 m.Mana -= 20;
		                 m.FixedParticles( 0x374A, 10, 30, 5013, 1153, 2, EffectLayer.Waist );
		                 m.PlaySound( 0x0FC );
                                 AOS.Damage(m, Utility.Random(15, 25), 0, 0, 100, 0, 0);
                            }

                            // Lightning Strike
		            if ( Utility.RandomDouble() < 0.01 )
                            {
                                 m.PlaySound(Utility.RandomList( 0x5CE ) );
		                 m.BoltEffect( 0x480 );
                                 AOS.Damage(m, Utility.RandomMinMax(12, 35), 0, 0, 0, 0, 100);
                            }

                            // Random Encounter 1
		            if ( Utility.RandomDouble() < 0.002 )
                            {
			           if ( m.Map == Map.Tokuno )
			           {
				         int x1 = m.X + 12;
				         int y1 = m.Y + 12;
				         int z1 = Map.Tokuno.GetAverageZ( x1, y1 );

				         if ( Map.Tokuno.CanSpawnMobile( x1, y1, z1 ) )
				         {
				         BaseCreature encountera;
			                 switch ( Utility.Random( 3 ) )
			                 {
					      default:
                                              case 0: encountera = new RunningPants(); break;
                                              case 1: encountera = new RunningPants(); break;
                                              case 2: encountera = new RunningPants(); break;
			                 }
					      encountera.MoveToWorld( new Point3D( x1, y1, z1 ), Map.Tokuno );
				              encountera.Combatant = m;

				              IceFieldIceFlame ice = new IceFieldIceFlame();
				              ice.MoveToWorld( new Point3D( encountera.X +5, encountera.Y, encountera.Z  ), encountera.Map );
				              m.PlaySound( 0x208 );


				              IceFieldIceFlame icea = new IceFieldIceFlame();
				              icea.MoveToWorld( new Point3D( encountera.X +5, encountera.Y +5, encountera.Z  ), encountera.Map );
				              m.PlaySound( 0x208 );

				              IceFieldIceFlame iceb = new IceFieldIceFlame();
				              iceb.MoveToWorld( new Point3D( encountera.X +5, encountera.Y -5, encountera.Z  ), encountera.Map );
				              m.PlaySound( 0x208 );

				              IceFieldIceFlame icec = new IceFieldIceFlame();
				              icec.MoveToWorld( new Point3D( encountera.X, encountera.Y +5, encountera.Z  ), encountera.Map );
				              m.PlaySound( 0x208 );

				              IceFieldIceFlame iced = new IceFieldIceFlame();
				              iced.MoveToWorld( new Point3D( encountera.X, encountera.Y -5, encountera.Z  ), encountera.Map );
				              m.PlaySound( 0x208 );

				              IceFieldIceFlame icee = new IceFieldIceFlame();
				              icee.MoveToWorld( new Point3D( encountera.X -5, encountera.Y, encountera.Z  ), encountera.Map );
				              m.PlaySound( 0x208 );

				              IceFieldIceFlame icef = new IceFieldIceFlame();
				              icef.MoveToWorld( new Point3D( encountera.X -5, encountera.Y -5, encountera.Z  ), encountera.Map );
				              m.PlaySound( 0x208 );

				              IceFieldIceFlame iceg = new IceFieldIceFlame();
				              iceg.MoveToWorld( new Point3D( encountera.X -5, encountera.Y +5, encountera.Z  ), encountera.Map );
				              m.PlaySound( 0x208 );

				              IceFieldIceFlame iceh = new IceFieldIceFlame();
				              iceh.ItemID = 0x8e1;
				              iceh.MoveToWorld( new Point3D( encountera.X, encountera.Y, encountera.Z +19 ), encountera.Map );
				              m.PlaySound( 0x208 );

	                                      AOS.Damage(m, 0, 0, 0, 0, 0, 0 );
				              Timer.DelayCall( TimeSpan.FromMinutes( 3.0 ), new TimerStateCallback( DeleteEncounterA ), encountera );
                                         }
                                   }
                            }

                            // Random Encounter 2
		            if ( Utility.RandomDouble() < 0.002 )
                            {
			           if ( m.Map == Map.Tokuno )
			           {
				         int x2 = m.X - 12;
				         int y2 = m.Y - 12;
				         int z2 = Map.Tokuno.GetAverageZ( x2, y2 );

				         if ( Map.Tokuno.CanSpawnMobile( x2, y2, z2 ) )
				         {
				         BaseCreature encountera;
			                 switch ( Utility.Random( 3 ) )
			                 {
					      default:
                                              case 0: encountera = new RunningPants(); break;
                                              case 1: encountera = new RunningPants(); break;
                                              case 2: encountera = new RunningPants(); break;
			                 }
					      encountera.MoveToWorld( new Point3D( x2, y2, z2 ), Map.Tokuno );
				              encountera.Combatant = m;

				              IceFieldIceFlame ice = new IceFieldIceFlame();
				              ice.MoveToWorld( new Point3D( encountera.X +5, encountera.Y, encountera.Z  ), encountera.Map );
				              m.PlaySound( 0x208 );


				              IceFieldIceFlame icea = new IceFieldIceFlame();
				              icea.MoveToWorld( new Point3D( encountera.X +5, encountera.Y +5, encountera.Z  ), encountera.Map );
				              m.PlaySound( 0x208 );

				              IceFieldIceFlame iceb = new IceFieldIceFlame();
				              iceb.MoveToWorld( new Point3D( encountera.X +5, encountera.Y -5, encountera.Z  ), encountera.Map );
				              m.PlaySound( 0x208 );

				              IceFieldIceFlame icec = new IceFieldIceFlame();
				              icec.MoveToWorld( new Point3D( encountera.X, encountera.Y +5, encountera.Z  ), encountera.Map );
				              m.PlaySound( 0x208 );

				              IceFieldIceFlame iced = new IceFieldIceFlame();
				              iced.MoveToWorld( new Point3D( encountera.X, encountera.Y -5, encountera.Z  ), encountera.Map );
				              m.PlaySound( 0x208 );

				              IceFieldIceFlame icee = new IceFieldIceFlame();
				              icee.MoveToWorld( new Point3D( encountera.X -5, encountera.Y, encountera.Z  ), encountera.Map );
				              m.PlaySound( 0x208 );

				              IceFieldIceFlame icef = new IceFieldIceFlame();
				              icef.MoveToWorld( new Point3D( encountera.X -5, encountera.Y -5, encountera.Z  ), encountera.Map );
				              m.PlaySound( 0x208 );

				              IceFieldIceFlame iceg = new IceFieldIceFlame();
				              iceg.MoveToWorld( new Point3D( encountera.X -5, encountera.Y +5, encountera.Z  ), encountera.Map );
				              m.PlaySound( 0x208 );

				              IceFieldIceFlame iceh = new IceFieldIceFlame();
				              iceh.ItemID = 0x8e1;
				              iceh.MoveToWorld( new Point3D( encountera.X, encountera.Y, encountera.Z +19 ), encountera.Map );
				              m.PlaySound( 0x208 );

	                                      AOS.Damage(m, 0, 0, 0, 0, 0, 0 );
				              Timer.DelayCall( TimeSpan.FromMinutes( 3.0 ), new TimerStateCallback( DeleteEncounterA ), encountera );
                                         }
                                   }
                            }

                            // Tamable Encounter 1
		            if ( Utility.RandomDouble() < 0.002 )
                            {
			           if ( m.Map == Map.Tokuno )
			           {
				         int x1 = m.X + 12;
				         int y1 = m.Y + 12;
				         int z1 = Map.Tokuno.GetAverageZ( x1, y1 );

				         if ( Map.Tokuno.CanSpawnMobile( x1, y1, z1 ) )
				         {
				         BaseCreature tameable;
			                 switch ( Utility.Random( 5 ) )
			                 {
					      default:
                                              case 0: tameable = new Bird(); break;
                                              case 1: tameable = new BlackBear(); break;
                                              case 2: tameable = new DireWolf(); break;
                                              case 3: tameable = new Goat(); break;
                                              case 4: tameable = new Horse(); break;
			                 }
					      tameable.MoveToWorld( new Point3D( x1, y1, z1 ), Map.Tokuno );

	                                      AOS.Damage(m, 0, 0, 0, 0, 0, 0 );
				              Timer.DelayCall( TimeSpan.FromMinutes( 2.0 ), new TimerStateCallback( DeleteTameable ), tameable );
                                         }
                                   }
                            }

                            // Tamable Encounter 2
		            if ( Utility.RandomDouble() < 0.002 )
                            {
			           if ( m.Map == Map.Tokuno )
			           {
				         int x2 = m.X - 12;
				         int y2 = m.Y - 12;
				         int z2 = Map.Tokuno.GetAverageZ( x2, y2 );

				         if ( Map.Tokuno.CanSpawnMobile( x2, y2, z2 ) )
				         {
				         BaseCreature tameable;
			                 switch ( Utility.Random( 5 ) )
			                 {
					      default:
                                              case 0: tameable = new Bird(); break;
                                              case 1: tameable = new BlackBear(); break;
                                              case 2: tameable = new DireWolf(); break;
                                              case 3: tameable = new Goat(); break;
                                              case 4: tameable = new Horse(); break;
			                 }
					      tameable.MoveToWorld( new Point3D( x2, y2, z2 ), Map.Tokuno );

	                                      AOS.Damage(m, 0, 0, 0, 0, 0, 0 );
				              Timer.DelayCall( TimeSpan.FromMinutes( 2.0 ), new TimerStateCallback( DeleteTameable ), tameable );
                                         }
                                   }
                            }
                   }
                }
             }

	     private void DeleteEncounterA( object encountera )
	     {
		  BaseCreature mob = (BaseCreature)encountera;
	          Map map = mob.Map;
		  Mobile c = encountera as Mobile;

		  if ( mob != null || !mob.Deleted )
		  {
			Effects.SendLocationEffect( mob.Location, mob.Map, 0x3728, 10, 10 );
			Effects.PlaySound( mob.Location, mob.Map, 1344 );

			mob.Delete();
                  }
             }

	     private void DeleteTameable( object tamable )
	     {
		  BaseCreature mob = (BaseCreature)tamable;
	          Map map = mob.Map;
		  Mobile c = tamable as Mobile;

		  if ( mob.Controlled )
		  {
                  }
		  if ( mob != null || !mob.Deleted )
		  {
			Effects.SendLocationEffect( mob.Location, mob.Map, 0x3728, 10, 10 );
			Effects.PlaySound( mob.Location, mob.Map, 0x1FC );

			mob.Delete();
                  }
             }
     }
}

