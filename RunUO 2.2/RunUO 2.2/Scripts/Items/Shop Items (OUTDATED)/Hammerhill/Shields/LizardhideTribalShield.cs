using System;
using Server.Network;
using Server.Items;

namespace Server.Items
{
	public class LizardhideTribalShield : GrassShield
	{
		public override int BasePhysicalResistance{ get{ return 3; } }
		public override int BaseFireResistance{ get{ return 5; } }
		public override int BaseColdResistance{ get{ return 2; } }

		[Constructable]
		public LizardhideTribalShield() 
		{
			Name = "Lizardhide Tribal Shield";
                        Hue = 171;
		}

		public LizardhideTribalShield( Serial serial ) : base( serial )
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