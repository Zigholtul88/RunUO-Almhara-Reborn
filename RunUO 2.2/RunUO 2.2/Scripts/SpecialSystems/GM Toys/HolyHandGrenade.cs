using System;
using Server;

namespace Server.Items
{
	public class HolyHandGrenade : BaseExplosionPotion
	{
		public override int MinDamage { get { return 99999; } }
		public override int MaxDamage { get { return 99999; } }

		[Constructable]
		public HolyHandGrenade() : base( PotionEffect.ExplosionGreater )
		{
                        Name = "Holy Hand Grenade";
		}

		public HolyHandGrenade( Serial serial ) : base( serial )
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