using System; 
using Server; 
using Server.Gumps; 
using Server.Network;
using Server.Commands;
using Server.Items;
using Server.Mobiles;

namespace Server.Gumps
{ 
   public class ThePrancingPoultryGump : Gump 
   { 
      public static void Initialize() 
      { 
         CommandSystem.Register( "ThePrancingPoultryGump", AccessLevel.GameMaster, new CommandEventHandler( ThePrancingPoultryGump_OnCommand ) ); 
      } 

      private static void ThePrancingPoultryGump_OnCommand( CommandEventArgs e ) 
      { 
         e.Mobile.SendGump( new ThePrancingPoultryGump( e.Mobile ) ); 
      } 

      public ThePrancingPoultryGump( Mobile owner ) : base( 50,50 ) 
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
			AddLabel( 140, 60, 0x34, "The Prancing Poultry" );
			

			AddHtml( 107, 140, 300, 230, "<BODY>" +
//----------------------/----------------------------------------------/
"<BASEFONT COLOR=YELLOW>Oh goody, someone new for a change.<BR>" +
"<BASEFONT COLOR=YELLOW>Well I must say you are looking mighty<BR>" +
"<BASEFONT COLOR=YELLOW>lonely this time of the day. Say why<BR>" +
"<BASEFONT COLOR=YELLOW>don't I interest you in some of these<BR>" +
"<BASEFONT COLOR=YELLOW>fine pack animals They're perfect for<BR>" +
"<BASEFONT COLOR=YELLOW>hauling away any excess junk so you<BR>" +
"<BASEFONT COLOR=YELLOW>wouldn't need to worry about being<BR>" +
"<BASEFONT COLOR=YELLOW>overencumbered. In fact you pretty much<BR>" +
"<BASEFONT COLOR=YELLOW>need these animals if you're thinking<BR>" +
"<BASEFONT COLOR=YELLOW>about doing any serious mining.<BR>" +
"<BASEFONT COLOR=YELLOW>Though I have to warn you, these<BR>" +
"<BASEFONT COLOR=YELLOW>packies don't make for exceptional<BR>" +
"<BASEFONT COLOR=YELLOW>fighters, especially the llamas. No if<BR>" +
"<BASEFONT COLOR=YELLOW>you want a pack mule that can really<BR>" +
"<BASEFONT COLOR=YELLOW>handle itself in a pinch then you'll<BR>" +
"<BASEFONT COLOR=YELLOW>have to try your luck taming some of<BR>" +
"<BASEFONT COLOR=YELLOW>the antlions located far north outside<BR>" +
"<BASEFONT COLOR=YELLOW>the Glimmerwood.<BR>" +
"<BASEFONT COLOR=YELLOW><BR>" +
"<BASEFONT COLOR=YELLOW>Now if you're more interested in an<BR>" +
"<BASEFONT COLOR=YELLOW>animal companion instead then seek<BR>" +
"<BASEFONT COLOR=YELLOW>out Redmond, though keep in mind he's<BR>" +
"<BASEFONT COLOR=YELLOW>not much of a talker.<BR>" +
"<BASEFONT COLOR=YELLOW><BR>" +
"<BASEFONT COLOR=YELLOW>Sorry to be a bit of a crazy bother but<BR>" + 
"<BASEFONT COLOR=YELLOW>I could really use your assistance. You<BR>" +
"<BASEFONT COLOR=YELLOW>see I tend to the chickens from around<BR>" +
"<BASEFONT COLOR=YELLOW>here. Well when I returned from one of <BR>" +
"<BASEFONT COLOR=YELLOW>my rounds I noticed that some of them <BR>" +
"<BASEFONT COLOR=YELLOW>went missing. If you are able to locate<BR>" +
"<BASEFONT COLOR=YELLOW>any of them I appreciate if you helped<BR>" +
"<BASEFONT COLOR=YELLOW>return them to me in one piece. I will <BR>" +
"<BASEFONT COLOR=YELLOW><BR>" +
"<BASEFONT COLOR=YELLOW><BR>" +
"<BASEFONT COLOR=YELLOW>pay you for your troubles.<BR>" +
"<BASEFONT COLOR=RED>Player Tip <BR>" +
"<BASEFONT COLOR=RED><BR>" +                         
"<BASEFONT COLOR=RED>Upon returning to Christina say to her<BR>" +
"<BASEFONT COLOR=YELLOW>*chicken*<BR>" +
"<BASEFONT COLOR=RED>and target her pet to finish quest.<BR>" +

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