using System;
using System.Collections;
using Server;
using Server.Gumps;
using Server.Items;
using Server.Mobiles;
using Server.Network;
using Server.Spells;
using Server.Engines.Quests;
using Server.Engines.Quests.StaffOfFlyingMonkeys;
using Server.Engines.Quests.StolenNecklace;

namespace Server.Items
{
	public class AlmharaMoongate : Item
	{
		[Constructable]
		public AlmharaMoongate() : base( 0xF6C )
		{
			Movable = false;
			Light = LightType.Circle300;
			Name = "Almhara Moongate";
			Hue = 1266;
		}

		public AlmharaMoongate( Serial serial ) : base( serial )
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

		public override bool OnMoveOver( Mobile m )
		{
			return !m.Player || UseGate( m );
		}

		public bool UseGate( Mobile m )
		{
			if ( m is BaseCreature )
				m = ((BaseCreature)m).ControlMaster;

			PlayerMobile player  = m as PlayerMobile;

			if ( player != null )
			{
		                QuestSystem qs = player.Quest;

			        bool sendMessage = m.Player;

		                if ( qs is StaffOfFlyingMonkeysQuest )
		                {  
                                        if ( qs.IsObjectiveInProgress( typeof( EscapeObjective ) ) )
			                {
        	                                m.SendMessage("You cannot enter during this portion of the questline.");

			                        return false;
                                        }
                                }
		                else if ( qs is StolenNecklaceQuest )
		                {
                                        if ( qs.IsObjectiveInProgress( typeof( ReturnStolenNecklaceObjective ) ) )
			                {
        	                                m.SendMessage("You cannot enter during this portion of the questline.");

			                        return false;
                                        }
                                }
                        }

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
				m.CloseGump( typeof( AlmharaMoonGateGump ) );
				m.SendGump( new AlmharaMoonGateGump( m, this ) );

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

	public class PAlmharaEntry
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

		public PAlmharaEntry( Point3D loc, string name )
		{
			m_Location = loc;
			m_Name = name;
		}
	}

	public class PAlmharaList
	{
		private string m_Name;
		private Map m_Map;
		private PAlmharaEntry[] m_Entries;

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

		public PAlmharaEntry[] Entries
		{
			get
			{
				return m_Entries;
			}
		}

		public PAlmharaList( Map map, PAlmharaEntry[] entries )
		{
			m_Map = map;
			m_Entries = entries;
		}

		public static readonly PAlmharaList Felucca =
			new PAlmharaList( Map.Felucca, new PAlmharaEntry[]
				{
					new PAlmharaEntry( new Point3D( 3423, 3705, 7 ), "Kameron Kove" ),
					new PAlmharaEntry( new Point3D( 4387, 1632, 3 ), "Kettleburg" ),
					new PAlmharaEntry( new Point3D( 4226, 2270, 2 ), "Vigilant Valley" )
					
				} );

		public static readonly PAlmharaList Trammel =
			new PAlmharaList( Map.Trammel, new PAlmharaEntry[]
				{
					new PAlmharaEntry( new Point3D( 5588, 2157, 50 ), "Sunnyside Resort" )
					
				} );

		public static readonly PAlmharaList Malas =
			new PAlmharaList( Map.Malas, new PAlmharaEntry[]
				{
					new PAlmharaEntry( new Point3D( 1675, 1834, 23 ), "Skaddria Nadheim" ),
					new PAlmharaEntry( new Point3D( 1194, 1143, 46 ), "Hammerhill" ),
					new PAlmharaEntry( new Point3D( 638, 746, 5 ), "Elmhaven" ),
					new PAlmharaEntry( new Point3D( 534, 728, 29 ), "Elandrim Nur Shaz" ),
					new PAlmharaEntry( new Point3D( 1737, 597, -2 ), "Coven's Landing" ),
					new PAlmharaEntry( new Point3D( 754, 1248, 20 ), "Old Plunderer's Haven" ),
					new PAlmharaEntry( new Point3D( 382, 1884, 29 ), "Red Dagger Keep" )
				} );

		public static readonly PAlmharaList[] QuestsLists = new PAlmharaList[] { Felucca, Trammel, Malas };
	}

	public class AlmharaMoonGateGump : Gump
	{
		private Mobile m_Mobile;
		private Item m_Moongate;
		private PAlmharaList[] m_Lists;

		public AlmharaMoonGateGump( Mobile mobile, Item moongate ) : base( 100, 100 )
		{
			m_Mobile = mobile;
			m_Moongate = moongate;

			PAlmharaList[] checkLists;

			if ( mobile.Player )
			{
				ClientFlags flags = mobile.NetState == null ? ClientFlags.None : mobile.NetState.Flags;
			}
			
			checkLists = PAlmharaList.QuestsLists;
			
			m_Lists = new PAlmharaList[checkLists.Length];

			for ( int i = 0; i < m_Lists.Length; ++i )
				m_Lists[i] = checkLists[i];

			for ( int i = 0; i < m_Lists.Length; ++i )
			{
				if ( m_Lists[i].Map == mobile.Map )
				{
					PAlmharaList temp = m_Lists[i];

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

				PAlmharaList list = m_Lists[j];
				PAlmharaEntry[] entries = list.Entries;

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

			PAlmharaList list = m_Lists[listIndex];

			if ( listEntry < 0 || listEntry >= list.Entries.Length )
				return;

			PAlmharaEntry entry = list.Entries[listEntry];

			if ( !m_Mobile.InRange( m_Moongate.GetWorldLocation(), 1 ) || m_Mobile.Map != m_Moongate.Map )
			{
				m_Mobile.SendLocalizedMessage( 1019002 ); // You are too far away to use the gate.
			}
			//else if ( m_Mobile.Player && m_Mobile.Kills >= 5 && list.Map != Map.Felucca )
			//{
				//m_Mobile.SendLocalizedMessage( 1019004 ); // You are not allowed to travel there.
			//}
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