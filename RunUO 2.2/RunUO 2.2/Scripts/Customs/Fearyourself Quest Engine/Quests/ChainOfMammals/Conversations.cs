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
using Server.Engines.Quests;

namespace Server.Fearyourself.Quests.ChainOfMammals
{
    public class GenericConversation : QuestConversation
    {
        private string m_text;

        public GenericConversation()
        {
            m_text = "Empty text";
        }

        public GenericConversation(string text)
        {
            if (text != null)
            {
                m_text = text;
            }
        }

        public override object Message
        {
            get
            {
                return m_text;
            }
        }

        public override void ChildDeserialize(GenericReader reader)
        {            
            int version = reader.ReadEncodedInt();
            switch (version)
            {
                case 0:
                default:
                    m_text = reader.ReadString();
                    break;
            }
  
        }

        public override void ChildSerialize(GenericWriter writer)
        {            
            writer.WriteEncodedInt((int)0); // version

            writer.Write((string) m_text);
        }

        public override void OnRead()
        {
        }
    }
}