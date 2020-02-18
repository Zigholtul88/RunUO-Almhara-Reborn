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
	public class BleakWindTunnelsLevel3Region : DamagingRegion
	{
	     public BleakWindTunnelsLevel3Region( XmlElement xml, Map map, Region parent ) : base( xml, map, parent )
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
                            // sfx noises
		            if ( Utility.RandomDouble() < 0.02 )
                            {
                                 m.PlaySound(Utility.RandomList( 0x0F5,0x0F7,0x0F8,0x0FB ) );
	                         AOS.Damage(m, 0, 0, 0, 0, 0, 0 );
                            }

                            // ice aura damage
		            if ( Utility.RandomDouble() < 0.010 )
                            {
		                 m.Hits -= 15;
		                 m.Stam -= 5;
		                 m.Mana -= 20;
		                 m.FixedParticles( 0x374A, 10, 30, 5013, 1153, 2, EffectLayer.Waist );
		                 m.PlaySound( 0x0FC );
		                 m.ApplyPoison( m, Poison.Regular );
                                 m.SendMessage( "An icy aura claws at your vessel and hypothermia starts to settle in." ); 
                                 AOS.Damage(m, Utility.Random(15, 25), 0, 0, 100, 0, 0);
                            }

                            // Beelzebug Ambush 1
		            if ( Utility.RandomDouble() < 0.012 )
                            {
			          if ( m.Map == Map.Tokuno )
			          {
				         int x1 = m.X + 1;
				         int y1 = m.Y + 1;
				         int z1 = Map.Tokuno.GetAverageZ( x1, y1 );

				         if ( Map.Tokuno.CanSpawnMobile( x1, y1, z1 ) )
				         {
				              BaseCreature beelzebug = new Beelzebug();
					      beelzebug.MoveToWorld( new Point3D( x1, y1, z1 ), Map.Tokuno );
				              beelzebug.Combatant = m;
			                      beelzebug.PlaySound( 0x4E8 );

				              IceFieldIceFlame ice = new IceFieldIceFlame();
				              ice.MoveToWorld( new Point3D( beelzebug.X +5, beelzebug.Y, beelzebug.Z  ), beelzebug.Map );
				              m.PlaySound( 0x208 );


				              IceFieldIceFlame icea = new IceFieldIceFlame();
				              icea.MoveToWorld( new Point3D( beelzebug.X +5, beelzebug.Y +5, beelzebug.Z  ), beelzebug.Map );
				              m.PlaySound( 0x208 );

				              IceFieldIceFlame iceb = new IceFieldIceFlame();
				              iceb.MoveToWorld( new Point3D( beelzebug.X +5, beelzebug.Y -5, beelzebug.Z  ), beelzebug.Map );
				              m.PlaySound( 0x208 );

				              IceFieldIceFlame icec = new IceFieldIceFlame();
				              icec.MoveToWorld( new Point3D( beelzebug.X, beelzebug.Y +5, beelzebug.Z  ), beelzebug.Map );
				              m.PlaySound( 0x208 );

				              IceFieldIceFlame iced = new IceFieldIceFlame();
				              iced.MoveToWorld( new Point3D( beelzebug.X, beelzebug.Y -5, beelzebug.Z  ), beelzebug.Map );
				              m.PlaySound( 0x208 );

				              IceFieldIceFlame icee = new IceFieldIceFlame();
				              icee.MoveToWorld( new Point3D( beelzebug.X -5, beelzebug.Y, beelzebug.Z  ), beelzebug.Map );
				              m.PlaySound( 0x208 );

				              IceFieldIceFlame icef = new IceFieldIceFlame();
				              icef.MoveToWorld( new Point3D( beelzebug.X -5, beelzebug.Y -5, beelzebug.Z  ), beelzebug.Map );
				              m.PlaySound( 0x208 );

				              IceFieldIceFlame iceg = new IceFieldIceFlame();
				              iceg.MoveToWorld( new Point3D( beelzebug.X -5, beelzebug.Y +5, beelzebug.Z  ), beelzebug.Map );
				              m.PlaySound( 0x208 );

				              IceFieldIceFlame iceh = new IceFieldIceFlame();
				              iceh.ItemID = 0x8e1;
				              iceh.MoveToWorld( new Point3D( beelzebug.X, beelzebug.Y, beelzebug.Z +19 ), beelzebug.Map );
				              m.PlaySound( 0x208 );

	                                      AOS.Damage(m, 0, 0, 0, 0, 0, 0 );
				              Timer.DelayCall( TimeSpan.FromMinutes( 3.0 ), new TimerStateCallback( DeleteBeelzebug ), beelzebug );
                                         }
                                  }
                            }

                            // Beelzebug Ambush 2
		            if ( Utility.RandomDouble() < 0.012 )
                            {
			          if ( m.Map == Map.Tokuno )
			          {
				         int x2 = m.X - 1;
				         int y2 = m.Y - 1;
				         int z2 = Map.Tokuno.GetAverageZ( x2, y2 );

				         if ( Map.Tokuno.CanSpawnMobile( x2, y2, z2 ) )
				         {
				              BaseCreature beelzebug = new Beelzebug();
					      beelzebug.MoveToWorld( new Point3D( x2, y2, z2 ), Map.Tokuno );
				              beelzebug.Combatant = m;
			                      beelzebug.PlaySound( 0x4E8 );
				              IceFieldIceFlame ice = new IceFieldIceFlame();
				              ice.MoveToWorld( new Point3D( beelzebug.X +5, beelzebug.Y, beelzebug.Z  ), beelzebug.Map );
				              m.PlaySound( 0x208 );

				              IceFieldIceFlame icea = new IceFieldIceFlame();
				              icea.MoveToWorld( new Point3D( beelzebug.X +5, beelzebug.Y +5, beelzebug.Z  ), beelzebug.Map );
				              m.PlaySound( 0x208 );

				              IceFieldIceFlame iceb = new IceFieldIceFlame();
				              iceb.MoveToWorld( new Point3D( beelzebug.X +5, beelzebug.Y -5, beelzebug.Z  ), beelzebug.Map );
				              m.PlaySound( 0x208 );

				              IceFieldIceFlame icec = new IceFieldIceFlame();
				              icec.MoveToWorld( new Point3D( beelzebug.X, beelzebug.Y +5, beelzebug.Z  ), beelzebug.Map );
				              m.PlaySound( 0x208 );

				              IceFieldIceFlame iced = new IceFieldIceFlame();
				              iced.MoveToWorld( new Point3D( beelzebug.X, beelzebug.Y -5, beelzebug.Z  ), beelzebug.Map );
				              m.PlaySound( 0x208 );

				              IceFieldIceFlame icee = new IceFieldIceFlame();
				              icee.MoveToWorld( new Point3D( beelzebug.X -5, beelzebug.Y, beelzebug.Z  ), beelzebug.Map );
				              m.PlaySound( 0x208 );

				              IceFieldIceFlame icef = new IceFieldIceFlame();
				              icef.MoveToWorld( new Point3D( beelzebug.X -5, beelzebug.Y -5, beelzebug.Z  ), beelzebug.Map );
				              m.PlaySound( 0x208 );

				              IceFieldIceFlame iceg = new IceFieldIceFlame();
				              iceg.MoveToWorld( new Point3D( beelzebug.X -5, beelzebug.Y +5, beelzebug.Z  ), beelzebug.Map );
				              m.PlaySound( 0x208 );

				              IceFieldIceFlame iceh = new IceFieldIceFlame();
				              iceh.ItemID = 0x8e1;
				              iceh.MoveToWorld( new Point3D( beelzebug.X, beelzebug.Y, beelzebug.Z +19 ), beelzebug.Map );
				              m.PlaySound( 0x208 );

	                                      AOS.Damage(m, 0, 0, 0, 0, 0, 0 );
				              Timer.DelayCall( TimeSpan.FromMinutes( 3.0 ), new TimerStateCallback( DeleteBeelzebug ), beelzebug );
                                         }
                                  }
                            }

                            // Ice Fiend Ambush 1
		            if ( Utility.RandomDouble() < 0.015 )
                            {
			          if ( m.Map == Map.Tokuno )
			          {
				         int x1 = m.X + 1;
				         int y1 = m.Y + 1;
				         int z1 = Map.Tokuno.GetAverageZ( x1, y1 );

				         if ( Map.Tokuno.CanSpawnMobile( x1, y1, z1 ) )
				         {
				              BaseCreature icefiend = new IceFiend();
					      icefiend.MoveToWorld( new Point3D( x1, y1, z1 ), Map.Tokuno );
				              icefiend.Combatant = m;
			                      icefiend.PlaySound( 357 );

				              IceFieldIceFlame ice = new IceFieldIceFlame();
				              ice.MoveToWorld( new Point3D( icefiend.X +5, icefiend.Y, icefiend.Z  ), icefiend.Map );
				              m.PlaySound( 0x208 );


				              IceFieldIceFlame icea = new IceFieldIceFlame();
				              icea.MoveToWorld( new Point3D( icefiend.X +5, icefiend.Y +5, icefiend.Z  ), icefiend.Map );
				              m.PlaySound( 0x208 );

				              IceFieldIceFlame iceb = new IceFieldIceFlame();
				              iceb.MoveToWorld( new Point3D( icefiend.X +5, icefiend.Y -5, icefiend.Z  ), icefiend.Map );
				              m.PlaySound( 0x208 );

				              IceFieldIceFlame icec = new IceFieldIceFlame();
				              icec.MoveToWorld( new Point3D( icefiend.X, icefiend.Y +5, icefiend.Z  ), icefiend.Map );
				              m.PlaySound( 0x208 );

				              IceFieldIceFlame iced = new IceFieldIceFlame();
				              iced.MoveToWorld( new Point3D( icefiend.X, icefiend.Y -5, icefiend.Z  ), icefiend.Map );
				              m.PlaySound( 0x208 );

				              IceFieldIceFlame icee = new IceFieldIceFlame();
				              icee.MoveToWorld( new Point3D( icefiend.X -5, icefiend.Y, icefiend.Z  ), icefiend.Map );
				              m.PlaySound( 0x208 );

				              IceFieldIceFlame icef = new IceFieldIceFlame();
				              icef.MoveToWorld( new Point3D( icefiend.X -5, icefiend.Y -5, icefiend.Z  ), icefiend.Map );
				              m.PlaySound( 0x208 );

				              IceFieldIceFlame iceg = new IceFieldIceFlame();
				              iceg.MoveToWorld( new Point3D( icefiend.X -5, icefiend.Y +5, icefiend.Z  ), icefiend.Map );
				              m.PlaySound( 0x208 );

				              IceFieldIceFlame iceh = new IceFieldIceFlame();
				              iceh.ItemID = 0x8e1;
				              iceh.MoveToWorld( new Point3D( icefiend.X, icefiend.Y, icefiend.Z +19 ), icefiend.Map );
				              m.PlaySound( 0x208 );

	                                      AOS.Damage(m, 0, 0, 0, 0, 0, 0 );
				              Timer.DelayCall( TimeSpan.FromMinutes( 3.0 ), new TimerStateCallback( DeleteIceFiend ), icefiend );
                                         }
                                  }
                            }

                            // Ice Fiend Ambush 2
		            if ( Utility.RandomDouble() < 0.015 )
                            {
			          if ( m.Map == Map.Tokuno )
			          {
				         int x2 = m.X - 1;
				         int y2 = m.Y - 1;
				         int z2 = Map.Tokuno.GetAverageZ( x2, y2 );

				         if ( Map.Tokuno.CanSpawnMobile( x2, y2, z2 ) )
				         {
				              BaseCreature icefiend = new IceFiend();
					      icefiend.MoveToWorld( new Point3D( x2, y2, z2 ), Map.Tokuno );
				              icefiend.Combatant = m;
			                      icefiend.PlaySound( 357 );

				              IceFieldIceFlame ice = new IceFieldIceFlame();
				              ice.MoveToWorld( new Point3D( icefiend.X +5, icefiend.Y, icefiend.Z  ), icefiend.Map );
				              m.PlaySound( 0x208 );


				              IceFieldIceFlame icea = new IceFieldIceFlame();
				              icea.MoveToWorld( new Point3D( icefiend.X +5, icefiend.Y +5, icefiend.Z  ), icefiend.Map );
				              m.PlaySound( 0x208 );

				              IceFieldIceFlame iceb = new IceFieldIceFlame();
				              iceb.MoveToWorld( new Point3D( icefiend.X +5, icefiend.Y -5, icefiend.Z  ), icefiend.Map );
				              m.PlaySound( 0x208 );

				              IceFieldIceFlame icec = new IceFieldIceFlame();
				              icec.MoveToWorld( new Point3D( icefiend.X, icefiend.Y +5, icefiend.Z  ), icefiend.Map );
				              m.PlaySound( 0x208 );

				              IceFieldIceFlame iced = new IceFieldIceFlame();
				              iced.MoveToWorld( new Point3D( icefiend.X, icefiend.Y -5, icefiend.Z  ), icefiend.Map );
				              m.PlaySound( 0x208 );

				              IceFieldIceFlame icee = new IceFieldIceFlame();
				              icee.MoveToWorld( new Point3D( icefiend.X -5, icefiend.Y, icefiend.Z  ), icefiend.Map );
				              m.PlaySound( 0x208 );

				              IceFieldIceFlame icef = new IceFieldIceFlame();
				              icef.MoveToWorld( new Point3D( icefiend.X -5, icefiend.Y -5, icefiend.Z  ), icefiend.Map );
				              m.PlaySound( 0x208 );

				              IceFieldIceFlame iceg = new IceFieldIceFlame();
				              iceg.MoveToWorld( new Point3D( icefiend.X -5, icefiend.Y +5, icefiend.Z  ), icefiend.Map );
				              m.PlaySound( 0x208 );

				              IceFieldIceFlame iceh = new IceFieldIceFlame();
				              iceh.ItemID = 0x8e1;
				              iceh.MoveToWorld( new Point3D( icefiend.X, icefiend.Y, icefiend.Z +19 ), icefiend.Map );
				              m.PlaySound( 0x208 );

	                                      AOS.Damage(m, 0, 0, 0, 0, 0, 0 );
				              Timer.DelayCall( TimeSpan.FromMinutes( 3.0 ), new TimerStateCallback( DeleteIceFiend ), icefiend );
                                         }
                                  }
                            }
                      }
                 }
            }

	    private void DeleteBeelzebug( object beelzebug )
	    {
		  BaseCreature mob = (BaseCreature)beelzebug;
	          Map map = mob.Map;
		  Mobile c = beelzebug as Mobile;

		  if ( mob != null || !mob.Deleted )
		  {
			Effects.SendLocationEffect( mob.Location, mob.Map, 0x3728, 10, 10 );
			Effects.PlaySound( mob.Location, mob.Map, 0x1FC );

			mob.Delete();
                  }
            }

	    private void DeleteIceFiend( object icefiend )
	    {
		  BaseCreature mob = (BaseCreature)icefiend;
	          Map map = mob.Map;
		  Mobile c = icefiend as Mobile;

		  if ( mob != null || !mob.Deleted )
		  {
			Effects.SendLocationEffect( mob.Location, mob.Map, 0x3728, 10, 10 );
			Effects.PlaySound( mob.Location, mob.Map, 0x1FC );

			mob.Delete();
                  }
            }
      }
}

