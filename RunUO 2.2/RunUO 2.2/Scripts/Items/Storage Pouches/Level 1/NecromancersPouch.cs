using System;
using System.Collections.Generic;
using Server.Items;

namespace Server.Items
{
        public sealed class NecromancersPouch : PouchOfReagentHolding
        {
                public override Type[] m_AllowedReagents
                {
                       get
                       {
                              return new Type[]
                              {
                                    typeof( BatWing ), typeof( DaemonBlood ), typeof( GraveDust ), typeof( NoxCrystal ), typeof( PigIron )
                              };
                       }
                }

                [Constructable]
                public NecromancersPouch(): this( 50 )
                {
                }

                [Constructable]
                public NecromancersPouch( int maxReagents ): base( maxReagents )
                {
                        Name = "Necromancer's Pouch - (50 Reagent Capacity)";
			LootType = LootType.Blessed;
                }

                public NecromancersPouch(Serial serial): base(serial)
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