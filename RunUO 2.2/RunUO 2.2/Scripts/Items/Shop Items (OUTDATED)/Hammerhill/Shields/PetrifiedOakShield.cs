using System;
using Server.Network;
using Server.Items;

namespace Server.Items
{
	public class PetrifiedOakShield : WoodenShield
	{
		public override int BasePhysicalResistance{ get{ return 4; } }
		public override int BaseColdResistance{ get{ return 3; } }
		public override int BasePoisonResistance{ get{ return 2; } }

		[Constructable]
		public PetrifiedOakShield() 
		{
			Name = "Petrified Oak Shield";
                        Hue = 946;
		}

		public PetrifiedOakShield( Serial serial ) : base( serial )
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