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
	public class MongbatHideoutLevel1Region : DamagingRegion
	{
	         public MongbatHideoutLevel1Region( XmlElement xml, Map map, Region parent ) : base( xml, map, parent )
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

                 public override void OnEnter( Mobile m )
                 {
                        if ( m is PlayerMobile )
                        {
                                m.Send( Network.PlayMusic.GetInstance( MusicName.Cave01 ) );
                        }

                        base.OnEnter( m );
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

                            // Cavern Mongbat Scout Ambush 1
		            if ( Utility.RandomDouble() < 0.0001 )
                            {
			          if ( m.Map == Map.Tokuno )
			          {
				         int x1 = m.X + 6;
				         int y1 = m.Y + 6;
				         int z1 = Map.Tokuno.GetAverageZ( x1, y1 );

				         if ( Map.Tokuno.CanSpawnMobile( x1, y1, z1 ) )
				         {
				              BaseCreature cavernmongbatscout = new CavernMongbatScout();
					      cavernmongbatscout.MoveToWorld( new Point3D( x1, y1, z1 ), Map.Tokuno );
				              cavernmongbatscout.Combatant = m;
			                      cavernmongbatscout.PlaySound( 422 );

	                                      AOS.Damage(m, 0, 0, 0, 0, 0, 0 );
				              Timer.DelayCall( TimeSpan.FromMinutes( 10.0 ), new TimerStateCallback( DeleteCavernMongbatScout ), cavernmongbatscout );
                                         }
                                  }
                            }

                            // Cavern Mongbat Scout Ambush 2
		            if ( Utility.RandomDouble() < 0.0001 )
                            {
			          if ( m.Map == Map.Tokuno )
			          {
				         int x2 = m.X - 6;
				         int y2 = m.Y - 6;
				         int z2 = Map.Tokuno.GetAverageZ( x2, y2 );

				         if ( Map.Tokuno.CanSpawnMobile( x2, y2, z2 ) )
				         {
				              BaseCreature cavernmongbatscout = new CavernMongbatScout();
					      cavernmongbatscout.MoveToWorld( new Point3D( x2, y2, z2 ), Map.Tokuno );
				              cavernmongbatscout.Combatant = m;
			                      cavernmongbatscout.PlaySound( 422 );

	                                      AOS.Damage(m, 0, 0, 0, 0, 0, 0 );
				              Timer.DelayCall( TimeSpan.FromMinutes( 10.0 ), new TimerStateCallback( DeleteCavernMongbatScout ), cavernmongbatscout );
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

	    private void DeleteCavernMongbatScout( object cavernmongbatscout )
	    {
		  BaseCreature mob = (BaseCreature)cavernmongbatscout;
	          Map map = mob.Map;
		  Mobile c = cavernmongbatscout as Mobile;

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

