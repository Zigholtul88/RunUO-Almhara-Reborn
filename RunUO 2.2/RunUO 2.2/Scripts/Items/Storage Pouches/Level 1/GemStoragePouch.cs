using System;
using System.Collections.Generic;
using Server.Items;

namespace Server.Items
{
        public sealed class GemStoragePouch : PouchOfGemStorage
        {
                public override Type[] m_AllowedGems
                {
                        get
                        {
                                return new Type[]
                                {
                                        typeof( Agate ), 
                                        typeof( Beryl ), 
                                        typeof( ChromeDiopside ), 
                                        typeof( FireOpal ),
                                        typeof( MoonstoneCustom ), 
                                        typeof( Onyx ), 
                                        typeof( Opal ),
                                        typeof( Pearl ),
                                        typeof( TurquoiseCustom ), 
                                        typeof( Bloodstone ), 
                                        typeof( Citrine ), 
                                        typeof( Demantoid ), 
                                        typeof( Jasper ),
                                        typeof( Lolite ), 
                                        typeof( Lupis ), 
                                        typeof( Peridot ),
                                        typeof( Tsavorite ),
                                        typeof( Zircon ), 
                                        typeof( Amber ), 
                                        typeof( Amethyst ), 
                                        typeof( Andalusite ), 
                                        typeof( Chrysoberyl ),
                                        typeof( Garnet ), 
                                        typeof( Jade ), 
                                        typeof( Mandarin ),
                                        typeof( Morganite ),
                                        typeof( Paraiba ), 
                                        typeof( TigerEye ), 
                                        typeof( Tourmaline ), 
                                        typeof( Alexandrite ), 
                                        typeof( Ametrine ),
                                        typeof( Kunzite ), 
                                        typeof( Ruby ), 
                                        typeof( Sapphire ),
                                        typeof( Tanzanite ),
                                        typeof( Topaz ), 
                                        typeof( Zultanite ), 
                                        typeof( Diamond ), 
                                        typeof( Emerald ), 
                                        typeof( PinkQuartz ),
                                        typeof( StarSapphire )
                                };
                        }
                }

                [Constructable]
                public GemStoragePouch(): this( 20 )
                {
                }

                [Constructable]
                public GemStoragePouch( int maxGems ): base( maxGems )
                {
                        Name = "Gem Storage Pouch - (20 Gems Each)";
			LootType = LootType.Blessed;
                }

                public GemStoragePouch(Serial serial): base(serial)
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