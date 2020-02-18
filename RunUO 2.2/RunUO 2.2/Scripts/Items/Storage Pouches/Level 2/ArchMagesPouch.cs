using System;
using System.Collections.Generic;
using Server.Items;

namespace Server.Items
{
        public sealed class ArchMagesPouch : PouchOfReagentHolding
        {
                public override Type[] m_AllowedReagents
                {
                        get
                        {
                                return new Type[]
                                {
                                        typeof( Bloodmoss ), typeof( BlackPearl ), typeof( Garlic ), typeof( Ginseng ), typeof( MandrakeRoot ),
                                        typeof( SulfurousAsh ), typeof( Nightshade ), typeof( SpidersSilk )
                                };
                        }
                }

                [Constructable]
                public ArchMagesPouch(): this( 500 )
                {
                }

                [Constructable]
                public ArchMagesPouch( int maxReagents ): base( maxReagents )
                {
                        Name = "Arch Mage's Pouch - (500 Reagent Capacity)";
                }

                public ArchMagesPouch(Serial serial): base(serial)
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