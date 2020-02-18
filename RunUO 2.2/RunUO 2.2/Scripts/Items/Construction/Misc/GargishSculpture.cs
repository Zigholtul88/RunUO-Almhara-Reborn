using System;

namespace Server.Items
{
        [FlipableAttribute(0x403F, 0x4040)]
	public class GargishSculpture : Item
	{
		[Constructable]
		public GargishSculpture() : base(0x403F)
		{
                        Name = "Gargish Sculpture";
			Weight = 10.0;
		}

		public GargishSculpture(Serial serial) : base(serial)
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
