using System;
using Server;
using Server.Items;
using Server.Mobiles;
using Server.Network; 
using Server.Spells;

namespace Server.Items
{
	public class MoongateTeleporter : Teleporter
	{
		[Constructable]
		public MoongateTeleporter()
		{
                        Name = "a moongate to some unknown location";
			Light = LightType.Circle300;
                        ItemID = 0xF6C;

			Movable = false;
			Visible = true;
		}

		public MoongateTeleporter( Serial serial ) : base( serial )
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