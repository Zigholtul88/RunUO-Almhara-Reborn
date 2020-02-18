using System; using Server; using Server.Commands;using Server.Gumps; using Server.Network;using Server.Items;using Server.Mobiles;namespace Server.Gumps
{ public class ElmhavenArchitectGump : Gump { 
public static void Initialize() { 
CommandSystem.Register( "ElmhavenArchitectGump", AccessLevel.GameMaster, new CommandEventHandler( ElmhavenArchitectGump_OnCommand ) ); 
}
private static void ElmhavenArchitectGump_OnCommand( CommandEventArgs e ) 
{
e.Mobile.SendGump( new ElmhavenArchitectGump( e.Mobile ) ); } 
public ElmhavenArchitectGump( Mobile owner ) : base( 50,50 ) 
{
//----------------------------------------------------------------------------------------------------
AddPage( 0 );AddImageTiled(  54, 33, 369, 400, 2624 );AddAlphaRegion( 54, 33, 369, 400 );AddImageTiled( 416, 39, 44, 389, 203 );
//--------------------------------------Window size bar--------------------------------------------
AddImage( 97, 49, 9005 );AddImageTiled( 58, 39, 29, 390, 10460 );AddImageTiled( 412, 37, 31, 389, 10460 );
AddLabel( 140, 60, 0x34, "" );
//----------------------/----------------------------------------------/
AddHtml( 107, 140, 300, 230, " < BODY > " + 
"<BASEFONT COLOR=YELLOW>Ahh greetings to you. I can tell you're<BR>" +
"<BASEFONT COLOR=YELLOW>interested in owning your very own <BR>" +
"<BASEFONT COLOR=YELLOW>house. Well with these tools and a <BR>" +
"<BASEFONT COLOR=YELLOW>healthy sum of gold you can not only<BR>" +
"<BASEFONT COLOR=YELLOW>make your dream come true but can even<BR>" +
"<BASEFONT COLOR=YELLOW>better spruce it up. You can choose <BR>" +
"<BASEFONT COLOR=YELLOW>from a fine selection of various houses<BR>" +
"<BASEFONT COLOR=YELLOW>or you can custom make your own from <BR>" +
"<BASEFONT COLOR=YELLOW>the ground up. You can only place a <BR>" +
"<BASEFONT COLOR=YELLOW>house down in completely empty space<BR>" +
"<BASEFONT COLOR=YELLOW>so nothing can be in the way.<BR>" +
"<BASEFONT COLOR=YELLOW><BR>" +
"<BASEFONT COLOR=YELLOW><BR>" +
"<BASEFONT COLOR=YELLOW><BR>" +
"</BODY>", false, true);
//----------------------/----------------------------------------------/
AddImage( 430, 9, 10441);AddImageTiled( 40, 38, 17, 391, 9263 );AddImage( 6, 25, 10421 );AddImage( 34, 12, 10420 );AddImageTiled( 94, 25, 342, 15, 10304 );AddImageTiled( 40, 427, 415, 16, 10304 );AddImage( -10, 314, 10402 );AddImage( 56, 150, 10411 );AddImage( 155, 120, 2103 );AddImage( 136, 84, 96 );AddButton( 225, 390, 0xF7, 0xF8, 0, GumpButtonType.Reply, 0 ); }
//----------------------/----------------------------------------------/
public override void OnResponse( NetState state, RelayInfo info ){ Mobile from = state.Mobile; switch ( info.ButtonID ) { case 0:{ break; }}}}}
