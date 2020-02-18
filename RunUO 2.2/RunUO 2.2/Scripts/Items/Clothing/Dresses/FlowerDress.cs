using System;

namespace Server.Items
{
	[Flipable( 14380, 14381 )]
	public class FlowerDress : BaseOuterTorso
	{
		public override int InitMinHits{ get{ return 25; } }
		public override int InitMaxHits{ get{ return 30; } }

		[Constructable]
		public FlowerDress() : this( 0 )
		{
		}

		[Constructable]
		public FlowerDress( int hue ) : base( 14380, hue )
		{
                        Name = "Flower Dress";
			Weight = 5.0;
		}

		public override bool AllowMaleWearer{ get{ return false; } }

		public FlowerDress( Serial serial ) : base( serial )
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

