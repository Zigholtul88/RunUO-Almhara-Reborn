using System;
using Server;

namespace Server.Items
{
	public class SandStreakerWings : Item
	{
		[Constructable]
		public SandStreakerWings() : this( 1 )
		{
		}

		[Constructable]
		public SandStreakerWings( int amount ) : base( 0x5726 )
		{
			Name = "Sand Streaker Wings";
			Stackable = true;
			Amount = amount;

			Weight = 0.1;
			Hue = 853;
		}

		public override void OnDoubleClick( Mobile m )
		{
			m.SendMessage( "the wings of a sand streaker that can be sold to butchers." );
			m.PlaySound( 1516 );
		}

		public SandStreakerWings( Serial serial ) : base( serial )
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