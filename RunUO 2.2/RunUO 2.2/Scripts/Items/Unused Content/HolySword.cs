using System;
using Server;

namespace Server.Items
{
	public class HolySword : Longsword
	{
		public override int InitMinHits{ get{ return 50; } }
		public override int InitMaxHits{ get{ return 55; } }

		[Constructable]
		public HolySword()
		{
                        Name = "The Holy Sword";
			Hue = 0x482;

			Slayer = SlayerName.Silver;

			Attributes.AttackChance = 5 + Utility.RandomMinMax( 1, 15 );
			Attributes.WeaponDamage = 5 + Utility.RandomMinMax( 1, 15 );
			Attributes.WeaponSpeed = 5 + Utility.RandomMinMax( 1, 15 );
		}

		public HolySword( Serial serial ) : base( serial )
		{
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );

			writer.WriteEncodedInt( (int) 0 ); // version
		}

		public override void Deserialize(GenericReader reader)
		{
			base.Deserialize( reader );

			int version = reader.ReadEncodedInt();
		}
	}
}