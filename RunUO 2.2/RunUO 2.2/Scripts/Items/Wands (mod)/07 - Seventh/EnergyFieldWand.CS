using System;
using Server;
using Server.Spells.Seventh;
using Server.Targeting;


namespace Server.Items
{
	public class EnergyFieldWand : BaseWand
	{
		[Constructable]
		public EnergyFieldWand() : base( WandEffect.EnergyField, 5, 50 )
		{
                Name = "Energy Field Wand";
		}

		public EnergyFieldWand( Serial serial ) : base( serial )
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
			Cast( new EnergyFieldSpell( from, this ) );
		}
	}
}