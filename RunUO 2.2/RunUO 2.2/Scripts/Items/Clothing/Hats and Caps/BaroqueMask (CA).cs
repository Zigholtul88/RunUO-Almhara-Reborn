using System;
using Server.Engines.Craft;

namespace Server.Items
{
	[FlipableAttribute( 15850, 15851 )]
	public class BaroqueMask  : BaseHat
	{
		public override int BasePhysicalResistance{ get{ return 5; } }

		public override int InitMinHits{ get{ return 21; } }
		public override int InitMaxHits{ get{ return 23; } }

		[Constructable]
		public BaroqueMask () : this( 0 )
		{
		}

		[Constructable]
		public BaroqueMask ( int hue ) : base( 15850, hue )
		{
                        Name = "Baroque Mask ";
			Weight = 4.0;
		}

		public BaroqueMask ( Serial serial ) : base( serial )
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