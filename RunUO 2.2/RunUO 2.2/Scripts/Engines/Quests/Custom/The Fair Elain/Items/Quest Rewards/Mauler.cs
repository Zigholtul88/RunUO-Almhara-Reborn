using System;
using Server.Network;
using Server.Items;

namespace Server.Items
{
	public class Mauler : Maul
	{
		[Constructable]
		public Mauler()
		{
			Name = "The Mauler";
                        Hue = 901;

			Attributes.WeaponSpeed = 10;
			Attributes.WeaponDamage = 25;
		}

		public Mauler( Serial serial ) : base( serial )
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