using System;
using System.IO;
using System.Collections;
using Server;
using Server.Items;
using Server.Targeting;
using Server.Network;

namespace Server.Items
{
	public class PeanutButter : Item
	{
		[Constructable]
		public PeanutButter() : base( 0x1006 )
		{
			Stackable = true;
			Hue = 0x413;
			Name = "Peanut Butter";
		}

		public PeanutButter( Serial serial ) : base( serial )
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