using System;
using Server;
using Server.Spells.Second;
using Server.Targeting;

namespace Server.Items
{
	public class StrengthWand : BaseWand
	{
		[Constructable]
		public StrengthWand() : base( WandEffect.Strength, 5, 50 )
		{
                Name = "Strength Wand";
		}

		public StrengthWand( Serial serial ) : base( serial )
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
			Cast( new StrengthSpell( from, this ) );
		}
	}
}