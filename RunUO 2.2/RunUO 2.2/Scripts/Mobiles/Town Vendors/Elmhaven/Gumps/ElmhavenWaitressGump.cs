using System; using Server; using Server.Commands;using Server.Gumps; using Server.Network;using Server.Items;using Server.Mobiles;namespace Server.Gumps
{ public class ElmhavenWaitressGump : Gump { 
public static void Initialize() { 
CommandSystem.Register( "ElmhavenWaitressGump", AccessLevel.GameMaster, new CommandEventHandler( ElmhavenWaitressGump_OnCommand ) ); 
}
private static void ElmhavenWaitressGump_OnCommand( CommandEventArgs e ) 
{
e.Mobile.SendGump( new ElmhavenWaitressGump( e.Mobile ) ); } 
public ElmhavenWaitressGump( Mobile owner ) : base( 50,50 ) 
{
//----------------------------------------------------------------------------------------------------
AddPage( 0 );AddImageTiled(  54, 33, 369, 400, 2624 );AddAlphaRegion( 54, 33, 369, 400 );AddImageTiled( 416, 39, 44, 389, 203 );
//--------------------------------------Window size bar--------------------------------------------
AddImage( 97, 49, 9005 );AddImageTiled( 58, 39, 29, 390, 10460 );AddImageTiled( 412, 37, 31, 389, 10460 );
AddLabel( 140, 60, 0x34, "" );
//----------------------/----------------------------------------------/
AddHtml( 107, 140, 300, 230, " < BODY > " + 
"<BASEFONT COLOR=YELLOW>Well good evening, if you're looking<BR>" +
"<BASEFONT COLOR=YELLOW>for a good time then may I help you in<BR>" +
"<BASEFONT COLOR=YELLOW>a glass of some good wine? Speaking <BR>" +
"<BASEFONT COLOR=YELLOW>of which Vivian said she was looking <BR>" +
"<BASEFONT COLOR=YELLOW>for a specific kind that's said to make<BR>" +
"<BASEFONT COLOR=YELLOW>you intoxicated within a few seconds.<BR>" +
"<BASEFONT COLOR=YELLOW>Its said to be a favorite of dragons<BR>" +
"<BASEFONT COLOR=YELLOW>and has a strong sour taste. <BR>" +
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
