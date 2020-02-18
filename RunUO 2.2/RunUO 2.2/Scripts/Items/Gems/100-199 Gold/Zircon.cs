using System;
using Server;

namespace Server.Items
{
	public class Zircon : Item
	{
		public override double DefaultWeight
		{
			get { return 0.1; }
		}

		[Constructable]
		public Zircon() : this( 1 )
		{
		}

		[Constructable]
		public Zircon( int amount ) : base( 0xF2B )
		{
			Name = "Zircon";
			Stackable = true;
			Amount = amount;
			Hue = 2422;
		}

		public Zircon( Serial serial ) : base( serial )
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