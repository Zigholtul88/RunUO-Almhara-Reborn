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
 *
 * LoggedQuestCenter : 
 * 	- This class contains the item that forces the engine to save the item and the hashtable
 * 	- It will be updated to show a gump that contains the different information
 * 
 */ 

using System;
using Server;
using System.Collections;
using System.Collections.Generic;
using Server.Mobiles;
using Server.Items;

namespace Server.Fearyourself.Quests.Core
{
	//LoggedQuestCenter class
	public class LoggedQuestCenter : Item 
	{
		//Hashtable QuestsTable
		private static Hashtable m_questsTable = null;

		//Get/Set of the quest hashtable
		public static Hashtable QuestsTable
		{ 
			get
			{ 
				return m_questsTable; 
			} 
			set
			{ 
				m_questsTable = value; 
			} 
		}

		[Constructable] 
		//Constructor
		public LoggedQuestCenter() : base( 10900 ) 
		{ 
			Hue = 2; 
			Name = "LoggedQuestCenter";
			Movable = false;
			Light = LightType.Circle300;
		}

		//Function initialize
		public static void Initialize()
		{
            Console.WriteLine("LoggedQuestCenter init");
			//If QuestTable is not allocated
			if(QuestsTable==null)
				QuestsTable = new Hashtable();
		}

		//Function double click
		public override void OnDoubleClick( Mobile from ) 
		{ 
		}

		//Constructor using a serializer
		public LoggedQuestCenter(Serial serial)
			: base(serial) 
			{
                Initialize();
			} 

		//Serialize
		public override void Serialize( GenericWriter writer ) 
		{
			base.Serialize(writer);
			Console.WriteLine("Serialize LoggedQuestSystem");
			writer.WriteEncodedInt((int)0); // version

			//To Serialize a hashtable, we have work to do...
			//So to serialize a hashtable of hashtables... Imagine ;-)
			//Loop through all items of the Player Hashtable
			IDictionaryEnumerator en = QuestsTable.GetEnumerator();

			//First get number of entries
			int cnt = QuestsTable.Count;

			//Write number of entries
			writer.WriteEncodedInt((int) cnt);
			Console.WriteLine("LoggedQuestCenter cnt : " + cnt);

			//Now write them
			while(en.MoveNext())
			{
				Console.WriteLine("LoggedQuestCenter Key : " + en.Key);
				//Write the key of this element
				writer.Write((Mobile) en.Key);

				//Now we handle all the elements of the value hashtable
				//Get the hashtable entry
				Hashtable questname = (Hashtable) en.Value;

				//Get second enumerator
				IDictionaryEnumerator secen = questname.GetEnumerator();

				//First get number of entries
				cnt = questname.Count;
				Console.WriteLine("LoggedQuestCenter Player cnt : " + cnt);

				//Write number of entries
				writer.WriteEncodedInt((int) cnt);

				//Now write them
				while(secen.MoveNext())
				{
					Console.WriteLine("LoggedQuestCenter Player Hash Key : " + secen.Key);

					Console.WriteLine("LoggedQuestCenter Player Hash Value : " + secen.Value);

					LoggedQuestInfo lqi = (LoggedQuestInfo) secen.Value;
					
					//Write key
					writer.Write((string)secen.Key);
					//Write Value
                    LoggedQuestInfoSerializer.Serialize(lqi, writer);
				}
			}
		}

		//Deserialize
		public override void Deserialize( GenericReader reader ) 
		{
			base.Deserialize(reader);

            //Init the static side of the class
            //Initialize();

			Console.WriteLine("Deserialize LoggedQuestCenter");
			int version = reader.ReadEncodedInt();

			//To deserialize the hashtable of hashtables...
			//Note the constructor creates the hashtable so no need of creating it

			//First we get the number of entries
			int cnt = reader.ReadEncodedInt(),
			    i,j;

			Console.WriteLine("Deser LoggedQuestCenter Cnt : " + cnt);
			//Next read each entry
			for (i = 0; i < cnt; i++)
			{
				//Get player key
				Mobile playerkey = reader.ReadMobile();
				Console.WriteLine("Deser LoggedQuestCenter Player : " + playerkey);

				//Get player hash table
				//If not yet in hashtable
				Hashtable playerquests = null;
				if (!QuestsTable.ContainsKey(playerkey))
				{
                    Console.WriteLine("LoggedQuestCenter here3");
					//Create an entry
					playerquests = new Hashtable();
					QuestsTable[playerkey] = playerquests;
				}
				else
				{
                    Console.WriteLine("LoggedQuestCenter here2");
					//Otherwise just get it
					playerquests = (Hashtable) QuestsTable[playerkey];
				}
                Console.WriteLine("LoggedQuestCenter here");

				//Get number of quest entries for this player
				int nbrquests = reader.ReadEncodedInt();

				//Get quest entries
				Console.WriteLine("Deser LoggedQuestCenter Player Hash Count : " + nbrquests);
				for (j = 0; j < nbrquests; j++)
				{
					//Get hash key (string name)
					string key = reader.ReadString();
					//Get hash value (LoggedQuestInfo)
                    LoggedQuestInfo value = LoggedQuestInfoSerializer.Deserialize(reader);
										
					Console.WriteLine("Deser LoggedQuestCenter Player Hash Key : " + key);
					//Add entry
					playerquests[key] = value;
				}
			}
		}
	}
}
