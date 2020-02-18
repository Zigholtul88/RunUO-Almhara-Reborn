using System;
using Server.Network;
using Server.Items;
using Server.Targeting;

namespace Server.Items
{
	public class SprintersSandals : Sandals, ITokunoDyable
        {
                [Constructable]
		public SprintersSandals()
		{
                       Name = "Sprinter's Sandals";
                       Hue = 1372;

                       Attributes.BonusStam = 50;
                       Attributes.RegenStam = 1;
		}

		public SprintersSandals( Serial serial ) : base( serial )
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
