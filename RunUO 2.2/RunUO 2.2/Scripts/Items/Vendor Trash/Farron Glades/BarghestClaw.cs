using System;
using Server;

namespace Server.Items
{
	public class BarghestClaw : Item
	{
		[Constructable]
		public BarghestClaw() : this( 1 )
		{
		}

		[Constructable]
		public BarghestClaw( int amount ) : base( 0x2DB8 )
		{
                        Name = "Barghest Claw";
			Stackable = true;
			Amount = amount;

			Weight = 2.0;
                        Hue = 0x455;
		}

		public override void OnDoubleClick( Mobile m )
		{
			m.SendMessage( "a barghest claw that can be sold to butchers." );
			m.PlaySound( 0x52C );
		}

		public BarghestClaw( Serial serial ) : base( serial )
		{
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );

			writer.Write( (int) 0 );
		}

		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader );

			int version = reader.ReadInt();
		}
	}
}