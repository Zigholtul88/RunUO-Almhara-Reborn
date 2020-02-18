using System;
using Server.Items;

namespace Server.Items
{
	public class CyclopeanStuddedLeggings : StuddedLegs
	{
		public override int BaseFireResistance{ get{ return 6; } }
		public override int BasePoisonResistance{ get{ return 6; } }
		public override int BaseEnergyResistance{ get{ return 6; } }

		[Constructable]
		public CyclopeanStuddedLeggings()
		{
			Name = "Cyclopean Studded Leggings";
                        Hue = 1864;

			Attributes.BonusHits = 5;
		}

		public CyclopeanStuddedLeggings( Serial serial ) : base( serial )
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