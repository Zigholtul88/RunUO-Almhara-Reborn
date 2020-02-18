using System;
using Server;

namespace Server.Items
{
	public class HarpyTalon : Item
	{
		[Constructable]
		public HarpyTalon() : this( 1 )
		{
		}

		[Constructable]
		public HarpyTalon( int amount ) : base( 0x2DB8 )
		{
                        Name = "Harpy Talon";
			Stackable = true;
			Amount = amount;

			Weight = 0.1;
                        Hue = 1005;
		}

		public override void OnDoubleClick( Mobile m )
		{
			m.SendMessage( "a harpy talon that can be sold to butchers." );
			m.PlaySound( 402 );
		}

		public HarpyTalon( Serial serial ) : base( serial )
		{
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );

			writer.Write( (int) 0 );
		}

		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader );

			int version = reader.ReadInt();
		}
	}
}