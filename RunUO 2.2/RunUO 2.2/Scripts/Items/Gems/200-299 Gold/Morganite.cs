using System;
using Server;

namespace Server.Items
{
	public class Morganite : Item
	{
		public override double DefaultWeight
		{
			get { return 0.1; }
		}

		[Constructable]
		public Morganite() : this( 1 )
		{
		}

		[Constructable]
		public Morganite( int amount ) : base( 0xF26 )
		{
			Name = "Morganite";
			Stackable = true;
			Amount = amount;
			Hue = 2970;
		}

		public Morganite( Serial serial ) : base( serial )
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