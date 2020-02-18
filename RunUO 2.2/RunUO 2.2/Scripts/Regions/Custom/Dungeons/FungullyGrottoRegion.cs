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
	public class FungullyGrottoRegion : DamagingRegion
	{
	     public FungullyGrottoRegion( XmlElement xml, Map map, Region parent ) : base( xml, map, parent )
	     {
	     }

             public override void OnEnter( Mobile m )
             {
        	    m.SendMessage("You have entered Fungully Grotto.");

                    base.OnEnter( m );
             }

             public override void OnExit( Mobile m )
             {
        	    m.SendMessage("You have left Fungully Grotto.");

                    base.OnExit( m );
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
                  
             base.Damage(m );

             if (m.Alive)
             {
		   Item item = m.FindItemOnLayer( Layer.OuterTorso );

	           if ( item is GMRobe )
	           {
                            // Jungle noises
		            if ( Utility.RandomDouble() < 0.08 )
                            {
                                 m.PlaySound(Utility.RandomList( 0x003,0x004,0x005 ) );
	                         AOS.Damage(m, 0, 0, 0, 0, 0, 0 );
                            }

                            // Bird chirps
		            if ( Utility.RandomDouble() < 0.02 )
                            {
                                 m.PlaySound(Utility.RandomList( 0x094,0x095,0x096,0x097,0x0D1,0x0D2 ) );
	                         AOS.Damage(m, 0, 0, 0, 0, 0, 0 );
                            }

                            // Cricket noises
		            if ( Utility.RandomDouble() < 0.03 )
                            {
                                 m.PlaySound(Utility.RandomList( 0x00A,0x00B ) );
	                         AOS.Damage(m, 0, 0, 0, 0, 0, 0 );
                            }

                            // sfx noises
		            if ( Utility.RandomDouble() < 0.02 )
                            {
                                 m.PlaySound(Utility.RandomList( 0x0F5,0x0F7,0x0F8,0x0FB ) );
	                         AOS.Damage(m, 0, 0, 0, 0, 0, 0 );
                            }
                   }
                   else
                   {
                            // Jungle noises
		            if ( Utility.RandomDouble() < 0.08 )
                            {
                                 m.PlaySound(Utility.RandomList( 0x003,0x004,0x005 ) );
	                         AOS.Damage(m, 0, 0, 0, 0, 0, 0 );
                            }

                            // Bird chirps
		            if ( Utility.RandomDouble() < 0.02 )
                            {
                                 m.PlaySound(Utility.RandomList( 0x094,0x095,0x096,0x097,0x0D1,0x0D2 ) );
	                         AOS.Damage(m, 0, 0, 0, 0, 0, 0 );
                            }

                            // Cricket noises
		            if ( Utility.RandomDouble() < 0.03 )
                            {
                                 m.PlaySound(Utility.RandomList( 0x00A,0x00B ) );
	                         AOS.Damage(m, 0, 0, 0, 0, 0, 0 );
                            }

                            // sfx noises
		            if ( Utility.RandomDouble() < 0.02 )
                            {
                                 m.PlaySound(Utility.RandomList( 0x0F5,0x0F7,0x0F8,0x0FB ) );
	                         AOS.Damage(m, 0, 0, 0, 0, 0, 0 );
                            }

                            // Corpser Ambush 1
		            if ( Utility.RandomDouble() < 0.012 )
                            {
			          if ( m.Map == Map.Tokuno )
			          {
				         int x1 = m.X + 3;
				         int y1 = m.Y + 3;
				         int z1 = Map.Tokuno.GetAverageZ( x1, y1 );

				         if ( Map.Tokuno.CanSpawnMobile( x1, y1, z1 ) )
				         {
				              BaseCreature corpser = new Corpser();
					      corpser.MoveToWorld( new Point3D( x1, y1, z1 ), Map.Tokuno );
				              corpser.Combatant = m;
			                      corpser.PlaySound( 684 );

	                                      AOS.Damage(m, 0, 0, 0, 0, 0, 0 );
				              Timer.DelayCall( TimeSpan.FromMinutes( 1.0 ), new TimerStateCallback( DeleteCorpser ), corpser );
                                         }
                                  }
                            }

                            // Corpser Ambush 2
		            if ( Utility.RandomDouble() < 0.012 )
                            {
			          if ( m.Map == Map.Tokuno )
			          {
				         int x2 = m.X - 3;
				         int y2 = m.Y - 3;
				         int z2 = Map.Tokuno.GetAverageZ( x2, y2 );

				         if ( Map.Tokuno.CanSpawnMobile( x2, y2, z2 ) )
				         {
				              BaseCreature corpser = new Corpser();
					      corpser.MoveToWorld( new Point3D( x2, y2, z2 ), Map.Tokuno );
				              corpser.Combatant = m;
			                      corpser.PlaySound( 684 );

	                                      AOS.Damage(m, 0, 0, 0, 0, 0, 0 );
				              Timer.DelayCall( TimeSpan.FromMinutes( 1.0 ), new TimerStateCallback( DeleteCorpser ), corpser );
                                         }
                                  }
                            }

                            // Qiraji Ambush 1
		            if ( Utility.RandomDouble() < 0.008 )
                            {
			          if ( m.Map == Map.Tokuno )
			          {
				         int x1 = m.X + 5;
				         int y1 = m.Y + 5;
				         int z1 = Map.Tokuno.GetAverageZ( x1, y1 );

				         if ( Map.Tokuno.CanSpawnMobile( x1, y1, z1 ) )
				         {
				              BaseCreature qiraji = new Qiraji();
					      qiraji.MoveToWorld( new Point3D( x1, y1, z1 ), Map.Tokuno );
				              qiraji.Combatant = m;
			                      qiraji.PlaySound( 0x269 );

	                                      AOS.Damage(m, 0, 0, 0, 0, 0, 0 );
				              Timer.DelayCall( TimeSpan.FromMinutes( 2.0 ), new TimerStateCallback( DeleteQiraji ), qiraji );
                                         }
                                  }
                            }

                            // Qiraji Ambush 2
		            if ( Utility.RandomDouble() < 0.008 )
                            {
			          if ( m.Map == Map.Tokuno )
			          {
				         int x2 = m.X - 5;
				         int y2 = m.Y - 5;
				         int z2 = Map.Tokuno.GetAverageZ( x2, y2 );

				         if ( Map.Tokuno.CanSpawnMobile( x2, y2, z2 ) )
				         {
				              BaseCreature qiraji = new Qiraji();
					      qiraji.MoveToWorld( new Point3D( x2, y2, z2 ), Map.Tokuno );
				              qiraji.Combatant = m;
			                      qiraji.PlaySound( 0x269 );

	                                      AOS.Damage(m, 0, 0, 0, 0, 0, 0 );
				              Timer.DelayCall( TimeSpan.FromMinutes( 2.0 ), new TimerStateCallback( DeleteQiraji ), qiraji );
                                         }
                                  }
                            }
                      }
                 }
            }

	    private void DeleteCorpser( object corpser )
	    {
		  BaseCreature mob = (BaseCreature)corpser;
	          Map map = mob.Map;
		  Mobile c = corpser as Mobile;

		  if ( mob != null || !mob.Deleted )
		  {
			Effects.SendLocationEffect( mob.Location, mob.Map, 0x3728, 10, 10 );
			Effects.PlaySound( mob.Location, mob.Map, 0x1FC );

			mob.Delete();
                  }
            }

	    private void DeleteQiraji( object qiraji )
	    {
		  BaseCreature mob = (BaseCreature)qiraji;
	          Map map = mob.Map;
		  Mobile c = qiraji as Mobile;

		  if ( mob != null || !mob.Deleted )
		  {
			Effects.SendLocationEffect( mob.Location, mob.Map, 0x3728, 10, 10 );
			Effects.PlaySound( mob.Location, mob.Map, 0x1FC );

			mob.Delete();
                  }
            }
      }
}

