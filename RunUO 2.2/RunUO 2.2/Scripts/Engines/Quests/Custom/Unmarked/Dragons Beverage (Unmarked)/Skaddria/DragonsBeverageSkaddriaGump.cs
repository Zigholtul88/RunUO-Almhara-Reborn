using System; 
using Server; 
using Server.Gumps; 
using Server.Network;
using Server.Commands;
using Server.Items;
using Server.Mobiles;

namespace Server.Gumps
{ 
   public class DragonsBeverageSkaddriaGump : Gump 
   { 
      public static void Initialize() 
      { 
         CommandSystem.Register( "DragonsBeverageSkaddriaGump", AccessLevel.GameMaster, new CommandEventHandler( DragonsBeverageSkaddriaGump_OnCommand ) ); 
      } 

      private static void DragonsBeverageSkaddriaGump_OnCommand( CommandEventArgs e ) 
      { 
         e.Mobile.SendGump( new DragonsBeverageSkaddriaGump( e.Mobile ) ); 
      } 

      public DragonsBeverageSkaddriaGump( Mobile owner ) : base( 50,50 ) 
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
"<BASEFONT COLOR=YELLOW>Doesn't seem we've been getting much<BR>" +
"<BASEFONT COLOR=YELLOW>customers lately so its rather<BR>" +
"<BASEFONT COLOR=YELLOW>refreshing to see a new face. We just<BR>" +
"<BASEFONT COLOR=YELLOW>recently got in a new stock of<BR>" +
"<BASEFONT COLOR=YELLOW>alcoholic beverages, some of them with<BR>" +
"<BASEFONT COLOR=YELLOW>some really interesting names such as<BR>" +
"<BASEFONT COLOR=YELLOW>Bumlight and Irish Spirit. Its really<BR>" +
"<BASEFONT COLOR=YELLOW>weird because they function like<BR>" +
"<BASEFONT COLOR=YELLOW>ordinary beer, but they leave you under<BR>" +
"<BASEFONT COLOR=YELLOW>some strange effects. One moment I'm<BR>" +
"<BASEFONT COLOR=YELLOW>sipping down a bottle of Montoya Rock<BR>" +
"<BASEFONT COLOR=YELLOW>and then I suddenly wanted to challenge<BR>" +
"<BASEFONT COLOR=YELLOW>someone else to a fencing duel.<BR>" +
"<BASEFONT COLOR=YELLOW><BR>" +
"<BASEFONT COLOR=YELLOW>In addition I'm also looking for a<BR>" +
"<BASEFONT COLOR=YELLOW>special beverage. It is known as<BR>" +
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
