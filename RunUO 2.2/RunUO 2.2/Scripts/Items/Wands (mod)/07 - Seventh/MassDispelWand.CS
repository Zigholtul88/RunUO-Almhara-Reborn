using System;
using Server;
using Server.Spells.Seventh;
using Server.Targeting;


namespace Server.Items
{
	public class MassDispelWand : BaseWand
	{
		[Constructable]
		public MassDispelWand() : base( WandEffect.MassDispel, 5, 50 )
		{
                Name = "Mass Dispel Wand";
		}

		public MassDispelWand( Serial serial ) : base( serial )
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
			Cast( new MassDispelSpell( from, this ) );
		}
	}
}