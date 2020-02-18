using System;
using Server.Engines.Craft;

namespace Server.Items
{
	public class SnowCrustedBoots : HeavyBoots
	{
		public override int BaseColdResistance{ get{ return 12; } }

		[Constructable]
		public SnowCrustedBoots()
		{ 
                        Name = "Snow Crusted Boots";
                        Hue = 1150;
		}

		public SnowCrustedBoots( Serial serial ) : base( serial )
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

