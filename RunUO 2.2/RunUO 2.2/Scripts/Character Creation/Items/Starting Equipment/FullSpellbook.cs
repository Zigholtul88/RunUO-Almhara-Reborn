using System;
using System.Collections;
using System.Collections.Generic;
using Server;
using Server.Engines.Craft;

namespace Server.Items
{
	public class FullSpellbook : Spellbook, ITokunoDyable
	{
		[Constructable]
		public FullSpellbook() : base()
		{
                        this.Content = 18446744073709551615;
			LootType = LootType.Blessed;

                        Attributes.SpellChanneling = 1;
			Attributes.SpellDamage = 1;
			Attributes.LowerManaCost = 1;
			Attributes.LowerRegCost = 1;
			Attributes.CastSpeed = 1;
			Attributes.CastRecovery = 1;
		}

		public FullSpellbook( Serial serial ) : base( serial )
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

