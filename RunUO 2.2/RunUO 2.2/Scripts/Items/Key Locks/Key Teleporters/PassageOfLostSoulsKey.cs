using System;
using Server;

namespace Server.Items
{
        [FlipableAttribute(16650, 16651)]
	public class PassageOfLostSoulsKey : Item
	{
		[Constructable]
		public PassageOfLostSoulsKey() : base( 16651 )
		{
                        Name = "Passage Of Lost Souls Key";
                        Hue = 1266;
		}

		public override void OnDoubleClick( Mobile m )
		{
			m.SendMessage( "the key needed to gain access to Passage of Lost Souls." );
		}

		public PassageOfLostSoulsKey( Serial serial ) : base( serial )
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