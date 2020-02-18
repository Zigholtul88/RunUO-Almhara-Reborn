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
    public class Alfred : BaseQuester
    {
        [Constructable]
        public Alfred()
        {
        }

        public override void InitBody()
        {
            Name = "Alfred";
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
                ratpos = new Point3D();

            int i;
            for (i = 0; i < 5; i++)
            {
                ratpos.X = pt.X + Utility.Random(6) - 3;
                ratpos.Y = pt.Y + Utility.Random(6) - 3;
                ratpos.Z = pt.Z;

                AlfredsRat ar = new AlfredsRat();
                ar.Home = pt;
                ar.RangeHome = 4;
                ar.MoveToWorld(ratpos, Map.Trammel);
            }

            Brian b = new Brian();
            pt.X +=6;
            b.MoveToWorld(pt, Map.Trammel);

            Charly c = new Charly();
            pt.X += 6;
            c.MoveToWorld(pt, Map.Trammel);

            David d = new David();
            pt.X += 6;
            d.MoveToWorld(pt, Map.Trammel);   
        }

        public override void OnTalk(PlayerMobile player, bool contextMenu)
        {
            //Look at the player
            this.Direction = GetDirectionTo(player);

            LoggedQuestState alfredstate = LoggedQuestSystem.getQuestState(player, "Alfred's Quest");
            AlfredQuest aq = player.Quest as AlfredQuest;

            //Switch on the state 
            switch (alfredstate)
            {
                case LoggedQuestState.NOTINVOLVED:
                    QuestSystem newQuest = null;

                    if (aq == null)
                    {
                        //New quest proposal
                        //Create the quest
                        newQuest = new AlfredQuest(player);

                        //Are we already doing a quest ?
                        if (!(player.Quest == null && QuestSystem.CanOfferQuest(player, typeof(AlfredQuest))))
                        {
                            newQuest.AddConversation(
                                new GenericConversation(
                                    "I'm sorry but you are already occupied, come back later<br><br>" +
                                    "And I'll have a quest for you"
                                    )
                                );
                            return;
                        }
                    }

                    newQuest.SendOffer();
                    break;
                case LoggedQuestState.ACCEPTED:
                    //Being paranoiac, normally bq can't be null be let's be sure
                    if (aq != null)
                    {
                        //Ok we know we have a quest, are we in progress killing bunnies ?
                        if (aq.IsObjectiveInProgress(typeof(AlfredsKillsObjective)))
                        {
                            aq.AddConversation(new GenericConversation("You have not finished your quest"));
                        }
                        //No then we are wanting the reward
                        else
                        {
                            QuestObjective lastObj = aq.FindObjective(typeof(AlfredsReturnAfterKillsObjective));

                            //Ok normally it's got to be non null and it shouldn't be completed
                            //Yet another paranoiac test
                            if (lastObj != null && !lastObj.Completed)
                            {
                                //Send the player to Brian
                                this.Say("Ahhh, I have nothing to offer, perhaps Brian would be nicer...");
                                lastObj.Complete();
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
        }

        public Alfred(Serial serial)
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
