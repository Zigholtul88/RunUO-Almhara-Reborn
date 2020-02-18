using System;
using Server;
using Server.Spells.Third;
using Server.Targeting;

namespace Server.Items
{
	public class TeleportWand : BaseWand
	{
		[Constructable]
		public TeleportWand() : base( WandEffect.Teleport, 5, 50 )
		{
                Name = "Teleport Wand";
		}

		public TeleportWand( Serial serial ) : base( serial )
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
			Cast( new TeleportSpell( from, this ) );
		}
	}
}