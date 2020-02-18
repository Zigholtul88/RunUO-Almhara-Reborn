using System;
using Server.Engines.Craft;

namespace Server.Items
{
	public class ElvenBootsOfSpeed : ElvenBoots
	{
		[Constructable]
		public ElvenBootsOfSpeed()
		{ 
                        Name = "Elven Boots Of Speed";
                        Hue = 1757;

			Attributes.BonusStam = 50;
		}

		public ElvenBootsOfSpeed( Serial serial ) : base( serial )
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

