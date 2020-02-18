using System;
using Server;

namespace Server.Items
{
	public class PeltedMinotaurFur : Item
	{
		[Constructable]
		public PeltedMinotaurFur() : base( 0x11F4 )
		{
                        Name = "Pelted Minotaur Fur";
			Hue = 0x455;

			Weight = 0.5;
		}

		public override void OnDoubleClick( Mobile m )
		{
			m.SendMessage( "the pelted fur of an autumnwood minotaur that can be sold to butchers." );
			m.PlaySound( 0x596 );
		}

		public PeltedMinotaurFur( Serial serial ) : base( serial )
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

