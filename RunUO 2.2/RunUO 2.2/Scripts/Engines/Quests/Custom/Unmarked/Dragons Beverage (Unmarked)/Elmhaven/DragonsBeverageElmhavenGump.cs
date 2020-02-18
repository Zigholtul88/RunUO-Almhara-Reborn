using System; 
using Server; 
using Server.Gumps; 
using Server.Network;
using Server.Commands;
using Server.Items;
using Server.Mobiles;

namespace Server.Gumps
{ 
   public class DragonsBeverageElmhavenGump : Gump 
   { 
      public static void Initialize() 
      { 
         CommandSystem.Register( "DragonsBeverageElmhavenGump", AccessLevel.GameMaster, new CommandEventHandler( DragonsBeverageElmhavenGump_OnCommand ) ); 
      } 

      private static void DragonsBeverageElmhavenGump_OnCommand( CommandEventArgs e ) 
      { 
         e.Mobile.SendGump( new DragonsBeverageElmhavenGump( e.Mobile ) ); 
      } 

      public DragonsBeverageElmhavenGump( Mobile owner ) : base( 50,50 ) 
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
			AddLabel( 140, 60, 0x34, "Dragon's Beverage" );
			

			AddHtml( 107, 140, 300, 230, "<BODY>" +
//----------------------/----------------------------------------------/
"<BASEFONT COLOR=YELLOW>Hello there, I specialize in all sorts <BR>" +
"<BASEFONT COLOR=YELLOW>of beverages but there is a special<BR>" +
"<BASEFONT COLOR=YELLOW>kind I'm looking for. It is known as<BR>" +
"<BASEFONT COLOR=YELLOW>Dragonfire Red Wine, an extremely<BR>" +
"<BASEFONT COLOR=YELLOW>rare beverage known for its strong<BR>" +
"<BASEFONT COLOR=YELLOW>sour taste and can easily get you <BR>" +
"<BASEFONT COLOR=YELLOW>intoxicated in mere seconds. I'll <BR>" +
"<BASEFONT COLOR=YELLOW>easily pay a decent amount of gold for<BR>" +
"<BASEFONT COLOR=YELLOW>each bottle you can bring me. I'm not<BR>" +
"<BASEFONT COLOR=YELLOW>entirely sure of exactly where you're <BR>" +
"<BASEFONT COLOR=YELLOW>able to find some but last I heard you <BR>" +
"<BASEFONT COLOR=YELLOW>can normally find the wine located in <BR>" +
"<BASEFONT COLOR=YELLOW>various dungeons.<BR>" +
"<BASEFONT COLOR=YELLOW><BR>" +
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
               from.SendMessage( "When you scavenge the dungeons be sure to check every chest for that wine." );
               break; 
            } 

         }
      }
   }
}
