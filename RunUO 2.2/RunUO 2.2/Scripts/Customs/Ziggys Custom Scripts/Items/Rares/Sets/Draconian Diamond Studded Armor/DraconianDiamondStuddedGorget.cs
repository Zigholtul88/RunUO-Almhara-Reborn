using System;
using Server.Items;

namespace Server.Items
{
	public class DraconianDiamondStuddedGorget : PlateGorget
	{
		public override int BaseFireResistance{ get{ return 8; } }
		public override int BaseColdResistance{ get{ return 3; } }
		public override int BaseEnergyResistance{ get{ return 4; } }

		[Constructable]
		public DraconianDiamondStuddedGorget()
		{
			Name = "Draconian Diamond Studded Gorget";
                  Hue = 2119;
		}

		public DraconianDiamondStuddedGorget( Serial serial ) : base( serial )
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