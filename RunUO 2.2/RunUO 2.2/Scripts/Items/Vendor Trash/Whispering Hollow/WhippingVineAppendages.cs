using System;
using Server;

namespace Server.Items
{
	public class WhippingVineAppendages : Item
	{
		[Constructable]
		public WhippingVineAppendages() : this( 1 )
		{
		}

		[Constructable]
		public WhippingVineAppendages( int amount ) : base( 0x5727 )
		{
			Name = "Whipping Vine Appendages";
			Stackable = true;
			Amount = amount;

			Weight = 1.0;
			Hue = 372;
		}

		public override void OnDoubleClick( Mobile m )
		{
			m.SendMessage( "the appendages of a whipping vine that can be sold to butchers." );
			m.PlaySound( 684 );
		}

		public WhippingVineAppendages( Serial serial ) : base( serial )
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