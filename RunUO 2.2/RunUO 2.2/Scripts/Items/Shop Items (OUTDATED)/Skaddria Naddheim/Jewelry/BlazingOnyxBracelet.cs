using System;
using Server;

namespace Server.Items
{
	public class BlazingOnyxBracelet : BaseBracelet
	{
		[Constructable]
		public BlazingOnyxBracelet() : base( 0x1086 )
		{
                        Name = "Blazing Onyx Bracelet";
                        Hue = 1161;
			Weight = 0.1;

			Resistances.Fire = 5;
		}

		public BlazingOnyxBracelet( Serial serial ) : base( serial )
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