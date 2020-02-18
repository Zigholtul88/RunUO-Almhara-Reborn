using System;
using Server;
using Server.Spells.Eighth;
using Server.Targeting;


namespace Server.Items
{
	public class EnergyVortexWand : BaseWand
	{
		[Constructable]
		public EnergyVortexWand() : base( WandEffect.EnergyVortex, 5, 50 )
		{
                Name = "Energy Vortex Wand";
		}

		public EnergyVortexWand( Serial serial ) : base( serial )
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
			Cast( new EnergyVortexSpell( from, this ) );
		}
	}
}