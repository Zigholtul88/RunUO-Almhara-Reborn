using System;
using Server.Engines.Craft;

namespace Server.Items
{
	public class ElvenBootsOfMinorProtection : ElvenBoots
	{
		public override int BasePhysicalResistance{ get{ return 15; } }
		public override int BaseFireResistance{ get{ return 15; } }
		public override int BaseColdResistance{ get{ return 15; } }
		public override int BasePoisonResistance{ get{ return 15; } }
		public override int BaseEnergyResistance{ get{ return 15; } }

		[Constructable]
		public ElvenBootsOfMinorProtection()
		{ 
                        Name = "Elven Boots Of Minor Protection";
                        Hue = 1925;
		}

		public ElvenBootsOfMinorProtection( Serial serial ) : base( serial )
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

