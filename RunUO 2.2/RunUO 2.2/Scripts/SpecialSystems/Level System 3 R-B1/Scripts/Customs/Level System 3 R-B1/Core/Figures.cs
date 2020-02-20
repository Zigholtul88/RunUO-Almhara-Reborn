using System;
using Server;
using Server.Items;
using Server.Mobiles;

namespace Server
{
    public class Figures
    {
        public static int Stats(Mobile m)
        {
            Setup set = new Setup();

            double Multiplier = 0;

            if (set.ExpFromStats)
            {
                Multiplier = set.TotalStatExp / set.StatCap;
                return ((int)Math.Round(Multiplier * m.RawStatTotal));
            }
            else
                return 0;
        }

        public static int Skills(Mobile m)
        {
            Setup set = new Setup();

            double Multiplier = 0;

            if (set.ExpFromSkills)
            {
                if (set.ExpFromOnlyFightSkills)
                {
                    if (Core.AOS)
                    {
                        Multiplier = set.TotalSkillExp / (10 * set.SkillCap);
                        return ((int)Multiplier * AoS(m));
                    }
                    else if (Core.SE | Core.ML)
                    {
                        Multiplier = set.TotalSkillExp / (12 * set.SkillCap);
                        return ((int)Multiplier * SE(m));
                    }
                    else
                    {
                        Multiplier = set.TotalSkillExp / (8 * set.SkillCap);
                        return ((int)Multiplier * Pre(m));
                    }
                }
                else
                {
                    Multiplier = set.TotalSkillExp / (set.SkillCap * set.SkillTotal);
                    return ((int)Multiplier * m.Skills.Total);
                }
            }
            else
                return 0;
        }

        public static double GetKillExp(Mobile killer, Mobile killed, Setup set)
        {
            PlayerMobile pm = killer as PlayerMobile;
            double amount;

            if (killed is PlayerMobile)
            {
                PlayerMobile dead = killed as PlayerMobile;

                amount = ((dead.Str * dead.HitsMax) + (dead.Dex * dead.StamMax)
                + (dead.Int * dead.ManaMax) / 1000);

                if (dead.Skills.Total >= 100)
                    amount += dead.Skills.Total / 5;
                else
                    amount += 100;
            }
            else
            {
                BaseCreature dead = killed as BaseCreature;
                amount = dead.HitsMax + dead.RawStatTotal;

                if (IsMageryCreature(dead))
                    amount += 100;

                if (IsFireBreathingCreature(dead))
                    amount += 200;

                if (killed is VampireBat || killed is VampireBatFamiliar)
                    amount += 5;

                amount += GetPoisonLevel(dead) * 10;
            }

            return amount / 5;
        }

        public static void GetCraftExp(Mobile m, Item created, int Quality, double SuccessChance, double ExcepChance)
        {
            double gain = 0;
            double chance = 100 * SuccessChance;
            Setup set = new Setup();

            if (!set.ExpFromCrafting)
                return;

            if (created is BaseWeapon)
            {
                #region Weapon Resource Settings

                BaseWeapon bw = created as BaseWeapon;

                if (bw.Resource == CraftResource.Iron)
                    gain += 0.2;
                else if (bw.Resource == CraftResource.DullCopper)
                    gain += 0.4;
                else if (bw.Resource == CraftResource.ShadowIron)
                    gain += 0.8;
                else if (bw.Resource == CraftResource.Copper)
                    gain += 1.6;
                else if (bw.Resource == CraftResource.Bronze)
                    gain += 1.8;
                else if (bw.Resource == CraftResource.Gold)
                    gain += 2.2;
                else if (bw.Resource == CraftResource.Agapite)
                    gain += 3.0;
                else if (bw.Resource == CraftResource.Verite)
                    gain += 4.6;
                else if (bw.Resource == CraftResource.Valorite)
                    gain += 4.8;

                #endregion
            }
            else if (created is BaseArmor)
            {
                #region Armour Resource Settings

                BaseArmor ba = created as BaseArmor;

                #region Armour Type (Ring/Chain/Plate)

                foreach (Type t in Armours.Ringmail)
                {
                    if (t == ba.GetType())
                        gain += 0.6;
                }

                foreach (Type t in Armours.Chainmail)
                {
                    if (t == ba.GetType())
                        gain += 1.3;
                }

                foreach (Type t in Armours.Platemail)
                {
                    if (t == ba.GetType())
                        gain += 2.1;
                }

                #endregion

                #region Metals

                if (ba.Resource == CraftResource.Iron)
                    gain += 0.2;
                else if (ba.Resource == CraftResource.DullCopper)
                    gain += 0.4;
                else if (ba.Resource == CraftResource.ShadowIron)
                    gain += 0.8;
                else if (ba.Resource == CraftResource.Copper)
                    gain += 1.6;
                else if (ba.Resource == CraftResource.Bronze)
                    gain += 1.8;
                else if (ba.Resource == CraftResource.Gold)
                    gain += 2.2;
                else if (ba.Resource == CraftResource.Agapite)
                    gain += 3.0;
                else if (ba.Resource == CraftResource.Verite)
                    gain += 4.6;
                else if (ba.Resource == CraftResource.Valorite)
                    gain += 4.8;

                #endregion

                #region Leathers

                else if (ba.Resource == CraftResource.RegularLeather)
                    gain += 0.8;
                else if (ba.Resource == CraftResource.SpinedLeather)
                    gain += 1.6;
                else if (ba.Resource == CraftResource.HornedLeather)
                    gain += 2.6;
                else if (ba.Resource == CraftResource.BarbedLeather)
                    gain += 3.8;

                #endregion

                #region Scales *NOT IN YET*

                //SCALES WILL GO HERE!

                #endregion

                #endregion
            }

            if (chance > 0 && chance < 20)
                gain += 6.0;
            else if (chance > 20 && chance < 40)
                gain += 4.4;
            else if (chance > 40 && chance < 60)
                gain += 3.2;
            else if (chance > 60 && chance < 80)
                gain += 2.0;
            else
                gain += 0.3;

            if (Quality > 1)
                gain += 3.2;

            gain -= ExcepChance;

            Actions.FinalizeExp(m, gain, true, new Setup());
        }

        public static double ExpMirror(Mobile m)
        {
            Setup set = new Setup();
            PlayerMobile pm = m as PlayerMobile;

            if (set.AccumulativeExp)
                return pm.AccKillExp + Figures.Stats(pm) + Figures.Skills(pm);
            else
                return pm.KillExp + Figures.Stats(pm) + Figures.Skills(pm);
        }

        public static double LevelDiffFilter(Mobile m, Mobile killed, double ToFilter, Setup set)
        {
            PlayerMobile pm = m as PlayerMobile;

            double Diff = 0;
            double Filtered = 0;

            if (!set.ExpFilterByLevel | killed == null)
                return ToFilter;

            if (killed is BaseCreature)
            {
                BaseCreature bc = killed as BaseCreature;

                int NPCLevel = ((bc.HitsMax + bc.RawStatTotal) / 40) + ((bc.DamageMax * bc.DamageMin) / 30);

                if (NPCLevel < pm.Level)
                {
                    if (pm.Level - NPCLevel > set.FilterByLevelRange)
                    {
                        Diff = pm.Level - NPCLevel;
                        Filtered = ToFilter - ((Diff - set.FilterByLevelRange) * set.ExpLostPerLevelDiff);
                    }
                    else
                        Filtered = ToFilter;
                }
                else
                {
                    if (NPCLevel - pm.Level > set.FilterByLevelRange)
                    {
                        Diff = NPCLevel - pm.Level;

                        if (set.ReverseRangeEffect)
                            Filtered = ToFilter + ((Diff - set.FilterByLevelRange) * set.ExpLostPerLevelDiff);
                        else
                            Filtered = ToFilter - ((Diff - set.FilterByLevelRange) * set.ExpLostPerLevelDiff);
                    }
                    else
                        Filtered = ToFilter;
                }
            }
            else
            {
                PlayerMobile dead = killed as PlayerMobile;

                if (dead.Level < pm.Level)
                {
                    if (pm.Level - dead.Level > set.FilterByLevelRange)
                    {
                        Diff = pm.Level - dead.Level;
                        Filtered = ToFilter - ((Diff - set.FilterByLevelRange) * set.ExpLostPerLevelDiff);
                    }
                    else
                        Filtered = ToFilter;
                }
                else
                {
                    if (dead.Level - pm.Level > set.FilterByLevelRange)
                    {
                        Diff = dead.Level - pm.Level;

                        if (set.ReverseRangeEffect)
                            Filtered = ToFilter + ((Diff - set.FilterByLevelRange) * set.ExpLostPerLevelDiff);
                        else
                            Filtered = ToFilter - ((Diff - set.FilterByLevelRange) * set.ExpLostPerLevelDiff);
                    }
                    else
                        Filtered = ToFilter;
                }
            }

            return Filtered;
        }

        public static double CapFilter(Mobile m, double ToAdd, Setup set)
        {
            double over;
            double difference;
            PlayerMobile pm = m as PlayerMobile;

            if (pm.Level >= pm.LevelCap && pm.Exp + ToAdd > pm.LevelAt)
            {
                over = (pm.Exp + ToAdd) - pm.LevelAt;
                difference = ToAdd - over;
            }
            else
                difference = ToAdd;

            if (difference < 0)
                difference = 0;

            return difference;
        }

        #region Skill Exp Info

        public static int Pre(Mobile m)
        {
            return (int)(m.Skills[SkillName.Archery].Base + m.Skills[SkillName.Fencing].Base
                + m.Skills[SkillName.Macing].Base + m.Skills[SkillName.Magery].Base +
                m.Skills[SkillName.Parry].Base + m.Skills[SkillName.Swords].Base +
                m.Skills[SkillName.Tactics].Base + m.Skills[SkillName.Wrestling].Base);
        }

        public static int AoS(Mobile m)
        {
            return (int)(Pre(m) + m.Skills[SkillName.Chivalry].Base
                + m.Skills[SkillName.Necromancy].Base);
        }

        public static int SE(Mobile m)
        {
            return (int)(AoS(m) + m.Skills[SkillName.Ninjitsu].Base
                + m.Skills[SkillName.Bushido].Base);
        }

        #endregion

        #region Creature Exp Info

        private static bool IsMageryCreature(BaseCreature bc)
        {
            return (bc != null && bc.AI == AIType.AI_Mage && bc.Skills[SkillName.Magery].Base > 5.0);
        }

        private static bool IsParagon(BaseCreature bc)
        {
            if (bc == null)
                return false;

            return bc.IsParagon;
        }

        private static bool IsFireBreathingCreature(BaseCreature bc)
        {
            if (bc == null)
                return false;

            return bc.HasBreath;
        }

        private static bool IsPoisonImmune(BaseCreature bc)
        {
            return (bc != null && bc.PoisonImmune != null);
        }

        private static int GetPoisonLevel(BaseCreature bc)
        {
            if (bc == null)
                return 0;

            Poison p = bc.HitPoison;

            if (p == null)
                return 0;

            return p.Level + 1;
        }

        #endregion
    }
}