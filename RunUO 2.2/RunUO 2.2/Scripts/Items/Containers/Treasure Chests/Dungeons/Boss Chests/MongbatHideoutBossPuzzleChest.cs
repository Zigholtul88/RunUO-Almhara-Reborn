using System;
using System.Collections.Generic;
using Server;
using Server.Gumps;
using Server.Mobiles;
using Server.Network;
using Server.Engines.PartySystem;

namespace Server.Items
{
	public enum MongbatHideoutBossPuzzleChestCylinder
	{
		None		= 0xE73,
		LightBlue	= 0x186F,
		Blue		= 0x186A,
		Green		= 0x186B,
		Orange		= 0x186C,
		Purple		= 0x186D,
		Red		= 0x186E,
		DarkBlue	= 0x1869,
		Yellow		= 0x1870
	}

	public class MongbatHideoutBossPuzzleChestSolution
	{
		public const int Length = 5;

		private MongbatHideoutBossPuzzleChestCylinder[] m_Cylinders = new MongbatHideoutBossPuzzleChestCylinder[Length];

		public MongbatHideoutBossPuzzleChestCylinder[] Cylinders{ get{ return m_Cylinders; } }

		public MongbatHideoutBossPuzzleChestCylinder First{ get{ return m_Cylinders[0]; } set{ m_Cylinders[0] = value; } }
		public MongbatHideoutBossPuzzleChestCylinder Second{ get{ return m_Cylinders[1]; } set{ m_Cylinders[1] = value; } }
		public MongbatHideoutBossPuzzleChestCylinder Third{ get{ return m_Cylinders[2]; } set{ m_Cylinders[2] = value; } }
		public MongbatHideoutBossPuzzleChestCylinder Fourth{ get{ return m_Cylinders[3]; } set{ m_Cylinders[3] = value; } }
		public MongbatHideoutBossPuzzleChestCylinder Fifth{ get{ return m_Cylinders[4]; } set{ m_Cylinders[4] = value; } }

		public static MongbatHideoutBossPuzzleChestCylinder RandomCylinder()
		{
			switch ( Utility.Random( 8 ) )
			{
				case 0: return MongbatHideoutBossPuzzleChestCylinder.LightBlue;
				case 1: return MongbatHideoutBossPuzzleChestCylinder.Blue;
				case 2: return MongbatHideoutBossPuzzleChestCylinder.Green;
				case 3: return MongbatHideoutBossPuzzleChestCylinder.Orange;
				case 4: return MongbatHideoutBossPuzzleChestCylinder.Purple;
				case 5: return MongbatHideoutBossPuzzleChestCylinder.Red;
				case 6: return MongbatHideoutBossPuzzleChestCylinder.DarkBlue;
				default: return MongbatHideoutBossPuzzleChestCylinder.Yellow;
			}
		}

		public MongbatHideoutBossPuzzleChestSolution()
		{
			for ( int i = 0; i < m_Cylinders.Length; i++ ) {
				m_Cylinders[i] = RandomCylinder();
			}
		}

		public MongbatHideoutBossPuzzleChestSolution( MongbatHideoutBossPuzzleChestCylinder first, MongbatHideoutBossPuzzleChestCylinder second, MongbatHideoutBossPuzzleChestCylinder third, MongbatHideoutBossPuzzleChestCylinder fourth, MongbatHideoutBossPuzzleChestCylinder fifth )
		{
			First = first;
			Second = second;
			Third = third;
			Fourth = fourth;
			Fifth = fifth;
		}

		public MongbatHideoutBossPuzzleChestSolution( MongbatHideoutBossPuzzleChestSolution solution )
		{
			for ( int i = 0; i < m_Cylinders.Length; i++ ) {
				m_Cylinders[i] = solution.m_Cylinders[i];
			}
		}

		public bool Matches( MongbatHideoutBossPuzzleChestSolution solution, out int cylinders, out int colors )
		{
			cylinders = 0;
			colors = 0;

			bool[] matchesSrc = new bool[solution.m_Cylinders.Length];
			bool[] matchesDst = new bool[solution.m_Cylinders.Length];

			for ( int i = 0; i < m_Cylinders.Length; i++ )
			{
				if ( m_Cylinders[i] == solution.m_Cylinders[i] )
				{
					cylinders++;

					matchesSrc[i] = true;
					matchesDst[i] = true;
				}
			}

			for ( int i = 0; i < m_Cylinders.Length; i++ )
			{
				if ( !matchesSrc[i] )
				{
					for ( int j = 0; j < solution.m_Cylinders.Length; j++ )
					{
						if ( m_Cylinders[i] == solution.m_Cylinders[j] && !matchesDst[j] )
						{
							colors++;

							matchesDst[j] = true;
						}
					}
				}
			}

			return cylinders == m_Cylinders.Length;
		}

		public virtual void Serialize( GenericWriter writer )
		{
			writer.WriteEncodedInt( (int) 0 ); // version

			writer.WriteEncodedInt( (int) m_Cylinders.Length );
			for ( int i = 0; i < m_Cylinders.Length; i++ )
			{
				writer.Write( (int) m_Cylinders[i] );
			}
		}

		public MongbatHideoutBossPuzzleChestSolution( GenericReader reader )
		{
			int version = reader.ReadEncodedInt();

			int length = reader.ReadEncodedInt();
			for ( int i = 0; ; i++ )
			{
				if ( i < length )
				{
					MongbatHideoutBossPuzzleChestCylinder cylinder = (MongbatHideoutBossPuzzleChestCylinder) reader.ReadInt();

					if ( i < m_Cylinders.Length )
						m_Cylinders[i] = cylinder;
				}
				else if ( i < m_Cylinders.Length )
				{
					m_Cylinders[i] = RandomCylinder();
				}
				else
				{
					break;
				}
			}
		}
	}

	public class MongbatHideoutBossPuzzleChestSolutionAndTime : MongbatHideoutBossPuzzleChestSolution
	{
		private DateTime m_When;

		public DateTime When{ get{ return m_When; } }

		public MongbatHideoutBossPuzzleChestSolutionAndTime( DateTime when, MongbatHideoutBossPuzzleChestSolution solution ) : base( solution )
		{
			m_When = when;
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );

			writer.WriteEncodedInt( (int) 0 ); // version

			writer.WriteDeltaTime( m_When );
		}

		public MongbatHideoutBossPuzzleChestSolutionAndTime( GenericReader reader ) : base( reader )
		{
			int version = reader.ReadEncodedInt();

			m_When = reader.ReadDeltaTime();
		}
	}

	public abstract class MongbatHideoutBossPuzzleChest : BaseTreasureChest
	{
		public const int HintsCount = 3;
		public readonly TimeSpan CleanupTime = TimeSpan.FromHours( 1.0 );

		private MongbatHideoutBossPuzzleChestSolution m_Solution;
		private MongbatHideoutBossPuzzleChestCylinder[] m_Hints = new MongbatHideoutBossPuzzleChestCylinder[HintsCount];
		private Dictionary<Mobile, MongbatHideoutBossPuzzleChestSolutionAndTime> m_Guesses = new Dictionary<Mobile, MongbatHideoutBossPuzzleChestSolutionAndTime>();

		public MongbatHideoutBossPuzzleChestSolution Solution
		{
			get{ return m_Solution; }
			set
			{
				m_Solution = value;
				InitHints();
			}
		}

		public MongbatHideoutBossPuzzleChestCylinder[] Hints{ get{ return m_Hints; } }

		public MongbatHideoutBossPuzzleChestCylinder FirstHint{ get{ return m_Hints[0]; } set{ m_Hints[0] = value; } }
		public MongbatHideoutBossPuzzleChestCylinder SecondHint{ get{ return m_Hints[1]; } set{ m_Hints[1] = value; } }
		public MongbatHideoutBossPuzzleChestCylinder ThirdHint{ get{ return m_Hints[2]; } set{ m_Hints[2] = value; } }

		public override string DefaultName
		{
			get { return null; }
		}

		public MongbatHideoutBossPuzzleChest( int itemID ) : base( itemID )
		{
		}

		private void InitHints()
		{
			List<MongbatHideoutBossPuzzleChestCylinder> list = new List<MongbatHideoutBossPuzzleChestCylinder>( Solution.Cylinders.Length - 1 );
			for ( int i = 1; i < Solution.Cylinders.Length; i++ )
				list.Add( Solution.Cylinders[i] );

			m_Hints = new MongbatHideoutBossPuzzleChestCylinder[HintsCount];
			
			for ( int i = 0; i < m_Hints.Length; i++ ) {
				int pos = Utility.Random( list.Count );
				m_Hints[i] = list[pos];
				list.RemoveAt( pos );
			}
		}

		protected override void SetLockLevel()
		{
			LockLevel = 0; // Can't be unlocked
		}

		public override bool CheckLocked( Mobile from )
		{
			if ( Locked )
			{
				MongbatHideoutBossPuzzleChestSolution solution = GetLastGuess( from );
				if ( solution != null )
					solution = new MongbatHideoutBossPuzzleChestSolution( solution );
				else
					solution = new MongbatHideoutBossPuzzleChestSolution( MongbatHideoutBossPuzzleChestCylinder.None, MongbatHideoutBossPuzzleChestCylinder.None, MongbatHideoutBossPuzzleChestCylinder.None, MongbatHideoutBossPuzzleChestCylinder.None, MongbatHideoutBossPuzzleChestCylinder.None );

				from.CloseGump( typeof( MongbatHideoutBossPuzzleGump ) );
				from.CloseGump( typeof( MongbatHideoutChestStatusGump ) );
				from.SendGump( new MongbatHideoutBossPuzzleGump( from, this, solution, 0 ) );

				return true;
			}
			else
			{
				return false;
			}
		}

		public MongbatHideoutBossPuzzleChestSolutionAndTime GetLastGuess( Mobile m )
		{
			MongbatHideoutBossPuzzleChestSolutionAndTime pcst = null;
			m_Guesses.TryGetValue( m, out pcst );
			return pcst;
		}

		public void SubmitSolution( Mobile m, MongbatHideoutBossPuzzleChestSolution solution )
		{
			int correctCylinders, correctColors;

			if ( solution.Matches( this.Solution, out correctCylinders, out correctColors ) )
			{
				LockPick( m );

				DisplayTo( m );
			}
			else
			{
				m_Guesses[m] = new MongbatHideoutBossPuzzleChestSolutionAndTime( DateTime.Now, solution );

				m.SendGump( new MongbatHideoutChestStatusGump( correctCylinders, correctColors ) );

				DoDamage( m );
			}
		}

		public void DoDamage( Mobile to )
		{
			switch ( Utility.Random( 14 ) )
			{
				case 0:
				{
					to.PlaySound( to.Female ? 781 : 1052 );
					to.Say( "*blows nose*" );
					if ( !to.Mounted )
						to.Animate( 34, 5, 1, true, false, 0 );

					AOS.Damage( to, to, Utility.RandomMinMax( 0, 0 ), 0, 0, 0, 0, 0 );

					break;
				}
				case 1:
				{
					to.PlaySound( to.Female ? 786 : 1057 );
					to.Say( "*bs cough*" );

					AOS.Damage( to, to, Utility.RandomMinMax( 0, 0 ), 0, 0, 0, 0, 0 );

					break;
				}
				case 2:
				{
					to.PlaySound( to.Female ? 782 : 1053 );
					to.Say( "*burp!*" );
					if ( !to.Mounted )
						to.Animate( 33, 5, 1, true, false, 0 );

					AOS.Damage( to, to, Utility.RandomMinMax( 0, 0 ), 0, 0, 0, 0, 0 );

					break;
				}
				case 3:
				{
					to.PlaySound( to.Female ? 748 : 1055 );
					to.Say( "*clears throat*" );
					if ( !to.Mounted )
						to.Animate( 33, 5, 1, true, false, 0 );

					AOS.Damage( to, to, Utility.RandomMinMax( 0, 0 ), 0, 0, 0, 0, 0 );

					break;
				}
				case 4:
				{
					to.PlaySound( to.Female ? 785 : 1056 );
					to.Say( "*cough!*" );				
					if ( !to.Mounted )
						to.Animate( 33, 5, 1, true, false, 0 );

					AOS.Damage( to, to, Utility.RandomMinMax( 0, 0 ), 0, 0, 0, 0, 0 );

					break;
				}
				case 5:
				{
					to.PlaySound( to.Female ? 787 : 1058 );
					to.Say( "*cries*" );

					AOS.Damage( to, to, Utility.RandomMinMax( 0, 0 ), 0, 0, 0, 0, 0 );

					break;
				}
				case 6:
				{
					to.PlaySound( to.Female ? 796 : 1068 );
					to.Say( "*growls*" );

					AOS.Damage( to, to, Utility.RandomMinMax( 0, 0 ), 0, 0, 0, 0, 0 );

					break;
				}
				case 7:
				{
					to.PlaySound( to.Female ? 798 : 1070 );
					to.Say( "*hiccup!*" );

					AOS.Damage( to, to, Utility.RandomMinMax( 0, 0 ), 0, 0, 0, 0, 0 );

					break;
				}
				case 8:
				{
					to.PlaySound( to.Female ? 802 : 1074 );
					to.Say( "*no!*" );

					AOS.Damage( to, to, Utility.RandomMinMax( 0, 0 ), 0, 0, 0, 0, 0 );

					break;
				}
				case 9:
				{
					to.PlaySound( to.Female ? 812 : 1086 );
					to.Say( "*oops*" );

					AOS.Damage( to, to, Utility.RandomMinMax( 0, 0 ), 0, 0, 0, 0, 0 );

					break;
				}
				case 10:
				{
					to.PlaySound( to.Female ? 796 : 1068 );

					to.PlaySound( 315 );
					to.Say( "*punches*" );
					if ( !to.Mounted )
						to.Animate( 31, 5, 1, true, false, 0 );

					AOS.Damage( to, to, Utility.RandomMinMax( 0, 0 ), 0, 0, 0, 0, 0 );

					break;
				}
				case 11:
				{
					to.PlaySound( to.Female ? 816 : 1090 );
					to.Say( "*sigh*" );

					AOS.Damage( to, to, Utility.RandomMinMax( 0, 0 ), 0, 0, 0, 0, 0 );

					break;
				}
				case 12:
				{
					to.PlaySound( to.Female ? 820 : 1094 );
					to.Say( "*spits*" );
					if ( !to.Mounted )
						to.Animate( 6, 5, 1, true, false, 0 );

					AOS.Damage( to, to, Utility.RandomMinMax( 0, 0 ), 0, 0, 0, 0, 0 );

					break;
				}
				default:
				{
					to.PlaySound( to.Female ? 823 : 1098 );
					to.Say( "*yells*" );

					AOS.Damage( to, to, Utility.RandomMinMax( 0, 0 ), 0, 0, 0, 0, 0 );

					break;
				}
			}
		}

		private class MongbatHideoutBossPuzzleGump : Gump
		{
			private Mobile m_From;
			private MongbatHideoutBossPuzzleChest m_Chest;
			private MongbatHideoutBossPuzzleChestSolution m_Solution;

			public MongbatHideoutBossPuzzleGump( Mobile from, MongbatHideoutBossPuzzleChest chest, MongbatHideoutBossPuzzleChestSolution solution, int check ) : base( 50, 50 )
			{
				m_From = from;
				m_Chest = chest;
				m_Solution = solution;

				Dragable = false;

				AddBackground( 25, 0, 500, 410, 0x53 );

				AddImage( 62, 20, 0x67 );

				AddHtmlLocalized( 80, 36, 110, 70, 1018309, true, false ); // A Puzzle Lock

				/* Correctly choose the sequence of cylinders needed to open the latch.  Each cylinder
				 * may potentially be used more than once.  Beware!  A false attempt could be deadly!
				 */
				AddHtmlLocalized( 214, 26, 270, 90, 1018310, true, true );

				AddLeftCylinderButton( 62, 130, MongbatHideoutBossPuzzleChestCylinder.LightBlue, 10 );
				AddLeftCylinderButton( 62, 180, MongbatHideoutBossPuzzleChestCylinder.Blue, 11 );
				AddLeftCylinderButton( 62, 230, MongbatHideoutBossPuzzleChestCylinder.Green, 12 );
				AddLeftCylinderButton( 62, 280, MongbatHideoutBossPuzzleChestCylinder.Orange, 13 );

				AddRightCylinderButton( 451, 130, MongbatHideoutBossPuzzleChestCylinder.Purple, 14 );
				AddRightCylinderButton( 451, 180, MongbatHideoutBossPuzzleChestCylinder.Red, 15 );
				AddRightCylinderButton( 451, 230, MongbatHideoutBossPuzzleChestCylinder.DarkBlue, 16 );
				AddRightCylinderButton( 451, 280, MongbatHideoutBossPuzzleChestCylinder.Yellow, 17 );

				double lockpicking = from.Skills.Lockpicking.Base;
				if ( lockpicking >= 45.0 )
				{
					AddHtmlLocalized( 160, 125, 230, 24, 1018308, false, false ); // Lockpicking hint:

					AddBackground( 159, 150, 230, 95, 0x13EC );

					if ( lockpicking >= 50.0 )
					{
						AddHtmlLocalized( 165, 157, 200, 40, 1018312, false, false ); // In the first slot:
						AddCylinder( 350, 165, chest.Solution.First );

						AddHtmlLocalized( 165, 197, 200, 40, 1018313, false, false ); // Used in unknown slot:
						AddCylinder( 350, 200, chest.FirstHint );

						if ( lockpicking >= 65.0 )
							AddCylinder( 350, 212, chest.SecondHint );

						if ( lockpicking >= 70.0 )
							AddCylinder( 350, 224, chest.ThirdHint );
					}
					else
					{
						AddHtmlLocalized( 165, 157, 200, 40, 1018313, false, false ); // Used in unknown slot:
						AddCylinder( 350, 160, chest.FirstHint );

						if ( lockpicking >= 65.0 )
							AddCylinder( 350, 172, chest.SecondHint );
					}
				}

				MongbatHideoutBossPuzzleChestSolution lastGuess = chest.GetLastGuess( from );
				if ( lastGuess != null )
				{
					AddHtmlLocalized( 127, 249, 170, 20, 1018311, false, false ); // Thy previous guess:

					AddBackground( 290, 247, 115, 25, 0x13EC );

					AddCylinder( 281, 254, lastGuess.First );
					AddCylinder( 303, 254, lastGuess.Second );
					AddCylinder( 325, 254, lastGuess.Third );
					AddCylinder( 347, 254, lastGuess.Fourth );
					AddCylinder( 369, 254, lastGuess.Fifth );
				}

				AddPedestal( 140, 270, solution.First, 0, check == 0 );
				AddPedestal( 195, 270, solution.Second, 1, check == 1 );
				AddPedestal( 250, 270, solution.Third, 2, check == 2 );
				AddPedestal( 305, 270, solution.Fourth, 3, check == 3 );
				AddPedestal( 360, 270, solution.Fifth, 4, check == 4 );

				AddButton( 258, 370, 0xFA5, 0xFA7, 1, GumpButtonType.Reply, 0 );
			}

			private void AddLeftCylinderButton( int x, int y, MongbatHideoutBossPuzzleChestCylinder cylinder, int buttonID )
			{
				AddBackground( x, y, 30, 30, 0x13EC );
				AddCylinder( x - 7, y + 10, cylinder );
				AddButton( x + 38, y + 9, 0x13A8, 0x4B9, buttonID, GumpButtonType.Reply, 0 );
			}

			private void AddRightCylinderButton( int x, int y, MongbatHideoutBossPuzzleChestCylinder cylinder, int buttonID )
			{
				AddBackground( x, y, 30, 30, 0x13EC );
				AddCylinder( x - 7, y + 10, cylinder );
				AddButton( x - 26, y + 9, 0x13A8, 0x4B9, buttonID, GumpButtonType.Reply, 0 );
			}

			private void AddPedestal( int x, int y, MongbatHideoutBossPuzzleChestCylinder cylinder, int switchID, bool initialState )
			{
				AddItem( x, y, 0xB10 );
				AddItem( x - 23, y + 12, 0xB12 );
				AddItem( x + 23, y + 12, 0xB13 );
				AddItem( x, y + 23, 0xB11 );

				if ( cylinder != MongbatHideoutBossPuzzleChestCylinder.None )
				{
					AddItem( x, y + 2, 0x51A );
					AddCylinder( x - 1, y + 19, cylinder );
				}
				else
				{
					AddItem( x, y + 2, 0x521 );
				}

				AddRadio( x + 7, y + 65, 0x867, 0x86A, initialState, switchID );
			}

			private void AddCylinder( int x, int y, MongbatHideoutBossPuzzleChestCylinder cylinder )
			{
				if ( cylinder != MongbatHideoutBossPuzzleChestCylinder.None )
					AddItem( x, y, (int)cylinder );
				else
					AddItem( x + 9, y, (int)cylinder );
			}

			public override void OnResponse( NetState sender, RelayInfo info )
			{
				if ( m_Chest.Deleted || info.ButtonID == 0 || !m_From.CheckAlive() )
					return;

				if ( m_From.AccessLevel == AccessLevel.Player && ( m_From.Map != m_Chest.Map || !m_From.InRange( m_Chest.GetWorldLocation(), 2 ) ) )
				{
					m_From.LocalOverheadMessage( MessageType.Regular, 0x3B2, 500446 ); // That is too far away.
					return;
				}

				if ( info.ButtonID == 1 )
				{
					m_Chest.SubmitSolution( m_From, m_Solution );
				}
				else
				{
					if ( info.Switches.Length == 0 )
						return;

					int pedestal = info.Switches[0];
					if ( pedestal < 0 || pedestal >= m_Solution.Cylinders.Length )
						return;

					MongbatHideoutBossPuzzleChestCylinder cylinder;
					switch ( info.ButtonID )
					{
						case 10: cylinder = MongbatHideoutBossPuzzleChestCylinder.LightBlue; break;
						case 11: cylinder = MongbatHideoutBossPuzzleChestCylinder.Blue; break;
						case 12: cylinder = MongbatHideoutBossPuzzleChestCylinder.Green; break;
						case 13: cylinder = MongbatHideoutBossPuzzleChestCylinder.Orange; break;
						case 14: cylinder = MongbatHideoutBossPuzzleChestCylinder.Purple; break;
						case 15: cylinder = MongbatHideoutBossPuzzleChestCylinder.Red; break;
						case 16: cylinder = MongbatHideoutBossPuzzleChestCylinder.DarkBlue; break;
						case 17: cylinder = MongbatHideoutBossPuzzleChestCylinder.Yellow; break;
						default: return;
					}

					m_Solution.Cylinders[pedestal] = cylinder;

					m_From.SendGump( new MongbatHideoutBossPuzzleGump( m_From, m_Chest, m_Solution, pedestal ) );
				}
			}
		}

		private class MongbatHideoutChestStatusGump : Gump
		{
			public MongbatHideoutChestStatusGump( int correctCylinders, int correctColors ) : base( 50, 50 )
			{
				AddBackground( 15, 250, 305, 163, 0x53 );
				AddBackground( 28, 265, 280, 133, 0xBB8 );

				AddHtmlLocalized( 35, 271, 270, 24, 1018314, false, false ); // Thou hast failed to solve the puzzle!

				AddHtmlLocalized( 35, 297, 250, 24, 1018315, false, false ); // Correctly placed colors:
				AddLabel( 285, 297, 0x44, correctCylinders.ToString() );

				AddHtmlLocalized( 35, 323, 250, 24, 1018316, false, false ); // Used colors in wrong slots:
				AddLabel( 285, 323, 0x44, correctColors.ToString() );

				AddButton( 152, 369, 0xFA5, 0xFA7, 0, GumpButtonType.Reply, 0 );
			}
		}

		public override void LockPick( Mobile from )
		{
			base.LockPick( from );

			m_Guesses.Clear();
		}

		private static void GetRandomAOSStats( out int attributeCount, out int min, out int max )
		{
			int rnd = Utility.Random( 15 );

			if ( rnd < 1 )
			{
				attributeCount = Utility.RandomMinMax( 2, 6 );
				min = 20; max = 70;
			}
			else if ( rnd < 3 )
			{
				attributeCount = Utility.RandomMinMax( 2, 4 );
				min = 20; max = 50;
			}
			else if ( rnd < 6 )
			{
				attributeCount = Utility.RandomMinMax( 2, 3 );
				min = 20; max = 40;
			}
			else if ( rnd < 10 )
			{
				attributeCount = Utility.RandomMinMax( 1, 2 );
				min = 10; max = 30;
			}
			else
			{
				attributeCount = 1;
				min = 10; max = 20;
			}
		}

		protected override void GenerateTreasure()
		{
			DropItem( new Gold( 5000 ) );

			List<Item> gems = new List<Item>();
			for ( int i = 0; i < 9; i++ )
			{
				Item gem = Loot.RandomGem();
				Type gemType = gem.GetType();

				foreach ( Item listGem in gems ) 
                                {
					if ( listGem.GetType() == gemType ) 
                                        {
						listGem.Amount++;
						gem.Delete();
						break;
					}
				}

				if ( !gem.Deleted )
					gems.Add( gem );
			}

			foreach ( Item gem in gems )
				DropItem( gem );

			DropItem( new BagOfAllReagents( 200 ) );

			DropItem( new Arrow( 500 ) );

			switch ( Utility.Random( 3 ) )
			{
				case 0: DropItem( new AshArrow(500) ); break;
				case 1: DropItem( new OakArrow(400) ); break;
				case 2: DropItem( new YewArrow(300) ); break;
			}

			DropItem( new Bolt( 200 ) );

			switch ( Utility.Random( 3 ) )
			{
				case 0: DropItem( new DullCopperBolt(500) ); break;
				case 1: DropItem( new ShadowIronBolt(400) ); break;
				case 2: DropItem( new BronzeBolt(300) ); break;
			}

			DropItem( new Bandage( 100 ) );

		        DropItem( new DyeTub() );

			switch ( Utility.Random( 3 ) )
			{
				case 0: DropItem( new DullCopperIngot(500) ); break;
				case 1: DropItem( new ShadowIronIngot(400) ); break;
				case 2: DropItem( new BronzeIngot(300) ); break;
			}

			switch ( Utility.Random( 17 ) )
			{
				case 0: DropItem( new ArcaneStone(200) ); break;
				case 1: DropItem( new BeetleEgg(200) ); break;
				case 2: DropItem( new BlackGear(200) ); break;
				case 3: DropItem( new Bonemeal(200) ); break;
				case 4: DropItem( new BronzeGear(200) ); break;
				case 5: DropItem( new CharredFeather(200) ); break;
				case 6: DropItem( new CrimsonGear(200) ); break;
				case 7: DropItem( new DiamondDust(200) ); break;
				case 8: DropItem( new DragonScale(200) ); break;
				case 9: DropItem( new ElementalDust(200) ); break;
				case 10: DropItem( new FishScale(200) ); break;
				case 11: DropItem( new LichDust(200) ); break;
				case 12: DropItem( new Nirnroot(200) ); break;
				case 13: DropItem( new SerpentScale(200) ); break;
				case 14: DropItem( new ShadowEssence(200) ); break;
				case 15: DropItem( new SpiderEgg(200) ); break;
				case 16: DropItem( new ThunderStone(200) ); break;
			}

			for ( int i = 0; i < 2; i++ )
			{
				Item item;

				if ( Core.AOS )
					item = Loot.RandomArmorOrShieldOrWeaponOrJewelry();
				else
					item = Loot.RandomArmorOrShieldOrWeapon();

				if ( item is BaseWeapon )
				{
					BaseWeapon weapon = (BaseWeapon)item;

					if ( Core.AOS )
					{
						int attributeCount;
						int min, max;

						GetRandomAOSStats( out attributeCount, out min, out max );

						BaseRunicTool.ApplyAttributesTo( weapon, attributeCount, min, max );
					}
					else
					{
						weapon.DamageLevel = (WeaponDamageLevel)Utility.Random( 6 );
						weapon.AccuracyLevel = (WeaponAccuracyLevel)Utility.Random( 6 );
						weapon.DurabilityLevel = (WeaponDurabilityLevel)Utility.Random( 6 );
					}

					DropItem( item );
				}
				else if ( item is BaseArmor )
				{
					BaseArmor armor = (BaseArmor)item;

					if ( Core.AOS )
					{
						int attributeCount;
						int min, max;

						GetRandomAOSStats( out attributeCount, out min, out max );

						BaseRunicTool.ApplyAttributesTo( armor, attributeCount, min, max );
					}
					else
					{
						armor.ProtectionLevel = (ArmorProtectionLevel)Utility.Random( 6 );
						armor.Durability = (ArmorDurabilityLevel)Utility.Random( 6 );
					}

					DropItem( item );
				}
				else if( item is BaseClothing )
				{
					BaseClothing clothing = (BaseClothing)item;

					if( Core.AOS )
					{
						int attributeCount;
						int min, max;

						GetRandomAOSStats( out attributeCount, out min, out  max );

						BaseRunicTool.ApplyAttributesTo( clothing, attributeCount, min, max );
					}

					DropItem( item );
				}
				else if( item is BaseHat )
				{
					BaseHat hat = (BaseHat)item;

					if( Core.AOS )
					{
						int attributeCount;
						int min, max;

						GetRandomAOSStats( out attributeCount, out min, out  max );

						BaseRunicTool.ApplyAttributesTo( hat, attributeCount, min, max );
					}

					DropItem( item );
				}
				else if( item is BaseJewel )
				{
					int attributeCount;
					int min, max;

					GetRandomAOSStats( out attributeCount, out min, out max );

					BaseRunicTool.ApplyAttributesTo( (BaseJewel)item, attributeCount, min, max );

					DropItem( item );
				}
			}

			Solution = new MongbatHideoutBossPuzzleChestSolution();
		}

		public void CleanupGuesses()
		{
			List<Mobile> toDelete = new List<Mobile>();

			foreach ( KeyValuePair<Mobile, MongbatHideoutBossPuzzleChestSolutionAndTime> kvp in m_Guesses ) {
				if ( DateTime.Now - kvp.Value.When > CleanupTime )
					toDelete.Add( kvp.Key );
			}

			foreach ( Mobile m in toDelete )
				m_Guesses.Remove( m );
		}

		public MongbatHideoutBossPuzzleChest( Serial serial ) : base( serial )
		{
		}

		public override void Serialize( GenericWriter writer )
		{
			CleanupGuesses();

			base.Serialize( writer );

			writer.WriteEncodedInt( (int) 0 ); // version

			m_Solution.Serialize( writer );

			writer.WriteEncodedInt( (int) m_Hints.Length );
			for ( int i = 0; i < m_Hints.Length; i++ )
			{
				writer.Write( (int) m_Hints[i] );
			}

			writer.WriteEncodedInt( (int) m_Guesses.Count );
			foreach ( KeyValuePair<Mobile, MongbatHideoutBossPuzzleChestSolutionAndTime> kvp in m_Guesses ) {
				writer.Write( kvp.Key );
				kvp.Value.Serialize( writer );
			}
		}

		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader );

			int version = reader.ReadEncodedInt();

			m_Solution = new MongbatHideoutBossPuzzleChestSolution( reader );

			int length = reader.ReadEncodedInt();
			for ( int i = 0; i < length; i++ )
			{
				MongbatHideoutBossPuzzleChestCylinder cylinder = (MongbatHideoutBossPuzzleChestCylinder) reader.ReadInt();

				if ( length == m_Hints.Length )
					m_Hints[i] = cylinder;
			}
			if ( length != m_Hints.Length )
				InitHints();

			int guesses = reader.ReadEncodedInt();
			for ( int i = 0; i < guesses; i++ )
			{
				Mobile m = reader.ReadMobile();
				MongbatHideoutBossPuzzleChestSolutionAndTime sol = new MongbatHideoutBossPuzzleChestSolutionAndTime( reader );

				m_Guesses[m] = sol;
			}
		}
	}

	public class MongbatHideoutBossChampionChest : MongbatHideoutBossPuzzleChest
	{
                public override bool Decays{ get{ return true; } } 

                public override TimeSpan DecayTime
                { 
                     get
                     { 
                          return TimeSpan.FromMinutes( 60 ); 
                     } 
                }

                public override int DefaultGumpID{ get{ return 0x49; } }
                public override int DefaultDropSound{ get{ return 0x42; } }

                public override Rectangle2D Bounds
                {
                       get{ return new Rectangle2D( 18, 105, 144, 73 ); }
                }

		[Constructable]
		public MongbatHideoutBossChampionChest() : base( 0x2DF2 )
		{
		        Name = "a boss treasure chest [45-70] - This chest self-deletes in 1 hour";
		        Movable = true;
                        ItemID = 0x2DF2;
			LootType = LootType.Blessed;
		}

		public MongbatHideoutBossChampionChest( Serial serial ) : base( serial )
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
	}
}