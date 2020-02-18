using System;
using Server.Items;

namespace Server.Items
{
	public class DaemonicGemEncrustedLeggings : PlateLegs
	{
		public override int BaseFireResistance{ get{ return 8; } }
		public override int BaseColdResistance{ get{ return 9; } }
		public override int BasePoisonResistance{ get{ return 14; } }

		[Constructable]
		public DaemonicGemEncrustedLeggings()
		{
			Name = "Daemonic Gem-Encrusted Leggings";
                  Hue = 1461;
		}

		public DaemonicGemEncrustedLeggings( Serial serial ) : base( serial )
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