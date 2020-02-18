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
	public class LakeStreamSFXRegion : DamagingRegion
	{
		public LakeStreamSFXRegion( XmlElement xml, Map map, Region parent ) : base( xml, map, parent )
		{
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

	                  AOS.Damage(m, 0, 0, 0, 100, 0, 0 );
                          m.PlaySound(Utility.RandomList( 0x307,0x308 ) );
                    }
                    else
                    {
                          // water stream
		          if ( Utility.RandomDouble() < 0.50 )
                          {
                               m.PlaySound( 0x11 );
	                       AOS.Damage(m, 0, 0, 0, 0, 0, 0 );
                          }

                          // water stream
		          if ( Utility.RandomDouble() < 0.25 )
                          {
                               m.PlaySound( 0x11 );
	                       AOS.Damage(m, 0, 0, 0, 0, 0, 0 );
                          }

                          // water stream
		          if ( Utility.RandomDouble() < 0.15 )
                          {
                               m.PlaySound( 0x11 );
	                       AOS.Damage(m, 0, 0, 0, 0, 0, 0 );
                          }

                          // water stream
		          if ( Utility.RandomDouble() < 0.08 )
                          {
                               m.PlaySound( 0x11 );
	                       AOS.Damage(m, 0, 0, 0, 0, 0, 0 );
                          }

                          // water stream
		          if ( Utility.RandomDouble() < 0.05 )
                          {
                               m.PlaySound( 0x11 );
	                       AOS.Damage(m, 0, 0, 0, 0, 0, 0 );
                          }
                    }
               }
          }
     }
}