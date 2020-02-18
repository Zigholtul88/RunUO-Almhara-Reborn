using System;
using Server.Network;
using Server.Items;

namespace Server.Items
{
	public class DragonhideTowerShield : BlackHeaterShield
	{
		public override int BasePhysicalResistance{ get{ return 6; } }
		public override int BaseFireResistance{ get{ return 12; } }

		[Constructable]
		public DragonhideTowerShield() 
		{
			Name = "Dragonhide Tower Shield";
                        Hue = 39;
		}

		public DragonhideTowerShield( Serial serial ) : base( serial )
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