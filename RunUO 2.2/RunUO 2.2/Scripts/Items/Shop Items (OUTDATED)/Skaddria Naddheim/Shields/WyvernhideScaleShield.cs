using System;
using Server.Network;
using Server.Items;

namespace Server.Items
{
	public class WyvernhideScaleShield : WoodenDragonShield
	{
		public override int BasePhysicalResistance{ get{ return 4; } }
		public override int BasePoisonResistance{ get{ return 11; } }

		[Constructable]
		public WyvernhideScaleShield() 
		{
			Name = "Wyvernhide Scale Shield";
                        Hue = 2107;
		}

		public WyvernhideScaleShield( Serial serial ) : base( serial )
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