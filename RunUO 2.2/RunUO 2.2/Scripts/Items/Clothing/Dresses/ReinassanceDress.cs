using System;

namespace Server.Items
{
	[Flipable( 15848, 15849 )]
	public class ReinassanceDress : BaseOuterTorso
	{
		public override int InitMinHits{ get{ return 25; } }
		public override int InitMaxHits{ get{ return 30; } }

		[Constructable]
		public ReinassanceDress() : this( 0 )
		{
		}

		[Constructable]
		public ReinassanceDress( int hue ) : base( 15848, hue )
		{
                        Name = "Reinassance Dress";
			Weight = 5.0;
		}

		public override bool AllowMaleWearer{ get{ return false; } }

		public ReinassanceDress( Serial serial ) : base( serial )
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

