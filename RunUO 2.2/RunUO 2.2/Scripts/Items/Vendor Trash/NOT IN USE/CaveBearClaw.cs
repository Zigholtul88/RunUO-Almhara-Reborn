using System;
using Server;

namespace Server.Items
{
	public class CaveBearClaw : Item
	{
		[Constructable]
		public CaveBearClaw() : this( 1 )
		{
		}

		[Constructable]
		public CaveBearClaw( int amount ) : base( 0x2DB8 )
		{
                        Name = "Cave Bear Claw";
			Stackable = true;
			Amount = amount;

			Weight = 1.0;
                        Hue = 1810;
		}

		public override void OnDoubleClick( Mobile m )
		{
			m.SendMessage( "a cave bear claw that can be sold to butchers." );
			m.PlaySound( 0xA3 );
		}

		public CaveBearClaw( Serial serial ) : base( serial )
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