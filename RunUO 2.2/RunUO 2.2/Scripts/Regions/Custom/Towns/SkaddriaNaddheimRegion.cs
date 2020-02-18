using System;
using System.Collections;
using System.Collections.Generic;
using System.Xml;
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
     public class SkaddriaNaddheimRegion : TownRegion
     {
            public SkaddriaNaddheimRegion( XmlElement xml, Map map, Region parent ) : base( xml, map, parent )
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
                                       m.Send( Network.PlayMusic.GetInstance( MusicName.SkaddriaNaddheim ) );
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
                                      m.Send( Network.PlayMusic.GetInstance( MusicName.SkaddriaNaddheim ) );
	                              AOS.Damage(m, 0, 0, 0, 0, 0, 0 );
                               }
                         }
                         else
			 {
                               m.Send( Network.PlayMusic.GetInstance( MusicName.SkaddriaNaddheim ) );
	                       AOS.Damage(m, 0, 0, 0, 0, 0, 0 );
                         }
                   }

                   base.OnEnter( m );
             }

             public static void Initialize() 
             { 
                   EventSink.Login += new LoginEventHandler( SkaddriaNaddheim_OnLogin );
             }

             public static void SkaddriaNaddheim_OnLogin( LoginEventArgs e ) 
             {
		   PlayerMobile m = e.Mobile as PlayerMobile;

                   if ( m.Region.Name == "Skaddria Naddheim" )
                           m.Send( Network.PlayMusic.GetInstance( MusicName.SkaddriaNaddheim ) );
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

                            // Birds, Crows, and Eagles
		            if ( Utility.RandomDouble() < 0.002 )
                            {
                                 m.PlaySound(Utility.RandomList( 0x07D,0x07E,0x07F,0x080,0x08F,0x090,0x29B,0x29C,0x29D,0x29E,0x29F,0x2A0 ) );
	                         AOS.Damage(m, 0, 0, 0, 0, 0, 0 );
                            }

                            // Cats
		            if ( Utility.RandomDouble() < 0.002 )
                            {
                                 m.PlaySound(Utility.RandomList( 0x069,0x06A,0x06B,0x06C,0x06D,0x2A2,0x2A3,0x2A4,0x2A5,0x2A6 ) );
	                         AOS.Damage(m, 0, 0, 0, 0, 0, 0 );
                            }

		            PlayerMobile player = m as PlayerMobile;
			    QuestSystem qs = player.Quest;

		            if ( qs is StolenNecklaceQuest )
		            {
                                     if ( qs.IsObjectiveInProgress( typeof( ReturnStolenNecklaceObjective ) ) )
			             {
                                              // Brigand Ambush 1
		                              if ( Utility.RandomDouble() < 0.035 )
                                              {
			                             if ( m.Map == Map.Malas )
			                             {
				                           int x1 = m.X + 10;
				                           int y1 = m.Y + 10;
				                           int z1 = Map.Malas.GetAverageZ( x1, y1 );

				                           if ( Map.Malas.CanSpawnMobile( x1, y1, z1 ) )
				                           {
				                                BaseCreature brigandmale1 = new BrigandMaleQuest();
					                        brigandmale1.MoveToWorld( new Point3D( x1, y1, z1 ), Map.Malas );
				                                brigandmale1.Combatant = m;

				                                BaseCreature brigandmale2 = new BrigandMaleQuest();
					                        brigandmale2.MoveToWorld( new Point3D( x1, y1, z1 ), Map.Malas );
				                                brigandmale2.Combatant = m;

				                                BaseCreature brigandmale3 = new BrigandMaleQuest();
					                        brigandmale3.MoveToWorld( new Point3D( x1, y1, z1 ), Map.Malas );
				                                brigandmale3.Combatant = m;

                                                                m.Send( Network.PlayMusic.GetInstance( MusicName.StygianAbyss ) );

	                                                        AOS.Damage(m, 0, 0, 0, 0, 0, 0 );
				                                Timer.DelayCall( TimeSpan.FromMinutes( 1.0 ), new TimerStateCallback( DeleteBrigandMale1 ), brigandmale1 );
				                                Timer.DelayCall( TimeSpan.FromMinutes( 1.0 ), new TimerStateCallback( DeleteBrigandMale2 ), brigandmale2 );
				                                Timer.DelayCall( TimeSpan.FromMinutes( 1.0 ), new TimerStateCallback( DeleteBrigandMale3 ), brigandmale3 );
                                                           }
                                                     }
                                              }

                                              // Brigand Ambush 2
		                              if ( Utility.RandomDouble() < 0.035 )
                                              {
			                             if ( m.Map == Map.Malas )
			                             {
				                           int x2 = m.X - 10;
				                           int y2 = m.Y - 10;
				                           int z2 = Map.Malas.GetAverageZ( x2, y2 );

				                           if ( Map.Malas.CanSpawnMobile( x2, y2, z2 ) )
				                           {
				                                BaseCreature brigandfemale1 = new BrigandFemaleQuest();
					                        brigandfemale1.MoveToWorld( new Point3D( x2, y2, z2 ), Map.Malas );
				                                brigandfemale1.Combatant = m;

				                                BaseCreature brigandfemale2 = new BrigandFemaleQuest();
					                        brigandfemale2.MoveToWorld( new Point3D( x2, y2, z2 ), Map.Malas );
				                                brigandfemale2.Combatant = m;

				                                BaseCreature brigandfemale3 = new BrigandFemaleQuest();
					                        brigandfemale3.MoveToWorld( new Point3D( x2, y2, z2 ), Map.Malas );
				                                brigandfemale3.Combatant = m;

                                                                m.Send( Network.PlayMusic.GetInstance( MusicName.StygianAbyss ) );

	                                                        AOS.Damage(m, 0, 0, 0, 0, 0, 0 );
				                                Timer.DelayCall( TimeSpan.FromMinutes( 1.0 ), new TimerStateCallback( DeleteBrigandFemale1 ), brigandfemale1 );
				                                Timer.DelayCall( TimeSpan.FromMinutes( 1.0 ), new TimerStateCallback( DeleteBrigandFemale2 ), brigandfemale2 );
				                                Timer.DelayCall( TimeSpan.FromMinutes( 1.0 ), new TimerStateCallback( DeleteBrigandFemale3 ), brigandfemale3 );
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
		                              if ( Utility.RandomDouble() < 0.050 )
                                              {
			                             if ( m.Map == Map.Malas )
			                             {
				                           int x1 = m.X + 6;
				                           int y1 = m.Y + 6;
				                           int z1 = Map.Malas.GetAverageZ( x1, y1 );

				                           if ( Map.Malas.CanSpawnMobile( x1, y1, z1 ) )
				                           {
				                                BaseCreature cavernmongbatberserker1 = new CavernMongbatBerserkerQuest();
					                        cavernmongbatberserker1.MoveToWorld( new Point3D( x1, y1, z1 ), Map.Malas );
				                                cavernmongbatberserker1.Combatant = m;

				                                BaseCreature cavernmongbatberserker2 = new CavernMongbatBerserkerQuest();
					                        cavernmongbatberserker2.MoveToWorld( new Point3D( x1, y1, z1 ), Map.Malas );
				                                cavernmongbatberserker2.Combatant = m;

				                                BaseCreature cavernmongbatberserker3 = new CavernMongbatBerserkerQuest();
					                        cavernmongbatberserker3.MoveToWorld( new Point3D( x1, y1, z1 ), Map.Malas );
				                                cavernmongbatberserker3.Combatant = m;
                                                                m.Send( Network.PlayMusic.GetInstance( MusicName.Medieval ) );

	                                                        AOS.Damage(m, 0, 0, 0, 0, 0, 0 );
				                                Timer.DelayCall( TimeSpan.FromMinutes( 1.0 ), new TimerStateCallback( DeleteCavernMongbatBerserkerQuest1 ), cavernmongbatberserker1 );
				                                Timer.DelayCall( TimeSpan.FromMinutes( 1.0 ), new TimerStateCallback( DeleteCavernMongbatBerserkerQuest2 ), cavernmongbatberserker2 );
                                                           }
                                                     }
                                              }

                                              // Mongbat Ambush 2
		                              if ( Utility.RandomDouble() < 0.050 )
                                              {
			                             if ( m.Map == Map.Malas )
			                             {
				                           int x2 = m.X - 6;
				                           int y2 = m.Y - 6;
				                           int z2 = Map.Malas.GetAverageZ( x2, y2 );

				                           if ( Map.Malas.CanSpawnMobile( x2, y2, z2 ) )
				                           {
				                                BaseCreature cavernmongbatberserker1 = new CavernMongbatBerserkerQuest();
					                        cavernmongbatberserker1.MoveToWorld( new Point3D( x2, y2, z2 ), Map.Malas );
				                                cavernmongbatberserker1.Combatant = m;

				                                BaseCreature cavernmongbatberserker2 = new CavernMongbatBerserkerQuest();
					                        cavernmongbatberserker2.MoveToWorld( new Point3D( x2, y2, z2 ), Map.Malas );
				                                cavernmongbatberserker2.Combatant = m;

				                                BaseCreature cavernmongbatberserker3 = new CavernMongbatBerserkerQuest();
					                        cavernmongbatberserker3.MoveToWorld( new Point3D( x2, y2, z2 ), Map.Malas );
				                                cavernmongbatberserker3.Combatant = m;

                                                                m.Send( Network.PlayMusic.GetInstance( MusicName.Medieval ) );

	                                                        AOS.Damage(m, 0, 0, 0, 0, 0, 0 );
				                                Timer.DelayCall( TimeSpan.FromMinutes( 1.0 ), new TimerStateCallback( DeleteCavernMongbatBerserkerQuest1 ), cavernmongbatberserker1 );
				                                Timer.DelayCall( TimeSpan.FromMinutes( 1.0 ), new TimerStateCallback( DeleteCavernMongbatBerserkerQuest2 ), cavernmongbatberserker2 );
				                                Timer.DelayCall( TimeSpan.FromMinutes( 1.0 ), new TimerStateCallback( DeleteCavernMongbatBerserkerQuest3 ), cavernmongbatberserker3 );
                                                           }
                                                     }
                                              }
                                     }
                            }
                       }
                  }
             }

	     private void DeleteBrigandMale1( object brigandmale1 )
	     {
		  BaseCreature mob = (BaseCreature)brigandmale1;
	          Map map = mob.Map;
		  Mobile c = brigandmale1 as Mobile;

		  if ( mob != null || !mob.Deleted )
		  {
			Effects.SendLocationEffect( mob.Location, mob.Map, 0x3728, 10, 10 );
			Effects.PlaySound( mob.Location, mob.Map, 0x1FC );

			mob.Delete();
                  }
             }
	     private void DeleteBrigandMale2( object brigandmale2 )
	     {
		  BaseCreature mob = (BaseCreature)brigandmale2;
	          Map map = mob.Map;
		  Mobile c = brigandmale2 as Mobile;

		  if ( mob != null || !mob.Deleted )
		  {
			Effects.SendLocationEffect( mob.Location, mob.Map, 0x3728, 10, 10 );
			Effects.PlaySound( mob.Location, mob.Map, 0x1FC );

			mob.Delete();
                  }
             }
	     private void DeleteBrigandMale3( object brigandmale3 )
	     {
		  BaseCreature mob = (BaseCreature)brigandmale3;
	          Map map = mob.Map;
		  Mobile c = brigandmale3 as Mobile;

		  if ( mob != null || !mob.Deleted )
		  {
			Effects.SendLocationEffect( mob.Location, mob.Map, 0x3728, 10, 10 );
			Effects.PlaySound( mob.Location, mob.Map, 0x1FC );

			mob.Delete();
                  }
             }
	     private void DeleteBrigandFemale1( object brigandfemale1 )
	     {
		  BaseCreature mob = (BaseCreature)brigandfemale1;
	          Map map = mob.Map;
		  Mobile c = brigandfemale1 as Mobile;

		  if ( mob != null || !mob.Deleted )
		  {
			Effects.SendLocationEffect( mob.Location, mob.Map, 0x3728, 10, 10 );
			Effects.PlaySound( mob.Location, mob.Map, 0x1FC );

			mob.Delete();
                  }
             }
	     private void DeleteBrigandFemale2( object brigandfemale2 )
	     {
		  BaseCreature mob = (BaseCreature)brigandfemale2;
	          Map map = mob.Map;
		  Mobile c = brigandfemale2 as Mobile;

		  if ( mob != null || !mob.Deleted )
		  {
			Effects.SendLocationEffect( mob.Location, mob.Map, 0x3728, 10, 10 );
			Effects.PlaySound( mob.Location, mob.Map, 0x1FC );

			mob.Delete();
                  }
             }
	     private void DeleteBrigandFemale3( object brigandfemale3 )
	     {
		  BaseCreature mob = (BaseCreature)brigandfemale3;
	          Map map = mob.Map;
		  Mobile c = brigandfemale3 as Mobile;

		  if ( mob != null || !mob.Deleted )
		  {
			Effects.SendLocationEffect( mob.Location, mob.Map, 0x3728, 10, 10 );
			Effects.PlaySound( mob.Location, mob.Map, 0x1FC );

			mob.Delete();
                  }
             }

	     private void DeleteCavernMongbatBerserkerQuest1( object cavernmongbatberserker1 )
	     {
		  BaseCreature mob = (BaseCreature)cavernmongbatberserker1;
	          Map map = mob.Map;
		  Mobile c = cavernmongbatberserker1 as Mobile;

		  if ( mob != null || !mob.Deleted )
		  {
			Effects.SendLocationEffect( mob.Location, mob.Map, 0x3728, 10, 10 );
			Effects.PlaySound( mob.Location, mob.Map, 0x1FC );

			mob.Delete();
                  }
             }
	     private void DeleteCavernMongbatBerserkerQuest2( object cavernmongbatberserker2 )
	     {
		  BaseCreature mob = (BaseCreature)cavernmongbatberserker2;
	          Map map = mob.Map;
		  Mobile c = cavernmongbatberserker2 as Mobile;

		  if ( mob != null || !mob.Deleted )
		  {
			Effects.SendLocationEffect( mob.Location, mob.Map, 0x3728, 10, 10 );
			Effects.PlaySound( mob.Location, mob.Map, 0x1FC );

			mob.Delete();
                  }
             }
	     private void DeleteCavernMongbatBerserkerQuest3( object cavernmongbatberserker3 )
	     {
		  BaseCreature mob = (BaseCreature)cavernmongbatberserker3;
	          Map map = mob.Map;
		  Mobile c = cavernmongbatberserker3 as Mobile;

		  if ( mob != null || !mob.Deleted )
		  {
			Effects.SendLocationEffect( mob.Location, mob.Map, 0x3728, 10, 10 );
			Effects.PlaySound( mob.Location, mob.Map, 0x1FC );

			mob.Delete();
                  }
             }
       }
}