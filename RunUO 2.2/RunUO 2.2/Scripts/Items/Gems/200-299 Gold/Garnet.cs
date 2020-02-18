using System;
using Server;

namespace Server.Items
{
	public class Garnet : Item
	{
		public override double DefaultWeight
		{
			get { return 0.1; }
		}

		[Constructable]
		public Garnet() : this( 1 )
		{
		}

		[Constructable]
		public Garnet( int amount ) : base( 0xF1B )
		{
			Name = "Garnet";
			Stackable = true;
			Amount = amount;
			Hue = 2116;
		}

		public Garnet( Serial serial ) : base( serial )
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