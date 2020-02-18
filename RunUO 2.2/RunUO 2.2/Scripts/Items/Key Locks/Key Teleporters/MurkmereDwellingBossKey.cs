using System;
using Server;

namespace Server.Items
{
        [FlipableAttribute(16650, 16651)]
	public class MurkmereDwellingBossKey : Item
	{
		[Constructable]
		public MurkmereDwellingBossKey() : base( 16651 )
		{
                        Name = "Murkmere Dwelling Boss Arena Key";
                        Hue = 1291;
		}

		public override void OnDoubleClick( Mobile m )
		{
			m.SendMessage( "the key needed to pass through the mysterious columns." );
		}

		public MurkmereDwellingBossKey( Serial serial ) : base( serial )
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