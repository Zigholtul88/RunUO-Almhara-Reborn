using System;
using Server.Items;
using Server.Network;
using Server.Prompts;

namespace Server.Items
{
	public class FaerieBeetleEgg : Item
	{
		public override double DefaultWeight
		{
			get { return 0.1; }
		}

		[Constructable]
		public FaerieBeetleEgg() : this( 1 )
		{
		}

		[Constructable]
		public FaerieBeetleEgg( int amount ) : base( 0x9D2 )
		{
			Name = "Faerie Beetle Egg - Quest Item";
                        Hue = 1366;
			Stackable = true;
			Amount = amount;
		}

		public override void OnDoubleClick( Mobile m )
		{
			m.SendMessage( "an item needed for the Egg Collector quest" );
		}

		public FaerieBeetleEgg( Serial serial ) : base( serial )
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