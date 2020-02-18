using System;
using Server;
using Server.Spells.Fifth;
using Server.Targeting;

namespace Server.Items
{
	public class IncognitoWand : BaseWand
	{
		[Constructable]
		public IncognitoWand() : base( WandEffect.Incognito, 5, 50 )
		{
                Name = "Incognito Wand";
		}

		public IncognitoWand( Serial serial ) : base( serial )
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
			Cast( new IncognitoSpell( from, this ) );
		}
	}
}