using System;
using Server.Network;
using Server.Items;

namespace Server.Items
{
	public class TerathanCeremonialShield : SpiderShield
	{
		public override int BasePhysicalResistance{ get{ return 15; } }
		public override int BasePoisonResistance{ get{ return 11; } }

		[Constructable]
		public TerathanCeremonialShield() 
		{
			Name = "Terathan Ceremonial Shield";
			Hue = 2128;
		}

		public TerathanCeremonialShield( Serial serial ) : base( serial )
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