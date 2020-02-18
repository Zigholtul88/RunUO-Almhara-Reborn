using System;
using Server;

namespace Server.Items
{
        [FlipableAttribute(16650, 16651)]
	public class BankSummoningKey : Item
	{
		[Constructable]
		public BankSummoningKey() : base( 16651 )
		{
                        Name = "Bank Summoning Key";
                        Hue = 86;
		}

		public override void OnDoubleClick( Mobile m )
		{
			m.SendMessage( "a key needed for the bank summoning ball." );
		}

		public BankSummoningKey( Serial serial ) : base( serial )
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