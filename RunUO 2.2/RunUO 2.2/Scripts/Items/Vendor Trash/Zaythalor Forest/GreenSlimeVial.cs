using System;
using Server;

namespace Server.Items
{
	public class GreenSlimeVial : Item
	{
		[Constructable]
		public GreenSlimeVial() : this( 1 )
		{
		}

		[Constructable]
		public GreenSlimeVial( int amount ) : base( 0x21FE )
		{
			Name = "Green Slime Vial";
			Stackable = true;
			Amount = amount;

			Weight = 0.1;
                  Hue = 163;
		}

		public override void OnDoubleClick( Mobile m )
		{
			m.SendMessage( "essence of a green slime that can be sold to butchers." );
			m.PlaySound( 456 );
		}

		public GreenSlimeVial( Serial serial ) : base( serial )
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