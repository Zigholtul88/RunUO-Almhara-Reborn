using System;
using System.Collections;
using System.Collections.Generic;
using Server;
using Server.Engines.Craft;

namespace Server.Items
{
	public class ClaininsSpellbook : Spellbook, ITokunoDyable
	{
		[Constructable]
		public ClaininsSpellbook() : base()
		{
			Name = "Clainin's Spellbook";
			Hue = 0x84D;
			LootType = LootType.Blessed;

                        Attributes.LowerRegCost = 15;
                        Attributes.Luck = 200;
                        Attributes.SpellChanneling = 1;
                        Attributes.RegenMana = 3;
		}

		public ClaininsSpellbook( Serial serial ) : base( serial )
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

