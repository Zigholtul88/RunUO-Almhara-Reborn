using System;

namespace Server.Items
{
	public class FullNecromancerbook : NecromancerSpellbook, ITokunoDyable
	{
		[Constructable]
		public FullNecromancerbook() : base()
		{
                        this.Content = 65535;
			LootType = LootType.Blessed;

                        Attributes.SpellChanneling = 1;
			Attributes.SpellDamage = 1;
			Attributes.LowerManaCost = 1;
			Attributes.LowerRegCost = 1;
			Attributes.CastSpeed = 1;
			Attributes.CastRecovery = 1;
		}

		public FullNecromancerbook( Serial serial ) : base( serial )
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
