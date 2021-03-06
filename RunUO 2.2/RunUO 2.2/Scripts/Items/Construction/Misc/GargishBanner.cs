using System;

namespace Server.Items
{
        [FlipableAttribute(0x4037, 0x4038)]
	public class GargishBanner : Item
	{
		[Constructable]
		public GargishBanner() : base(0x4037)
		{
                        Name = "Gargish Banner";
			Weight = 10.0;
		}

		public GargishBanner(Serial serial) : base(serial)
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
