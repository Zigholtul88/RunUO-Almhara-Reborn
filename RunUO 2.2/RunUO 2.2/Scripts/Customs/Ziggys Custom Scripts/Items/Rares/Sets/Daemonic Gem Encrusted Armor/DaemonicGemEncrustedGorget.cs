using System;
using Server.Items;

namespace Server.Items
{
	public class DaemonicGemEncrustedGorget : PlateGorget
	{
		public override int BaseFireResistance{ get{ return 3; } }
		public override int BaseColdResistance{ get{ return 4; } }
		public override int BasePoisonResistance{ get{ return 8; } }

		[Constructable]
		public DaemonicGemEncrustedGorget()
		{
			Name = "Daemonic Gem-Encrusted Gorget";
                  Hue = 1461;
		}

		public DaemonicGemEncrustedGorget( Serial serial ) : base( serial )
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