using System;
using Server;
using Server.Spells.Sixth;
using Server.Targeting;


namespace Server.Items
{
	public class InvisibilityWand : BaseWand
	{
		[Constructable]
		public InvisibilityWand() : base( WandEffect.Invisibility, 5, 50 )
		{
                Name = "Invisibility Wand";
		}

		public InvisibilityWand( Serial serial ) : base( serial )
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
			Cast( new InvisibilitySpell( from, this ) );
		}
	}
}