using System;
using Server;

namespace Server.Items
{
	public class GryphonClaw : Item
	{
		[Constructable]
		public GryphonClaw() : this( 1 )
		{
		}

		[Constructable]
		public GryphonClaw( int amount ) : base( 0x2DB8 )
		{
                        Name = "Gryphon Claw";
			Stackable = true;
			Amount = amount;

			Weight = 2.0;
                        Hue = 0x457;
		}

		public override void OnDoubleClick( Mobile m )
		{
			m.SendMessage( "a gryphon claw that can be sold to butchers." );
			m.PlaySound( 0x2EE );
		}

		public GryphonClaw( Serial serial ) : base( serial )
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