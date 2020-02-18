using System;
using Server.Engines.Craft;

namespace Server.Items
{
	public class WovenHedgeCloak : Cloak
	{
		public override int BaseEnergyResistance{ get{ return 10; } }
		public override int BasePoisonResistance{ get{ return 15; } }

		[Constructable]
		public WovenHedgeCloak()
		{ 
                        Name = "Woven Hedge Cloak";
                        Hue = 66;
		}

		public WovenHedgeCloak( Serial serial ) : base( serial )
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

