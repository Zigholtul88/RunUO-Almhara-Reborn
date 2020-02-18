using System;
using Server;

namespace Server.Items
{
	public class Ametrine : Item
	{
		public override double DefaultWeight
		{
			get { return 0.1; }
		}

		[Constructable]
		public Ametrine() : this( 1 )
		{
		}

		[Constructable]
		public Ametrine( int amount ) : base( 0xF1B )
		{
			Name = "Ametrine";
			Stackable = true;
			Amount = amount;
			Hue = 2599;
		}

		public Ametrine( Serial serial ) : base( serial )
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