using System;
using Server.Items;

namespace Server.Items
{
	public class GreenLeatherTunicOfPoisonProtection : LeatherChest
	{
		public override int BasePoisonResistance{ get{ return 30; } }

		[Constructable]
		public GreenLeatherTunicOfPoisonProtection()
		{
			Name = "Green Leather Tunic of Poison Protection";
                        Hue = 1371;

			Attributes.BonusHits = 25;
		}

		public GreenLeatherTunicOfPoisonProtection( Serial serial ) : base( serial )
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