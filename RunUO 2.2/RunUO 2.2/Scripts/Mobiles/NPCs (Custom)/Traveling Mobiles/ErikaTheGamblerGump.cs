using System; 
using Server; 
using Server.Gumps; 
using Server.Network;
using Server.Commands;
using Server.Items;
using Server.Mobiles;

namespace Server.Gumps
{ 
   public class ErikaTheGamblerGump : Gump 
   { 
      public static void Initialize() 
      { 
         CommandSystem.Register( "ErikaTheGamblerGump", AccessLevel.GameMaster, new CommandEventHandler( ErikaTheGamblerGump_OnCommand ) ); 
      } 

      private static void ErikaTheGamblerGump_OnCommand( CommandEventArgs e ) 
      { 
         e.Mobile.SendGump( new ErikaTheGamblerGump( e.Mobile ) ); 
      } 

      public ErikaTheGamblerGump( Mobile owner ) : base( 50,50 ) 
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
"<BASEFONT COLOR=YELLOW>If your skill with a lockpick is decent<BR>" +
"<BASEFONT COLOR=YELLOW>then you can easily make some gold<BR>" +
"<BASEFONT COLOR=YELLOW>on the side. This land is filled to the<BR>" +
"<BASEFONT COLOR=YELLOW>brim with locked treasure chests and <BR>" +
"<BASEFONT COLOR=YELLOW>various other containers. Also for some<BR>" +
"<BASEFONT COLOR=YELLOW>bewildering reason not only are they <BR>" +
"<BASEFONT COLOR=YELLOW>too heavy but they vanish after a <BR>" +
"<BASEFONT COLOR=YELLOW>certain amount of time has passed so<BR>" +
"<BASEFONT COLOR=YELLOW>they are not very good for storage. I <BR>" +
"<BASEFONT COLOR=YELLOW>guess the ancient gods have a twisted <BR>" +
"<BASEFONT COLOR=YELLOW>sense of humor<BR>" +
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
