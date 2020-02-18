using System;
using Server.Network;
using Server.Items;

namespace Server.Items
{
	public class PerfectlyCraftedBucklerOfGloom : Buckler
	{
		public override int BasePhysicalResistance{ get{ return 12; } }
		public override int BaseFireResistance{ get{ return 9; } }
		public override int BaseColdResistance{ get{ return 9; } }

		[Constructable]
		public PerfectlyCraftedBucklerOfGloom() 
		{
			Name = "Perfectly Crafted Buckler Of Gloom";
                        Hue = 2406;
		}

		public PerfectlyCraftedBucklerOfGloom( Serial serial ) : base( serial )
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