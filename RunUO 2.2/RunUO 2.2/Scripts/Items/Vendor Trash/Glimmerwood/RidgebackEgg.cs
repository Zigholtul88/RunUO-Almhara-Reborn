using System;
using Server;

namespace Server.Items
{
	public class RidgebackEgg : Item
	{
		[Constructable]
		public RidgebackEgg() : base( 0x41BE )
		{
                        Name = "Ridgeback Egg";
			Weight = 1.0;
			Hue = 1266;
		}

		public override void OnDoubleClick( Mobile m )
		{
			m.SendMessage( "a slightly uncommon ridgeback egg that can be sold to butchers." );
			m.PlaySound( 0x3F3 );
		}

		public RidgebackEgg( Serial serial ) : base( serial )
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