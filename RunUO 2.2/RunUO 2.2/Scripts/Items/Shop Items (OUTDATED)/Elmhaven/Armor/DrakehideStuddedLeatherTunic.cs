using System;
using Server.Items;

namespace Server.Items
{
	public class DrakehideStuddedLeatherTunic : StuddedChest
	{
		public override int BaseFireResistance{ get{ return 25; } }
		public override int BaseColdResistance{ get{ return 25; } }
		public override int BaseEnergyResistance{ get{ return 25; } }
		public override int BasePoisonResistance{ get{ return 25; } }

		[Constructable]
		public DrakehideStuddedLeatherTunic()
		{
			Name = "Drakehide Studded Leather Tunic";
                        Hue = 1172;

			Attributes.BonusHits = 30;
		}

		public DrakehideStuddedLeatherTunic( Serial serial ) : base( serial )
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