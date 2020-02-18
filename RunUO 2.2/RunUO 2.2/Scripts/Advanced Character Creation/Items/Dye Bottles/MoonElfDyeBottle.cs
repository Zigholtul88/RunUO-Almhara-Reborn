using System;
using Server.Gumps;
using Server.Mobiles;
using Server.Network;
using System.Text;

namespace Server.Items
{
	public class MoonElfDyeBottle : Item
	{
		public override string DefaultName
		{
			get { return "Moon Elf Dye Bottle"; }
		}

		[Constructable]
		public MoonElfDyeBottle() : base( 0xE26 )
		{
			Weight = 1.0;
                  	Movable = false;
		}

		public MoonElfDyeBottle( Serial serial ) : base( serial )
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
			if ( from.InRange( this.GetWorldLocation(), 1 ) && from.Title == "the Svartalfar" )
			{
				from.CloseGump( typeof( MoonElfDyeBottleGump ) );
				from.SendGump( new MoonElfDyeBottleGump( this ) );
				from.SendMessage( "Select a color to dye your skin" );
			}
                        else
                        {
				from.SendMessage( "You must be a svartalfar in order to use this" );
                        }				
		}
	}

	public class MoonElfDyeBottleGump : Gump
	{
		private MoonElfDyeBottle m_MoonElfDyeBottle;

		public MoonElfDyeBottleGump( MoonElfDyeBottle dye ) : base( 50, 50 )
		{
			m_MoonElfDyeBottle = dye;

			AddPage( 0 );
			AddBackground( 0, 0, 220, 630, 5054 );
			AddBackground( 10, 10, 200, 610, 3000 );
			AddLabel( 20, 20, 0, "Moon Elf Skin Hue Selector");
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
			AddButton( 20, 390, 4005, 4007, 16, GumpButtonType.Reply, 0 );
			AddButton( 20, 410, 4005, 4007, 17, GumpButtonType.Reply, 0 );
			AddButton( 20, 430, 4005, 4007, 18, GumpButtonType.Reply, 0 );
			AddButton( 20, 450, 4005, 4007, 19, GumpButtonType.Reply, 0 );
			AddButton( 20, 470, 4005, 4007, 20, GumpButtonType.Reply, 0 );
			AddButton( 20, 490, 4005, 4007, 21, GumpButtonType.Reply, 0 );
			AddButton( 20, 510, 4005, 4007, 22, GumpButtonType.Reply, 0 );
			AddButton( 20, 530, 4005, 4007, 23, GumpButtonType.Reply, 0 );

			AddLabel( 55,  90, 897, "Moon Elf 1");
			AddLabel( 55, 110, 898, "Moon Elf 2");
			AddLabel( 55, 130, 899, "Moon Elf 3");
			AddLabel( 55, 150, 900, "Moon Elf 4");
			AddLabel( 55, 170, 901, "Moon Elf 5");
			AddLabel( 55, 190, 905, "Moon Elf 6");
			AddLabel( 55, 210, 990, "Moon Elf 7");
			AddLabel( 55, 230, 995, "Moon Elf 8");
			AddLabel( 55, 250, 996, "Moon Elf 9");
			AddLabel( 55, 270, 997, "Moon Elf 10");
			AddLabel( 55, 290, 998, "Moon Elf 11");
			AddLabel( 55, 310, 999, "Moon Elf 12");
			AddLabel( 55, 330, 2401, "Moon Elf 13");
			AddLabel( 55, 350, 2402, "Moon Elf 14");
			AddLabel( 55, 370, 2403, "Moon Elf 15");
			AddLabel( 55, 390, 2404, "Moon Elf 16");
			AddLabel( 55, 410, 2405, "Moon Elf 17");
			AddLabel( 55, 430, 2406, "Moon Elf 18");
			AddLabel( 55, 450, 2407, "Moon Elf 19");
			AddLabel( 55, 470, 2408, "Moon Elf 20");
			AddLabel( 55, 490, 2409, "Moon Elf 21");
			AddLabel( 55, 510, 2410, "Moon Elf 22");
			AddLabel( 55, 530, 2411, "Moon Elf 23");
		}

		public override void OnResponse( NetState from, RelayInfo info )
		{
			if ( m_MoonElfDyeBottle.Deleted )
				return;

			Mobile m = from.Mobile;
			int[] switches = info.Switches;

			switch( info.ButtonID )
			{

			case 0: from.Mobile.SendMessage( "You decide not to hue your skin" ); break;

			case 1: from.Mobile.SendMessage( "You dye your skin Moon Elf 1" );
				from.Mobile.Hue = 897;
				m.PlaySound( 0x4E ); break;

			case 2: from.Mobile.SendMessage( "You dye your skin Moon Elf 2" );
				from.Mobile.Hue = 898;
				m.PlaySound( 0x4E ); break;

			case 3: from.Mobile.SendMessage( "You dye your skin Moon Elf 3" );
				from.Mobile.Hue = 899;
				m.PlaySound( 0x4E ); break;

			case 4: from.Mobile.SendMessage( "You dye your skin Moon Elf 4" );
				from.Mobile.Hue = 900;
				m.PlaySound( 0x4E ); break;

			case 5: from.Mobile.SendMessage( "You dye your skin Moon Elf 5" );
				from.Mobile.Hue = 901;
				m.PlaySound( 0x4E ); break;

			case 6: from.Mobile.SendMessage( "You dye your skin Moon Elf 6" );
				from.Mobile.Hue = 905;
				m.PlaySound( 0x4E ); break;

			case 7: from.Mobile.SendMessage( "You dye your skin Moon Elf 7" );
				from.Mobile.Hue = 990;
				m.PlaySound( 0x4E ); break;

			case 8: from.Mobile.SendMessage( "You dye your skin Moon Elf 8" );
				from.Mobile.Hue = 995;
				m.PlaySound( 0x4E ); break;

			case 9: from.Mobile.SendMessage( "You dye your skin Moon Elf 9" );
				from.Mobile.Hue = 996;
				m.PlaySound( 0x4E ); break;

			case 10: from.Mobile.SendMessage( "You dye your skin Moon Elf 10" );
				from.Mobile.Hue = 997;
				m.PlaySound( 0x4E ); break;

			case 11: from.Mobile.SendMessage( "You dye your skin Moon Elf 11" );
				from.Mobile.Hue = 998;
				m.PlaySound( 0x4E ); break;

			case 12: from.Mobile.SendMessage( "You dye your skin Moon Elf 12" );
				from.Mobile.Hue = 999;
				m.PlaySound( 0x4E ); break;

			case 13: from.Mobile.SendMessage( "You dye your skin Moon Elf 13" );
				from.Mobile.Hue = 2401;
				m.PlaySound( 0x4E ); break;

			case 14: from.Mobile.SendMessage( "You dye your skin Moon Elf 14" );
				from.Mobile.Hue = 2402;
				m.PlaySound( 0x4E ); break;

			case 15: from.Mobile.SendMessage( "You dye your skin Moon Elf 15" );
				from.Mobile.Hue = 2403;
				m.PlaySound( 0x4E ); break;

			case 16: from.Mobile.SendMessage( "You dye your skin Moon Elf 16" );
				from.Mobile.Hue = 2404;
				m.PlaySound( 0x4E ); break;

			case 17: from.Mobile.SendMessage( "You dye your skin Moon Elf 17" );
				from.Mobile.Hue = 2405;
				m.PlaySound( 0x4E ); break;
				
			case 18: from.Mobile.SendMessage( "You dye your skin Moon Elf 18" );
				from.Mobile.Hue = 2406;
				m.PlaySound( 0x4E ); break;
				
			case 19: from.Mobile.SendMessage( "You dye your skin Moon Elf 19" );
				from.Mobile.Hue = 2407;
				m.PlaySound( 0x4E ); break;	
				
			case 20: from.Mobile.SendMessage( "You dye your skin Moon Elf 20" );
				from.Mobile.Hue = 2408;
				m.PlaySound( 0x4E ); break;
				
			case 21: from.Mobile.SendMessage( "You dye your skin Moon Elf 21" );
				from.Mobile.Hue = 2409;
				m.PlaySound( 0x4E ); break;	
				
			case 22: from.Mobile.SendMessage( "You dye your skin Moon Elf 22" );
				from.Mobile.Hue = 2410;
				m.PlaySound( 0x4E ); break;			

			case 23: from.Mobile.SendMessage( "You dye your skin Moon Elf 23" );
				from.Mobile.Hue = 2411;
				m.PlaySound( 0x4E ); break;	
			}
		}
	}
}