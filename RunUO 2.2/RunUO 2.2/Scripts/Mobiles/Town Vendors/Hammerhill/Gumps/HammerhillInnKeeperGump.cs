using System; 
using Server; 
using Server.Gumps; 
using Server.Network;
using Server.Commands;
using Server.Items;
using Server.Mobiles;

namespace Server.Gumps
{ 
   public class HammerhillInnKeeperGump : Gump 
   { 
      public static void Initialize() 
      { 
         CommandSystem.Register( "HammerhillInnKeeperGump", AccessLevel.GameMaster, new CommandEventHandler( HammerhillInnKeeperGump_OnCommand ) ); 
      } 

      private static void HammerhillInnKeeperGump_OnCommand( CommandEventArgs e ) 
      { 
         e.Mobile.SendGump( new HammerhillInnKeeperGump( e.Mobile ) ); 
      } 

      public HammerhillInnKeeperGump( Mobile owner ) : base( 50,50 ) 
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
"<BASEFONT COLOR=YELLOW>Welcome to the Slumberland Inn. By<BR>" +
"<BASEFONT COLOR=YELLOW>resting here in one of our fine rooms <BR>" +
"<BASEFONT COLOR=YELLOW>you will be able to safely leave this <BR>" +
"<BASEFONT COLOR=YELLOW>world without having to wait 5 minutes <BR>" +
"<BASEFONT COLOR=YELLOW>where during that time someone will <BR>" +
"<BASEFONT COLOR=YELLOW>more than likely shank you without<BR>" +
"<BASEFONT COLOR=YELLOW>warning. In case you're wondering why <BR>" +
"<BASEFONT COLOR=YELLOW>our bedrooms have been declared free <BR>" +
"<BASEFONT COLOR=YELLOW>for personal use, you can thank the<BR>" +
"<BASEFONT COLOR=YELLOW>actual boss that runs this place, who <BR>" +
"<BASEFONT COLOR=YELLOW>is stationed within one of the rooms. <BR>" +
"<BASEFONT COLOR=YELLOW><BR>" +
"<BASEFONT COLOR=YELLOW>He says that he gets by on selling <BR>" +
"<BASEFONT COLOR=YELLOW>bandages because I guess that mere<BR>" +
"<BASEFONT COLOR=YELLOW>Chivalry doesn't exist anymore, or <BR>" +
"<BASEFONT COLOR=YELLOW>something to those lines. Me I think <BR>" +
"<BASEFONT COLOR=YELLOW>its bad business but I guess I can't <BR>" +
"<BASEFONT COLOR=YELLOW>complain. After all this establishment <BR>" +
"<BASEFONT COLOR=YELLOW>is still standed despite all the recent<BR>" +
"<BASEFONT COLOR=YELLOW>attacks from those accursed fire  <BR>" +
"<BASEFONT COLOR=YELLOW>elementals. I suppose since you're here<BR>" +
"<BASEFONT COLOR=YELLOW>you matters well take the time to chat <BR>" +
"<BASEFONT COLOR=YELLOW>with Kenichi the bandage dealer over in<BR>" +
"<BASEFONT COLOR=YELLOW>one of the rooms. He'll explain to you <BR>" +
"<BASEFONT COLOR=YELLOW>the methods of common bandage usage.<BR>" +
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