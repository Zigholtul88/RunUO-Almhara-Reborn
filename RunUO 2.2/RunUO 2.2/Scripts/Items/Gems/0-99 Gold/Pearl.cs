using System;
using Server;

namespace Server.Items
{
	public class Pearl : Item
	{
		public override double DefaultWeight
		{
			get { return 0.1; }
		}

		[Constructable]
		public Pearl() : this( 1 )
		{
		}

		[Constructable]
		public Pearl( int amount ) : base( 0xF2B )
		{
			Name = "Pearl";
			Stackable = true;
			Amount = amount;
			Hue = 2960;
		}

		public Pearl( Serial serial ) : base( serial )
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