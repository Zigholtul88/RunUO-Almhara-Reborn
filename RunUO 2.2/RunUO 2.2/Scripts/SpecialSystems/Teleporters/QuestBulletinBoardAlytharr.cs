using System;
using System.Collections;
using Server;
using Server.Gumps;
using Server.Network;
using Server.Mobiles;

namespace Server.Items
{
	public class QuestBulletinBoardAlytharr : Item
	{
		[Constructable]
		public QuestBulletinBoardAlytharr() : base( 7775 )
		{
			Movable = false;
			Light = LightType.Circle300;
			Name = "Quest Bulletin - Alytharr Forest";
			Hue = 1266;
		}

		public QuestBulletinBoardAlytharr( Serial serial ) : base( serial )
		{
		}

		public override void OnDoubleClick( Mobile from )
		{
			if ( !from.Player )
				return;

			if ( from.InRange( GetWorldLocation(), 1 ) )
				UseGate( from );
			else
				from.SendLocalizedMessage( 500446 ); // That is too far away.
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
				m.CloseGump( typeof( QuestBulletinBoardAlytharrGump ) );
				m.SendGump( new QuestBulletinBoardAlytharrGump( m, this ) );

				if ( !m.Hidden || m.AccessLevel == AccessLevel.Player )
					Effects.PlaySound( m.Location, m.Map, 0x20E );

				return true;
			}
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
	}

	public class PBulletinBoardAlytharrEntry
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

		public PBulletinBoardAlytharrEntry( Point3D loc, string name )
		{
			m_Location = loc;
			m_Name = name;
		}
	}

	public class PBulletinBoardAlytharrList
	{
		private string m_Name;
		private Map m_Map;
		private PBulletinBoardAlytharrEntry[] m_Entries;

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

		public PBulletinBoardAlytharrEntry[] Entries
		{
			get
			{
				return m_Entries;
			}
		}

		public PBulletinBoardAlytharrList( Map map, PBulletinBoardAlytharrEntry[] entries )
		{
			m_Map = map;
			m_Entries = entries;
		}

		public static readonly PBulletinBoardAlytharrList Malas =
			new PBulletinBoardAlytharrList( Map.Malas, new PBulletinBoardAlytharrEntry[]
				{
					new PBulletinBoardAlytharrEntry( new Point3D( 656, 1361, 16 ), "Bright Club" ),
					new PBulletinBoardAlytharrEntry( new Point3D( 739, 601, -4 ), "Champion Hunt 1" ),
					new PBulletinBoardAlytharrEntry( new Point3D( 721, 796, 0 ), "Enchanted Shovel" ),
					new PBulletinBoardAlytharrEntry( new Point3D( 766, 601, -11 ), "Jade Jungle Jems" ),
					new PBulletinBoardAlytharrEntry( new Point3D( 493, 684, 52 ), "Kiss of the Serpent Mistress" ),
					new PBulletinBoardAlytharrEntry( new Point3D( 773, 1357, 1 ), "Molasses Greed" ),
					new PBulletinBoardAlytharrEntry( new Point3D( 673, 644, -4 ), "Spiderwick Chronicles" ),
					new PBulletinBoardAlytharrEntry( new Point3D( 1115, 1014, -8 ), "Sweet Child of Mine" ),
					new PBulletinBoardAlytharrEntry( new Point3D( 505, 678, 30 ), "Treasure of the Sands" )
				} );

		public static readonly PBulletinBoardAlytharrList[] QuestsLists	= new PBulletinBoardAlytharrList[] { Malas };
	}

	public class QuestBulletinBoardAlytharrGump : Gump
	{
		private Mobile m_Mobile;
		private Item m_Moongate;
		private PBulletinBoardAlytharrList[] m_Lists;

		public QuestBulletinBoardAlytharrGump( Mobile mobile, Item moongate ) : base( 100, 100 )
		{
			m_Mobile = mobile;
			m_Moongate = moongate;

			PBulletinBoardAlytharrList[] checkLists;

			if ( mobile.Player )
			{
				ClientFlags flags = mobile.NetState == null ? ClientFlags.None : mobile.NetState.Flags;
			}
			
			checkLists = PBulletinBoardAlytharrList.QuestsLists;
			
			m_Lists = new PBulletinBoardAlytharrList[checkLists.Length];

			for ( int i = 0; i < m_Lists.Length; ++i )
				m_Lists[i] = checkLists[i];

			for ( int i = 0; i < m_Lists.Length; ++i )
			{
				if ( m_Lists[i].Map == mobile.Map )
				{
					PBulletinBoardAlytharrList temp = m_Lists[i];

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

				PBulletinBoardAlytharrList list = m_Lists[j];
				PBulletinBoardAlytharrEntry[] entries = list.Entries;

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

			AddHtml( 10, 5, 200, 20, "Pick your quest destination:", false, false );
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

			PBulletinBoardAlytharrList list = m_Lists[listIndex];

			if ( listEntry < 0 || listEntry >= list.Entries.Length )
				return;

			PBulletinBoardAlytharrEntry entry = list.Entries[listEntry];

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