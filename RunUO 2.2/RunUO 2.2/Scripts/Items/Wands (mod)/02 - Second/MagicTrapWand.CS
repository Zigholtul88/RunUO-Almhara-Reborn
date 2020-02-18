using System;
using Server;
using Server.Spells.Second;
using Server.Targeting;

namespace Server.Items
{
	public class MagicTrapWand : BaseWand
	{
		[Constructable]
		public MagicTrapWand() : base( WandEffect.MagicTrap, 5, 50 )
		{
                Name = "Magic Trap Wand";
		}

		public MagicTrapWand( Serial serial ) : base( serial )
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
			Cast( new MagicTrapSpell( from, this ) );
		}
	}
}