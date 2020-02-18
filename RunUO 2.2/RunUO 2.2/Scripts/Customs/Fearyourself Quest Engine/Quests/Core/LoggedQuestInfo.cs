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

/*
 * LoggedQuestInfo class :
 * 	- This class contains the information for an entry in the hash table
 * 	- It only contains a state variable but it can be extended to contain what you need
 */ 

using System;
using Server;
using System.Collections;
using System.Collections.Generic;
using Server.Mobiles;
using Server.Items;

namespace Server.Fearyourself.Quests.Core
{

    //Enumeration for the enumeration
    public enum LoggedQuestState
    {
        NOTINVOLVED,
        ACCEPTED,
        FINISHED,
        DECLINED,
        CANCELED
    }

	//LoggedQuestInfo class
	public class LoggedQuestInfo
	{
		
        //Add in this table any new types you would want
        public static readonly Type[] InfoTypes = new Type[]
            {
                typeof(LoggedQuestInfo),
                typeof(Server.Fearyourself.Quests.ChainOfMammals.DavidLoggedQuestInfo)
            };

		//State of the quest
		private LoggedQuestState m_state;

		//Get/Set of the state
		public LoggedQuestState State 
		{
			get 
			{
				return m_state;
			}
			set
			{
				m_state = value;
			}
		}

		//Constructor
		public LoggedQuestInfo()
		{
		}

		//Serial constructor
		public LoggedQuestInfo(Serial serial)
		{
		} 

		//Serialize the LoggedQuestInfo Class
		public void BaseSerialize(GenericWriter writer)
		{
			Console.WriteLine("Serialize LoggedQuestInfo");
			writer.WriteEncodedInt((int)0); // version

			writer.WriteEncodedInt((int)State);

            ChildSerialize(writer);
		}

		//Deserialize the LoggedQuestInfo Class
		public void BaseDeserialize( GenericReader reader ) 
		{
            Console.WriteLine("Deserialize LoggedQuestInfo");
			int version = reader.ReadEncodedInt();

			State = (LoggedQuestState) reader.ReadEncodedInt();

            ChildDeserialize(reader);
		}

        //Serialize the LoggedQuestInfo Class
        public virtual void ChildSerialize(GenericWriter writer)
        {
            Console.WriteLine("ChildSerialize LoggedQuestInfo");
            writer.WriteEncodedInt((int)0); // version
        }

        //Deserialize the LoggedQuestInfo Class
        public virtual void ChildDeserialize(GenericReader reader)
        {
            Console.WriteLine("ChildDeserialize LoggedQuestInfo");
            int version = reader.ReadEncodedInt();
        }

	}
}
