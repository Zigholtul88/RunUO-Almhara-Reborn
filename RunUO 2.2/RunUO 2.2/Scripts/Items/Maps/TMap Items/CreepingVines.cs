using System;

namespace Server.Items
{
	public class CreepingVines : Item
	{
		[Constructable]
		public CreepingVines() : base( Utility.RandomList( 0x4792, 0x4793, 0x4794, 0x4795 ) )
		{
            Name = "creeping vine";
			Weight = 1.0;
		}

		public CreepingVines(Serial serial) : base(serial)
		{
		}

		public override bool ForceShowProperties{ get{ return ObjectPropertyList.Enabled; } }

		public override void Serialize(GenericWriter writer)
		{
			base.Serialize(writer);

			writer.Write((int) 0); // version
		}

		public override void Deserialize(GenericReader reader)
		{
			base.Deserialize(reader);

			int version = reader.ReadInt();
		}
	}
}