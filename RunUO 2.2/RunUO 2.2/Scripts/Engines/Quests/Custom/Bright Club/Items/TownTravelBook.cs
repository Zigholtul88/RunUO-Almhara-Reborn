using System;
using System.Collections;
using Server;
using Server.Gumps;
using Server.Network;
using Server.Mobiles;

namespace Server.Items
{
	public class TownTravelBook : Item
	{
                private int m_Charges;

		[CommandProperty( AccessLevel.GameMaster )]
		public int Charges
		{
			get{ return m_Charges; }
			set{ m_Charges = value; InvalidateProperties(); }
		}

		[Constructable]
		public TownTravelBook() : this( 30 )
		{
		}

		[Constructable]
		public TownTravelBook( int charges ) : base( 17080 )
		{
			m_Charges = charges;
                        Name = "Book of Town Travel";
			LootType = LootType.Blessed;
		}

		public TownTravelBook( Serial serial ) : base( serial )
		{
		}

		public override void AddNameProperties( ObjectPropertyList list )
		{
			base.AddNameProperties( list );

			list.Add( 1060741, m_Charges.ToString() ); // charges: ~1_val~
		}

		public override void OnDoubleClick( Mobile from )
		{
			if ( !from.Player )
				return;

			if ( from.InRange( GetWorldLocation(), 1 ) )
				BeginUsing( from, true );
			else
				from.SendLocalizedMessage( 500446 ); // That is too far away.
		}

		public void BeginUsing( Mobile from, bool useCharges )
		{
			Map map = from.Map;

			if ( map == null || map == Map.Internal )
				return;

			if ( useCharges )
			{
				if ( Charges > 0 )
				{
					--Charges;
					UseGate( from );
				}
				else
				{
					from.SendLocalizedMessage( 502412 ); // There are no charges left on that item.
					from.SendMessage( "The Travel Book has now exploded!" );
					from.PlaySound( 777 );
					this.Delete();
					return;
				}
			}		
		}

		public bool UseGate( Mobile m )
		{
			if ( m.Criminal )
			{
				m.SendLocalizedMessage( 1005561, "", 0x22 ); // Thou'rt a criminal and cannot escape so easily.
				return false;
			}
			else if ( Server.Spells.SpellHelper.CheckCombat( m ) )
			{
				m.SendLocalizedMessage( 1005564, "", 0x22 ); // Wouldst thou flee during the heat of battle??
				return false;
			}
			else if ( m.Spell != null )
			{
				m.SendLocalizedMessage( 1049616 ); // You are too busy to do that at the moment.
				return false;
			}
			else
			{
				m.CloseGump( typeof( TownTravelBookGump ) );
				m.SendGump( new TownTravelBookGump( m, this ) );

				if ( !m.Hidden || m.AccessLevel == AccessLevel.Player )
					Effects.PlaySound( m.Location, m.Map, 0x20E );

				return true;
			}
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );
			writer.Write( (int) 0 ); // version
			writer.Write( (int) m_Charges );
		}

		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader );
			int version = reader.ReadInt();

			switch ( version )
			{
				case 0:
				{
					m_Charges = reader.ReadInt();
					break;
				}
			}
		}
	}

	public class PTownTravelEntry
	{
		private Point3D m_Location;
		private string m_Name;

		public Point3D Location
		{
			get
			{
				return m_Location;
			}
		}

		public string Name
		{
			get
			{
				return m_Name;
			}
		}

		public PTownTravelEntry( Point3D loc, string name )
		{
			m_Location = loc;
			m_Name = name;
		}
	}

	public class PTownTravelList
	{
		private string m_Name;
		private Map m_Map;
		private PTownTravelEntry[] m_Entries;

		public string Name
		{
			get
			{
				return m_Name;
			}
		}

		public Map Map
		{
			get
			{
				return m_Map;
			}
		}

		public PTownTravelEntry[] Entries
		{
			get
			{
				return m_Entries;
			}
		}

		public PTownTravelList( Map map, PTownTravelEntry[] entries )
		{
			m_Map = map;
			m_Entries = entries;
		}

		public static readonly PTownTravelList Malas =
			new PTownTravelList( Map.Malas, new PTownTravelEntry[]
				{
					new PTownTravelEntry( new Point3D( 1689, 1883, 5 ), "Skaddria Naddheim" ),
					new PTownTravelEntry( new Point3D( 1272, 1071, 1 ), "Hammerhill" ),
					new PTownTravelEntry( new Point3D( 743, 1208, 13 ), "Old Plunderer's Haven" ),
					new PTownTravelEntry( new Point3D( 681, 720, 1 ), "Elmhaven" ),
					new PTownTravelEntry( new Point3D( 507, 717, 32 ), "Elandrim Nur Shaz" )
				} );

		public static readonly PTownTravelList[] QuestsLists	= new PTownTravelList[] { Malas };
	}

	public class TownTravelBookGump : Gump
	{
		private Mobile m_Mobile;
		private Item m_Moongate;
		private PTownTravelList[] m_Lists;

		public TownTravelBookGump( Mobile mobile, Item moongate ) : base( 100, 100 )
		{
			m_Mobile = mobile;
			m_Moongate = moongate;

			PTownTravelList[] checkLists;

			if ( mobile.Player )
			{
				ClientFlags flags = mobile.NetState == null ? ClientFlags.None : mobile.NetState.Flags;
			}
			
			checkLists = PTownTravelList.QuestsLists;
			
			m_Lists = new PTownTravelList[checkLists.Length];

			for ( int i = 0; i < m_Lists.Length; ++i )
				m_Lists[i] = checkLists[i];

			for ( int i = 0; i < m_Lists.Length; ++i )
			{
				if ( m_Lists[i].Map == mobile.Map )
				{
					PTownTravelList temp = m_Lists[i];

					m_Lists[i] = m_Lists[0];
					m_Lists[0] = temp;

					break;
				}
			}		

			RenderPage();
		}

		private void RenderPage()
		{

			AddPage( 0 );
			AddBackground( 0, 0, 230, 25*12+ 80, 5054 );
			
			int yPosition = 10;

			for ( int j = 0; j < m_Lists.Length; ++j )
			{

				PTownTravelList list = m_Lists[j];
				PTownTravelEntry[] entries = list.Entries;

				for ( int i = 0; i < entries.Length; ++i )
				{
					yPosition += 25;
					AddRadio( 10, yPosition, 210, 211, false, (j * 100) + i );
					AddHtml( 45, yPosition, 150, 20, entries[i].Name, false, false );
				}
			}

			AddButton( 10, yPosition + 35, 4005, 4007, 1, GumpButtonType.Reply, 0 );
			AddHtmlLocalized( 45, yPosition + 35, 140, 25, 1011036, false, false ); // OKAY

			AddButton( 10, yPosition + 60, 4005, 4007, 0, GumpButtonType.Reply, 0 );
			AddHtmlLocalized( 45, yPosition + 60, 140, 25, 1011012, false, false ); // CANCEL

			AddHtml( 10, 5, 200, 20, "Pick your destination:", false, false );
		}

		public override void OnResponse( NetState state, RelayInfo info )
		{
			if ( info.ButtonID == 0 ) // Cancel
				return;
			else if ( m_Mobile.Deleted || m_Moongate.Deleted || m_Mobile.Map == null )
				return;

			int[] switches = info.Switches;

			if ( switches.Length == 0 )
				return;

			int switchID = switches[0];
			int listIndex = switchID / 100;
			int listEntry = switchID % 100;

			if ( listIndex < 0 || listIndex >= m_Lists.Length )
				return;

			PTownTravelList list = m_Lists[listIndex];

			if ( listEntry < 0 || listEntry >= list.Entries.Length )
				return;

			PTownTravelEntry entry = list.Entries[listEntry];

			if ( !m_Mobile.InRange( m_Moongate.GetWorldLocation(), 1 ) || m_Mobile.Map != m_Moongate.Map )
			{
				m_Mobile.SendLocalizedMessage( 1019002 ); // You are too far away to use the gate.
			}
			else if ( Factions.Sigil.ExistsOn( m_Mobile ) && list.Map != Factions.Faction.Facet )
			{
				m_Mobile.SendLocalizedMessage( 1019004 ); // You are not allowed to travel there.
			}
			else if ( m_Mobile.Criminal )
			{
				m_Mobile.SendLocalizedMessage( 1005561, "", 0x22 ); // Thou'rt a criminal and cannot escape so easily.
			}
			else if ( Server.Spells.SpellHelper.CheckCombat( m_Mobile ) )
			{
				m_Mobile.SendLocalizedMessage( 1005564, "", 0x22 ); // Wouldst thou flee during the heat of battle??
			}
			else if ( m_Mobile.Spell != null )
			{
				m_Mobile.SendLocalizedMessage( 1049616 ); // You are too busy to do that at the moment.
			}
			else if ( m_Mobile.Map == list.Map && m_Mobile.InRange( entry.Location, 1 ) )
			{
				m_Mobile.SendLocalizedMessage( 1019003 ); // You are already there.
			}
			else
			{
				BaseCreature.TeleportPets( m_Mobile, entry.Location, list.Map );

				m_Mobile.Combatant = null;
				m_Mobile.Warmode = false;
				m_Mobile.Hidden = true;

				m_Mobile.MoveToWorld( entry.Location, list.Map );

				Effects.PlaySound( entry.Location, list.Map, 0x1FE );
			}
		}
	}
}