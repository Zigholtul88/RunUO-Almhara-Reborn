using System;
using System.Collections;
using Server;
using Server.Gumps;
using Server.Network;
using Server.Mobiles;

namespace Server.Items
{
	public class QuestBulletinBoardZaythalor : Item
	{
		[Constructable]
		public QuestBulletinBoardZaythalor() : base( 7775 )
		{
			Movable = false;
			Light = LightType.Circle300;
			Name = "Quest Bulletin - Zaythalor Forest";
			Hue = 1266;
		}

		public QuestBulletinBoardZaythalor( Serial serial ) : base( serial )
		{
		}

		public override void OnDoubleClick( Mobile from )
		{
			if ( !from.Player )
				return;

			if ( from.InRange( GetWorldLocation(), 1 ) )
				UseBulletinBoard( from );
			else
				from.SendLocalizedMessage( 500446 ); // That is too far away.
		}

		public bool UseBulletinBoard( Mobile m )
		{
			m.CloseGump( typeof( QuestBulletinBoardZaythalorGump ) );
			m.SendGump( new QuestBulletinBoardZaythalorGump( m ) );

			return true;
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

	public class QuestBulletinBoardZaythalorGump : Gump
	{
		public QuestBulletinBoardZaythalorGump( Mobile owner ) : base( 100, 100 )
		{
  			Closable = true;
  			Disposable = true;
  			Dragable = true;
  			Resizable = false;

			AddPage( 0 );
 			AddImage( 3, 7, 2170 );

			AddPage( 1 );
            		AddLabel( 166, 171, 90, @"Zaythalor Tavern Quests" );
			AddButton( 358, 150, 2085, 248, 0, GumpButtonType.Page, 2 );
	    		AddHtml( 123, 198, 244, 120, @"Click the up arrow to bring up the first page.", (bool)false, (bool)true);
            		AddLabel( 127, 351, 90, @"Index Page" );

			AddPage( 2 );
			AddButton( 358, 150, 2084, 248, 0, GumpButtonType.Page, 1 );
            		AddLabel( 129, 170, 90, @"Name: Birdemic" );
	    		AddHtml( 123, 198, 244, 120, @"Info: A troll over by some ruins needs help dealing with an avian situation.<BR><BR>Quester: Vas Gharn<BR><BR>Objective: Slay 30 birds.<BR><BR>Reward: 500 experience points<BR><BR>Reward: Small bag of treasure", (bool)false, (bool)true);
            		AddLabel( 127, 351, 90, @"Page 1" );
			AddButton( 357, 324, 2085, 248, 0, GumpButtonType.Page, 3 );

			AddPage( 3 );
			AddButton( 358, 150, 2084, 248, 0, GumpButtonType.Page, 2 );
            		AddLabel( 129, 170, 90, @"Name: Egg Collector" );
	    		AddHtml( 123, 198, 244, 120, @"Info: A woman over at her farm needs assistance in collecting eggs from some nearby faerie beetles.<BR><BR>Quester: Sabrina the fortune teller<BR><BR>Collect 10 faerie beetle eggs.<BR><BR>Reward: 500 experience points<BR><BR>Reward: Small bag of treasure", (bool)false, (bool)true);
            		AddLabel( 127, 351, 90, @"Page 2" );
			AddButton( 357, 324, 2085, 248, 0, GumpButtonType.Page, 4 );

			AddPage( 4 );
			AddButton( 358, 150, 2084, 248, 0, GumpButtonType.Page, 3 );
            		AddLabel( 129, 170, 90, @"Name: Insecticide" );
	    		AddHtml( 123, 198, 244, 120, @"Info: A forest ranger needs help dealing with a woodland infestation.<BR><BR>Quester: David Cranshaw the forest expert<BR><BR>Objective: Slay 20 black ants.<BR><BR>Reward: 500 experience points<BR><BR>Reward: Small bag of treasure", (bool)false, (bool)true);
            		AddLabel( 127, 351, 90, @"Page 3" );
			AddButton( 357, 324, 2085, 248, 0, GumpButtonType.Page, 5 );

			AddPage( 5 );
			AddButton( 358, 150, 2084, 248, 0, GumpButtonType.Page, 4 );
            		AddLabel( 129, 170, 90, @"Name: Molasses Greed" );
	    		AddHtml( 123, 198, 244, 120, @"Info: A blacksmith has had her order list stolen and needs someone to help get it back.<BR><BR>Quester: Feron the worried smithy<BR><BR>Objective: Retrieve an order list from a troublesome thief.<BR><BR>Reward: 2000 experience points<BR><BR>Reward: Small bag of treasure", (bool)false, (bool)true);
            		AddLabel( 127, 351, 90, @"Page 4" );
			AddButton( 357, 324, 2085, 248, 0, GumpButtonType.Page, 6 );

			AddPage( 6 );
			AddButton( 358, 150, 2084, 248, 0, GumpButtonType.Page, 5 );
            		AddLabel( 129, 170, 90, @"Name: Star Lake Infestation" );
	    		AddHtml( 123, 198, 244, 120, @"Info: A local fisherman is hiring anyone to clean up Star Lake of its crab infestation.<BR><BR>Quester: Travis Crabtree the fisherman<BR><BR>Objective: Slay 10 crabs from Star Lake.<BR><BR>Reward: 500 experience points<BR><BR>Reward: Small bag of treasure", (bool)false, (bool)true);
            		AddLabel( 127, 351, 90, @"Page 5" );
			AddButton( 357, 324, 2085, 248, 0, GumpButtonType.Page, 7 );

			AddPage( 7 );
			AddButton( 358, 150, 2084, 248, 0, GumpButtonType.Page, 6 );
            		AddLabel( 129, 170, 90, @"Name: Thinning Out The Herd" );
	    		AddHtml( 123, 198, 244, 120, @"Info: A strange lopine lunatic calling itself the Rabbit King is currently offering rewards for anyone willing to take care of a hind situation.<BR><BR>Quester: Fluffy Snapper<BR><BR>Objective: Slay 18 hinds.<BR><BR>Reward: 500 experience points<BR><BR>Reward: Small bag of treasure", (bool)false, (bool)true);
            		AddLabel( 127, 351, 90, @"Page 6" );
			AddButton( 357, 324, 2085, 248, 0, GumpButtonType.Page, 8 );

			AddPage( 8 );
			AddButton( 358, 150, 2084, 248, 0, GumpButtonType.Page, 7 );
            		AddLabel( 129, 170, 90, @"Name: Those Blue Bastards" );
	    		AddHtml( 123, 198, 244, 120, @"Info: A farmer over at Popplewell Ranch seems to be having complications involving attacks on his chickens.<BR><BR>Quester: Ruffus Weinstein the farmer<BR><BR>Objective: Slay 10 gizzards.<BR><BR>Reward: 500 experience points<BR><BR>Reward: Small bag of treasure", (bool)false, (bool)true);
            		AddLabel( 127, 351, 90, @"Last Page" );
		}

		public override void OnResponse( NetState sender, RelayInfo info )
		{
			Mobile m = sender.Mobile;
			PlayerMobile player = m as PlayerMobile;

         		switch ( info.ButtonID ) 
         		{ 
            			case 0: //Case uses the ActionIDs defenied above. Case 0 defenies the actions for the button with the action id 0 
            			{ 
               				//Cancel 
               				break; 
            			} 
         		}
      		}
   	}
}
