using System;

namespace Server.Items
{
	[Flipable( 16369, 16370 )]
	public class GMRobeHoly : BaseOuterTorso
	{
		public override int InitMinHits{ get{ return 35; } }
		public override int InitMaxHits{ get{ return 50; } }

		[Constructable]
		public GMRobeHoly() : this( 0 )
		{
		}

		[Constructable]
		public GMRobeHoly( int hue ) : base( 16369, hue )
		{
                        Name = "GM Holy Robe";
			Weight = 5.0;
		}

		public GMRobeHoly( Serial serial ) : base( serial )
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

