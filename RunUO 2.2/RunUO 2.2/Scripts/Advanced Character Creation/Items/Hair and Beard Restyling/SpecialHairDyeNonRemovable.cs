using System;
using System.Text;
using Server.Gumps;
using Server.Network;

namespace Server.Items
{
	public class SpecialHairDyeNonRemovable : Item
	{
		public override string DefaultName
		{
			get { return "Special Hair Dye"; }
		}

		[Constructable]
		public SpecialHairDyeNonRemovable() : base( 0xE26 )
		{
			Weight = 1.0;
                        Movable = false;
		}

		public SpecialHairDyeNonRemovable( Serial serial ) : base( serial )
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

		public override void OnDoubleClick( Mobile from )
		{
			from.CloseGump( typeof( SpecialHairDyeNonRemovableGump ) );
			from.SendGump( new SpecialHairDyeNonRemovableGump( this ) );		
		}
	}

	public class SpecialHairDyeNonRemovableGump : Gump
	{
		private SpecialHairDyeNonRemovable m_SpecialHairDyeNonRemovable;

		private class SpecialHairDyeNonRemovableEntry
		{
			private string m_Name;
			private int m_HueStart;
			private int m_HueCount;

			public string Name
			{
				get
				{
					return m_Name;
				}
			}

			public int HueStart
			{
				get
				{
					return m_HueStart;
				}
			}

			public int HueCount
			{
				get
				{
					return m_HueCount;
				}
			}

			public SpecialHairDyeNonRemovableEntry( string name, int hueStart, int hueCount )
			{
				m_Name = name;
				m_HueStart = hueStart;
				m_HueCount = hueCount;
			}
		}

		private static SpecialHairDyeNonRemovableEntry[] m_Entries = new SpecialHairDyeNonRemovableEntry[]
			{
				new SpecialHairDyeNonRemovableEntry( "*****", 12, 10 ),
				new SpecialHairDyeNonRemovableEntry( "*****", 32, 5 ),
				new SpecialHairDyeNonRemovableEntry( "*****", 38, 8 ),
				new SpecialHairDyeNonRemovableEntry( "*****", 54, 3 ),
				new SpecialHairDyeNonRemovableEntry( "*****", 62, 10 ),
				new SpecialHairDyeNonRemovableEntry( "*****", 81, 2 ),
				new SpecialHairDyeNonRemovableEntry( "*****", 89, 2 ),
				new SpecialHairDyeNonRemovableEntry( "*****", 1153, 2 )
		};

		public SpecialHairDyeNonRemovableGump( SpecialHairDyeNonRemovable dye ) : base( 0, 0 )
		{
			m_SpecialHairDyeNonRemovable = dye;

			AddPage( 0 );
			AddBackground( 150, 60, 350, 358, 2600 );
			AddBackground( 170, 104, 110, 270, 5100 );
			AddHtmlLocalized( 230, 75, 200, 20, 1011013, false, false );		// Hair Color Selection Menu
			AddHtmlLocalized( 235, 380, 300, 20, 1011014, false, false );		// Dye my hair this color!
			AddButton( 200, 380, 0xFA5, 0xFA7, 1, GumpButtonType.Reply, 0 );        // DYE HAIR

			for ( int i = 0; i < m_Entries.Length; ++i )
			{
				AddLabel( 180, 109 + (i * 22), m_Entries[i].HueStart - 1, m_Entries[i].Name );
				AddButton( 257, 110 + (i * 22), 5224, 5224, 0, GumpButtonType.Page, i + 1 );
			}

			for ( int i = 0; i < m_Entries.Length; ++i )
			{
				SpecialHairDyeNonRemovableEntry e = m_Entries[i];

				AddPage( i + 1 );

				for ( int j = 0; j < e.HueCount; ++j )
				{
					AddLabel( 328 + ((j / 16) * 80), 102 + ((j % 16) * 17), e.HueStart + j - 1, "*****" );
					AddRadio( 310 + ((j / 16) * 80), 102 + ((j % 16) * 17), 210, 211, false, (i * 100) + j );
				}
			}
		}

		public override void OnResponse( NetState from, RelayInfo info )
		{
			if ( m_SpecialHairDyeNonRemovable.Deleted )
				return;

			Mobile m = from.Mobile;
			int[] switches = info.Switches;

			if ( info.ButtonID != 0 && switches.Length > 0 )
			{
				if( m.HairItemID == 0 )
				{
					m.SendLocalizedMessage( 502623 );	// You have no hair to dye and cannot use this
				}
				else
				{
					// To prevent this from being exploited, the hue is abstracted into an internal list

					int entryIndex = switches[0] / 100;
					int hueOffset = switches[0] % 100;

					if ( entryIndex >= 0 && entryIndex < m_Entries.Length )
					{
						SpecialHairDyeNonRemovableEntry e = m_Entries[entryIndex];

						if ( hueOffset >= 0 && hueOffset < e.HueCount )
						{
							int hue = e.HueStart + hueOffset;

							m.HairHue = hue;
							
							m.SendLocalizedMessage( 501199 );  // You dye your hair
							m.PlaySound( 0x4E );
						}
					}
				}
			}
			else
			{
				m.SendLocalizedMessage( 501200 ); // You decide not to dye your hair
			}
		}
	}
}