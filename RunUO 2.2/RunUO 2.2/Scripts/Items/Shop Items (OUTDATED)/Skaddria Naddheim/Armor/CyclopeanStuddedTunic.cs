using System;
using Server.Items;

namespace Server.Items
{
	public class CyclopeanStuddedTunic : StuddedChest
	{
		public override int BaseFireResistance{ get{ return 10; } }
		public override int BasePoisonResistance{ get{ return 10; } }
		public override int BaseEnergyResistance{ get{ return 10; } }

		[Constructable]
		public CyclopeanStuddedTunic()
		{
			Name = "Cyclopean Studded Tunic";
                        Hue = 1864;

			Attributes.BonusHits = 7;
		}

		public CyclopeanStuddedTunic( Serial serial ) : base( serial )
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