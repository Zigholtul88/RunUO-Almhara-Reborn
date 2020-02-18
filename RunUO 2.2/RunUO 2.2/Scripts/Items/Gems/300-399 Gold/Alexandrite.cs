using System;
using Server;

namespace Server.Items
{
	public class Alexandrite : Item
	{
		public override double DefaultWeight
		{
			get { return 0.1; }
		}

		[Constructable]
		public Alexandrite() : this( 1 )
		{
		}

		[Constructable]
		public Alexandrite( int amount ) : base( 0xF26 )
		{
			Name = "Alexandrite";
			Stackable = true;
			Amount = amount;
			Hue = 2591;
		}

		public Alexandrite( Serial serial ) : base( serial )
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