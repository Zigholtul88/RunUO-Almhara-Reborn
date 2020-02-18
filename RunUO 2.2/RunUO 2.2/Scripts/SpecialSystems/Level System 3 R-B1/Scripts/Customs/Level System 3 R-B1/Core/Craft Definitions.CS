using System;
using System.Collections;
using System.Collections.Generic;
using Server;
using Server.Items;
using Server.Mobiles;
using Server.Network;

namespace Server
{
    public class Armours // This is for craft xp.
    {
        public static Type[] Ringmail = new Type[]
            {
                typeof(RingmailGloves),
                typeof(RingmailLegs),
                typeof(RingmailArms),
                typeof(RingmailChest)
            };

        public static Type[] Chainmail = new Type[]
            {
                typeof(ChainCoif),
                typeof(ChainChest),
                typeof(ChainLegs)
            };

        public static Type[] Platemail = new Type[]
            {
                typeof(PlateHelm),
                typeof(PlateArms),
                typeof(PlateGloves),
                typeof(PlateChest),
                typeof(PlateLegs),
                typeof(PlateGorget),
                typeof(FemalePlateChest)
            };
    }
}