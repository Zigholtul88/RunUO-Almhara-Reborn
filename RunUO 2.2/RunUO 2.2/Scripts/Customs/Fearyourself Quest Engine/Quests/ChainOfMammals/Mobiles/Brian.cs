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
using Server.Engines.Quests;
using Server.Fearyourself.Quests.Core;

namespace Server.Fearyourself.Quests.ChainOfMammals
{
    public class Brian : BaseQuester
    {
        [Constructable]
        public Brian()
        {
        }

        public override void InitBody()
        {
            Name = "Brian";
            Body = 400;
            VirtualArmor = 50;
            CantWalk = true;
            Female = false;

            HairItemID = 0x203B;
            HairHue = 0x1;

            AddItem(new Server.Items.LongPants(0x1));
            AddItem(new Server.Items.FancyShirt(0x481)); ;
            AddItem(new Server.Items.ThighBoots(0x1));
            AddItem(new Server.Items.FeatheredHat(0x1));
            AddItem(new Server.Items.Cloak(0x485));

            Blessed = true;
        }


        public override void MoveToWorld(Point3D newLocation, Map map)
        {
            base.MoveToWorld(newLocation, map);

            /* Create the rabbits */
            Point3D pt = newLocation,
                jackrabbitpos = new Point3D();

            int i;
            for (i = 0; i < 5; i++)
            {
                jackrabbitpos.X = pt.X + Utility.Random(6) - 3;
                jackrabbitpos.Y = pt.Y + Utility.Random(6) - 3;
                jackrabbitpos.Z = pt.Z;

                BriansJackRabbit bjr = new BriansJackRabbit();
                bjr.Home = pt;
                bjr.RangeHome = 4;
                bjr.MoveToWorld(jackrabbitpos, Map.Trammel);
            }
        }

        public override void OnTalk(PlayerMobile player, bool contextMenu)
        {
            //Look at the player
            this.Direction = GetDirectionTo(player);

            //New quest proposal
            //Create the quest
            QuestSystem newQuest = new BrianQuest(player);

            //First we check if we have done Bobs Quest
            LoggedQuestState state = LoggedQuestSystem.getQuestState(player, "Alfred's Quest");

            switch (state)
            {
                case LoggedQuestState.FINISHED:
                    //Look for this quest's state
                    LoggedQuestState Brianstate = LoggedQuestSystem.getQuestState(player, "Brian's Quest");

                    //Switch on the state 
                    switch (Brianstate)
                    {
                        case LoggedQuestState.NOTINVOLVED:
                            //Are we already doing a quest ?
                            if (!(player.Quest == null && QuestSystem.CanOfferQuest(player, typeof(BrianQuest))))
                            {
                                newQuest.AddConversation(
                                    new GenericConversation(
                                        "I'm sorry but you are already occupied, come back later<br><br>" +
                                        "And I'll have a quest for you"
                                        )
                                    );
                                return;
                            }

                            newQuest.SendOffer();
                            break;
                        case LoggedQuestState.ACCEPTED:
                            BrianQuest bq = player.Quest as BrianQuest;

                            //Being paranoiac, normally bq can't be null be let's be sure
                            if (bq != null)
                            {
                                //Ok we know we have a quest, are we in progress killing bunnies ?
                                if (bq.IsObjectiveInProgress(typeof(BriansKillsObjective)))
                                {
                                    bq.AddConversation(new GenericConversation("You have not finished your quest"));
                                }
                                //No then we are wanting the reward
                                else
                                {
                                    QuestObjective lastObj = bq.FindObjective(typeof(BriansReturnAfterKillsObjective));

                                    //Ok normally it's got to be non null and it shouldn't be completed
                                    //Yet another paranoiac test
                                    if (lastObj != null && !lastObj.Completed)
                                    {
                                       //Send the player to Brian
                                       this.Say("I told you to go see Charlie when you were finished...");
                                    }
                                }
                            }
                            else
                            {
                                //Write to console, if you see this, you made a mistake in the quest name...
                                Console.WriteLine("Quest should not be null, what happenned?");
                            }
                            break;
                        case LoggedQuestState.CANCELED:
                            this.Say("You canceled your quest, move along");
                            break;
                        case LoggedQuestState.FINISHED:
                            this.Say("You have already finished this quest, move along");
                            break;
                        case LoggedQuestState.DECLINED:
                            this.Say("You have refused this quest, move along");
                            break;
                        default:
                            break;
                    }
                    break;
                case LoggedQuestState.ACCEPTED:
                    this.Say("Finish Alfred's quest and come and see me");
                    break;
                case LoggedQuestState.CANCELED:
                    this.Say("You canceled Alfred's quest, move along");
                    break;
                case LoggedQuestState.DECLINED:
                    this.Say("You declined Alfred's quest, move along");
                    break;
                case LoggedQuestState.NOTINVOLVED:
                    this.Say("Ahhh, you must prove yourself first to Alfred");
                    break;
                default:
                    break;
            }
        }

        public Brian(Serial serial)
            : base(serial)
        {
        }

        public override void Serialize(GenericWriter writer)
        {
            base.Serialize(writer);

            writer.WriteEncodedInt((int)0); // version
        }

        public override void Deserialize(GenericReader reader)
        {
            base.Deserialize(reader);

            int version = reader.ReadEncodedInt();
        }
    }
}
