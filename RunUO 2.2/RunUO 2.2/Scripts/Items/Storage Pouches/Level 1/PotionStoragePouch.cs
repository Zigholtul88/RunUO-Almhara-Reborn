using System;
using System.Collections.Generic;
using Server.Items;

namespace Server.Items
{
        public sealed class PotionStoragePouch : PouchOfPotionStorage
        {
                public override Type[] m_AllowedPotions
                {
                        get
                        {
                                return new Type[]
                                {
                                        typeof( GreaterAgilityPotion ), 
                                        typeof( GreaterMindPotion ), 
                                        typeof( GreaterStrengthPotion ), 
                                        typeof( GreaterCurePotion ),
                                        typeof( GreaterHealPotion ), 
                                        typeof( GreaterManaPotion ), 
                                        typeof( GreaterExplosionPotion ),
                                        typeof( GreaterLightningPotion ),
                                        typeof( GreaterPoisonPotion ),
                                        typeof( GreaterShatterPotion ), 
                                        typeof( GreaterToxicPotion ),
                                        typeof( CurePotion ), 
                                        typeof( HealPotion ), 
                                        typeof( ManaPotion ), 
                                        typeof( ExplosionPotion ),
                                        typeof( LightningPotion ), 
                                        typeof( PoisonPotion ),
                                        typeof( ShatterPotion ), 
                                        typeof( ToxicPotion ),
                                        typeof( AgilityPotion ),
                                        typeof( MindPotion ),
                                        typeof( StrengthPotion ), 
                                        typeof( LesserHealPotion ), 
                                        typeof( LesserManaPotion ), 
                                        typeof( LesserCurePotion ), 
                                        typeof( LesserExplosionPotion ),
                                        typeof( LesserShatterPotion ), 
                                        typeof( LesserLightningPotion ), 
                                        typeof( LesserPoisonPotion ),
                                        typeof( LesserToxicPotion ),
                                        typeof( NightSightPotion ),
                                        typeof( RefreshPotion )
                                };
                        }
                }

                [Constructable]
                public PotionStoragePouch(): this( 20 )
                {
                }

                [Constructable]
                public PotionStoragePouch( int maxPotions ): base( maxPotions )
                {
                        Name = "Potion Storage Pouch - (20 Standard Potions Each)";
			LootType = LootType.Blessed;
                }

                public PotionStoragePouch(Serial serial): base(serial)
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