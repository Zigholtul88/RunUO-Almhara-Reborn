#region Header
// **********
// [ForgeUO] - Dungeon Barrel
// A chop-able barrel that will spawn a variety
// of configurable loot or mobiles.
// **********
#endregion

#region References
using System;
using System.Collections;
using System.Collections.Generic;
using Server.Multis;
using Server.Items;
using Server.Mobiles;
#endregion

namespace Server.Items
{
    	public class DungeonBarrel1 : Container, IChopable
    	{
        	public override int DefaultMaxWeight{ get{ return 0; } } // A value of 0 signals unlimited weight

        	public override bool TryDropItem( Mobile from, Item dropped, bool sendFullMessage )
        	{
            		if ( from.AccessLevel < AccessLevel.GameMaster )
            		{
                		from.SendLocalizedMessage( 501747 ); // It appears to be locked.
                		return false;
            		}

            		return base.TryDropItem( from, dropped, sendFullMessage );
        	}

        	public override bool OnDragDropInto( Mobile from, Item item, Point3D p )
        	{
            		if ( from.AccessLevel < AccessLevel.GameMaster )
            		{
                		from.SendLocalizedMessage( 501747 ); // It appears to be locked.
                		return false;
            		}

            		return base.OnDragDropInto( from, item, p );
       		}

        	public override void OnDoubleClick( Mobile from)
        	{
            		from.SendLocalizedMessage(501747); // It appears to be locked.
        	}

        	public override int DefaultGumpID{ get{ return 0x3E; } }
        	public override int DefaultDropSound{ get{ return 0x42; } }

        	public override Rectangle2D Bounds
        	{
            		get{ return new Rectangle2D( 33, 36, 109, 112 ); }
        	}

        	[Constructable]
        	public DungeonBarrel1() : base( 0xFAE) //0xE77 )  
        	{
            		Name = "Sealed Barrel";
            		Hue = 1121;
            		Movable = false;
        	}

        	public DungeonBarrel1( Serial serial ) : base( serial )
        	{
        	}

        	public override void Serialize( GenericWriter writer )
        	{
            		base.Serialize( writer );
            		writer.Write( (int) 0 ); // version
        	}

        	public override void Deserialize( GenericReader reader )
        	{
            		base.Deserialize( reader );
            		int version = reader.ReadInt();
        	}

        	public void OnChop( Mobile from )
        	{
            		if ( from.InRange( this.GetWorldLocation(), 2 ) )
            		{
                		Effects.SendLocationEffect( Location, Map, 0x3728, 20, 10 ); //smoke or dust
                		Effects.PlaySound( Location, Map, 0x11C );

                		switch ( Utility.Random( 5 ) )
                		{
                    			case 0:
                        			new BarrelLid().MoveToWorld( Location, Map );
                        			new BarrelHoops().MoveToWorld( Location, Map );
                        			break;
                    			case 1:
                        			new BarrelStaves().MoveToWorld( Location, Map );
                        			new BarrelHoops().MoveToWorld( Location, Map );
                        			break;
                    			case 2:
                        			Gold g1 = new Gold(Utility.RandomMinMax( 5, 15 ) );
                        			g1.MoveToWorld( Location, Map );
                        			break;
                    			case 3:
                        			Gold g2 = new Gold(Utility.RandomMinMax( 15, 30 ) );
                        			g2.MoveToWorld( Location, Map );
                        			break;
                    			case 4:
                        			Gold g3 = new Gold(Utility.RandomMinMax( 30, 50 ) );
                        			g3.MoveToWorld( Location, Map );
                        			break;
                		}

                		Destroy();                
            		}
                	else
            		{
                		from.SendLocalizedMessage( 500446 ); // That is too far away.
            		}
        	}
    	}
}