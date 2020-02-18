using System;
using System.Collections;
using Server;
using Server.Gumps;
using Server.Network;
using Server.Mobiles;

namespace Server.Items
{
	public class QuestBulletinBoardElmhaven : Item
	{
		[Constructable]
		public QuestBulletinBoardElmhaven() : base( 7775 )
		{
			Movable = false;
			Light = LightType.Circle300;
			Name = "Quest Bulletin - Elmhaven";
			Hue = 1266;
		}

		public QuestBulletinBoardElmhaven( Serial serial ) : base( serial )
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
			m.CloseGump( typeof( QuestBulletinBoardElmhavenGump ) );
			m.SendGump( new QuestBulletinBoardElmhavenGump( m ) );

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

	public class QuestBulletinBoardElmhavenGump : Gump
	{
		public QuestBulletinBoardElmhavenGump( Mobile owner ) : base( 100, 100 )
		{
  			Closable = true;
  			Disposable = true;
  			Dragable = true;
  			Resizable = false;

			AddPage( 0 );
 			AddImage( 3, 7, 2170 );

			AddPage( 1 );
            		AddLabel( 166, 171, 90, @"Elmhaven Quests" );
			AddButton( 358, 150, 2085, 248, 0, GumpButtonType.Page, 2 );
	    		AddHtml( 123, 198, 244, 120, @"Click the up arrow to bring up the first page.", (bool)false, (bool)true);
            		AddLabel( 127, 351, 90, @"Index Page" );

			AddPage( 2 );
			AddButton( 358, 150, 2084, 248, 0, GumpButtonType.Page, 1 );
            		AddLabel( 129, 170, 90, @"Name: A Big Job" );
	    		AddHtml( 123, 198, 244, 120, @"Info: In the mood for giant slaying. I think I can help you.<BR><BR>Quester: Alejaha<BR><BR>Objective: Slay 5 ogres and 5 ettins.<BR><BR>Reward: 1500 experience points<BR><BR>Reward: medium and large bags of treasure", (bool)false, (bool)true);
            		AddLabel( 127, 351, 90, @"Page 1" );
			AddButton( 357, 324, 2085, 248, 0, GumpButtonType.Page, 3 );

			AddPage( 3 );
			AddButton( 358, 150, 2084, 248, 0, GumpButtonType.Page, 2 );
            		AddLabel( 129, 170, 90, @"Name: Champion Hunt 1" );
	    		AddHtml( 123, 198, 244, 120, @"Info: Fharlune is currently hosting the towns annual champion hunt and she needs members to seek out some legendary beasts.<BR><BR>Quester: Fharlune<BR><BR>Objective: Slay 3 champions.<BR><BR>Reward: 2000 experience points<BR><BR>Reward: a unique one of a time bow along with a pouch capable of storing gems without weight limitations", (bool)false, (bool)true);
            		AddLabel( 127, 351, 90, @"Page 2" );
			AddButton( 357, 324, 2085, 248, 0, GumpButtonType.Page, 4 );

			AddPage( 4 );
			AddButton( 358, 150, 2084, 248, 0, GumpButtonType.Page, 3 );
            		AddLabel( 129, 170, 90, @"Name: Clakk Trapp" );
	    		AddHtml( 123, 198, 244, 120, @"Info: Oy vey, I'm deep in the gefilte fish and I'm chalisching one of you mensches to do something with this nudnik. L'chaim to any of you heymish tsaddiks.<BR><BR>Quester: Schlomo Shamttenstein<BR><BR>Objective: Slay Clikk Clakk.<BR><BR>Reward: 2000 experience points<BR><BR>Reward: medium and 2 large bags of shekels", (bool)false, (bool)true);
            		AddLabel( 127, 351, 90, @"Page 3" );
			AddButton( 357, 324, 2085, 248, 0, GumpButtonType.Page, 5 );

			AddPage( 5 );
			AddButton( 358, 150, 2084, 248, 0, GumpButtonType.Page, 4 );
            		AddLabel( 129, 170, 90, @"Name: Crab Catchers" );
	    		AddHtml( 123, 198, 244, 120, @"Info: I need help. My flock of sheep have been subjugated to several attacks by sand crabs and I'll hire anyone willing to down them.<BR><BR>Quester: Diana McThornbody<BR><BR>Objective: Collect 6 sand crab mandibles.<BR><BR>Reward: 1500 experience points<BR><BR>Reward: large bag of treasure", (bool)false, (bool)true);
            		AddLabel( 127, 351, 90, @"Page 4" );
			AddButton( 357, 324, 2085, 248, 0, GumpButtonType.Page, 6 );

			AddPage( 6 );
			AddButton( 358, 150, 2084, 248, 0, GumpButtonType.Page, 5 );
            		AddLabel( 129, 170, 90, @"Name: Forked Tongues" );
	    		AddHtml( 123, 198, 244, 120, @"Info: Are you in the mood to exercise your might against some pesky reptilians? Seek me out and I'll fill you in on the details.<BR><BR>Quester: Lohn<BR><BR>Objective: Slay 10 lizardmen.<BR><BR>Reward: 1500 experience points<BR><BR>Reward: medium bag of treasure", (bool)false, (bool)true);
            		AddLabel( 127, 351, 90, @"Page 5" );
			AddButton( 357, 324, 2085, 248, 0, GumpButtonType.Page, 7 );

			AddPage( 7 );
			AddButton( 358, 150, 2084, 248, 0, GumpButtonType.Page, 6 );
            		AddLabel( 129, 170, 90, @"Name: Impish Delights" );
	    		AddHtml( 123, 198, 244, 120, @"Info: IMPS! IMPS, IMPS, IMPS!<BR><BR>Quester: Athailon<BR><BR>Objective: Slay 4 imps.<BR><BR>Reward: 1000 experience points<BR><BR>Reward: medium bag of treasure", (bool)false, (bool)true);
            		AddLabel( 127, 351, 90, @"Page 6" );
			AddButton( 357, 324, 2085, 248, 0, GumpButtonType.Page, 8 );

			AddPage( 8 );
			AddButton( 358, 150, 2084, 248, 0, GumpButtonType.Page, 7 );
            		AddLabel( 129, 170, 90, @"Name: Jade Jungle Jems" );
	    		AddHtml( 123, 198, 244, 120, @"Info: Fed up with your current armor setup? Want something a bit more fanciful? Don't worry, I think I got your back.<BR><BR>Quester: Filkien<BR><BR>Objective: Collect 13 pieces of serpentine jade.<BR><BR>Reward: 500 experience points<BR><BR>Reward: a set of serpentine jade ringmail armor", (bool)false, (bool)true);
            		AddLabel( 127, 351, 90, @"Page 7" );
			AddButton( 357, 324, 2085, 248, 0, GumpButtonType.Page, 9 );

			AddPage( 9 );
			AddButton( 358, 150, 2084, 248, 0, GumpButtonType.Page, 8 );
            		AddLabel( 129, 170, 90, @"Name: Lagarto Lunancy" );
	    		AddHtml( 123, 198, 244, 120, @"Info: Me no speaka your language.<BR><BR>Quester: Diego Martinez<BR><BR>Objective: Lizadmen, yes.<BR><BR>Reward: 1500 experience points<BR><BR>Reward: money homie", (bool)false, (bool)true);
            		AddLabel( 127, 351, 90, @"Page 8" );
			AddButton( 357, 324, 2085, 248, 0, GumpButtonType.Page, 10 );

			AddPage( 10 );
			AddButton( 358, 150, 2084, 248, 0, GumpButtonType.Page, 9 );
            		AddLabel( 129, 170, 90, @"Name: Orcish Elite" );
	    		AddHtml( 123, 198, 244, 120, @"Info: Foul brutes! I need a few of them disposed of. What's say you?<BR><BR>Quester: Sleen<BR><BR>Objective: Slay 6 orc bombers and 4 orc captains.<BR><BR>Reward: 1500 experience points<BR><BR>Reward: large bag of treasure", (bool)false, (bool)true);
            		AddLabel( 127, 351, 90, @"Page 9" );
			AddButton( 357, 324, 2085, 248, 0, GumpButtonType.Page, 11 );

			AddPage( 11 );
			AddButton( 358, 150, 2084, 248, 0, GumpButtonType.Page, 10 );
            		AddLabel( 129, 170, 90, @"Name: Puddle Of Mud" );
	    		AddHtml( 123, 198, 244, 120, @"Info: Greetings to any who take heed of this notice. Recently I've had trouble with a particular ooze oddity and I would like some assistance in dealing with it. Please contact me for any more information.<BR><BR>Quester: Daryl Mclancaster<BR><BR>Objective: Slay Puddles.<BR><BR>Reward: 2000 experience points<BR><BR>Reward: 2x large bag of treasure", (bool)false, (bool)true);
            		AddLabel( 127, 351, 90, @"Page 10" );
			AddButton( 357, 324, 2085, 248, 0, GumpButtonType.Page, 12 );

			AddPage( 12 );
			AddButton( 358, 150, 2084, 248, 0, GumpButtonType.Page, 11 );
            		AddLabel( 129, 170, 90, @"Name: Rhino Rhombet" );
	    		AddHtml( 123, 198, 244, 120, @"Info: Dagnabit, that dobber is gunna be the death of me. Listen here yer mawkits, I need someone to deal a nasty blow to that basturt and I'll be a happy lil quine in the end.<BR><BR>Quester: Maevlan<BR><BR>Objective: Slay Rhinox.<BR><BR>Reward: 2000 experience points<BR><BR>Reward: 2x large bag of treasure", (bool)false, (bool)true);
            		AddLabel( 127, 351, 90, @"Page 11" );
			AddButton( 357, 324, 2085, 248, 0, GumpButtonType.Page, 13 );

			AddPage( 13 );
			AddButton( 358, 150, 2084, 248, 0, GumpButtonType.Page, 12 );
            		AddLabel( 129, 170, 90, @"Name: Spiderwick Chronicles" );
	    		AddHtml( 123, 198, 244, 120, @"Info: A tailors apprentice needs someone to go into the Oboru Jungle to collect some specialized spidersilk.<BR><BR>Quester: Gilmora<BR><BR>Objective: Collect 12 piece of oboru spidersilk.<BR><BR>Reward: 1500 experience points<BR><BR>Reward: spidersilk cloak of protection", (bool)false, (bool)true);
            		AddLabel( 127, 351, 90, @"Page 12" );
			AddButton( 357, 324, 2085, 248, 0, GumpButtonType.Page, 14 );

			AddPage( 14 );
			AddButton( 358, 150, 2084, 248, 0, GumpButtonType.Page, 13 );
            		AddLabel( 129, 170, 90, @"Name: The Gravefinders Repose" );
	    		AddHtml( 123, 198, 244, 120, @"Info: Someone here in town needs assistance dealing with a troublemaker over at Zaythalor Graveyard.<BR><BR>Quester: Audric<BR><BR>Objective: Slay Raelynn.<BR><BR>Reward: 2000 experience points<BR><BR>Reward: large bag of treasure", (bool)false, (bool)true);
            		AddLabel( 127, 351, 90, @"Page 13" );
			AddButton( 357, 324, 2085, 248, 0, GumpButtonType.Page, 15 );

			AddPage( 15 );
			AddButton( 358, 150, 2084, 248, 0, GumpButtonType.Page, 14 );
            		AddLabel( 129, 170, 90, @"Name: Trolling For Trolls" );
	    		AddHtml( 123, 198, 244, 120, @"Info: If it won't be too much a bother, I need someone to go over to the Island of Giants and put a dent on some rambuncous trolls.<BR><BR>Quester: Tyeelor<BR><BR>Objective: Slay 10 trolls.<BR><BR>Reward: 1500 experience points<BR><BR>Reward: large bag of treasure", (bool)false, (bool)true);
            		AddLabel( 127, 351, 90, @"Page 14" );
			AddButton( 357, 324, 2085, 248, 0, GumpButtonType.Page, 16 );

			AddPage( 16 );
			AddButton( 358, 150, 2084, 248, 0, GumpButtonType.Page, 15 );
            		AddLabel( 129, 170, 90, @"Name: Vollie Ball" );
	    		AddHtml( 123, 198, 244, 120, @"Info: Pardon to any who might get this message. If you're interesting in going after Vollie then pay me a visit and I'll set you up.<BR><BR>Quester: Candice Crumpet<BR><BR>Objective: Slay Vollie.<BR><BR>Reward: 2000 experience points<BR><BR>Reward: 2x large bags of treasure", (bool)false, (bool)true);
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
