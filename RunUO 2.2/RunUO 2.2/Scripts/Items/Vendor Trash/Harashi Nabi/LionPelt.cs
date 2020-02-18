using System;
using Server;

namespace Server.Items
{
	public class LionPelt : Item
	{
		[Constructable]
		public LionPelt() : base( 0x11F4 )
		{
                        Name = "Lion Pelt";
			Weight = 0.5;
		}

		public override void OnDoubleClick( Mobile m )
		{
			m.SendMessage( "the pelt of a lion that can be sold to butchers." );
			m.PlaySound( 0x3F1 );
		}

		public LionPelt( Serial serial ) : base( serial )
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

