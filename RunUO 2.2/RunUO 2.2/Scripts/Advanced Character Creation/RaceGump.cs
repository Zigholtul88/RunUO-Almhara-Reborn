using System;
using Server;
using Server.Gumps;
using Server.Items;
using Server.Mobiles;
using Server.Network;

namespace Server.Gumps
{
	public class RaceChoiceGump : Gump
	{			
		public RaceChoiceGump() : base( 0, 0 )
		{
			this.Closable = false;
			this.Disposable = true;
			this.Dragable = true;
			this.Resizable = false;

			this.AddPage( 0 );
			this.AddBackground( 28, 9, 385, 458, 9270 );
			this.AddImage( 30, 19, 5557, 0 );
			this.AddButton( 80, 140, 55, 56, (int)Buttons.Button1, GumpButtonType.Reply, 0 );
			this.AddButton( 80, 180, 55, 56, (int)Buttons.Button2, GumpButtonType.Reply, 0 );
			this.AddButton( 80, 220, 55, 56, (int)Buttons.Button3, GumpButtonType.Reply, 0 );
			this.AddButton( 80, 260, 55, 56, (int)Buttons.Button4, GumpButtonType.Reply, 0 );
			this.AddButton( 80, 300, 55, 56, (int)Buttons.Button5, GumpButtonType.Reply, 0 );
			this.AddLabel( 125, 69, 36, @"Almharian Races" );
/////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
			this.AddLabel( 100, 140, 0, @"Human" );
			this.AddLabel( 100, 170, 0, @"Ljosalfar" );
			this.AddLabel( 100, 220, 0, @"Svartafar" );
			this.AddLabel( 100, 260, 0, @"Yugitashi" );
			this.AddLabel( 100, 300, 0, @"Keljii" );
/////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
		}
			
		public enum Buttons
		{
			Close,
			Button1,
			Button2,
			Button3,
			Button4,
			Button5,
			Button6,
			Button7,
		}
			
		public override void OnResponse( NetState sender, RelayInfo info )
		{
			Mobile m = sender.Mobile;
			PlayerMobile player = m as PlayerMobile;
			
			if ( m == null )
				return;
			switch ( info.ButtonID )
			{
				case 0:
				{
                			m.Race = Race.Human;
					m.Title = "the Human";
					player.RacialNumber = 1; // Human

                                        m.Str = 10;
                                        m.Dex = 10;
                                        m.Int = 10;

					m.SendMessage( 0x26, "You have chosen the path of a Human." );
				        m.CloseGump( typeof( RaceChoiceGump ) );
					break;
				}

				case 1:
				{
                			m.Race = Race.Human;
					m.Title = "the Human";
					player.RacialNumber = 1; // Human

                                        m.Str = 10;
                                        m.Dex = 10;
                                        m.Int = 10;

					m.SendMessage( 0x26, "You have chosen the path of a Human." );
				        m.CloseGump( typeof( RaceChoiceGump ) );
					break;
				}

				case 2:
				{
                			m.Race = Race.Elf;
					m.Title = "the Ljosalfar";
                			m.Hue = 1023;
					player.RacialNumber = 2; // Ljosalfar

                                        m.Str = 10;
                                        m.Dex = 15;
                                        m.Int = 5;

            				if ( m.Female == false )
            				{
                				m.BodyValue = 605;
                				m.HairItemID = 12237;
                				m.HairHue = 55;
                				m.Female = false;
                				m.FacialHairHue = 0;
                				m.FacialHairItemID = 0;

            				}
            				else if ( m.Female == true )
            				{
                				m.BodyValue = 606;
                				m.HairItemID = 12236;
                				m.HairHue = 55;
                				m.Female = true;
                				m.FacialHairHue = 0;
                				m.FacialHairItemID = 0;
            				}

					m.SendMessage( 0x26, "You have chosen the path of a Ljosalfar." );
				        m.CloseGump( typeof( RaceChoiceGump ) );
					break;
				}
				
				case 3:
				{
                			m.Race = Race.Elf;
					m.Title = "the Svartafar";
                			m.Hue = 2405;
					player.RacialNumber = 3; // Svartalfar

                                        m.Str = 10;
                                        m.Dex = 5;
                                        m.Int = 15;

            				if ( m.Female == false )
            				{
                				m.BodyValue = 605;
                				m.HairItemID = 12237;
                				m.HairHue = 1153;
                				m.Female = false;
                				m.FacialHairHue = 0;
                				m.FacialHairItemID = 0;
            				}
            				else if ( m.Female == true )
            				{
                				m.BodyValue = 606;
                				m.HairItemID = 12237;
                				m.HairHue = 1153;
                				m.FacialHairHue = 0;
                				m.FacialHairItemID = 0;
                				m.Female = true;
            				}

					m.SendMessage( 0x26, "You have chosen the path of a Svartafar." );
				        m.CloseGump( typeof( RaceChoiceGump ) );
					break;
				}

				case 4:
				{
                			m.Race = Race.Human;
					m.Title = "the Yugitashi";
                			m.Hue = 1047;
					player.RacialNumber = 4; // Yugitashi

                                        m.Str = 15;
                                        m.Dex = 10;
                                        m.Int = 5;

                                        m.EquipItem( new YugitashiTalisman() );

            				if ( m.Female == false )
            				{
                				m.BodyValue = 400;
                				m.HairItemID = 12237;
                				m.HairHue = 11;
                				m.Female = false;
                				m.FacialHairHue = 0;
                				m.FacialHairItemID = 0;
            				}
            				else if ( m.Female == true )
            				{
                				m.BodyValue = 401;
                				m.HairItemID = 12237;
                				m.HairHue = 11;
                				m.FacialHairHue = 0;
                				m.FacialHairItemID = 0;
                				m.Female = true;
            				}

					m.SendMessage( 0x26, "You have chosen the path of a Yugitashi." );
				        m.CloseGump( typeof( RaceChoiceGump ) );
					break;
				}

				case 5:
				{
                			m.Race = Race.Human;
					m.Title = "the Keljii";
                			m.Hue = 1266;
					player.RacialNumber = 5; // Keljii

                                        m.Str = 8;
                                        m.Dex = 15;
                                        m.Int = 12;

                                        m.EquipItem( new KeljiiTalisman() );

            				if ( m.Female == false )
            				{
                				m.BodyValue = 400;
                				m.HairItemID = 12237;
                				m.HairHue = 90;
                				m.Female = false;
                				m.FacialHairHue = 0;
                				m.FacialHairItemID = 0;
            				}
            				else if ( m.Female == true )
            				{
                				m.BodyValue = 401;
                				m.HairItemID = 12237;
                				m.HairHue = 90;
                				m.FacialHairHue = 0;
                				m.FacialHairItemID = 0;
                				m.Female = true;
            				}

					m.SendMessage( 0x26, "You have chosen the path of a Keljii." );
				        m.CloseGump( typeof( RaceChoiceGump ) );
					break;
				}
			}
		}
	}
}