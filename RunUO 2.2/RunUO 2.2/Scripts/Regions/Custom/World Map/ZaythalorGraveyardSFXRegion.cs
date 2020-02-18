using System;
using System.Collections;
using System.Collections.Generic;
using System.Xml;
using Server;
using Server.ContextMenus;
using Server.Network;
using Server.Items;
using Server.Mobiles;
using Server.Targeting;

namespace Server.Regions
{
	public class ZaythalorGraveyardSFXRegion : LandscapeRegion
	{
	     public ZaythalorGraveyardSFXRegion( XmlElement xml, Map map, Region parent ) : base( xml, map, parent )
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
        	    m.SendMessage("You have entered Zaythalor Graveyard.");
                    m.Send( Network.PlayMusic.GetInstance( MusicName.Dungeon9 ) );

                    base.OnEnter( m );
             }

             public override void OnExit( Mobile m )
             {
        	    m.SendMessage("You have left Zaythalor Graveyard.");

                    base.OnExit( m );
             }

             public override void Damage( Mobile m )
             {
                  
             base.Damage(m );

             if (m.Alive)
             {
		   BaseEquipableLight lightsource = m.FindItemOnLayer( Layer.TwoHanded ) as BaseEquipableLight;

	           if ( lightsource != null && lightsource.Burning )
	           {
                            // Wind
		            if ( Utility.RandomDouble() < 0.09 )
                            {
                                 m.PlaySound(Utility.RandomList( 0x014,0x15,0x016,0x5C7 ) );
	                         AOS.Damage(m, 0, 0, 0, 0, 0, 0 );
                            }
                   }
                   else
                   {
                            // Wind
		            if ( Utility.RandomDouble() < 0.09 )
                            {
                                 m.PlaySound(Utility.RandomList( 0x014,0x15,0x016,0x5C7 ) );
	                         AOS.Damage(m, 0, 0, 0, 0, 0, 0 );
                            }

                            // Anchimayen Ambush 1
		            if ( Utility.RandomDouble() < 0.00002 )
                            {
			          if ( m.Map == Map.Malas )
			          {
				         int x1 = m.X + 10;
				         int y1 = m.Y + 10;
				         int z1 = Map.Malas.GetAverageZ( x1, y1 );

				         if ( Map.Malas.CanSpawnMobile( x1, y1, z1 ) )
				         {
				              BaseCreature ghoul = new Anchimayen();
					      ghoul.MoveToWorld( new Point3D( x1, y1, z1 ), Map.Malas );
			                      ghoul.PlaySound( 1534 );

	                                      AOS.Damage(m, 0, 0, 0, 0, 0, 0 );
				              Timer.DelayCall( TimeSpan.FromMinutes( 3.0 ), new TimerStateCallback( DeleteGhoul ), ghoul );
                                         }
                                  }
                            }

                            // Anchimayen Ambush 2
		            if ( Utility.RandomDouble() < 0.00002 )
                            {
			          if ( m.Map == Map.Malas )
			          {
				         int x2 = m.X - 10;
				         int y2 = m.Y - 10;
				         int z2 = Map.Malas.GetAverageZ( x2, y2 );

				         if ( Map.Malas.CanSpawnMobile( x2, y2, z2 ) )
				         {
				              BaseCreature ghoul = new Anchimayen();
					      ghoul.MoveToWorld( new Point3D( x2, y2, z2 ), Map.Malas );
			                      ghoul.PlaySound( 1534 );

	                                      AOS.Damage(m, 0, 0, 0, 0, 0, 0 );
				              Timer.DelayCall( TimeSpan.FromMinutes( 3.0 ), new TimerStateCallback( DeleteGhoul ), ghoul );
                                         }
                                  }
                            }

                            // Gualichu Ambush 1
		            if ( Utility.RandomDouble() < 0.00002 )
                            {
			          if ( m.Map == Map.Malas )
			          {
				         int x1 = m.X + 8;
				         int y1 = m.Y + 8;
				         int z1 = Map.Malas.GetAverageZ( x1, y1 );

				         if ( Map.Malas.CanSpawnMobile( x1, y1, z1 ) )
				         {
				              BaseCreature skeleton = new Gualichu();
					      skeleton.MoveToWorld( new Point3D( x1, y1, z1 ), Map.Malas );
			                      skeleton.PlaySound( 0x48D );

	                                      AOS.Damage(m, 0, 0, 0, 0, 0, 0 );
				              Timer.DelayCall( TimeSpan.FromMinutes( 3.0 ), new TimerStateCallback( DeleteSkeleton ), skeleton );
                                         }
                                  }
                            }

                            // Gualichu Ambush 2
		            if ( Utility.RandomDouble() < 0.00002 )
                            {
			          if ( m.Map == Map.Malas )
			          {
				         int x2 = m.X - 8;
				         int y2 = m.Y - 8;
				         int z2 = Map.Malas.GetAverageZ( x2, y2 );

				         if ( Map.Malas.CanSpawnMobile( x2, y2, z2 ) )
				         {
				              BaseCreature skeleton = new Gualichu();
					      skeleton.MoveToWorld( new Point3D( x2, y2, z2 ), Map.Malas );
			                      skeleton.PlaySound( 0x48D );

	                                      AOS.Damage(m, 0, 0, 0, 0, 0, 0 );
				              Timer.DelayCall( TimeSpan.FromMinutes( 3.0 ), new TimerStateCallback( DeleteSkeleton ), skeleton );
                                         }
                                  }
                            }

                            // Wekufe Ambush 1
		            if ( Utility.RandomDouble() < 0.00002 )
                            {
			          if ( m.Map == Map.Malas )
			          {
				         int x1 = m.X + 20;
				         int y1 = m.Y + 20;
				         int z1 = Map.Malas.GetAverageZ( x1, y1 );

				         if ( Map.Malas.CanSpawnMobile( x1, y1, z1 ) )
				         {
				              BaseCreature wraith = new Wekufe();
					      wraith.MoveToWorld( new Point3D( x1, y1, z1 ), Map.Malas );
			                      wraith.PlaySound( 748 );

	                                      AOS.Damage(m, 0, 0, 0, 0, 0, 0 );
				              Timer.DelayCall( TimeSpan.FromMinutes( 3.0 ), new TimerStateCallback( DeleteWraith ), wraith );
                                         }
                                  }
                            }

                            // Wekufe Ambush 2
		            if ( Utility.RandomDouble() < 0.00002 )
                            {
			          if ( m.Map == Map.Malas )
			          {
				         int x2 = m.X - 20;
				         int y2 = m.Y - 20;
				         int z2 = Map.Malas.GetAverageZ( x2, y2 );

				         if ( Map.Malas.CanSpawnMobile( x2, y2, z2 ) )
				         {
				              BaseCreature wraith = new Wekufe();
					      wraith.MoveToWorld( new Point3D( x2, y2, z2 ), Map.Malas );
			                      wraith.PlaySound( 748 );

	                                      AOS.Damage(m, 0, 0, 0, 0, 0, 0 );
				              Timer.DelayCall( TimeSpan.FromMinutes( 3.0 ), new TimerStateCallback( DeleteWraith ), wraith );
                                         }
                                  }
                            }

                            // Umkhovu Ambush 1
		            if ( Utility.RandomDouble() < 0.00002 )
                            {
			          if ( m.Map == Map.Malas )
			          {
				         int x1 = m.X + 12;
				         int y1 = m.Y + 12;
				         int z1 = Map.Malas.GetAverageZ( x1, y1 );

				         if ( Map.Malas.CanSpawnMobile( x1, y1, z1 ) )
				         {
				              BaseCreature zombie = new Umkhovu();
					      zombie.MoveToWorld( new Point3D( x1, y1, z1 ), Map.Malas );
			                      zombie.PlaySound( 471 );

	                                      AOS.Damage(m, 0, 0, 0, 0, 0, 0 );
				              Timer.DelayCall( TimeSpan.FromMinutes( 3.0 ), new TimerStateCallback( DeleteZombie ), zombie );
                                         }
                                  }
                            }

                            // Umkhovu Ambush 2
		            if ( Utility.RandomDouble() < 0.00002 )
                            {
			          if ( m.Map == Map.Malas )
			          {
				         int x2 = m.X - 12;
				         int y2 = m.Y - 12;
				         int z2 = Map.Malas.GetAverageZ( x2, y2 );

				         if ( Map.Malas.CanSpawnMobile( x2, y2, z2 ) )
				         {
				              BaseCreature zombie = new Umkhovu();
					      zombie.MoveToWorld( new Point3D( x2, y2, z2 ), Map.Malas );
			                      zombie.PlaySound( 471 );

	                                      AOS.Damage(m, 0, 0, 0, 0, 0, 0 );
				              Timer.DelayCall( TimeSpan.FromMinutes( 3.0 ), new TimerStateCallback( DeleteZombie ), zombie );
                                         }
                                  }
                            }
                      }
                 }
            }

	    private void DeleteGhoul( object ghoul )
	    {
		  BaseCreature mob = (BaseCreature)ghoul;
	          Map map = mob.Map;
		  Mobile c = ghoul as Mobile;

		  if ( mob != null || !mob.Deleted )
		  {
			Effects.SendLocationEffect( mob.Location, mob.Map, 0x3728, 10, 10 );
			Effects.PlaySound( mob.Location, mob.Map, 0x1FC );

			mob.Delete();
                  }
            }

	    private void DeleteSkeleton( object skeleton )
	    {
		  BaseCreature mob = (BaseCreature)skeleton;
	          Map map = mob.Map;
		  Mobile c = skeleton as Mobile;

		  if ( mob != null || !mob.Deleted )
		  {
			Effects.SendLocationEffect( mob.Location, mob.Map, 0x3728, 10, 10 );
			Effects.PlaySound( mob.Location, mob.Map, 0x1FC );

			mob.Delete();
                  }
            }

	    private void DeleteWraith( object wraith )
	    {
		  BaseCreature mob = (BaseCreature)wraith;
	          Map map = mob.Map;
		  Mobile c = wraith as Mobile;

		  if ( mob != null || !mob.Deleted )
		  {
			Effects.SendLocationEffect( mob.Location, mob.Map, 0x3728, 10, 10 );
			Effects.PlaySound( mob.Location, mob.Map, 0x1FC );

			mob.Delete();
                  }
            }

	    private void DeleteZombie( object zombie )
	    {
		  BaseCreature mob = (BaseCreature)zombie;
	          Map map = mob.Map;
		  Mobile c = zombie as Mobile;

		  if ( mob != null || !mob.Deleted )
		  {
			Effects.SendLocationEffect( mob.Location, mob.Map, 0x3728, 10, 10 );
			Effects.PlaySound( mob.Location, mob.Map, 0x1FC );

			mob.Delete();
                  }
            }
      }
}

