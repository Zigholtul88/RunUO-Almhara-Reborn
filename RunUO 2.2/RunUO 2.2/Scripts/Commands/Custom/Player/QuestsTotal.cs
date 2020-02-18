using System;
using Server;
using Server.Mobiles;
using Server.Network;
using Server.Gumps;
using Server.Commands;

namespace Server.Commands
{
	public class QuestsSpecs
	{
		public static void Initialize()
		{
			CommandSystem.Register( "QuestsTotal", AccessLevel.Player, new CommandEventHandler( QuestsSpecs_OnCommand ) );
		}
		
		[Usage( "QuestsTotal" )]
		[Description( "Shows the total amount of completed quests." )]
		public static void QuestsSpecs_OnCommand( CommandEventArgs e )
		{
			Mobile from = e.Mobile;
			from.CloseGump( typeof( QuestsTotalGump ) );
			from.SendGump( new QuestsTotalGump ( from ) );	
		}
		
	}
}

namespace Server.Gumps
{
	public class QuestsTotalGump : Gump
	{
		public QuestsTotalGump(Mobile caller) : base(0,0)
		{
			PlayerMobile from = (PlayerMobile)caller;

			Closable = true;
			Dragable = true;
			
			AddPage(0);
			
			AddBackground( 0, 0, /*295*/ 245, 144, 5054);
			AddBackground( 14, 27, /*261*/ 211, 100, 3500);
			AddLabel( 60, 62, from.TotalQuestsDone < 6 ? 33 : 0, string.Format( "Total Quests Done: {0} / 500", from.TotalQuestsDone) );
			AddItem( 8, 78, 8093);
			AddItem( 19, 60, 4155);
		}
		
		public override void OnResponse( Server.Network.NetState sender, RelayInfo info )
		{
			
		}
	}
}