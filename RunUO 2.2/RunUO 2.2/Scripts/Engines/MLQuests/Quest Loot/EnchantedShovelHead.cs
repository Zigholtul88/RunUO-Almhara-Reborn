using System;
using Server;
using Server.Items;

namespace Server.Items
{
	public class EnchantedShovelHead : Item
	{
		[Constructable]
		public EnchantedShovelHead()
		{
			Name = "The Head Of An Enchanted Shovel - Quest Item";          
         		ItemID = 3971;
         		Weight = 5.0;
         		Hue = 1581;
		}

		public override void OnDoubleClick( Mobile m )
		{
			m.SendMessage( "shovel part required to complete the Enchanted Shovel quest." );
		}

		public EnchantedShovelHead( Serial serial ) : base( serial )
		{
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );
			writer.Write( (int) 0 );
		}

		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader );
			int version = reader.ReadInt();
		}
	}
}
