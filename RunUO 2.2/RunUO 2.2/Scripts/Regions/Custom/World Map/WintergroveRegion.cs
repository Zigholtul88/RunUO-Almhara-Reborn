using System;
using System.Collections;
using System.Collections.Generic;
using System.Xml;
using Server.ContextMenus;
using Server.Items;
using Server.Mobiles;
using Server.Network;
using Server.Spells;
using Server.Spells.First;
using Server.Spells.Third;
using Server.Spells.Fourth;
using Server.Spells.Sixth;
using Server.Spells.Seventh;
using Server.Targeting;
using AMT = Server.Items.ArmorMaterialType;

namespace Server.Regions
{
     public class WintergroveRegion : DamagingRegion
     {
            public WintergroveRegion( XmlElement xml, Map map, Region parent ) : base( xml, map, parent )
	    {
	    }

            public override void OnEnter( Mobile m )
            {
        	   m.SendMessage("You have entered the region of Wintergrove.");

                   base.OnEnter( m );
            }

            public override void OnExit( Mobile m )
            {
        	   m.SendMessage("You have left the region of Wintergrove.");

                   base.OnExit( m );
            }

	    public virtual void AlterSpellDamageFrom( Mobile from, ref int damage, ISpell s )
	    {
		    if ( from is PlayerMobile )
	            {
			   PlayerMobile p_PlayerMobile = from as PlayerMobile;

		           if ( s is MagicArrowSpell )
		           {
                                damage += 25;
                           }
		           else if ( ( s is FireballSpell || s is FireFieldSpell || s is ExplosionSpell ) )
		           {
                                damage += 50;
                           }
		           else if ( s is FlameStrikeSpell )
		           {
                                damage += 75;
                           }
		           else if ( s is MeteorSwarmSpell )
		           {
                                damage *= 2;
                           }
                    }
            }
      
            public override TimeSpan DamageInterval
            {
                get
                {
                    return TimeSpan.FromSeconds(30);
                }
            }

            public override void Damage( Mobile m )
            {
                    base.Damage(m );

                    if ( m.Alive )
                    {
		            Item item = m.FindItemOnLayer( Layer.OuterTorso );

	                    if ( item is GMRobe )
	                    {
	                           AOS.Damage(m, 0, 0, 0, 0, 0, 0 );
                            }
                            else
                            {
	                             if ( item is BaseOuterTorso )
	                             {
	                                   AOS.Damage(m, 0, 0, 0, 0, 0, 0 );
                                     }
                                     else
                                     {
		                     	if ( Utility.RandomDouble() < 0.02 )
                                     	{
			                   m.Stam -= 10;
			                   m.Mana -= 20;
			                   m.FixedParticles( 0x37CC, 1, 40, 97, 3, 9917, EffectLayer.Waist );
           		                   m.FixedParticles( 0x374A, 1, 15, 9502, 97, 3, (EffectLayer)255 );
			                   m.PlaySound( 20 );
			                   m.SendMessage("You feel as if your skin is freezing!!!");
			                   m.PlaySound( m.Female ? 811 : 1085 );
			                   m.Say( "*oooh!*" );
                                           AOS.Damage(m, Utility.Random(5, 15), 0, 0, 100, 0, 0);
					}
                                     }

                                     // Wind
		                     if ( Utility.RandomDouble() < 0.08 )
                                     {
                                           m.PlaySound(Utility.RandomList( 0x014,0x15,0x016,0x5C7 ) );
	                                   AOS.Damage(m, 0, 0, 0, 0, 0, 0 );
                                     }
                            }
                    }
            }
      }
}