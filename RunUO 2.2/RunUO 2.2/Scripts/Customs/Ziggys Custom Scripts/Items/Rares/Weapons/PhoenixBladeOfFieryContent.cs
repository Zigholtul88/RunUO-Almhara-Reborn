using System;
using Server.Network;
using Server.Items;

namespace Server.Items
{
	public class PhoenixBladeOfFieryContent : Katana
	{
		[Constructable]
		public PhoenixBladeOfFieryContent() 
		{
			Name = "Phoenix Blade Of Fiery Content";
			Hue = 43;
			Attributes.WeaponDamage = 30;
			Attributes.WeaponSpeed = 20;
			Attributes.AttackChance = 25;
			WeaponAttributes.HitFireball = 15;
		}

		public override void GetDamageTypes( Mobile wielder, out int phys, out int fire, out int cold, out int pois, out int nrgy, out int chaos, out int direct )
		{
			cold = pois = nrgy = chaos = direct = 0;
                  phys = 40;
			fire = 60;
		}

		public PhoenixBladeOfFieryContent( Serial serial ) : base( serial )
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