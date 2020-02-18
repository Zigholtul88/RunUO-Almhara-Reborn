using System;
using Server.Items;

namespace Server.Items
{
	public class DraconianDiamondStuddedSleeves : PlateArms
	{
		public override int BaseFireResistance{ get{ return 9; } }
		public override int BaseColdResistance{ get{ return 4; } }
		public override int BaseEnergyResistance{ get{ return 3; } }

		[Constructable]
		public DraconianDiamondStuddedSleeves()
		{
			Name = "Draconian Diamond Studded Sleeves";
                  Hue = 2119;
		}

		public DraconianDiamondStuddedSleeves( Serial serial ) : base( serial )
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