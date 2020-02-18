using System;
using Server;

namespace Server.Items
{
	public class Lolite : Item
	{
		public override double DefaultWeight
		{
			get { return 0.1; }
		}

		[Constructable]
		public Lolite() : this( 1 )
		{
		}

		[Constructable]
		public Lolite( int amount ) : base( 0xF17 )
		{
			Name = "Lolite";
			Stackable = true;
			Amount = amount;
			Hue = 1176;
		}

		public Lolite( Serial serial ) : base( serial )
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