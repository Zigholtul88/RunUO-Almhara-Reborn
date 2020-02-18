using System;
using Server;

namespace Server.Items
{
	public class Mandarin : Item
	{
		public override double DefaultWeight
		{
			get { return 0.1; }
		}

		[Constructable]
		public Mandarin() : this( 1 )
		{
		}

		[Constructable]
		public Mandarin( int amount ) : base( 0xF2B )
		{
			Name = "Mandarin";
			Stackable = true;
			Amount = amount;
			Hue = 1358;
		}

		public Mandarin( Serial serial ) : base( serial )
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