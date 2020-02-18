using System;
using System.Collections.Generic;
using Server.Items;

namespace Server.Items
{
        public sealed class AdultsWallet : PouchOfGoldStorage
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
                public AdultsWallet(): this( 15000 )
                {
                }

                [Constructable]
                public AdultsWallet( int maxGolds ): base( maxGolds )
                {
                        Name = "Adult's Wallet - (15000 Gold Capacity)";
			LootType = LootType.Blessed;
                }

                public AdultsWallet(Serial serial): base(serial)
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