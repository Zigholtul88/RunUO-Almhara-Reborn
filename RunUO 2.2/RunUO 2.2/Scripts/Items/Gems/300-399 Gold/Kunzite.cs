using System;
using Server;

namespace Server.Items
{
	public class Kunzite : Item
	{
		public override double DefaultWeight
		{
			get { return 0.1; }
		}

		[Constructable]
		public Kunzite() : this( 1 )
		{
		}

		[Constructable]
		public Kunzite( int amount ) : base( 0xF17 )
		{
			Name = "Kunzite";
			Stackable = true;
			Amount = amount;
			Hue = 2535;
		}

		public Kunzite( Serial serial ) : base( serial )
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