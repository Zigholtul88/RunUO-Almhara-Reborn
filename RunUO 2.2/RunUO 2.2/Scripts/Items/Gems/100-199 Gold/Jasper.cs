using System;
using Server;

namespace Server.Items
{
	public class Jasper : Item
	{
		public override double DefaultWeight
		{
			get { return 0.1; }
		}

		[Constructable]
		public Jasper() : this( 1 )
		{
		}

		[Constructable]
		public Jasper( int amount ) : base( 0xF1B )
		{
			Name = "Jasper";
			Stackable = true;
			Amount = amount;
			Hue = 538;
		}

		public Jasper( Serial serial ) : base( serial )
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