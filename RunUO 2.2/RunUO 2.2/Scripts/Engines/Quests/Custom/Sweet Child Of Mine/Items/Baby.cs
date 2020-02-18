using System;
using Server;
using Server.Items;
using Server.Mobiles;
using Server.Engines.Quests;

namespace Server.Engines.Quests.SweetChildOfMine
{
	public class Baby : Item
	{
		[Constructable]
		public Baby() : base( 0x1AE6 )
		{
			Name = "a baby - Quest Item";
			Weight = 2.0;
			Light = LightType.Empty;
			LootType = LootType.Blessed;
		}

		public Baby( Serial serial ) : base( serial )
		{
		}

		public override void OnDoubleClick( Mobile from )
		{
			from.PlaySound( 0x8E );
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
	}
}