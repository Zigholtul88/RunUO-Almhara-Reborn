using System;
using Server.Items;

namespace Server.Items
{
	public class OphidianStuddedLeatherTunic : StuddedChest
	{
		public override int BaseFireResistance{ get{ return 10; } }
		public override int BasePoisonResistance{ get{ return 15; } }
		public override int BaseEnergyResistance{ get{ return 10; } }

		[Constructable]
		public OphidianStuddedLeatherTunic()
		{
			Name = "Ophidian Studded Leather Tunic";
                        Hue = 1846;

			Attributes.BonusMana = 7;
		}

		public OphidianStuddedLeatherTunic( Serial serial ) : base( serial )
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