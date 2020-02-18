using System;
using System.Collections;
using System.Collections.Generic;
using System.Xml;
using Server.Network;
using Server.Items;
using Server.Mobiles;
using Server.ContextMenus;

namespace Server.Regions
{
	public class StarLakeSFXRegion : LandscapeRegion
	{
		public StarLakeSFXRegion( XmlElement xml, Map map, Region parent ) : base( xml, map, parent )
		{
		}

		public override bool AllowHousing( Mobile from, Point3D p )
		{
			return false;
		}

		public override void AlterLightLevel( Mobile m, ref int global, ref int personal )
		{
			global = LightCycle.NightLevel;
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
        	    m.SendMessage("You have entered Star Lake.");

                    base.OnEnter( m );
             }

             public override void OnExit( Mobile m )
             {
        	    m.SendMessage("You have left Star Lake.");

                    base.OnExit( m );
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
                          // Forest noises
		          if ( Utility.RandomDouble() < 0.09 )
                          {
                               m.PlaySound(Utility.RandomList( 0x000,0x001,0x002 ) );
	                       AOS.Damage(m, 0, 0, 0, 0, 0, 0 );
                          }

                          // Bird chirps
		          if ( Utility.RandomDouble() < 0.06 )
                          {
                               m.PlaySound(Utility.RandomList( 0x094,0x095,0x096,0x097,0x0D1,0x0D2 ) );
	                       AOS.Damage(m, 0, 0, 0, 0, 0, 0 );
                          }

                          // Cricket noises
		          if ( Utility.RandomDouble() < 0.05 )
                          {
                               m.PlaySound(Utility.RandomList( 0x00A,0x00B ) );
	                       AOS.Damage(m, 0, 0, 0, 0, 0, 0 );
                          }
                    }
               }
          }
     }
}