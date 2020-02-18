using System;
using Server;

namespace Server.Items
{
	[FlipableAttribute( 0x2B68, 0x315F )]
	public class WoodlandBelt : BaseWaist
	{
		public override int InitMinHits{ get{ return 11; } }
		public override int InitMaxHits{ get{ return 40; } }

		[Constructable]
		public WoodlandBelt() : this( 0 )
		{
		}

		[Constructable]
		public WoodlandBelt( int hue ) : base( 0x2B68, hue )
		{
			Weight = 4.0;
		}

		public WoodlandBelt( Serial serial ) : base( serial )
		{
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );

			writer.WriteEncodedInt( 0 ); // version
		}

		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader );

			int version = reader.ReadEncodedInt();
		}
	}
}