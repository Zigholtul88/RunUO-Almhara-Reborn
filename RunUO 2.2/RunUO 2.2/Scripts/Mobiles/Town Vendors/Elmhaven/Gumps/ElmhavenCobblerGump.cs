using System; using Server; using Server.Commands;using Server.Gumps; using Server.Network;using Server.Items;using Server.Mobiles;namespace Server.Gumps
{ public class ElmhavenCobblerGump : Gump { 
public static void Initialize() { 
CommandSystem.Register( "ElmhavenCobblerGump", AccessLevel.GameMaster, new CommandEventHandler( ElmhavenCobblerGump_OnCommand ) ); 
}
private static void ElmhavenCobblerGump_OnCommand( CommandEventArgs e ) 
{
e.Mobile.SendGump( new ElmhavenCobblerGump( e.Mobile ) ); } 
public ElmhavenCobblerGump( Mobile owner ) : base( 50,50 ) 
{
//----------------------------------------------------------------------------------------------------
AddPage( 0 );AddImageTiled(  54, 33, 369, 400, 2624 );AddAlphaRegion( 54, 33, 369, 400 );AddImageTiled( 416, 39, 44, 389, 203 );
//--------------------------------------Window size bar--------------------------------------------
AddImage( 97, 49, 9005 );AddImageTiled( 58, 39, 29, 390, 10460 );AddImageTiled( 412, 37, 31, 389, 10460 );
AddLabel( 140, 60, 0x34, "" );
//----------------------/----------------------------------------------/
AddHtml( 107, 140, 300, 230, " < BODY > " + 
"<BASEFONT COLOR=YELLOW>Greetings soldier or fair adventurer. I<BR>" +
"<BASEFONT COLOR=YELLOW>can only offer my services in the form<BR>" +
"<BASEFONT COLOR=YELLOW>of various foot wear. You don't want to<BR>" +
"<BASEFONT COLOR=YELLOW>venture out into the wild without any<BR>" +
"<BASEFONT COLOR=YELLOW>decent boots now do you? Feel free to<BR>" +
"<BASEFONT COLOR=YELLOW>use the various dye tubs to change the<BR>" +
"<BASEFONT COLOR=YELLOW>color of your armor or clothes.<BR>" +
"<BASEFONT COLOR=YELLOW><BR>" +
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
