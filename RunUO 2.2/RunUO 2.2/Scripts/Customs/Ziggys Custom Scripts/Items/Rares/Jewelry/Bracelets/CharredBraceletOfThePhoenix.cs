using System;
using Server;

namespace Server.Items
{
	public class CharredBraceletOfThePhoenix : BaseBracelet
	{
		[Constructable]
		public CharredBraceletOfThePhoenix() : base( 0x1086 )
		{
                  Name = "Charred Bracelet of the Phoenix";
                  Hue = 1281;
			Weight = 0.1;
			Resistances.Fire = 15;
		}

		public CharredBraceletOfThePhoenix( Serial serial ) : base( serial )
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