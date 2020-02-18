using System;
using Server;

namespace Server.Items
{
	public class FatManExplosionPotion  : BaseExplosionPotion
	{
		public override int MinDamage { get { return 500; } }
		public override int MaxDamage { get { return 700; } }

		[Constructable]
		public FatManExplosionPotion () : base( PotionEffect.ExplosionGreater )
		{
                      Name = "Fat Man Maximum Purple Potion";
		}

		public FatManExplosionPotion ( Serial serial ) : base( serial )
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