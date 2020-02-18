using System;
using Server;
using Server.Mobiles;
using Server.Factions;

namespace Server.Misc
{
	public class SkillCheck
	{
		private static readonly bool AntiMacroCode = false;		//Change this to false to disable anti-macro code

		public static TimeSpan AntiMacroExpire = TimeSpan.FromMinutes( 5.0 ); //How long do we remember targets/locations?
		public const int Allowance = 10;	//How many times may we use the same location/target for gain
		private const int LocationSize = 1; //The size of eeach location, make this smaller so players dont have to move as far
		private static bool[] UseAntiMacro = new bool[]
		{
			// true if this skill uses the anti-macro code, false if it does not
			false, // Alchemy = 0,
			false, // Anatomy = 1,
			false, // AnimalLore = 2,
			false, // ItemID = 3,
			false, // ArmsLore = 4,
			false, // Parry = 5,
			false, // Begging = 6,
			false, // Blacksmith = 7,
			false, // Fletching = 8,
			false, // Peacemaking = 9,
			false, // Camping = 10,
			false, // Carpentry = 11,
			false, // Cartography = 12,
			false, // Cooking = 13,
			false, // DetectHidden = 14,
			false, // Discordance = 15,
			false, // EvalInt = 16,
			false, // Healing = 17,
			false, // Fishing = 18,
			false, // Forensics = 19,
			false, // Herding = 20,
			false, // Hiding = 21,
			false, // Provocation = 22,
			false, // Inscribe = 23,
			false, // Lockpicking = 24,
			false, // Magery = 25,
			false, // MagicResist = 26,
			false, // Tactics = 27,
			false, // Snooping = 28,
			false, // Musicianship = 29,
			false, // Poisoning = 30,
			false, // Archery = 31,
			false, // SpiritSpeak = 32,
			false, // Stealing = 33,
			false, // Tailoring = 34,
			false, // AnimalTaming = 35,
			false, // TasteID = 36,
			false, // Tinkering = 37,
			false, // Tracking = 38,
			false, // Veterinary = 39,
			false, // Swords = 40,
			false, // Macing = 41,
			false, // Fencing = 42,
			false, // Wrestling = 43,
			false, // Lumberjacking = 44,
			false, // Mining = 45,
			false, // Meditation = 46,
			false, // Stealth = 47,
			false, // RemoveTrap = 48,
			false, // Necromancy = 49,
			false, // Focus = 50,
			false, // Chivalry = 51
			false, // Bushido = 52
			false, //Ninjitsu = 53
			true, // Spellweaving = 54
                      #region Stygian Abyss
                        true, // Mysticism = 55
                        true, // Imbuing = 56
                        false // Throwing = 57
                      #endregion
		};

		public static void Initialize()
		{
			Mobile.SkillCheckLocationHandler = new SkillCheckLocationHandler( Mobile_SkillCheckLocation );
			Mobile.SkillCheckDirectLocationHandler = new SkillCheckDirectLocationHandler( Mobile_SkillCheckDirectLocation );

			Mobile.SkillCheckTargetHandler = new SkillCheckTargetHandler( Mobile_SkillCheckTarget );
			Mobile.SkillCheckDirectTargetHandler = new SkillCheckDirectTargetHandler( Mobile_SkillCheckDirectTarget );

                        SkillInfo.Table[0].GainFactor = 1;// Alchemy = 0,
                        SkillInfo.Table[1].GainFactor = 1;// Anatomy = 1,
                        SkillInfo.Table[2].GainFactor = 1;// AnimalLore = 2,
                        SkillInfo.Table[3].GainFactor = 1;// ItemID = 3,
                        SkillInfo.Table[4].GainFactor = 1;// ArmsLore = 4,
                        SkillInfo.Table[5].GainFactor = 1;// Parry = 5,
                        SkillInfo.Table[6].GainFactor = 1;// Begging = 6,
                        SkillInfo.Table[7].GainFactor = 1;// Blacksmith = 7,
                        SkillInfo.Table[8].GainFactor = 1;// Fletching = 8,
                        SkillInfo.Table[9].GainFactor = 1;// Peacemaking = 9,
                        SkillInfo.Table[10].GainFactor = 1;// Camping = 10,
                        SkillInfo.Table[11].GainFactor = 1;// Carpentry = 11,
                        SkillInfo.Table[12].GainFactor = 1;// Cartography = 12,
                        SkillInfo.Table[13].GainFactor = 1;// Cooking = 13,
                        SkillInfo.Table[14].GainFactor = 1;// DetectHidden = 14,
                        SkillInfo.Table[15].GainFactor = 1;// Discordance = 15,
                        SkillInfo.Table[16].GainFactor = 1;// EvalInt = 16,
                        SkillInfo.Table[17].GainFactor = 1;// Healing = 17,
                        SkillInfo.Table[18].GainFactor = 1;// Fishing = 18,
                        SkillInfo.Table[19].GainFactor = 1;// Forensics = 19,
                        SkillInfo.Table[20].GainFactor = 1;// Herding = 20,
                        SkillInfo.Table[21].GainFactor = 1.1;// Hiding = 21,
                        SkillInfo.Table[22].GainFactor = 1;// Provocation = 22,
                        SkillInfo.Table[23].GainFactor = 1;// Inscribe = 23,
                        SkillInfo.Table[24].GainFactor = 1;// Lockpicking = 24,
                        SkillInfo.Table[25].GainFactor = .5;// Magery = 25,
                        SkillInfo.Table[26].GainFactor = 1.5;// MagicResist = 26,
                        SkillInfo.Table[27].GainFactor = 1;// Tactics = 27,
                        SkillInfo.Table[28].GainFactor = 1;// Snooping = 28,
                        SkillInfo.Table[29].GainFactor = 1.5;// Musicianship = 29,
                        SkillInfo.Table[30].GainFactor = 1;// Poisoning = 30
                        SkillInfo.Table[31].GainFactor = 1;// Archery = 31
                        SkillInfo.Table[32].GainFactor = 1;// SpiritSpeak = 32
                        SkillInfo.Table[33].GainFactor = 1.2;// Stealing = 33
                        SkillInfo.Table[34].GainFactor = 1;// Tailoring = 34
                        SkillInfo.Table[35].GainFactor = 1;// AnimalTaming = 35
                        SkillInfo.Table[36].GainFactor = 1;// TasteID = 36
                        SkillInfo.Table[37].GainFactor = 1;// Tinkering = 37
                        SkillInfo.Table[38].GainFactor = 1;// Tracking = 38
                        SkillInfo.Table[39].GainFactor = 1;// Veterinary = 39
                        SkillInfo.Table[40].GainFactor = .8;// Swords = 40
                        SkillInfo.Table[41].GainFactor = .8;// Macing = 41
                        SkillInfo.Table[42].GainFactor = .75;// Fencing = 42
                        SkillInfo.Table[43].GainFactor = .8;// Wrestling = 43
                        SkillInfo.Table[44].GainFactor = .8;// Lumberjacking = 44
                        SkillInfo.Table[45].GainFactor = .75;// Mining = 45
                        SkillInfo.Table[46].GainFactor = .025;// Meditation = 46
                        SkillInfo.Table[47].GainFactor = 1;// Stealth = 47
                        SkillInfo.Table[48].GainFactor = 1;// RemoveTrap = 48
                        SkillInfo.Table[49].GainFactor = 1;// Necromancy = 49
                        SkillInfo.Table[50].GainFactor = .025;// Focus = 50
                        SkillInfo.Table[51].GainFactor = 1;// Chivalry = 51 
                        SkillInfo.Table[52].GainFactor = 1;// Bushido = 52
                        SkillInfo.Table[53].GainFactor = 1;// Ninjitsu = 53
                        SkillInfo.Table[54].GainFactor = 1;// Spellweaving = 54
                      #region Stygian Abyss
                        SkillInfo.Table[55].GainFactor = .5;// Mysticism = 55
                        SkillInfo.Table[56].GainFactor = 1;// Imbuing = 56
                        SkillInfo.Table[57].GainFactor = .8;// Throwing = 57
                      #endregion
		}

		public static bool Mobile_SkillCheckLocation( Mobile from, SkillName skillName, double minSkill, double maxSkill )
		{
			Skill skill = from.Skills[skillName];

			if ( skill == null )
				return false;

			double value = skill.Value;

			if ( value < minSkill )
				return false; // Too difficult
			else if ( value >= maxSkill )
				return true; // No challenge

			double chance = (value - minSkill) / (maxSkill - minSkill);

			Point2D loc = new Point2D( from.Location.X / LocationSize, from.Location.Y / LocationSize );
			return CheckSkill( from, skill, loc, chance );
		}

		public static bool Mobile_SkillCheckDirectLocation( Mobile from, SkillName skillName, double chance )
		{
			Skill skill = from.Skills[skillName];

			if ( skill == null )
				return false;

			if ( chance < 0.0 )
				return false; // Too difficult
			else if ( chance >= 1.0 )
				return true; // No challenge

			Point2D loc = new Point2D( from.Location.X / LocationSize, from.Location.Y / LocationSize );
			return CheckSkill( from, skill, loc, chance );
		}

		public static bool CheckSkill( Mobile from, Skill skill, object amObj, double chance )
		{
			if ( from.Skills.Cap == 0 )
				return false;

            //************* Halt Gains in Specific Region Here ****************
              if (from.Region.Name == "Swampwater Solitude" && skill.SkillName == SkillName.Mining && skill.Base >= 100) //Custom Regions in a box method
              {
                  from.SendMessage("You can no longer increase your Mining skill within Swampwater Solitude.");
                  return false;
              }
            //************** Make Gains Faster in Specific Region Here *************
              if (from.Region.Name == "Elandrim Nur Shaz" && skill.SkillName == SkillName.Musicianship && skill.Base <= 100) //Custom Regions in a box method
              {
                  bool success = (chance >= Utility.RandomDouble()); double gc = (double)(from.Skills.Cap - from.Skills.Total) / from.Skills.Cap;
                  gc += (skill.Cap - skill.Base) / skill.Cap;
                  gc /= 0.5;
                  gc += (50.0 - chance) * (success ? 0.5 : (Core.AOS ? 0.0 : 0.2));
                  gc /= 10.0;
                  gc *= skill.Info.GainFactor;
                  if (gc < 0.01)
                      gc = 0.01;
                  if (from is BaseCreature && ((BaseCreature)from).Controlled)
                      gc *= 2;
                  if (from.Alive && ((gc >= Utility.RandomDouble() && AllowGain(from, skill, amObj)) || skill.SkillName == SkillName.Musicianship && skill.Base <= 100.0))
                      Gain(from, skill);
                  return success;
              }
              if (from.Region.Name == "Sagitta Residence" && skill.Base <= 100) //Custom Regions in a box method
              {
                  bool success = (chance >= Utility.RandomDouble()); double gc = (double)(from.Skills.Cap - from.Skills.Total) / from.Skills.Cap;
                  gc += (skill.Cap - skill.Base) / skill.Cap;
                  gc /= 1;
                  gc += (5.0 - chance) * (success ? 0.5 : (Core.AOS ? 0.0 : 0.2) );
                  gc /= 2.5;//50% Increase
                  gc *= skill.Info.GainFactor;
                  if (gc < 0.01)
                      gc = 0.01;
                  if (from is BaseCreature && ((BaseCreature)from).Controlled)
                      gc *= 2;
                  if (from.Alive && ((gc >= Utility.RandomDouble() && AllowGain(from, skill, amObj)) || skill.Base <= 100.0) )
                      Gain(from, skill);
                  return success;
              }
              if (from.Region.Name == "Samsons Swamplands" && skill.SkillName == SkillName.Poisoning && skill.Base <= 100) //Custom Regions in a box method
              {
                  bool success = (chance >= Utility.RandomDouble()); double gc = (double)(from.Skills.Cap - from.Skills.Total) / from.Skills.Cap;
                  gc += (skill.Cap - skill.Base) / skill.Cap;
                  gc /= 0.5;
                  gc += (5.0 - chance) * (success ? 0.5 : (Core.AOS ? 0.0 : 0.2));
                  gc /= 10.0;
                  gc *= skill.Info.GainFactor;
                  if (gc < 0.01)
                      gc = 0.01;
                  if (from is BaseCreature && ((BaseCreature)from).Controlled)
                      gc *= 2;
                  if (from.Alive && ((gc >= Utility.RandomDouble() && AllowGain(from, skill, amObj)) || skill.SkillName == SkillName.Poisoning && skill.Base <= 100.0))
                      Gain(from, skill);
                  return success;
              }
              if (from.Region.Name == "Star Lake" && skill.SkillName == SkillName.Hiding && skill.Base <= 100) //Custom Regions in a box method
              {
                  bool success = (chance >= Utility.RandomDouble()); double gc = (double)(from.Skills.Cap - from.Skills.Total) / from.Skills.Cap;
                  gc += (skill.Cap - skill.Base) / skill.Cap;
                  gc /= 0.5;
                  gc += (5.0 - chance) * (success ? 0.5 : (Core.AOS ? 0.0 : 0.2));
                  gc /= 4.0;
                  gc *= skill.Info.GainFactor;
                  if (gc < 0.01)
                      gc = 0.01;
                  if (from is BaseCreature && ((BaseCreature)from).Controlled)
                      gc *= 2;
                  if (from.Alive && ((gc >= Utility.RandomDouble() && AllowGain(from, skill, amObj)) || skill.SkillName == SkillName.Hiding && skill.Base <= 100.0))
                      Gain(from, skill);
                  return success;
              }
              if (from.Region.Name == "Swampwater Solitude" && skill.SkillName == SkillName.Mining && skill.Base <= 100) //Custom Regions in a box method
              {
                  bool success = (chance >= Utility.RandomDouble()); double gc = (double)(from.Skills.Cap - from.Skills.Total) / from.Skills.Cap;
                  gc += (skill.Cap - skill.Base) / skill.Cap;
                  gc /= 0.5;
                  gc += (5.0 - chance) * (success ? 0.5 : (Core.AOS ? 0.0 : 0.2));
                  gc /= 10.0;
                  gc *= skill.Info.GainFactor;
                  if (gc < 0.01)
                      gc = 0.01;
                  if (from is BaseCreature && ((BaseCreature)from).Controlled)
                      gc *= 2;
                  if (from.Alive && ((gc >= Utility.RandomDouble() && AllowGain(from, skill, amObj)) || skill.SkillName == SkillName.Mining && skill.Base <= 100.0))
                      Gain(from, skill);
                  return success;
              }
              if (from.Region.Name == "Zaythalor Graveyard" && skill.SkillName == SkillName.SpiritSpeak && skill.Base <= 100) //Custom Regions in a box method
              {
                  bool success = (chance >= Utility.RandomDouble()); double gc = (double)(from.Skills.Cap - from.Skills.Total) / from.Skills.Cap;
                  gc += (skill.Cap - skill.Base) / skill.Cap;
                  gc /= 0.5;
                  gc += (10.0 - chance) * (success ? 0.5 : (Core.AOS ? 0.0 : 0.2));
                  gc /= 4.0;
                  gc *= skill.Info.GainFactor;
                  if (gc < 0.01)
                      gc = 0.01;
                  if (from is BaseCreature && ((BaseCreature)from).Controlled)
                      gc *= 2;
                  if (from.Alive && ((gc >= Utility.RandomDouble() && AllowGain(from, skill, amObj)) || skill.SkillName == SkillName.SpiritSpeak && skill.Base <= 100.0))
                      Gain(from, skill);
                  return success;
              }
             //******************* Make Gains Normal if not in Region *******************
               else
               {

			bool success = ( chance >= Utility.RandomDouble() );
			double gc = (double)(from.Skills.Cap - from.Skills.Total) / from.Skills.Cap;
			gc += ( skill.Cap - skill.Base ) / skill.Cap;
			gc /= 2;

			gc += ( 1.0 - chance ) * ( success ? 0.5 : (Core.AOS ? 0.0 : 0.2) );
			gc /= 1;

			gc *= skill.Info.GainFactor;

                        if ( skill.Base > 50.0 )
                        gc /= 1.5;

                        else if ( skill.Base > 60.0 )
                        gc /= 2;

                        else if ( skill.Base > 70.0 )
                        gc /= 3;

                        else if ( skill.Base > 80.0 )
                        gc /= 4;

                        else if ( skill.Base > 95.0 )
                        gc /= 5;

			if ( gc < 0.01 )
				gc = 0.01;

			if ( from is BaseCreature && ((BaseCreature)from).Controlled )
				gc *= 4;

			if ( from.Alive && ( ( gc >= Utility.RandomDouble() && AllowGain( from, skill, amObj ) ) || skill.Base < 10.0 ) )
				Gain( from, skill );

			return success;
                    }
		}

		public static bool Mobile_SkillCheckTarget( Mobile from, SkillName skillName, object target, double minSkill, double maxSkill )
		{
			Skill skill = from.Skills[skillName];

			if ( skill == null )
				return false;

			double value = skill.Value;

			if ( value < minSkill )
				return false; // Too difficult
			else if ( value >= maxSkill )
				return true; // No challenge

			double chance = (value - minSkill) / (maxSkill - minSkill);

			return CheckSkill( from, skill, target, chance );
		}

		public static bool Mobile_SkillCheckDirectTarget( Mobile from, SkillName skillName, object target, double chance )
		{
			Skill skill = from.Skills[skillName];

			if ( skill == null )
				return false;

			if ( chance < 0.0 )
				return false; // Too difficult
			else if ( chance >= 1.0 )
				return true; // No challenge

			return CheckSkill( from, skill, target, chance );
		}

		private static bool AllowGain( Mobile from, Skill skill, object obj )
		{
			if ( Core.AOS && Faction.InSkillLoss( from ) )	//Changed some time between the introduction of AoS and SE.
				return false;

			if ( AntiMacroCode && from is PlayerMobile && UseAntiMacro[skill.Info.SkillID] )
				return ((PlayerMobile)from).AntiMacroCheck( skill, obj );
			else
				return true;
		}

		public enum Stat { Str, Dex, Int }

		public static void Gain( Mobile from, Skill skill )
		{
			if ( from.Region.IsPartOf( typeof( Regions.Jail ) ) )
				return;

			if ( from is BaseCreature && ((BaseCreature)from).IsDeadPet )
				return;

			if ( skill.SkillName == SkillName.Focus && from is BaseCreature )
				return;

			if ( skill.Base < skill.Cap && skill.Lock == SkillLock.Up )
			{
				int toGain = 1;

				if ( skill.Base <= 10.0 )
					toGain = Utility.Random( 4 ) + 1;

				Skills skills = from.Skills;

				if ( from.Player && ( skills.Total / skills.Cap ) >= Utility.RandomDouble() )//( skills.Total >= skills.Cap )
				{
					for ( int i = 0; i < skills.Length; ++i )
					{
						Skill toLower = skills[i];

						if ( toLower != skill && toLower.Lock == SkillLock.Down && toLower.BaseFixedPoint >= toGain )
						{
							toLower.BaseFixedPoint -= toGain;
							break;
						}
					}
				}

				#region Scroll of Alacrity
				PlayerMobile pm = from as PlayerMobile;

				if ( from is PlayerMobile )
					if (pm != null && skill.SkillName == pm.AcceleratedSkill && pm.AcceleratedStart > DateTime.Now)
					toGain *= Utility.RandomMinMax(2, 5);
					#endregion

				if ( !from.Player || (skills.Total + toGain) <= skills.Cap )
				{
					skill.BaseFixedPoint += toGain;
				}
			}

			if ( skill.Lock == SkillLock.Up )
			{
				SkillInfo info = skill.Info;

				if ( from.StrLock == StatLockType.Up && (info.StrGain / 20.0) > Utility.RandomDouble() )
					GainStat( from, Stat.Str );
				else if ( from.DexLock == StatLockType.Up && (info.DexGain / 20.0) > Utility.RandomDouble() )
					GainStat( from, Stat.Dex );
				else if ( from.IntLock == StatLockType.Up && (info.IntGain / 20.0) > Utility.RandomDouble() )
					GainStat( from, Stat.Int );
			}
		}

		public static bool CanLower( Mobile from, Stat stat )
		{
			switch ( stat )
			{
				case Stat.Str: return ( from.StrLock == StatLockType.Down && from.RawStr > 10 );
				case Stat.Dex: return ( from.DexLock == StatLockType.Down && from.RawDex > 10 );
				case Stat.Int: return ( from.IntLock == StatLockType.Down && from.RawInt > 10 );
			}

			return false;
		}

		public static bool CanRaise( Mobile from, Stat stat )
		{
			if ( !(from is BaseCreature && ((BaseCreature)from).Controlled) )
			{
				if ( from.RawStatTotal >= from.StatCap )
					return false;
			}

			switch ( stat )
			{
				case Stat.Str: return ( from.StrLock == StatLockType.Up && from.RawStr < 400 );
				case Stat.Dex: return ( from.DexLock == StatLockType.Up && from.RawDex < 400 );
				case Stat.Int: return ( from.IntLock == StatLockType.Up && from.RawInt < 400 );
			}

			return false;
		}

		public static void IncreaseStat( Mobile from, Stat stat, bool atrophy )
		{
			atrophy = atrophy || (from.RawStatTotal >= from.StatCap);

			switch ( stat )
			{
				case Stat.Str:
				{
					if ( atrophy )
					{
						if ( CanLower( from, Stat.Dex ) && (from.RawDex < from.RawInt || !CanLower( from, Stat.Int )) )
							--from.RawDex;
						else if ( CanLower( from, Stat.Int ) )
							--from.RawInt;
					}

					if ( CanRaise( from, Stat.Str ) )
						++from.RawStr;

					break;
				}
				case Stat.Dex:
				{
					if ( atrophy )
					{
						if ( CanLower( from, Stat.Str ) && (from.RawStr < from.RawInt || !CanLower( from, Stat.Int )) )
							--from.RawStr;
						else if ( CanLower( from, Stat.Int ) )
							--from.RawInt;
					}

					if ( CanRaise( from, Stat.Dex ) )
						++from.RawDex;

					break;
				}
				case Stat.Int:
				{
					if ( atrophy )
					{
						if ( CanLower( from, Stat.Str ) && (from.RawStr < from.RawDex || !CanLower( from, Stat.Dex )) )
							--from.RawStr;
						else if ( CanLower( from, Stat.Dex ) )
							--from.RawDex;
					}

					if ( CanRaise( from, Stat.Int ) )
						++from.RawInt;

					break;
				}
			}
		}

		private static TimeSpan m_StatGainDelay = TimeSpan.FromMinutes( 5.0 );
		private static TimeSpan m_PetStatGainDelay = TimeSpan.FromMinutes( 5.0 );

		public static void GainStat( Mobile from, Stat stat )
		{
			switch( stat )
			{
				case Stat.Str:
				{
					if ( from is BaseCreature && ((BaseCreature)from).Controlled ) {
						if ( (from.LastStrGain + m_PetStatGainDelay) >= DateTime.Now )
							return;
					}
					else if( (from.LastStrGain + m_StatGainDelay) >= DateTime.Now )
						return;

					from.LastStrGain = DateTime.Now;
					break;
				}
				case Stat.Dex:
				{
					if ( from is BaseCreature && ((BaseCreature)from).Controlled ) {
						if ( (from.LastDexGain + m_PetStatGainDelay) >= DateTime.Now )
							return;
					}
					else if( (from.LastDexGain + m_StatGainDelay) >= DateTime.Now )
						return;

					from.LastDexGain = DateTime.Now;
					break;
				}
				case Stat.Int:
				{
					if ( from is BaseCreature && ((BaseCreature)from).Controlled ) {
						if ( (from.LastIntGain + m_PetStatGainDelay) >= DateTime.Now )
							return;
					}

					else if( (from.LastIntGain + m_StatGainDelay) >= DateTime.Now )
						return;

					from.LastIntGain = DateTime.Now;
					break;
				}
			}

			bool atrophy = ( (from.RawStatTotal / (double)from.StatCap) >= Utility.RandomDouble() );

			IncreaseStat( from, stat, atrophy );
		}
	}
}