using System;
using Server;

namespace Server.Items
{
	public class Peridot : Item
	{
		public override double DefaultWeight
		{
			get { return 0.1; }
		}

		[Constructable]
		public Peridot() : this( 1 )
		{
		}

		[Constructable]
		public Peridot( int amount ) : base( 0xF18 )
		{
			Name = "Peridot";
			Stackable = true;
			Amount = amount;
			Hue = 2126;
		}

		public Peridot( Serial serial ) : base( serial )
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