using System;
using Server;

namespace Server.Items
{
	public class SwampVineAppendages : Item
	{
		[Constructable]
		public SwampVineAppendages() : this( 1 )
		{
		}

		[Constructable]
		public SwampVineAppendages( int amount ) : base( 0x5727 )
		{
			Name = "Swamp Vine Appendages";
			Stackable = true;
			Amount = amount;

			Weight = 1.0;
			Hue = 768;
		}

		public override void OnDoubleClick( Mobile m )
		{
			m.SendMessage( "the appendages of a swamp vine that can be sold to butchers." );
			m.PlaySound( 684 );
		}

		public SwampVineAppendages( Serial serial ) : base( serial )
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