using System;
using Server;

namespace Server.Items
{
	public class GoldenNecklaceOfFortification : BaseNecklace
	{
		[Constructable]
		public GoldenNecklaceOfFortification() : base( 0x1085 )
		{
                        Name = "Golden Necklace of Fortification";
                        Hue = 2415;
			Weight = 0.1;

			Resistances.Physical = 40;
		}

		public GoldenNecklaceOfFortification( Serial serial ) : base( serial )
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