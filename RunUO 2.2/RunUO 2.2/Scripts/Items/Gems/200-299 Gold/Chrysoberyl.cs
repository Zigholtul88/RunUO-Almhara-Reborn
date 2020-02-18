using System;
using Server;

namespace Server.Items
{
	public class Chrysoberyl : Item
	{
		public override double DefaultWeight
		{
			get { return 0.1; }
		}

		[Constructable]
		public Chrysoberyl() : this( 1 )
		{
		}

		[Constructable]
		public Chrysoberyl( int amount ) : base( 0xF15 )
		{
			Name = "Chrysoberyl";
			Stackable = true;
			Amount = amount;
			Hue = 2961;
		}

		public Chrysoberyl( Serial serial ) : base( serial )
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