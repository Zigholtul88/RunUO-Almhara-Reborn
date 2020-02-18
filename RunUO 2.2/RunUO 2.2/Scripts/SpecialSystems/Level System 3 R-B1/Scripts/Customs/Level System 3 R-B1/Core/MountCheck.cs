using System;
using Server;
using Server.Mobiles;

namespace Server
{
    //This File Checks ALL MOUNTS To See
    //If You Have A Required Level Setup
    //In The Configuration File, If You Do
    //It Does The Appropriate Checks.
    public class NeedLevel
    {
        public static bool MountCheck(Mobile m, BaseMount mnt)
        {
            Setup set = new Setup();
            PlayerMobile pm = m as PlayerMobile;

            if (set.LTREveryMount > 0)
            {
                if (!(pm.Level >= set.LTREveryMount))
                {
                    mnt.OnDisallowedRider(pm);
                    pm.SendMessage("You are not level {0}!", set.LTREveryMount);
                    return false;
                }
                return true;
            }
            else
            {
                if (mnt is Beetle)
                {
                    if (set.LTRBeetle > 0 && !(pm.Level >= set.LTRBeetle))
                    {
                        mnt.OnDisallowedRider(pm);
                        pm.SendMessage("You are not level {0}!", set.LTRBeetle);
                        return false;
                    }
                    return true;
                }
                else if (mnt is DesertOstard)
                {
                    if (set.LTRDesertOstard > 0 && !(pm.Level >= set.LTRDesertOstard))
                    {
                        mnt.OnDisallowedRider(pm);
                        pm.SendMessage("You are not level {0}!", set.LTRDesertOstard);
                        return false;
                    }
                    return true;
                }
                else if (mnt is FireSteed)
                {
                    if (set.LTRFireSteed > 0 && !(pm.Level >= set.LTRFireSteed))
                    {
                        mnt.OnDisallowedRider(pm);
                        pm.SendMessage("You are not level {0}!", set.LTRFireSteed);
                        return false;
                    }
                    return true;
                }
                else if (mnt is ForestOstard)
                {
                    if (set.LTRForestOstard > 0 && !(pm.Level >= set.LTRForestOstard))
                    {
                        mnt.OnDisallowedRider(pm);
                        pm.SendMessage("You are not level {0}!", set.LTRForestOstard);
                        return false;
                    }
                    return true;
                }
                else if (mnt is FrenziedOstard)
                {
                    if (set.LTRFrenziedOstard > 0 && !(pm.Level >= set.LTRFrenziedOstard))
                    {
                        mnt.OnDisallowedRider(pm);
                        pm.SendMessage("You are not level {0}!", set.LTRFrenziedOstard);
                        return false;
                    }
                    return true;
                }
                else if (mnt is HellSteed)
                {
                    if (set.LTRHellSteed > 0 && !(pm.Level >= set.LTRHellSteed))
                    {
                        mnt.OnDisallowedRider(pm);
                        pm.SendMessage("You are not level {0}!", set.LTRHellSteed);
                        return false;
                    }
                    return true;
                }
                else if (mnt is Hiryu)
                {
                    if (set.LTRHiryu > 0 && !(pm.Level >= set.LTRHiryu))
                    {
                        mnt.OnDisallowedRider(pm);
                        pm.SendMessage("You are not level {0}!", set.LTRHiryu);
                        return false;
                    }
                    return true;
                }
                else if (mnt is Horse)
                {
                    if (set.LTRHorse > 0 && !(pm.Level >= set.LTRHorse))
                    {
                        mnt.OnDisallowedRider(pm);
                        pm.SendMessage("You are not level {0}!", set.LTRHorse);
                        return false;
                    }
                    return true;
                }
                else if (mnt is Kirin)
                {
                    if (set.LTRKirin > 0 && !(pm.Level >= set.LTRKirin))
                    {
                        mnt.OnDisallowedRider(pm);
                        pm.SendMessage("You are not level {0}!", set.LTRKirin);
                        return false;
                    }
                    return true;
                }
                else if (mnt is LesserHiryu)
                {
                    if (set.LTRLesserHiryu > 0 && !(pm.Level >= set.LTRLesserHiryu))
                    {
                        mnt.OnDisallowedRider(pm);
                        pm.SendMessage("You are not level {0}!", set.LTRLesserHiryu);
                        return false;
                    }
                    return true;
                }
                else if (mnt is Nightmare)
                {
                    if (set.LTRNightMare > 0 && !(pm.Level >= set.LTRNightMare))
                    {
                        mnt.OnDisallowedRider(pm);
                        pm.SendMessage("You are not level {0}!", set.LTRNightMare);
                        return false;
                    }
                    return true;
                }
                else if (mnt is RidableLlama)
                {
                    if (set.LTRRidableLlama > 0 && !(pm.Level >= set.LTRRidableLlama))
                    {
                        mnt.OnDisallowedRider(pm);
                        pm.SendMessage("You are not level {0}!", set.LTRRidableLlama);
                        return false;
                    }
                    return true;
                }
                else if (mnt is Ridgeback)
                {
                    if (set.LTRRidgeback > 0 && !(pm.Level >= set.LTRRidgeback))
                    {
                        mnt.OnDisallowedRider(pm);
                        pm.SendMessage("You are not level {0}!", set.LTRRidgeback);
                        return false;
                    }
                    return true;
                }
                else if (mnt is SavageRidgeback)
                {
                    if (set.LTRSavageRidgeback > 0 && !(pm.Level >= set.LTRSavageRidgeback))
                    {
                        mnt.OnDisallowedRider(pm);
                        pm.SendMessage("You are not level {0}!", set.LTRSavageRidgeback);
                        return false;
                    }
                    return true;
                }
                else if (mnt is ScaledSwampDragon)
                {
                    if (set.LTRScaledSwampDragon > 0 && !(pm.Level >= set.LTRScaledSwampDragon))
                    {
                        mnt.OnDisallowedRider(pm);
                        pm.SendMessage("You are not level {0}!", set.LTRScaledSwampDragon);
                        return false;
                    }
                    return true;
                }
                else if (mnt is SeaHorse)
                {
                    if (set.LTRSeaHorse > 0 && !(pm.Level >= set.LTRSeaHorse))
                    {
                        mnt.OnDisallowedRider(pm);
                        pm.SendMessage("You are not level {0}!", set.LTRSeaHorse);
                        return false;
                    }
                    return true;
                }
                else if (mnt is SilverSteed)
                {
                    if (set.LTRSilverSteed > 0 && !(pm.Level >= set.LTRSilverSteed))
                    {
                        mnt.OnDisallowedRider(pm);
                        pm.SendMessage("You are not level {0}!", set.LTRSilverSteed);
                        return false;
                    }
                    return true;
                }
                else if (mnt is SkeletalMount)
                {
                    if (set.LTRSkeletalMount > 0 && !(pm.Level >= set.LTRSkeletalMount))
                    {
                        mnt.OnDisallowedRider(pm);
                        pm.SendMessage("You are not level {0}!", set.LTRSkeletalMount);
                        return false;
                    }
                    return true;
                }
                else if (mnt is SwampDragon)
                {
                    if (set.LTRSwampDragon > 0 && !(pm.Level >= set.LTRSwampDragon))
                    {
                        mnt.OnDisallowedRider(pm);
                        pm.SendMessage("You are not level {0}!", set.LTRSwampDragon);
                        return false;
                    }
                    return true;
                }
                else if (mnt is Unicorn)
                {
                    if (set.LTRUnicorn > 0 && !(pm.Level >= set.LTRUnicorn))
                    {
                        mnt.OnDisallowedRider(pm);
                        pm.SendMessage("You are not level {0}!", set.LTRUnicorn);
                        return false;
                    }
                    return true;
                }
                return true;
            }
        }
    }
}