using System;
using System.Collections.Generic;
using Server.Items;

namespace Server.Items
{
        public sealed class TeensWallet : PouchOfGoldStorage
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
                public TeensWallet(): this( 10000 )
                {
                }

                [Constructable]
                public TeensWallet( int maxGolds ): base( maxGolds )
                {
                        Name = "Teen's Wallet - (10000 Gold Capacity)";
			LootType = LootType.Blessed;
                }

                public TeensWallet(Serial serial): base(serial)
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