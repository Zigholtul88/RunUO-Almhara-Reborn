using System;
using Server;

namespace Server.Items
{
	public class LesserLovePotion : BaseLovePotion
	{
		public override int MinDamage { get { return 0; } }
		public override int MaxDamage { get { return 0; } }

		public override int MinHeal { get { return 50; } }
		public override int MaxHeal { get { return 100; } }

		[Constructable]
		public LesserLovePotion() : base( PotionEffect.HealLesser )
		{
                        Name = "Lesser Love Potion";
			Hue = 1278;
		}

		public LesserLovePotion( Serial serial ) : base( serial )
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