using System;
using Server;

namespace Server.Items
{
	public class RazorwindBow : Yumi
	{
		[Constructable]
		public RazorwindBow() 
		{
                        Name = "Song of the Razorwind";
                        Hue = 1924; 
			LootType = LootType.Blessed;

			SkillBonuses.SetValues( 0, SkillName.Archery, 5 );
			Attributes.AttackChance = 15;
			Attributes.WeaponDamage = 15;
			Attributes.WeaponSpeed = 15;
		}

		public RazorwindBow( Serial serial ) : base( serial )
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
