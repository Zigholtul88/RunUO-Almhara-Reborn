/*
LoggedQuestSystem with two example quests
Copyright (C) 2006 BEYLER Jean Christophe

This program is free software; you can redistribute it and/or
modify it under the terms of the GNU General Public License
as published by the Free Software Foundation; either version 2
of the License, or (at your option) any later version.

This program is distributed in the hope that it will be useful,
but WITHOUT ANY WARRANTY; without even the implied warranty of
MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
GNU General Public License for more details.

You should have received a copy of the GNU General Public License
along with this program; if not, write to the Free Software
Foundation, Inc., 51 Franklin Street, Fifth Floor, Boston, MA  02110-1301, USA.
*/

using System;
using Server;
using Server.Mobiles;
using Server.Items;
using Server.Fearyourself.Quests.Core;

namespace Server.Fearyourself.Quests.ChainOfMammals
{
	//Main quest, derives of LoggedQuestSystem (adding the quest logging system)
	public class BrianQuest : LoggedQuestSystem
	{
		//Table containing the GenericConversation, used by QuestSystem
		private static Type[] m_TypeReferenceTable = new Type[] 
		{
			typeof( ChainOfMammals.GenericConversation )
		};

		//Get function
		public override Type[] TypeReferenceTable
		{ 
			get{ return m_TypeReferenceTable; } 
		}

		//Get Function for the name, this is the name of the quest
		public override object Name
		{
			get
			{
			return "Brian's Quest";
			}
		}

		//Message when you offer the quest
		public override object OfferMessage
		{
			get
			{
			return "Ahhh, Alfred sent you did he ? <br><br>"+
                "It would seem I have a JackRabbit problem, so before I give you anything,<br><br>" +
                "You'll have to kill 4 of them to get anything out of me...<br><br>"+
                "But Charlie will be the one with your reward, not I!";
			}
		}

		public override TimeSpan RestartDelay{ get{ return TimeSpan.MaxValue; } }


		public override bool IsTutorial
		{ 
			get{ return false; } 
		}

		public override int Picture{ get{ return 0x15C9; } }

		public BrianQuest( PlayerMobile from ) : base( from )
		{
		}

		// Serialization
		public BrianQuest()
		{
		}

		public override void ChildDeserialize( GenericReader reader )
		{
			base.ChildDeserialize(reader);

			int version = reader.ReadEncodedInt();
		}

		public override void ChildSerialize( GenericWriter writer )
		{
			base.ChildSerialize(writer);

			writer.WriteEncodedInt( (int) 0 ); // version
		}

		public override void Accept()
		{
			base.Accept();
        
            AddConversation(
					new GenericConversation("Fabulous, kill 4 JackRabbits and be sure to come back!")
				    );

            AddObjective(new BriansKillsObjective());

            LoggedQuestSystem.questAccepted(From, (string)Name);
		}

        //Clear quest -> boolean says if quest is cleared or canceled)
        public override void ClearQuest(bool completed)
        {
            //Clear the quest from the base class (QuestSystem)
            base.ClearQuest(completed);

            //If completed, state becomes Finish
            if (completed)
            {
                LoggedQuestSystem.questFinished(From, (string)Name);
            }
            else
            {
                LoggedQuestSystem.questCanceled(From, (string)Name);
            }
        }


		public override void Decline()
		{
			base.Decline();

			AddConversation(new GenericConversation("Too bad for you"));

            LoggedQuestSystem.questDeclined(From, (string) Name);
		}

        public static void GiveRewardTo(PlayerMobile player, ref bool gold)
        {
            if (gold)
            {
                Item reward = new Gold(Utility.RandomMinMax(250, 350));

                if (player.PlaceInBackpack(reward))
                {
                    player.SendLocalizedMessage(1054076, "", 0x59); // You have been given some gold.
                    gold = false;
                }
                else
                {
                    reward.Delete();
                }
            }
        }
	}
}
