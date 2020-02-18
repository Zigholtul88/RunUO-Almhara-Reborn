using System;
using Server;

namespace Server.Items
{
	public class GreenAllosaurTooth : Item
	{
		[Constructable]
		public GreenAllosaurTooth() : this( 1 )
		{
		}

		[Constructable]
		public GreenAllosaurTooth( int amount ) : base( 0x5747 )
		{
                        Name = "Green Allosaur Tooth";
			Weight = 5.0;
			Hue = 67;
		}

		public override void OnDoubleClick( Mobile m )
		{
			m.SendMessage( "the tooth from a green allosaur that can be sold to butchers." );
			m.PlaySound( 651 );
		}

		public GreenAllosaurTooth( Serial serial ) : base( serial )
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