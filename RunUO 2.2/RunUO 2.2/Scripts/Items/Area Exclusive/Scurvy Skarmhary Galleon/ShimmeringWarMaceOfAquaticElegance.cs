using System;
using Server.Network;
using Server.Items;

namespace Server.Items
{
	public class ShimmeringWarMaceOfAquaticElegance : WarMace
	{
		[Constructable]
		public ShimmeringWarMaceOfAquaticElegance() 
		{
			Name = "Shimmering War Mace Of Aquatic Elegance";
			Hue = 1173;
			Attributes.WeaponDamage = 30;
			Attributes.WeaponSpeed = 20;
			Attributes.AttackChance = 20;
			WeaponAttributes.HitLightning = 15;
		}

		public ShimmeringWarMaceOfAquaticElegance( Serial serial ) : base( serial )
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