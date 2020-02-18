using System;
using Server;

namespace Server.Items
{
	public class BlazingOnyxEarrings : BaseEarrings
	{
		[Constructable]
		public BlazingOnyxEarrings() : base( 0x1087 )
		{
                        Name = "Blazing Onyx Earrings";
                        Hue = 1161;
			Weight = 0.1;

			Resistances.Fire = 5;
		}

		public BlazingOnyxEarrings( Serial serial ) : base( serial )
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