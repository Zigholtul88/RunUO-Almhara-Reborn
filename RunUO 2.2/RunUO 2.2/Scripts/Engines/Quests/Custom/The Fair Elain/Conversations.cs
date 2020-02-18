using System;
using Server;
using Server.Items;
using Server.Misc;
using Server.Mobiles;

namespace Server.Engines.Quests.TheFairElain
{
	public class DeclineConversation : QuestConversation
	{
		public override object Message
		{
			get
			{
				return "<I><BASEFONT COLOR=#FFFF00>You decline the request.</BASEFONT COLOR></I><BR><BR>Please I beg of you!";
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
				return "<I><BASEFONT COLOR=#FFFF00>You accept the request.</BASEFONT COLOR></I><BR><BR>Thank you, my friend, and good travels. Vacar is usually at the library in the city.";
			}
		}

		public AcceptConversation()
		{
		}

		public override void OnRead()
		{
			PlayerMobile pm = System.From;

			System.AddObjective( new SeekVacarJamesObjective() );
		}
	}

	public class DuringSeekVacarJamesConversation : QuestConversation
	{
		public override object Message
		{
			get
			{
				return "Between you and me, we will win the love of my fair Elain!";
			}
		}

		public override bool Logged{ get{ return false; } }

		public DuringSeekVacarJamesConversation()
		{
		}
	}

	public class VacarJamesConversation : QuestConversation
	{
		public override object Message
		{
			get
			{
				return "This is all crap! Oh, hello. Yes, I suppose you want me to write a love letter for your fair Elain. No? Not you? Then for who?<BR><BR>Alecsander? It's too bad I'm already writing one for Erik Sullivan. You need to talk to him before I can change the order. Now off with you.<BR><BR>Hm? Oh, you can find Erik down by the waterfalls outside the city. He's one of the guard.";
			}
		}

		public VacarJamesConversation()
		{
		}

		public override void OnRead()
		{
			PlayerMobile pm = System.From;

			System.AddObjective( new SeekErikSullivanObjective() );
		}
	}

	public class DuringSeekErikSullivanConversation : QuestConversation
	{
		public override object Message
		{
			get
			{
				return "This is all crap!";
			}
		}

		public override bool Logged{ get{ return false; } }

		public DuringSeekErikSullivanConversation()
		{
		}
	}

	public class ErikSullivanConversation : QuestConversation
	{
		public override object Message
		{
			get
			{
				return "What? I'm not going to stop courting Elain for some weakling that hasn't ever picked up a sword!<BR><BR>Tell you what. If you can get the famous sword Gorgon Blade from Andora the Ranger, I'll give up chasing Elain.<BR><BR>That sounds like a good deal, hm? You can find her in the Zaythalor Forest she protects northwest of this establishment.";
			}
		}

		public ErikSullivanConversation()
		{
		}

		public override void OnRead()
		{
			PlayerMobile pm = System.From;

			System.AddObjective( new SeekAndoraObjective() );
		}
	}

	public class DuringSeekAndoraConversation : QuestConversation
	{
		public override object Message
		{
			get
			{
				return "Remember... strength is the measure of a man.";
			}
		}

		public override bool Logged{ get{ return false; } }

		public DuringSeekAndoraConversation()
		{
		}
	}

	public class AndoraConversation : QuestConversation
	{
		public override object Message
		{
			get
			{
				return "My blade? Sorry, friend, but you're not getting it for free. I've been tracking the evil mage Acaras through the woods nearby, but I've been unable to find him.<BR><BR>If you bring back his ring as proof that he is dead, I'll consider letting you have the blade.<BR><BR>The mage known as Acaras is an evil man who summons monsters to do his bidding. Please stop him. You have no idea the amount of damage he's capable of inflicting upon the landscape.";
			}
		}

		public AndoraConversation()
		{
		}

		public override void OnRead()
		{
			PlayerMobile pm = System.From;

			System.AddObjective( new SeekAcarasObjective() );
		}
	}

	public class DuringSeekAcarasConversation : QuestConversation
	{
		public override object Message
		{
			get
			{
				return "Do not return until you have the evil mage's ring!";
			}
		}

		public override bool Logged{ get{ return false; } }

		public DuringSeekAcarasConversation()
		{
		}
	}

	public class AcarasConversation : QuestConversation
	{
		public override object Message
		{
			get
			{
				return "Evil? Me? What? Are you insane? Do I look like an evil mage to you? I couldn't harm a flea!<BR><BR>You want my ring? It's my prized possession! The only thing I have worth any... well, I suppose I can part with it if you had... uh...<BR><BR>Do you think you could get me a robe?";
			}
		}

		public AcarasConversation()
		{
		}

		public override void OnRead()
		{
			PlayerMobile pm = System.From;

			System.AddObjective( new BringAcarasRobeObjective() );
		}
	}

	public class DuringBringAcarasRobeConversation : QuestConversation
	{
		public override object Message
		{
			get
			{
				return "Yes, just a robe. It gets cold out here, you know.";
			}
		}

		public override bool Logged{ get{ return false; } }

		public DuringBringAcarasRobeConversation()
		{
		}
	}

	public class AcarasEndConversation : QuestConversation
	{
		public override object Message
		{
			get
			{
				return "Perfect fit! Brings out my eyes! Yes, the ring. Take it. It's not worth the fake gold it was made with, if you ask me...";
			}
		}

		public AcarasEndConversation()
		{
		}

		public override void OnRead()
		{
			PlayerMobile pm = System.From;

			System.AddObjective( new BringRingToAndoraObjective() );
		}
	}

	public class DuringBringRingToAndoraAcaraConversation : QuestConversation
	{
		public override object Message
		{
			get
			{
				return "Yay. Now I won't freeze my balls off out here.";
			}
		}

		public override bool Logged{ get{ return false; } }

		public DuringBringRingToAndoraAcaraConversation()
		{
		}
	}

	public class AndorasEndConversation : QuestConversation
	{
		public override object Message
		{
			get
			{
				return "Yes, the ring. I can't give up my best blade, though. Take this book to Vacar. He should find it to his liking and help you.";
			}
		}

		public AndorasEndConversation()
		{
		}

		public override void OnRead()
		{
			PlayerMobile pm = System.From;

			System.AddObjective( new BringBookToVacarObjective() );
		}
	}

	public class DuringBringBookToVacarAndoraConversation : QuestConversation
	{
		public override object Message
		{
			get
			{
				return "Go on. I'm done with you.";
			}
		}

		public override bool Logged{ get{ return false; } }

		public DuringBringBookToVacarAndoraConversation()
		{
		}
	}

	public class VacarJamesEndConversation : QuestConversation
	{
		public override object Message
		{
			get
			{
				return "What's this? Oh heavens! New material!<BR><BR>This is great! Here, you can have the letter and give it to who you want.";
			}
		}

		public VacarJamesEndConversation()
		{
		}
	}

	public class DuringBringLetterVacarConversation : QuestConversation
	{
		public override object Message
		{
			get
			{
				return "Love to chat, but I got work to do.";
			}
		}

		public override bool Logged{ get{ return false; } }

		public DuringBringLetterVacarConversation()
		{
		}
	}

	public class ErikSullivanEndConversation : QuestConversation
	{
		public override object Message
		{
			get
			{
				return "So you decided to play messenger afterall. I suppose I should give you something for your time.<BR><BR>Here, perhaps this will help.";
			}
		}

		public override void OnRead()
		{
			PlayerMobile pm = System.From;

                        // woohoo!
			pm.PlaySound( 0x5B1 ); // fiddle_use_well
			pm.PlaySound( pm.Female ? 783 : 1054 );
                        pm.Say( "Yahoo!" );

                        pm.Exp += 2000;
                        pm.KillExp += 2000;
                        pm.SendMessage("You've gained 2000 exp.");

                        if (pm.Exp >= pm.LevelAt && pm.Level != pm.LevelCap)
                        {
                                Actions.DoLevel(pm, new Setup());
                        }

                        pm.TotalQuestsDone += 1;

			System.Complete();
		}

		public ErikSullivanEndConversation()
		{
		}
	}

	public class AlecsanderEndConversation : QuestConversation
	{
		public override object Message
		{
			get
			{
				return "Ah! Many thanks, my friend! Here, as I said, an heirloom that's been in my family for generations. Now to find Elain!";
			}
		}

		public override void OnRead()
		{
			PlayerMobile pm = System.From;

                        // woohoo!
			pm.PlaySound( 0x5B1 ); // fiddle_use_well
			pm.PlaySound( pm.Female ? 783 : 1054 );
                        pm.Say( "Yahoo!" );

                        pm.Exp += 2000;
                        pm.KillExp += 2000;
                        pm.SendMessage("You've gained 2000 exp.");

                        if (pm.Exp >= pm.LevelAt && pm.Level != pm.LevelCap)
                        {
                                Actions.DoLevel(pm, new Setup());
                        }

                        pm.TotalQuestsDone += 1;

			System.Complete();
		}

		public AlecsanderEndConversation()
		{
		}
	}
}