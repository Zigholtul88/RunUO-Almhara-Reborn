using System;
using Server;
using Server.Spells.Seventh;
using Server.Targeting;


namespace Server.Items
{
	public class GateTravelWand : BaseWand
	{
		[Constructable]
		public GateTravelWand() : base( WandEffect.GateTravel, 5, 50 )
		{
                Name = "Gate Travel Wand";
		}

		public GateTravelWand( Serial serial ) : base( serial )
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
			Cast( new GateTravelSpell( from, this ) );
		}
	}
}