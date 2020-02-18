using System;
using Server;
using Server.Items;

namespace Server.Items
{
	[FlipableAttribute( 15900, 15901 )]
	public class LeatherShirt : BaseShirt
	{
		public override int InitMinHits{ get{ return 45; } }
		public override int InitMaxHits{ get{ return 55; } }

		[Constructable]
		public LeatherShirt() : this( 0 )
		{
		}

		[Constructable]
		public LeatherShirt( int hue ) : base( 15900, hue )
		{
                        Name = "Leather Shirt";
			Weight = 2.0;
		}

		public LeatherShirt( Serial serial ) : base( serial )
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