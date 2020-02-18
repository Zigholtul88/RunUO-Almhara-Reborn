using System;
using Server;
using Server.Spells.Seventh;
using Server.Targeting;


namespace Server.Items
{
	public class PolymorphWand : BaseWand
	{
		[Constructable]
		public PolymorphWand() : base( WandEffect.Polymorph, 5, 50 )
		{
                Name = "Polymorph Wand";
		}

		public PolymorphWand( Serial serial ) : base( serial )
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
			Cast( new PolymorphSpell( from, this ) );
		}
	}
}