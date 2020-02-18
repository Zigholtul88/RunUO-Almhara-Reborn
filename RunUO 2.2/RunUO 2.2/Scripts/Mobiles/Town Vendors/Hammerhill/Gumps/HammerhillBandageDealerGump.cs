using System; 
using Server; 
using Server.Gumps; 
using Server.Network;
using Server.Commands;
using Server.Items;
using Server.Mobiles;

namespace Server.Gumps
{ 
   public class HammerhillBandageDealerGump : Gump 
   { 
      public static void Initialize() 
      { 
         CommandSystem.Register( "HammerhillBandageDealerGump", AccessLevel.GameMaster, new CommandEventHandler( HammerhillBandageDealerGump_OnCommand ) ); 
      } 

      private static void HammerhillBandageDealerGump_OnCommand( CommandEventArgs e ) 
      { 
         e.Mobile.SendGump( new HammerhillBandageDealerGump( e.Mobile ) ); 
      } 

      public HammerhillBandageDealerGump( Mobile owner ) : base( 50,50 ) 
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
"<BASEFONT COLOR=YELLOW>Ah I see commander Doland brought you<BR>" +
"<BASEFONT COLOR=YELLOW>here and she's probably still bitching <BR>" +
"<BASEFONT COLOR=YELLOW>about the finance problems concerning <BR>" +
"<BASEFONT COLOR=YELLOW>this inn. Well let me for one tell you <BR>" +
"<BASEFONT COLOR=YELLOW>something newbie. Bandages are <BR>" +
"<BASEFONT COLOR=YELLOW>solutions designed for the common <BR>" +
"<BASEFONT COLOR=YELLOW>mortal, one that prefers the simpliest<BR>" +
"<BASEFONT COLOR=YELLOW>and natural approach over supernatural<BR>" +
"<BASEFONT COLOR=YELLOW>methods. However is this a method made<BR>" +
"<BASEFONT COLOR=YELLOW>for those who are proficient with their<BR>" +
"<BASEFONT COLOR=YELLOW>Healing skill so at first it will be <BR>" +
"<BASEFONT COLOR=YELLOW>quite difficult, though through hard <BR>" +
"<BASEFONT COLOR=YELLOW>work you'll not only be able to quickly<BR>" +
"<BASEFONT COLOR=YELLOW>mend lost health but you'll also be <BR>" +
"<BASEFONT COLOR=YELLOW>able to treat away the condition of <BR>" +
"<BASEFONT COLOR=YELLOW>being poisoned. I've also heard legends<BR>" +
"<BASEFONT COLOR=YELLOW>of folks, whom with their great skill <BR>" +
"<BASEFONT COLOR=YELLOW>be able to literally bring others back <BR>" +
"<BASEFONT COLOR=YELLOW>from the beyond.<BR>" +
"<BASEFONT COLOR=YELLOW><BR>" +
"<BASEFONT COLOR=YELLOW>Maybe I should take back the notion <BR>" +
"<BASEFONT COLOR=YELLOW>that these bandages were completely<BR>" +
"<BASEFONT COLOR=YELLOW>natural, oh well.<BR>" +
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