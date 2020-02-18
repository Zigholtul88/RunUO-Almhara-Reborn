using System;
using Server;

namespace Server.Items
{
	public class Bloodstone : Item
	{
		public override double DefaultWeight
		{
			get { return 0.1; }
		}

		[Constructable]
		public Bloodstone() : this( 1 )
		{
		}

		[Constructable]
		public Bloodstone( int amount ) : base( 0xF2F )
		{
			Name = "Bloodstone";
			Stackable = true;
			Amount = amount;
			Hue = 1194;
		}

		public Bloodstone( Serial serial ) : base( serial )
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