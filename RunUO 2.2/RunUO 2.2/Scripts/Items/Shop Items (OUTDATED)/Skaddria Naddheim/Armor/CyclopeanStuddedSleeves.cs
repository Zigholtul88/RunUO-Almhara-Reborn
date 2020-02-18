using System;
using Server.Items;

namespace Server.Items
{
	public class CyclopeanStuddedSleeves : StuddedArms
	{
		public override int BaseFireResistance{ get{ return 4; } }
		public override int BasePoisonResistance{ get{ return 4; } }
		public override int BaseEnergyResistance{ get{ return 4; } }

		[Constructable]
		public CyclopeanStuddedSleeves()
		{
			Name = "Cyclopean Studded Sleeves";
                        Hue = 1864;

			Attributes.BonusHits = 3;
		}

		public CyclopeanStuddedSleeves( Serial serial ) : base( serial )
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