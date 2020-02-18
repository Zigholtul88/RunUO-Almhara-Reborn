using System;
using Server;

namespace Server.Items
{
	public class GryphonBeak : Item
	{
		[Constructable]
		public GryphonBeak() : this( 1 )
		{
		}

		[Constructable]
		public GryphonBeak( int amount ) : base( 0x5747 )
		{
                        Name = "Gryphon Beak";
			Weight = 1.0;
                        Hue = 0x457;
		}

		public override void OnDoubleClick( Mobile m )
		{
			m.SendMessage( "the beak from a gryphon that can be sold to butchers." );
			m.PlaySound( 0x2EE );
		}

		public GryphonBeak( Serial serial ) : base( serial )
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