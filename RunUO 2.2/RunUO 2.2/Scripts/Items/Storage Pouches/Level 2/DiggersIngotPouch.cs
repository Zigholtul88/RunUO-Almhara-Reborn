using System;
using System.Collections.Generic;
using Server.Items;

namespace Server.Items
{
        public sealed class DiggersIngotPouch : PouchOfIngotHolding
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
                public DiggersIngotPouch(): this( 1000 )
                {
                }

                [Constructable]
                public DiggersIngotPouch( int maxIngots ): base( maxIngots )
                {
                        Name = "Digger's Ingot Pouch - (1000 Ingot Capacity)";
                }

                public DiggersIngotPouch(Serial serial): base(serial)
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