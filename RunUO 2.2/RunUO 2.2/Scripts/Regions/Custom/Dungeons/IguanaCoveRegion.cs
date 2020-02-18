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
	public class IguanaCoveRegion : DamagingRegion
	{
	     public IguanaCoveRegion( XmlElement xml, Map map, Region parent ) : base( xml, map, parent )
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

                            // jungle sfx noises
		            if ( Utility.RandomDouble() < 0.02 )
                            {
                                 m.PlaySound(Utility.RandomList( 0x003,0x004,0x005,0x00C,0x00D,0x00E,0x00F ) );
	                         AOS.Damage(m, 0, 0, 0, 0, 0, 0 );
                            }

                            // water drips
		            if ( Utility.RandomDouble() < 0.01 )
                            {
                                 m.PlaySound(Utility.RandomList( 0x022,0x023,0x024 ) );
	                         AOS.Damage(m, 0, 0, 0, 0, 0, 0 );
                            }

                            // Random Encounter 1
		            if ( Utility.RandomDouble() < 0.0001 )
                            {
			           if ( m.Map == Map.Tokuno )
			           {
				         int x1 = m.X + 10;
				         int y1 = m.Y + 10;
				         int z1 = Map.Tokuno.GetAverageZ( x1, y1 );

				         if ( Map.Tokuno.CanSpawnMobile( x1, y1, z1 ) )
				         {
				         BaseCreature encountera;
			                 switch ( Utility.Random( 8 ) )
			                 {
					      default:
                                              case 0: encountera = new BullFrog(); break;
                                              case 1: encountera = new GiantSerpent(); break;
                                              case 2: encountera = new Lizardman(); break;
                                              case 3: encountera = new LizardmanGuardian(); break;
                                              case 4: encountera = new LizardmanRanger(); break;
                                              case 5: encountera = new LizardmanWizard(); break;
                                              case 6: encountera = new Myconid(); break;
                                              case 7: encountera = new WaterLizardScout(); break;
			                 }
					      encountera.MoveToWorld( new Point3D( x1, y1, z1 ), Map.Tokuno );

	                                      AOS.Damage(m, 0, 0, 0, 0, 0, 0 );
				              Timer.DelayCall( TimeSpan.FromMinutes( 10.0 ), new TimerStateCallback( DeleteEncounterA ), encountera );
                                         }
                                   }
                            }

                            // Random Encounter 2
		            if ( Utility.RandomDouble() < 0.0001 )
                            {
			           if ( m.Map == Map.Tokuno )
			           {
				         int x2 = m.X - 10;
				         int y2 = m.Y - 10;
				         int z2 = Map.Tokuno.GetAverageZ( x2, y2 );

				         if ( Map.Tokuno.CanSpawnMobile( x2, y2, z2 ) )
				         {
				         BaseCreature encountera;
			                 switch ( Utility.Random( 8 ) )
			                 {
					      default:
                                              case 0: encountera = new BullFrog(); break;
                                              case 1: encountera = new GiantSerpent(); break;
                                              case 2: encountera = new Lizardman(); break;
                                              case 3: encountera = new LizardmanGuardian(); break;
                                              case 4: encountera = new LizardmanRanger(); break;
                                              case 5: encountera = new LizardmanWizard(); break;
                                              case 6: encountera = new Myconid(); break;
                                              case 7: encountera = new WaterLizardScout(); break;
			                 }
					      encountera.MoveToWorld( new Point3D( x2, y2, z2 ), Map.Tokuno );

	                                      AOS.Damage(m, 0, 0, 0, 0, 0, 0 );
				              Timer.DelayCall( TimeSpan.FromMinutes( 10.0 ), new TimerStateCallback( DeleteEncounterA ), encountera );
                                         }
                                   }
                            }
                       }
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
		  else if ( mob != null || !mob.Deleted )
		  {
			Effects.SendLocationEffect( mob.Location, mob.Map, 0x3728, 10, 10 );
			Effects.PlaySound( mob.Location, mob.Map, 0x1FC );

			mob.Delete();
                  }
            }
      }
}

