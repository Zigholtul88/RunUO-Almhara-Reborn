using System;

namespace Server.Items
{
	[Flipable(0x389D, 0x389E)]
	public class Toilet : Item
	{
		[Constructable]
		public Toilet() : base(0x389D)
		{
			Weight = 20.0;
		}

		public Toilet(Serial serial) : base(serial)
		{
		}

		public override void Serialize(GenericWriter writer)
		{
			base.Serialize(writer);

			writer.Write((int) 0);
		}

		public override void Deserialize(GenericReader reader)
		{
			base.Deserialize(reader);

			int version = reader.ReadInt();
		}
	}
}
