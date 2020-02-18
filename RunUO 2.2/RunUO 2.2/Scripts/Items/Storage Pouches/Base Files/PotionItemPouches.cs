using System;
using System.Collections.Generic;
using Server.Items;

namespace Server.Items
{
        public abstract class PouchOfPotionStorage : BackpackOfReduction
        {
                private int m_MaxPotions;
                public abstract Type[] m_AllowedPotions { get; }

                [CommandProperty(AccessLevel.GameMaster)]
                public int MaxPotions { get { return m_MaxPotions; } set { m_MaxPotions = value; } }

                private int RandomBagHue { get { return Utility.RandomList( 1230, 1303, 1420, 1619, 1640, 2001 ); } }

                public PouchOfPotionStorage( int maxPotions ): base( 100 )
                {
                        ItemID = 3705;
                        Hue = RandomBagHue;
                        m_MaxPotions = maxPotions;
                }

                private bool CheckDrop( Mobile from, Item dropped )
                {
                        bool valid = false;
                        for (int i = 0; i < m_AllowedPotions.Length; i++)
                        {
                                if ( dropped.GetType() == m_AllowedPotions[i])
                                {
                                    valid = true;
                                    break;
                                }
                        }
                        if ( valid )
                        {
                                int curAmount = 0;
                                List<Item> items = this.Items;

                                foreach ( Item item in items )
                                {
                                    if ( item.GetType() == dropped.GetType() )
                                        curAmount += item.Amount;
                                }

                                if ( ( curAmount + dropped.Amount ) > m_MaxPotions )
                                {
                                    from.SendMessage("That pouch cannot hold anymore of that type of potion!");
                                    return false;
                                }
                                else return true;
                        }
                        else
                        {
                            from.SendMessage("You can only place potions in this pouch.");
                            return false;
                        }
                }

                public override bool OnDragDrop( Mobile from, Item dropped )
                {
                        if ( CheckDrop( from, dropped ) )
                            return base.OnDragDrop( from, dropped );
                        else
                            return false;
                }

                public override bool OnDragDropInto( Mobile from, Item item, Point3D p )
                {
                        if ( CheckDrop( from, item ) )
                            return base.OnDragDropInto( from, item, p );
                        else
                            return false;
                }

                public override bool OnStackAttempt( Mobile from, Item stack, Item dropped )
                {
                        if ( CheckDrop( from, dropped ) )
                            return base.OnStackAttempt( from, stack, dropped );
                        else
                            return false;
                }

                public PouchOfPotionStorage(Serial serial): base(serial)
                {
                }

                public override void Serialize(GenericWriter writer)
                {
                        base.Serialize(writer);
                        writer.WriteEncodedInt(0); // version
                        writer.WriteEncodedInt(m_MaxPotions);
                }

                public override void Deserialize(GenericReader reader)
                {
                        base.Deserialize(reader);
                        int version = reader.ReadEncodedInt();

                        switch (version)
                        {
                            case 0:
                                  m_MaxPotions = reader.ReadEncodedInt();
                                  break;
                        }
                }
        }
}