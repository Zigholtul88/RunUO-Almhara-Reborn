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
    	public class DungeonBarrel2 : Container, IChopable
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
        	public DungeonBarrel2() : base( 0xFAE) //0xE77 )  
        	{
            		Name = "Sealed Barrel";
            		Hue = 1121;
            		Movable = false;
        	}

        	public DungeonBarrel2( Serial serial ) : base( serial )
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

                		switch ( Utility.Random( 25 ) )
                		{
                    			case 0:
                        			Effects.SendLocationEffect( from, from.Map, 0x113A, 20, 10 ); // Poison Player
                        			from.PlaySound( 0x231 );
                        			from.ApplyPoison( from, Poison.Lesser );
                        			break;
                    			case 1:
                        			Effects.SendLocationEffect(from, from.Map, 0x3709, 30); // Burn Player
                        			from.PlaySound( 0x54 );
                        			AOS.Damage( from, from, Utility.RandomMinMax( 2, 5 ), 0, 100, 0, 0, 0 );
                        			break;
                    			case 2:
                        			new BarrelLid().MoveToWorld( Location, Map );
                        			new BarrelHoops().MoveToWorld( Location, Map );
                        			break;
                    			case 3:
                        			Bandage b = new Bandage( Utility.RandomMinMax( 5, 10 ) ); 
                        			b.MoveToWorld( Location, Map );
                        			break;
                    			case 4:
                        			new BarrelStaves().MoveToWorld( Location, Map );
                        			new BarrelHoops().MoveToWorld( Location, Map );
                        			break;
                    			case 5:
                        			Gold g = new Gold(Utility.RandomMinMax( 25, 50 ) );
                        			g.MoveToWorld( Location, Map );
                        			break;
                    			case 6:
                        			new AgilityPotion().MoveToWorld( Location, Map );
                        			break;
                    			case 7:
                        			new LesserCurePotion().MoveToWorld( Location, Map );
                        			break;
                    			case 8:
                        			new LesserExplosionPotion().MoveToWorld( Location, Map );
                        			break;
                    			case 9:
                        			new LesserHealPotion().MoveToWorld( Location, Map );
                       	 			break;
                    			case 10:
                        			new LesserLightningPotion().MoveToWorld( Location, Map );
                       	 			break;
                    			case 11:
                        			new LesserManaPotion().MoveToWorld( Location, Map );
                       	 			break;
                    			case 12:
                        			new MindPotion().MoveToWorld( Location, Map );
                       	 			break;
                    			case 13:
                        			new LesserPoisonPotion().MoveToWorld( Location, Map );
                       	 			break;
                    			case 14:
                        			new LesserShatterPotion().MoveToWorld( Location, Map );
                       	 			break;
                    			case 15:
                        			new StrengthPotion().MoveToWorld( Location, Map );
                       	 			break;
                    			case 16:
                        			new LesserToxicPotion().MoveToWorld( Location, Map );
                       	 			break;
                    			case 17:
                        			Arrow arrow = new Arrow( Utility.RandomMinMax( 5, 25 ) ); 
                        			arrow.MoveToWorld( Location, Map );
                        			break;
                    			case 18:
                        			Bolt bolt = new Bolt( Utility.RandomMinMax( 5, 25 ) ); 
                        			bolt.MoveToWorld( Location, Map );
                        			break;
                    			case 19:
                        			IronIngot ii = new IronIngot( Utility.RandomMinMax( 5, 25 ) ); 
                        			ii.MoveToWorld( Location, Map );
                        			break;
                    			case 20:
                        			Leather leather = new Leather( Utility.RandomMinMax( 5, 25 ) ); 
                        			leather.MoveToWorld( Location, Map );
                        			break;
                    			case 21:
                        			Log log = new Log( Utility.RandomMinMax( 5, 25 ) ); 
                        			log.MoveToWorld( Location, Map );
                        			break;
                    			case 22:
                        			BoltOfCloth boc = new BoltOfCloth( Utility.RandomMinMax( 1, 25 ) ); 
                        			boc.MoveToWorld( Location, Map );
                        			break;
                    			case 23:
                        			SpidersSilk spiderssilk = new SpidersSilk( Utility.RandomMinMax( 5, 25 ) ); 
                        			spiderssilk.MoveToWorld( Location, Map );
                        			break;
                    			case 24:
                        			SulfurousAsh sulfurousash = new SulfurousAsh( Utility.RandomMinMax( 1, 25 ) ); 
                        			sulfurousash.MoveToWorld( Location, Map );
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