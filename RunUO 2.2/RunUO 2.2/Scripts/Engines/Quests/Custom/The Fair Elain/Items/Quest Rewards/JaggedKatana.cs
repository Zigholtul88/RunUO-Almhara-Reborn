using System;
using Server.Network;
using Server.Items;

namespace Server.Items
{
	public class JaggedKatana : Katana
	{
		[Constructable]
		public JaggedKatana()
		{
			Name = "Jagged Katana";
                        Hue = 917;

			WeaponAttributes.HitHarm = 5;
			Attributes.NightSight = 1;
			Attributes.WeaponDamage = 20;
		}

		public JaggedKatana( Serial serial ) : base( serial )
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