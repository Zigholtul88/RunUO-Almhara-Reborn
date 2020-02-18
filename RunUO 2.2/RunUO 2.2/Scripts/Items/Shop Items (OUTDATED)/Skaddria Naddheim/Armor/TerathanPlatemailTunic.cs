using System;
using Server.Items;

namespace Server.Items
{
	public class TerathanPlatemailTunic : PlateChest
	{
		public override int BaseFireResistance{ get{ return 10; } }
		public override int BasePoisonResistance{ get{ return 15; } }
		public override int BaseEnergyResistance{ get{ return 10; } }

		[Constructable]
		public TerathanPlatemailTunic()
		{
			Name = "Terathan Platemail Tunic";
                        Hue = 2128;

			Attributes.BonusMana = 7;
		}

		public TerathanPlatemailTunic( Serial serial ) : base( serial )
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