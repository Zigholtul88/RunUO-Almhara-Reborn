using System;
using Server.Engines.Craft;

namespace Server.Items
{
	public class SalamandersRobe : Robe
	{
		public override int BaseFireResistance{ get{ return 40; } }

		[Constructable]
		public SalamandersRobe()
		{ 
                        Name = "Salamander's Robe";
                        Hue = 1281;
		}

		public SalamandersRobe( Serial serial ) : base( serial )
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

