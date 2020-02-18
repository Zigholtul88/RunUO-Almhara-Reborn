using System;

namespace Server.Items
{
        [FlipableAttribute(0x1E61, 0x1E68)]
	public class DeerHead : Item
	{
		[Constructable]
		public DeerHead() : base(0x1E61)
		{
                        Name = "Deer Head";
			Weight = 5.0;
		}

		public DeerHead(Serial serial) : base(serial)
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
