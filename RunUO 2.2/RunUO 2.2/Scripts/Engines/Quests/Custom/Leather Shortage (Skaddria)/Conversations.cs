using System;
using Server;
using Server.Mobiles;
using Server.Items;

namespace Server.Engines.Quests.LeatherShortageSkaddria
{
	public class DeclineConversation : QuestConversation
	{
		public override object Message
		{
			get
			{
				return "<I><BASEFONT COLOR=#FFFF00>You decline the offer and Nathan nods his head in disbelief.</BASEFONT COLOR></I><BR><BR>Well I suppose I'm gonna have to find some other means of getting leather. Maybe I outta dive toes first into the magma chambers of Nimaku Caverns, providing the void terror doesn't do me in beforehand.";					
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
				return "<I><BASEFONT COLOR=#FFFF00>You accept the offer and Nathan smiles with glee.</BASEFONT COLOR></I><BR><BR>Brilliant mate, now I require at least 100 leather strips, and they can range from spined, horned, or barbed. The type you bring me will determine what reward I can give you.";					
			}
		}

		public AcceptConversation()
		{
		}

		public override void OnRead()
		{
			System.AddObjective( new GatherLeatherObjective() );
		}
	}

	public class GatherLeatherConversation : QuestConversation
	{
		public override object Message
		{
			get
			{
				return "Have you've gathered enough leather strips? I'm willing to pay you generously depending on what variety you bring me. Remember there's spined, horned, and barbed.";					
			}
		}

		public override bool Logged{ get{ return false; } }

		public GatherLeatherConversation()
		{
		}
	}

	public class Reward100Conversation : QuestConversation
	{
		public override object Message
		{
			get
			{
				return "<I><BASEFONT COLOR=#FFFF00>You hand over exactly 100 Spined Leather and Nathan takes them from you. He then hands to you three gold bars.</BASEFONT COLOR></I><BR><BR>Quite the generous amount mate. Now we can definitely fill out those orders. Thanks for your help and come back tomorrow and I'll have another job ready for you.";					
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
				return "<I><BASEFONT COLOR=#FFFF00>You hand over exactly 100 Horned Leather and Nathan takes them from you. He then hands to you four gold bars.</BASEFONT COLOR></I><BR><BR>Now that's what I'm talking about. Not only can we finish those orders but there will be enough to last for a while. Thanks for your help and come back tomorrow and I'll have another job ready for you.";					
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
				return "<I><BASEFONT COLOR=#FFFF00>You hand over exactly 100 Barbed Leather and Nathan takes them from you. He then hands to you five gold bars.</BASEFONT COLOR></I><BR><BR>Excellent, that right there is what I'm talking about. Thanks for your help and come back tomorrow and I'll have another job ready for you.";						
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
}