using System; 
using Server; 
using Server.Gumps; 
using Server.Network;
using Server.Commands;
using Server.Items;
using Server.Mobiles;

namespace Server.Gumps
{ 
   public class TheElusiveEquineFinishGump : Gump 
   { 
      public static void Initialize() 
      { 
         CommandSystem.Register( "TheElusiveEquineFinishGump", AccessLevel.GameMaster, new CommandEventHandler( TheElusiveEquineFinishGump_OnCommand ) ); 
      } 

      private static void TheElusiveEquineFinishGump_OnCommand( CommandEventArgs e ) 
      { 
         e.Mobile.SendGump( new TheElusiveEquineFinishGump( e.Mobile ) ); 
      } 

      public TheElusiveEquineFinishGump( Mobile owner ) : base( 50,50 ) 
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
			AddLabel( 140, 60, 0x34, "The Elusive Equine" );
			

			AddHtml( 107, 140, 300, 230, "<BODY>" +
//----------------------/----------------------------------------------/
"<BASEFONT COLOR=YELLOW>Ah many blesses to you partner in going<BR>" +
"<BASEFONT COLOR=YELLOW>out of your way to rescue one of my<BR>" +
"<BASEFONT COLOR=YELLOW>horses but sadly this isn't the only<BR>" +
"<BASEFONT COLOR=YELLOW>one. There are more of them out in the<BR>" +
"<BASEFONT COLOR=YELLOW>wild and they need to be returned home.<BR>" +
"<BASEFONT COLOR=YELLOW>As for your payment here's a little bit<BR>" +
"<BASEFONT COLOR=YELLOW>of gold that should come in handy.<BR>" +
"<BASEFONT COLOR=YELLOW>Also please take this statue as a<BR>" +
"<BASEFONT COLOR=YELLOW>gratitude of my appreciation. It may<BR>" +
"<BASEFONT COLOR=YELLOW>come in handy if you require quicker<BR>" +
"<BASEFONT COLOR=YELLOW>means of transportation.<BR>" +
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
		   from.AddToBackpack( new OneGoldBar() );
		   from.AddToBackpack( new PonyStatue() );
               break; 
            } 

         }
      }
   }
}