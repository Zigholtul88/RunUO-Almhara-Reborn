using System;
using Server;

namespace Server.Items
{
	public class ShatterPotion : BaseShatterPotion
	{
		public override int MinDamage { get { return 75; } }
		public override int MaxDamage { get { return 80; } }

		[Constructable]
		public ShatterPotion() : base( PotionEffect.Explosion )
		{
                       Name = "Ice Blue Potion";
                       Hue = 1152;
		}

		public ShatterPotion( Serial serial ) : base( serial )
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