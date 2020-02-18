using System;
using Server;

namespace Server.Items
{
	public class Andalusite : Item
	{
		public override double DefaultWeight
		{
			get { return 0.1; }
		}

		[Constructable]
		public Andalusite() : this( 1 )
		{
		}

		[Constructable]
		public Andalusite( int amount ) : base( 0xF2F )
		{
			Name = "Andalusite";
			Stackable = true;
			Amount = amount;
			Hue = 2424;
		}

		public Andalusite( Serial serial ) : base( serial )
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