using System;
using Server;

namespace Server.Items
{
	public class TreasureOfTheSandsTicket : Item
	{
		public override string DefaultName
		{
			get { return "Treasure Of The Sands Ticket"; }
		}

		[Constructable]
		public TreasureOfTheSandsTicket() : base( 0x14EE )
		{
                        Hue = 33;
			Weight = 0.0;
			LootType = LootType.Blessed;
		}

		public override void OnDoubleClick( Mobile m )
		{
			m.SendMessage( "1 of 24 tickets from the Zaythalor/Alytharr Tavern bulletin needed for the quest ticket connection box." );
                }

		public TreasureOfTheSandsTicket( Serial serial ) : base( serial )
		{
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );

			writer.Write( (int) 0 ); // version
		}

		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader );

			int version = reader.ReadInt();
		}
       }
}
