using System;
using Server;

namespace Server.Items
{
	public class BronzeWeevilEgg : Item
	{
		[Constructable]
		public BronzeWeevilEgg() : base( 0x41BD )
		{
                        Name = "Bronze Weevil Egg";
			Weight = 1.0;
                        Hue = 1126;
		}

		public override void OnDoubleClick( Mobile m )
		{
			m.SendMessage( "a small bronze weevil egg that is used for the Resident Weevil quest." );
		}

		public BronzeWeevilEgg( Serial serial ) : base( serial )
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