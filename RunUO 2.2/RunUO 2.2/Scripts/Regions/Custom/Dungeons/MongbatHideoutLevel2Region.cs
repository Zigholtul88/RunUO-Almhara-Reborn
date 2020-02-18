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
	public class MongbatHideoutLevel2Region : DamagingRegion
	{
	     public MongbatHideoutLevel2Region( XmlElement xml, Map map, Region parent ) : base( xml, map, parent )
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
                     return TimeSpan.FromSeconds(30);
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
		            if ( Utility.RandomDouble() < 0.01 )
                            {
                                 m.PlaySound(Utility.RandomList( 0x014,0x15,0x016,0x5C7 ) );
	                         AOS.Damage(m, 0, 0, 0, 0, 0, 0 );
                            }

                            // sfx noises
		            if ( Utility.RandomDouble() < 0.02 )
                            {
                                 m.PlaySound(Utility.RandomList( 0x0F5,0x0F7,0x0F8,0x0FB ) );
	                         AOS.Damage(m, 0, 0, 0, 0, 0, 0 );
                            }

                            // water drips
		            if ( Utility.RandomDouble() < 0.01 )
                            {
                                 m.PlaySound(Utility.RandomList( 0x022,0x023,0x024 ) );
	                         AOS.Damage(m, 0, 0, 0, 0, 0, 0 );
                            }

                            // Cavern Mongbat Archer 1
		            if ( Utility.RandomDouble() < 0.0001 )
                            {
			          if ( m.Map == Map.Tokuno )
			          {
				         int x1 = m.X + 6;
				         int y1 = m.Y + 6;
				         int z1 = Map.Tokuno.GetAverageZ( x1, y1 );

				         if ( Map.Tokuno.CanSpawnMobile( x1, y1, z1 ) )
				         {
				              BaseCreature cavernmongbatarcher1 = new CavernMongbatArcher();
					      cavernmongbatarcher1.MoveToWorld( new Point3D( x1, y1, z1 ), Map.Tokuno );
				              cavernmongbatarcher1.Combatant = m;
			                      cavernmongbatarcher1.PlaySound( 422 );

				              BaseCreature cavernmongbatarcher2 = new CavernMongbatArcher();
					      cavernmongbatarcher2.MoveToWorld( new Point3D( x1, y1, z1 ), Map.Tokuno );
				              cavernmongbatarcher2.Combatant = m;
			                      cavernmongbatarcher2.PlaySound( 422 );

	                                      AOS.Damage(m, 0, 0, 0, 0, 0, 0 );
				              Timer.DelayCall( TimeSpan.FromMinutes( 10.0 ), new TimerStateCallback( DeleteCavernMongbatArcher1 ), cavernmongbatarcher1 );
				              Timer.DelayCall( TimeSpan.FromMinutes( 10.0 ), new TimerStateCallback( DeleteCavernMongbatArcher2 ), cavernmongbatarcher2 );
                                         }
                                  }
                            }

                            // Cavern Mongbat Archer 2
		            if ( Utility.RandomDouble() < 0.0001 )
                            {
			          if ( m.Map == Map.Tokuno )
			          {
				         int x2 = m.X - 6;
				         int y2 = m.Y - 6;
				         int z2 = Map.Tokuno.GetAverageZ( x2, y2 );

				         if ( Map.Tokuno.CanSpawnMobile( x2, y2, z2 ) )
				         {
				              BaseCreature cavernmongbatarcher1 = new CavernMongbatArcher();
					      cavernmongbatarcher1.MoveToWorld( new Point3D( x2, y2, z2 ), Map.Tokuno );
				              cavernmongbatarcher1.Combatant = m;
			                      cavernmongbatarcher1.PlaySound( 422 );

				              BaseCreature cavernmongbatarcher2 = new CavernMongbatArcher();
					      cavernmongbatarcher2.MoveToWorld( new Point3D( x2, y2, z2 ), Map.Tokuno );
				              cavernmongbatarcher2.Combatant = m;
			                      cavernmongbatarcher2.PlaySound( 422 );

	                                      AOS.Damage(m, 0, 0, 0, 0, 0, 0 );
				              Timer.DelayCall( TimeSpan.FromMinutes( 10.0 ), new TimerStateCallback( DeleteCavernMongbatArcher1 ), cavernmongbatarcher1 );
				              Timer.DelayCall( TimeSpan.FromMinutes( 10.0 ), new TimerStateCallback( DeleteCavernMongbatArcher2 ), cavernmongbatarcher2 );
                                         }
                                  }
                            }

                            // Cavern Mongbat Berserker Ambush 1
		            if ( Utility.RandomDouble() < 0.0001 )
                            {
			          if ( m.Map == Map.Tokuno )
			          {
				         int x1 = m.X + 6;
				         int y1 = m.Y + 6;
				         int z1 = Map.Tokuno.GetAverageZ( x1, y1 );

				         if ( Map.Tokuno.CanSpawnMobile( x1, y1, z1 ) )
				         {
				              BaseCreature cavernmongbatberserker1 = new CavernMongbatBerserker();
					      cavernmongbatberserker1.MoveToWorld( new Point3D( x1, y1, z1 ), Map.Tokuno );
				              cavernmongbatberserker1.Combatant = m;
			                      cavernmongbatberserker1.PlaySound( 422 );

				              BaseCreature cavernmongbatberserker2 = new CavernMongbatBerserker();
					      cavernmongbatberserker2.MoveToWorld( new Point3D( x1, y1, z1 ), Map.Tokuno );
				              cavernmongbatberserker2.Combatant = m;
			                      cavernmongbatberserker2.PlaySound( 422 );

				              BaseCreature cavernmongbatberserker3 = new CavernMongbatBerserker();
					      cavernmongbatberserker3.MoveToWorld( new Point3D( x1, y1, z1 ), Map.Tokuno );
				              cavernmongbatberserker3.Combatant = m;
			                      cavernmongbatberserker3.PlaySound( 422 );

	                                      AOS.Damage(m, 0, 0, 0, 0, 0, 0 );
				              Timer.DelayCall( TimeSpan.FromMinutes( 10.0 ), new TimerStateCallback( DeleteCavernMongbatBerserker1 ), cavernmongbatberserker1 );
				              Timer.DelayCall( TimeSpan.FromMinutes( 10.0 ), new TimerStateCallback( DeleteCavernMongbatBerserker2 ), cavernmongbatberserker2 );
				              Timer.DelayCall( TimeSpan.FromMinutes( 10.0 ), new TimerStateCallback( DeleteCavernMongbatBerserker3 ), cavernmongbatberserker3 );
                                         }
                                  }
                            }

                            // Cavern Mongbat Berserker Ambush 2
		            if ( Utility.RandomDouble() < 0.0001 )
                            {
			          if ( m.Map == Map.Tokuno )
			          {
				         int x2 = m.X - 6;
				         int y2 = m.Y - 6;
				         int z2 = Map.Tokuno.GetAverageZ( x2, y2 );

				         if ( Map.Tokuno.CanSpawnMobile( x2, y2, z2 ) )
				         {
				              BaseCreature cavernmongbatberserker1 = new CavernMongbatBerserker();
					      cavernmongbatberserker1.MoveToWorld( new Point3D( x2, y2, z2 ), Map.Tokuno );
				              cavernmongbatberserker1.Combatant = m;
			                      cavernmongbatberserker1.PlaySound( 422 );

				              BaseCreature cavernmongbatberserker2 = new CavernMongbatBerserker();
					      cavernmongbatberserker2.MoveToWorld( new Point3D( x2, y2, z2 ), Map.Tokuno );
				              cavernmongbatberserker2.Combatant = m;
			                      cavernmongbatberserker2.PlaySound( 422 );

				              BaseCreature cavernmongbatberserker3 = new CavernMongbatBerserker();
					      cavernmongbatberserker3.MoveToWorld( new Point3D( x2, y2, z2 ), Map.Tokuno );
				              cavernmongbatberserker3.Combatant = m;
			                      cavernmongbatberserker3.PlaySound( 422 );

	                                      AOS.Damage(m, 0, 0, 0, 0, 0, 0 );
				              Timer.DelayCall( TimeSpan.FromMinutes( 10.0 ), new TimerStateCallback( DeleteCavernMongbatBerserker1 ), cavernmongbatberserker1 );
				              Timer.DelayCall( TimeSpan.FromMinutes( 10.0 ), new TimerStateCallback( DeleteCavernMongbatBerserker2 ), cavernmongbatberserker2 );
				              Timer.DelayCall( TimeSpan.FromMinutes( 10.0 ), new TimerStateCallback( DeleteCavernMongbatBerserker3 ), cavernmongbatberserker3 );
                                         }
                                  }
                            }

                            // Cavern Mongbat Plantkeeper Ambush 1
		            if ( Utility.RandomDouble() < 0.0001 )
                            {
			          if ( m.Map == Map.Tokuno )
			          {
				         int x1 = m.X + 6;
				         int y1 = m.Y + 6;
				         int z1 = Map.Tokuno.GetAverageZ( x1, y1 );

				         if ( Map.Tokuno.CanSpawnMobile( x1, y1, z1 ) )
				         {
				              BaseCreature cavernmongbatplantkeeper = new CavernMongbatPlantkeeper();
					      cavernmongbatplantkeeper.MoveToWorld( new Point3D( x1, y1, z1 ), Map.Tokuno );
			                      cavernmongbatplantkeeper.PlaySound( 422 );

	                                      AOS.Damage(m, 0, 0, 0, 0, 0, 0 );
				              Timer.DelayCall( TimeSpan.FromMinutes( 10.0 ), new TimerStateCallback( DeleteCavernMongbatPlantkeeper ), cavernmongbatplantkeeper );
                                         }
                                  }
                            }

                            // Cavern Mongbat Plantkeeper Ambush 2
		            if ( Utility.RandomDouble() < 0.0001 )
                            {
			          if ( m.Map == Map.Tokuno )
			          {
				         int x2 = m.X - 6;
				         int y2 = m.Y - 6;
				         int z2 = Map.Tokuno.GetAverageZ( x2, y2 );

				         if ( Map.Tokuno.CanSpawnMobile( x2, y2, z2 ) )
				         {
				              BaseCreature cavernmongbatplantkeeper = new CavernMongbatPlantkeeper();
					      cavernmongbatplantkeeper.MoveToWorld( new Point3D( x2, y2, z2 ), Map.Tokuno );
			                      cavernmongbatplantkeeper.PlaySound( 422 );

	                                      AOS.Damage(m, 0, 0, 0, 0, 0, 0 );
				              Timer.DelayCall( TimeSpan.FromMinutes( 10.0 ), new TimerStateCallback( DeleteCavernMongbatPlantkeeper ), cavernmongbatplantkeeper );
                                         }
                                  }
                            }
                      }
                 }
            }

	    private void DeleteCavernMongbatArcher1( object cavernmongbatarcher1 )
	    {
		  BaseCreature mob = (BaseCreature)cavernmongbatarcher1;
	          Map map = mob.Map;
		  Mobile c = cavernmongbatarcher1 as Mobile;

		  if ( mob != null || !mob.Deleted )
		  {
			Effects.SendLocationEffect( mob.Location, mob.Map, 0x3728, 10, 10 );
			Effects.PlaySound( mob.Location, mob.Map, 0x1FC );

			mob.Delete();
                  }
            }

	    private void DeleteCavernMongbatArcher2( object cavernmongbatarcher2 )
	    {
		  BaseCreature mob = (BaseCreature)cavernmongbatarcher2;
	          Map map = mob.Map;
		  Mobile c = cavernmongbatarcher2 as Mobile;

		  if ( mob != null || !mob.Deleted )
		  {
			Effects.SendLocationEffect( mob.Location, mob.Map, 0x3728, 10, 10 );
			Effects.PlaySound( mob.Location, mob.Map, 0x1FC );

			mob.Delete();
                  }
            }

	    private void DeleteCavernMongbatBerserker1( object cavernmongbatberserker1 )
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

	    private void DeleteCavernMongbatBerserker2( object cavernmongbatberserker2 )
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

	    private void DeleteCavernMongbatBerserker3( object cavernmongbatberserker3 )
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

	    private void DeleteCavernMongbatPlantkeeper( object cavernmongbatplantkeeper )
	    {
		  BaseCreature mob = (BaseCreature)cavernmongbatplantkeeper;
	          Map map = mob.Map;
		  Mobile c = cavernmongbatplantkeeper as Mobile;

		  if ( mob != null || !mob.Deleted )
		  {
			Effects.SendLocationEffect( mob.Location, mob.Map, 0x3728, 10, 10 );
			Effects.PlaySound( mob.Location, mob.Map, 0x1FC );

			mob.Delete();
                  }
            }
      }
}

