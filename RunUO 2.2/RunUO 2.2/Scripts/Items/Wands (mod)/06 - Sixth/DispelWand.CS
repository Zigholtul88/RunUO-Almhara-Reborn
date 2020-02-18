using System;
using Server;
using Server.Spells.Sixth;
using Server.Targeting;


namespace Server.Items
{
	public class DispelWand : BaseWand
	{
		[Constructable]
		public DispelWand() : base( WandEffect.Dispel, 5, 50 )
		{
                Name = "Dispel Wand";
		}

		public DispelWand( Serial serial ) : base( serial )
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
			Cast( new DispelSpell( from, this ) );
		}
	}
}