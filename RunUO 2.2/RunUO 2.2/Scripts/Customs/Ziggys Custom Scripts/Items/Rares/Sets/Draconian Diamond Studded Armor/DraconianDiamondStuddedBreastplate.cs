using System;
using Server.Items;

namespace Server.Items
{
	public class DraconianDiamondStuddedBreastplate : PlateChest
	{
		public override int BaseFireResistance{ get{ return 18; } }
		public override int BaseColdResistance{ get{ return 12; } }
		public override int BaseEnergyResistance{ get{ return 13; } }

		[Constructable]
		public DraconianDiamondStuddedBreastplate()
		{
			Name = "Draconian Diamond Studded Breastplate";
                  Hue = 2119;
		}

		public DraconianDiamondStuddedBreastplate( Serial serial ) : base( serial )
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