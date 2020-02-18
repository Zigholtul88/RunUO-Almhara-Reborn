using System;
using Server;

namespace Server.Items
{
        [FlipableAttribute(16650, 16651)]
	public class MongbatHideoutBossKey : Item
	{
		[Constructable]
		public MongbatHideoutBossKey() : base( 16651 )
		{
                        Name = "Mongbat Hideout Boss Arena Key";
                        Hue = 1355;
		}

		public override void OnDoubleClick( Mobile m )
		{
			m.SendMessage( "the key needed to pass through the fog gates." );
		}

		public MongbatHideoutBossKey( Serial serial ) : base( serial )
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