using System;
using System.Collections;
using System.Collections.Generic;
using System.Net;
using Server;
using Server.Accounting;
using Server.ContextMenus;
using Server.Gumps;
using Server.Items;
using Server.Misc;
using Server.Mobiles;
using Server.Network;
using Server.Spells;
using Server.Targeting;
using Server.Prompts;
using Server.Regions;
using System.Collections;
using Server.Engines.PartySystem;

namespace Server.Items
{
	public class NyeenakuuSummonAltar : Item
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
		public NyeenakuuSummonAltar() : this( null )
		{
		}

		[Constructable]
		public NyeenakuuSummonAltar( string name ) : base( 0x2258 )
		{
			Name = "Nyeenakuu Summon. Dont Spawn this boss unless you and your party are ready!";
			Light = LightType.Circle225;
			LootType = LootType.Blessed;
			Movable = false;
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
		
		public NyeenakuuSummonAltar( Serial serial ) : base( serial )
		{
		}
		
		public override void OnDoubleClick( Mobile from )
		{			
			ArrayList list = new ArrayList();
			
			foreach ( Mobile m in World.Mobiles.Values )
			{
				if ( m is BaseCreature )
				{
					BaseCreature bc = (BaseCreature)m;
					
					if ( bc is Nyeenakuu )
						list.Add( bc );
				}
			}
			if ( list.Count > 0 )
				from.SendMessage( "A Party is Already in Battle With Nyeenakuu. Please Wait" );

			
			else
			{
				from.SendGump( new NyeenakuuGump( from, this ) );
			}
		}
		
		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );
			writer.Write( (int) 0 );
		}
		
		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader );
			int version = reader.ReadInt();
		}
	}

	public class NyeenakuuGump : Gump
	{
		private Mobile m_Mobile;
		private Item m_Deed;
		
		public NyeenakuuGump( Mobile from, Item deed ) : base( 30, 20 )
		{
			m_Mobile = from;
			m_Deed = deed;
						
			Account a = from.Account as Account;
			
			AddImageTiled(  54, 33, 369, 400, 2624 );
			AddAlphaRegion( 54, 33, 369, 400 );
			AddImageTiled( 416, 39, 44, 389, 203 );			
			AddImage( 97, 49, 9005 );
			AddImageTiled( 58, 39, 29, 390, 10460 );
			AddImageTiled( 412, 37, 31, 389, 10460 );
			AddLabel( 140, 60, 0x34, "Destroy Nyeenakuu" );
			AddImage( 430, 9, 10441);
			AddImageTiled( 40, 38, 17, 391, 9263 );
			AddImage( 6, 25, 10421 );
			AddImage( 34, 12, 10420 );
			AddImageTiled( 94, 25, 342, 15, 10304 );
			AddImageTiled( 40, 427, 415, 16, 10304 );
			AddImage( -10, 314, 10402 );
			AddImage( 56, 150, 10411 );
			AddImage( 136, 84, 96 );
			AddImage( 215, 150, 5536 );

			AddButton( 225, 390, 0xF7, 0xF8, 1, GumpButtonType.Reply, 0 );
			
		}
		
		public override void OnResponse( NetState state, RelayInfo info )
		{
			Mobile from = state.Mobile;
			
			switch( info.ButtonID )
			{
				case 0:
					{
						from.CloseGump( typeof( NyeenakuuGump ) );
						break;
					}
						case 1: //Case uses the ActionIDs defined above. Case 1 defines the actions for the button with the action id 1 
					{
						Party party = Party.Get( from );

						if( party != null )
						{
							for( int i = 0; i < party.Count; i++ )
							{
								Mobile m = party[ i ].Mobile;

								if( Utility.InRange( from.Location, m.Location, 6 ) )
								{
									m.MoveToWorld( new Point3D( 284, 104, -75 ), Map.Tokuno );
									Nyeenakuu cp = new Nyeenakuu();
                                                                        cp.MoveToWorld( new Point3D( 289, 66, -48 ), Map.Tokuno );
									m_Deed.Delete(); // Delete the deed
								}
							}
						}
						else
						{
							from.MoveToWorld( new Point3D( 284, 104, -75 ), Map.Tokuno );
							Nyeenakuu cp = new Nyeenakuu();
                                                        cp.MoveToWorld( new Point3D( 289, 66, -48 ), Map.Tokuno );
							m_Deed.Delete();	
						}
                                                break;
					}
			}
		}
	}
}