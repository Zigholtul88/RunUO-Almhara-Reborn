using System;
using Server;

namespace Server.Items
{
	public class BeachBeetleSerum: Item
	{
		[Constructable]
		public BeachBeetleSerum() : this( 1 )
		{
		}

		[Constructable]
		public BeachBeetleSerum( int amount ) : base( 0x5720 )
		{
			Name = "Beach Beetle Serum";
			Stackable = true;
			Amount = amount;

			Weight = 0.1;
			Hue = 251;
		}

		public override void OnDoubleClick( Mobile m )
		{
			m.SendMessage( "serum that can be sold to butchers." );
			m.PlaySound( 0x21D );
                }

		public BeachBeetleSerum( Serial serial ) : base( serial )
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