using System;
using Server;

namespace Server.Items
{
	public class GrobusFur : Item
	{
		[Constructable]
		public GrobusFur() : base( 0x11F4 )
		{
                        Name = "Grobu's Fur";
			Hue = 0x455;
		}

		public override void OnDoubleClick( Mobile m )
		{
			m.SendMessage( "the fur of Grobu that can be sold to butchers." );
			m.PlaySound( 0xA3 );
		}

		public GrobusFur( Serial serial ) : base( serial )
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

