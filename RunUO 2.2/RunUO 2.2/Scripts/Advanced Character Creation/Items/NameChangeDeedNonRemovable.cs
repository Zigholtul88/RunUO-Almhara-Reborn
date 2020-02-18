using System;
using Server.Gumps;
using Server.Misc;
using Server.Network;

namespace Server.Items
{
    	public class NameChangeDeedNonRemovable : Item
    	{
        	[Constructable]
        	public NameChangeDeedNonRemovable(): base(0x14F0)
        	{
            		this.LootType = LootType.Blessed;
                        Movable = false;
        	}

        	public NameChangeDeedNonRemovable(Serial serial): base(serial)
        	{
        	}

        	public override string DefaultName
        	{
            		get
            		{
                		return "a name change deed";
            		}
        	}

        	public override void Serialize(GenericWriter writer)
        	{
            		base.Serialize(writer);

            		writer.Write((int)0); // version
        	}

        	public override void Deserialize(GenericReader reader)
        	{
            		base.Deserialize(reader);

            		int version = reader.ReadInt();
        	}

        	public override void OnDoubleClick(Mobile from)
        	{
                	from.CloseGump( typeof(NameChangeDeedNonRemovableGump ) );
                	from.SendGump( new NameChangeDeedNonRemovableGump( this ) );
    		}

    		public class NameChangeDeedNonRemovableGump : Gump
    		{
        		Item m_Sender;

        		public void AddBlackAlpha(int x, int y, int width, int height)
        		{
            			AddImageTiled(x, y, width, height, 2624);
            			AddAlphaRegion(x, y, width, height);
        		}

       	 		public void AddTextField(int x, int y, int width, int height, int index)
        		{
            			AddBackground(x - 2, y - 2, width + 4, height + 4, 0x2486);
            			AddTextEntry(x + 2, y + 2, width - 4, height - 4, 0, index, "");
        		}

        		public string Center(string text)
        		{
            			return String.Format("<CENTER>{0}</CENTER>", text);
        		}

        		public string Color(string text, int color)
        		{
            			return String.Format("<BASEFONT COLOR=#{0:X6}>{1}</BASEFONT>", color, text);
        		}

        		public void AddButtonLabeled(int x, int y, int buttonID, string text)
        		{
            			AddButton(x, y - 1, 4005, 4007, buttonID, GumpButtonType.Reply, 0);
            			AddHtml(x + 35, y, 240, 20, this.Color(text, 0xFFFFFF), false, false);
        		}

        		public NameChangeDeedNonRemovableGump(Item sender): base(50, 50)
        		{
            			this.m_Sender = sender;

            			Closable = true;
            			Dragable = true;
            			Resizable = false;

            			AddPage(0);

            			this.AddBlackAlpha(10, 120, 250, 85);
            			AddHtml(10, 125, 250, 20, this.Color(this.Center("Name Change Deed"), 0xFFFFFF), false, false);

            			AddLabel(73, 15, 1152, "");
            			AddLabel(20, 150, 0x480, "New Name:");
            			this.AddTextField(100, 150, 150, 20, 0);

            			this.AddButtonLabeled(75, 180, 1, "Submit");
        		}

        		public override void OnResponse(NetState sender, RelayInfo info)
        		{
            			if (this.m_Sender == null || this.m_Sender.Deleted || info.ButtonID != 1 || this.m_Sender.RootParent != sender.Mobile)
                			return;

            			Mobile m = sender.Mobile;
            			TextRelay nameEntry = info.GetTextEntry(0);

            			string newName = (nameEntry == null ? null : nameEntry.Text.Trim());


            			if (!NameVerification.Validate(newName, 2, 16, true, true, true, 1, NameVerification.SpaceDashPeriodQuote))
            			{
                			m.SendMessage("That name is unacceptable.");
                			return;
            			}
            			else
            			{
                			m.RawName = newName;
                			m.SendMessage("Your name has been changed!");
                			m.SendMessage(String.Format("You are now known as {0}", newName));
                			this.m_Sender.Delete();
            			}
			}
        	}
	}
}