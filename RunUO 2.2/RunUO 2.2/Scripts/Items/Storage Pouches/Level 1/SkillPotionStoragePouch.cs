using System;
using System.Collections.Generic;
using Server.Items;

namespace Server.Items
{
        public sealed class SkillPotionStoragePouch : PouchOfSkillPotionStorage
        {
                public override Type[] m_AllowedSkillPotions
                {
                        get
                        {
                                return new Type[]
                                {
                                        typeof( SkilledPotionOfArchery ), 
                                        typeof( SkilledPotionOfFencing ), 
                                        typeof( SkilledPotionOfMaceFighting ), 
                                        typeof( SkilledPotionOfMagery ),
                                        typeof( SkilledPotionOfParry ), 
                                        typeof( SkilledPotionOfSwordsmanship ), 
                                        typeof( SkilledPotionOfWrestling ),
                                        typeof( SkilledPotionOfAlchemy ),
                                        typeof( SkilledPotionOfBlacksmithy ), 
                                        typeof( SkilledPotionOfCarpentry ), 
                                        typeof( SkilledPotionOfCooking ), 
                                        typeof( SkilledPotionOfFletching ), 
                                        typeof( SkilledPotionOfInscription ),
                                        typeof( SkilledPotionOfTailoring ), 
                                        typeof( SkilledPotionOfTinkering ), 
                                        typeof( SkilledPotionOfAnimalTaming ),
                                        typeof( SkilledPotionOfDiscordance ),
                                        typeof( SkilledPotionOfFishing ), 
                                        typeof( SkilledPotionOfHerding ), 
                                        typeof( SkilledPotionOfHiding ), 
                                        typeof( SkilledPotionOfLumberjacking ), 
                                        typeof( SkilledPotionOfMagicResist ),
                                        typeof( SkilledPotionOfMining ), 
                                        typeof( SkilledPotionOfPeacemaking ), 
                                        typeof( SkilledPotionOfPoisoning ),
                                        typeof( SkilledPotionOfProvocation ),
                                        typeof( SkilledPotionOfSnooping ), 
                                        typeof( SkilledPotionOfStealing ), 
                                        typeof( SkilledPotionOfVeterinary ), 
                                        typeof( AdeptPotionOfArchery ), 
                                        typeof( AdeptPotionOfFencing ), 
                                        typeof( AdeptPotionOfMaceFighting ), 
                                        typeof( AdeptPotionOfMagery ),
                                        typeof( AdeptPotionOfParry ), 
                                        typeof( AdeptPotionOfSwordsmanship ), 
                                        typeof( AdeptPotionOfWrestling ),
                                        typeof( AdeptPotionOfAlchemy ),
                                        typeof( AdeptPotionOfBlacksmithy ), 
                                        typeof( AdeptPotionOfCarpentry ), 
                                        typeof( AdeptPotionOfCooking ), 
                                        typeof( AdeptPotionOfFletching ), 
                                        typeof( AdeptPotionOfInscription ),
                                        typeof( AdeptPotionOfTailoring ), 
                                        typeof( AdeptPotionOfTinkering ), 
                                        typeof( AdeptPotionOfAnimalTaming ),
                                        typeof( AdeptPotionOfDiscordance ),
                                        typeof( AdeptPotionOfFishing ), 
                                        typeof( AdeptPotionOfHerding ), 
                                        typeof( AdeptPotionOfHiding ), 
                                        typeof( AdeptPotionOfLumberjacking ), 
                                        typeof( AdeptPotionOfMagicResist ),
                                        typeof( AdeptPotionOfMining ), 
                                        typeof( AdeptPotionOfPeacemaking ), 
                                        typeof( AdeptPotionOfPoisoning ),
                                        typeof( AdeptPotionOfProvocation ),
                                        typeof( AdeptPotionOfSnooping ), 
                                        typeof( AdeptPotionOfStealing ), 
                                        typeof( AdeptPotionOfVeterinary ), 
                                        typeof( NovicePotionOfArchery ), 
                                        typeof( NovicePotionOfFencing ), 
                                        typeof( NovicePotionOfMaceFighting ), 
                                        typeof( NovicePotionOfMagery ),
                                        typeof( NovicePotionOfParry ), 
                                        typeof( NovicePotionOfSwordsmanship ), 
                                        typeof( NovicePotionOfWrestling ),
                                        typeof( NovicePotionOfAlchemy ),
                                        typeof( NovicePotionOfBlacksmithy ), 
                                        typeof( NovicePotionOfCarpentry ), 
                                        typeof( NovicePotionOfCooking ), 
                                        typeof( NovicePotionOfFletching ), 
                                        typeof( NovicePotionOfInscription ),
                                        typeof( NovicePotionOfTailoring ), 
                                        typeof( NovicePotionOfTinkering ), 
                                        typeof( NovicePotionOfAnimalTaming ),
                                        typeof( NovicePotionOfDiscordance ),
                                        typeof( NovicePotionOfFishing ), 
                                        typeof( NovicePotionOfHerding ), 
                                        typeof( NovicePotionOfHiding ), 
                                        typeof( NovicePotionOfLumberjacking ), 
                                        typeof( NovicePotionOfMagicResist ),
                                        typeof( NovicePotionOfMining ), 
                                        typeof( NovicePotionOfPeacemaking ), 
                                        typeof( NovicePotionOfPoisoning ),
                                        typeof( NovicePotionOfProvocation ),
                                        typeof( NovicePotionOfSnooping ), 
                                        typeof( NovicePotionOfStealing ), 
                                        typeof( NovicePotionOfVeterinary )
                                };
                        }
                }

                [Constructable]
                public SkillPotionStoragePouch(): this( 1 )
                {
                }

                [Constructable]
                public SkillPotionStoragePouch( int maxSkillPotions ): base( maxSkillPotions )
                {
                        Name = "Skill Potion Storage Pouch - (1 Skill Type Potion Each)";
                }

                public SkillPotionStoragePouch(Serial serial): base(serial)
                {
                }

                public override void Serialize(GenericWriter writer)
                {
                        base.Serialize(writer);
                        writer.WriteEncodedInt(0); // version
                }

                public override void Deserialize(GenericReader reader)
                {
                        base.Deserialize(reader);
                        int version = reader.ReadEncodedInt();
                }
        }
}