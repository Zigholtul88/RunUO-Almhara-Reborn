using System;
using Server;
using Server.Spells.First;
using Server.Targeting;

namespace Server.Items
{
	public class MagicArrowWand : BaseWand
	{
		[Constructable]
		public MagicArrowWand() : base( WandEffect.MagicArrow, 5, 50 )
		{
                Name = "Magic Arrow Wand";
		}

		public MagicArrowWand( Serial serial ) : base( serial )
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
			Cast( new MagicArrowSpell( from, this ) );
		}
	}
}