using System;
using Server;

namespace Server.Items
{
	public class FeatheredHatOfSpeed : FeatheredHat
	{
		[Constructable]
		public FeatheredHatOfSpeed()
		{
                        Name = "Feathered Hat Of Speed";

			Attributes.BonusStam = 20;
		}

		public FeatheredHatOfSpeed( Serial serial ) : base( serial )
		{
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );

			writer.WriteEncodedInt( 0 ); // version
		}

		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader );

			int version = reader.ReadEncodedInt();
		}
	}
}
