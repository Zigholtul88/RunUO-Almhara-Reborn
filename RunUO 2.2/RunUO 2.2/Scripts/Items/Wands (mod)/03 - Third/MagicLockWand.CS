using System;
using Server;
using Server.Spells.Third;
using Server.Targeting;

namespace Server.Items
{
	public class MagicLockWand : BaseWand
	{
		[Constructable]
		public MagicLockWand() : base( WandEffect.MagicLock, 5, 50 )
		{
                Name = "Magic Lock Wand";
		}

		public MagicLockWand( Serial serial ) : base( serial )
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
			Cast( new MagicLockSpell( from, this ) );
		}
	}
}