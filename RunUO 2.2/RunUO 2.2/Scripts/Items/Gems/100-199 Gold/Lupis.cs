using System;
using Server;

namespace Server.Items
{
	public class Lupis : Item
	{
		public override double DefaultWeight
		{
			get { return 0.1; }
		}

		[Constructable]
		public Lupis() : this( 1 )
		{
		}

		[Constructable]
		public Lupis( int amount ) : base( 0xF15 )
		{
			Name = "Lupis";
			Stackable = true;
			Amount = amount;
			Hue = 2124;
		}

		public Lupis( Serial serial ) : base( serial )
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