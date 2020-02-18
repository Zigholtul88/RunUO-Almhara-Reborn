using System;
using System.Collections.Generic;
using Server.Items;

namespace Server.Items
{
        public sealed class MagesPouch : PouchOfReagentHolding
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
                public MagesPouch(): this( 50 )
                {
                }

                [Constructable]
                public MagesPouch( int maxReagents ): base( maxReagents )
                {
                        Name = "Mage's Pouch - (50 Reagent Capacity)";
			LootType = LootType.Blessed;
                }

                public MagesPouch(Serial serial): base(serial)
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