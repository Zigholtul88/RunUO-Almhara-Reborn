using System;
using Server.Items;

namespace Server.Items
{
	public class WindLeatherTunicOfProtection : LeatherChest
	{
		public override int BaseColdResistance{ get{ return 15; } }
		public override int BaseEnergyResistance{ get{ return 15; } }

		[Constructable]
		public WindLeatherTunicOfProtection()
		{
			Name = "Wind Leather Tunic of Protection";
                        Hue = 991;

			Attributes.BonusHits = 25;
		}

		public WindLeatherTunicOfProtection( Serial serial ) : base( serial )
		{
		}
		
		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );
			writer.Write( (int) 0 );
		}
		
		public override void Deserialize(GenericReader reader)
		{
			base.Deserialize( reader );
			int version = reader.ReadInt();
		}
	}
}