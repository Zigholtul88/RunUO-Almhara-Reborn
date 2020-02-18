using System;
using Server;

namespace Server.Items
{
	public class Zultanite : Item
	{
		public override double DefaultWeight
		{
			get { return 0.1; }
		}

		[Constructable]
		public Zultanite() : this( 1 )
		{
		}

		[Constructable]
		public Zultanite( int amount ) : base( 0xF2F )
		{
			Name = "Zultanite";
			Stackable = true;
			Amount = amount;
			Hue = 2105;
		}

		public Zultanite( Serial serial ) : base( serial )
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