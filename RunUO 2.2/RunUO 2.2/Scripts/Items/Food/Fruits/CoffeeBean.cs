using System;
using System.IO;
using System.Collections;
using Server;
using Server.Items;

namespace Server.Items
{
	public class CoffeeBean : Item
	{
		[Constructable]
		public CoffeeBean() : this( 1 )
		{
		}

		[Constructable]
		public CoffeeBean( int amount ) : base( 0xC64 )
		{
			Name = "Coffee Bean";
                        Weight = 0.1;
                        Hue = 0x46A;
                        Amount = amount;
                        Stackable = true;
		}

		public CoffeeBean( Serial serial ) : base( serial )
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