using System; using Server; using Server.Commands;using Server.Gumps; using Server.Network;using Server.Items;using Server.Mobiles;namespace Server.Gumps
{ public class ElmhavenInnKeeperGump : Gump { 
public static void Initialize() { 
CommandSystem.Register( "ElmhavenInnKeeperGump", AccessLevel.GameMaster, new CommandEventHandler( ElmhavenInnKeeperGump_OnCommand ) ); 
}
private static void ElmhavenInnKeeperGump_OnCommand( CommandEventArgs e ) 
{
e.Mobile.SendGump( new ElmhavenInnKeeperGump( e.Mobile ) ); } 
public ElmhavenInnKeeperGump( Mobile owner ) : base( 50,50 ) 
{
//----------------------------------------------------------------------------------------------------
AddPage( 0 );AddImageTiled(  54, 33, 369, 400, 2624 );AddAlphaRegion( 54, 33, 369, 400 );AddImageTiled( 416, 39, 44, 389, 203 );
//--------------------------------------Window size bar--------------------------------------------
AddImage( 97, 49, 9005 );AddImageTiled( 58, 39, 29, 390, 10460 );AddImageTiled( 412, 37, 31, 389, 10460 );
AddLabel( 140, 60, 0x34, "" );
//----------------------/----------------------------------------------/
AddHtml( 107, 140, 300, 230, " < BODY > " + 
"<BASEFONT COLOR=YELLOW>Well howdy fellow adventurer. Normally<BR>" +
"<BASEFONT COLOR=YELLOW>I charge for rooms and service but I'll<BR>" +
"<BASEFONT COLOR=YELLOW>make an exception for you. I tend to <BR>" +
"<BASEFONT COLOR=YELLOW>make my money doing other tasks<BR>" +
"<BASEFONT COLOR=YELLOW>around yonder. I just like to help <BR>" +
"<BASEFONT COLOR=YELLOW>those in times of need. Just find <BR>" +
"<BASEFONT COLOR=YELLOW>yourself a room and rest up for the <BR>" +
"<BASEFONT COLOR=YELLOW>night.<BR>" +
"<BASEFONT COLOR=YELLOW><BR>" +
"<BASEFONT COLOR=YELLOW><BR>" +
"<BASEFONT COLOR=YELLOW><BR>" +
"<BASEFONT COLOR=YELLOW><BR>" +
"<BASEFONT COLOR=YELLOW><BR>" +
"<BASEFONT COLOR=YELLOW><BR>" +
"</BODY>", false, true);
//----------------------/----------------------------------------------/
AddImage( 430, 9, 10441);AddImageTiled( 40, 38, 17, 391, 9263 );AddImage( 6, 25, 10421 );AddImage( 34, 12, 10420 );AddImageTiled( 94, 25, 342, 15, 10304 );AddImageTiled( 40, 427, 415, 16, 10304 );AddImage( -10, 314, 10402 );AddImage( 56, 150, 10411 );AddImage( 155, 120, 2103 );AddImage( 136, 84, 96 );AddButton( 225, 390, 0xF7, 0xF8, 0, GumpButtonType.Reply, 0 ); }
//----------------------/----------------------------------------------/
public override void OnResponse( NetState state, RelayInfo info ){ Mobile from = state.Mobile; switch ( info.ButtonID ) { case 0:{ break; }}}}}
