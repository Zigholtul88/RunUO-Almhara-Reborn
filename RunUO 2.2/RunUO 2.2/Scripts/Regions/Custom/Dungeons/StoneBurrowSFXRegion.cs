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
	public class StoneBurrowSFXRegion : DamagingRegion
	{
		public StoneBurrowSFXRegion( XmlElement xml, Map map, Region parent ) : base( xml, map, parent )
		{
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
        	    m.SendMessage("You have entered Stone Burrow Mines.");

                    base.OnEnter( m );
             }

             public override void OnExit( Mobile m )
             {
        	    m.SendMessage("You have left Stone Burrow Mines.");

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
                          // sfx noises
		          if ( Utility.RandomDouble() < 0.02 )
                          {
                               m.PlaySound(Utility.RandomList( 0x0F5,0x0F7,0x0F8,0x0FB ) );
	                       AOS.Damage(m, 0, 0, 0, 0, 0, 0 );
                          }

                          // water drips
		          if ( Utility.RandomDouble() < 0.03 )
                          {
                               m.PlaySound(Utility.RandomList( 0x022,0x023,0x024 ) );
	                       AOS.Damage(m, 0, 0, 0, 0, 0, 0 );
                          }
                    }
               }
          }
     }
}