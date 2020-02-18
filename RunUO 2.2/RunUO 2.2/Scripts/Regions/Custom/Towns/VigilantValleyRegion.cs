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
        public class VigilantValleyRegion : TownRegion
        {
                public VigilantValleyRegion( XmlElement xml, Map map, Region parent ) : base( xml, map, parent )
	        {
	        }

                public override void OnEnter( Mobile m )
                {
        	       m.SendMessage("You have entered Vigilant Valley.");

                       base.OnEnter( m );
                }

                public override void OnExit( Mobile m )
                {
        	       m.SendMessage("You have left Vigilant Valley.");

                       base.OnExit( m );
                }

		public override void AlterLightLevel( Mobile m, ref int global, ref int personal )
		{
			global = LightCycle.DungeonLevel;
		}
        }
}