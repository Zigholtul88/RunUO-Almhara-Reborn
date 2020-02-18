using System;
using Server;

namespace Server.Items
{
	public class Beryl : Item
	{
		public override double DefaultWeight
		{
			get { return 0.1; }
		}

		[Constructable]
		public Beryl() : this( 1 )
		{
		}

		[Constructable]
		public Beryl( int amount ) : base( 0xF2F )
		{
			Name = "Beryl";
			Stackable = true;
			Amount = amount;
			Hue = 496;
		}

		public Beryl( Serial serial ) : base( serial )
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