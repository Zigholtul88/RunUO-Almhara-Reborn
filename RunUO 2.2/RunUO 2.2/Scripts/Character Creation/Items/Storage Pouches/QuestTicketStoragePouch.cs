using System;
using System.Collections.Generic;
using Server.Items;

namespace Server.Items
{
        public sealed class QuestTicketStoragePouch : PouchOfTicketStorage
        {
                public override Type[] m_AllowedTickets
                {
                        get
                        {
                                return new Type[]
                                {
                                        typeof( AFlagForHammerhillTicket ), 
                                        typeof( BaroqueORamaTicket ), 
                                        typeof( BirdemicTicket ), 
                                        typeof( EggCollectorTicket ),
                                        typeof( FeeshTendeesTicket ), 
                                        typeof( HaldursBaitTicket ), 
                                        typeof( InsecticideTicket ),
                                        typeof( LetterDeliveryTicket ),
                                        typeof( StaffOfFlyingMonkeysTicket ), 
                                        typeof( StarLakeTicket ), 
                                        typeof( StolenNecklaceTicket ), 
                                        typeof( ThinningHerdTicket ),
                                        typeof( ThisNotHalloweenTicket ), 
                                        typeof( ThoseBlueBastardsTicket ), 
                                        typeof( WitchApprenticeTicket ),
                                        typeof( BrightClubTicket ),
                                        typeof( ChampionHunt1Ticket ), 
                                        typeof( EnchantedShovelTicket ), 
                                        typeof( JadeJungleJemsTicket ), 
                                        typeof( KissOfTheSerpentMistressTicket ),
                                        typeof( MolassesGreedTicket ), 
                                        typeof( SpiderwickChroniclesTicket ), 
                                        typeof( SweetChildTicket ),
                                        typeof( TreasureOfTheSandsTicket )
                                };
                        }
                }

                [Constructable]
                public QuestTicketStoragePouch(): this( 1 )
                {
                }

                [Constructable]
                public QuestTicketStoragePouch( int maxTickets ): base( maxTickets )
                {
                        Name = "Quest Ticket Storage Pouch - (1 Ticket Each)";
                }

                public QuestTicketStoragePouch(Serial serial): base(serial)
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