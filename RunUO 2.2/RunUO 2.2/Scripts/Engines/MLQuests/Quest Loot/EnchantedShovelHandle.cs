using System;
using Server;
using Server.Items; 

namespace Server.Items
{
	public class EnchantedShovelHandle : Item
	{
		[Constructable]
		public EnchantedShovelHandle()
		{
			Name = "The Handle Of An Enchanted Shovel - Quest Item";          
         		ItemID = 6202;
         		Weight = 1.0;
         		Hue = 1581;
		}

		public override void OnDoubleClick( Mobile m )
		{
			m.SendMessage( "shovel part required to complete the Enchanted Shovel quest." );
		}

		public EnchantedShovelHandle( Serial serial ) : base( serial )
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
