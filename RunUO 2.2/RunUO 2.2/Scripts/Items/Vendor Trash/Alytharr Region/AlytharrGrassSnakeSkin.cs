using System;
using Server;

namespace Server.Items
{
	public class AlytharrGrassSnakeSkin : Item
	{
		[Constructable]
		public AlytharrGrassSnakeSkin() : this( 1 )
		{
		}

		[Constructable]
		public AlytharrGrassSnakeSkin( int amount ) : base( 0x5744 )
		{
			Name = "Alytharr Grass Snake Skin";
			Stackable = true;
			Amount = amount;

			Weight = 0.1;
                        Hue = 372;
		}

		public override void OnDoubleClick( Mobile m )
		{
			m.SendMessage( "outer skin of an alytharr grass snake that can be sold to butchers." );
		        m.PlaySound( 0xDB );

		}

		public AlytharrGrassSnakeSkin( Serial serial ) : base( serial )
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