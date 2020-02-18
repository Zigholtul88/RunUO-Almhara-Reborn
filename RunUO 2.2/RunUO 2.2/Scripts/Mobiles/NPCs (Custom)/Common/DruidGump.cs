using System;
using Server;
using System.Collections.Generic;
using Server.Commands; 
using Server.Gumps; 
using Server.Network;
using Server.Items;
using Server.Mobiles;

namespace Server.Gumps
{ 
   public class DruidGump : Gump 
   { 
      public static void Initialize() 
      { 
         CommandSystem.Register( "DruidGump", AccessLevel.GameMaster, new CommandEventHandler( DruidGump_OnCommand ) ); 
      } 

      private static void DruidGump_OnCommand( CommandEventArgs e ) 
      { 
         e.Mobile.SendGump( new DruidGump( e.Mobile ) ); 
      } 

      public DruidGump( Mobile owner ) : base( 50,50 ) 
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
			AddLabel( 140, 60, 0x34, "The Power of the Druids" );
			

			AddHtml( 107, 140, 300, 230, "<BODY>" +
//----------------------/----------------------------------------------/
"<BASEFONT COLOR=WHITE>*the druid looks at you and smiles*...<BR><BR>Hail, Adventurer. I am a member of the Druids<BR>" +
"<BASEFONT COLOR=WHITE>We possess many special abilities, one is the ability to bring creatures who have passed into the afterlife back to the living.<BR><BR>" +
"<BASEFONT COLOR=WHITE>Should you find you are in need of my services, you must give me 1000 gp to complete this task for you. No more, no less to bring your precious pet back to life. Come see me if the need arises." +
						     "</BODY>", false, true);
			

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
               from.SendMessage( "Until we meet again." );
         
               break; 
            } 

         }
      }
   }
}
 
