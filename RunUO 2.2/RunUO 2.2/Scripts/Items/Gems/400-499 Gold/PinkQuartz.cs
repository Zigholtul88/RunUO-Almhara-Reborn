using System;
using Server;

namespace Server.Items
{
	public class PinkQuartz : Item
	{
		public override double DefaultWeight
		{
			get { return 0.1; }
		}

		[Constructable]
		public PinkQuartz() : this( 1 )
		{
		}

		[Constructable]
		public PinkQuartz( int amount ) : base( 0xF17 )
		{
			Name = "Pink Quartz";
			Stackable = true;
			Amount = amount;
			Hue = 2662;
		}

		public PinkQuartz( Serial serial ) : base( serial )
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