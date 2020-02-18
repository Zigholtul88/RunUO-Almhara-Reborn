using System;
using Server;

namespace Server.Items
{
	public class CharredRingOfThePhoenix : BaseRing
	{
		[Constructable]
		public CharredRingOfThePhoenix() : base( 0x108a )
		{
                  Name = "Charred Ring of the Phoenix";
                  Hue = 1281;
			Weight = 0.1;
			Resistances.Fire = 15;
		}

		public CharredRingOfThePhoenix( Serial serial ) : base( serial )
		{
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );
			writer.Write( (int) 0 ); // version
		}

		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader );
			int version = reader.ReadInt();
		}
	}
}