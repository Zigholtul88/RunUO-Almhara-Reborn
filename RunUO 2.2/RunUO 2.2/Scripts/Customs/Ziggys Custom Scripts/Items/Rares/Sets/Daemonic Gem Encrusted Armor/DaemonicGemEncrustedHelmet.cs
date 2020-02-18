using System;
using Server.Items;

namespace Server.Items
{
	public class DaemonicGemEncrustedHelmet : Helmet
	{
		public override int BaseFireResistance{ get{ return 7; } }
		public override int BaseColdResistance{ get{ return 6; } }
		public override int BasePoisonResistance{ get{ return 10; } }

		[Constructable]
		public DaemonicGemEncrustedHelmet()
		{
			Name = "Daemonic Gem-Encrusted Helmet";
                  Hue = 1461;
		}

		public DaemonicGemEncrustedHelmet( Serial serial ) : base( serial )
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