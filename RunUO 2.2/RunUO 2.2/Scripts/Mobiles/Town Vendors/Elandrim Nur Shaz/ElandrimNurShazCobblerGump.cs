using System; 
using Server; 
using Server.Gumps; 
using Server.Network;
using Server.Commands;
using Server.Items;
using Server.Mobiles;

namespace Server.Gumps
{ 
   public class ElandrimNurShazCobblerGump : Gump 
   { 
      public static void Initialize() 
      { 
         CommandSystem.Register( "ElandrimNurShazCobblerGump", AccessLevel.GameMaster, new CommandEventHandler( ElandrimNurShazCobblerGump_OnCommand ) ); 
      } 

      private static void ElandrimNurShazCobblerGump_OnCommand( CommandEventArgs e ) 
      { 
         e.Mobile.SendGump( new ElandrimNurShazCobblerGump( e.Mobile ) ); 
      } 

      public ElandrimNurShazCobblerGump( Mobile owner ) : base( 50,50 ) 
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
"<BASEFONT COLOR=YELLOW>You know my job sucks. That's what <BR>" +
"<BASEFONT COLOR=YELLOW>every cobbler has to say on the matter.<BR>" +
"<BASEFONT COLOR=YELLOW>Well I must be one of the lucky few <BR>" +
"<BASEFONT COLOR=YELLOW>because I do happen to have some <BR>" +
"<BASEFONT COLOR=YELLOW>splendid new boots that's right for any<BR>" +
"<BASEFONT COLOR=YELLOW>adventurer. Also here's a small tip.<BR>" +
"<BASEFONT COLOR=YELLOW><BR>" +
"<BASEFONT COLOR=YELLOW>Watch out for the gargantuan spiders <BR>" +
"<BASEFONT COLOR=YELLOW>that roam the northern part of the <BR>" +
"<BASEFONT COLOR=YELLOW>Oboru Jungle because they carry quite a<BR>" +
"<BASEFONT COLOR=YELLOW>nasty bite.<BR>" +
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