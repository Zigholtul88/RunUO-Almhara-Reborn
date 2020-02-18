using System;
using Server.Network;
using Server.Items;

namespace Server.Items
{
	public class SpidersilkRoundShield : BronzeShield
	{
		public override int BasePhysicalResistance{ get{ return 5; } }
		public override int BaseColdResistance{ get{ return 2; } }
		public override int BasePoisonResistance{ get{ return 4; } }

		[Constructable]
		public SpidersilkRoundShield() 
		{
			Name = "Spidersilk Round Shield";
                        Hue = 1150;
		}

		public SpidersilkRoundShield( Serial serial ) : base( serial )
		{
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );

			writer.Write( (int) 0 ); // version
		}

		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader );

			int version = reader.ReadInt();
		}
	}
}