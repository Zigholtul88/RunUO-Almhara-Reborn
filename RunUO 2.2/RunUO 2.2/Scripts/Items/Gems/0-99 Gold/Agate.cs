using System;
using Server;

namespace Server.Items
{
	public class Agate : Item
	{
		public override double DefaultWeight
		{
			get { return 0.1; }
		}

		[Constructable]
		public Agate() : this( 1 )
		{
		}

		[Constructable]
		public Agate( int amount ) : base( 0xF17 )
		{
			Name = "Agate";
			Stackable = true;
			Amount = amount;
			Hue = 2307;
		}

		public Agate( Serial serial ) : base( serial )
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