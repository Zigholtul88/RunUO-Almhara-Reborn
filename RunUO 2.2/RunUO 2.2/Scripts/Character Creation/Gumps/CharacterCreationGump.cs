using System; 
using Server; 
using Server.Commands;
using Server.Gumps; 
using Server.Mobiles;
using Server.Network;

namespace Server.Gumps
{ 
   public class CharacterCreationGump: Gump 
   { 
      public static void Initialize() 
      { 
         CommandSystem.Register( "CharacterCreationGump", AccessLevel.GameMaster, new CommandEventHandler( CharacterCreationGump_OnCommand ) ); 
      } 

      private static void CharacterCreationGump_OnCommand( CommandEventArgs e ) 
      { 
         e.Mobile.SendGump( new CharacterCreationGump( e.Mobile ) ); 
      } 

      public CharacterCreationGump( Mobile owner ) : base( 50,50 ) 
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
			AddLabel( 140, 60, 0x34, "Character Creation" );

			AddHtml( 107, 140, 300, 230, "<BODY>" +
//----------------------/----------------------------------------------/
"<BASEFONT COLOR=YELLOW>Hey dumbass, take a load off, smoke a<BR>" +
"<BASEFONT COLOR=YELLOW>bowl of crimson grass and welcome to<BR>" +
"<BASEFONT COLOR=YELLOW>that one shard that doesn't know how to<BR>" +
"<BASEFONT COLOR=YELLOW>craft decent enough stories, choosing<BR>" +
"<BASEFONT COLOR=YELLOW>instead to opt more for the comedic<BR>" +
"<BASEFONT COLOR=YELLOW>stylings only a stoned mentally<BR>" +
"<BASEFONT COLOR=YELLOW>challenged marsupial would think was<BR>" +
"<BASEFONT COLOR=YELLOW>a good idea for a roleplaying world.<BR>" +
"<BASEFONT COLOR=YELLOW><BR>" +
"<BASEFONT COLOR=YELLOW>If you're not content with the mere<BR>" +
"<BASEFONT COLOR=YELLOW>mundanity that is the human race then<BR>" +
"<BASEFONT COLOR=YELLOW>you're in luck because up ahead are<BR>" +
"<BASEFONT COLOR=YELLOW>two portals that will allow you to<BR>" +
"<BASEFONT COLOR=YELLOW>convert into either sun or moon elf and<BR>" +
"<BASEFONT COLOR=YELLOW>coming soon possibly gargoyles. Once<BR>" +
"<BASEFONT COLOR=YELLOW>you've eventually come to terms with<BR>" +
"<BASEFONT COLOR=YELLOW>your identity issues then you need to<BR>" +
"<BASEFONT COLOR=YELLOW>pick a class.<BR>" +
"<BASEFONT COLOR=YELLOW><BR>" +
"<BASEFONT COLOR=YELLOW>Upon stepping through any of the class<BR>" +
"<BASEFONT COLOR=YELLOW>portals you will automatically be set<BR>" +
"<BASEFONT COLOR=YELLOW>forth to Skaddria Naddheim, where most<BR>" +
"<BASEFONT COLOR=YELLOW>of the npcs can actually be interacted<BR>" +
"<BASEFONT COLOR=YELLOW>with and they will usually offer some<BR>" +
"<BASEFONT COLOR=YELLOW>advice, world lore or possibly even a<BR>" +
"<BASEFONT COLOR=YELLOW>quest. This is also true for anywhere<BR>" +
"<BASEFONT COLOR=YELLOW>else throughout the world. However<BR>" +
"<BASEFONT COLOR=YELLOW>before we leave you to explore, here's<BR>" +
"<BASEFONT COLOR=YELLOW>a very useful tip for those who've<BR>" +
"<BASEFONT COLOR=YELLOW>never played this game before.<BR>" +
"<BASEFONT COLOR=YELLOW><BR>" +
"<BASEFONT COLOR=GREEN>-----Tips of Redundancy 1-----<BR>" +
"<BASEFONT COLOR=YELLOW>Holding down both Ctrl and Shift will<BR>" +
"<BASEFONT COLOR=YELLOW>display all items on screen that can be<BR>" +
"<BASEFONT COLOR=YELLOW>interacted with, though this won't work<BR>" +
"<BASEFONT COLOR=YELLOW>for everything.<BR>" +
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