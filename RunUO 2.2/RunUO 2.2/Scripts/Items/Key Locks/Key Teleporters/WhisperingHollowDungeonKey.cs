using System;
using Server;

namespace Server.Items
{
        [FlipableAttribute(16650, 16651)]
	public class WhisperingHollowDungeonKey : Item
	{
		[Constructable]
		public WhisperingHollowDungeonKey() : base( 16651 )
		{
                        Name = "Whispering Hollow Dungeon Key";
                        Hue = 18;
		}

		public override void OnDoubleClick( Mobile m )
		{
			m.SendMessage( "the key needed to gain access to Whispering Hollow." );
		}

		public WhisperingHollowDungeonKey( Serial serial ) : base( serial )
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