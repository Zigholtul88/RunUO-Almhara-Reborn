using System;
using System.Text;
using Server.Gumps;
using Server.Items;
using Server.Mobiles;
using Server.Network;

namespace Server.Items
{
	public class YugitashiDyeBottle : Item
	{
		public override string DefaultName
		{
			get { return "Yugitashi Dye Bottle"; }
		}

		[Constructable]
		public YugitashiDyeBottle() : base( 0xE26 )
		{
			Weight = 1.0;
                  	Movable = false;
		}

		public YugitashiDyeBottle( Serial serial ) : base( serial )
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
			if ( from.InRange( this.GetWorldLocation(), 1 ) && from.Title == "the Yugitashi" )
			{
				from.CloseGump( typeof( YugitashiDyeBottleGump ) );
				from.SendGump( new YugitashiDyeBottleGump( this ) );
				from.SendMessage( "Select a color to dye your skin" );
			}
                        else
                        {
				from.SendMessage( "You must be a yugitashi in order to use this" );
                        }
		}
	}

	public class YugitashiDyeBottleGump : Gump
	{
		private YugitashiDyeBottle m_YugitashiDyeBottle;

		public YugitashiDyeBottleGump( YugitashiDyeBottle dye ) : base( 50, 50 )
		{
			m_YugitashiDyeBottle = dye;

			AddPage( 0 );
			AddBackground( 0, 0, 220, 630, 5054 );
			AddBackground( 10, 10, 200, 610, 3000 );
			AddLabel( 20, 20, 0, "Yugitashi Skin Hue Selector");
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

			AddLabel( 55,  90, 1043, "Yugitashi 1");
			AddLabel( 55, 110, 1044, "Yugitashi 2");
			AddLabel( 55, 130, 1045, "Yugitashi 3");
			AddLabel( 55, 150, 1046, "Yugitashi 4");
			AddLabel( 55, 170, 1047, "Yugitashi 5");
			AddLabel( 55, 190, 1048, "Yugitashi 6");
			AddLabel( 55, 210, 1049, "Yugitashi 7");
			AddLabel( 55, 230, 1050, "Yugitashi 8");
			AddLabel( 55, 250, 1051, "Yugitashi 9");
			AddLabel( 55, 270, 1053, "Yugitashi 10");
			AddLabel( 55, 290, 1054, "Yugitashi 11");
			AddLabel( 55, 310, 1055, "Yugitashi 12");
			AddLabel( 55, 330, 1056, "Yugitashi 13");
			AddLabel( 55, 350, 1057, "Yugitashi 14");
			AddLabel( 55, 370, 1058, "Yugitashi 15");
		}

		public override void OnResponse( NetState from, RelayInfo info )
		{
			if ( m_YugitashiDyeBottle.Deleted )
				return;

			Mobile m = from.Mobile;
			int[] switches = info.Switches;

			switch( info.ButtonID )
			{

			case 0: from.Mobile.SendMessage( "You decide not to hue your skin" ); break;

			case 1: from.Mobile.SendMessage( "You dye your skin Yugitashi 1" );
				from.Mobile.Hue = 1043;
		  		Item itema = m.FindItemOnLayer( Layer.Shirt );
	          		if ( itema is YugitashiTalisman )
	          		{
					itema.Hue = 1043;
                                }
				m.PlaySound( 0x4E ); break;

			case 2: from.Mobile.SendMessage( "You dye your skin Yugitashi 2" );
				from.Mobile.Hue = 1044;
		  		Item itemb = m.FindItemOnLayer( Layer.Shirt );
	          		if ( itemb is YugitashiTalisman )
	          		{
					itemb.Hue = 1044;
                                }
				m.PlaySound( 0x4E ); break;

			case 3: from.Mobile.SendMessage( "You dye your skin Yugitashi 3" );
				from.Mobile.Hue = 1045;
		  		Item itemc = m.FindItemOnLayer( Layer.Shirt );
	          		if ( itemc is YugitashiTalisman )
	          		{
					itemc.Hue = 1045;
                                }
				m.PlaySound( 0x4E ); break;

			case 4: from.Mobile.SendMessage( "You dye your skin Yugitashi 4" );
				from.Mobile.Hue = 1046;
		  		Item itemd = m.FindItemOnLayer( Layer.Shirt );
	          		if ( itemd is YugitashiTalisman )
	          		{
					itemd.Hue = 1046;
                                }
				m.PlaySound( 0x4E ); break;

			case 5: from.Mobile.SendMessage( "You dye your skin Yugitashi 5" );
				from.Mobile.Hue = 1047;
		  		Item iteme = m.FindItemOnLayer( Layer.Shirt );
	          		if ( iteme is YugitashiTalisman )
	          		{
					iteme.Hue = 1047;
                                }
				m.PlaySound( 0x4E ); break;

			case 6: from.Mobile.SendMessage( "You dye your skin Yugitashi 6" );
				from.Mobile.Hue = 1048;
		  		Item itemf = m.FindItemOnLayer( Layer.Shirt );
	          		if ( itemf is YugitashiTalisman )
	          		{
					itemf.Hue = 1048;
                                }
				m.PlaySound( 0x4E ); break;

			case 7: from.Mobile.SendMessage( "You dye your skin Yugitashi 7" );
				from.Mobile.Hue = 1049;
		  		Item itemg = m.FindItemOnLayer( Layer.Shirt );
	          		if ( itemg is YugitashiTalisman )
	          		{
					itemg.Hue = 1049;
                                }
				m.PlaySound( 0x4E ); break;

			case 8: from.Mobile.SendMessage( "You dye your skin Yugitashi 8" );
				from.Mobile.Hue = 1050;
		  		Item itemh = m.FindItemOnLayer( Layer.Shirt );
	          		if ( itemh is YugitashiTalisman )
	          		{
					itemh.Hue = 1050;
                                }
				m.PlaySound( 0x4E ); break;

			case 9: from.Mobile.SendMessage( "You dye your skin Yugitashi 9" );
				from.Mobile.Hue = 1051;
		  		Item itemi = m.FindItemOnLayer( Layer.Shirt );
	          		if ( itemi is YugitashiTalisman )
	          		{
					itemi.Hue = 1051;
                                }
				m.PlaySound( 0x4E ); break;

			case 10: from.Mobile.SendMessage( "You dye your skin Yugitashi 10" );
				from.Mobile.Hue = 1053;
		  		Item itemj = m.FindItemOnLayer( Layer.Shirt );
	          		if ( itemj is YugitashiTalisman )
	          		{
					itemj.Hue = 1053;
                                }
				m.PlaySound( 0x4E ); break;

			case 11: from.Mobile.SendMessage( "You dye your skin Yugitashi 11" );
				from.Mobile.Hue = 1054;
		  		Item itemk = m.FindItemOnLayer( Layer.Shirt );
	          		if ( itemk is YugitashiTalisman )
	          		{
					itemk.Hue = 1054;
                                }
				m.PlaySound( 0x4E ); break;

			case 12: from.Mobile.SendMessage( "You dye your skin Yugitashi 12" );
				from.Mobile.Hue = 1055;
		  		Item iteml = m.FindItemOnLayer( Layer.Shirt );
	          		if ( iteml is YugitashiTalisman )
	          		{
					iteml.Hue = 1055;
                                }
				m.PlaySound( 0x4E ); break;

			case 13: from.Mobile.SendMessage( "You dye your skin Yugitashi 13" );
				from.Mobile.Hue = 1056;
		  		Item itemm = m.FindItemOnLayer( Layer.Shirt );
	          		if ( itemm is YugitashiTalisman )
	          		{
					itemm.Hue = 1056;
                                }
				m.PlaySound( 0x4E ); break;

			case 14: from.Mobile.SendMessage( "You dye your skin Yugitashi 14" );
				from.Mobile.Hue = 1057;
		  		Item itemn = m.FindItemOnLayer( Layer.Shirt );
	          		if ( itemn is YugitashiTalisman )
	          		{
					itemn.Hue = 1057;
                                }
				m.PlaySound( 0x4E ); break;

			case 15: from.Mobile.SendMessage( "You dye your skin Yugitashi 15" );
				from.Mobile.Hue = 1058;
		  		Item itemo = m.FindItemOnLayer( Layer.Shirt );
	          		if ( itemo is YugitashiTalisman )
	          		{
					itemo.Hue = 1058;
                                }
				m.PlaySound( 0x4E ); break;				
			}
		}
	}
}