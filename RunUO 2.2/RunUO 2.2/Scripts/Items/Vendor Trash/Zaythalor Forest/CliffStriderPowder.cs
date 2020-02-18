using System;
using Server;

namespace Server.Items
{
	public class CliffStriderPowder : Item
	{
		[Constructable]
		public CliffStriderPowder() : this( 1 )
		{
		}

		[Constructable]
		public CliffStriderPowder( int amount ) : base( 0x5745 )
		{
			Name = "Cliff Strider Powder";
			Stackable = true;
			Amount = amount;

			Weight = 0.1;
                        Hue = 2651;
		}

		public override void OnDoubleClick( Mobile m )
		{
			m.SendMessage( "powder from a cliff strider that can be sold to butchers." );
		      m.PlaySound( 0x451 );
		}

		public CliffStriderPowder( Serial serial ) : base( serial )
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