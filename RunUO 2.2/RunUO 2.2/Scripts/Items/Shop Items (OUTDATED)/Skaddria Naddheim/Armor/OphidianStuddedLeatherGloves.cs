using System;
using Server.Items;

namespace Server.Items
{
	public class OphidianStuddedLeatherGloves : StuddedGloves
	{
		public override int BaseFireResistance{ get{ return 2; } }
		public override int BasePoisonResistance{ get{ return 10; } }
		public override int BaseEnergyResistance{ get{ return 2; } }

		[Constructable]
		public OphidianStuddedLeatherGloves()
		{
			Name = "Ophidian Studded Leather Gloves";
                        Hue = 1846;

			Attributes.BonusMana = 3;
		}

		public OphidianStuddedLeatherGloves( Serial serial ) : base( serial )
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