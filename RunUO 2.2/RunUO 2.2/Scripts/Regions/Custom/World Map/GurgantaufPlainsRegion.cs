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
	public class GurgantaufPlainsRegion : LandscapeRegion
	{
		public GurgantaufPlainsRegion( XmlElement xml, Map map, Region parent ) : base( xml, map, parent )
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
                            // Wind
		            if ( Utility.RandomDouble() < 0.00002 )
                            {
                                 m.PlaySound(Utility.RandomList( 0x014,0x15,0x016,0x5C7 ) );
	                         AOS.Damage(m, 0, 0, 0, 0, 0, 0 );
                            }

                            // Forest noises
		            if ( Utility.RandomDouble() < 0.00002 )
                            {
                                 m.PlaySound(Utility.RandomList( 0x000,0x001,0x002 ) );
	                         AOS.Damage(m, 0, 0, 0, 0, 0, 0 );
                            }

                            // Bird chirps
		            if ( Utility.RandomDouble() < 0.00002 )
                            {
                                 m.PlaySound(Utility.RandomList( 0x094,0x095,0x096,0x097,0x0D1,0x0D2 ) );
	                         AOS.Damage(m, 0, 0, 0, 0, 0, 0 );
                            }

                            // Cricket noises
		            if ( Utility.RandomDouble() < 0.00002 )
                            {
                                 m.PlaySound(Utility.RandomList( 0x00A,0x00B ) );
	                         AOS.Damage(m, 0, 0, 0, 0, 0, 0 );
                            }

                            // Random Encounter 1
		            if ( Utility.RandomDouble() < 0.00001 )
                            {
			           if ( m.Map == Map.Felucca )
			           {
				         int x1 = m.X + 12;
				         int y1 = m.Y + 12;
				         int z1 = Map.Felucca.GetAverageZ( x1, y1 );

				         if ( Map.Felucca.CanSpawnMobile( x1, y1, z1 ) )
				         {
				         BaseCreature randomencounter;
			                 switch ( Utility.Random( 2 ) )
			                 {
					      default:
                                              case 0: randomencounter = new AnansirochAdventurer(); break;
                                              case 1: randomencounter = new AnansirochAdventurer(); break;
			                 }
					      randomencounter.MoveToWorld( new Point3D( x1, y1, z1 ), Map.Felucca );

	                                      AOS.Damage(m, 0, 0, 0, 0, 0, 0 );
				              Timer.DelayCall( TimeSpan.FromMinutes( 20.0 ), new TimerStateCallback( DeleteRandomEncounter ), randomencounter );
                                         }
                                   }
                            }

                            // Random Encounter 2
		            if ( Utility.RandomDouble() < 0.00001 )
                            {
			           if ( m.Map == Map.Felucca )
			           {
				         int x2 = m.X - 12;
				         int y2 = m.Y - 12;
				         int z2 = Map.Felucca.GetAverageZ( x2, y2 );

				         if ( Map.Felucca.CanSpawnMobile( x2, y2, z2 ) )
				         {
				         BaseCreature randomencounter;
			                 switch ( Utility.Random( 2 ) )
			                 {
					      default:
                                              case 0: randomencounter = new AnansirochAdventurer(); break;
                                              case 1: randomencounter = new AnansirochAdventurer(); break;
			                 }
					      randomencounter.MoveToWorld( new Point3D( x2, y2, z2 ), Map.Felucca );

	                                      AOS.Damage(m, 0, 0, 0, 0, 0, 0 );
				              Timer.DelayCall( TimeSpan.FromMinutes( 20.0 ), new TimerStateCallback( DeleteRandomEncounter ), randomencounter );
                                         }
                                   }
                            }

                            // Random Encounter 3
		            if ( Utility.RandomDouble() < 0.00001 )
                            {
			           if ( m.Map == Map.Felucca )
			           {
				         int x1 = m.X + 12;
				         int y1 = m.Y + 12;
				         int z1 = Map.Felucca.GetAverageZ( x1, y1 );

				         if ( Map.Felucca.CanSpawnMobile( x1, y1, z1 ) )
				         {
				         BaseCreature encountera;
			                 switch ( Utility.Random( 7 ) )
			                 {
					      default:
                                              case 0: encountera = new DewSheerie(); break;
                                              case 1: encountera = new FaerieHorse(); break;
                                              case 2: encountera = new FogPhantom(); break;
                                              case 3: encountera = new HeadlessBomber(); break;
                                              case 4: encountera = new Parthanan(); break;
                                              case 5: encountera = new PrimroseSprite(); break;
                                              case 6: encountera = new VillainousBandit(); break;
			                 }
					      encountera.MoveToWorld( new Point3D( x1, y1, z1 ), Map.Felucca );

	                                      AOS.Damage(m, 0, 0, 0, 0, 0, 0 );
				              Timer.DelayCall( TimeSpan.FromMinutes( 10.0 ), new TimerStateCallback( DeleteEncounterA ), encountera );
                                         }
                                   }
                            }

                            // Random Encounter 4
		            if ( Utility.RandomDouble() < 0.00001 )
                            {
			           if ( m.Map == Map.Felucca )
			           {
				         int x2 = m.X - 12;
				         int y2 = m.Y - 12;
				         int z2 = Map.Felucca.GetAverageZ( x2, y2 );

				         if ( Map.Felucca.CanSpawnMobile( x2, y2, z2 ) )
				         {
				         BaseCreature encountera;
			                 switch ( Utility.Random( 7 ) )
			                 {
					      default:
                                              case 0: encountera = new DewSheerie(); break;
                                              case 1: encountera = new FaerieHorse(); break;
                                              case 2: encountera = new FogPhantom(); break;
                                              case 3: encountera = new HeadlessBomber(); break;
                                              case 4: encountera = new Parthanan(); break;
                                              case 5: encountera = new PrimroseSprite(); break;
                                              case 6: encountera = new VillainousBandit(); break;
			                 }
					      encountera.MoveToWorld( new Point3D( x2, y2, z2 ), Map.Felucca );

	                                      AOS.Damage(m, 0, 0, 0, 0, 0, 0 );
				              Timer.DelayCall( TimeSpan.FromMinutes( 10.0 ), new TimerStateCallback( DeleteEncounterA ), encountera );
                                         }
                                   }
                            }

                            // Tamable Encounter 1
		            if ( Utility.RandomDouble() < 0.00001 )
                            {
			           if ( m.Map == Map.Felucca )
			           {
				         int x1 = m.X + 12;
				         int y1 = m.Y + 12;
				         int z1 = Map.Felucca.GetAverageZ( x1, y1 );

				         if ( Map.Felucca.CanSpawnMobile( x1, y1, z1 ) )
				         {
				         BaseCreature tameable;
			                 switch ( Utility.Random( 16 ) )
			                 {
					      default:
                                              case 0: tameable = new Booplesnoot(); break;
                                              case 1: tameable = new DampwoodMite(); break;
                                              case 2: tameable = new DangerFloof(); break;
                                              case 3: tameable = new DuskRat(); break;
                                              case 4: tameable = new FelineOfColor(); break;
                                              case 5: tameable = new FreedomGlider(); break;
                                              case 6: tameable = new GreatLandShark(); break;
                                              case 7: tameable = new GryphonScout(); break;
                                              case 8: tameable = new Gullnah(); break;
                                              case 9: tameable = new LakeLizard(); break;
                                              case 10: tameable = new MajesticFlyingFlapFlap(); break;
                                              case 11: tameable = new MegalocerosFawn(); break;
                                              case 12: tameable = new NopeRope(); break;
                                              case 13: tameable = new RedBoar(); break;
                                              case 14: tameable = new RiverGobbler(); break;
                                              case 15: tameable = new SwampHopper(); break;
			                 }
					      tameable.MoveToWorld( new Point3D( x1, y1, z1 ), Map.Felucca );

	                                      AOS.Damage(m, 0, 0, 0, 0, 0, 0 );
				              Timer.DelayCall( TimeSpan.FromMinutes( 10.0 ), new TimerStateCallback( DeleteTameable ), tameable );
                                         }
                                   }
                            }

                            // Tamable Encounter 2
		            if ( Utility.RandomDouble() < 0.00001 )
                            {
			           if ( m.Map == Map.Felucca )
			           {
				         int x2 = m.X - 12;
				         int y2 = m.Y - 12;
				         int z2 = Map.Felucca.GetAverageZ( x2, y2 );

				         if ( Map.Felucca.CanSpawnMobile( x2, y2, z2 ) )
				         {
				         BaseCreature tameable;
			                 switch ( Utility.Random( 16 ) )
			                 {
					      default:
                                              case 0: tameable = new Booplesnoot(); break;
                                              case 1: tameable = new DampwoodMite(); break;
                                              case 2: tameable = new DangerFloof(); break;
                                              case 3: tameable = new DuskRat(); break;
                                              case 4: tameable = new FelineOfColor(); break;
                                              case 5: tameable = new FreedomGlider(); break;
                                              case 6: tameable = new GreatLandShark(); break;
                                              case 7: tameable = new GryphonScout(); break;
                                              case 8: tameable = new Gullnah(); break;
                                              case 9: tameable = new LakeLizard(); break;
                                              case 10: tameable = new MajesticFlyingFlapFlap(); break;
                                              case 11: tameable = new MegalocerosFawn(); break;
                                              case 12: tameable = new NopeRope(); break;
                                              case 13: tameable = new RedBoar(); break;
                                              case 14: tameable = new RiverGobbler(); break;
                                              case 15: tameable = new SwampHopper(); break;
			                 }
					      tameable.MoveToWorld( new Point3D( x2, y2, z2 ), Map.Felucca );

	                                      AOS.Damage(m, 0, 0, 0, 0, 0, 0 );
				              Timer.DelayCall( TimeSpan.FromMinutes( 10.0 ), new TimerStateCallback( DeleteTameable ), tameable );
                                         }
                                   }
                            }
                        }
                   }
                }

	        private void DeleteRandomEncounter( object randomencounter )
	        {
		     BaseCreature mob = (BaseCreature)randomencounter;
	             Map map = mob.Map;
		     Mobile c = randomencounter as Mobile;

		     if ( mob != null || !mob.Deleted )
		     {
			  Effects.SendLocationEffect( mob.Location, mob.Map, 0x3728, 10, 10 );
			  Effects.PlaySound( mob.Location, mob.Map, 652 );

			  mob.Delete();
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