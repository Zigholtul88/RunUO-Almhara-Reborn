using System;
using Server;
using Server.Spells.Seventh;
using Server.Targeting;


namespace Server.Items
{
	public class ChainLightningWand : BaseWand
	{
		[Constructable]
		public ChainLightningWand() : base( WandEffect.ChainLightning, 5, 50 )
		{
                Name = "Chain Lightning Wand";
		}

		public ChainLightningWand( Serial serial ) : base( serial )
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

		public override void OnWandUse( Mobile from )
		{
			Cast( new ChainLightningSpell( from, this ) );
		}
	}
}