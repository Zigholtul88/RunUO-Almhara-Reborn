using System;
using Server.Items;

namespace Server.Items
{
	public class DaemonicGemEncrustedBreastplate : PlateChest
	{
		public override int BaseFireResistance{ get{ return 12; } }
		public override int BaseColdResistance{ get{ return 13; } }
		public override int BasePoisonResistance{ get{ return 18; } }

		[Constructable]
		public DaemonicGemEncrustedBreastplate()
		{
			Name = "Daemonic Gem-Encrusted Breastplate";
                  Hue = 1461;
		}

		public DaemonicGemEncrustedBreastplate( Serial serial ) : base( serial )
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