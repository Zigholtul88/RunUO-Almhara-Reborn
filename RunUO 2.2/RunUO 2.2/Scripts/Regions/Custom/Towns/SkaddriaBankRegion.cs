using System;
using System.Collections;
using System.Collections.Generic;
using System.Xml;
using Server.Items;
using Server.Mobiles;
using Server.Network;
using Server.ContextMenus;

namespace Server.Regions
{
        public class SkaddriaBankRegion : TownRegion
        {
                public SkaddriaBankRegion( XmlElement xml, Map map, Region parent ) : base( xml, map, parent )
	        {
	        }

                public override void OnEnter( Mobile m )
                {
        	        m.SendMessage("You have entered First State Bank of Skaddria Naddheim.");
                        m.Send( Network.PlayMusic.GetInstance( MusicName.BankTheme ) );

                        base.OnEnter( m );
                }

                public override void OnExit( Mobile m )
                {
        	        m.SendMessage("You have left First State Bank of Skaddria Naddheim.");
                        m.Send( Network.PlayMusic.GetInstance( MusicName.SkaddriaNaddheim ) );

                        base.OnExit( m );
                }  

                public static void Initialize() 
                { 
                       EventSink.Login += new LoginEventHandler( SkaddriaBank_OnLogin );
                }

                public static void SkaddriaBank_OnLogin( LoginEventArgs e ) 
                {
		       PlayerMobile m = e.Mobile as PlayerMobile;

                       if ( m.Region.Name == "First State Bank of Skaddria Naddheim" )
                            m.Send( Network.PlayMusic.GetInstance( MusicName.BankTheme ) );
                }

                public override TimeSpan DamageInterval
                {
                         get
                         {
                                 return TimeSpan.FromSeconds(5);
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
                            // random chit-chat
		            if ( Utility.RandomDouble() < 0.02 )
                            {
                                 m.PlaySound(Utility.RandomList( 0x53B, 0x53C, 0x53D, 0x53E, 0x53F, 0x540, 0x541, 0x542, 0x543, 0x544, 0x545, 0x546, 0x547, 0x548, 0x549 ) );
	                         AOS.Damage(m, 0, 0, 0, 0, 0, 0 );
                            }

                            // random chit-chat
		            if ( Utility.RandomDouble() < 0.02 )
                            {
                                 m.PlaySound(Utility.RandomList( 0x54A, 0x54B, 0x54C, 0x54D, 0x54E, 0x54F, 0x550, 0x551, 0x552, 0x553, 0x554, 0x555, 0x556, 0x557, 0x558, 0x559 ) );
	                         AOS.Damage(m, 0, 0, 0, 0, 0, 0 );
                            }

                            // random chit-chat
		            if ( Utility.RandomDouble() < 0.02 )
                            {
                                 m.PlaySound(Utility.RandomList( 0x55A, 0x55B, 0x55C, 0x55D, 0x55E, 0x55F, 0x560, 0x561, 0x562, 0x563, 0x564, 0x565, 0x566, 0x568 ) );
	                         AOS.Damage(m, 0, 0, 0, 0, 0, 0 );
                            }
                     }
                 }
             }
       }
}