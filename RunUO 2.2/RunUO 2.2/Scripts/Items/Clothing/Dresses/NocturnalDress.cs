using System;

namespace Server.Items
{
	[Flipable( 14390, 14391 )]
	public class NocturnalDress : BaseOuterTorso
	{
		public override int InitMinHits{ get{ return 25; } }
		public override int InitMaxHits{ get{ return 30; } }

		[Constructable]
		public NocturnalDress() : this( 0 )
		{
		}

		[Constructable]
		public NocturnalDress( int hue ) : base( 14390, hue )
		{
                        Name = "Nocturnal Dress";
			Weight = 5.0;
		}

		public override bool AllowMaleWearer{ get{ return false; } }

		public NocturnalDress( Serial serial ) : base( serial )
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

