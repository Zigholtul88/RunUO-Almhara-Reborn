using System;
using System.Collections;
using System.Collections.Generic;
using Server;
using Server.Engines.Craft;

namespace Server.Items
{
	public class ConjurersGrimoire : Spellbook, ITokunoDyable
	{
		[Constructable]
		public ConjurersGrimoire() : base()
		{
			Name = "Conjurer's Grimoire";
			Hue = 1157;
			LootType = LootType.Blessed;

                        Slayer = SlayerName.Silver;
                        Attributes.LowerManaCost = 15;
                        Attributes.BonusInt = 5;
                        Attributes.SpellChanneling = 1;
                        Attributes.SpellDamage = 35;
                        SkillBonuses.SetValues(0, SkillName.Magery, 15.0);
		}

		public ConjurersGrimoire( Serial serial ) : base( serial )
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

