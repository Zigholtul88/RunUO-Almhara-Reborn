using System; 
using Server; 
using Server.Gumps; 
using Server.Network;
using Server.Commands;
using Server.Items;
using Server.Mobiles;

namespace Server.Gumps
{ 
   public class HammerhillBlacksmithGump : Gump 
   { 
      public static void Initialize() 
      { 
         CommandSystem.Register( "HammerhillBlacksmithGump", AccessLevel.GameMaster, new CommandEventHandler( HammerhillBlacksmithGump_OnCommand ) ); 
      } 

      private static void HammerhillBlacksmithGump_OnCommand( CommandEventArgs e ) 
      { 
         e.Mobile.SendGump( new HammerhillBlacksmithGump( e.Mobile ) ); 
      } 

      public HammerhillBlacksmithGump( Mobile owner ) : base( 50,50 ) 
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
"<BASEFONT COLOR=YELLOW>Oui, I see someone is in need of <BR>" +
"<BASEFONT COLOR=YELLOW>becoming a blacksmith. Well not to fret<BR>" +
"<BASEFONT COLOR=YELLOW>because I happen to be one and I will <BR>" +
"<BASEFONT COLOR=YELLOW>inform you about the profession. Wait <BR>" +
"<BASEFONT COLOR=YELLOW>you already know how the system works,<BR>" +
"<BASEFONT COLOR=YELLOW>well too fucking bad because I'm going<BR>" +
"<BASEFONT COLOR=YELLOW>to explain it all to you because you <BR>" +
"<BASEFONT COLOR=YELLOW>just so happen to wanted to chat.<BR>" +
"<BASEFONT COLOR=YELLOW><BR>" +
"<BASEFONT COLOR=YELLOW>Make sure you have enough ingots, then<BR>" +
"<BASEFONT COLOR=YELLOW>make sure you're near both an anvil and<BR>" +
"<BASEFONT COLOR=YELLOW>forge and then you can proceed towards<BR>" +
"<BASEFONT COLOR=YELLOW>crafting your own weapons and armor. Oh<BR>" +
"<BASEFONT COLOR=YELLOW>but you want to make some money on the <BR>" +
"<BASEFONT COLOR=YELLOW>side, don't ya? From time to time I <BR>" +
"<BASEFONT COLOR=YELLOW>will hand out bulk order deeds where<BR>" +
"<BASEFONT COLOR=YELLOW>you just simply create the items in the<BR>" +
"<BASEFONT COLOR=YELLOW>description, then return the deed to me<BR>" +
"<BASEFONT COLOR=YELLOW>where I will reward you based off the <BR>" +
"<BASEFONT COLOR=YELLOW>difficulty rating.<BR>" +
"<BASEFONT COLOR=YELLOW><BR>" +
"<BASEFONT COLOR=YELLOW>That's all the information you'll need <BR>" +
"<BASEFONT COLOR=YELLOW>unless you're really this stupid. In<BR>" +
"<BASEFONT COLOR=YELLOW>which case I cannot help you there but<BR>" +
"<BASEFONT COLOR=YELLOW>maybe purchasing a teal potion from the<BR>" +
"<BASEFONT COLOR=YELLOW>Magician's Corner could remedy your <BR>" +
"<BASEFONT COLOR=YELLOW>gizzarded intellect.<BR>" +
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