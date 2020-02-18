using System; using Server; using Server.Commands;using Server.Gumps; using Server.Network;using Server.Items;using Server.Mobiles;namespace Server.Gumps
{ public class ElmhavenReagentSellerGump : Gump { 
public static void Initialize() { 
CommandSystem.Register( "ElmhavenReagentSellerGump", AccessLevel.GameMaster, new CommandEventHandler( ElmhavenReagentSellerGump_OnCommand ) ); 
}
private static void ElmhavenReagentSellerGump_OnCommand( CommandEventArgs e ) 
{
e.Mobile.SendGump( new ElmhavenReagentSellerGump( e.Mobile ) ); } 
public ElmhavenReagentSellerGump( Mobile owner ) : base( 50,50 ) 
{
//----------------------------------------------------------------------------------------------------
AddPage( 0 );AddImageTiled(  54, 33, 369, 400, 2624 );AddAlphaRegion( 54, 33, 369, 400 );AddImageTiled( 416, 39, 44, 389, 203 );
//--------------------------------------Window size bar--------------------------------------------
AddImage( 97, 49, 9005 );AddImageTiled( 58, 39, 29, 390, 10460 );AddImageTiled( 412, 37, 31, 389, 10460 );
AddLabel( 140, 60, 0x34, "" );
//----------------------/----------------------------------------------/
AddHtml( 107, 140, 300, 230, " < BODY > " + 
"<BASEFONT COLOR=YELLOW>Well hello there. Throughout my travels<BR>" +
"<BASEFONT COLOR=YELLOW>and research I've discovered that there<BR>" +
"<BASEFONT COLOR=YELLOW>are other types of reagents that are <BR>" +
"<BASEFONT COLOR=YELLOW>the ingredients of certain forbidden <BR>" +
"<BASEFONT COLOR=YELLOW>magic such as with necromancy.<BR>" +
"<BASEFONT COLOR=YELLOW>Certain creatures of the black arts <BR>" +
"<BASEFONT COLOR=YELLOW>called liches have been known to <BR>" +
"<BASEFONT COLOR=YELLOW>conjure up the undead by relying on <BR>" +
"<BASEFONT COLOR=YELLOW>these deadly reagents. Take extreme<BR>" +
"<BASEFONT COLOR=YELLOW>caution when dealing with these<BR>" +
"<BASEFONT COLOR=YELLOW>undead mages for they are highly<BR>" +
"<BASEFONT COLOR=YELLOW>skilled in magic.<BR>" +
"<BASEFONT COLOR=YELLOW><BR>" +
"<BASEFONT COLOR=YELLOW><BR>" +
"</BODY>", false, true);
//----------------------/----------------------------------------------/
AddImage( 430, 9, 10441);AddImageTiled( 40, 38, 17, 391, 9263 );AddImage( 6, 25, 10421 );AddImage( 34, 12, 10420 );AddImageTiled( 94, 25, 342, 15, 10304 );AddImageTiled( 40, 427, 415, 16, 10304 );AddImage( -10, 314, 10402 );AddImage( 56, 150, 10411 );AddImage( 155, 120, 2103 );AddImage( 136, 84, 96 );AddButton( 225, 390, 0xF7, 0xF8, 0, GumpButtonType.Reply, 0 ); }
//----------------------/----------------------------------------------/
public override void OnResponse( NetState state, RelayInfo info ){ Mobile from = state.Mobile; switch ( info.ButtonID ) { case 0:{ break; }}}}}
