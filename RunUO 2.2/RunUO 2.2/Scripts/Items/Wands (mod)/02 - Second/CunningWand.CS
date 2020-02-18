using System;
using Server;
using Server.Spells.Second;
using Server.Targeting;

namespace Server.Items
{
	public class CunningWand : BaseWand
	{
		[Constructable]
		public CunningWand() : base( WandEffect.Cunning, 5, 50 )
		{
                Name = "Cunning Wand";
		}

		public CunningWand( Serial serial ) : base( serial )
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
			Cast( new CunningSpell( from, this ) );
		}
	}
}