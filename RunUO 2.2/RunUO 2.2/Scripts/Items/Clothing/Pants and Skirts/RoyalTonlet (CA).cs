using System;

namespace Server.Items
{
	[FlipableAttribute( 15305, 15306 )]
	public class RoyalTonlet : BasePants
	{
		public override int InitMinHits{ get{ return 45; } }
		public override int InitMaxHits{ get{ return 55; } }

		[Constructable]
		public RoyalTonlet() : this( 0 )
		{
		}

		[Constructable]
		public RoyalTonlet( int hue ) : base( 15305, hue )
		{
                        Name = "Royal Tonlet";
			Weight = 2.0;
		}

		public RoyalTonlet( Serial serial ) : base( serial )
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
