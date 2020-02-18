using System;
using Server;

namespace Server.Items
{
	public class LesserShatterPotion : BaseShatterPotion
	{
		public override int MinDamage { get { return 40; } }
		public override int MaxDamage { get { return 50; } }

		[Constructable]
		public LesserShatterPotion() : base( PotionEffect.ExplosionLesser )
		{
                       Name = "Lesser Ice Blue Potion";
                       Hue = 1152;
		}

		public LesserShatterPotion( Serial serial ) : base( serial )
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