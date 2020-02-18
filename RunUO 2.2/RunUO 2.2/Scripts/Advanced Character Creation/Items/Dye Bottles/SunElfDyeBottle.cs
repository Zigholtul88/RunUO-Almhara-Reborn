using System;
using Server.Gumps;
using Server.Mobiles;
using Server.Network;
using System.Text;

namespace Server.Items
{
	public class SunElfDyeBottle : Item
	{
		public override string DefaultName
		{
			get { return "Sun Elf Dye Bottle"; }
		}

		[Constructable]
		public SunElfDyeBottle() : base( 0xE26 )
		{
			Weight = 1.0;
                  	Movable = false;
		}

		public SunElfDyeBottle( Serial serial ) : base( serial )
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
			if ( from.InRange( this.GetWorldLocation(), 1 ) && from.Title == "the Ljosalfar" )
			{
				from.CloseGump( typeof( SunElfDyeBottleGump ) );
				from.SendGump( new SunElfDyeBottleGump( this ) );
				from.SendMessage( "Select a color to dye your skin" );
			}
                        else
                        {
				from.SendMessage( "You must be a ljosalfar in order to use this" );
                        }
		}
	}

	public class SunElfDyeBottleGump : Gump
	{
		private SunElfDyeBottle m_SunElfDyeBottle;

		public SunElfDyeBottleGump( SunElfDyeBottle dye ) : base( 50, 50 )
		{
			m_SunElfDyeBottle = dye;

			AddPage( 0 );
			AddBackground( 0, 0, 220, 630, 5054 );
			AddBackground( 10, 10, 200, 610, 3000 );
			AddLabel( 20, 20, 0, "Sun Elf Skin Hue Selector");
			AddLabel( 20, 60, 0, "Select a Hue");
			AddButton( 20, 590, 4005, 4007, 0, GumpButtonType.Reply, 0 );
                        AddLabel( 55, 590, 0, "Close");

			AddPage( 1 );
			AddButton( 20,  90, 4005, 4007,  1, GumpButtonType.Reply, 0 );
			AddButton( 20, 110, 4005, 4007,  2, GumpButtonType.Reply, 0 );
			AddButton( 20, 130, 4005, 4007,  3, GumpButtonType.Reply, 0 );
			AddButton( 20, 150, 4005, 4007,  4, GumpButtonType.Reply, 0 );
			AddButton( 20, 170, 4005, 4007,  5, GumpButtonType.Reply, 0 );
			AddButton( 20, 190, 4005, 4007,  6, GumpButtonType.Reply, 0 );
			AddButton( 20, 210, 4005, 4007,  7, GumpButtonType.Reply, 0 );
			AddButton( 20, 230, 4005, 4007,  8, GumpButtonType.Reply, 0 );
			AddButton( 20, 250, 4005, 4007,  9, GumpButtonType.Reply, 0 );
			AddButton( 20, 270, 4005, 4007, 10, GumpButtonType.Reply, 0 );
			AddButton( 20, 290, 4005, 4007, 11, GumpButtonType.Reply, 0 );
			AddButton( 20, 310, 4005, 4007, 12, GumpButtonType.Reply, 0 );
			AddButton( 20, 330, 4005, 4007, 13, GumpButtonType.Reply, 0 );
			AddButton( 20, 350, 4005, 4007, 14, GumpButtonType.Reply, 0 );
			AddButton( 20, 370, 4005, 4007, 15, GumpButtonType.Reply, 0 );

			AddLabel( 55,  90, 1002, "Sun Elf 1");
			AddLabel( 55, 110, 1003, "Sun Elf 2");
			AddLabel( 55, 130, 1009, "Sun Elf 3");
			AddLabel( 55, 150, 1010, "Sun Elf 4");
			AddLabel( 55, 170, 1011, "Sun Elf 5");
			AddLabel( 55, 190, 1016, "Sun Elf 6");
			AddLabel( 55, 210, 1017, "Sun Elf 7");
			AddLabel( 55, 230, 1018, "Sun Elf 8");
			AddLabel( 55, 250, 1023, "Sun Elf 9");
			AddLabel( 55, 270, 1024, "Sun Elf 10");
			AddLabel( 55, 290, 1025, "Sun Elf 11");
			AddLabel( 55, 310, 1030, "Sun Elf 12");
			AddLabel( 55, 330, 1031, "Sun Elf 13");
			AddLabel( 55, 350, 1032, "Sun Elf 14");
			AddLabel( 55, 370, 1037, "Sun Elf 15");
		}

		public override void OnResponse( NetState from, RelayInfo info )
		{
			if ( m_SunElfDyeBottle.Deleted )
				return;

			Mobile m = from.Mobile;
			int[] switches = info.Switches;

			switch( info.ButtonID )
			{

			case 0: from.Mobile.SendMessage( "You decide not to hue your skin" ); break;

			case 1: from.Mobile.SendMessage( "You dye your skin Sun Elf 1" );
				from.Mobile.Hue = 1002;
				m.PlaySound( 0x4E ); break;

			case 2: from.Mobile.SendMessage( "You dye your skin Sun Elf 2" );
				from.Mobile.Hue = 1003;
				m.PlaySound( 0x4E ); break;

			case 3: from.Mobile.SendMessage( "You dye your skin Sun Elf 3" );
				from.Mobile.Hue = 1009;
				m.PlaySound( 0x4E ); break;

			case 4: from.Mobile.SendMessage( "You dye your skin Sun Elf 4" );
				from.Mobile.Hue = 1010;
				m.PlaySound( 0x4E ); break;

			case 5: from.Mobile.SendMessage( "You dye your skin Sun Elf 5" );
				from.Mobile.Hue = 1011;
				m.PlaySound( 0x4E ); break;

			case 6: from.Mobile.SendMessage( "You dye your skin Sun Elf 6" );
				from.Mobile.Hue = 1016;
				m.PlaySound( 0x4E ); break;

			case 7: from.Mobile.SendMessage( "You dye your skin Sun Elf 7" );
				from.Mobile.Hue = 1017;
				m.PlaySound( 0x4E ); break;

			case 8: from.Mobile.SendMessage( "You dye your skin Sun Elf 8" );
				from.Mobile.Hue = 1018;
				m.PlaySound( 0x4E ); break;

			case 9: from.Mobile.SendMessage( "You dye your skin Sun Elf 9" );
				from.Mobile.Hue = 1023;
				m.PlaySound( 0x4E ); break;

			case 10: from.Mobile.SendMessage( "You dye your skin Sun Elf 10" );
				from.Mobile.Hue = 1024;
				m.PlaySound( 0x4E ); break;

			case 11: from.Mobile.SendMessage( "You dye your skin Sun Elf 11" );
				from.Mobile.Hue = 1025;
				m.PlaySound( 0x4E ); break;

			case 12: from.Mobile.SendMessage( "You dye your skin Sun Elf 12" );
				from.Mobile.Hue = 1030;
				m.PlaySound( 0x4E ); break;

			case 13: from.Mobile.SendMessage( "You dye your skin Sun Elf 13" );
				from.Mobile.Hue = 1031;
				m.PlaySound( 0x4E ); break;

			case 14: from.Mobile.SendMessage( "You dye your skin Sun Elf 14" );
				from.Mobile.Hue = 1032;
				m.PlaySound( 0x4E ); break;

			case 15: from.Mobile.SendMessage( "You dye your skin Sun Elf 15" );
				from.Mobile.Hue = 1037;
				m.PlaySound( 0x4E ); break;				
			}
		}
	}
}