using System;

namespace Server.Items
{
	[Flipable( 14394, 14395 )]
	public class RaggedDress : BaseOuterTorso
	{
		public override int InitMinHits{ get{ return 25; } }
		public override int InitMaxHits{ get{ return 30; } }

		[Constructable]
		public RaggedDress() : this( 0 )
		{
		}

		[Constructable]
		public RaggedDress( int hue ) : base( 14394, hue )
		{
                        Name = "Ragged Dress";
			Weight = 5.0;
		}

		public override bool AllowMaleWearer{ get{ return false; } }

		public RaggedDress( Serial serial ) : base( serial )
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

