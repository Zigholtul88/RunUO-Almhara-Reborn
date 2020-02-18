using System;
using Server.Items;

namespace Server.Items
{
	public class BrownLeatherTunicOfEarthProtection : LeatherChest
	{
		public override int BasePhysicalResistance{ get{ return 30; } }

		[Constructable]
		public BrownLeatherTunicOfEarthProtection()
		{
			Name = "Brown Leather Tunic of Earth Protection";
                        Hue = 1181;

			Attributes.BonusHits = 25;
		}

		public BrownLeatherTunicOfEarthProtection( Serial serial ) : base( serial )
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