using System;
using Server;
using Server.Spells.Fifth;
using Server.Targeting;

namespace Server.Items
{
	public class MagicReflectWand : BaseWand
	{
		[Constructable]
		public MagicReflectWand() : base( WandEffect.MagicReflect, 5, 50 )
		{
                Name = "Magic Reflect Wand";
		}

		public MagicReflectWand( Serial serial ) : base( serial )
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
			Cast( new MagicReflectSpell( from, this ) );
		}
	}
}