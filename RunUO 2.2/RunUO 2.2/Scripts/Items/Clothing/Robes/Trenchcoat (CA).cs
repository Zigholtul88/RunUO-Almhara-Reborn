using System;

namespace Server.Items
{
	[Flipable( 16173, 16174 )]
	public class Trenchcoat : BaseOuterTorso
	{
		public override int InitMinHits{ get{ return 21; } }
		public override int InitMaxHits{ get{ return 30; } }

		[Constructable]
		public Trenchcoat() : this( 0 )
		{
		}

		[Constructable]
		public Trenchcoat( int hue ) : base( 16173, hue )
		{
                        Name = "Trenchcoat";
			Weight = 5.0;
		}

		public Trenchcoat( Serial serial ) : base( serial )
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

