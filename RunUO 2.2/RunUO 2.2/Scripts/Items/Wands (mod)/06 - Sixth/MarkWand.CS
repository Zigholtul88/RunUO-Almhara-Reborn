using System;
using Server;
using Server.Spells.Sixth;
using Server.Targeting;


namespace Server.Items
{
	public class MarkWand : BaseWand
	{
		[Constructable]
		public MarkWand() : base( WandEffect.Mark, 5, 50 )
		{
                Name = "Mark Wand";
		}

		public MarkWand( Serial serial ) : base( serial )
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
			Cast( new MarkSpell( from, this ) );
		}
	}
}