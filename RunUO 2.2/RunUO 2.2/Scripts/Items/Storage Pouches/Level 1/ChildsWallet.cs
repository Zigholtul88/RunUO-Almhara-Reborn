using System;
using System.Collections.Generic;
using Server.Items;

namespace Server.Items
{
        public sealed class ChildsWallet : PouchOfGoldStorage
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
                public ChildsWallet(): this( 5000 )
                {
                }

                [Constructable]
                public ChildsWallet( int maxGolds ): base( maxGolds )
                {
                        Name = "Child's Wallet - (5000 Gold Capacity)";
			LootType = LootType.Blessed;
                }

                public ChildsWallet(Serial serial): base(serial)
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