using System;
using System.Collections;
using Server;
using Server.Gumps;
using Server.Network;
using Server.Mobiles;

namespace Server.Items
{
	public class QuestBulletinBoardHammerhill : Item
	{
		[Constructable]
		public QuestBulletinBoardHammerhill() : base( 7775 )
		{
			Movable = false;
			Light = LightType.Circle300;
			Name = "Quest Bulletin - Hammerhill";
			Hue = 1266;
		}

		public QuestBulletinBoardHammerhill( Serial serial ) : base( serial )
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
			m.CloseGump( typeof( QuestBulletinBoardHammerhillGump ) );
			m.SendGump( new QuestBulletinBoardHammerhillGump( m ) );

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

	public class QuestBulletinBoardHammerhillGump : Gump
	{
		public QuestBulletinBoardHammerhillGump( Mobile owner ) : base( 100, 100 )
		{
  			Closable = true;
  			Disposable = true;
  			Dragable = true;
  			Resizable = false;

			AddPage( 0 );
 			AddImage( 3, 7, 2170 );

			AddPage( 1 );
            		AddLabel( 166, 171, 90, @"Hammerhill Quests" );
			AddButton( 358, 150, 2085, 248, 0, GumpButtonType.Page, 2 );
	    		AddHtml( 123, 198, 244, 120, @"Click the up arrow to bring up the first page.", (bool)false, (bool)true);
            		AddLabel( 127, 351, 90, @"Index Page" );

			AddPage( 2 );
			AddButton( 358, 150, 2084, 248, 0, GumpButtonType.Page, 1 );
            		AddLabel( 129, 170, 90, @"Name: A Flag For Hammerhill" );
	    		AddHtml( 123, 198, 244, 120, @"Info: Local banner crafter seeks out those whom are willing to scour various farms looking for worm silk.<BR><BR>Quester: Ralph<BR><BR>Objective: Collect 12 worm silk.<BR><BR>Reward: banner", (bool)false, (bool)true);
            		AddLabel( 127, 351, 90, @"Page 1" );
			AddButton( 357, 324, 2085, 248, 0, GumpButtonType.Page, 3 );

			AddPage( 3 );
			AddButton( 358, 150, 2084, 248, 0, GumpButtonType.Page, 2 );
            		AddLabel( 129, 170, 90, @"Name: Dead Man Walking" );
	    		AddHtml( 123, 198, 244, 120, @"Info: The local graveyard has grown infested with the wandering undead. Someone needs to put those maggot infested corpses to rest.<BR><BR>Quester: Cloorne<BR><BR>Objective: Slay 5 umkhovus and 5 gualichus.<BR><BR>Reward: 1000 experience points<BR><BR>Reward: medium bag of treasure", (bool)false, (bool)true);
            		AddLabel( 127, 351, 90, @"Page 2" );
			AddButton( 357, 324, 2085, 248, 0, GumpButtonType.Page, 4 );

			AddPage( 4 );
			AddButton( 358, 150, 2084, 248, 0, GumpButtonType.Page, 3 );
            		AddLabel( 129, 170, 90, @"Name: Dragons Dogma" );
	    		AddHtml( 123, 198, 244, 120, @"Info: The lands of Zaythalor have become subjugated to various attacks from black dragons and they seem to have us in quite the pickle.<BR><BR>Quester: Landy<BR><BR>Objective: Slay 3 black dragons.<BR><BR>Reward: 2000 experience points<BR><BR>Reward: 2 large bags of treasure and a child's wallet capable of holding tons of gold without weight limitations", (bool)false, (bool)true);
            		AddLabel( 127, 351, 90, @"Page 3" );
			AddButton( 357, 324, 2085, 248, 0, GumpButtonType.Page, 5 );

			AddPage( 5 );
			AddButton( 358, 150, 2084, 248, 0, GumpButtonType.Page, 4 );
            		AddLabel( 129, 170, 90, @"Name: Feesh Tendees" );
	    		AddHtml( 123, 198, 244, 120, @"Info: Sum1 peeze halp mii. Saum stoopid feesh haus stolen mii roud aund eye need et bak.<BR><BR>Quester: Cottoneye Job<BR><BR>Objective: Locate a stolen fishing rod.<BR><BR>Reward: 1500 experience points<BR><BR>Reward: small bag of treasure", (bool)false, (bool)true);
            		AddLabel( 127, 351, 90, @"Page 4" );
			AddButton( 357, 324, 2085, 248, 0, GumpButtonType.Page, 6 );

			AddPage( 6 );
			AddButton( 358, 150, 2084, 248, 0, GumpButtonType.Page, 5 );
            		AddLabel( 129, 170, 90, @"Name: Industrious As An Ant Lion" );
	    		AddHtml( 123, 198, 244, 120, @"Info: I keep getting harassed by ant lions whenever I visit the sandy dunes. Somebody please do something about them.<BR><BR>Quester: ???<BR><BR>Objective: Slay 12 lesser ant lions.<BR><BR>Reward: 1000 experience points<BR><BR>Reward: large bag of treasure", (bool)false, (bool)true);
            		AddLabel( 127, 351, 90, @"Page 5" );
			AddButton( 357, 324, 2085, 248, 0, GumpButtonType.Page, 7 );

			AddPage( 7 );
			AddButton( 358, 150, 2084, 248, 0, GumpButtonType.Page, 6 );
            		AddLabel( 129, 170, 90, @"Name: Its A Ghastly Job" );
	    		AddHtml( 123, 198, 244, 120, @"Info: The local graveyard has grown infested with the wandering undead. Someone needs to put those maggot infested corpses to rest. Yeah I'm repeating what the previous poster said. What about it?<BR><BR>Quester: Tillanil<BR><BR>Objective: Slay 12 anchimayen.<BR><BR>Reward: 1000 experience points<BR><BR>Reward: medium bag of treasure", (bool)false, (bool)true);
            		AddLabel( 127, 351, 90, @"Page 6" );
			AddButton( 357, 324, 2085, 248, 0, GumpButtonType.Page, 8 );

			AddPage( 8 );
			AddButton( 358, 150, 2084, 248, 0, GumpButtonType.Page, 7 );
            		AddLabel( 129, 170, 90, @"Name: scitsiugniL draziL" );
	    		AddHtml( 123, 198, 244, 120, @"Info: meht htiw laed ot enoemos deen I dna rolahtyaZ tuohguorht stops gniretaw suoirav eht dedavni evah sdraziL retaW.<BR><BR>Quester: naM sdrawkcaB<BR><BR>Objective: sdrazil retaw 21 yalS.<BR><BR>Reward: stniop ecneirepxe 0051<BR><BR>Reward: erusaerT fO gaB egraL", (bool)false, (bool)true);
            		AddLabel( 127, 351, 90, @"Page 7" );
			AddButton( 357, 324, 2085, 248, 0, GumpButtonType.Page, 9 );

			AddPage( 9 );
			AddButton( 358, 150, 2084, 248, 0, GumpButtonType.Page, 8 );
            		AddLabel( 129, 170, 90, @"Name: Mongbat Menance" );
	    		AddHtml( 123, 198, 244, 120, @"Info: Someone is hiring any wouldbe mercenaries to clear out a hideout full of mongbats.<BR><BR>Quester: Unoelil<BR><BR>Objective: Slay 5 of every mongbat variety over in their hideout.<BR><BR>Reward: 2000 experience points<BR><BR>Reward: small, medium and large bags of treasure and a pouch that allows for carrying lots of reagents without weight limitations", (bool)false, (bool)true);
            		AddLabel( 127, 351, 90, @"Page 8" );
			AddButton( 357, 324, 2085, 248, 0, GumpButtonType.Page, 10 );

			AddPage( 10 );
			AddButton( 358, 150, 2084, 248, 0, GumpButtonType.Page, 9 );
            		AddLabel( 129, 170, 90, @"Name: Roll The Bones" );
	    		AddHtml( 123, 198, 244, 120, @"Info: A young woman in town needs assistance with putting a few undead down to rest.<BR><BR>Quester: Cillitha<BR><BR>Objective: Slay 8 gualichai.<BR><BR>Reward: 1000 experience points<BR><BR>Reward: small bag of treasure", (bool)false, (bool)true);
            		AddLabel( 127, 351, 90, @"Page 9" );
			AddButton( 357, 324, 2085, 248, 0, GumpButtonType.Page, 11 );

			AddPage( 11 );
			AddButton( 358, 150, 2084, 248, 0, GumpButtonType.Page, 10 );
            		AddLabel( 129, 170, 90, @"Name: Sewer In A Half Shell" );
	    		AddHtml( 123, 198, 244, 120, @"Info: ???<BR><BR>Quester: Trisha<BR><BR>Objective: ???<BR><BR>Reward: ???", (bool)false, (bool)true);
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
