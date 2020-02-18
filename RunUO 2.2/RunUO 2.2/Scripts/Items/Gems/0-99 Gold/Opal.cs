using System;
using Server;

namespace Server.Items
{
	public class Opal : Item
	{
		public override double DefaultWeight
		{
			get { return 0.1; }
		}

		[Constructable]
		public Opal() : this( 1 )
		{
		}

		[Constructable]
		public Opal( int amount ) : base( 0xF26 )
		{
			Name = "Opal";
			Stackable = true;
			Amount = amount;
			Hue = 1187;
		}

		public Opal( Serial serial ) : base( serial )
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