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
	public class HarashiNabiDesertRegion : LandscapeRegion
	{
		public HarashiNabiDesertRegion( XmlElement xml, Map map, Region parent ) : base( xml, map, parent )
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
		            if ( Utility.RandomDouble() < 0.002 )
                            {
                                 m.PlaySound(Utility.RandomList( 0x014,0x15,0x016,0x5C7 ) );
	                         AOS.Damage(m, 0, 0, 0, 0, 0, 0 );
                            }

		            if ( Utility.RandomDouble() < 0.05 )
                            {
		            	PlayerMobile pm = m as PlayerMobile;
		            	if ( pm.TotalQuestsDone < 25 )
		            	{  
                                        m.Location = new Point3D( 652, 1364, 20 );
				        m.Map = Map.Malas;
        	            		m.SendMessage("You cannot enter this area until you've completed at least 25 quests.");
                                }
                            }

                            // Random Encounter 1
		            if ( Utility.RandomDouble() < 0.0001 )
                            {
			           if ( m.Map == Map.Malas )
			           {
				         int x1 = m.X + 12;
				         int y1 = m.Y + 12;
				         int z1 = Map.Malas.GetAverageZ( x1, y1 );

				         if ( Map.Malas.CanSpawnMobile( x1, y1, z1 ) )
				         {
				         BaseCreature randomencounter;
			                 switch ( Utility.Random( 2 ) )
			                 {
					      default:
                                              case 0: randomencounter = new SandKraken(); break;
                                              case 1: randomencounter = new SandKraken(); break;
			                 }
					      randomencounter.MoveToWorld( new Point3D( x1, y1, z1 ), Map.Malas );
                                              m.PlaySound( 649 );
				              randomencounter.Combatant = m;

	                                      AOS.Damage(m, 0, 0, 0, 0, 0, 0 );
				              Timer.DelayCall( TimeSpan.FromMinutes( 20.0 ), new TimerStateCallback( DeleteRandomEncounter ), randomencounter );
                                         }
                                   }
                            }

                            // Random Encounter 2
		            if ( Utility.RandomDouble() < 0.0001 )
                            {
			           if ( m.Map == Map.Malas )
			           {
				         int x2 = m.X - 12;
				         int y2 = m.Y - 12;
				         int z2 = Map.Malas.GetAverageZ( x2, y2 );

				         if ( Map.Malas.CanSpawnMobile( x2, y2, z2 ) )
				         {
				         BaseCreature randomencounter;
			                 switch ( Utility.Random( 2 ) )
			                 {
					      default:
                                              case 0: randomencounter = new SandKraken(); break;
                                              case 1: randomencounter = new SandKraken(); break;
			                 }
					      randomencounter.MoveToWorld( new Point3D( x2, y2, z2 ), Map.Malas );
                                              m.PlaySound( 649 );
				              randomencounter.Combatant = m;

	                                      AOS.Damage(m, 0, 0, 0, 0, 0, 0 );
				              Timer.DelayCall( TimeSpan.FromMinutes( 20.0 ), new TimerStateCallback( DeleteRandomEncounter ), randomencounter );
                                         }
                                   }
                            }

                            // Random Encounter 3
		            if ( Utility.RandomDouble() < 0.0002 )
                            {
			           if ( m.Map == Map.Malas )
			           {
				         int x1 = m.X + 12;
				         int y1 = m.Y + 12;
				         int z1 = Map.Malas.GetAverageZ( x1, y1 );

				         if ( Map.Malas.CanSpawnMobile( x1, y1, z1 ) )
				         {
				         BaseCreature encountera;
			                 switch ( Utility.Random( 10 ) )
			                 {
					      default:
                                              case 0: encountera = new BronzeElemental(); break;
                                              case 1: encountera = new CharredSprite(); break;
                                              case 2: encountera = new CliffDiver(); break;
                                              case 3: encountera = new CopperElemental(); break;
                                              case 4: encountera = new DeathwatchBeetle(); break;
                                              case 5: encountera = new DeathwatchBeetleHatchling(); break;
                                              case 6: encountera = new GoldenElemental(); break;
                                              case 7: encountera = new Imp(); break;
                                              case 8: encountera = new MountainGiant(); break;
                                              case 9: encountera = new SpectralArmour(); break;
			                 }
					      encountera.MoveToWorld( new Point3D( x1, y1, z1 ), Map.Malas );

	                                      AOS.Damage(m, 0, 0, 0, 0, 0, 0 );
				              Timer.DelayCall( TimeSpan.FromMinutes( 10.0 ), new TimerStateCallback( DeleteEncounterA ), encountera );
                                         }
                                   }
                            }

                            // Random Encounter 4
		            if ( Utility.RandomDouble() < 0.0002 )
                            {
			           if ( m.Map == Map.Malas )
			           {
				         int x2 = m.X - 12;
				         int y2 = m.Y - 12;
				         int z2 = Map.Malas.GetAverageZ( x2, y2 );

				         if ( Map.Malas.CanSpawnMobile( x2, y2, z2 ) )
				         {
				         BaseCreature encountera;
			                 switch ( Utility.Random( 10 ) )
			                 {
					      default:
                                              case 0: encountera = new BronzeElemental(); break;
                                              case 1: encountera = new CharredSprite(); break;
                                              case 2: encountera = new CliffDiver(); break;
                                              case 3: encountera = new CopperElemental(); break;
                                              case 4: encountera = new DeathwatchBeetle(); break;
                                              case 5: encountera = new DeathwatchBeetleHatchling(); break;
                                              case 6: encountera = new GoldenElemental(); break;
                                              case 7: encountera = new Imp(); break;
                                              case 8: encountera = new MountainGiant(); break;
                                              case 9: encountera = new SpectralArmour(); break;
			                 }
					      encountera.MoveToWorld( new Point3D( x2, y2, z2 ), Map.Malas );

	                                      AOS.Damage(m, 0, 0, 0, 0, 0, 0 );
				              Timer.DelayCall( TimeSpan.FromMinutes( 10.0 ), new TimerStateCallback( DeleteEncounterA ), encountera );
                                         }
                                   }
                            }

                            // Tamable Encounter 1
		            if ( Utility.RandomDouble() < 0.0001 )
                            {
			           if ( m.Map == Map.Malas )
			           {
				         int x1 = m.X + 12;
				         int y1 = m.Y + 12;
				         int z1 = Map.Malas.GetAverageZ( x1, y1 );

				         if ( Map.Malas.CanSpawnMobile( x1, y1, z1 ) )
				         {
				         BaseCreature tameable;
			                 switch ( Utility.Random( 8 ) )
			                 {
					      default:
                                              case 0: tameable = new DesertOstard(); break;
                                              case 1: tameable = new Jubokko(); break;
                                              case 2: tameable = new GiantTurtle(); break;
                                              case 3: tameable = new Lion(); break;
                                              case 4: tameable = new SandBarracuda(); break;
                                              case 5: tameable = new SandStreaker(); break;
                                              case 6: tameable = new RedbarkScorpion(); break;
                                              case 7: tameable = new Zebra(); break;
			                 }
					      tameable.MoveToWorld( new Point3D( x1, y1, z1 ), Map.Malas );

	                                      AOS.Damage(m, 0, 0, 0, 0, 0, 0 );
				              Timer.DelayCall( TimeSpan.FromMinutes( 10.0 ), new TimerStateCallback( DeleteTameable ), tameable );
                                         }
                                   }
                            }

                            // Tamable Encounter 2
		            if ( Utility.RandomDouble() < 0.0001 )
                            {
			           if ( m.Map == Map.Malas )
			           {
				         int x2 = m.X - 12;
				         int y2 = m.Y - 12;
				         int z2 = Map.Malas.GetAverageZ( x2, y2 );

				         if ( Map.Malas.CanSpawnMobile( x2, y2, z2 ) )
				         {
				         BaseCreature tameable;
			                 switch ( Utility.Random( 8 ) )
			                 {
					      default:
                                              case 0: tameable = new DesertOstard(); break;
                                              case 1: tameable = new Jubokko(); break;
                                              case 2: tameable = new GiantTurtle(); break;
                                              case 3: tameable = new Lion(); break;
                                              case 4: tameable = new SandBarracuda(); break;
                                              case 5: tameable = new SandStreaker(); break;
                                              case 6: tameable = new RedbarkScorpion(); break;
                                              case 7: tameable = new Zebra(); break;
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

                                               if ( m.Skills.Tracking.Base > 39.9 )
                                               {

			                       switch ( Utility.Random( 2 ) )
			                       {
					            default:
                                                    case 0: treasurechest = new HarashiNabiChest(); break;
                                                    case 1: treasurechest = new HarashiNabiChest(); break;
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

                                               if ( m.Skills.Tracking.Base > 39.9 )
                                               {

			                       switch ( Utility.Random( 2 ) )
			                       {
					            default:
                                                    case 0: treasurechest = new HarashiNabiChest(); break;
                                                    case 1: treasurechest = new HarashiNabiChest(); break;
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