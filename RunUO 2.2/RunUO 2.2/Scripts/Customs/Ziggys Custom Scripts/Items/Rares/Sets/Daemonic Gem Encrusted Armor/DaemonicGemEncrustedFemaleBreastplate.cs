using System;
using Server.Items;

namespace Server.Items
{
	public class DaemonicGemEncrustedFemaleBreastplate : FemalePlateChest
	{
		public override int BaseFireResistance{ get{ return 12; } }
		public override int BaseColdResistance{ get{ return 13; } }
		public override int BasePoisonResistance{ get{ return 18; } }

		[Constructable]
		public DaemonicGemEncrustedFemaleBreastplate()
		{
			Name = "Daemonic Gem-Encrusted Female Breastplate";
                  Hue = 1461;
		}

		public DaemonicGemEncrustedFemaleBreastplate( Serial serial ) : base( serial )
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