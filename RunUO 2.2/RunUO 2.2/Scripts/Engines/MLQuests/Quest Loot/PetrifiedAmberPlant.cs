using System;
using System.Collections;
using System.Collections.Generic;
using Server;
using Server.ContextMenus;
using Server.Items;
using Server.Misc;
using Server.Mobiles;
using Server.Spells;
using Server.Targeting; 

namespace Server.Items 
{ 
	public class PetrifiedAmberPlant : Item
	{ 
		public override bool HandlesOnMovement{ get{ return true; } } // Tell the core that we implement OnMovement

                private static readonly int[] m_North = new int[]
                {
                       -1, -1,
                        1, -1,
                       -1, 2,
                        1, 2
                };
                private static readonly int[] m_East = new int[]
                {
                       -1, 0,
                        2, 0
                };

		[Constructable]
		public PetrifiedAmberPlant() : base( Utility.RandomList( 14539, 14540 ) ) 
		{
			Name = "petrified amber plant";
			Light = LightType.Circle225;
			Movable = false;
			Weight = 1.0; 
			Hue = 1169;
		} 

		public bool CheckRange( Point3D loc, Point3D oldLoc, int range )
		{
			return CheckRange( loc, range ) && !CheckRange( oldLoc, range );
		}

		public bool CheckRange( Point3D loc, int range )
		{
			return ( (this.Z + 8) >= loc.Z && (loc.Z + 16) > this.Z )
				&& Utility.InRange( GetWorldLocation(), loc, range );
		}

		public override void OnMovement( Mobile m, Point3D oldLocation )
		{
			base.OnMovement( m, oldLocation );

			if ( m.Location == oldLocation )
				return;

			if ( CheckRange( m.Location, oldLocation, 5 ) )
			{
                                SparkleRing();
			}
		}

                public virtual void SparkleRing()
                {
                        for (int i = 0; i < m_North.Length; i += 2)
                        {
                                Point3D p = Location;

                                p.X += m_North[i];
                                p.Y += m_North[i + 1];

                                IPoint3D po = p as IPoint3D;

                                SpellHelper.GetSurfaceTop(ref po);

                                Effects.SendLocationEffect(po, Map, 0x373A, 50);
                        }

                        for (int i = 0; i < m_East.Length; i += 2)
                        {
                                Point3D p = Location;

                                p.X += m_East[i];
                                p.Y += m_East[i + 1];

                                IPoint3D po = p as IPoint3D;

                                SpellHelper.GetSurfaceTop(ref po);

                                Effects.SendLocationEffect(po, Map, 0x375A, 50);
                        }
                }

		public PetrifiedAmberPlant( Serial serial ) : base( serial ) 
		{ 
		} 

		public override void Serialize( GenericWriter writer ) 
		{ 
			base.Serialize( writer ); 
			writer.Write( (int) 0 ); 
		} 
       
		public override void Deserialize(GenericReader reader) 
		{ 
			base.Deserialize( reader ); 
			int version = reader.ReadInt(); 
		}

		public override void OnDoubleClick( Mobile from ) 
		{ 
			if ( from.InRange( this.GetWorldLocation(), 2 ) ) 
		        { 
		    	        int pick = Utility.Random( 1, 2 );
			        PetrifiedAmber crop = new PetrifiedAmber( pick ); 
				from.AddToBackpack( crop );
			        from.SendMessage( "You harvest some petrified amber." ); 
				this.Delete();
			}
		        else
		        { 
			        from.SendMessage( "You are too far away to harvest anything." ); 
		        } 
		}
	} 
}