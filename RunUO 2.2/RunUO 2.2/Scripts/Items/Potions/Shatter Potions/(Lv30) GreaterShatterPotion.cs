using System;
using Server;

namespace Server.Items
{
	public class GreaterShatterPotion : BaseShatterPotion
	{
		public override int MinDamage { get { return 95; } }
		public override int MaxDamage { get { return 100; } }

		[Constructable]
		public GreaterShatterPotion() : base( PotionEffect.ExplosionGreater )
		{
                       Name = "Greater Ice Blue Potion";
                       Hue = 1152;
		}

		public GreaterShatterPotion( Serial serial ) : base( serial )
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