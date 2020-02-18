using System;

namespace Server.Items
{
	[Flipable( 16369, 16370 )]
	public class GMRobeTrailfire : BaseOuterTorso
	{
		public override int InitMinHits{ get{ return 35; } }
		public override int InitMaxHits{ get{ return 50; } }

		[Constructable]
		public GMRobeTrailfire() : this( 0 )
		{
		}

		[Constructable]
		public GMRobeTrailfire( int hue ) : base( 16369, hue )
		{
                        Name = "GM Trailfire Robe";
			Weight = 5.0;
		}

		public GMRobeTrailfire( Serial serial ) : base( serial )
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

