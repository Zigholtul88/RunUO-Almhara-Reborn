using System;
using System.Collections.Generic;
using System.Text;
using Server;
using Server.Engines.Harvest;
using Server.Items;

namespace Server.Engines.MLQuests.Items
{
	public class MagicEnchantedShovel : BaseHarvestTool
	{
		public override HarvestSystem HarvestSystem{ get{ return Mining.System; } }

		[Constructable]
		public MagicEnchantedShovel() : this( 50000 )
		{
		}

		[Constructable]
		public MagicEnchantedShovel( int uses ) : base( uses, 0xF39 )
		{
			Name = "Magic Enchanted Shovel";
			Weight = 5.0;
			Hue = 1581;

			LootType = LootType.Blessed;
		}
		
		public MagicEnchantedShovel( Serial serial ) : base( serial )
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