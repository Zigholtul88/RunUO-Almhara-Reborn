using System;

namespace Server.Items
{
	[Flipable( 16379, 16380 )]
	public class BaroqueDress : BaseOuterTorso
	{
		public override int InitMinHits{ get{ return 25; } }
		public override int InitMaxHits{ get{ return 30; } }

		[Constructable]
		public BaroqueDress() : this( 0 )
		{
		}

		[Constructable]
		public BaroqueDress( int hue ) : base( 16379, hue )
		{
                        Name = "Baroque Dress";
			Weight = 5.0;
		}

		public override bool AllowMaleWearer{ get{ return false; } }

		public BaroqueDress( Serial serial ) : base( serial )
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

