using System;

namespace Server.Items
{
	[Flipable( 14374, 14375 )]
	public class ConfessorDress : BaseOuterTorso
	{
		public override int InitMinHits{ get{ return 25; } }
		public override int InitMaxHits{ get{ return 30; } }

		[Constructable]
		public ConfessorDress() : this( 0 )
		{
		}

		[Constructable]
		public ConfessorDress( int hue ) : base( 14374, hue )
		{
                        Name = "Confessor Dress";
			Weight = 5.0;
		}

		public override bool AllowMaleWearer{ get{ return false; } }

		public ConfessorDress( Serial serial ) : base( serial )
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

