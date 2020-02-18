using System;
using Server;

namespace Server.Items
{
	public class BogCreeperCarapace : Item
	{
		[Constructable]
		public BogCreeperCarapace() : this( 1 )
		{
		}

		[Constructable]
		public BogCreeperCarapace( int amount ) : base( 0x5720 )
		{
			Name = "Bog Creeper Carapace";
			Stackable = true;
			Amount = amount;

			Weight = 0.1;
			Hue = 768;
		}

		public override void OnDoubleClick( Mobile m )
		{
			m.SendMessage( "a bog creeper carapace that can be sold to butchers." );
			m.PlaySound( 397 );
                }

		public BogCreeperCarapace( Serial serial ) : base( serial )
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