using System;
using Server;

namespace Server.Items
{
	public class SandCrabCarapace: Item
	{
		[Constructable]
		public SandCrabCarapace() : this( 1 )
		{
		}

		[Constructable]
		public SandCrabCarapace( int amount ) : base( 0x5720 )
		{
			Name = "Sand Crab Carapace";
			Stackable = true;
			Amount = amount;

			Weight = 0.1;
			Hue = 1864;
		}

		public override void OnDoubleClick( Mobile m )
		{
			m.SendMessage( "a sand crab carapace that can be sold to butchers." );
			m.PlaySound( 1561 );
                }

		public SandCrabCarapace( Serial serial ) : base( serial )
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