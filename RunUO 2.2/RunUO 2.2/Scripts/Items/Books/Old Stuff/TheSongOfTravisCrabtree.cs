using System;
using System.Text;
using Server.Commands;
using Server.Gumps;
using Server.Mobiles;
using Server.Network;

namespace Server.Items
{
	public class SongOfTravisCrabtree : Item
	{
		public override string DefaultName
		{
			get { return "The Song of Travis Crabtree"; }
		}

		[Constructable]
		public SongOfTravisCrabtree() : base( 0xFBD )
		{
			Weight = 1.0;
		}

		public SongOfTravisCrabtree( Serial serial ) : base( serial )
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
			if ( IsChildOf( from.Backpack ) )
			{
				from.CloseGump( typeof( TravisCrabtreeWarningGump ) );
				from.SendGump( new TravisCrabtreeWarningGump( from ) );
			}
			else
			{
				from.SendLocalizedMessage( 1042001 ); // That must be in your pack for you to use it.
			}
		}
      }

   public class TravisCrabThemeSongGump : Gump 
   { 
      public static void Initialize() 
      { 
         CommandSystem.Register( "TravisCrabThemeSongGump", AccessLevel.GameMaster, new CommandEventHandler( TravisCrabThemeSongGump_OnCommand ) ); 
      } 

      private static void TravisCrabThemeSongGump_OnCommand( CommandEventArgs e ) 
      { 
         e.Mobile.SendGump( new TravisCrabThemeSongGump( e.Mobile ) ); 
      } 

      public TravisCrabThemeSongGump( Mobile owner ) : base( 50,50 ) 
      { 
//----------------------------------------------------------------------------------------------------

				AddPage( 0 );
			AddImageTiled(  54, 33, 369, 400, 2624 );
			AddAlphaRegion( 54, 33, 369, 400 );

			AddImageTiled( 416, 39, 44, 389, 203 );
//--------------------------------------Window size bar--------------------------------------------
			
			AddImage( 97, 49, 9005 );
			AddImageTiled( 58, 39, 29, 390, 10460 );
			AddImageTiled( 412, 37, 31, 389, 10460 );
			AddLabel( 140, 60, 0x34, "The Song of Travis Crabtree" );
			

			AddHtml( 107, 140, 300, 230, "<BODY>" +
//----------------------/----------------------------------------------/
"<BASEFONT COLOR=YELLOW>Hey Travis Crabtree,<BR>" +
"<BASEFONT COLOR=YELLOW>Wait a minute for me.<BR>" +
"<BASEFONT COLOR=YELLOW>Let's go back in the bottoms,<BR>" +
"<BASEFONT COLOR=YELLOW>Back where the fish are bitin'.<BR>" +
"<BASEFONT COLOR=YELLOW>Where all the world's invitin',<BR>" +
"<BASEFONT COLOR=YELLOW>And nobody sees the flowers bloom <BR>" +
"<BASEFONT COLOR=YELLOW>but me.<BR>" +
"<BASEFONT COLOR=YELLOW><BR>" +
"<BASEFONT COLOR=YELLOW>Hey Travis Crabtree,<BR>" +
"<BASEFONT COLOR=YELLOW>Do you see what I see?<BR>" +
"<BASEFONT COLOR=YELLOW>On the gentle winds of morning',<BR>" +
"<BASEFONT COLOR=YELLOW>A million birds are singing,<BR>" +
"<BASEFONT COLOR=YELLOW>Like the bells of heaven ringing,<BR>" +
"<BASEFONT COLOR=YELLOW>And nobody sees the flowers bloom but  <BR>" +
"<BASEFONT COLOR=YELLOW>me.<BR>" +
"<BASEFONT COLOR=YELLOW><BR>" +
"<BASEFONT COLOR=YELLOW>Drop me on a patch of land,<BR>" +
"<BASEFONT COLOR=YELLOW>Never stepped upon by man,<BR>" +
"<BASEFONT COLOR=YELLOW>Where the crystal water flows deep,<BR>" +
"<BASEFONT COLOR=YELLOW>While the falcon flies high,<BR>" +
"<BASEFONT COLOR=YELLOW>Across the yellow-eyed sky,<BR>" +
"<BASEFONT COLOR=YELLOW>Lo, ain't it great to be free?<BR>" +
"<BASEFONT COLOR=YELLOW><BR>" +
"<BASEFONT COLOR=YELLOW>Hey Travis Crabtree,<BR>" +
"<BASEFONT COLOR=YELLOW>It's the right life for me,<BR>" +
"<BASEFONT COLOR=YELLOW>Roamin' alone in the bottoms,<BR>" +
"<BASEFONT COLOR=YELLOW>While the birds and beasts are crying,<BR>" +
"<BASEFONT COLOR=YELLOW>Because the sun is dying,<BR>" +
"<BASEFONT COLOR=YELLOW>And nobody sees the flowers bloom but <BR>" +
"<BASEFONT COLOR=YELLOW>me.<BR>" +

"</BODY>", false, true);
			
//			<BASEFONT COLOR=#7B6D20>			

			AddImage( 430, 9, 10441);
			AddImageTiled( 40, 38, 17, 391, 9263 );
			AddImage( 6, 25, 10421 );
			AddImage( 34, 12, 10420 );
			AddImageTiled( 94, 25, 342, 15, 10304 );
			AddImageTiled( 40, 427, 415, 16, 10304 );
			AddImage( -10, 314, 10402 );
			AddImage( 56, 150, 10411 );
			AddImage( 155, 120, 2103 );
			AddImage( 136, 84, 96 );

			AddButton( 225, 390, 0xF7, 0xF8, 0, GumpButtonType.Reply, 0 ); 

//--------------------------------------------------------------------------------------------------------------
      } 

      public override void OnResponse( NetState state, RelayInfo info ) //Function for GumpButtonType.Reply Buttons 

      { 
         Mobile from = state.Mobile; 

         switch ( info.ButtonID ) 
         { 
            case 0: //Case uses the ActionIDs defenied above. Case 0 defenies the actions for the button with the action id 0 
            { 
               //Cancel 
               break; 
            } 

         }
      }
   }

	public class TravisCrabtreeWarningGump : Gump
	{
		public TravisCrabtreeWarningGump( Mobile m): base( 0, 0 )
		{
			this.Closable=false;
			this.Disposable=true;
			this.Dragable=true;
			this.Resizable=false;
			this.AddPage(0);
			this.AddBackground(126, 131, 398, 389, 9270);
			this.AddAlphaRegion(130, 132, 391, 389);
			this.AddImage(110, 460, 10464);
			this.AddImage(536, 214, 9265);
			this.AddImage(507, 460, 10464);
			this.AddImage(507, 408, 10464);
			this.AddImage(110, 193, 10464);
			this.AddImage(110, 247, 10464);
			this.AddImage(110, 301, 10464);
			this.AddImage(110, 354, 10464);
			this.AddImage(110, 408, 10464);
			this.AddImage(110, 139, 10464);
			this.AddImage(93, 197, 9263);
			this.AddImage(59, 124, 10421);
			this.AddImage(88, 110, 10420);
			this.AddImage(107, 246, 10411);
			this.AddImage(43, 399, 10402);
			this.AddImage(93, 513, 10103);
			this.AddImage(109, 513, 10100);
			this.AddImage(234, 513, 10100);
			this.AddImage(218, 513, 10100);
			this.AddImage(202, 513, 10100);
			this.AddImage(124, 513, 10100);
			this.AddImage(172, 513, 10100);
			this.AddImage(156, 513, 10100);
			this.AddImage(140, 513, 10100);
			this.AddImage(188, 513, 10100);
			this.AddImage(234, 513, 10100);
			this.AddImage(234, 513, 10100);
			this.AddImage(249, 513, 10100);
			this.AddImage(264, 513, 10100);
			this.AddImage(218, 513, 10100);
			this.AddImage(308, 513, 10100);
			this.AddImage(172, 513, 10100);
			this.AddImage(292, 513, 10100);
			this.AddImage(188, 513, 10100);
			this.AddImage(277, 513, 10100);
			this.AddImage(339, 513, 10100);
			this.AddImage(324, 513, 10100);
			this.AddImage(415, 513, 10100);
			this.AddImage(399, 513, 10100);
			this.AddImage(354, 513, 10100);
			this.AddImage(368, 123, 10100);
			this.AddImage(385, 513, 10100);
			this.AddImage(445, 513, 10100);
			this.AddImage(430, 513, 10100);
			this.AddImage(521, 513, 10100);
			this.AddImage(505, 513, 10100);
			this.AddImage(460, 513, 10100);
			this.AddImage(476, 513, 10100);
			this.AddImage(491, 513, 10100);
			this.AddImage(156, 123, 10100);
			this.AddImage(140, 123, 10100);
			this.AddImage(232, 123, 10100);
			this.AddImage(216, 123, 10100);
			this.AddImage(171, 123, 10100);
			this.AddImage(187, 123, 10100);
			this.AddImage(202, 123, 10100);
			this.AddImage(339, 513, 10100);
			this.AddImage(324, 513, 10100);
			this.AddImage(415, 513, 10100);
			this.AddImage(399, 513, 10100);
			this.AddImage(353, 123, 10100);
			this.AddImage(369, 513, 10100);
			this.AddImage(385, 513, 10100);
			this.AddImage(263, 123, 10100);
			this.AddImage(248, 123, 10100);
			this.AddImage(339, 123, 10100);
			this.AddImage(323, 123, 10100);
			this.AddImage(278, 123, 10100);
			this.AddImage(294, 123, 10100);
			this.AddImage(309, 123, 10100);
			this.AddImage(398, 123, 10100);
			this.AddImage(383, 123, 10100);
			this.AddImage(474, 123, 10100);
			this.AddImage(458, 123, 10100);
			this.AddImage(413, 123, 10100);
			this.AddImage(429, 123, 10100);
			this.AddImage(444, 123, 10100);
			this.AddImage(505, 123, 10100);
			this.AddImage(489, 123, 10100);
			this.AddImage(521, 123, 10100);
			this.AddImage(507, 193, 10464);
			this.AddImage(507, 139, 10464);
			this.AddImage(507, 354, 10464);
			this.AddImage(507, 299, 10464);
			this.AddImage(507, 247, 10464);
			this.AddImage(523, 254, 10411);
			this.AddImage(532, 130, 10431);
			this.AddImage(500, 112, 10430);
			this.AddImage(535, 513, 10105);
			this.AddImage(520, 417, 10412);
			this.AddLabel(282, 151, 1153, @"WARNING!");
			this.AddButton(226, 469, 247, 248, 0, GumpButtonType.Reply, 0);
			this.AddButton(351, 469, 241, 242,  1, GumpButtonType.Reply, 0);
			this.AddHtml( 157, 181, 345, 279, "Opening this book with result in you having to listen to an old but catchy tune. Do you wanna proceed?", false, true);
		}

		public override void OnResponse( NetState state, RelayInfo info )
		{
			Mobile from = state.Mobile;

			switch( info.ButtonID )
			{
				case 0:
				{
				      from.CloseGump( typeof( TravisCrabtreeWarningGump ) );
				      from.SendGump( new TravisCrabThemeSongGump( from ) );

                              from.Send( Network.PlayMusic.GetInstance( MusicName.SelimsBar ));

					break;
				}
				case 1:
				{
					from.SendMessage( "That's okay. Last thing you need is for that tune to get stuck in your head." );
				      from.CloseGump( typeof( TravisCrabtreeWarningGump ) );
					break;
				}
			}
		}
	}
}

