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
using Server.Mobiles;
using Server.Items;
using Server.Engines.Quests;

/* 
 * LoggedQuestSystem class :
 * 	This class contains the static functions that handle quest informations :
 * 	 - Did the player accept/decline/cancel/finish the quest ?
 * 	 - This class has a link to the LoggedQuestCenter class that contains the
 * 	 information for the quest logging system
 */

namespace Server.Fearyourself.Quests.Core
{
    //All quests that want the logging system should use this class
    public abstract class LoggedQuestSystem : QuestSystem
    {
        //Get/Setter of the quests' table
        public static Hashtable QuestsTable
        {
            get
            {
                return LoggedQuestCenter.QuestsTable;
            }
            set
            {
                LoggedQuestCenter.QuestsTable = value;
            }
        }

        //Constructor of the LoggedQuestSystem using a PlayerMobile
        public LoggedQuestSystem(PlayerMobile from)
            : base(from)
        {
        }

        //Base constructor of the LoggedQuestSystem
        public LoggedQuestSystem()
            : base()
        {
        }

        //Get the player entry (returns the entry and creates if it doesn't exist)
        private static Hashtable getPlayerEntry(Mobile from)
        {
            Hashtable playerquests = null;

            //Do we already have an entry for this player ?
            if (QuestsTable.ContainsKey(from))
            {
                //Return it
                playerquests = (Hashtable)QuestsTable[from];
            }
            else
            {
                playerquests = new Hashtable();
                //Create hashtable for this player
                QuestsTable[from] = playerquests;
            }

            return playerquests;
        }

        public static void updateQuestInfo(Mobile player, string questname, object info)
        {
            Hashtable playerquests = null;

            //Do we already have an entry for this player ?
            if (QuestsTable.ContainsKey(player))
            {
                //Return it
                playerquests = (Hashtable)QuestsTable[player];
            }
            else
            {
                playerquests = new Hashtable();
                //Create hashtable for this player
                QuestsTable[player] = playerquests;
            }

            //Update info
            playerquests[questname] = info;
        }


        public static object getQuestInfo(Mobile from, string questname)
        {
            Hashtable playerquests = getPlayerEntry(from);

            if (playerquests.ContainsKey(questname))
            {
                return playerquests[questname];
            }
            return null;
        }    

        public static void updateQuestState(Hashtable playerquests, string questname, LoggedQuestState state)
        {
            LoggedQuestInfo lqi;

            //Is the quest in the hashtable
            if (playerquests.ContainsKey(questname))
            {
                lqi = (LoggedQuestInfo)playerquests[questname];
            }
            else
            {
                lqi = new LoggedQuestInfo();
                playerquests[questname] = lqi;
            }

            Console.WriteLine("LoggedQuestSystem, updating : " + questname + " with : " + (int) state);
            //Update quest state
            lqi.State = state;
        }

        public static void questDeclined(Mobile from, string questname)
        {
            Hashtable playerquests = getPlayerEntry(from);

            //Technically lots of different things could be decided here...
            //We could check if the entry already exists...
            //I decide to pass the state as being declined
            updateQuestState(playerquests, questname, LoggedQuestState.DECLINED);
        }

        public static void questAccepted(Mobile from, string questname)
        {
            Hashtable playerquests = getPlayerEntry(from);

            //Technically lots of different things could be decided here...
            //We could check if the entry already exists...
            //I decide to pass the state as being accepted
            updateQuestState(playerquests, questname, LoggedQuestState.ACCEPTED);
        }

        public static void questFinished(Mobile from, string questname)
        {
            Hashtable playerquests = getPlayerEntry(from);

            //Technically lots of different things could be decided here...
            //We could check if the entry already exists...
            //I decide to pass the state as being finished
            updateQuestState(playerquests, questname, LoggedQuestState.FINISHED);
        }

        public static void questCanceled(Mobile from, string questname)
        {
            Hashtable playerquests = getPlayerEntry(from);

            //Technically lots of different things could be decided here...
            //We could check if the entry already exists...
            //I decide to pass the state as being canceled 
            updateQuestState(playerquests, questname, LoggedQuestState.CANCELED);
        }

        //Returns QuestState
        public static LoggedQuestState getQuestState(Mobile from, string questname)
        {
            Console.WriteLine("Here");
            //If we have an entry for the player
            if (QuestsTable.Contains(from))
            {
                Console.WriteLine("Here 2");
                Hashtable playerquests = getPlayerEntry(from);

                //If we have an entry for the quest
                if (playerquests.ContainsKey(questname))
                {
                    //Return state
                    LoggedQuestInfo lqi =  (LoggedQuestInfo) playerquests[questname];
                    return lqi.State;
                }
            }
            //Otherwise the player is not involved with this quest
            return LoggedQuestState.NOTINVOLVED;
        }

        //Deserialize
        public override void ChildDeserialize(GenericReader reader)
        {
            int version = reader.ReadEncodedInt();
        }

        //Serialize
        public override void ChildSerialize(GenericWriter writer)
        {
            writer.WriteEncodedInt((int)0); // version
        }
    }
}
