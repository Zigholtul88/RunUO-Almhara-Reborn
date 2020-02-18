using System;

namespace Server.Items
{
	[Flipable( 14396, 14397 )]
	public class TheaterDress : BaseOuterTorso
	{
		public override int InitMinHits{ get{ return 25; } }
		public override int InitMaxHits{ get{ return 30; } }

		[Constructable]
		public TheaterDress() : this( 0 )
		{
		}

		[Constructable]
		public TheaterDress( int hue ) : base( 14396, hue )
		{
                        Name = "Theater Dress";
			Weight = 5.0;
		}

		public override bool AllowMaleWearer{ get{ return false; } }

		public TheaterDress( Serial serial ) : base( serial )
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

