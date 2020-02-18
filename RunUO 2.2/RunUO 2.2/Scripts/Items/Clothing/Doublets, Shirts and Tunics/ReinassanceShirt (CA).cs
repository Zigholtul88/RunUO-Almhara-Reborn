using System;
using Server;
using Server.Items;

namespace Server.Items
{
	[FlipableAttribute( 15842, 15843 )]
	public class ReinassanceShirt : BaseShirt
	{
		public override int InitMinHits{ get{ return 21; } }
		public override int InitMaxHits{ get{ return 30; } }

		[Constructable]
		public ReinassanceShirt() : this( 0 )
		{
		}

		[Constructable]
		public ReinassanceShirt( int hue ) : base( 15842, hue )
		{
                        Name = "Reinassance Shirt";
			Weight = 2.0;
		}

		public ReinassanceShirt( Serial serial ) : base( serial )
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