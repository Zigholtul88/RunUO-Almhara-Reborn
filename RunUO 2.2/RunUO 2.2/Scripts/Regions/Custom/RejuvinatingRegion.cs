using System;
using System.Collections;
using System.Collections.Generic;
using System.Xml;
using Server;
using Server.ContextMenus;
using Server.Items;
using Server.Mobiles;
using Server.Network;
using Server.Spells;

namespace Server.Regions
{
        public class RejuvinatingRegion : DamagingRegion
        { 
                public RejuvinatingRegion( XmlElement xml, Map map, Region parent) : base(xml, map, parent)
                { 
                }

		public override bool AllowBeneficial( Mobile from, Mobile target )
		{
			if ( from.AccessLevel == AccessLevel.Player )
        	                from.SendMessage("You cannot commit generosity in this area.");

			return ( from.AccessLevel > AccessLevel.Player );
		}

		public override bool AllowHarmful( Mobile from, Mobile target )
		{
			if ( from.AccessLevel == AccessLevel.Player )
        	                from.SendMessage("You cannot commit violence in this area.");

			return ( from.AccessLevel > AccessLevel.Player );
		}

		public override bool OnBeginSpellCast( Mobile from, ISpell s )
		{
			if ( from.AccessLevel == AccessLevel.Player )
				from.SendLocalizedMessage( 502629 ); // You cannot cast spells here.

			return ( from.AccessLevel > AccessLevel.Player );
		}

		public override bool OnSkillUse( Mobile from, int Skill )
		{
			if ( from.AccessLevel == AccessLevel.Player )
        	                from.SendMessage("You cannot use skills in this area.");

			return ( from.AccessLevel > AccessLevel.Player );
		}

                public override void Damage( Mobile m )
                {
                     base.Damage( m );

                 if (m.NetState != null)
                 {
	             AOS.Damage(m, 0, 0, 0, 0, 0, 0 );
                 }
           }
     }
}