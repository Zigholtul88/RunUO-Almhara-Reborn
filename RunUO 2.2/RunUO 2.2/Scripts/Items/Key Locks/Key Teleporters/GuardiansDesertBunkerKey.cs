using System;
using Server;

namespace Server.Items
{
        [FlipableAttribute(16650, 16651)]
	public class GuardiansDesertBunkerKey : Item
	{
		[Constructable]
		public GuardiansDesertBunkerKey() : base( 16651 )
		{
                        Name = "Guardians Desert Bunker Key";
                        Hue = 2213;
		}

		public override void OnDoubleClick( Mobile m )
		{
			m.SendMessage( "the key needed to gain access to Guardians Desert Bunker." );
		}

		public GuardiansDesertBunkerKey( Serial serial ) : base( serial )
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