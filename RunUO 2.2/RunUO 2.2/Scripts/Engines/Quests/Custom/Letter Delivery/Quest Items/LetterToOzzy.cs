using System;
using System.Text;
using Server.Commands;
using Server.Gumps;
using Server.Mobiles;
using Server.Network;

namespace Server.Items
{
	public class LetterToOzzy : Item
	{
		public override string DefaultName
		{
			get { return "Letter To Ozzy"; }
		}

		[Constructable]
		public LetterToOzzy() : base( 0x14EE )
		{
			Weight = 1.0;
			LootType = LootType.Blessed;
		}

		public LetterToOzzy( Serial serial ) : base( serial )
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
				from.CloseGump( typeof( LetterToOzzyGump ) );
				from.SendGump( new LetterToOzzyGump( from ) );
			}
			else
			{
				from.SendLocalizedMessage( 1042001 ); // That must be in your pack for you to use it.
			}
		}
      }

   public class LetterToOzzyGump : Gump 
   { 
      public static void Initialize() 
      { 
         CommandSystem.Register( "LetterToOzzyGump", AccessLevel.GameMaster, new CommandEventHandler( LetterToOzzyGump_OnCommand ) ); 
      } 

      private static void LetterToOzzyGump_OnCommand( CommandEventArgs e ) 
      { 
         e.Mobile.SendGump( new LetterToOzzyGump( e.Mobile ) ); 
      } 

      public LetterToOzzyGump( Mobile owner ) : base( 50,50 ) 
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
			AddLabel( 140, 60, 0x34, "Letter to Ozzy" );
			

			AddHtml( 107, 140, 300, 230, "<BODY>" +
//----------------------/----------------------------------------------/
"<BASEFONT COLOR=YELLOW>My dear Ozzy, I worry about you. I <BR>" +
"<BASEFONT COLOR=YELLOW>haven't been able to see you in quite<BR>" +
"<BASEFONT COLOR=YELLOW>some time. Right now I'm currently<BR>" +
"<BASEFONT COLOR=YELLOW>staying at the Firefly Lounge over in<BR>" +
"<BASEFONT COLOR=YELLOW>Elmhaven. I had to move away from my<BR>" +
"<BASEFONT COLOR=YELLOW>parents ever since they started to <BR>" +
"<BASEFONT COLOR=YELLOW>fight with each other. It seems that <BR>" +
"<BASEFONT COLOR=YELLOW>they're having trouble adjusting to the<BR>" +
"<BASEFONT COLOR=YELLOW>notion of me dating outside my race. <BR>" +
"<BASEFONT COLOR=YELLOW>Personally I think its quite ridiculous<BR>" +
"<BASEFONT COLOR=YELLOW>considering to me that everlasting true<BR>" +
"<BASEFONT COLOR=YELLOW>has no racial boundaries.<BR>" +
"<BASEFONT COLOR=YELLOW>I've fallen for you because of how much<BR>" +
"<BASEFONT COLOR=YELLOW>I enjoy your character and nothing will<BR>" +
"<BASEFONT COLOR=YELLOW>ever change that. You will always <BR>" +
"<BASEFONT COLOR=YELLOW>forever be my stunning jewel amongst<BR>" +
"<BASEFONT COLOR=YELLOW>a sea of emptiness and doubt.<BR>" +

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
}
