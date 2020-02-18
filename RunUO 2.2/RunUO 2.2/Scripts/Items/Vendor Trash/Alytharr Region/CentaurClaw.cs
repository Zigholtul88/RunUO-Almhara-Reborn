using System;
using Server;

namespace Server.Items
{
	public class CentaurClaw : Item
	{
		[Constructable]
		public CentaurClaw() : this( 1 )
		{
		}

		[Constructable]
		public CentaurClaw( int amount ) : base( 0x2DB8 )
		{
                        Name = "Centaur Claw";
			Stackable = true;
			Amount = amount;

			Weight = 0.1;
		}

		public override void OnDoubleClick( Mobile m )
		{
			m.SendMessage( "a centaur claw that can be sold to butchers." );
			m.PlaySound( 0x2A7 );
		}

		public CentaurClaw( Serial serial ) : base( serial )
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