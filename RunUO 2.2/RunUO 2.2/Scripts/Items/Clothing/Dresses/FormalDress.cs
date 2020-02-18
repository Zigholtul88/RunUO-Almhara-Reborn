using System;

namespace Server.Items
{
	[Flipable( 14382, 14383 )]
	public class FormalDress : BaseOuterTorso
	{
		public override int InitMinHits{ get{ return 25; } }
		public override int InitMaxHits{ get{ return 30; } }

		[Constructable]
		public FormalDress() : this( 0 )
		{
		}

		[Constructable]
		public FormalDress( int hue ) : base( 14382, hue )
		{
                        Name = "Formal Dress";
			Weight = 5.0;
		}

		public override bool AllowMaleWearer{ get{ return false; } }

		public FormalDress( Serial serial ) : base( serial )
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

