using System;
using Server.Network;
using Server.Items;

namespace Server.Items
{
	public class ResilientOakShield : WoodenShield
	{
		public override int InitMinHits{ get{ return 28; } }
		public override int InitMaxHits{ get{ return 30; } }

		[Constructable]
		public ResilientOakShield() 
		{
			Name = "Resilient Oak Shield";

			Attributes.BonusStr = 3;
		}

		public ResilientOakShield( Serial serial ) : base( serial )
		{
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );

			writer.Write( (int) 0 ); // version
		}

		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader );

			int version = reader.ReadInt();
		}
	}
}