using System;
using Server;

namespace Server.Items
{
	public class BraceletOfResilience : GoldBracelet
	{
		public override int LabelNumber{ get{ return 1077627; } } // Bracelet of Resilience

		[Constructable]
		public BraceletOfResilience()
		{
			Attributes.DefendChance = 10;
			Resistances.Fire = 10;
			Resistances.Cold = 10;
			Resistances.Poison = 10;
			Resistances.Energy = 10;
		}

		public BraceletOfResilience( Serial serial ) : base( serial )
		{
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );

			writer.WriteEncodedInt( 0 ); // version
		}

		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader );

			int version = reader.ReadEncodedInt();
		}
	}
}
