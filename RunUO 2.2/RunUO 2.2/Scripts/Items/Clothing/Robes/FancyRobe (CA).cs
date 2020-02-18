using System;

namespace Server.Items
{
	[Flipable( 16369, 16370 )]
	public class FancyRobe : BaseOuterTorso
	{
		public override int InitMinHits{ get{ return 35; } }
		public override int InitMaxHits{ get{ return 50; } }

		[Constructable]
		public FancyRobe() : this( 0 )
		{
		}

		[Constructable]
		public FancyRobe( int hue ) : base( 16369, hue )
		{
                        Name = "Fancy Robe";
			Weight = 5.0;
		}

		public FancyRobe( Serial serial ) : base( serial )
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

