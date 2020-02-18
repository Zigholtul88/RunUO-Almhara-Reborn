using System;

namespace Server.Items
{
	[FlipableAttribute( 8967, 8968 )]
	public class FurBoots : BaseShoes
	{
		[Constructable]
		public FurBoots() : this( 0 )
		{
		}

		[Constructable]
		public FurBoots( int hue ) : base( 8967, hue )
		{
			Weight = 3.0;
		}

		public FurBoots( Serial serial ) : base( serial )
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
