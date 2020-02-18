using System;
using Server.Engines.Craft;

namespace Server.Items
{

	[Flipable( 0x2306, 0x2305 )]
	public class FlowerGarland : BaseHat
	{
		public override int InitMinHits{ get{ return 20; } }
		public override int InitMaxHits{ get{ return 30; } }

		[Constructable]
		public FlowerGarland() : this( 0 )
		{
		}

		[Constructable]
		public FlowerGarland( int hue ) : base( 0x2306, hue )
		{
                  Name = "a flower garland";
			Weight = 1.0;
		}

		public FlowerGarland( Serial serial ) : base( serial )
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