using System;
using Server;
using Server.Spells.Fourth;
using Server.Targeting;

namespace Server.Items
{
	public class RecallWand : BaseWand
	{
		[Constructable]
		public RecallWand() : base( WandEffect.Recall, 1, 5 )
		{
                Name = "Recall Wand";
		}

		public RecallWand( Serial serial ) : base( serial )
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
			Cast( new RecallSpell( from, this ) );
		}
	}
}