using System;
using System.Collections;
using System.Collections.Generic;
using System.Xml;
using Server.Network;
using Server.Items;
using Server.Mobiles;
using Server.ContextMenus;
using Server.Engines.Quests;
using Server.Engines.Quests.StaffOfFlyingMonkeys;
using Server.Engines.Quests.StolenNecklace;

namespace Server.Regions
{
	public class PonyoPlateauRegion : LandscapeRegion
	{
	     public PonyoPlateauRegion( XmlElement xml, Map map, Region parent ) : base( xml, map, parent )
	     {
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
                                       m.Send( Network.PlayMusic.GetInstance( MusicName.Paws ) );
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
                                       m.Send( Network.PlayMusic.GetInstance( MusicName.Paws ) );
	                               AOS.Damage(m, 0, 0, 0, 0, 0, 0 );
                               }
                         }
                         else
			 {
                               m.Send( Network.PlayMusic.GetInstance( MusicName.Paws ) );
	                       AOS.Damage(m, 0, 0, 0, 0, 0, 0 );
                         }
                   }

                   base.OnEnter( m );
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
	           else if ( item is GMRobeTrailfire )
	           {
	                  AOS.Damage(m, 0, 0, 0, 0, 0, 0 );

		          m.FixedParticles( 0x3709, 10, 30, 5052, EffectLayer.LeftFoot );
                   }
                   else
                   {
                            // Wind
		            if ( Utility.RandomDouble() < 0.002 )
                            {
                                 m.PlaySound(Utility.RandomList( 0x014,0x15,0x016,0x5C7 ) );
	                         AOS.Damage(m, 0, 0, 0, 0, 0, 0 );
                            }

                            // Forest noises
		            if ( Utility.RandomDouble() < 0.04 )
                            {
                                 m.PlaySound(Utility.RandomList( 0x000,0x001,0x002 ) );
	                         AOS.Damage(m, 0, 0, 0, 0, 0, 0 );
                            }

                            // Bird chirps
		            if ( Utility.RandomDouble() < 0.01 )
                            {
                                 m.PlaySound(Utility.RandomList( 0x094,0x095,0x096,0x097,0x0D1,0x0D2 ) );
	                         AOS.Damage(m, 0, 0, 0, 0, 0, 0 );
                            }

                            // Cricket noises
		            if ( Utility.RandomDouble() < 0.01 )
                            {
                                 m.PlaySound(Utility.RandomList( 0x00A,0x00B ) );
	                         AOS.Damage(m, 0, 0, 0, 0, 0, 0 );
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
                                              case 1: tameable = new ForestBat(); break;
                                              case 2: tameable = new GreySquirrel(); break;
                                              case 3: tameable = new Hind(); break;
                                              case 4: tameable = new LargeFrog(); break;
			                 }
					      tameable.MoveToWorld( new Point3D( x1, y1, z1 ), Map.Malas );

	                                      AOS.Damage(m, 0, 0, 0, 0, 0, 0 );
				              Timer.DelayCall( TimeSpan.FromMinutes( 20.0 ), new TimerStateCallback( DeleteTameable ), tameable );
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
                                              case 1: tameable = new ForestBat(); break;
                                              case 2: tameable = new GreySquirrel(); break;
                                              case 3: tameable = new Hind(); break;
                                              case 4: tameable = new LargeFrog(); break;
			                 }
					      tameable.MoveToWorld( new Point3D( x2, y2, z2 ), Map.Malas );

	                                      AOS.Damage(m, 0, 0, 0, 0, 0, 0 );
				              Timer.DelayCall( TimeSpan.FromMinutes( 20.0 ), new TimerStateCallback( DeleteTameable ), tameable );
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
		                              if ( Utility.RandomDouble() < 0.02 )
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

	                                                        AOS.Damage(m, 0, 0, 0, 0, 0, 0 );
				                                Timer.DelayCall( TimeSpan.FromMinutes( 2.0 ), new TimerStateCallback( DeleteBrigandMale ), brigandmale );
                                                           }
                                                     }
                                              }

                                              // Brigand Ambush 2
		                              if ( Utility.RandomDouble() < 0.02 )
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
		                              if ( Utility.RandomDouble() < 0.02 )
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

	                                                        AOS.Damage(m, 0, 0, 0, 0, 0, 0 );
				                                Timer.DelayCall( TimeSpan.FromMinutes( 2.0 ), new TimerStateCallback( DeleteCavernMongbatBerserkerQuest ), cavernmongbatberserker );
                                                           }
                                                     }
                                              }

                                              // Mongbat Ambush 2
		                              if ( Utility.RandomDouble() < 0.02 )
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
       }
}

