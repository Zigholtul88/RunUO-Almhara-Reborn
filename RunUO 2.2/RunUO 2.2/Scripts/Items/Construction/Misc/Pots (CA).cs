using System;

namespace Server.Items
{
	public class PatternedPot : Item
	{
		[Constructable]
		public PatternedPot() : base(0x3877)
		{
                        Name = "Patterned Pot";
			Weight = 8.0;
		}

		public PatternedPot(Serial serial) : base(serial)
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

	public class WhiteUrn : Item
	{
		[Constructable]
		public WhiteUrn() : base(0x3879)
		{
                        Name = "White Urn";
			Weight = 4.0;
		}

		public WhiteUrn(Serial serial) : base(serial)
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

	public class CeramicPotA : Item
	{
		[Constructable]
		public CeramicPotA() : base(0x388F)
		{
                        Name = "Ceramic Pot";
			Weight = 5.0;
		}

		public CeramicPotA(Serial serial) : base(serial)
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

	public class CeramicPotB : Item
	{
		[Constructable]
		public CeramicPotB() : base(0x3890)
		{
                        Name = "Ceramic Pot";
			Weight = 5.0;
		}

		public CeramicPotB(Serial serial) : base(serial)
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
