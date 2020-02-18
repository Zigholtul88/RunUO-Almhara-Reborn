using System;
using Server;

namespace Server.Items
{
	public class GreenAllosaurClaw : Item
	{
		[Constructable]
		public GreenAllosaurClaw() : this( 1 )
		{
		}

		[Constructable]
		public GreenAllosaurClaw( int amount ) : base( 0x2DB8 )
		{
                        Name = "Green Allosaur Claw";
			Stackable = true;
			Amount = amount;

			Weight = 2.0;
                        Hue = 67;
		}

		public override void OnDoubleClick( Mobile m )
		{
			m.SendMessage( "a green allosaur claw that can be sold to butchers." );
			m.PlaySound( 651 );
		}

		public GreenAllosaurClaw( Serial serial ) : base( serial )
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