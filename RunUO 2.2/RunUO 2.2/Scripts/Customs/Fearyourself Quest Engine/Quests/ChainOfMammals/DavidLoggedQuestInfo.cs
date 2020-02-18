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
using Server.Fearyourself.Quests.Core;

namespace Server.Fearyourself.Quests.ChainOfMammals
{

   	//DavidLoggedQuestInfo class
	class DavidLoggedQuestInfo : LoggedQuestInfo
	{
		//Counter for this info
		private int m_cnt;

		//Get/Set of the state
		public int Counter
		{
			get 
			{
				return m_cnt;
			}
			set
			{
				m_cnt = value;
			}
		}

		//Constructor
		public DavidLoggedQuestInfo()
		{
		}

		//Serial constructor
        public DavidLoggedQuestInfo(Serial serial)
		{
		} 

		//Serialize the LoggedQuestInfo Class
		public override void ChildSerialize(GenericWriter writer)
		{
			Console.WriteLine("Serialize DavidLoggedQuestInfo");
			writer.WriteEncodedInt((int)0); // version

            Console.WriteLine("Serialize DavidLoggedQuestInfo " + Counter);
			writer.WriteEncodedInt((int)Counter);
		}

		//Deserialize the LoggedQuestInfo Class
		public override void ChildDeserialize( GenericReader reader ) 
		{
            Console.WriteLine("Deserialize DavidLoggedQuestInfo");
			int version = reader.ReadEncodedInt();

			Counter = reader.ReadEncodedInt();
            Console.WriteLine("Deserialize DavidLoggedQuestInfo " + Counter);
		}

	}
}
