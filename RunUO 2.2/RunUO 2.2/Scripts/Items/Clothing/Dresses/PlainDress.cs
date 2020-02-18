using System;

namespace Server.Items
{
	[Flipable( 0x1F01, 0x1F02 )]
	public class PlainDress : BaseOuterTorso
	{
		public override int InitMinHits{ get{ return 21; } }
		public override int InitMaxHits{ get{ return 30; } }

		[Constructable]
		public PlainDress() : this( 0 )
		{
		}

		[Constructable]
		public PlainDress( int hue ) : base( 0x1F02, hue )
		{
			Weight = 2.0;
		}

		public PlainDress( Serial serial ) : base( serial )
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
