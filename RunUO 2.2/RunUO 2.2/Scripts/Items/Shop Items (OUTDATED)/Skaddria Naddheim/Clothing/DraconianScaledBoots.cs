using System;
using Server.Engines.Craft;

namespace Server.Items
{
	public class DraconianScaledBoots : HighBoots
	{
		public override int BasePhysicalResistance{ get{ return 11; } }
		public override int BaseFireResistance{ get{ return 10; } }
		public override int BaseColdResistance{ get{ return 6; } }
		public override int BasePoisonResistance{ get{ return 5; } }
		public override int BaseEnergyResistance{ get{ return 4; } }

		[Constructable]
		public DraconianScaledBoots()
		{ 
                        Name = "Draconian Scaled Boots";
                        Hue = 2119;
		}

		public DraconianScaledBoots( Serial serial ) : base( serial )
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

