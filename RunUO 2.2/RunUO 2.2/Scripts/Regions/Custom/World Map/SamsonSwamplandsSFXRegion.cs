using System;
using System.Collections;
using System.Collections.Generic;
using System.Xml;
using Server;
using Server.ContextMenus;
using Server.Items;
using Server.Misc;
using Server.Mobiles;
using Server.Network;
using Server.Engines.Quests;
using Server.Engines.Quests.StaffOfFlyingMonkeys;
using Server.Engines.Quests.StolenNecklace;

namespace Server.Regions
{
	public class SamsonSwamplandsSFXRegion : LandscapeRegion
	{
	       public SamsonSwamplandsSFXRegion( XmlElement xml, Map map, Region parent ) : base( xml, map, parent )
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
                                           m.Send( Network.PlayMusic.GetInstance( MusicName.BTCastle ) );
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
                                       m.Send( Network.PlayMusic.GetInstance( MusicName.BTCastle ) );
	                               AOS.Damage(m, 0, 0, 0, 0, 0, 0 );
                                  }
                            }
                            else
			    {
                                  m.Send( Network.PlayMusic.GetInstance( MusicName.BTCastle ) );
	                          AOS.Damage(m, 0, 0, 0, 0, 0, 0 );
                            }
                      }

                      base.OnEnter( m );
               }

               public override void OnExit( Mobile m )
               {
        	    m.SendMessage("You have left Samson Swamplands.");

                    base.OnExit( m );
               }

               public override void Damage( Mobile m )
               {
                  
               base.Damage( m );

               if ( m.Alive )
               {
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
				    int x1 = m.X + 12;
				    int y1 = m.Y + 12;
				    int z1 = Map.Malas.GetAverageZ( x1, y1 );

				    if ( Map.Malas.CanSpawnMobile( x1, y1, z1 ) )
				    {
				         BaseCreature brigandmale = new BrigandMaleQuest();
					 brigandmale.MoveToWorld( new Point3D( x1, y1, z1 ), Map.Malas );
				         brigandmale.Combatant = m;

	                                 AOS.Damage(m, 0, 0, 0, 0, 0, 0 );
				         Timer.DelayCall( TimeSpan.FromMinutes( 1.0 ), new TimerStateCallback( DeleteBrigandMale ), brigandmale );
                                    }
                                }
                           }

                           // Brigand Ambush 2
		           if ( Utility.RandomDouble() < 0.02 )
                           {
			       if ( m.Map == Map.Malas )
			       {
				   int x2 = m.X - 12;
				   int y2 = m.Y - 12;
				   int z2 = Map.Malas.GetAverageZ( x2, y2 );

				   if ( Map.Malas.CanSpawnMobile( x2, y2, z2 ) )
				   {
				        BaseCreature brigandfemale = new BrigandFemaleQuest();
					brigandfemale.MoveToWorld( new Point3D( x2, y2, z2 ), Map.Malas );
				        brigandfemale.Combatant = m;

	                                AOS.Damage(m, 0, 0, 0, 0, 0, 0 );
				        Timer.DelayCall( TimeSpan.FromMinutes( 1.0 ), new TimerStateCallback( DeleteBrigandFemale ), brigandfemale );
                                   }
                               }
                            }
                        }
                   }

		   PlayerMobile pm = m as PlayerMobile;
		   GreenCandle greencandle = m.FindItemOnLayer( Layer.TwoHanded ) as GreenCandle;

	           if ( greencandle != null && greencandle.Burning )
	           {
                          // Swamp noises
		          if ( Utility.RandomDouble() < 0.08 )
                          {
                               m.PlaySound(Utility.RandomList( 0x006,0x007,0x00E,0x00F,0x2B6,0x2B7 ) );
	                       AOS.Damage(m, 0, 0, 0, 0, 0, 0 );
                          }

                          // Bird chirps
		          if ( Utility.RandomDouble() < 0.02 )
                          {
                               m.PlaySound(Utility.RandomList( 0x097,0x0D1,0x0D2,0x0D3,0x0D4,0x29B,0x29C,0x29D,0x29E,0x29F,0x2A0 ) );
	                       AOS.Damage(m, 0, 0, 0, 0, 0, 0 );
                          }

                          // Air Elemental noises
		          if ( Utility.RandomDouble() < 0.02 )
                          {
                               m.PlaySound( 0x107 );
	                       AOS.Damage(m, 0, 0, 0, 0, 0, 0 );
                          }

                          // Daemon noises
		          if ( Utility.RandomDouble() < 0.010 )
                          {
                               m.PlaySound( 0x2B8 );
	                       AOS.Damage(m, 0, 0, 0, 0, 0, 0 );
                          }

                          // Cricket noises
		          if ( Utility.RandomDouble() < 0.03 )
                          {
                               m.PlaySound(Utility.RandomList( 0x00A,0x00B ) );
	                       AOS.Damage(m, 0, 0, 0, 0, 0, 0 );
                          }

                          // Wind
		          if ( Utility.RandomDouble() < 0.04 )
                          {
                               m.PlaySound(Utility.RandomList( 0x014,0x15,0x016,0x5C7 ) );
	                       AOS.Damage(m, 0, 0, 0, 0, 0, 0 );
                          }
                   }
                   else
                   {
                          // Swamp noises
		          if ( Utility.RandomDouble() < 0.08 )
                          {
                               m.PlaySound(Utility.RandomList( 0x006,0x007,0x00E,0x00F,0x2B6,0x2B7 ) );
	                       AOS.Damage(m, 0, 0, 0, 0, 0, 0 );
                          }

                          // Bird chirps
		          if ( Utility.RandomDouble() < 0.02 )
                          {
                               m.PlaySound(Utility.RandomList( 0x097,0x0D1,0x0D2,0x0D3,0x0D4,0x29B,0x29C,0x29D,0x29E,0x29F,0x2A0 ) );
	                       AOS.Damage(m, 0, 0, 0, 0, 0, 0 );
                          }

                          // Air Elemental noises
		          if ( Utility.RandomDouble() < 0.02 )
                          {
                               m.PlaySound( 0x107 );
	                       AOS.Damage(m, 0, 0, 0, 0, 0, 0 );
                          }

                          // Daemon noises
		          if ( Utility.RandomDouble() < 0.010 )
                          {
                               m.PlaySound( 0x2B8 );
	                       AOS.Damage(m, 0, 0, 0, 0, 0, 0 );
                          }

                          // Cricket noises
		          if ( Utility.RandomDouble() < 0.03 )
                          {
                               m.PlaySound(Utility.RandomList( 0x00A,0x00B ) );
	                       AOS.Damage(m, 0, 0, 0, 0, 0, 0 );
                          }

                          // Wind
		          if ( Utility.RandomDouble() < 0.04 )
                          {
                               m.PlaySound(Utility.RandomList( 0x014,0x15,0x016,0x5C7 ) );
	                       AOS.Damage(m, 0, 0, 0, 0, 0, 0 );
                          }

                          // Annoying Llama Ambush 1
		          if ( Utility.RandomDouble() < 0.02 )
                          {
			        if ( m.Map == Map.Malas )
			        {
				       int x1 = m.X + 20;
				       int y1 = m.Y + 20;
				       int z1 = Map.Malas.GetAverageZ( x1, y1 );

				       if ( Map.Malas.CanSpawnMobile( x1, y1, z1 ) )
				       {
				              BaseCreature annoyingllama;
			                      switch ( Utility.Random( 3 ) )
			                      {
					           default:
                                                   case 0: annoyingllama = new AnnoyingLlama1(); break;
                                                   case 1: annoyingllama = new AnnoyingLlama2(); break;
                                                   case 2: annoyingllama = new AnnoyingLlama3(); break;
			                      }

					      annoyingllama.MoveToWorld( new Point3D( x1, y1, z1 ), Map.Malas );
				              annoyingllama.Combatant = m;

	                                      AOS.Damage(m, 0, 0, 0, 0, 0, 0 );
				              Timer.DelayCall( TimeSpan.FromMinutes( 1.0 ), new TimerStateCallback( DeleteAnnoyingLlama ), annoyingllama );
                                       }
                                }
                          }

                          // Annoying Llama Ambush 2
		          if ( Utility.RandomDouble() < 0.02 )
                          {
			        if ( m.Map == Map.Malas )
			        {
				       int x2 = m.X - 20;
				       int y2 = m.Y - 20;
				       int z2 = Map.Malas.GetAverageZ( x2, y2 );

				       if ( Map.Malas.CanSpawnMobile( x2, y2, z2 ) )
				       {
				              BaseCreature annoyingllama;
			                      switch ( Utility.Random( 3 ) )
			                      {
					           default:
                                                   case 0: annoyingllama = new AnnoyingLlama1(); break;
                                                   case 1: annoyingllama = new AnnoyingLlama2(); break;
                                                   case 2: annoyingllama = new AnnoyingLlama3(); break;
			                      }

					      annoyingllama.MoveToWorld( new Point3D( x2, y2, z2 ), Map.Malas );
				              annoyingllama.Combatant = m;

	                                      AOS.Damage(m, 0, 0, 0, 0, 0, 0 );
				              Timer.DelayCall( TimeSpan.FromMinutes( 1.0 ), new TimerStateCallback( DeleteAnnoyingLlama ), annoyingllama );
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

	     private void DeleteAnnoyingLlama( object annoyingllama )
	     {
		  BaseCreature mob = (BaseCreature)annoyingllama;
	          Map map = mob.Map;
		  Mobile c = annoyingllama as Mobile;

		  if ( mob != null || !mob.Deleted )
		  {
			Effects.SendLocationEffect( mob.Location, mob.Map, 0x3728, 10, 10 );
			Effects.PlaySound( mob.Location, mob.Map, 0x1FC );

			mob.Delete();
                  }
             }
      }
}

