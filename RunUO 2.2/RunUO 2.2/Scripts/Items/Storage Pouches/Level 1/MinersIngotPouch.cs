using System;
using System.Collections.Generic;
using Server.Items;

namespace Server.Items
{
        public sealed class MinersIngotPouch : PouchOfIngotHolding
        {
                public override Type[] m_AllowedIngots
                {
                        get
                        {
                                return new Type[]
                                {
                                        typeof( IronIngot ), typeof( DullCopperIngot ), typeof( ShadowIronIngot ), typeof( CopperIngot ), typeof( BronzeIngot ),
                                        typeof( GoldIngot ), typeof( AgapiteIngot ), typeof( VeriteIngot ), typeof( ValoriteIngot )
                                };
                        }
                }

                [Constructable]
                public MinersIngotPouch(): this( 300 )
                {
                }

                [Constructable]
                public MinersIngotPouch( int maxIngots ): base( maxIngots )
                {
                        Name = "Miner's Ingot Pouch - (300 Ingot Capacity)";
			LootType = LootType.Blessed;
                }

                public MinersIngotPouch(Serial serial): base(serial)
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