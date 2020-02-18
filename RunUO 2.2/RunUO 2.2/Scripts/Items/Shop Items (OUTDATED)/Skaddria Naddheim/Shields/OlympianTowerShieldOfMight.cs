using System;
using Server.Network;
using Server.Items;

namespace Server.Items
{
	public class OlympianTowerShieldOfMight : HeaterShield
	{
		public override int BasePhysicalResistance{ get{ return 10; } }
		public override int BaseFireResistance{ get{ return 10; } }
		public override int BasePoisonResistance{ get{ return 10; } }

		[Constructable]
		public OlympianTowerShieldOfMight() 
		{
			Name = "Olympian Tower Shield Of Might";
                        Hue = 1864;
		}

		public OlympianTowerShieldOfMight( Serial serial ) : base( serial )
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