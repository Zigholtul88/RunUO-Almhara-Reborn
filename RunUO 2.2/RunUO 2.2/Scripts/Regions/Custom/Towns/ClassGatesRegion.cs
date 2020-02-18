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
      public class ClassGatesRegion : TownRegion
      {
                public ClassGatesRegion( XmlElement xml, Map map, Region parent ) : base( xml, map, parent )
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

                public static void Initialize() 
                { 
                       EventSink.Login += new LoginEventHandler( ClassGates_OnLogin );
                }

                public static void ClassGates_OnLogin( LoginEventArgs e ) 
                {
		       PlayerMobile m = e.Mobile as PlayerMobile;

                       if ( m.Region.Name == "Class Gates" )
                            m.Send( Network.PlayMusic.GetInstance( MusicName.Mountn_a ) );
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
                        base.Damage(m );

                        if ( m.Alive )
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
                        }
                }
        }
}