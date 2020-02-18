using System;
using Server;

namespace Server.Items
{
	public class AdamantoiseEgg : Item
	{
		[Constructable]
		public AdamantoiseEgg() : base( 0x366D )
		{
                        Name = "Adamantoise Egg";
			Weight = 12.0;
                        Hue = 2119;
		}

		public override void OnDoubleClick( Mobile m )
		{
			m.SendMessage( "an adamantoise egg that can be sold to butchers." );
			m.PlaySound( 224 );
		}

		public AdamantoiseEgg( Serial serial ) : base( serial )
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