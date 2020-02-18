using System;

namespace Server.Items
{
	[Flipable( 14384, 14385 )]
	public class MaidensDress : BaseOuterTorso
	{
		public override int InitMinHits{ get{ return 25; } }
		public override int InitMaxHits{ get{ return 30; } }

		[Constructable]
		public MaidensDress() : this( 0 )
		{
		}

		[Constructable]
		public MaidensDress( int hue ) : base( 14384, hue )
		{
                        Name = "Maidens Dress";
			Weight = 5.0;
		}

		public override bool AllowMaleWearer{ get{ return false; } }

		public MaidensDress( Serial serial ) : base( serial )
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

