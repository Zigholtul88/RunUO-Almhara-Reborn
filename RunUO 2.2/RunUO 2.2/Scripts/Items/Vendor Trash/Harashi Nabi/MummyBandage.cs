using System;
using Server;

namespace Server.Items
{
	public class MummyBandage : Item
	{
		[Constructable]
		public MummyBandage() : this( 1 )
		{
		}

		[Constructable]
		public MummyBandage( int amount ) : base( 0xE21 )
		{
			Name = "Mummy Bandage";
			Stackable = true;
			Amount = amount;

			Weight = 0.1;
			Hue = 176;
		}

		public override void OnDoubleClick( Mobile m )
		{
			m.SendMessage( "bandage of a mummy that can be sold to butchers." );
			m.PlaySound( 471 );
		}

		public MummyBandage( Serial serial ) : base( serial )
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