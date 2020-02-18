using System;
using System.IO;
using System.Collections;
using Server;
using Server.Items;
using Server.Targeting;
using Server.Network;

namespace Server.Items
{
	public class TomatoSauce : Item
	{
		[Constructable]
		public TomatoSauce() : base( 0x1006 )
		{
			Stackable = true;
			Hue = 0x26;
			Name = "Tomato Sauce";
		}

		public TomatoSauce( Serial serial ) : base( serial )
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