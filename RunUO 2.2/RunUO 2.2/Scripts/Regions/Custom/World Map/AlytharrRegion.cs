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
	public class AlytharrRegion : LandscapeRegion
	{
		public AlytharrRegion( XmlElement xml, Map map, Region parent ) : base( xml, map, parent )
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
                        return TimeSpan.FromSeconds(1);
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

                            // Random Encounter 1
		            if ( Utility.RandomDouble() < 0.003 )
                            {
			           if ( m.Map == Map.Malas )
			           {
				         int x1 = m.X + 8;
				         int y1 = m.Y + 8;
				         int z1 = Map.Malas.GetAverageZ( x1, y1 );

				         if ( Map.Malas.CanSpawnMobile( x1, y1, z1 ) )
				         {
				         BaseCreature encountera;
			                 switch ( Utility.Random( 11 ) )
			                 {
					      default:
                                              case 0: encountera = new AlytharrForestHart(); break;
                                              case 1: encountera = new AlytharrGrassSnake(); break;
                                              case 2: encountera = new BlackLizard(); break;
                                              case 3: encountera = new Centaur(); break;
                                              case 4: encountera = new HillToad(); break;
                                              case 5: encountera = new MinorBloodElemental(); break;
                                              case 6: encountera = new Pixie(); break;
                                              case 7: encountera = new WyvernYoungling(); break;
                                              case 8: encountera = new BlackBear(); break;
                                              case 9: encountera = new Crane(); break;
                                              case 10: encountera = new Panther(); break;
			                 }
					      encountera.MoveToWorld( new Point3D( x1, y1, z1 ), Map.Malas );

	                                      AOS.Damage(m, 0, 0, 0, 0, 0, 0 );
				              Timer.DelayCall( TimeSpan.FromMinutes( 10.0 ), new TimerStateCallback( DeleteEncounterA ), encountera );
                                         }
                                   }
                            }

                            // Random Encounter 2
		            if ( Utility.RandomDouble() < 0.003 )
                            {
			           if ( m.Map == Map.Malas )
			           {
				         int x2 = m.X - 8;
				         int y2 = m.Y - 8;
				         int z2 = Map.Malas.GetAverageZ( x2, y2 );

				         if ( Map.Malas.CanSpawnMobile( x2, y2, z2 ) )
				         {
				         BaseCreature encountera;
			                 switch ( Utility.Random( 11 ) )
			                 {
					      default:
                                              case 0: encountera = new AlytharrForestHart(); break;
                                              case 1: encountera = new AlytharrGrassSnake(); break;
                                              case 2: encountera = new BlackLizard(); break;
                                              case 3: encountera = new Centaur(); break;
                                              case 4: encountera = new HillToad(); break;
                                              case 5: encountera = new MinorBloodElemental(); break;
                                              case 6: encountera = new Pixie(); break;
                                              case 7: encountera = new WyvernYoungling(); break;
                                              case 8: encountera = new BlackBear(); break;
                                              case 9: encountera = new Crane(); break;
                                              case 10: encountera = new Panther(); break;
			                 }
					      encountera.MoveToWorld( new Point3D( x2, y2, z2 ), Map.Malas );

	                                      AOS.Damage(m, 0, 0, 0, 0, 0, 0 );
				              Timer.DelayCall( TimeSpan.FromMinutes( 10.0 ), new TimerStateCallback( DeleteEncounterA ), encountera );
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

                                               if ( m.Skills.Tracking.Base > 9.9 )
                                               {

			                       switch ( Utility.Random( 2 ) )
			                       {
					            default:
                                                    case 0: treasurechest = new AlytharrRegionTreasureChest1(); break;
                                                    case 1: treasurechest = new AlytharrRegionTreasureChest1(); break;
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

                                               if ( m.Skills.Tracking.Base > 9.9 )
                                               {

			                       switch ( Utility.Random( 2 ) )
			                       {
					            default:
                                                    case 0: treasurechest = new AlytharrRegionTreasureChest1(); break;
                                                    case 1: treasurechest = new AlytharrRegionTreasureChest1(); break;
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

	        private void DeleteEncounterA( object encountera )
	        {
		     BaseCreature mob = (BaseCreature)encountera;
	             Map map = mob.Map;
		     Mobile c = encountera as Mobile;

		     if ( mob.Controlled )
		     {
			   return;
                     }
		     if ( mob != null || !mob.Deleted )
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
