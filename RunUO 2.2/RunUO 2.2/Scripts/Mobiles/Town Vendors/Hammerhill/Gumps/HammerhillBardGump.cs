using System; 
using Server; 
using Server.Gumps; 
using Server.Network;
using Server.Commands;
using Server.Items;
using Server.Mobiles;

namespace Server.Gumps
{ 
   public class HammerhillBardGump : Gump 
   { 
      public static void Initialize() 
      { 
         CommandSystem.Register( "HammerhillBardGump", AccessLevel.GameMaster, new CommandEventHandler( HammerhillBardGump_OnCommand ) ); 
      } 

      private static void HammerhillBardGump_OnCommand( CommandEventArgs e ) 
      { 
         e.Mobile.SendGump( new HammerhillBardGump( e.Mobile ) ); 
      } 

      public HammerhillBardGump( Mobile owner ) : base( 50,50 ) 
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
"<BASEFONT COLOR=YELLOW>Welcome to the Bard's Tale. Its not a <BR>" +
"<BASEFONT COLOR=YELLOW>very original name for a store. Well <BR>" +
"<BASEFONT COLOR=YELLOW>its certainly better than what Hormell<BR>" +
"<BASEFONT COLOR=YELLOW>Jenkins came up with. Who would name<BR>" +
"<BASEFONT COLOR=YELLOW>a woodworking shop after a writer known<BR>" +
"<BASEFONT COLOR=YELLOW>for producing horror novellas? Lets <BR>" +
"<BASEFONT COLOR=YELLOW>forget all that and focus on why you're<BR>" +
"<BASEFONT COLOR=YELLOW>here. In order to get started, one will<BR>" +
"<BASEFONT COLOR=YELLOW>need to be skilled in Musicianship, the<BR>" +
"<BASEFONT COLOR=YELLOW>central component for a bard's song?<BR>" +
"<BASEFONT COLOR=YELLOW>Next you're going to want to decide <BR>" +
"<BASEFONT COLOR=YELLOW>what path you want to take. Do you want<BR>" +
"<BASEFONT COLOR=YELLOW>to weaken your opponents so that you <BR>" +
"<BASEFONT COLOR=YELLOW>can take easier advantage of them? Then<BR>" +
"<BASEFONT COLOR=YELLOW>the skill Discordance is right up your <BR>" +
"<BASEFONT COLOR=YELLOW>alley. Or do you prefer to coerce them <BR>" +
"<BASEFONT COLOR=YELLOW>into not attacking? The Peacemaking <BR>" +
"<BASEFONT COLOR=YELLOW>skill will allow you to do just that. <BR>" +
"<BASEFONT COLOR=YELLOW>Or, if you rather opt for the more <BR>" +
"<BASEFONT COLOR=YELLOW>popular method and force different<BR>" +
"<BASEFONT COLOR=YELLOW>opponents into beating the living <BR>" +
"<BASEFONT COLOR=YELLOW>potatoes out of each other, then <BR>" +
"<BASEFONT COLOR=YELLOW>specializing in Provocation will net <BR>" +
"<BASEFONT COLOR=YELLOW>you some results.<BR>" +
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