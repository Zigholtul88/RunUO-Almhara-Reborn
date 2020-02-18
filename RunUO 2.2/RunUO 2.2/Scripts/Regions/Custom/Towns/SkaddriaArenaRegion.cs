using System;
using System.Collections;
using System.Collections.Generic;
using System.Xml;
using Server;
using Server.Gumps;
using Server.Items;
using Server.Mobiles;
using Server.Network;
using Server.Spells;
using Server.Spells.First;
using Server.Spells.Second;
using Server.Spells.Third;
using Server.Spells.Fourth;
using Server.Spells.Fifth;
using Server.Spells.Sixth;
using Server.Spells.Seventh;
using Server.Spells.Chivalry;
using Server.Targeting;

namespace Server.Regions
{
        public class SkaddriaArenaRegion : NoHousingRegion  // this region will flag people gray. made for duel pits and whatever else you need to flag everyone gray in. (runuo shard/data/regions.xml)
	{
	        public SkaddriaArenaRegion( XmlElement xml, Map map, Region parent ) : base( xml, map, parent )
	        {
	        }

                public override void OnEnter( Mobile m )
                {
                        m.SendMessage("You have entered Skaddria Arena. You may do battle with others.");
                        m.Send( PlayMusic.GetInstance( MusicName.Trinsic ) );

                        base.OnEnter(m);
                }

                public override void OnExit( Mobile m )
                {
        	        m.SendMessage("You have left Skaddria Arena.");
                        base.OnExit(m);
                }

		public override bool AllowBeneficial( Mobile from, Mobile target )
		{
			if( target.Player )
				return true; // Can heal other players

                        return true;
		}

		public override bool AllowHarmful( Mobile from, Mobile target )
		{
			if( target.Player )
				return true; // Can harm other players

                        return true;
		}

		public override bool OnBeginSpellCast( Mobile m, ISpell s )
		{
			if ( ( s is GateTravelSpell || s is RecallSpell || s is MarkSpell || s is TeleportSpell || s is SacredJourneySpell ) && m.AccessLevel == AccessLevel.Player )
			{
				m.SendMessage( "*sighs* Really nigga! I don't think so!" );
				return false;
			}
			else if ( ( s is HealSpell || s is GreaterHealSpell ) && m.AccessLevel == AccessLevel.Player )
			{
				m.SendMessage( "What the fuck do you think you're doing healing yo ass inside mah arena!" );
				return false;
			}
			else
			{
				return base.OnBeginSpellCast( m, s );
			}
		}

		public override bool OnSkillUse( Mobile from, int Skill )
		{
                        return true;
		}

                public override bool OnDoubleClick( Mobile m, object o )
                {
                        if ( o is BasePotion )
                        {
                                if (o is BaseHealPotion || o is BaseHealPotion )
                                {
                                        return false;
                                }
                        }
                        if ( o is Corpse && ( ( Corpse )o ).Owner != m )
                        {
                                m.SendLocalizedMessage(1010054); // You cannot loot that corpse!!
                                return false;
                        }

                        return base.OnDoubleClick( m, o );
                }
        }
}