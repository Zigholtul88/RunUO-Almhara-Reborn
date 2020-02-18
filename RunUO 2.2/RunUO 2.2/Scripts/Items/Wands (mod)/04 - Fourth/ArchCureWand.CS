using System;
using Server;
using Server.Spells.Fourth;
using Server.Targeting;

namespace Server.Items
{
	public class ArchCureWand : BaseWand
	{
		[Constructable]
		public ArchCureWand() : base( WandEffect.ArchCure, 5, 50 )
		{
                Name = "Arch Cure Wand";
		}

		public ArchCureWand( Serial serial ) : base( serial )
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
			Cast( new ArchCureSpell( from, this ) );
		}
	}
}