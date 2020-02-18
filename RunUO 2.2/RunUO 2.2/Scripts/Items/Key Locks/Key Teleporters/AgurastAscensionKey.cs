using System;
using Server;

namespace Server.Items
{
        [FlipableAttribute(16650, 16651)]
	public class AgurastAscensionKey : Item
	{
		[Constructable]
		public AgurastAscensionKey() : base( 16651 )
		{
                        Name = "Agurast Ascension Key";
                        Hue = 1272;
		}

		public override void OnDoubleClick( Mobile m )
		{
			m.SendMessage( "the key needed to gain access to Agurast Ascension." );
		}

		public AgurastAscensionKey( Serial serial ) : base( serial )
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