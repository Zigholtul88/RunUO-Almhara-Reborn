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
	public class WhisperingHollowBossRegion : LandscapeRegion
	{
		public WhisperingHollowBossRegion( XmlElement xml, Map map, Region parent ) : base( xml, map, parent )
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

		public override void OnDeath( Mobile m )
		{
                        if ( m is PlayerMobile )
                        {
		              PlayerMobile player = m as PlayerMobile;
                              Region rg = player.Region;

	                      if ( m.Region.Name == "Whispering Hollow Boss Room" )
	                      {
                                        ////////// Whispering Hollow First Floor //////////
                                        m.Location = new Point3D( 1089, 1129, -42 );
				        m.Map = Map.TerMur;
                                        World.Broadcast( 0x35, true, string.Format( "{0} has been slaughtered by Knightmare.", m.Name ) );

				        Item corpse = m.Corpse;

                      	  	        if ( corpse != null )
				        {
			 		         m.Corpse.Location = new Point3D( 1089, 1129, -42 );
					         m.Corpse.Map = Map.TerMur;
                                        }

                              }
                              else
                              {
                                     m.Location = new Point3D( 1089, 1129, -42 );
				     m.Map = Map.TerMur;
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

                                // Jungle noises
		                if ( Utility.RandomDouble() < 0.08 )
                                {
                                       m.PlaySound(Utility.RandomList( 0x003,0x004,0x005 ) );
	                               AOS.Damage(m, 0, 0, 0, 0, 0, 0 );
                                }

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
