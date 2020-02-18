using System;
using Server;
using Server.Mobiles;
using Server.Engines.Quests;

namespace Server.Engines.Quests.StolenNecklace
{
	public class QuestStolenNecklace : QuestItem
	{
		[Constructable]
		public QuestStolenNecklace() : base( 0x1F08 )
		{
			Name = "Raina's Necklace - Quest Item";
			Weight = 1.0;
                        Hue = 1278;
			LootType = LootType.Blessed;
		}

		public QuestStolenNecklace( Serial serial ) : base( serial )
		{
		}

		public override bool CanDrop( PlayerMobile player )
		{
			StolenNecklaceQuest qs = player.Quest as StolenNecklaceQuest;

			if ( qs == null )
				return true;

			/*return !qs.IsObjectiveInProgress( typeof( ReturnStolenNecklaceObjective ) );*/
			return false;
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