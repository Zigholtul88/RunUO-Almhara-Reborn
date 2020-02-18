using System;
using System.IO;
using System.Collections;
using Server;
using Server.Items;
using Server.Targeting;
using Server.Network;

namespace Server.Items
{
	public class SoySauce : Item
	{
		[Constructable]
		public SoySauce() : base( 0xE2C )
		{
			Stackable = true;
			Hue = 0x39E;
			Name = "Soy Sauce";
		}

		public SoySauce( Serial serial ) : base( serial )
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