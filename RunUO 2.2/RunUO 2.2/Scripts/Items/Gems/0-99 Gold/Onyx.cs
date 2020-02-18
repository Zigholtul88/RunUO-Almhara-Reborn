using System;
using Server;

namespace Server.Items
{
	public class Onyx : Item
	{
		public override double DefaultWeight
		{
			get { return 0.1; }
		}

		[Constructable]
		public Onyx() : this( 1 )
		{
		}

		[Constructable]
		public Onyx( int amount ) : base( 0xF18 )
		{
			Name = "Onyx";
			Stackable = true;
			Amount = amount;
			Hue = 1905;
		}

		public Onyx( Serial serial ) : base( serial )
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