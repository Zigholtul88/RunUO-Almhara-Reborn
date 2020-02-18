using System;
using Server;
using Server.Spells.Fifth;
using Server.Targeting;

namespace Server.Items
{
	public class MindBlastWand : BaseWand
	{
		[Constructable]
		public MindBlastWand() : base( WandEffect.MindBlast, 5, 50 )
		{
                Name = "Mind Blast Wand";
		}

		public MindBlastWand( Serial serial ) : base( serial )
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
			Cast( new MindBlastSpell( from, this ) );
		}
	}
}