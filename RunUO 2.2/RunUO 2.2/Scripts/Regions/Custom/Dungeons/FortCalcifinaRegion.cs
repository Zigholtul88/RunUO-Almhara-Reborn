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
	public class FortCalcifinaRegion : DamagingRegion
	{
		 public FortCalcifinaRegion( XmlElement xml, Map map, Region parent ) : base( xml, map, parent )
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

                 public override void OnEnter( Mobile m )
                 {
                        if ( m is PlayerMobile )
                        {
                                m.Send( Network.PlayMusic.GetInstance( MusicName.Dungeon2 ) );
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
                        else
                        {
                            // Random Encounter 1
		            if ( Utility.RandomDouble() < 0.0001 )
                            {
			           if ( m.Map == Map.Ilshenar )
			           {
				         int x1 = m.X + 5;
				         int y1 = m.Y + 5;
				         int z1 = Map.Ilshenar.GetAverageZ( x1, y1 );

				         if ( Map.Ilshenar.CanSpawnMobile( x1, y1, z1 ) )
				         {
				         BaseCreature encountera;
			                 switch ( Utility.Random( 6 ) )
			                 {
					      default:
                                              case 0: encountera = new AutumnwoodMinotaur(); break;
                                              case 1: encountera = new MoundOfMaggots(); break;
                                              case 2: encountera = new OrcBomber(); break;
                                              case 3: encountera = new OrcCaptain(); break;
                                              case 4: encountera = new OrcishLord(); break;
                                              case 5: encountera = new OrcishMage(); break;
			                 }
					      encountera.MoveToWorld( new Point3D( x1, y1, z1 ), Map.Ilshenar );

	                                      AOS.Damage(m, 0, 0, 0, 0, 0, 0 );
				              Timer.DelayCall( TimeSpan.FromMinutes( 10.0 ), new TimerStateCallback( DeleteEncounterA ), encountera );
                                         }
                                   }
                            }

                            // Random Encounter 2
		            if ( Utility.RandomDouble() < 0.0001 )
                            {
			           if ( m.Map == Map.Ilshenar )
			           {
				         int x2 = m.X - 5;
				         int y2 = m.Y - 5;
				         int z2 = Map.Ilshenar.GetAverageZ( x2, y2 );

				         if ( Map.Ilshenar.CanSpawnMobile( x2, y2, z2 ) )
				         {
				         BaseCreature encountera;
			                 switch ( Utility.Random( 6 ) )
			                 {
					      default:
                                              case 0: encountera = new AutumnwoodMinotaur(); break;
                                              case 1: encountera = new MoundOfMaggots(); break;
                                              case 2: encountera = new OrcBomber(); break;
                                              case 3: encountera = new OrcCaptain(); break;
                                              case 4: encountera = new OrcishLord(); break;
                                              case 5: encountera = new OrcishMage(); break;
			                 }
					      encountera.MoveToWorld( new Point3D( x2, y2, z2 ), Map.Ilshenar );

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
		     if ( mob != null || !mob.Deleted )
		     {
			   Effects.SendLocationEffect( mob.Location, mob.Map, 0x3728, 10, 10 );
			   Effects.PlaySound( mob.Location, mob.Map, 0x1FC );

			   mob.Delete();
                     }
                }
       }
}
