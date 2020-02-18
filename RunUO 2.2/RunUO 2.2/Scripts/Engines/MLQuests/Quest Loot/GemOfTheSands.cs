using System;
using Server.Network;
using Server.Prompts;
using Server.Items;

namespace Server.Items
{
	public class GemOfTheSands : Item
	{
		public override double DefaultWeight
		{
			get { return 0.1; }
		}

		[Constructable]
		public GemOfTheSands() : this( 1 )
		{
		}

		[Constructable]
		public GemOfTheSands( int amount ) : base( 0xF21 )
		{
			Name = "Gem of the Sands - Quest Item";
                        Hue = 251;
			Stackable = true;
			Amount = amount;
		}

		public override void OnDoubleClick( Mobile m )
		{
			m.SendMessage( "an item needed for the Treasure Of The Sands quest" );
		}

		public GemOfTheSands( Serial serial ) : base( serial )
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