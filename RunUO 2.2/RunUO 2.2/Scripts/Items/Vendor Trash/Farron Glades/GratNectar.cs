using System;
using Server;

namespace Server.Items
{
	public class GratNectar : Item
	{
		[Constructable]
		public GratNectar() : this( 1 )
		{
		}

		[Constructable]
		public GratNectar( int amount ) : base( 0x21FE )
		{
			Name = "Grat Nectar";
			Stackable = true;
			Amount = amount;

			Weight = 0.1;
                        Hue = 1276;
		}

		public override void OnDoubleClick( Mobile m )
		{
			m.SendMessage( "nectar from a grat that can be sold to butchers." );
			m.PlaySound( 0x017 );
		}

		public GratNectar( Serial serial ) : base( serial )
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