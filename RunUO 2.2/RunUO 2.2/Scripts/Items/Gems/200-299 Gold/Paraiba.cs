using System;
using Server;

namespace Server.Items
{
	public class Paraiba : Item
	{
		public override double DefaultWeight
		{
			get { return 0.1; }
		}

		[Constructable]
		public Paraiba() : this( 1 )
		{
		}

		[Constructable]
		public Paraiba( int amount ) : base( 0xF18 )
		{
			Name = "Paraiba";
			Stackable = true;
			Amount = amount;
			Hue = 2499;
		}

		public Paraiba( Serial serial ) : base( serial )
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