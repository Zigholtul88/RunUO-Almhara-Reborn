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
     public class BoulderTunnelRegion : DamagingRegion
     {
            public BoulderTunnelRegion( XmlElement xml, Map map, Region parent ) : base( xml, map, parent )
	    {
	    }

            public override void OnEnter( Mobile m )
            {
        	    m.SendMessage("You have entered Boulder Tunnel.");

                    base.OnEnter( m );
            }

            public override void OnExit( Mobile m )
            {
        	   m.SendMessage("You have left Boulder Tunnel.");

                   base.OnExit( m );
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
		            if ( Utility.RandomDouble() < 0.001 )
                            {
                                 m.PlaySound(Utility.RandomList( 0x014,0x15,0x016,0x5C7 ) );
	                         AOS.Damage(m, 0, 0, 0, 0, 0, 0 );
                            }

		            PlayerMobile player = m as PlayerMobile;
			    QuestSystem qs = player.Quest;

		            if ( qs is StolenNecklaceQuest )
		            {
                                     if ( qs.IsObjectiveInProgress( typeof( ReturnStolenNecklaceObjective ) ) )
			             {
                                              // Brigand Ambush 1
		                              if ( Utility.RandomDouble() < 0.015 )
                                              {
			                             if ( m.Map == Map.Tokuno )
			                             {
				                           int x1 = m.X + 8;
				                           int y1 = m.Y + 8;
				                           int z1 = Map.Tokuno.GetAverageZ( x1, y1 );

				                           if ( Map.Tokuno.CanSpawnMobile( x1, y1, z1 ) )
				                           {
				                                BaseCreature brigandmale = new BrigandMaleQuest();
				                                BaseCreature brigandmale2 = new BrigandMaleQuest();
					                        brigandmale.MoveToWorld( new Point3D( x1, y1, z1 ), Map.Tokuno );
					                        brigandmale2.MoveToWorld( new Point3D( x1, y1, z1 ), Map.Tokuno );
				                                brigandmale.Combatant = m;
				                                brigandmale2.Combatant = m;

	                                                        AOS.Damage(m, 0, 0, 0, 0, 0, 0 );
				                                Timer.DelayCall( TimeSpan.FromMinutes( 1.0 ), new TimerStateCallback( DeleteBrigandMale ), brigandmale );
				                                Timer.DelayCall( TimeSpan.FromMinutes( 1.0 ), new TimerStateCallback( DeleteBrigandMale2 ), brigandmale2 );
                                                           }
                                                     }
                                              }

                                              // Brigand Ambush 2
		                              if ( Utility.RandomDouble() < 0.015 )
                                              {
			                             if ( m.Map == Map.Tokuno )
			                             {
				                           int x2 = m.X - 8;
				                           int y2 = m.Y - 8;
				                           int z2 = Map.Tokuno.GetAverageZ( x2, y2 );

				                           if ( Map.Tokuno.CanSpawnMobile( x2, y2, z2 ) )
				                           {
				                                BaseCreature brigandfemale = new BrigandFemaleQuest();
				                                BaseCreature brigandfemale2 = new BrigandFemaleQuest();
					                        brigandfemale.MoveToWorld( new Point3D( x2, y2, z2 ), Map.Tokuno );
					                        brigandfemale2.MoveToWorld( new Point3D( x2, y2, z2 ), Map.Tokuno );
				                                brigandfemale.Combatant = m;
				                                brigandfemale2.Combatant = m;

	                                                        AOS.Damage(m, 0, 0, 0, 0, 0, 0 );
				                                Timer.DelayCall( TimeSpan.FromMinutes( 1.0 ), new TimerStateCallback( DeleteBrigandFemale ), brigandfemale );
				                                Timer.DelayCall( TimeSpan.FromMinutes( 1.0 ), new TimerStateCallback( DeleteBrigandFemale2 ), brigandfemale2 );
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
			                             if ( m.Map == Map.Tokuno )
			                             {
				                           int x1 = m.X + 8;
				                           int y1 = m.Y + 8;
				                           int z1 = Map.Tokuno.GetAverageZ( x1, y1 );

				                           if ( Map.Tokuno.CanSpawnMobile( x1, y1, z1 ) )
				                           {
				                                BaseCreature cavernmongbatberserker = new CavernMongbatBerserkerQuest();
					                        cavernmongbatberserker.MoveToWorld( new Point3D( x1, y1, z1 ), Map.Tokuno );
				                                cavernmongbatberserker.Combatant = m;

	                                                        AOS.Damage(m, 0, 0, 0, 0, 0, 0 );
				                                Timer.DelayCall( TimeSpan.FromMinutes( 1.0 ), new TimerStateCallback( DeleteCavernMongbatBerserkerQuest ), cavernmongbatberserker );
                                                           }
                                                     }
                                              }

                                              // Mongbat Ambush 2
		                              if ( Utility.RandomDouble() < 0.015 )
                                              {
			                             if ( m.Map == Map.Tokuno )
			                             {
				                           int x2 = m.X - 8;
				                           int y2 = m.Y - 8;
				                           int z2 = Map.Tokuno.GetAverageZ( x2, y2 );

				                           if ( Map.Tokuno.CanSpawnMobile( x2, y2, z2 ) )
				                           {
				                                BaseCreature cavernmongbatberserker = new CavernMongbatBerserkerQuest();
					                        cavernmongbatberserker.MoveToWorld( new Point3D( x2, y2, z2 ), Map.Tokuno );
				                                cavernmongbatberserker.Combatant = m;

	                                                        AOS.Damage(m, 0, 0, 0, 0, 0, 0 );
				                                Timer.DelayCall( TimeSpan.FromMinutes( 1.0 ), new TimerStateCallback( DeleteCavernMongbatBerserkerQuest ), cavernmongbatberserker );
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
       }
}