using System; 
using Server.Gumps;
using Server.Items; 
using Server.Mobiles; 
using Server.Network; 

namespace Server.Items
{
      public class OphidianAlterationGate : Item
      {
            [Constructable]
            public OphidianAlterationGate() : base(0xF6C)
            {
	            Movable = false;
	            Light = LightType.Circle300;
	            Hue = 1366; 
	            Name = "Ophidian Alteration Gate"; 
            }

            public OphidianAlterationGate(Serial serial) : base(serial)
            {
            }

            public override void Serialize( GenericWriter writer ) 
            { 
               base.Serialize( writer ); 

               writer.Write( (int) 0 ); // version 
            } 

            public override void Deserialize( GenericReader reader ) 
            { 
               base.Deserialize( reader ); 

               int version = reader.ReadInt(); 
            } 

            public override bool OnMoveOver( Mobile m ) 
            { 

            if ( m.Female == false )
            {
                m.Race = Race.Elf;
                m.Title = "the Ophidian";

                m.BodyMod = 86;
                m.HueMod = 0;

                m.BodyValue = 605;
                m.Hue = 93;
                m.HairItemID = 12237;
                m.HairHue = 43;
                m.FacialHairHue = 0;
                m.FacialHairItemID = 0;

                m.StatCap = 175;
                m.SkillsCap = 7000;
                m.Str = 10;
                m.Dex = 10;
                m.Int = 10;

                m.Skills.Alchemy.Base = 0;
                m.Skills.Anatomy.Base = 0;
                m.Skills.AnimalLore.Base = 0;
                m.Skills.AnimalTaming.Base = 0;
                m.Skills.Archery.Base = 0;
                m.Skills.ArmsLore.Base = 0;
                m.Skills.Begging.Base = 0;
                m.Skills.Blacksmith.Base = 0;
                m.Skills.Camping.Base = 0;
                m.Skills.Carpentry.Base = 0;
                m.Skills.Cartography.Base = 0;
                m.Skills.Cooking.Base = 0;
                m.Skills.DetectHidden.Base = 0;
                m.Skills.Discordance.Base = 0;
                m.Skills.EvalInt.Base = 0;
                m.Skills.Fishing.Base = 0;
                m.Skills.Fencing.Base = 0;
                m.Skills.Fletching.Base = 0;
                m.Skills.Focus.Base = 0;
                m.Skills.Forensics.Base = 0;
                m.Skills.Healing.Base = 0;
                m.Skills.Herding.Base = 0;
                m.Skills.Hiding.Base = 0;
                m.Skills.Inscribe.Base = 0;
                m.Skills.ItemID.Base = 0;
                m.Skills.Lockpicking.Base = 0;
                m.Skills.Lumberjacking.Base = 0;
                m.Skills.Macing.Base = 0;
                m.Skills.Magery.Base = 0;
                m.Skills.MagicResist.Base = 20;
                m.Skills.Meditation.Base = 0;
                m.Skills.Mining.Base = 0;
                m.Skills.Musicianship.Base = 0;
                m.Skills.Parry.Base = 0;
                m.Skills.Peacemaking.Base = 0;
                m.Skills.Poisoning.Base = 0;
                m.Skills.Provocation.Base = 0;
                m.Skills.RemoveTrap.Base = 0;
                m.Skills.Snooping.Base = 0;
                m.Skills.SpiritSpeak.Base = 0;
                m.Skills.Stealing.Base = 0;
                m.Skills.Stealth.Base = 0;
                m.Skills.Swords.Base = 0;
                m.Skills.Tactics.Base = 0;
                m.Skills.Tailoring.Base = 0;
                m.Skills.TasteID.Base = 0;
                m.Skills.Tinkering.Base = 0;
                m.Skills.Tracking.Base = 0;
                m.Skills.Veterinary.Base = 0;
                m.Skills.Wrestling.Base = 0;
                m.Skills.Chivalry.Base = 0;
                m.Skills.Necromancy.Base = 0;
                m.Skills.Bushido.Base = 0;
                m.Skills.Ninjitsu.Base = 0;
                m.Skills.Spellweaving.Base = 0;

                return false; //Changed this to false
            }
            else if ( m.Female == true )
            {
                m.Race = Race.Elf;
                m.Title = "the Ophidian";

                m.BodyMod = 85;
                m.HueMod = 0;

                m.BodyValue = 606;
                m.Hue = 443;
                m.HairItemID = 12237;
                m.HairHue = 18;
                m.FacialHairHue = 0;
                m.FacialHairItemID = 0;

                m.StatCap = 175;
                m.SkillsCap = 7000;
                m.Str = 10;
                m.Dex = 10;
                m.Int = 10;

                m.Skills.Alchemy.Base = 0;
                m.Skills.Anatomy.Base = 0;
                m.Skills.AnimalLore.Base = 0;
                m.Skills.AnimalTaming.Base = 0;
                m.Skills.Archery.Base = 0;
                m.Skills.ArmsLore.Base = 0;
                m.Skills.Begging.Base = 0;
                m.Skills.Blacksmith.Base = 0;
                m.Skills.Camping.Base = 0;
                m.Skills.Carpentry.Base = 0;
                m.Skills.Cartography.Base = 0;
                m.Skills.Cooking.Base = 0;
                m.Skills.DetectHidden.Base = 0;
                m.Skills.Discordance.Base = 0;
                m.Skills.EvalInt.Base = 0;
                m.Skills.Fishing.Base = 0;
                m.Skills.Fencing.Base = 0;
                m.Skills.Fletching.Base = 0;
                m.Skills.Focus.Base = 0;
                m.Skills.Forensics.Base = 0;
                m.Skills.Healing.Base = 0;
                m.Skills.Herding.Base = 0;
                m.Skills.Hiding.Base = 0;
                m.Skills.Inscribe.Base = 0;
                m.Skills.ItemID.Base = 0;
                m.Skills.Lockpicking.Base = 0;
                m.Skills.Lumberjacking.Base = 0;
                m.Skills.Macing.Base = 0;
                m.Skills.Magery.Base = 0;
                m.Skills.MagicResist.Base = 20;
                m.Skills.Meditation.Base = 0;
                m.Skills.Mining.Base = 0;
                m.Skills.Musicianship.Base = 0;
                m.Skills.Parry.Base = 0;
                m.Skills.Peacemaking.Base = 0;
                m.Skills.Poisoning.Base = 0;
                m.Skills.Provocation.Base = 0;
                m.Skills.RemoveTrap.Base = 0;
                m.Skills.Snooping.Base = 0;
                m.Skills.SpiritSpeak.Base = 0;
                m.Skills.Stealing.Base = 0;
                m.Skills.Stealth.Base = 0;
                m.Skills.Swords.Base = 0;
                m.Skills.Tactics.Base = 0;
                m.Skills.Tailoring.Base = 0;
                m.Skills.TasteID.Base = 0;
                m.Skills.Tinkering.Base = 0;
                m.Skills.Tracking.Base = 0;
                m.Skills.Veterinary.Base = 0;
                m.Skills.Wrestling.Base = 0;
                m.Skills.Chivalry.Base = 0;
                m.Skills.Necromancy.Base = 0;
                m.Skills.Bushido.Base = 0;
                m.Skills.Ninjitsu.Base = 0;
                m.Skills.Spellweaving.Base = 0;

                return false; //Changed this to false
            }
             else 
            { 
                return false; //Changed this to false
            } 
        } 
    } 
}
