using System;
using Server;

namespace Server.Items
{
	public class CrushedShatterGlass : Item
	{
		[Constructable]
		public CrushedShatterGlass() : this( 1 )
		{
		}

		[Constructable]
		public CrushedShatterGlass( int amount ) : base( 0x573B )
		{
			Name = "Crushed Shatter Glass";
			Stackable = true;
			Amount = amount;

			Weight = 0.1;
			Hue = 1926;
		}

		public override void OnDoubleClick( Mobile m )
		{
			m.SendMessage( "glass fragments that can be sold to butchers." );
		}

		public CrushedShatterGlass( Serial serial ) : base( serial )
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