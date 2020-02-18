using System;
using Server.Engines.Craft;

namespace Server.Items
{
	public class ElvenSilkRobe : ElvenRobe
	{
		[Constructable]
		public ElvenSilkRobe()
		{ 
                        Name = "Elven Silk Robe";
                        Hue = 1150;

			Attributes.CastSpeed = 5;
			Attributes.BonusMana = 50;
			Attributes.RegenMana = 1;
		}

		public ElvenSilkRobe( Serial serial ) : base( serial )
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

