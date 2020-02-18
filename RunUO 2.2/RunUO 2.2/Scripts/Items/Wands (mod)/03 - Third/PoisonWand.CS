using System;
using Server;
using Server.Spells.Third;
using Server.Targeting;

namespace Server.Items
{
	public class PoisonWand : BaseWand
	{
		[Constructable]
		public PoisonWand() : base( WandEffect.Poison, 5, 50 )
		{
                Name = "Poison Wand";
		}

		public PoisonWand( Serial serial ) : base( serial )
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
			Cast( new PoisonSpell( from, this ) );
		}
	}
}