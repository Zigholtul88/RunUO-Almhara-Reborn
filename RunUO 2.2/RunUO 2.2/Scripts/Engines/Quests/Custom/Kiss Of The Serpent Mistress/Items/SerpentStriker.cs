using System;
using Server;

namespace Server.Items
{
	public class SerpentStriker : Yumi
	{
		[Constructable]
		public SerpentStriker() 
		{
                        Name = "Serpent Striker";
                        Hue = 1924;

			LootType = LootType.Blessed; 

			SkillBonuses.SetValues( 0, SkillName.Archery, 2 );
			Attributes.AttackChance = 5;
			Attributes.WeaponDamage = 5;
			Attributes.WeaponSpeed = 5;
		}

		public SerpentStriker( Serial serial ) : base( serial )
		{
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );

			writer.Write( (int) 0 );
		}

		public override void Deserialize(GenericReader reader)
		{
			base.Deserialize( reader );

			int version = reader.ReadInt();
		}
	}
}
