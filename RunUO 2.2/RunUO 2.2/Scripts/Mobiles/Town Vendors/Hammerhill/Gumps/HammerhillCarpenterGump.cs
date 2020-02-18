using System; 
using Server; 
using Server.Gumps; 
using Server.Network;
using Server.Commands;
using Server.Items;
using Server.Mobiles;

namespace Server.Gumps
{ 
   public class HammerhillCarpenterGump : Gump 
   { 
      public static void Initialize() 
      { 
         CommandSystem.Register( "HammerhillCarpenterGump", AccessLevel.GameMaster, new CommandEventHandler( HammerhillCarpenterGump_OnCommand ) ); 
      } 

      private static void HammerhillCarpenterGump_OnCommand( CommandEventArgs e ) 
      { 
         e.Mobile.SendGump( new HammerhillCarpenterGump( e.Mobile ) ); 
      } 

      public HammerhillCarpenterGump( Mobile owner ) : base( 50,50 ) 
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
"<BASEFONT COLOR=YELLOW>Welcome to John Carpenter's Woodshop,<BR>" +
"<BASEFONT COLOR=YELLOW>named after the famous horror writer of<BR>" +
"<BASEFONT COLOR=YELLOW>such amazing classics. Which I will not<BR>" +
"<BASEFONT COLOR=YELLOW>mention because I do not plan on <BR>" +
"<BASEFONT COLOR=YELLOW>getting swamped with lawsuits out the <BR>" +
"<BASEFONT COLOR=YELLOW>ass. So instead I'll just inform you <BR>" +
"<BASEFONT COLOR=YELLOW>how my store is perfect for those who <BR>" +
"<BASEFONT COLOR=YELLOW>plan on becoming carpenters themselves<BR>" +
"<BASEFONT COLOR=YELLOW>or if they want to simply get rid of <BR>" +
"<BASEFONT COLOR=YELLOW>any logs and other wooden crafts that<BR>" +
"<BASEFONT COLOR=YELLOW>have no business being in a home <BR>" +
"<BASEFONT COLOR=YELLOW>setting that's tailored to one's own<BR>" +
"<BASEFONT COLOR=YELLOW>personal liking.<BR>" +
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