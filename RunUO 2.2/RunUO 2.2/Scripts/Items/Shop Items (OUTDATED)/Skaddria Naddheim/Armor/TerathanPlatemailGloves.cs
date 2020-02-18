using System;
using Server.Items;

namespace Server.Items
{
	public class TerathanPlatemailGloves : PlateGloves
	{
		public override int BaseFireResistance{ get{ return 2; } }
		public override int BasePoisonResistance{ get{ return 10; } }
		public override int BaseEnergyResistance{ get{ return 2; } }

		[Constructable]
		public TerathanPlatemailGloves()
		{
			Name = "Terathan Platemail Gloves";
                        Hue = 2128;

			Attributes.BonusMana = 3;
		}

		public TerathanPlatemailGloves( Serial serial ) : base( serial )
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