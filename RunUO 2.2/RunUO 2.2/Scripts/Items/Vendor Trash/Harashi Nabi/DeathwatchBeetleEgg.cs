using System;
using Server;

namespace Server.Items
{
	public class DeathwatchBeetleEgg : Item
	{
		[Constructable]
		public DeathwatchBeetleEgg() : base( 0x41BD )
		{
                        Name = "Deathwatch Beetle Egg";
			Weight = 1.0;
		}

		public override void OnDoubleClick( Mobile m )
		{
			m.SendMessage( "a deathwatch beetle egg that can be sold to butchers." );
			m.PlaySound( 0x4F2 );
		}

		public DeathwatchBeetleEgg( Serial serial ) : base( serial )
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