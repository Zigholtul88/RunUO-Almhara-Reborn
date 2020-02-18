using System;
using Server;
using Server.Spells.Fifth;
using Server.Targeting;


namespace Server.Items
{
	public class SummonCreatureWand : BaseWand
	{
		[Constructable]
		public SummonCreatureWand() : base( WandEffect.SummonCreature, 5, 50 )
		{
                Name = "Summon Creature Wand";
		}

		public SummonCreatureWand( Serial serial ) : base( serial )
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
			Cast( new SummonCreatureSpell( from, this ) );
		}
	}
}