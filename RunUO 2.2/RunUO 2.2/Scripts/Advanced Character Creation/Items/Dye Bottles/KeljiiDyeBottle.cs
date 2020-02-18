using System;
using System.Text;
using Server.Gumps;
using Server.Items;
using Server.Mobiles;
using Server.Network;

namespace Server.Items
{
	public class KeljiiDyeBottle : Item
	{
		public override string DefaultName
		{
			get { return "Keljii Dye Bottle"; }
		}

		[Constructable]
		public KeljiiDyeBottle() : base( 0xE26 )
		{
			Weight = 1.0;
                  	Movable = false;
		}

		public KeljiiDyeBottle( Serial serial ) : base( serial )
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
			if ( from.InRange( this.GetWorldLocation(), 1 ) && from.Title == "the Keljii" )
			{
				from.CloseGump( typeof( KeljiiDyeBottleGump ) );
				from.SendGump( new KeljiiDyeBottleGump( this ) );
				from.SendMessage( "Select a color to dye your skin" );
			}
                        else
                        {
				from.SendMessage( "You must be a keljii in order to use this" );
                        }
		}
	}

	public class KeljiiDyeBottleGump : Gump
	{
		private KeljiiDyeBottle m_KeljiiDyeBottle;

		public KeljiiDyeBottleGump( KeljiiDyeBottle dye ) : base( 50, 50 )
		{
			m_KeljiiDyeBottle = dye;

			AddPage( 0 );
			AddBackground( 0, 0, 220, 630, 5054 );
			AddBackground( 10, 10, 200, 610, 3000 );
			AddLabel( 20, 20, 0, "Keljii Skin Hue Selector");
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

			AddLabel( 55,  90, 1266, "Keljii 1");
			AddLabel( 55, 110, 183, "Keljii 2");
			AddLabel( 55, 130, 184, "Keljii 3");
			AddLabel( 55, 150, 185, "Keljii 4");
			AddLabel( 55, 170, 186, "Keljii 5");
			AddLabel( 55, 190, 187, "Keljii 6");
			AddLabel( 55, 210, 188, "Keljii 7");
			AddLabel( 55, 230, 189, "Keljii 8");
			AddLabel( 55, 250, 190, "Keljii 9");
			AddLabel( 55, 270, 191, "Keljii 10");
			AddLabel( 55, 290, 192, "Keljii 11");
			AddLabel( 55, 310, 193, "Keljii 12");
			AddLabel( 55, 330, 194, "Keljii 13");
			AddLabel( 55, 350, 195, "Keljii 14");
			AddLabel( 55, 370, 196, "Keljii 15");
		}

		public override void OnResponse( NetState from, RelayInfo info )
		{
			if ( m_KeljiiDyeBottle.Deleted )
				return;

			Mobile m = from.Mobile;
			int[] switches = info.Switches;

			switch( info.ButtonID )
			{

			case 0: from.Mobile.SendMessage( "You decide not to hue your skin" ); break;

			case 1: from.Mobile.SendMessage( "You dye your skin Keljii 1" );
				from.Mobile.Hue = 1266;
		  		Item itema = m.FindItemOnLayer( Layer.Shirt );
	          		if ( itema is KeljiiTalisman )
	          		{
					itema.Hue = 1266;
                                }
				m.PlaySound( 0x4E ); break;

			case 2: from.Mobile.SendMessage( "You dye your skin Keljii 2" );
				from.Mobile.Hue = 183;
		  		Item itemb = m.FindItemOnLayer( Layer.Shirt );
	          		if ( itemb is KeljiiTalisman )
	          		{
					itemb.Hue = 183;
                                }
				m.PlaySound( 0x4E ); break;

			case 3: from.Mobile.SendMessage( "You dye your skin Keljii 3" );
				from.Mobile.Hue = 184;
		  		Item itemc = m.FindItemOnLayer( Layer.Shirt );
	          		if ( itemc is KeljiiTalisman )
	          		{
					itemc.Hue = 184;
                                }
				m.PlaySound( 0x4E ); break;

			case 4: from.Mobile.SendMessage( "You dye your skin Keljii 4" );
				from.Mobile.Hue = 185;
		  		Item itemd = m.FindItemOnLayer( Layer.Shirt );
	          		if ( itemd is KeljiiTalisman )
	          		{
					itemd.Hue = 185;
                                }
				m.PlaySound( 0x4E ); break;

			case 5: from.Mobile.SendMessage( "You dye your skin Keljii 5" );
				from.Mobile.Hue = 186;
		  		Item iteme = m.FindItemOnLayer( Layer.Shirt );
	          		if ( iteme is KeljiiTalisman )
	          		{
					iteme.Hue = 186;
                                }
				m.PlaySound( 0x4E ); break;

			case 6: from.Mobile.SendMessage( "You dye your skin Keljii 6" );
				from.Mobile.Hue = 187;
		  		Item itemf = m.FindItemOnLayer( Layer.Shirt );
	          		if ( itemf is KeljiiTalisman )
	          		{
					itemf.Hue = 187;
                                }
				m.PlaySound( 0x4E ); break;

			case 7: from.Mobile.SendMessage( "You dye your skin Keljii 7" );
				from.Mobile.Hue = 188;
		  		Item itemg = m.FindItemOnLayer( Layer.Shirt );
	          		if ( itemg is KeljiiTalisman )
	          		{
					itemg.Hue = 188;
                                }
				m.PlaySound( 0x4E ); break;

			case 8: from.Mobile.SendMessage( "You dye your skin Keljii 8" );
				from.Mobile.Hue = 189;
		  		Item itemh = m.FindItemOnLayer( Layer.Shirt );
	          		if ( itemh is KeljiiTalisman )
	          		{
					itemh.Hue = 189;
                                }
				m.PlaySound( 0x4E ); break;

			case 9: from.Mobile.SendMessage( "You dye your skin Keljii 9" );
				from.Mobile.Hue = 190;
		  		Item itemi = m.FindItemOnLayer( Layer.Shirt );
	          		if ( itemi is KeljiiTalisman )
	          		{
					itemi.Hue = 190;
                                }
				m.PlaySound( 0x4E ); break;

			case 10: from.Mobile.SendMessage( "You dye your skin Keljii 10" );
				from.Mobile.Hue = 191;
		  		Item itemj = m.FindItemOnLayer( Layer.Shirt );
	          		if ( itemj is KeljiiTalisman )
	          		{
					itemj.Hue = 191;
                                }
				m.PlaySound( 0x4E ); break;

			case 11: from.Mobile.SendMessage( "You dye your skin Keljii 11" );
				from.Mobile.Hue = 192;
		  		Item itemk = m.FindItemOnLayer( Layer.Shirt );
	          		if ( itemk is KeljiiTalisman )
	          		{
					itemk.Hue = 192;
                                }
				m.PlaySound( 0x4E ); break;

			case 12: from.Mobile.SendMessage( "You dye your skin Keljii 12" );
				from.Mobile.Hue = 193;
		  		Item iteml = m.FindItemOnLayer( Layer.Shirt );
	          		if ( iteml is KeljiiTalisman )
	          		{
					iteml.Hue = 193;
                                }
				m.PlaySound( 0x4E ); break;

			case 13: from.Mobile.SendMessage( "You dye your skin Keljii 13" );
				from.Mobile.Hue = 194;
		  		Item itemm = m.FindItemOnLayer( Layer.Shirt );
	          		if ( itemm is KeljiiTalisman )
	          		{
					itemm.Hue = 194;
                                }
				m.PlaySound( 0x4E ); break;

			case 14: from.Mobile.SendMessage( "You dye your skin Keljii 14" );
				from.Mobile.Hue = 195;
		  		Item itemn = m.FindItemOnLayer( Layer.Shirt );
	          		if ( itemn is KeljiiTalisman )
	          		{
					itemn.Hue = 195;
                                }
				m.PlaySound( 0x4E ); break;

			case 15: from.Mobile.SendMessage( "You dye your skin Keljii 15" );
				from.Mobile.Hue = 196;
		  		Item itemo = m.FindItemOnLayer( Layer.Shirt );
	          		if ( itemo is KeljiiTalisman )
	          		{
					itemo.Hue = 196;
                                }
				m.PlaySound( 0x4E ); break;				
			}
		}
	}
}