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
     public class OldPlunderersHavenRegion : TownRegion
     {
            public OldPlunderersHavenRegion( XmlElement xml, Map map, Region parent ) : base( xml, map, parent )
	    {
	    }    
      }
}