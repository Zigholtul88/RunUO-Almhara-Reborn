using System;
using Server;

namespace Server.Items
{
	public class RoseOfQuagmire : Item
	{
		[Constructable]
		public RoseOfQuagmire() : base( 10299 )
		{
                  Name = "Rose of Quagmire";
			Weight = 0.1;
                  Hue = 2536;
		}

		public override void OnDoubleClick( Mobile m )
		{
			m.SendMessage( "the rose from a quagmire that can be sold to butchers." );
			m.PlaySound( 0x018 );
		}

		public RoseOfQuagmire( Serial serial ) : base( serial )
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