using System;
using Server;

namespace Server.Items
{
	public class CharredSpriteWings : Item
	{
		[Constructable]
		public CharredSpriteWings() : this( 1 )
		{
		}

		[Constructable]
		public CharredSpriteWings( int amount ) : base( 0x5726 )
		{
			Name = "Charred Sprite Wings";
			Stackable = true;
			Amount = amount;

			Weight = 0.1;
			Hue = 1908;
		}

		public override void OnDoubleClick( Mobile m )
		{
			m.SendMessage( "the wings of a charred sprite that can be sold to butchers." );
			m.PlaySound( 0x57B );
		}

		public CharredSpriteWings( Serial serial ) : base( serial )
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