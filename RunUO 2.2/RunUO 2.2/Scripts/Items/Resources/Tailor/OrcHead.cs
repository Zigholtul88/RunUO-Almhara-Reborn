using System;

namespace Server.Items
{
        [FlipableAttribute(0x1E64, 0x1E6B)]
	public class OrcHead : Item
	{
		[Constructable]
		public OrcHead() : base(0x1E64)
		{
                        Name = "Orc Head";
			Weight = 2.0;
		}

		public OrcHead(Serial serial) : base(serial)
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
