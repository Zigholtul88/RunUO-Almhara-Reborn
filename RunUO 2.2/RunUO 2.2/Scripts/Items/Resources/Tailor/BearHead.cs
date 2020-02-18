using System;

namespace Server.Items
{
        [FlipableAttribute(0x1E60, 0x1E67)]
	public class BearHead : Item
	{
		[Constructable]
		public BearHead() : base(0x1E60)
		{
                        Name = "Bear Head";
			Weight = 5.0;
		}

		public BearHead(Serial serial) : base(serial)
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
