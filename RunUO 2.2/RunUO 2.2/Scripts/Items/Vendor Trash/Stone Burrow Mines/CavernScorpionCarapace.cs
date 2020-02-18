using System;
using Server;

namespace Server.Items
{
	public class CavernScorpionCarapace : Item
	{
		[Constructable]
		public CavernScorpionCarapace() : this( 1 )
		{
		}

		[Constructable]
		public CavernScorpionCarapace( int amount ) : base( 0x5720 )
		{
			Name = "Cavern Scorpion Carapace";
			Stackable = true;
			Amount = amount;

			Weight = 0.1;
			Hue = 2103;
		}

		public override void OnDoubleClick( Mobile m )
		{
			m.SendMessage( "a cavern scorpion carapace that can be sold to butchers." );
			m.PlaySound( 397 );
            }

		public CavernScorpionCarapace( Serial serial ) : base( serial )
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