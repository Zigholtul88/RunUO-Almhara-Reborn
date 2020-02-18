using System; using Server; using Server.Commands;using Server.Gumps; using Server.Network;using Server.Items;using Server.Mobiles;namespace Server.Gumps
{ public class ElmhavenButcherGump : Gump { 
public static void Initialize() { 
CommandSystem.Register( "ElmhavenButcherGump", AccessLevel.GameMaster, new CommandEventHandler( ElmhavenButcherGump_OnCommand ) ); 
}
private static void ElmhavenButcherGump_OnCommand( CommandEventArgs e ) 
{
e.Mobile.SendGump( new ElmhavenButcherGump( e.Mobile ) ); } 
public ElmhavenButcherGump( Mobile owner ) : base( 50,50 ) 
{
//----------------------------------------------------------------------------------------------------
AddPage( 0 );AddImageTiled(  54, 33, 369, 400, 2624 );AddAlphaRegion( 54, 33, 369, 400 );AddImageTiled( 416, 39, 44, 389, 203 );
//--------------------------------------Window size bar--------------------------------------------
AddImage( 97, 49, 9005 );AddImageTiled( 58, 39, 29, 390, 10460 );AddImageTiled( 412, 37, 31, 389, 10460 );
AddLabel( 140, 60, 0x34, "" );
//----------------------/----------------------------------------------/
AddHtml( 107, 140, 300, 230, " < BODY > " + 
"<BASEFONT COLOR=YELLOW>You there, yes you. If you have any<BR>" +
"<BASEFONT COLOR=YELLOW>freshly cut animal meat on you I will<BR>" +
"<BASEFONT COLOR=YELLOW>take it off of your hands in exchange <BR>" +
"<BASEFONT COLOR=YELLOW>for some decent coin.<BR>" +
"<BASEFONT COLOR=YELLOW><BR>" +
"<BASEFONT COLOR=YELLOW>Now if you've probably noticed that<BR>" +
"<BASEFONT COLOR=YELLOW>strange cave over at the Samson<BR>" +
"<BASEFONT COLOR=YELLOW>Swamplands. Well the only way<BR>" +
"<BASEFONT COLOR=YELLOW>you're getting access through<BR>" +
"<BASEFONT COLOR=YELLOW>the barrier is through possession<BR>" +
"<BASEFONT COLOR=YELLOW>of a specialized forest hart shard,<BR>" +
"<BASEFONT COLOR=YELLOW>and if you want one, then bring me<BR>" +
"<BASEFONT COLOR=YELLOW>a regular variant from the local<BR>" +
"<BASEFONT COLOR=YELLOW>deer around here and I'll set you<BR>" +
"<BASEFONT COLOR=YELLOW>up. Or you could give it to the<BR>" +
"<BASEFONT COLOR=YELLOW>other butchers and they'll do<BR>" +
"<BASEFONT COLOR=YELLOW>the same.<BR>" +
"</BODY>", false, true);
//----------------------/----------------------------------------------/
AddImage( 430, 9, 10441);AddImageTiled( 40, 38, 17, 391, 9263 );AddImage( 6, 25, 10421 );AddImage( 34, 12, 10420 );AddImageTiled( 94, 25, 342, 15, 10304 );AddImageTiled( 40, 427, 415, 16, 10304 );AddImage( -10, 314, 10402 );AddImage( 56, 150, 10411 );AddImage( 155, 120, 2103 );AddImage( 136, 84, 96 );AddButton( 225, 390, 0xF7, 0xF8, 0, GumpButtonType.Reply, 0 ); }
//----------------------/----------------------------------------------/
public override void OnResponse( NetState state, RelayInfo info ){ Mobile from = state.Mobile; switch ( info.ButtonID ) { case 0:{ break; }}}}}
