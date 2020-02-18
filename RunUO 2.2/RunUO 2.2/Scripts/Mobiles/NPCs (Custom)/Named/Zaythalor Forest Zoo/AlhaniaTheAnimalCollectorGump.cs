using System; 
using Server; 
using Server.Gumps; 
using Server.Network;
using Server.Commands;
using Server.Items;
using Server.Mobiles;

namespace Server.Gumps
{ 
   public class AlhaniaTheAnimalCollectorGump : Gump 
   { 
      public static void Initialize() 
      { 
         CommandSystem.Register( "AlhaniaTheAnimalCollectorGump", AccessLevel.GameMaster, new CommandEventHandler( AlhaniaTheAnimalCollectorGump_OnCommand ) ); 
      } 

      private static void AlhaniaTheAnimalCollectorGump_OnCommand( CommandEventArgs e ) 
      { 
         e.Mobile.SendGump( new AlhaniaTheAnimalCollectorGump( e.Mobile ) ); 
      } 

      public AlhaniaTheAnimalCollectorGump( Mobile owner ) : base( 50,50 ) 
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
"<BASEFONT COLOR=YELLOW>I've just recently opened up this zoo <BR>" +
"<BASEFONT COLOR=YELLOW>and now I need animals to help fill out<BR>" +
"<BASEFONT COLOR=YELLOW>the pens. I'm currently looking for any<BR>" +
"<BASEFONT COLOR=YELLOW>creature that exists on this continent <BR>" +
"<BASEFONT COLOR=YELLOW>and if you have any then I will pay you<BR>" +
"<BASEFONT COLOR=YELLOW>for your efforts.<BR>" +
"<BASEFONT COLOR=YELLOW><BR>" +
"<BASEFONT COLOR=YELLOW><BR>" +
"<BASEFONT COLOR=RED>Player Tip <BR>" +
"<BASEFONT COLOR=RED><BR>" +
"<BASEFONT COLOR=RED>When you return to Alhania say *sell* <BR>" +
"<BASEFONT COLOR=RED>and target a tamed animal. The amount <BR>" +
"<BASEFONT COLOR=RED>of gold you receive largely depends on <BR>" +
"<BASEFONT COLOR=RED>how challenging the creature was to <BR>" +
"<BASEFONT COLOR=RED>tame.<BR>" +
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