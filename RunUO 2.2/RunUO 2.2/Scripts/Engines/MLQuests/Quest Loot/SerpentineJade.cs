using System;
using Server;

namespace Server.Items
{
	public class SerpentineJade : Item
	{
		public override double DefaultWeight
		{
			get { return 0.1; }
		}

		[Constructable]
		public SerpentineJade() : this( 1 )
		{
		}

		[Constructable]
		public SerpentineJade( int amount ) : base( 0xF17 )
		{
			Name = "Serpentine Jade - Quest Item";
			Stackable = true;
			Amount = amount;
			Hue = 61;
		}

		public override void OnDoubleClick( Mobile m )
		{
			m.SendMessage( "an item needed for the Jade Jungle Jems quest" );
		}

		public SerpentineJade( Serial serial ) : base( serial )
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