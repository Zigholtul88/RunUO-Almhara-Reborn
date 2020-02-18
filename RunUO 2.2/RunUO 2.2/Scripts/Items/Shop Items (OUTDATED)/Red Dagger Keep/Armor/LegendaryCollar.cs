using System;
using Server;

namespace Server.Items
{
	public class LegendaryCollar : PlateGorget, ITokunoDyable
	{
		public override int BaseFireResistance{ get{ return 13; } }
		public override int BaseColdResistance{ get{ return 11; } }
		public override int BasePhysicalResistance{ get{ return 8; } }
		public override int BaseEnergyResistance{ get{ return 12; } }

		public override int InitMinHits{ get{ return 95; } }
		public override int InitMaxHits{ get{ return 100; } }

		[Constructable]
		public LegendaryCollar()
		{
			Name = "Legendary Collar";
			Hue = 794;

			Attributes.BonusStr = 5;
			Attributes.RegenHits = 1;
			Attributes.DefendChance = 25;
		}

		public LegendaryCollar( Serial serial ) : base( serial )
		{
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );

			writer.Write( (int) 1 );
		}
		
		public override void Deserialize(GenericReader reader)
		{
			base.Deserialize( reader );

			int version = reader.ReadInt();

		}
	}
}