using System;
using Server;
using Server.Gumps;
using Server.Items;
using Server.Network;
using Server.Commands;
using Server.Targeting;
using Server.Mobiles;

namespace Server.Gumps
{
    public class ExpBar : Gump
    {
        public static void Initialize()
        {
            Setup set = new Setup();

            if (set.AllowExpBar)
                CommandSystem.Register("ExpBar", AccessLevel.Player, new CommandEventHandler(ExpBar_OnCommand));
        }

        private static void ExpBar_OnCommand(CommandEventArgs e)
        {
            e.Mobile.CloseGump(typeof(ExpBar));
            e.Mobile.SendGump(new ExpBar(e.Mobile));
        }

        public ExpBar(Mobile m)
            : base(0, 0)
        {
            Closable = true;
            Disposable = true;
            Dragable = true;
            Resizable = false;
            AddPage(0);

            Setup set = new Setup();
            PlayerMobile pm = m as PlayerMobile;

            AddBackground(10, 10, 295, 90, 9270);

            AddLabel(25, 25, 50, "EXP:");
            AddLabel(60, 25, 3, "" + pm.Exp.ToString("#,0"));

            if (! (set.AccumulativeExp))
            {
                AddLabel(164, 25, 66, "" + pm.Exp.ToString("#,0"));
                AddLabel(158, 25, 50, "(" + AddSpaces(pm.Exp.ToString()) + " Total)");
            }

            AddLabel(25, 40, 50, "Level At:");
            AddLabel(85, 40, 3, "" + pm.LevelAt.ToString("#,0"));

            AddLabel(187, 40, 3, "" + GetPercentage((int)pm.Exp, pm.LevelAt, 2) + "%");
            AddLabel(181, 40, 50, "(" + AddSpaces(GetPercentage((int)pm.Exp, pm.LevelAt, 2) + "%") + " Reached)");
            
            AddLabel(31, 55, 1153, "____________________________");
            
            double ShowBarAt = pm.LevelAt / 100;
            double NextExtendAt = 0;
            int LengthOfBar = 0;

            if (NextExtendAt == 0)
                NextExtendAt = ShowBarAt;

            for (int i = 0; pm.Exp >= NextExtendAt; i++)
            {
                NextExtendAt += ShowBarAt;
                LengthOfBar = (int)(2.24 * i);
            }

            AddImageTiled(30, 70, LengthOfBar, 15, 58);//x, y, Width, Heigth, ID
            AddLabel(26, 68, 1153, "(____________________________)");
        }

        public static string AddSpaces(string SpaceNeeded)
        {
            int Number = 0;
            string Spaces = "";

            for (int i = 0; i < SpaceNeeded.Length; i++)
            {
                if (i == 0)
                    Number = 1;
                else
                    Number = i;
            }

            while (Spaces.Length < Number)
            { Spaces += " "; }

            return Spaces;
        }

        public static string GetPercentage(int value, int total, int places)
        {
            Decimal percent = 0;
            string retval = string.Empty;
            String strplaces = new String('0', places);
            
            if (value == 0 || total == 0)
            { percent = 0; }
            else
            {
                percent = Decimal.Divide(value, total) * 100;

                if (places > 0)
                { strplaces = "." + strplaces; }
            }

            retval = percent.ToString("#" + strplaces);
            return retval;
        }
    }
}