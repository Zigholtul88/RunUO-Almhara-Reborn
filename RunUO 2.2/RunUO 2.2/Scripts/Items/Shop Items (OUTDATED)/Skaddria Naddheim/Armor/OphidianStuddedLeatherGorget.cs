using System;
using Server.Items;

namespace Server.Items
{
	public class OphidianStuddedLeatherGorget : StuddedGorget
	{
		public override int BaseFireResistance{ get{ return 5; } }
		public override int BasePoisonResistance{ get{ return 10; } }
		public override int BaseEnergyResistance{ get{ return 5; } }

		[Constructable]
		public OphidianStuddedLeatherGorget()
		{
			Name = "Ophidian Studded Leather Gorget";
                        Hue = 1846;

			Attributes.BonusMana = 5;
		}

		public OphidianStuddedLeatherGorget( Serial serial ) : base( serial )
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