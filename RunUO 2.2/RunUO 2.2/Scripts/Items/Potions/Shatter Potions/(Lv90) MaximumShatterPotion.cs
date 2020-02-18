using System;
using Server;

namespace Server.Items
{
	public class MaximumShatterPotion : BaseShatterPotion
	{
		public override int MinDamage { get { return 150; } }
		public override int MaxDamage { get { return 200; } }

		[Constructable]
		public MaximumShatterPotion() : base( PotionEffect.ExplosionGreater )
		{
                       Name = "Maximum Ice Blue Potion";
                       Hue = 1152;
		}

		public MaximumShatterPotion( Serial serial ) : base( serial )
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