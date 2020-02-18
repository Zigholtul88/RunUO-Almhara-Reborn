using System;
using Server;
using Server.Spells.Third;
using Server.Targeting;

namespace Server.Items
{
	public class UnlockWand : BaseWand
	{
		[Constructable]
		public UnlockWand() : base( WandEffect.Unlock, 5, 50 )
		{
                Name = "Unlock Wand";
		}

		public UnlockWand( Serial serial ) : base( serial )
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
			Cast( new UnlockSpell( from, this ) );
		}
	}
}