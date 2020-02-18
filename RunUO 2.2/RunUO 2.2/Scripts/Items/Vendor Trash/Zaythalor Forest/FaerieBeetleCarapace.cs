using System;
using Server;

namespace Server.Items
{
	public class FaerieBeetleCarapace : Item
	{
		[Constructable]
		public FaerieBeetleCarapace() : this( 1 )
		{
		}

		[Constructable]
		public FaerieBeetleCarapace( int amount ) : base( 0x5720 )
		{
			Name = "Faerie Beetle Carapace";
			Stackable = true;
			Amount = amount;

			Weight = 0.1;
			Hue = 181;
		}

		public override void OnDoubleClick( Mobile m )
		{
			m.SendMessage( "a fairly magical carapace that can be sold to butchers." );
			m.PlaySound( 0x21D );
            }

		public FaerieBeetleCarapace( Serial serial ) : base( serial )
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