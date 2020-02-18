using System;
using System.Collections;
using System.Collections.Generic;
using System.Xml;
using Server.Network;
using Server.Items;
using Server.Mobiles;
using Server.ContextMenus;

namespace Server.Regions
{
	public class IslandOfGiantsSFXRegion : LandscapeRegion
	{
	     public IslandOfGiantsSFXRegion( XmlElement xml, Map map, Region parent ) : base( xml, map, parent )
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
        	    m.SendMessage("You have entered the Island of Giants.");

                    base.OnEnter( m );
             }

             public override void OnExit( Mobile m )
             {
        	    m.SendMessage("You have left the Island of Giants.");

                    base.OnExit( m );
             }

             public override void Damage( Mobile m )
             {
                  
             base.Damage( m );

             if ( m.Alive )
             {
		   Item item = m.FindItemOnLayer( Layer.OuterTorso );

	           if ( item is GMRobe )
	           {
	                  AOS.Damage(m, 0, 0, 0, 0, 0, 0 );
                   }
	           else if ( item is GMRobeExplosion )
	           {
	                  AOS.Damage(m, 0, 0, 0, 0, 0, 0 );
                          m.PlaySound(Utility.RandomList( 0x307,0x308 ) );
                   }
	           else if ( item is GMRobeHoly )
	           {
	                  AOS.Damage(m, 0, 0, 0, 0, 0, 0 );

		          m.FixedParticles( 0x375A, 1, 30, 9966, 88, 2, EffectLayer.Head ); 
           	          m.FixedParticles( 0x37B9, 1, 30, 9502, 85, 3, EffectLayer.Head );
		          m.FixedParticles( 0x376A, 1, 31, 9961, 80, 0, EffectLayer.Waist );
           	          m.FixedParticles( 0x37C4, 1, 31, 9502, 88, 2, EffectLayer.Waist );
                   }
	           else if ( item is GMRobeTrailfire )
	           {
	                  AOS.Damage(m, 0, 0, 0, 0, 0, 0 );

		          m.FixedParticles( 0x3709, 10, 30, 5052, EffectLayer.LeftFoot );
                   }
                   else
                   {
                            // Wind
		            if ( Utility.RandomDouble() < 0.09 )
                            {
                                 m.PlaySound(Utility.RandomList( 0x014,0x15,0x016,0x5C7 ) );
	                         AOS.Damage(m, 0, 0, 0, 0, 0, 0 );
                            }

                            // Thunderstorm
		            if ( Utility.RandomDouble() < 0.06 )
                            {
                                 m.PlaySound(Utility.RandomList( 0x028,0x029,0x206 ) );
	                         AOS.Damage(m, 0, 0, 0, 0, 0, 0 );
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
			           if ( m.Map == Map.Malas )
			           {
				         int x1 = m.X + 12;
				         int y1 = m.Y + 12;
				         int z1 = Map.Malas.GetAverageZ( x1, y1 );

				         if ( Map.Malas.CanSpawnMobile( x1, y1, z1 ) )
				         {
				         BaseCreature encountera;
			                 switch ( Utility.Random( 3 ) )
			                 {
					      default:
                                              case 0: encountera = new Ettin(); break;
                                              case 1: encountera = new Ogre(); break;
                                              case 2: encountera = new Troll(); break;
			                 }
					      encountera.MoveToWorld( new Point3D( x1, y1, z1 ), Map.Malas );
				              encountera.Combatant = m;

	                                      AOS.Damage(m, 0, 0, 0, 0, 0, 0 );
				              Timer.DelayCall( TimeSpan.FromMinutes( 3.0 ), new TimerStateCallback( DeleteEncounterA ), encountera );
                                         }
                                   }
                            }

                            // Random Encounter 2
		            if ( Utility.RandomDouble() < 0.002 )
                            {
			           if ( m.Map == Map.Malas )
			           {
				         int x2 = m.X - 12;
				         int y2 = m.Y - 12;
				         int z2 = Map.Malas.GetAverageZ( x2, y2 );

				         if ( Map.Malas.CanSpawnMobile( x2, y2, z2 ) )
				         {
				         BaseCreature encountera;
			                 switch ( Utility.Random( 3 ) )
			                 {
					      default:
                                              case 0: encountera = new Ettin(); break;
                                              case 1: encountera = new Ogre(); break;
                                              case 2: encountera = new Troll(); break;
			                 }
					      encountera.MoveToWorld( new Point3D( x2, y2, z2 ), Map.Malas );
				              encountera.Combatant = m;

	                                      AOS.Damage(m, 0, 0, 0, 0, 0, 0 );
				              Timer.DelayCall( TimeSpan.FromMinutes( 3.0 ), new TimerStateCallback( DeleteEncounterA ), encountera );
                                         }
                                   }
                            }

                            // Tamable Encounter 1
		            if ( Utility.RandomDouble() < 0.002 )
                            {
			           if ( m.Map == Map.Malas )
			           {
				         int x1 = m.X + 12;
				         int y1 = m.Y + 12;
				         int z1 = Map.Malas.GetAverageZ( x1, y1 );

				         if ( Map.Malas.CanSpawnMobile( x1, y1, z1 ) )
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
					      tameable.MoveToWorld( new Point3D( x1, y1, z1 ), Map.Malas );

	                                      AOS.Damage(m, 0, 0, 0, 0, 0, 0 );
				              Timer.DelayCall( TimeSpan.FromMinutes( 2.0 ), new TimerStateCallback( DeleteTameable ), tameable );
                                         }
                                   }
                            }

                            // Tamable Encounter 2
		            if ( Utility.RandomDouble() < 0.002 )
                            {
			           if ( m.Map == Map.Malas )
			           {
				         int x2 = m.X - 12;
				         int y2 = m.Y - 12;
				         int z2 = Map.Malas.GetAverageZ( x2, y2 );

				         if ( Map.Malas.CanSpawnMobile( x2, y2, z2 ) )
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
					      tameable.MoveToWorld( new Point3D( x2, y2, z2 ), Map.Malas );

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
			Effects.PlaySound( mob.Location, mob.Map, 0x1FC );

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
			return;
                  }
		  else if ( mob != null || !mob.Deleted )
		  {
			Effects.SendLocationEffect( mob.Location, mob.Map, 0x3728, 10, 10 );
			Effects.PlaySound( mob.Location, mob.Map, 0x1FC );

			mob.Delete();
                  }
             }
     }
}

