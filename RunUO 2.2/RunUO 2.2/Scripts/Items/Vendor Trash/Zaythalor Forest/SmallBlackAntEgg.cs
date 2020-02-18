using System;
using Server;

namespace Server.Items
{
	public class SmallBlackAntEgg : Item
	{
		[Constructable]
		public SmallBlackAntEgg() : base( 0x41BD )
		{
                  Name = "Small Black Ant Egg";
			Weight = 1.0;
                  Hue = 2051;
		}

		public override void OnDoubleClick( Mobile m )
		{
			m.SendMessage( "a small ant egg that can be sold to butchers." );
			m.PlaySound( 846 );
		}

		public SmallBlackAntEgg( Serial serial ) : base( serial )
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