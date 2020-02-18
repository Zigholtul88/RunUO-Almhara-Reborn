using System;
using Server;

namespace Server.Items
{
        [FlipableAttribute(16650, 16651)]
	public class RoyalTombPyramidKey : Item
	{
		[Constructable]
		public RoyalTombPyramidKey() : base( 16651 )
		{
                        Name = "Royal Tomb Pyramid Key";
                        Hue = 88;
		}

		public override void OnDoubleClick( Mobile m )
		{
			m.SendMessage( "the key needed to gain access to Amul Seketsi Royal Tomb." );
		}

		public RoyalTombPyramidKey( Serial serial ) : base( serial )
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