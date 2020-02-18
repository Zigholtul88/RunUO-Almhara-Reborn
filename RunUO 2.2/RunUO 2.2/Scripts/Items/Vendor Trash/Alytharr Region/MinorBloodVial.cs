using System;
using Server;

namespace Server.Items
{
	public class MinorBloodVial : Item
	{
		[Constructable]
		public MinorBloodVial() : this( 1 )
		{
		}

		[Constructable]
		public MinorBloodVial( int amount ) : base( 0x21FE )
		{
			Name = "Minor Blood Vial";
			Stackable = true;
			Amount = amount;

			Weight = 0.1;
                  Hue = 2118;
		}

		public override void OnDoubleClick( Mobile m )
		{
			m.SendMessage( "essence of a minor blood elemental that can be sold to butchers." );
			m.PlaySound( 278 );
		}

		public MinorBloodVial( Serial serial ) : base( serial )
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