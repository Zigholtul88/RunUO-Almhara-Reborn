using System;
using Server;

namespace Server.Items
{
	public class CavernMongbatClaw : Item
	{
		[Constructable]
		public CavernMongbatClaw() : this( 1 )
		{
		}

		[Constructable]
		public CavernMongbatClaw( int amount ) : base( 0x2DB8 )
		{
                        Name = "Cavern Mongbat Claw";
			Stackable = true;
			Amount = amount;

			Weight = 0.1;
                        Hue = 1005;
		}

		public override void OnDoubleClick( Mobile m )
		{
			m.SendMessage( "a cavern mongbat claw that can be sold to butchers." );
			m.PlaySound( 422 );
		}

		public CavernMongbatClaw( Serial serial ) : base( serial )
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