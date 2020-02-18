using System;
using Server;

namespace Server.Items
{
        [FlipableAttribute(16650, 16651)]
	public class WhisperingHollowBossKey : Item
	{
		[Constructable]
		public WhisperingHollowBossKey() : base( 16651 )
		{
                        Name = "Whispering Hollow Boss Arena Key";
                        Hue = 98;
		}

		public override void OnDoubleClick( Mobile m )
		{
			m.SendMessage( "the key needed to pass through the fog gates." );
		}

		public WhisperingHollowBossKey( Serial serial ) : base( serial )
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