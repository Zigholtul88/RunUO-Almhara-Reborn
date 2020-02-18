using System;
using Server;

namespace Server.Items
{
	public class SunMaggotNecklace : BaseNecklace
	{
		[Constructable]
		public SunMaggotNecklace() : base( 0x1085 )
		{
                        Name = "Sun Maggot Necklace";
                        Hue = 2413;
			Weight = 0.1;

			Resistances.Cold = 3;
			Resistances.Poison = 2;
			Resistances.Energy = 2;
		}

		public SunMaggotNecklace( Serial serial ) : base( serial )
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