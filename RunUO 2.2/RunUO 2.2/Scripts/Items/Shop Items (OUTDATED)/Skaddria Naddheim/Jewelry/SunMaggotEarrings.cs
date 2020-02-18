using System;
using Server;

namespace Server.Items
{
	public class SunMaggotEarrings : BaseEarrings
	{
		[Constructable]
		public SunMaggotEarrings() : base( 0x1087 )
		{
                        Name = "Sun Maggot Earrings";
                        Hue = 2413;
			Weight = 0.1;

			Resistances.Cold = 3;
			Resistances.Poison = 2;
			Resistances.Energy = 2;
		}

		public SunMaggotEarrings( Serial serial ) : base( serial )
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