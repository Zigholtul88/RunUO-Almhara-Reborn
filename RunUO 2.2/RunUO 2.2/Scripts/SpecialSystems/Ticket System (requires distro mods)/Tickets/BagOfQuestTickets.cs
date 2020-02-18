using System;
using Server;
using Server.Items;

namespace Server.Items
{
	public class BagOfQuestTickets : Bag
	{
		[Constructable]
		public BagOfQuestTickets()
		{
			DropItem( new AFlagForHammerhillTicket () );
			DropItem( new BaroqueORamaTicket () );
			DropItem( new BirdemicTicket () );
			DropItem( new EggCollectorTicket () );
			DropItem( new FeeshTendeesTicket () );
			DropItem( new HaldursBaitTicket () );
			DropItem( new InsecticideTicket () );
			DropItem( new LetterDeliveryTicket () );
			DropItem( new StaffOfFlyingMonkeysTicket () );
			DropItem( new StarLakeTicket () );
			DropItem( new StolenNecklaceTicket () );
			DropItem( new ThinningHerdTicket () );
			DropItem( new ThisNotHalloweenTicket () );
			DropItem( new ThoseBlueBastardsTicket () );
			DropItem( new WitchApprenticeTicket () );
			DropItem( new BrightClubTicket () );
			DropItem( new ChampionHunt1Ticket () );
			DropItem( new EnchantedShovelTicket () );
			DropItem( new JadeJungleJemsTicket () );
			DropItem( new KissOfTheSerpentMistressTicket () );
			DropItem( new MolassesGreedTicket () );
			DropItem( new SpiderwickChroniclesTicket () );
			DropItem( new SweetChildTicket () );
			DropItem( new TreasureOfTheSandsTicket () );
		}

		public BagOfQuestTickets( Serial serial ) : base( serial )
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
	}
}