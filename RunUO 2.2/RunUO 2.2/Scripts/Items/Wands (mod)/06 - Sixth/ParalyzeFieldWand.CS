using System;
using Server;
using Server.Spells.Sixth;
using Server.Targeting;


namespace Server.Items
{
	public class ParalyzeFieldWand : BaseWand
	{
		[Constructable]
		public ParalyzeFieldWand() : base( WandEffect.ParalyzeField, 5, 50 )
		{
                Name = "Paralyze Wand";
		}

		public ParalyzeFieldWand( Serial serial ) : base( serial )
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
			Cast( new ParalyzeFieldSpell( from, this ) );
		}
	}
}