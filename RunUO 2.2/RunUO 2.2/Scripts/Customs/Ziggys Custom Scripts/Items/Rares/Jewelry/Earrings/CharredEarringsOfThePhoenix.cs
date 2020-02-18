using System;
using Server;

namespace Server.Items
{
	public class CharredEarringsOfThePhoenix : BaseEarrings
	{
		[Constructable]
		public CharredEarringsOfThePhoenix() : base( 0x1087 )
		{
                  Name = "Charred Earrings of the Phoenix";
                  Hue = 1281;
			Weight = 0.1;
			Resistances.Fire = 15;
		}

		public CharredEarringsOfThePhoenix( Serial serial ) : base( serial )
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