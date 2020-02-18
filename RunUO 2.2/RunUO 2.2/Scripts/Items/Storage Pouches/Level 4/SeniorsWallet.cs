using System;
using System.Collections.Generic;
using Server.Items;

namespace Server.Items
{
        public sealed class SeniorsWallet : PouchOfGoldStorage
        {
                public override Type[] m_AllowedGolds
                {
                        get
                        {
                                return new Type[]
                                {
                                        typeof( Gold )
                                };
                        }
                }

                [Constructable]
                public SeniorsWallet(): this( 20000 )
                {
                }

                [Constructable]
                public SeniorsWallet( int maxGolds ): base( maxGolds )
                {
                        Name = "Senior's Wallet - (20000 Gold Capacity)";
			LootType = LootType.Blessed;
                }

                public SeniorsWallet(Serial serial): base(serial)
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