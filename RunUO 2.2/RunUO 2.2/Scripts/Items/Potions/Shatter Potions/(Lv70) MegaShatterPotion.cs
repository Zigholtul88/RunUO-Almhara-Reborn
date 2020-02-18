using System;
using Server;

namespace Server.Items
{
	public class MegaShatterPotion : BaseShatterPotion
	{
		public override int MinDamage { get { return 125; } }
		public override int MaxDamage { get { return 150; } }

		[Constructable]
		public MegaShatterPotion() : base( PotionEffect.ExplosionGreater )
		{
                       Name = "Mega Ice Blue Potion";
                       Hue = 1152;
		}

		public MegaShatterPotion( Serial serial ) : base( serial )
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