using System;
using Server;

namespace Server.Items
{
	public class VerdantSpriteWings : Item
	{
		[Constructable]
		public VerdantSpriteWings() : this( 1 )
		{
		}

		[Constructable]
		public VerdantSpriteWings( int amount ) : base( 0x5726 )
		{
			Name = "Verdant Sprite Wings";
			Stackable = true;
			Amount = amount;

			Weight = 0.1;
			Hue = 71;
		}

		public override void OnDoubleClick( Mobile m )
		{
			m.SendMessage( "the wings of a verdant sprite that can be sold to butchers." );
			m.PlaySound( 0x57B );
		}

		public VerdantSpriteWings( Serial serial ) : base( serial )
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