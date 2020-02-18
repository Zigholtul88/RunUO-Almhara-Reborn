using System;
using System.Collections.Generic;
using System.Text;
using Server;
using Server.Items;

namespace Server.Engines.MLQuests.Items
{
	public class SpidersilkCloakOfProtection : Cloak
	{
		public override int BasePhysicalResistance{ get{ return 15; } }
		public override int BaseFireResistance{ get{ return 15; } }
		public override int BaseColdResistance{ get{ return 15; } }
		public override int BaseEnergyResistance{ get{ return 15; } }
		public override int BasePoisonResistance{ get{ return 15; } }

		[Constructable]
		public SpidersilkCloakOfProtection()
		{ 
                        Name = "Spidersilk Cloak of Protection";
                        Hue = 1752;

			LootType = LootType.Blessed;
		}

		public SpidersilkCloakOfProtection( Serial serial ) : base( serial )
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

