using System;
using Server;

namespace Server.Items
{
	public class RazorbackTooth : Item
	{
		[Constructable]
		public RazorbackTooth() : this( 1 )
		{
		}

		[Constructable]
		public RazorbackTooth( int amount ) : base( 0x5747 )
		{
                  Name = "Razorback Tooth";
			Weight = 0.1;
                  Hue = 2001;
		}

		public override void OnDoubleClick( Mobile m )
		{
			m.SendMessage( "the tooth from a razorback raptor that can be sold to butchers." );
			m.PlaySound( 1573 );
		}

		public RazorbackTooth( Serial serial ) : base( serial )
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