using System;
using System.Collections;
using System.Collections.Generic;
using System.Xml;
using Server;
using Server.ContextMenus;
using Server.Items;
using Server.Mobiles;
using Server.Network;
using Server.Targeting;
using Server.Engines.Quests;
using Server.Engines.Quests.StaffOfFlyingMonkeys;
using Server.Engines.Quests.StolenNecklace;

namespace Server.Regions
{
	public class ZaythalorForestRegion : LandscapeRegion
	{
	        public ZaythalorForestRegion( XmlElement xml, Map map, Region parent ) : base( xml, map, parent )
	        {
	        }

		public override void OnDeath( Mobile m )
		{
                        if ( m is PlayerMobile )
                        {
		              PlayerMobile player = m as PlayerMobile;
                              Region rg = player.Region;

	                      if ( m.Region.Name == "Zaythalor Forest" )
	                      {
                                        ////////// Zaythalor Forest //////////
                                        m.Location = new Point3D( 1112, 1128, 10 );
				        m.Map = Map.Malas;

				        Item corpse = m.Corpse;

                      	  	        if ( corpse != null )
				        {
			 		         m.Corpse.Location = new Point3D( 1112, 1128, 10 );
					         m.Corpse.Map = Map.Malas;
                                        }
                              }
                              else
                              {
                                     m.Location = new Point3D( 1112, 1128, 10 );
				     m.Map = Map.Malas;
                              }
                       }

		       base.OnDeath( m );
                }

                public override void OnEnter( Mobile m )
                {
                   if ( m.Player && m.Alive )
                   {
		         PlayerMobile player = m as PlayerMobile;
		         QuestSystem qs = player.Quest;

		         if ( qs is StaffOfFlyingMonkeysQuest )
		         {
                               if ( qs.IsObjectiveInProgress( typeof( EscapeObjective ) ) )
			       {
                                       m.Send( Network.PlayMusic.GetInstance( MusicName.Medieval ) );
	                               AOS.Damage(m, 0, 0, 0, 0, 0, 0 );
                               }
                               else
                               {
                                       m.Send( Network.PlayMusic.GetInstance( MusicName.Ocllo ) );
	                               AOS.Damage(m, 0, 0, 0, 0, 0, 0 );
                               }
                         }
		         else if ( qs is StolenNecklaceQuest )
		         {
                               if ( qs.IsObjectiveInProgress( typeof( ReturnStolenNecklaceObjective ) ) )
			       {
                                       m.Send( Network.PlayMusic.GetInstance( MusicName.StygianAbyss ) );
	                               AOS.Damage(m, 0, 0, 0, 0, 0, 0 );
                               }
                               else
                               {
                                       m.Send( Network.PlayMusic.GetInstance( MusicName.Ocllo ) );
	                               AOS.Damage(m, 0, 0, 0, 0, 0, 0 );
                               }
                         }
                         else
			 {
                               m.Send( Network.PlayMusic.GetInstance( MusicName.Ocllo ) );
	                       AOS.Damage(m, 0, 0, 0, 0, 0, 0 );
                         }
                   }

                   base.OnEnter( m );
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
                  
             base.Damage(m );

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
	           else if ( item is GMRobeFarts )
	           {
	                  AOS.Damage(m, 0, 0, 0, 0, 0, 0 );

                          m.PlaySound(Utility.RandomList( 792, 1064 ) );
                   }
	           else if ( item is GMRobeTrailfire )
	           {
	                  AOS.Damage(m, 0, 0, 0, 0, 0, 0 );

		          m.FixedParticles( 0x3709, 10, 30, 5052, EffectLayer.LeftFoot );
                   }
                   else
                   {
	                    if ( m.Title == "the Running Pants" )
	                    {
                                     if ( m.Str <= 100 )
                                     {
		                              if ( Utility.RandomDouble() < 0.0003 )
                                              {
                                                   m.Str += 1;
		                                   m.BoltEffect( 0x480 );
                                                   m.PlaySound( 0x5CE );
	                                           AOS.Damage(m, 0, 0, 0, 0, 0, 0 );
                                              }
                                     }
                            }

                            // Wind
		            if ( Utility.RandomDouble() < 0.002 )
                            {
                                 m.PlaySound(Utility.RandomList( 0x014,0x15,0x016,0x5C7 ) );
	                         AOS.Damage(m, 0, 0, 0, 0, 0, 0 );
                            }

		            if ( Utility.RandomDouble() < 0.002 )
                            {
                                 m.PlaySound(Utility.RandomList( 0x014,0x15,0x016,0x5C7 ) );
	                         AOS.Damage(m, 0, 0, 0, 0, 0, 0 );
                            }

		            if ( m.Kills >= 5 )
		            {
                                     // Wasteland Mercenary Ambush 
		                     if ( Utility.RandomDouble() < 0.005 )
                                     {
			                      if ( m.Map == Map.Malas )
			                      {
				                     int x1 = m.X + 20;
				                     int y1 = m.Y + 20;
				                     int z1 = Map.Malas.GetAverageZ( x1, y1 );

				                     if ( Map.Malas.CanSpawnMobile( x1, y1, z1 ) )
				                     {
				                            BaseCreature wastelandmercenary = new WastelandMercenary();
					                    wastelandmercenary.MoveToWorld( new Point3D( x1, y1, z1 ), Map.Malas );
				                            wastelandmercenary.Combatant = m;
			                                    wastelandmercenary.PlaySound( 0x220 ); // Earthquake

                                                            m.PlaySound( 0x5CE );
		                                            wastelandmercenary.BoltEffect( 0x480 );
	                                                    AOS.Damage(m, 0, 0, 0, 0, 0, 0 );

				                            Timer.DelayCall( TimeSpan.FromMinutes( 30.0 ), new TimerStateCallback( DeleteWastelandMercenary ), wastelandmercenary );
                                                     }
                                              }

                                              // Wasteland Mercenary 2
		                              if ( Utility.RandomDouble() < 0.005 )
                                              {
			                             if ( m.Map == Map.Malas )
			                             {
				                           int x2 = m.X - 20;
				                           int y2 = m.Y - 20;
				                           int z2 = Map.Malas.GetAverageZ( x2, y2 );

				                           if ( Map.Malas.CanSpawnMobile( x2, y2, z2 ) )
				                           {
				                                BaseCreature wastelandmercenary = new WastelandMercenary();
					                        wastelandmercenary.MoveToWorld( new Point3D( x2, y2, z2 ), Map.Malas );
				                                wastelandmercenary.Combatant = m;
			                                        wastelandmercenary.PlaySound( 0x220 ); // Earthquake

                                                                m.PlaySound( 0x5CE );
		                                                wastelandmercenary.BoltEffect( 0x480 );
	                                                        AOS.Damage(m, 0, 0, 0, 0, 0, 0 );

				                                Timer.DelayCall( TimeSpan.FromMinutes( 30.0 ), new TimerStateCallback( DeleteWastelandMercenary ), wastelandmercenary );
                                                           }
                                                     }
                                             }
                                     }
                            }

                            // Dragon Encounter 1
		            if ( Utility.RandomDouble() < 0.0001 )
                            {
			           if ( m.Map == Map.Malas )
			           {
				         int x1 = m.X + 15;
				         int y1 = m.Y + 15;
				         int z1 = Map.Malas.GetAverageZ( x1, y1 );

				         if ( Map.Malas.CanSpawnMobile( x1, y1, z1 ) )
				         {
				         BaseCreature dragonencounter;
			                 switch ( Utility.Random( 2 ) )
			                 {
					      default:
                                              case 0: dragonencounter = new BlackDragon(); break;
                                              case 1: dragonencounter = new BlackDragon(); break;
			                 }
					      dragonencounter.MoveToWorld( new Point3D( x1, y1, z1 ), Map.Malas );
				              dragonencounter.Combatant = m;
                                              m.PlaySound( 0x656 ); // risingColossus

	                                      AOS.Damage(m, 0, 0, 0, 0, 0, 0 );
				              Timer.DelayCall( TimeSpan.FromMinutes( 30.0 ), new TimerStateCallback( DeleteDragonEncounter ), dragonencounter );
                                         }
                                   }
                            }

                            // Dragon Encounter 2
		            if ( Utility.RandomDouble() < 0.0001 )
                            {
			           if ( m.Map == Map.Malas )
			           {
				         int x2 = m.X - 12;
				         int y2 = m.Y - 12;
				         int z2 = Map.Malas.GetAverageZ( x2, y2 );

				         if ( Map.Malas.CanSpawnMobile( x2, y2, z2 ) )
				         {
				         BaseCreature dragonencounter;
			                 switch ( Utility.Random( 8 ) )
			                 {
					      default:
                                              case 0: dragonencounter = new BlackDragon(); break;
                                              case 1: dragonencounter = new BlackDragon(); break;
			                 }
					      dragonencounter.MoveToWorld( new Point3D( x2, y2, z2 ), Map.Malas );
				              dragonencounter.Combatant = m;
                                              m.PlaySound( 0x656 ); // risingColossus

	                                      AOS.Damage(m, 0, 0, 0, 0, 0, 0 );
				              Timer.DelayCall( TimeSpan.FromMinutes( 30.0 ), new TimerStateCallback( DeleteDragonEncounter ), dragonencounter );
                                         }
                                   }
                            }

                            // Random Encounter 1
		            if ( Utility.RandomDouble() < 0.00002 )
                            {
			           if ( m.Map == Map.Malas )
			           {
				         int x1 = m.X + 12;
				         int y1 = m.Y + 12;
				         int z1 = Map.Malas.GetAverageZ( x1, y1 );

				         if ( Map.Malas.CanSpawnMobile( x1, y1, z1 ) )
				         {
				         BaseCreature encountera;
			                 switch ( Utility.Random( 15 ) )
			                 {
					      default:
                                              case 0: encountera = new Almiraj(); break;
                                              case 1: encountera = new BlackAntAmbusher(); break;
                                              case 2: encountera = new FaerieBeetleCollector(); break;
                                              case 3: encountera = new GazerLarva(); break;
                                              case 4: encountera = new Gizzard(); break;
                                              case 5: encountera = new GreenSlime(); break;
                                              case 6: encountera = new HordeMinion(); break;
                                              case 7: encountera = new Mongbat(); break;
                                              case 8: encountera = new Orc(); break;
                                              case 9: encountera = new Ratman(); break;
                                              case 10: encountera = new StreamingWisp(); break;
                                              case 11: encountera = new SwampVine(); break;
                                              case 12: encountera = new Tokoloshe(); break;
                                              case 13: encountera = new VerdantSprite(); break;
                                              case 14: encountera = new WaterLizard(); break;
			                 }
					      encountera.MoveToWorld( new Point3D( x1, y1, z1 ), Map.Malas );

	                                      AOS.Damage(m, 0, 0, 0, 0, 0, 0 );
				              Timer.DelayCall( TimeSpan.FromMinutes( 10.0 ), new TimerStateCallback( DeleteEncounterA ), encountera );
                                         }
                                   }
                            }

                            // Random Encounter 2
		            if ( Utility.RandomDouble() < 0.00002 )
                            {
			           if ( m.Map == Map.Malas )
			           {
				         int x2 = m.X - 12;
				         int y2 = m.Y - 12;
				         int z2 = Map.Malas.GetAverageZ( x2, y2 );

				         if ( Map.Malas.CanSpawnMobile( x2, y2, z2 ) )
				         {
				         BaseCreature encountera;
			                 switch ( Utility.Random( 15 ) )
			                 {
					      default:
                                              case 0: encountera = new Almiraj(); break;
                                              case 1: encountera = new BlackAntAmbusher(); break;
                                              case 2: encountera = new FaerieBeetleCollector(); break;
                                              case 3: encountera = new GazerLarva(); break;
                                              case 4: encountera = new Gizzard(); break;
                                              case 5: encountera = new GreenSlime(); break;
                                              case 6: encountera = new HordeMinion(); break;
                                              case 7: encountera = new Mongbat(); break;
                                              case 8: encountera = new Orc(); break;
                                              case 9: encountera = new Ratman(); break;
                                              case 10: encountera = new StreamingWisp(); break;
                                              case 11: encountera = new SwampVine(); break;
                                              case 12: encountera = new Tokoloshe(); break;
                                              case 13: encountera = new VerdantSprite(); break;
                                              case 14: encountera = new WaterLizard(); break;
			                 }
					      encountera.MoveToWorld( new Point3D( x2, y2, z2 ), Map.Malas );

	                                      AOS.Damage(m, 0, 0, 0, 0, 0, 0 );
				              Timer.DelayCall( TimeSpan.FromMinutes( 10.0 ), new TimerStateCallback( DeleteEncounterA ), encountera );
                                         }
                                   }
                            }

                            // Tamable Encounter 1
		            if ( Utility.RandomDouble() < 0.00002 )
                            {
			           if ( m.Map == Map.Malas )
			           {
				         int x1 = m.X + 12;
				         int y1 = m.Y + 12;
				         int z1 = Map.Malas.GetAverageZ( x1, y1 );

				         if ( Map.Malas.CanSpawnMobile( x1, y1, z1 ) )
				         {
				         BaseCreature tameable;
			                 switch ( Utility.Random( 23 ) )
			                 {
					      default:
                                              case 0: tameable = new Bird(); break;
                                              case 1: tameable = new Boar(); break;
                                              case 2: tameable = new BrownBear(); break;
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
		            if ( Utility.RandomDouble() < 0.00002 )
                            {
			           if ( m.Map == Map.Malas )
			           {
				         int x2 = m.X - 12;
				         int y2 = m.Y - 12;
				         int z2 = Map.Malas.GetAverageZ( x2, y2 );

				         if ( Map.Malas.CanSpawnMobile( x2, y2, z2 ) )
				         {
				         BaseCreature tameable;
			                 switch ( Utility.Random( 23 ) )
			                 {
					      default:
                                              case 0: tameable = new Bird(); break;
                                              case 1: tameable = new Boar(); break;
                                              case 2: tameable = new BrownBear(); break;
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

                            // Random Adventurer 1
		            if ( Utility.RandomDouble() < 0.00002 )
                            {
			           if ( m.Map == Map.Malas )
			           {
				         int x1 = m.X + 15;
				         int y1 = m.Y + 15;
				         int z1 = Map.Malas.GetAverageZ( x1, y1 );

				         if ( Map.Malas.CanSpawnMobile( x1, y1, z1 ) )
				         {
				         BaseCreature friendlyencounter;
			                 switch ( Utility.Random( 2 ) )
			                 {
					      default:
                                              case 0: friendlyencounter = new ZaythalorHuman(); break;
                                              case 1: friendlyencounter = new ZaythalorSunElf(); break;
                                              case 2: friendlyencounter = new ZaythalorMoonElf(); break;
			                 }
					      friendlyencounter.MoveToWorld( new Point3D( x1, y1, z1 ), Map.Malas );

	                                      AOS.Damage(m, 0, 0, 0, 0, 0, 0 );
				              Timer.DelayCall( TimeSpan.FromMinutes( 10.0 ), new TimerStateCallback( DeleteFriendlyEncounter ), friendlyencounter );
                                         }
                                   }
                            }

                            // Random Adventurer 2
		            if ( Utility.RandomDouble() < 0.00002 )
                            {
			           if ( m.Map == Map.Malas )
			           {
				         int x2 = m.X - 15;
				         int y2 = m.Y - 15;
				         int z2 = Map.Malas.GetAverageZ( x2, y2 );

				         if ( Map.Malas.CanSpawnMobile( x2, y2, z2 ) )
				         {
				         BaseCreature friendlyencounter;
			                 switch ( Utility.Random( 2 ) )
			                 {
					      default:
                                              case 0: friendlyencounter = new ZaythalorHuman(); break;
                                              case 1: friendlyencounter = new ZaythalorSunElf(); break;
                                              case 2: friendlyencounter = new ZaythalorMoonElf(); break;
			                 }
					      friendlyencounter.MoveToWorld( new Point3D( x2, y2, z2 ), Map.Malas );

	                                      AOS.Damage(m, 0, 0, 0, 0, 0, 0 );
				              Timer.DelayCall( TimeSpan.FromMinutes( 10.0 ), new TimerStateCallback( DeleteFriendlyEncounter ), friendlyencounter );
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

                                               if ( m.Skills.Tracking.Base > 4.9 )
                                               {

			                       switch ( Utility.Random( 2 ) )
			                       {
					            default:
                                                    case 0: treasurechest = new ZaythalorForestTreasureChest1(); break;
                                                    case 1: treasurechest = new ZaythalorForestTreasureChest1(); break;
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

                                               if ( m.Skills.Tracking.Base > 4.9 )
                                               {

			                       switch ( Utility.Random( 2 ) )
			                       {
					            default:
                                                    case 0: treasurechest = new ZaythalorForestTreasureChest1(); break;
                                                    case 1: treasurechest = new ZaythalorForestTreasureChest1(); break;
			                       }
					            treasurechest.MoveToWorld( new Point3D( x2, y2, z2 ), Map.Malas );

	                                            AOS.Damage(m, 0, 0, 0, 0, 0, 0 );
				                    Timer.DelayCall( TimeSpan.FromMinutes( 5.0 ), new TimerStateCallback( DeleteTreasureChest ), treasurechest );
                                               }
                                         }
                                   }
                            }

                            // Random Dead Body 1
		            if ( Utility.RandomDouble() < 0.0003 )
                            {
			           if ( m.Map == Map.Malas )
			           {
				         int x1 = m.X + 10;
				         int y1 = m.Y + 10;
				         int z1 = Map.Malas.GetAverageZ( x1, y1 );

				         if ( Map.Malas.CanSpawnMobile( x1, y1, z1 ) )
				         {
				               BaseContainer deadbody;

			                       switch ( Utility.Random( 4 ) )
			                       {
					            default:
                                                    case 0: deadbody = new UnknownBardSkeletonZaythalor(); break;
                                                    case 1: deadbody = new UnknownMageSkeletonZaythalor(); break;
                                                    case 2: deadbody = new UnknownRogueSkeletonZaythalor(); break;
                                                    case 3: deadbody = new UnknownRogueSkeletonZaythalor(); break;
			                       }

					       deadbody.MoveToWorld( new Point3D( x1, y1, z1 ), Map.Malas );

	                                       AOS.Damage(m, 0, 0, 0, 0, 0, 0 );
				               Timer.DelayCall( TimeSpan.FromMinutes( 5.0 ), new TimerStateCallback( DeleteDeadBody ), deadbody );
                                         }
                                   }
                            }

                            // Random Dead Body 2
		            if ( Utility.RandomDouble() < 0.0003 )
                            {
			           if ( m.Map == Map.Malas )
			           {
				         int x2 = m.X - 10;
				         int y2 = m.Y - 10;
				         int z2 = Map.Malas.GetAverageZ( x2, y2 );

				         if ( Map.Malas.CanSpawnMobile( x2, y2, z2 ) )
				         {
				               BaseContainer deadbody;

			                       switch ( Utility.Random( 4 ) )
			                       {
					            default:
                                                    case 0: deadbody = new UnknownBardSkeletonZaythalor(); break;
                                                    case 1: deadbody = new UnknownMageSkeletonZaythalor(); break;
                                                    case 2: deadbody = new UnknownRogueSkeletonZaythalor(); break;
                                                    case 3: deadbody = new UnknownRogueSkeletonZaythalor(); break;
			                       }

					       deadbody.MoveToWorld( new Point3D( x2, y2, z2 ), Map.Malas );

	                                       AOS.Damage(m, 0, 0, 0, 0, 0, 0 );
				               Timer.DelayCall( TimeSpan.FromMinutes( 5.0 ), new TimerStateCallback( DeleteDeadBody ), deadbody );
                                         }
                                   }
                            }

		            PlayerMobile player1 = m as PlayerMobile;
			    QuestSystem qs1 = player1.Quest;

		            if ( qs1 is StolenNecklaceQuest )
		            {
                                     if ( qs1.IsObjectiveInProgress( typeof( ReturnStolenNecklaceObjective ) ) )
			             {
                                             m.Send( Network.PlayMusic.GetInstance( MusicName.StygianAbyss ) );
	                                     AOS.Damage(m, 0, 0, 0, 0, 0, 0 );
                                     }
                            }

		            PlayerMobile player = m as PlayerMobile;
			    QuestSystem qs = player.Quest;

		            if ( qs is StolenNecklaceQuest )
		            {
                                     if ( qs.IsObjectiveInProgress( typeof( ReturnStolenNecklaceObjective ) ) )
			             {
                                              // Brigand Ambush 
		                              if ( Utility.RandomDouble() < 0.015 )
                                              {
			                             if ( m.Map == Map.Malas )
			                             {
				                           int x1 = m.X + 20;
				                           int y1 = m.Y + 20;
				                           int z1 = Map.Malas.GetAverageZ( x1, y1 );

				                           if ( Map.Malas.CanSpawnMobile( x1, y1, z1 ) )
				                           {
				                                BaseCreature brigandmale = new BrigandMaleQuest();
					                        brigandmale.MoveToWorld( new Point3D( x1, y1, z1 ), Map.Malas );
				                                brigandmale.Combatant = m;
                                                                m.Send( Network.PlayMusic.GetInstance( MusicName.StygianAbyss ) );

	                                                        AOS.Damage(m, 0, 0, 0, 0, 0, 0 );
				                                Timer.DelayCall( TimeSpan.FromMinutes( 2.0 ), new TimerStateCallback( DeleteBrigandMale ), brigandmale );
                                                           }
                                                     }
                                              }

                                              // Brigand Ambush 2
		                              if ( Utility.RandomDouble() < 0.015 )
                                              {
			                             if ( m.Map == Map.Malas )
			                             {
				                           int x2 = m.X - 20;
				                           int y2 = m.Y - 20;
				                           int z2 = Map.Malas.GetAverageZ( x2, y2 );

				                           if ( Map.Malas.CanSpawnMobile( x2, y2, z2 ) )
				                           {
				                                BaseCreature brigandfemale = new BrigandFemaleQuest();
					                        brigandfemale.MoveToWorld( new Point3D( x2, y2, z2 ), Map.Malas );
				                                brigandfemale.Combatant = m;
                                                                m.Send( Network.PlayMusic.GetInstance( MusicName.StygianAbyss ) );

	                                                        AOS.Damage(m, 0, 0, 0, 0, 0, 0 );
				                                Timer.DelayCall( TimeSpan.FromMinutes( 2.0 ), new TimerStateCallback( DeleteBrigandFemale ), brigandfemale );
                                                           }
                                                     }
                                              }
                                     }
                            }

		            else if ( qs is StaffOfFlyingMonkeysQuest )
		            {
                                     if ( qs.IsObjectiveInProgress( typeof( EscapeObjective ) ) )
			             {
                                              // Mongbat Ambush 
		                              if ( Utility.RandomDouble() < 0.015 )
                                              {
			                             if ( m.Map == Map.Malas )
			                             {
				                           int x1 = m.X + 20;
				                           int y1 = m.Y + 20;
				                           int z1 = Map.Malas.GetAverageZ( x1, y1 );

				                           if ( Map.Malas.CanSpawnMobile( x1, y1, z1 ) )
				                           {
				                                BaseCreature cavernmongbatberserker = new CavernMongbatBerserkerQuest();
					                        cavernmongbatberserker.MoveToWorld( new Point3D( x1, y1, z1 ), Map.Malas );
				                                cavernmongbatberserker.Combatant = m;
                                                                m.Send( Network.PlayMusic.GetInstance( MusicName.Medieval ) );

	                                                        AOS.Damage(m, 0, 0, 0, 0, 0, 0 );
				                                Timer.DelayCall( TimeSpan.FromMinutes( 2.0 ), new TimerStateCallback( DeleteCavernMongbatBerserkerQuest ), cavernmongbatberserker );
                                                           }
                                                     }
                                              }

                                              // Mongbat Ambush 2
		                              if ( Utility.RandomDouble() < 0.015 )
                                              {
			                             if ( m.Map == Map.Malas )
			                             {
				                           int x2 = m.X - 20;
				                           int y2 = m.Y - 20;
				                           int z2 = Map.Malas.GetAverageZ( x2, y2 );

				                           if ( Map.Malas.CanSpawnMobile( x2, y2, z2 ) )
				                           {
				                                BaseCreature cavernmongbatberserker = new CavernMongbatBerserkerQuest();
					                        cavernmongbatberserker.MoveToWorld( new Point3D( x2, y2, z2 ), Map.Malas );
				                                cavernmongbatberserker.Combatant = m;
                                                                m.Send( Network.PlayMusic.GetInstance( MusicName.Medieval ) );

	                                                        AOS.Damage(m, 0, 0, 0, 0, 0, 0 );
				                                Timer.DelayCall( TimeSpan.FromMinutes( 2.0 ), new TimerStateCallback( DeleteCavernMongbatBerserkerQuest ), cavernmongbatberserker );
                                                           }
                                                     }
                                              }
                                     }
                            }
                       }
                  }
             }

	     private void DeleteWastelandMercenary( object wastelandmercenary )
	     {
		     BaseCreature mob = (BaseCreature)wastelandmercenary;
	             Map map = mob.Map;
		     Mobile c = wastelandmercenary as Mobile;

		     if ( mob != null || !mob.Deleted )
		     {
			 Effects.SendLocationEffect( mob.Location, mob.Map, 0x3728, 10, 10 );
			 Effects.PlaySound( mob.Location, mob.Map, 0x1FC );

			 mob.Delete();
                     }
             }

	     private void DeleteDragonEncounter( object dragonencounter )
	     {
		  BaseCreature mob = (BaseCreature)dragonencounter;
	          Map map = mob.Map;
		  Mobile c = dragonencounter as Mobile;

		  if ( mob != null || !mob.Deleted )
		  {
			Effects.SendLocationEffect( mob.Location, mob.Map, 0x3728, 10, 10 );
			Effects.PlaySound( mob.Location, mob.Map, 0x1FC );

			mob.Delete();
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

	     private void DeleteBrigandMale( object brigandmale )
	     {
		  BaseCreature mob = (BaseCreature)brigandmale;
	          Map map = mob.Map;
		  Mobile c = brigandmale as Mobile;

		  if ( mob != null || !mob.Deleted )
		  {
			Effects.SendLocationEffect( mob.Location, mob.Map, 0x3728, 10, 10 );
			Effects.PlaySound( mob.Location, mob.Map, 0x1FC );

			mob.Delete();
                  }
             }

	     private void DeleteBrigandFemale( object brigandfemale )
	     {
		  BaseCreature mob = (BaseCreature)brigandfemale;
	          Map map = mob.Map;
		  Mobile c = brigandfemale as Mobile;

		  if ( mob != null || !mob.Deleted )
		  {
			Effects.SendLocationEffect( mob.Location, mob.Map, 0x3728, 10, 10 );
			Effects.PlaySound( mob.Location, mob.Map, 0x1FC );

			mob.Delete();
                  }
             }

	     private void DeleteCavernMongbatBerserkerQuest( object cavernmongbatberserker )
	     {
		  BaseCreature mob = (BaseCreature)cavernmongbatberserker;
	          Map map = mob.Map;
		  Mobile c = cavernmongbatberserker as Mobile;

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

	     private void DeleteFriendlyEncounter( object friendlyencounter )
	     {
		  BaseCreature mob = (BaseCreature)friendlyencounter;
	          Map map = mob.Map;
		  Mobile c = friendlyencounter as Mobile;

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

	     private void DeleteDeadBody( object deadbody )
	     {
		  BaseContainer container = (BaseContainer)deadbody;
	          Map map = container.Map;
		  Container c = deadbody as Container;

		  if ( container != null || !container.Deleted )
		  {
			Effects.SendLocationEffect( container.Location, container.Map, 0x3728, 10, 10 );
			Effects.PlaySound( container.Location, container.Map, 0x1FC );

			container.Delete();
                  }
             }
       }
}

