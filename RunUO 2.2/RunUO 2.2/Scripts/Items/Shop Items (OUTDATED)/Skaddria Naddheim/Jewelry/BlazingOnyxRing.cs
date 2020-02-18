using System;
using Server;

namespace Server.Items
{
	public class BlazingOnyxRing : BaseRing
	{
		[Constructable]
		public BlazingOnyxRing() : base( 0x108a )
		{
                        Name = "Blazing Onyx Ring";
                        Hue = 1161;
			Weight = 0.1;

			Resistances.Fire = 5;
		}

		public BlazingOnyxRing( Serial serial ) : base( serial )
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