using System;

namespace Server.Items
{
	[Flipable( 14386, 14387 )]
	public class MedievalLongDress : BaseOuterTorso
	{
		public override int InitMinHits{ get{ return 25; } }
		public override int InitMaxHits{ get{ return 30; } }

		[Constructable]
		public MedievalLongDress() : this( 0 )
		{
		}

		[Constructable]
		public MedievalLongDress( int hue ) : base( 14386, hue )
		{
                        Name = "Medieval Long Dress";
			Weight = 5.0;
		}

		public override bool AllowMaleWearer{ get{ return false; } }

		public MedievalLongDress( Serial serial ) : base( serial )
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

