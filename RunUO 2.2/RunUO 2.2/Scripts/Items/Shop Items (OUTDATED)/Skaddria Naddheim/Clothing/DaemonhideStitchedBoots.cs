using System;
using Server.Engines.Craft;

namespace Server.Items
{
	public class DaemonhideStitchedBoots : Boots
	{
		public override int BasePhysicalResistance{ get{ return 9; } }
		public override int BaseFireResistance{ get{ return 10; } }
		public override int BaseColdResistance{ get{ return 8; } }
		public override int BasePoisonResistance{ get{ return 7; } }
		public override int BaseEnergyResistance{ get{ return 8; } }

		[Constructable]
		public DaemonhideStitchedBoots()
		{ 
                        Name = "Daemonhide Stitched Boots";
                        Hue = 1461;
		}

		public DaemonhideStitchedBoots( Serial serial ) : base( serial )
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

