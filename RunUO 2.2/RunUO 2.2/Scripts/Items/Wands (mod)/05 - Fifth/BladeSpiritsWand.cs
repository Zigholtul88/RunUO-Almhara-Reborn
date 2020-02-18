using System;
using Server;
using Server.Spells.Fifth;
using Server.Mobiles;
using Server.Network;
using Server.Targeting;


namespace Server.Items
{
	public class BladeSpiritsWand : BaseWand
	{
		[Constructable]
		public BladeSpiritsWand() : base( WandEffect.BladeSpirits, 5, 50 )
		{
                Name = "Blade Spirits Wand";
		}

		public BladeSpiritsWand( Serial serial ) : base( serial )
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
			Cast( new BladeSpiritsSpell( from, this ) );
		}
	}
}