using System;
using Server.Network;
using Server.Items;

namespace Server.Items
{
	public class InfernoStaff : BlackStaff
	{
		[Constructable]
		public InfernoStaff() 
		{
			Name = "Inferno Staff";
			Hue = 1360;
			Attributes.WeaponDamage = 35;
			WeaponAttributes.HitFireball = 15;
			Attributes.SpellChanneling = 1;
		}

		public InfernoStaff( Serial serial ) : base( serial )
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