using System;
using Server;

namespace Server.Items
{
	public class DesertEmerald : Item
	{
		public override double DefaultWeight
		{
			get { return 0.1; }
		}

		[Constructable]
		public DesertEmerald() : this( 1 )
		{
		}

		[Constructable]
		public DesertEmerald( int amount ) : base( 0xF10 )
		{
			Name = "Desert Emerald";
			Stackable = true;
			Amount = amount;
			Hue = 2611;
		}

		public DesertEmerald( Serial serial ) : base( serial )
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