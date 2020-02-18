using System;
using Server.Items;

namespace Server.Items
{
	public class DraconianDiamondStuddedLeggings : PlateLegs
	{
		public override int BaseFireResistance{ get{ return 14; } }
		public override int BaseColdResistance{ get{ return 8; } }
		public override int BaseEnergyResistance{ get{ return 9; } }

		[Constructable]
		public DraconianDiamondStuddedLeggings()
		{
			Name = "Draconian Diamond Studded Leggings";
                  Hue = 2119;
		}

		public DraconianDiamondStuddedLeggings( Serial serial ) : base( serial )
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