using System;
using Server.Items;

namespace Server.Items
{
	public class DraconianDiamondStuddedGauntlets : PlateGloves
	{
		public override int BaseFireResistance{ get{ return 11; } }
		public override int BaseColdResistance{ get{ return 6; } }
		public override int BaseEnergyResistance{ get{ return 5; } }

		[Constructable]
		public DraconianDiamondStuddedGauntlets()
		{
			Name = "Draconian Diamond Studded Gauntlets";
                  Hue = 2119;
		}

		public DraconianDiamondStuddedGauntlets( Serial serial ) : base( serial )
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