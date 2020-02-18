using System;
using System.Collections.Generic;
using System.Text;
using Server;
using Server.Items;

namespace Server.Engines.MLQuests.Items
{
	public class BeachBeetleBracelet : BaseBracelet
	{
		[Constructable]
		public BeachBeetleBracelet() : base( 0x1086 )
		{
                        Name = "Beach Beetle Bracelet";
                        Hue = 251;
			Weight = 0.1;
                        LootType = LootType.Blessed;
			Attributes.RegenHits = 1;
			Resistances.Physical = 5;
			SkillBonuses.SetValues( 0, SkillName.MagicResist, 15.0 );
		}

		public BeachBeetleBracelet( Serial serial ) : base( serial )
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