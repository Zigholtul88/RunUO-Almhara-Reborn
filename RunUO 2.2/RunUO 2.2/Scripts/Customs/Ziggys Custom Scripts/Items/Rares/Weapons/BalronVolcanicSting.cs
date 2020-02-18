using System;
using Server;

namespace Server.Items
{
	public class BalronVolcanicSting : VikingSword
	{
		[Constructable]
		public BalronVolcanicSting() 
		{
                        Name = "Balron Volcanic Sting";
                        Hue = 1281;

                        Slayer = SlayerName.DaemonDismissal;
			WeaponAttributes.HitFireball = 15;
			Attributes.WeaponDamage = 35;
			Attributes.WeaponSpeed = 25;
			Attributes.AttackChance = 25;
		}

		public override void GetDamageTypes( Mobile wielder, out int phys, out int fire, out int cold, out int pois, out int nrgy, out int chaos, out int direct )
		{
			chaos = direct = cold = pois = 0;
                        phys = 50;
                        fire = nrgy = 25;
		}

		public override bool OnEquip( Mobile m )
		{
		       this.ItemID = 0x13B9;
		       return true;
		}

		public override void OnRemoved( object parent )
		{
		       this.ItemID = 0x2554;
		}

		public BalronVolcanicSting( Serial serial ) : base( serial )
		{
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );

			writer.Write( (int) 0 );
		}

		public override void Deserialize(GenericReader reader)
		{
			base.Deserialize( reader );

			int version = reader.ReadInt();
		}
	}
}
