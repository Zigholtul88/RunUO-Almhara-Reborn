using System;
using System.Text;
using Server.Gumps;
using Server.Mobiles;
using Server.Network;

namespace Server.Items
{
	public class GargishDyeBottle : Item
	{
		public override string DefaultName
		{
			get { return "Gargish Dye Bottle"; }
		}

		[Constructable]
		public GargishDyeBottle() : base( 0xE26 )
		{
			Weight = 1.0;
			LootType = LootType.Blessed;
		}

		public GargishDyeBottle( Serial serial ) : base( serial )
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
			if ( from.InRange( this.GetWorldLocation(), 1 ) )
			{
				from.CloseGump( typeof( GargishDyeBottleGump ) );
				from.SendGump( new GargishDyeBottleGump( this ) );
				from.SendMessage( "Select a color to dye your skin" );
			}
			else
			{
				from.LocalOverheadMessage( MessageType.Regular, 906, 1019045 ); // I can't reach that.
			}	
					
		}
	}

	public class GargishDyeBottleGump : Gump
	{
		private GargishDyeBottle m_GargishDyeBottle;

		public GargishDyeBottleGump( GargishDyeBottle dye ) : base( 50, 50 )
		{
			m_GargishDyeBottle = dye;

			AddPage( 0 );
			AddBackground( 0, 0, 220, 630, 5054 );
			AddBackground( 10, 10, 200, 610, 3000 );
			AddLabel( 20, 20, 0, "Gargish Skin Hue Selector");
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
			AddButton( 20, 550, 4005, 4007, 24, GumpButtonType.Reply, 0 );																					

			AddLabel( 55,  90, 1755, "Gargish 1");
			AddLabel( 55, 110, 1756, "Gargish 2");
			AddLabel( 55, 130, 1757, "Gargish 3");
			AddLabel( 55, 150, 1758, "Gargish 4");
			AddLabel( 55, 170, 1759, "Gargish 5");
			AddLabel( 55, 190, 1760, "Gargish 6");
			AddLabel( 55, 210, 1761, "Gargish 7");
			AddLabel( 55, 230, 1762, "Gargish 8");
			AddLabel( 55, 250, 1763, "Gargish 9");
			AddLabel( 55, 270, 1764, "Gargish 10");
			AddLabel( 55, 290, 1765, "Gargish 11");
			AddLabel( 55, 310, 1766, "Gargish 12");
			AddLabel( 55, 330, 1767, "Gargish 13");
			AddLabel( 55, 350, 1768, "Gargish 14");
			AddLabel( 55, 370, 1769, "Gargish 15");
			AddLabel( 55, 390, 1770, "Gargish 16");
			AddLabel( 55, 410, 1771, "Gargish 17");
			AddLabel( 55, 430, 1772, "Gargish 18");
			AddLabel( 55, 450, 1773, "Gargish 19");
			AddLabel( 55, 470, 1774, "Gargish 20");
			AddLabel( 55, 490, 1775, "Gargish 21");
			AddLabel( 55, 510, 1776, "Gargish 22");
			AddLabel( 55, 530, 1777, "Gargish 23");
			AddLabel( 55, 550, 1778, "Gargish 24");												
		}

		public override void OnResponse( NetState from, RelayInfo info )
		{
			if ( m_GargishDyeBottle.Deleted )
				return;

			Mobile m = from.Mobile;
			int[] switches = info.Switches;

			if ( !m_GargishDyeBottle.IsChildOf( m.Backpack ) ) 
			{
				m.SendLocalizedMessage( 1042010 ); //You must have the object in your backpack to use it.
				return;
			}

			switch( info.ButtonID )
			{

			case 0: from.Mobile.SendMessage( "You decide not to hue your skin" ); break;

			case 1: from.Mobile.SendMessage( "You dye your skin Gargish 1" );
				from.Mobile.Hue = 1755;
				m_GargishDyeBottle.Delete();
				m.PlaySound( 0x4E ); break;

			case 2: from.Mobile.SendMessage( "You dye your skin Gargish 2" );
				from.Mobile.Hue = 1756;
				m_GargishDyeBottle.Delete();
				m.PlaySound( 0x4E ); break;

			case 3: from.Mobile.SendMessage( "You dye your skin Gargish 3" );
				from.Mobile.Hue = 1757;
				m_GargishDyeBottle.Delete();
				m.PlaySound( 0x4E ); break;

			case 4: from.Mobile.SendMessage( "You dye your skin Gargish 4" );
				from.Mobile.Hue = 1758;
				m_GargishDyeBottle.Delete();
				m.PlaySound( 0x4E ); break;

			case 5: from.Mobile.SendMessage( "You dye your skin Gargish 5" );
				from.Mobile.Hue = 1759;
				m_GargishDyeBottle.Delete();
				m.PlaySound( 0x4E ); break;

			case 6: from.Mobile.SendMessage( "You dye your skin Gargish 6" );
				from.Mobile.Hue = 1760;
				m_GargishDyeBottle.Delete();
				m.PlaySound( 0x4E ); break;

			case 7: from.Mobile.SendMessage( "You dye your skin Gargish 7" );
				from.Mobile.Hue = 1761;
				m_GargishDyeBottle.Delete();
				m.PlaySound( 0x4E ); break;

			case 8: from.Mobile.SendMessage( "You dye your skin Gargish 8" );
				from.Mobile.Hue = 1762;
				m_GargishDyeBottle.Delete();
				m.PlaySound( 0x4E ); break;

			case 9: from.Mobile.SendMessage( "You dye your skin Gargish 9" );
				from.Mobile.Hue = 1763;
				m_GargishDyeBottle.Delete();
				m.PlaySound( 0x4E ); break;

			case 10: from.Mobile.SendMessage( "You dye your skin Gargish 10" );
				from.Mobile.Hue = 1764;
				m_GargishDyeBottle.Delete();
				m.PlaySound( 0x4E ); break;

			case 11: from.Mobile.SendMessage( "You dye your skin Gargish 11" );
				from.Mobile.Hue = 1765;
				m_GargishDyeBottle.Delete();
				m.PlaySound( 0x4E ); break;

			case 12: from.Mobile.SendMessage( "You dye your skin Gargish 12" );
				from.Mobile.Hue = 1766;
				m_GargishDyeBottle.Delete();
				m.PlaySound( 0x4E ); break;

			case 13: from.Mobile.SendMessage( "You dye your skin Gargish 13" );
				from.Mobile.Hue = 1767;
				m_GargishDyeBottle.Delete();
				m.PlaySound( 0x4E ); break;

			case 14: from.Mobile.SendMessage( "You dye your skin Gargish 14" );
				from.Mobile.Hue = 1168;
				m_GargishDyeBottle.Delete();
				m.PlaySound( 0x4E ); break;

			case 15: from.Mobile.SendMessage( "You dye your skin Gargish 15" );
				from.Mobile.Hue = 1769;
				m_GargishDyeBottle.Delete();
				m.PlaySound( 0x4E ); break;

			case 16: from.Mobile.SendMessage( "You dye your skin Gargish 16" );
				from.Mobile.Hue = 1770;
				m_GargishDyeBottle.Delete();
				m.PlaySound( 0x4E ); break;

			case 17: from.Mobile.SendMessage( "You dye your skin Gargish 17" );
				from.Mobile.Hue = 1771;
				m_GargishDyeBottle.Delete();
				m.PlaySound( 0x4E ); break;
				
			case 18: from.Mobile.SendMessage( "You dye your skin Gargish 18" );
				from.Mobile.Hue = 1772;
				m_GargishDyeBottle.Delete();
				m.PlaySound( 0x4E ); break;
				
			case 19: from.Mobile.SendMessage( "You dye your skin Gargish 19" );
				from.Mobile.Hue = 1773;
				m_GargishDyeBottle.Delete();
				m.PlaySound( 0x4E ); break;	
				
			case 20: from.Mobile.SendMessage( "You dye your skin Gargish 20" );
				from.Mobile.Hue = 1774;
				m_GargishDyeBottle.Delete();
				m.PlaySound( 0x4E ); break;
				
			case 21: from.Mobile.SendMessage( "You dye your skin Gargish 21" );
				from.Mobile.Hue = 1775;
				m_GargishDyeBottle.Delete();
				m.PlaySound( 0x4E ); break;	
				
			case 22: from.Mobile.SendMessage( "You dye your skin Gargish 22" );
				from.Mobile.Hue = 1776;
				m_GargishDyeBottle.Delete();
				m.PlaySound( 0x4E ); break;			

			case 23: from.Mobile.SendMessage( "You dye your skin Gargish 23" );
				from.Mobile.Hue = 1777;
				m_GargishDyeBottle.Delete();
				m.PlaySound( 0x4E ); break;	
				
			case 24: from.Mobile.SendMessage( "You dye your skin Gargish 24" );
				from.Mobile.Hue = 1778;
				m_GargishDyeBottle.Delete();
				m.PlaySound( 0x4E ); break;	
			}
		}
	}
}