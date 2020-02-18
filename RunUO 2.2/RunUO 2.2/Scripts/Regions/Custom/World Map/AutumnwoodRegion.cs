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
	public class AutumnwoodRegion : LandscapeRegion
	{
		public AutumnwoodRegion( XmlElement xml, Map map, Region parent ) : base( xml, map, parent )
		{
		}

		public override bool AllowHousing( Mobile from, Point3D p )
		{
			return true;
		}

                public override TimeSpan DamageInterval
                {
                    get
                    {
                        return TimeSpan.FromSeconds(5);
                    }
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
                        else
                        {
                            // Forest noises
		            if ( Utility.RandomDouble() < 0.008 )
                            {
                                 m.PlaySound(Utility.RandomList( 0x000,0x001,0x002 ) );
	                         AOS.Damage(m, 0, 0, 0, 0, 0, 0 );
                            }

                            // Bird chirps
		            if ( Utility.RandomDouble() < 0.002 )
                            {
                                 m.PlaySound(Utility.RandomList( 0x094,0x095,0x096,0x097,0x0D1,0x0D2 ) );
	                         AOS.Damage(m, 0, 0, 0, 0, 0, 0 );
                            }

                            // Cricket noises
		            if ( Utility.RandomDouble() < 0.003 )
                            {
                                 m.PlaySound(Utility.RandomList( 0x00A,0x00B ) );
	                         AOS.Damage(m, 0, 0, 0, 0, 0, 0 );
                            }

                            // Turdy Encounter 1
		            if ( Utility.RandomDouble() < 0.002 )
                            {
			           if ( m.Map == Map.Malas )
			           {
				         int x1 = m.X + 8;
				         int y1 = m.Y + 8;
				         int z1 = Map.Malas.GetAverageZ( x1, y1 );

				         if ( Map.Malas.CanSpawnMobile( x1, y1, z1 ) )
				         {
				         BaseCreature turdyencounter;
			                 switch ( Utility.Random( 2 ) )
			                 {
					      default:
                                              case 0: turdyencounter = new Turdy(); break;
                                              case 1: turdyencounter = new Turdy(); break;
			                 }
					      turdyencounter.MoveToWorld( new Point3D( x1, y1, z1 ), Map.Malas );

				              turdyencounter.Combatant = m;
	                                      AOS.Damage(m, 0, 0, 0, 0, 0, 0 );
				              Timer.DelayCall( TimeSpan.FromMinutes( 10.0 ), new TimerStateCallback( DeleteTurdyEncounter ), turdyencounter );
                                         }
                                   }
                            }

                            // Turdy Encounter 2
		            if ( Utility.RandomDouble() < 0.002 )
                            {
			           if ( m.Map == Map.Malas )
			           {
				         int x2 = m.X - 8;
				         int y2 = m.Y - 8;
				         int z2 = Map.Malas.GetAverageZ( x2, y2 );

				         if ( Map.Malas.CanSpawnMobile( x2, y2, z2 ) )
				         {
				         BaseCreature turdyencounter;
			                 switch ( Utility.Random( 2 ) )
			                 {
					      default:
                                              case 0: turdyencounter = new Turdy(); break;
                                              case 1: turdyencounter = new Turdy(); break;
			                 }
					      turdyencounter.MoveToWorld( new Point3D( x2, y2, z2 ), Map.Malas );

				              turdyencounter.Combatant = m;
	                                      AOS.Damage(m, 0, 0, 0, 0, 0, 0 );
				              Timer.DelayCall( TimeSpan.FromMinutes( 10.0 ), new TimerStateCallback( DeleteTurdyEncounter ), turdyencounter );
                                         }
                                   }
                            }

                            // Random Encounter 1
		            if ( Utility.RandomDouble() < 0.0002 )
                            {
			           if ( m.Map == Map.Malas )
			           {
				         int x1 = m.X + 8;
				         int y1 = m.Y + 8;
				         int z1 = Map.Malas.GetAverageZ( x1, y1 );

				         if ( Map.Malas.CanSpawnMobile( x1, y1, z1 ) )
				         {
				         BaseCreature encounterb;
			                 switch ( Utility.Random( 2 ) )
			                 {
					      default:
                                              case 0: encounterb = new AutumnwoodAdventurer(); break;
                                              case 1: encounterb = new AutumnwoodAdventurer(); break;
			                 }
					      encounterb.MoveToWorld( new Point3D( x1, y1, z1 ), Map.Malas );

	                                      AOS.Damage(m, 0, 0, 0, 0, 0, 0 );
				              Timer.DelayCall( TimeSpan.FromMinutes( 10.0 ), new TimerStateCallback( DeleteEncounterB ), encounterb );
                                         }
                                   }
                            }

                            // Random Encounter 2
		            if ( Utility.RandomDouble() < 0.0002 )
                            {
			           if ( m.Map == Map.Malas )
			           {
				         int x2 = m.X - 8;
				         int y2 = m.Y - 8;
				         int z2 = Map.Malas.GetAverageZ( x2, y2 );

				         if ( Map.Malas.CanSpawnMobile( x2, y2, z2 ) )
				         {
				         BaseCreature encounterb;
			                 switch ( Utility.Random( 2 ) )
			                 {
					      default:
                                              case 0: encounterb = new AutumnwoodAdventurer(); break;
                                              case 1: encounterb = new AutumnwoodAdventurer(); break;
			                 }
					      encounterb.MoveToWorld( new Point3D( x2, y2, z2 ), Map.Malas );

	                                      AOS.Damage(m, 0, 0, 0, 0, 0, 0 );
				              Timer.DelayCall( TimeSpan.FromMinutes( 10.0 ), new TimerStateCallback( DeleteEncounterB ), encounterb );
                                         }
                                   }
                            }

                            // Tamable Encounter 1
		            if ( Utility.RandomDouble() < 0.002 )
                            {
			           if ( m.Map == Map.Malas )
			           {
				         int x1 = m.X + 8;
				         int y1 = m.Y + 8;
				         int z1 = Map.Malas.GetAverageZ( x1, y1 );

				         if ( Map.Malas.CanSpawnMobile( x1, y1, z1 ) )
				         {
				         BaseCreature tameable;
			                 switch ( Utility.Random( 23 ) )
			                 {
					      default:
                                              case 0: tameable = new Bird(); break;
                                              case 1: tameable = new Boar(); break;
                                              case 2: tameable = new BlackBear(); break;
                                              case 3: tameable = new Bull(); break;
                                              case 4: tameable = new Chicken(); break;
                                              case 5: tameable = new Cow(); break;
                                              case 6: tameable = new ForestBat(); break;
                                              case 7: tameable = new Goat(); break;
                                              case 8: tameable = new GreatHart(); break;
                                              case 9: tameable = new GreenSlime(); break;
                                              case 10: tameable = new GreySquirrel(); break;
                                              case 11: tameable = new GreyWolfPup(); break;
                                              case 12: tameable = new Hind(); break;
                                              case 13: tameable = new Horse(); break;
                                              case 14: tameable = new LargeFrog(); break;
                                              case 15: tameable = new Ogumo(); break;
                                              case 16: tameable = new Panther(); break;
                                              case 17: tameable = new Pig(); break;
                                              case 18: tameable = new Rabbit(); break;
                                              case 19: tameable = new Rat(); break;
                                              case 20: tameable = new RhinoBeetle(); break;
                                              case 21: tameable = new RunningPants(); break;
                                              case 22: tameable = new Sheep(); break;
			                 }
					      tameable.MoveToWorld( new Point3D( x1, y1, z1 ), Map.Malas );

	                                      AOS.Damage(m, 0, 0, 0, 0, 0, 0 );
				              Timer.DelayCall( TimeSpan.FromMinutes( 10.0 ), new TimerStateCallback( DeleteTameable ), tameable );
                                         }
                                   }
                            }

                            // Tamable Encounter 2
		            if ( Utility.RandomDouble() < 0.002 )
                            {
			           if ( m.Map == Map.Malas )
			           {
				         int x2 = m.X - 8;
				         int y2 = m.Y - 8;
				         int z2 = Map.Malas.GetAverageZ( x2, y2 );

				         if ( Map.Malas.CanSpawnMobile( x2, y2, z2 ) )
				         {
				         BaseCreature tameable;
			                 switch ( Utility.Random( 23 ) )
			                 {
					      default:
                                              case 0: tameable = new Bird(); break;
                                              case 1: tameable = new Boar(); break;
                                              case 2: tameable = new BlackBear(); break;
                                              case 3: tameable = new Bull(); break;
                                              case 4: tameable = new Chicken(); break;
                                              case 5: tameable = new Cow(); break;
                                              case 6: tameable = new ForestBat(); break;
                                              case 7: tameable = new Goat(); break;
                                              case 8: tameable = new GreatHart(); break;
                                              case 9: tameable = new GreenSlime(); break;
                                              case 10: tameable = new GreySquirrel(); break;
                                              case 11: tameable = new GreyWolfPup(); break;
                                              case 12: tameable = new Hind(); break;
                                              case 13: tameable = new Horse(); break;
                                              case 14: tameable = new LargeFrog(); break;
                                              case 15: tameable = new Ogumo(); break;
                                              case 16: tameable = new Panther(); break;
                                              case 17: tameable = new Pig(); break;
                                              case 18: tameable = new Rabbit(); break;
                                              case 19: tameable = new Rat(); break;
                                              case 20: tameable = new RhinoBeetle(); break;
                                              case 21: tameable = new RunningPants(); break;
                                              case 22: tameable = new Sheep(); break;
			                 }
					      tameable.MoveToWorld( new Point3D( x2, y2, z2 ), Map.Malas );

	                                      AOS.Damage(m, 0, 0, 0, 0, 0, 0 );
				              Timer.DelayCall( TimeSpan.FromMinutes( 10.0 ), new TimerStateCallback( DeleteTameable ), tameable );
                                         }
                                   }
                            }

                            // Random Treasure Chest 1
		            if ( Utility.RandomDouble() < 0.0005 )
                            {
			           if ( m.Map == Map.Malas )
			           {
				         int x1 = m.X + 12;
				         int y1 = m.Y + 12;
				         int z1 = Map.Malas.GetAverageZ( x1, y1 );

				         if ( Map.Malas.CanSpawnMobile( x1, y1, z1 ) )
				         {
				               BaseContainer treasurechest;

                                               if ( m.Skills.Tracking.Base > 14.9 )
                                               {

			                       switch ( Utility.Random( 2 ) )
			                       {
					            default:
                                                    case 0: treasurechest = new AutumnwoodTreasureChest1(); break;
                                                    case 1: treasurechest = new AutumnwoodTreasureChest1(); break;
			                       }
					            treasurechest.MoveToWorld( new Point3D( x1, y1, z1 ), Map.Malas );

	                                            AOS.Damage(m, 0, 0, 0, 0, 0, 0 );
				                    Timer.DelayCall( TimeSpan.FromMinutes( 5.0 ), new TimerStateCallback( DeleteTreasureChest ), treasurechest );
                                               }
                                         }
                                   }
                            }

                            // Random Treasure Chest 2
		            if ( Utility.RandomDouble() < 0.0005 )
                            {
			           if ( m.Map == Map.Malas )
			           {
				         int x2 = m.X - 12;
				         int y2 = m.Y - 12;
				         int z2 = Map.Malas.GetAverageZ( x2, y2 );

				         if ( Map.Malas.CanSpawnMobile( x2, y2, z2 ) )
				         {
				               BaseContainer treasurechest;

                                               if ( m.Skills.Tracking.Base > 14.9 )
                                               {

			                       switch ( Utility.Random( 2 ) )
			                       {
					            default:
                                                    case 0: treasurechest = new AutumnwoodTreasureChest1(); break;
                                                    case 1: treasurechest = new AutumnwoodTreasureChest1(); break;
			                       }
					            treasurechest.MoveToWorld( new Point3D( x2, y2, z2 ), Map.Malas );

	                                            AOS.Damage(m, 0, 0, 0, 0, 0, 0 );
				                    Timer.DelayCall( TimeSpan.FromMinutes( 5.0 ), new TimerStateCallback( DeleteTreasureChest ), treasurechest );
                                               }
                                         }
                                   }
                            }
                        }
                   }
                }

	        private void DeleteTurdyEncounter( object turdyencounter )
	        {
		     BaseCreature mob = (BaseCreature)turdyencounter;
	             Map map = mob.Map;
		     Mobile c = turdyencounter as Mobile;

		     if ( mob != null || !mob.Deleted )
		     {
			   Effects.SendLocationEffect( mob.Location, mob.Map, 0x3728, 10, 10 );
			   Effects.PlaySound( mob.Location, mob.Map, 0x1FC );

			   mob.Delete();
                     }
                }

	        private void DeleteEncounterB( object encounterb )
	        {
		     BaseCreature mob = (BaseCreature)encounterb;
	             Map map = mob.Map;
		     Mobile c = encounterb as Mobile;

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

	        private void DeleteTreasureChest( object treasurechest )
	        {
		     BaseContainer container = (BaseContainer)treasurechest;
	             Map map = container.Map;
		     Container c = treasurechest as Container;

		     if ( container != null || !container.Deleted )
		     {
			  Effects.SendLocationEffect( container.Location, container.Map, 0x3728, 10, 10 );
			  Effects.PlaySound( container.Location, container.Map, 0x1FC );

			  container.Delete();
                     }
                }
       }
}
