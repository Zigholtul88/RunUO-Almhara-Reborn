using System;
using Server;
using Server.Mobiles;
using Server.Items;

namespace Server.Engines.Quests.OreShortageSkaddria
{
	public class DeclineConversation : QuestConversation
	{
		public override object Message
		{
			get
			{
				return "<I><BASEFONT COLOR=#FFFF00>You decline the offer and Lewis nods his head in disbelief.</BASEFONT COLOR></I><BR><BR>Well I suppose I'm gonna have to find some other means of getting ingots. Perhaps I might sell off my body to the highest bidder or something.";					
			}
		}

		public override bool Logged{ get{ return false; } }

		public DeclineConversation()
		{
		}
	}

	public class AcceptConversation : QuestConversation
	{
		public override object Message
		{
			get
			{
				return "<I><BASEFONT COLOR=#FFFF00>You accept the offer and Lewis smiles with glee.</BASEFONT COLOR></I><BR><BR>Brilliant mate, now I require at least 100 ingots, and they can range from dull copper, shadow iron, copper or bronze. The type you bring me will determine what reward I can give you.";					
			}
		}

		public AcceptConversation()
		{
		}

		public override void OnRead()
		{
			System.AddObjective( new GatherIngotsObjective() );
		}
	}

	public class GatherIngotsConversation : QuestConversation
	{
		public override object Message
		{
			get
			{
				return "Have you've gathered enough ingots? I'm willing to pay you generously depending on what variety you bring me. Remember there's dull copper, shadow iron, copper and bronze.";					
			}
		}

		public override bool Logged{ get{ return false; } }

		public GatherIngotsConversation()
		{
		}
	}

	public class Reward100Conversation : QuestConversation
	{
		public override object Message
		{
			get
			{
				return "<I><BASEFONT COLOR=#FFFF00>You hand over exactly 100 Dull Copper Ingots and Lewis takes them from you. He then hands to you three gold bars and a special pickaxe.</BASEFONT COLOR></I><BR><BR>Quite the generous amount mate. Now we can definitely fill out those orders. I shall now bestow to you this ruby pickaxe, where it is a bit more durable compared to others of its type.";					
			}
		}

		public Reward100Conversation()
		{
		}

		public override void OnRead()
		{
			PlayerMobile pm = System.From;

                        // woohoo!
			pm.PlaySound( 0x5B8 ); // satyrpipe_use_well
			pm.PlaySound( pm.Female ? 783 : 1054 );
                        pm.Say( "Yahoo!" );

			System.Complete();
		}
	}

	public class Reward200Conversation : QuestConversation
	{
		public override object Message
		{
			get
			{
				return "<I><BASEFONT COLOR=#FFFF00>You hand over exactly 100 Shadow Iron Ingots and Lewis takes them from you. He then hands to you four gold bars and an even better special pickaxe.</BASEFONT COLOR></I><BR><BR>Now that's what I'm talking about. Not only can we finish those orders but there will be enough to last for a while. Here, take this emerald pickaxe that I made, which is a lot more durable compared to the ruby version.";					
			}
		}

		public Reward200Conversation()
		{
		}

		public override void OnRead()
		{
			PlayerMobile pm = System.From;

                        // woohoo!
			pm.PlaySound( 0x5B8 ); // satyrpipe_use_well
			pm.PlaySound( pm.Female ? 783 : 1054 );
                        pm.Say( "Yahoo!" );

			System.Complete();
		}
	}

	public class Reward300Conversation : QuestConversation
	{
		public override object Message
		{
			get
			{
				return "<I><BASEFONT COLOR=#FFFF00>You hand over exactly 100 Copper Ingots and Lewis takes them from you. He then hands to you five gold bars and a way better, holy shit awesome pickaxe.</BASEFONT COLOR></I><BR><BR>Holy mashed potatoes, this is way more than I was expecting. Fuck it, I'm gonna let you have my old diamond pickaxe, which is an extremely rare and sought after item that's not only as durable as all heck but you never have to worry about it getting stolen.";						
			}
		}

		public Reward300Conversation()
		{
		}

		public override void OnRead()
		{
			PlayerMobile pm = System.From;

                        // woohoo!
			pm.PlaySound( 0x5B8 ); // satyrpipe_use_well
			pm.PlaySound( pm.Female ? 783 : 1054 );
                        pm.Say( "Yahoo!" );

			System.Complete();
		}
	}

	public class Reward400Conversation : QuestConversation
	{
		public override object Message
		{
			get
			{
				return "<I><BASEFONT COLOR=#FFFF00>You hand over exactly 100 Bronze Ingots and Lewis takes them from you. He then hands to you ten gold bars and a way better, holy shit awesome pickaxe and even better you're getting two of them.</BASEFONT COLOR></I><BR><BR>Oh boy I can feel it calling in the air tonight. Fellow miner, you've earned yourself a real reward for a change.";					
			}
		}

		public Reward400Conversation()
		{
		}

		public override void OnRead()
		{
			PlayerMobile pm = System.From;

                        // woohoo!
			pm.PlaySound( 0x5B8 ); // satyrpipe_use_well
			pm.PlaySound( pm.Female ? 783 : 1054 );
                        pm.Say( "Yahoo!" );

			System.Complete();
		}
	}
}