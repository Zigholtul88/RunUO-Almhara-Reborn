using System;
using Server;

namespace Server.Items
{
	public class Tanzanite : Item
	{
		public override double DefaultWeight
		{
			get { return 0.1; }
		}

		[Constructable]
		public Tanzanite() : this( 1 )
		{
		}

		[Constructable]
		public Tanzanite( int amount ) : base( 0xF15 )
		{
			Name = "Tanzanite";
			Stackable = true;
			Amount = amount;
			Hue = 2593;
		}

		public Tanzanite( Serial serial ) : base( serial )
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