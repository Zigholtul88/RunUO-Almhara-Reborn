using System;
using Server;

namespace Server.Items
{
	public class SuperShatterPotion : BaseShatterPotion
	{
		public override int MinDamage { get { return 110; } }
		public override int MaxDamage { get { return 125; } }

		[Constructable]
		public SuperShatterPotion() : base( PotionEffect.ExplosionGreater )
		{
                       Name = "Super Ice Blue Potion";
                       Hue = 1152;
		}

		public SuperShatterPotion( Serial serial ) : base( serial )
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