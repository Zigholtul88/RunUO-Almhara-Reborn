using System;
using System.Collections;
using System.Collections.Generic;
using System.Xml;
using Server.ContextMenus;
using Server.Items;
using Server.Mobiles;
using Server.Network;
using Server.Spells.Fourth;
using Server.Targeting;

namespace Server.Regions
{
	public class DragonStormIslandSFXRegion : LandscapeRegion
	{
		public DragonStormIslandSFXRegion( XmlElement xml, Map map, Region parent ) : base( xml, map, parent )
		{
		}

		public override bool AllowHousing( Mobile from, Point3D p )
		{
			return true;
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
                          // Crimson Meteor
		            if ( Utility.RandomDouble() < 0.005 )
                            {
		                 Ability.CrimsonMeteor( m, 10 );
	                         AOS.Damage(m, 0, 0, 0, 0, 0, 0 );
                            }

                          // Wind
		            if ( Utility.RandomDouble() < 0.25 )
                            {
                                 m.PlaySound(Utility.RandomList( 0x014,0x15,0x016,0x5C7 ) );
	                         AOS.Damage(m, 0, 0, 0, 0, 0, 0 );
                            }

                            // Wind
		            if ( Utility.RandomDouble() < 0.15 )
                            {
                                 m.PlaySound(Utility.RandomList( 0x014,0x15,0x016,0x5C7 ) );
	                         AOS.Damage(m, 0, 0, 0, 0, 0, 0 );
                            }

                            // Wind
		            if ( Utility.RandomDouble() < 0.08 )
                            {
                                 m.PlaySound(Utility.RandomList( 0x014,0x15,0x016,0x5C7 ) );
	                         AOS.Damage(m, 0, 0, 0, 0, 0, 0 );
                            }

                            // Wind
		            if ( Utility.RandomDouble() < 0.05 )
                            {
                                 m.PlaySound(Utility.RandomList( 0x014,0x15,0x016,0x5C7 ) );
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
			                 switch ( Utility.Random( 2 ) )
			                 {
					      default:
                                              case 0: tameable = new Drake(); break;
                                              case 1: tameable = new Dragon(); break;
			                 }
					      tameable.MoveToWorld( new Point3D( x1, y1, z1 ), Map.Malas );
				              tameable.Combatant = m;
                                              m.PlaySound( 0x656 ); // risingColossus

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
			                 switch ( Utility.Random( 2 ) )
			                 {
					      default:
                                              case 0: tameable = new Drake(); break;
                                              case 1: tameable = new Dragon(); break;
			                 }
					      tameable.MoveToWorld( new Point3D( x2, y2, z2 ), Map.Malas );
				              tameable.Combatant = m;
                                              m.PlaySound( 0x656 ); // risingColossus

	                                      AOS.Damage(m, 0, 0, 0, 0, 0, 0 );
				              Timer.DelayCall( TimeSpan.FromMinutes( 20.0 ), new TimerStateCallback( DeleteTameable ), tameable );
                                         }
                                   }
                            }
                   }
                }
             }

	     private void DeleteTameable( object tameable )
	     {
		  BaseCreature mob = (BaseCreature)tameable;
	          Map map = mob.Map;
		  Mobile c = tameable as Mobile;

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