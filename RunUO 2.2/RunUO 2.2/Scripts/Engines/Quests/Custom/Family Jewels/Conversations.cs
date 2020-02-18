using System;
using Server;
using Server.Items;
using Server.Misc;
using Server.Mobiles;

namespace Server.Engines.Quests.FamilyJewels
{
	public class DeclineConversation : QuestConversation
	{
		public override object Message
		{
			get
			{
				return "Fine, I'll find someone else who can help me out.";
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
				return "<I><BASEFONT COLOR=#FFFF00>*Arriana hands to you a jewelry box needed for the parts assembly.*</BASEFONT COLOR></I><BR><BR>My uncle is currently staying at a farm somewhere in ...hmmm, all i can remember is my mother telling me its somewhere next to a beach...I believe it might be Sabrina's Farm over in Zaythalor Forest, though I'm not entirely sure. Bring me back all the pieces and I will be forever in your debt.";
			}
		}

		public AcceptConversation()
		{
		}

		public override void OnRead()
		{
			PlayerMobile pm = System.From;

			pm.AddToBackpack( new AncientJewelryBox() );

			System.AddObjective( new SeekUncleJohnObjective() );
		}
	}

	public class DuringSeekUncleJohnConversation : QuestConversation
	{
		public override object Message
		{
			get
			{
				return "Please find the pieces.";
			}
		}

		public override bool Logged{ get{ return false; } }

		public DuringSeekUncleJohnConversation()
		{
		}
	}

	public class UncleJohnConversation : QuestConversation
	{
		public override object Message
		{
			get
			{
				return "So my niece sent ye here eh.<BR><BR>Yes, I do believe I have that item but first you must do me a favor! I have been crossing plant breeds to create a special green carrot.<BR><BR>Unfortunately everytime I try to harvest one those pesky rabbits steal it on me.<BR><BR>Get me a green carrot from those ferocious beasts and i will give you what you seek.<BR><BR>Be careful they can be quite a handful!";
			}
		}

		public UncleJohnConversation()
		{
		}

		public override void OnRead()
		{
			PlayerMobile pm = System.From;

			System.AddObjective( new ObtainGreenCarrotObjective() );
		}
	}

	public class DuringObtainGreenCarrotConversation : QuestConversation
	{
		public override object Message
		{
			get
			{
				return "Save us all from them darn bunnies!";
			}
		}

		public override bool Logged{ get{ return false; } }

		public DuringObtainGreenCarrotConversation()
		{
		}
	}

	public class UncleJohn2Conversation : QuestConversation
	{
		public override object Message
		{
			get
			{
				return "Praise Eienyasil you got me a green carrot. Here, take this component and seek out Grandpa Tam over in Elmhaven. He should be able to help you out, providing you're able to assist him with his chicken problem.";
			}
		}

		public UncleJohn2Conversation()
		{
		}

		public override void OnRead()
		{
			PlayerMobile pm = System.From;

			System.AddObjective( new SeekGrandpaTamObjective() );
		}
	}

	public class DuringSeekGrandpaTamConversation : QuestConversation
	{
		public override object Message
		{
			get
			{
				return "Thanks for helping with that pesky rabbit!";
			}
		}

		public override bool Logged{ get{ return false; } }

		public DuringSeekGrandpaTamConversation()
		{
		}
	}

	public class GrandpaTamConversation : QuestConversation
	{
		public override object Message
		{
			get
			{
				return "Who are you?<BR><BR>You say you seek the artifact of our ancestors? Well I do believe I have a piece but you must do me a favor first.<BR><BR>I have a chicken in my coop that lays a golden egg, but I have not the patience to get it from him<BR><BR>If you can keep trying to you get one and bring it back to me I will give you the piece.";
			}
		}

		public GrandpaTamConversation()
		{
		}

		public override void OnRead()
		{
			PlayerMobile pm = System.From;

			System.AddObjective( new ObtainGoldenEggObjective() );
		}
	}

	public class DuringObtainGoldenEggConversation : QuestConversation
	{
		public override object Message
		{
			get
			{
				return "Thank you for helping out an old man.";
			}
		}

		public override bool Logged{ get{ return false; } }

		public DuringObtainGoldenEggConversation()
		{
		}
	}

	public class GrandpaTam2Conversation : QuestConversation
	{
		public override object Message
		{
			get
			{
				return "Well I'll be a goosie gander you managed to procure the right egg. Take this second to last piece and seek out Auntie June over beyond Old Plunderer's Haven.";
			}
		}

		public GrandpaTam2Conversation()
		{
		}

		public override void OnRead()
		{
			PlayerMobile pm = System.From;

			System.AddObjective( new SeekAuntieJuneObjective() );
		}
	}

	public class DuringSeekAuntieJuneConversation : QuestConversation
	{
		public override object Message
		{
			get
			{
				return "Good luck to you!";
			}
		}

		public override bool Logged{ get{ return false; } }

		public DuringSeekAuntieJuneConversation()
		{
		}
	}

	public class AuntieJuneConversation : QuestConversation
	{
		public override object Message
		{
			get
			{
				return "Ol' Granpa sent you, you say?<BR><BR>Yes I do have the last piece hidden away, but it's gonna cost ya.<BR><BR>I have been crosspollinating my trees to get a blue apple breed.<BR><BR>Unfortunately They seem to stick to the ground  when they drop so I havn't been able to collect one yet.<BR><BR>Go outside in my orchard and find me an apple thats not stuck and what I have is yours.";
			}
		}

		public AuntieJuneConversation()
		{
		}

		public override void OnRead()
		{
			PlayerMobile pm = System.From;

			System.AddObjective( new ObtainBlueAppleObjective() );
		}
	}

	public class DuringObtainBlueAppleConversation : QuestConversation
	{
		public override object Message
		{
			get
			{
				return "Ohhhh my apples!";
			}
		}

		public override bool Logged{ get{ return false; } }

		public DuringObtainBlueAppleConversation()
		{
		}
	}

	public class AuntieJune2Conversation : QuestConversation
	{
		public override object Message
		{
			get
			{
				return "Sha-boo-pii, how'd you find that apple? I've been scrawling the whole grove looking for one that wasn't too heavy. Anywhoo, heres the final component. Now combine all three pieces and return it to Arriana. I've got work to do";
			}
		}

		public AuntieJune2Conversation()
		{
		}

		public override void OnRead()
		{
			PlayerMobile pm = System.From;

			System.AddObjective( new ReturnToArrianaObjective() );
		}
	}

	public class DuringReturnToArrianaConversation : QuestConversation
	{
		public override object Message
		{
			get
			{
				return "The Piece is now yours, now join them and bring it back to Arriana!";
			}
		}

		public override bool Logged{ get{ return false; } }

		public DuringReturnToArrianaConversation()
		{
		}
	}

	public class EndConversation : QuestConversation
	{
		public override object Message
		{
			get
			{
				return "The deed is done. Take this duplicate and good luck.";
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

		public EndConversation()
		{
		}
	}
}