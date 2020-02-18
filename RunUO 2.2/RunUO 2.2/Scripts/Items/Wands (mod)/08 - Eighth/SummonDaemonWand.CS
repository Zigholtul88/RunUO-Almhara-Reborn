using System;
using Server;
using Server.Spells.Eighth;
using Server.Targeting;


namespace Server.Items
{
	public class SummonDaemonWand : BaseWand
	{
		[Constructable]
		public SummonDaemonWand() : base( WandEffect.SummonDaemon, 5, 50 )
		{
                Name = "Summon Daemon Wand";
		}

		public SummonDaemonWand( Serial serial ) : base( serial )
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
			Cast( new SummonDaemonSpell( from, this ) );
		}
	}
}