using System;
using Server;

namespace Server.Items
{
	public class AdamantoiseCarapace : Item
	{
		[Constructable]
		public AdamantoiseCarapace() : this( 1 )
		{
		}

		[Constructable]
		public AdamantoiseCarapace( int amount ) : base( 0x5720 )
		{
			Name = "Adamantoise Carapace";
			Stackable = true;
			Amount = amount;

			Weight = 25.0;
			Hue = 2119;
		}

		public override void OnDoubleClick( Mobile m )
		{
			m.SendMessage( "an adamantoise carapace that can be sold to butchers." );
			m.PlaySound( 224 );
                }

		public AdamantoiseCarapace( Serial serial ) : base( serial )
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