using System;
using Server;

namespace Server.Items
{
	public class ForgedPendant : SilverNecklace
	{
		[Constructable]
		public ForgedPendant()
		{
                        Name = "ForgedPendant";
                        Hue = 1756;
			LootType = LootType.Blessed;

                        Attributes.DefendChance = 10;

                        SkillBonuses.SetValues(0, SkillName.Blacksmith, 5.0);
                        SkillBonuses.SetValues(0, SkillName.Mining, 5.0);
		}

		public ForgedPendant( Serial serial ) : base( serial )
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