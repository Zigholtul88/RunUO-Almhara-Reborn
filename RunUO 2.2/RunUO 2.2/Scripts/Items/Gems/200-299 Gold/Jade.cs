using System;
using Server;

namespace Server.Items
{
	public class Jade : Item
	{
		public override double DefaultWeight
		{
			get { return 0.1; }
		}

		[Constructable]
		public Jade() : this( 1 )
		{
		}

		[Constructable]
		public Jade( int amount ) : base( 0xF17 )
		{
			Name = "Jade";
			Stackable = true;
			Amount = amount;
			Hue = 2002;
		}

		public Jade( Serial serial ) : base( serial )
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