using System;
using Server;
using Server.Gumps;
using Server.Network;
using Server.Commands;
using Server.Items;

namespace Server.Gumps
{
    public class CreateFoodGump : Gump
    {
          public CreateFoodGump()
			:base(0, 0)
        	{
            
		Closable = true;
            Disposable = true;
            Dragable = true;
		Resizable = false;

            AddPage(0);
            AddBackground(148, 104, 152, 157, 9200);
            AddTextEntry(157, 112, 86, 20, 0, 0, @"Create Food");   
            AddButton(191, 170, 247, 248, 0, GumpButtonType.Reply, 0);
            AddButton(189, 230, 247, 248, 1, GumpButtonType.Reply, 0);
            AddTextEntry(181, 141, 86, 20, 0, 0, @"Create Meat");
            AddTextEntry(178, 201, 86, 20, 0, 0, @"Create Fruit");
		
        }

        public override void OnResponse(NetState sender, RelayInfo info)
        {
            Mobile from = sender.Mobile;

            switch (info.ButtonID)
            {
                case 0:
				{
                    from.SendMessage("You Have Created Meat.");
                    Item o_item = null;

                    switch (Utility.Random(3))
                    {
                        case 0: o_item = new Ham(); break;
                        case 1: o_item = new CookedBird(); break;
                        case 2: o_item = new Sausage(); break;
                    }
                    from.AddToBackpack(o_item); 
                    from.CloseGump(typeof(CreateFoodGump));
                  
                    break;
				}
                case 1: 
				{

                    from.SendMessage("You Have Created Fruits & Vegies.");
                    Item o_item = null;

                    switch (Utility.Random(3))
                    {
                        case 0: o_item = new Apple(); break;
                        case 1: o_item = new Carrot(); break;
                        case 2: o_item = new Grapes(); break;
                    }
                    from.AddToBackpack(o_item); 
                    from.CloseGump(typeof(CreateFoodGump));
                    
                    
                    break;
				}

            }
        }
    }
}