using System;
using Server.Items;

namespace Server.Items
{
	public class DaemonicGemEncrustedGauntlets : PlateGloves
	{
		public override int BaseFireResistance{ get{ return 6; } }
		public override int BaseColdResistance{ get{ return 5; } }
		public override int BasePoisonResistance{ get{ return 11; } }

		[Constructable]
		public DaemonicGemEncrustedGauntlets()
		{
			Name = "Daemonic Gem-Encrusted Gauntlets";
                  Hue = 1461;
		}

		public DaemonicGemEncrustedGauntlets( Serial serial ) : base( serial )
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