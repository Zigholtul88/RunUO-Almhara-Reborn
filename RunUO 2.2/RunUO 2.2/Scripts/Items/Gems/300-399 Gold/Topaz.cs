using System;
using Server;

namespace Server.Items
{
	public class Topaz : Item
	{
		public override double DefaultWeight
		{
			get { return 0.1; }
		}

		[Constructable]
		public Topaz() : this( 1 )
		{
		}

		[Constructable]
		public Topaz( int amount ) : base( 0xF1C )
		{
			Name = "Topaz";
			Stackable = true;
			Amount = amount;
			Hue = 2952;
		}

		public Topaz( Serial serial ) : base( serial )
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