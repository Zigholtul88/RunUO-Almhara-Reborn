using System;
using Server.Engines.Craft;

namespace Server.Items
{
	public class DaemonhideStitchedShield : MercenaryShield
	{
		public override int BasePhysicalResistance{ get{ return 10; } }
		public override int BaseFireResistance{ get{ return 10; } }
		public override int BaseColdResistance{ get{ return 9; } }
		public override int BasePoisonResistance{ get{ return 9; } }
		public override int BaseEnergyResistance{ get{ return 9; } }

		[Constructable]
		public DaemonhideStitchedShield()
		{ 
                        Name = "Daemonhide Stitched Shield";
                        Hue = 1461;
		}

		public DaemonhideStitchedShield( Serial serial ) : base( serial )
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

