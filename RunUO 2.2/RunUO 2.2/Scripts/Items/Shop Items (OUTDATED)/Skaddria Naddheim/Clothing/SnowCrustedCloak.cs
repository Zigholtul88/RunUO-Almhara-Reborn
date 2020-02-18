using System;
using Server.Engines.Craft;

namespace Server.Items
{
	public class SnowCrustedCloak : Cloak
	{
		public override int BaseColdResistance{ get{ return 15; } }

		[Constructable]
		public SnowCrustedCloak()
		{ 
                        Name = "Snow Crusted Cloak";
                        Hue = 1150;
		}

		public SnowCrustedCloak( Serial serial ) : base( serial )
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

