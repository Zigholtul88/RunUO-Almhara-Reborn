using System; 
using Server; 
using Server.Gumps; 
using Server.Network;
using Server.Commands;
using Server.Items;
using Server.Mobiles;

namespace Server.Gumps
{ 
   public class ElmhavenFlowerArranger1Gump : Gump 
   { 
      public static void Initialize() 
      { 
         CommandSystem.Register( "ElmhavenFlowerArranger1Gump", AccessLevel.GameMaster, new CommandEventHandler( ElmhavenFlowerArranger1Gump_OnCommand ) ); 
      } 

      private static void ElmhavenFlowerArranger1Gump_OnCommand( CommandEventArgs e ) 
      { 
         e.Mobile.SendGump( new ElmhavenFlowerArranger1Gump( e.Mobile ) ); 
      } 

      public ElmhavenFlowerArranger1Gump( Mobile owner ) : base( 50,50 ) 
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
			AddLabel( 140, 60, 0x34, "" );
			

			AddHtml( 107, 140, 300, 230, "<BODY>" +
//----------------------/----------------------------------------------/
"<BASEFONT COLOR=YELLOW>Greetings friend and welcome to this<BR>" +
"<BASEFONT COLOR=YELLOW>shop where I tend to all these lovely<BR>" +
"<BASEFONT COLOR=YELLOW>plants. If you're looking to grow your<BR>" +
"<BASEFONT COLOR=YELLOW>own plants then I suggest you pick up <BR>" +
"<BASEFONT COLOR=YELLOW>one of these bowls for you will need<BR>" +
"<BASEFONT COLOR=YELLOW>it. Also you will need some fertile <BR>" +
"<BASEFONT COLOR=YELLOW>soil so the easiest way of gathering<BR>" +
"<BASEFONT COLOR=YELLOW>some is to hunt down many of the giant<BR>" +
"<BASEFONT COLOR=YELLOW>ants that populate the dense Zaythalor <BR>" +
"<BASEFONT COLOR=YELLOW>region. Finally you will need both <BR>" +
"<BASEFONT COLOR=YELLOW>water and some moderately strong<BR>" +
"<BASEFONT COLOR=YELLOW>alchemy potions to insure that your<BR>" +
"<BASEFONT COLOR=YELLOW>sapling grows up healthy and strong.<BR>" +
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
		   from.SendGump( new ElmhavenFlowerArranger2Gump( from ));
               break; 
            } 

         }
      }
   }
}