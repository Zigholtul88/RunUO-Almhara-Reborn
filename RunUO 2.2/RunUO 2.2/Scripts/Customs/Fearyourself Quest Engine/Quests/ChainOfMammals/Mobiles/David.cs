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
using System.Collections;
using System.Collections.Generic;
using Server.ContextMenus;
using Server.Mobiles;
using Server.Items;
using Server.Engines.Quests;
using Server.Fearyourself.Quests.Core;

namespace Server.Fearyourself.Quests.ChainOfMammals
{
    public class David : Mobile
    {
        [Constructable]
        public David()
        {
            Name = "David";
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

        public override void GetContextMenuEntries(Mobile from, List<ContextMenuEntry> list)
        {
            base.GetContextMenuEntries(from, list);
            list.Add(new DavidEntry(from, this));
        }


        public class DavidEntry : ContextMenuEntry
        {
            private Mobile m_Mobile;
            private Mobile m_Giver;

            public DavidEntry(Mobile from, Mobile giver)
                : base(6146, 3)
            {
                m_Mobile = from;
                m_Giver = giver;
            }

            public override void OnClick()
            {
                PlayerMobile player = (PlayerMobile)m_Mobile;

                //Look for the quest state
                LoggedQuestState bobstate = LoggedQuestSystem.getQuestState(player, "Bunny Attack Quest");

                //No need to check Alfred -> If brian's quest is finished, then alfred's is too
                LoggedQuestState brianstate = LoggedQuestSystem.getQuestState(player, "Brian's Quest");

                if ((bobstate == LoggedQuestState.FINISHED) && (brianstate == LoggedQuestState.FINISHED))
                {
                    //Get David's State
                    LoggedQuestState davidstate = LoggedQuestSystem.getQuestState(player, "David's Quest");
                    //David's info
                    DavidLoggedQuestInfo davidinfo = null;

                    if (davidstate == LoggedQuestState.NOTINVOLVED)
                    {
                        //Create a DavidLoggedQuestInfo instance and replace the information for this entry
                        davidinfo = new DavidLoggedQuestInfo();

                        //Add entry
                        LoggedQuestSystem.questFinished(player, "David's Quest");
                        
                        //Set Counter
                        davidinfo.Counter = 0;
                        davidinfo.State = LoggedQuestState.FINISHED;

                        LoggedQuestSystem.updateQuestInfo(player, "David's Quest", davidinfo);
                    }
                    else
                    {
                        davidinfo = (DavidLoggedQuestInfo)LoggedQuestSystem.getQuestInfo(player, "David's Quest");
                    }

                    //Check counter
                    if (davidinfo.Counter < 2)
                    {
                        bool gold = true;
                        GiveRewardTo(player, ref gold);

                        //If given
                        if (!gold)
                        {
                            //Now update the counter
                            davidinfo.Counter++;
                            m_Giver.Say("Here, have some gold " + davidinfo.Counter);
                        }
                        else
                        {
                            m_Giver.Say("You don't even have room for gold!");
                        }
                    }
                    else
                    {
                        m_Giver.Say("Go away, I gave you gold twice!");
                    }
                }
                else
                {
                    m_Giver.Say("I have nothing to say to you!");
                }
            }
        }

        public David(Serial serial)
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
