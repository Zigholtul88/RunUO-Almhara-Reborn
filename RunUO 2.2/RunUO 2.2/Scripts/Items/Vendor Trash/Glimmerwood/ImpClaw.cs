using System;
using Server;

namespace Server.Items
{
	public class ImpClaw : Item
	{
		[Constructable]
		public ImpClaw() : this( 1 )
		{
		}

		[Constructable]
		public ImpClaw( int amount ) : base( 0x2DB8 )
		{
                        Name = "Imp Claw";
			Stackable = true;
			Amount = amount;

			Weight = 0.1;
                        Hue = 1058;
		}

		public override void OnDoubleClick( Mobile m )
		{
			m.SendMessage( "an imp claw that can be sold to butchers." );
			m.PlaySound( 422 );
		}

		public ImpClaw( Serial serial ) : base( serial )
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