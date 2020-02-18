using System;

namespace Server.Items
{
	public class OssianGrimoire : NecromancerSpellbook, ITokunoDyable
	{
		public override int LabelNumber { get { return 1078148; } } // Ossian Grimoire

		[Constructable]
		public OssianGrimoire() : base()
		{
			LootType = LootType.Blessed;

			SkillBonuses.SetValues( 0, SkillName.Necromancy, 20.0 );
			Attributes.CastSpeed = 1;
			Attributes.RegenMana = 5;
                        Attributes.SpellChanneling = 1;
		}

		public OssianGrimoire( Serial serial ) : base( serial )
		{
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );

			writer.WriteEncodedInt( 0 ); //version
		}

		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader );

			int version = reader.ReadEncodedInt();
		}
	}
}
