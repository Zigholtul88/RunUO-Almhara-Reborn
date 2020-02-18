using System;

namespace Server.Items
{
	[Flipable( 0x1fa1, 0x1fa2 )]
	public class Tunic : BaseMiddleTorso
	{
		public override int InitMinHits{ get{ return 21; } }
		public override int InitMaxHits{ get{ return 30; } }

		[Constructable]
		public Tunic() : this( 0 )
		{
		}

		[Constructable]
		public Tunic( int hue ) : base( 0x1FA1, hue )
		{
			Weight = 5.0;
		}

		public Tunic( Serial serial ) : base( serial )
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

