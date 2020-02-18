using System;
using System.Collections;
using System.Collections.Generic;
using System.Xml;
using Server;
using Server.Mobiles;
using Server.Network;
using Server.Gumps;
using Server.Items;
using Server.Spells;
using Server.Spells.Third;
using Server.Spells.Fourth;
using Server.Spells.Fifth;
using Server.Spells.Sixth;
using Server.Spells.Seventh;
using Server.Spells.Eighth;
using Server.Spells.Chivalry;
using Server.Spells.Necromancy;
using Server.Targeting;

namespace Server.Regions
{
	public class StoneBurrowBossRegion : LandscapeRegion
	{
		public StoneBurrowBossRegion( XmlElement xml, Map map, Region parent ) : base( xml, map, parent )
		{
		}

		public override bool AllowHousing( Mobile from, Point3D p )
		{
			return false;
		}

		public override void AlterLightLevel( Mobile m, ref int global, ref int personal )
		{
			global = LightCycle.JailLevel;
		}

                public override TimeSpan DamageInterval
                {
                    get
                    {
                        return TimeSpan.FromSeconds(1);
                    }
                }

                public override void OnEnter( Mobile m )
                {
                        if ( m is PlayerMobile )
                        {
		              PlayerMobile player = m as PlayerMobile;

                              if ( m.Warmode )
                              {
                                       ////////// Boss Theme 4 //////////
                                       m.Send(PlayMusic.GetInstance( MusicName.Docktown ) );
                              }
                              else
	                      {
                                       ////////// Boss Theme 4 //////////
                                       m.Send(PlayMusic.GetInstance( MusicName.Docktown ) );
                              }
                       }

                       base.OnEnter( m );
                }

		public override void OnDeath( Mobile m )
		{
                        if ( m is PlayerMobile )
                        {
		              PlayerMobile player = m as PlayerMobile;
                              Region rg = player.Region;

	                      if ( m.Region.Name == "Stone Burrow Boss Room" )
	                      {
                                        ////////// Stone Burrow Mines First Floor //////////
                                        m.Location = new Point3D( 740, 731, 20 );
				        m.Map = Map.Tokuno;
                                        World.Broadcast( 0x35, true, string.Format( "{0} has been slaughtered by Amul Seketsi.", m.Name ) );

				        Item corpse = m.Corpse;

                      	  	        if ( corpse != null )
				        {
			 		         m.Corpse.Location = new Point3D( 740, 731, 20 );
					         m.Corpse.Map = Map.Tokuno;
                                        }

                              }
                              else
                              {
                                     m.Location = new Point3D( 740, 731, 20 );
				     m.Map = Map.Tokuno;
                                     World.Broadcast( 0x35, true, string.Format( "Some douchebag has slaughtered {0}.", m.Name ) );
                              }
                       }

		       base.OnDeath( m );
                }

		public override bool OnBeginSpellCast( Mobile m, ISpell s )
		{
			if ( ( s is GateTravelSpell || s is RecallSpell || s is MarkSpell || s is TeleportSpell || s is SacredJourneySpell ) && m.AccessLevel == AccessLevel.Player )
			{
				m.SendMessage( "An aura radiates throughout this region, forbidding you from teleporting away." );
				return false;
			}
			else
			{
				return base.OnBeginSpellCast( m, s );
			}
		}

                public override void Damage( Mobile m )
                {   
                        base.Damage( m );

                        if ( m.Alive )
                        {
                                // Wind
		                if ( Utility.RandomDouble() < 0.25 )
                                {
                                       m.PlaySound(Utility.RandomList( 0x014,0x15,0x016,0x5C7 ) );
	                               AOS.Damage(m, 0, 0, 0, 0, 0, 0 );
                                }

                                // Wind
		                if ( Utility.RandomDouble() < 0.15 )
                                {
                                       m.PlaySound(Utility.RandomList( 0x014,0x15,0x016,0x5C7 ) );
	                               AOS.Damage(m, 0, 0, 0, 0, 0, 0 );
                                }

                                // Wind
		                if ( Utility.RandomDouble() < 0.08 )
                                {
                                       m.PlaySound(Utility.RandomList( 0x014,0x15,0x016,0x5C7 ) );
	                               AOS.Damage(m, 0, 0, 0, 0, 0, 0 );
                                }

                                // Wind
		                if ( Utility.RandomDouble() < 0.05 )
                                {
                                       m.PlaySound(Utility.RandomList( 0x014,0x15,0x016,0x5C7 ) );
	                               AOS.Damage(m, 0, 0, 0, 0, 0, 0 );
                                }
                        }
                }
	}
}
