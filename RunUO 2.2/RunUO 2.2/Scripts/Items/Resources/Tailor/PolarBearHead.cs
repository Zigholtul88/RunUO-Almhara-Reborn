using System;

namespace Server.Items
{
        [FlipableAttribute(0x1E65, 0x1E6C)]
	public class PolarBearHead : Item
	{
		[Constructable]
		public PolarBearHead() : base(0x1E65)
		{
                        Name = "Polar Bear Head";
			Weight = 5.0;
		}

		public PolarBearHead(Serial serial) : base(serial)
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
