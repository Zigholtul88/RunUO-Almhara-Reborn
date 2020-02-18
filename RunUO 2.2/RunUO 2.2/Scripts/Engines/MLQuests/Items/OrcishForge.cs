using System;
using System.Collections.Generic;
using System.Text;
using Server;
using Server.Items;

namespace Server.Engines.MLQuests.Items
{
	[Server.Engines.Craft.Forge]
	public class OrcishForge : Item
	{
		[Constructable]
		public OrcishForge() : base( 0xFB1 )
		{
			Name = "Orcish Forge";
			Hue = 1161;
			Movable = true;

		        LootType = LootType.Blessed;
		}

		public OrcishForge( Serial serial ) : base( serial )
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