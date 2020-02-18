using System;
using Server;

namespace Server.Items
{
        [FlipableAttribute(16650, 16651)]
	public class IguanaCoveBossKey : Item
	{
		[Constructable]
		public IguanaCoveBossKey() : base( 16651 )
		{
                        Name = "Iguana Cove Boss Arena Key";
                        Hue = 33;
		}

		public override void OnDoubleClick( Mobile m )
		{
			m.SendMessage( "the key needed to pass through the fog gates." );
		}

		public IguanaCoveBossKey( Serial serial ) : base( serial )
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