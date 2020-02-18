using System;
using Server;
using Server.Items;
using Server.Mobiles;

namespace Server
{
    public class Features
    {
        public static string Display(Mobile m, string suffix)
        {
            string display;
            Setup set = new Setup();

            if (suffix == null)
                suffix = "";

            if (m is BaseCreature)
            {
                display = NPCLevel(m);

                if (suffix.Length > 0)
                    display = String.Concat(suffix, " " + display);

                return display;
            }
            
            PlayerMobile pm = m as PlayerMobile;

            if (pm.AccessLevel > AccessLevel.Player && !(set.ShowStaffLevel))
                display = "";
            else
            {
                if (set.ShowLevelCap == true)
                    display = " " + pm.Level + "/" + pm.LevelCap;
                else
                    display = " " + pm.Level;
            }

            if (suffix.Length > 0)
            {
                display = String.Concat(suffix, display);
            }

            return display;
        }

        public static string NPCLevel(Mobile m)
        {
            Setup set = new Setup();
            BaseCreature bc = m as BaseCreature;

            int npclevel = ((bc.HitsMax + bc.RawStatTotal) / 40) + ((bc.DamageMax * bc.DamageMin) / 30);

            if (bc is BaseVendor && !(set.ShowVendorLevels))
                return "";
            else
            {
                if (npclevel < 1)
                    return "(level 1)";
                else
                    return "(level " + npclevel.ToString() + ")";
            }
        }
    }
}