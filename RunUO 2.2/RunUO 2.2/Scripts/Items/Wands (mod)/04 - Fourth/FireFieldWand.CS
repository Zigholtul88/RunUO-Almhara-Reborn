using System;
using Server;
using Server.Spells.Fourth;
using Server.Targeting;

namespace Server.Items
{
	public class FireFieldWand : BaseWand
	{
		[Constructable]
		public FireFieldWand() : base( WandEffect.FireField, 5, 50 )
		{
                Name = "Fire Field Wand";
		}

		public FireFieldWand( Serial serial ) : base( serial )
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
			Cast( new FireFieldSpell( from, this ) );
		}
	}
}