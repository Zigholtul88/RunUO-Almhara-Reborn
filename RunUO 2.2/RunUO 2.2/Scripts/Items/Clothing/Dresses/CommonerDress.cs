using System;

namespace Server.Items
{
	[Flipable( 14372, 14373 )]
	public class CommonerDress : BaseOuterTorso
	{
		public override int InitMinHits{ get{ return 25; } }
		public override int InitMaxHits{ get{ return 30; } }

		[Constructable]
		public CommonerDress() : this( 0 )
		{
		}

		[Constructable]
		public CommonerDress( int hue ) : base( 14372, hue )
		{
                        Name = "Commoner Dress";
			Weight = 5.0;
		}

		public override bool AllowMaleWearer{ get{ return false; } }

		public CommonerDress( Serial serial ) : base( serial )
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

