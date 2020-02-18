using System;
using Server.Network;
using Server.Prompts;
using Server.Items;

namespace Server.Items
{
	public class BlackGear : Item
	{
		public override double DefaultWeight
		{
			get { return 0.1; }
		}

		[Constructable]
		public BlackGear() : this( 1 )
		{
		}

		[Constructable]
		public BlackGear( int amount ) : base( 0x1053 )
		{
			Name = "Black Gear";
                  Hue = 1;
			Stackable = true;
			Amount = amount;
		}

		public BlackGear( Serial serial ) : base( serial )
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

		public override void OnDoubleClick( Mobile m )
		{
			m.SendMessage( "an ingredient used for gem crafting" );
		}
	}
}