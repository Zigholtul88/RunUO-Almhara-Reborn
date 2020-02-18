using System;
using System.Collections;
using Server;
using Server.Gumps;
using Server.Network;
using Server.Mobiles;

namespace Server.Items
{
	public class QuestBulletinBoardSkaddriaCombat : Item
	{
		[Constructable]
		public QuestBulletinBoardSkaddriaCombat() : base( 7775 )
		{
			Movable = false;
			Light = LightType.Circle300;
			Name = "Quest Bulletin - Combat Quests";
			Hue = 1266;
		}

		public QuestBulletinBoardSkaddriaCombat( Serial serial ) : base( serial )
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
			m.CloseGump( typeof( QuestBulletinBoardSkaddriaCombatGump ) );
			m.SendGump( new QuestBulletinBoardSkaddriaCombatGump( m ) );

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

	public class QuestBulletinBoardSkaddriaCombatGump : Gump
	{
		public QuestBulletinBoardSkaddriaCombatGump( Mobile owner ) : base( 100, 100 )
		{
  			Closable = true;
  			Disposable = true;
  			Dragable = true;
  			Resizable = false;

			AddPage( 0 );
 			AddImage( 3, 7, 2170 );

			AddPage( 1 );
            		AddLabel( 166, 171, 90, @"Skaddria Combat Quests" );
			AddButton( 358, 150, 2085, 248, 0, GumpButtonType.Page, 2 );
	    		AddHtml( 123, 198, 244, 120, @"Click the up arrow to bring up the first page.", (bool)false, (bool)true);
            		AddLabel( 127, 351, 90, @"Index Page" );

			AddPage( 2 );
			AddButton( 358, 150, 2084, 248, 0, GumpButtonType.Page, 1 );
            		AddLabel( 129, 170, 90, @"Name: A Fine Feast" );
	    		AddHtml( 123, 198, 244, 120, @"Info: Someone is hungry for mutton and its up to you to help them out.<BR><BR>Quester: Aulan<BR><BR>Objective: Slay 10 sheep.<BR><BR>Reward: 500 experience points<BR><BR>Reward: Small bag of treasure", (bool)false, (bool)true);
            		AddLabel( 127, 351, 90, @"Page 1" );
			AddButton( 357, 324, 2085, 248, 0, GumpButtonType.Page, 3 );

			AddPage( 3 );
			AddButton( 358, 150, 2084, 248, 0, GumpButtonType.Page, 2 );
            		AddLabel( 129, 170, 90, @"Name: A Hero In The Making" );
	    		AddHtml( 123, 198, 244, 120, @"Info: Mongbats are annoying and I need anyone to deal with those pesky buggers.<BR><BR>Quester: Brinnae<BR><BR>Objective: Slay 10 mongbats.<BR><BR>Reward: 500 experience points<BR><BR>Reward: Small bag of treasure", (bool)false, (bool)true);
            		AddLabel( 127, 351, 90, @"Page 2" );
			AddButton( 357, 324, 2085, 248, 0, GumpButtonType.Page, 4 );

			AddPage( 4 );
			AddButton( 358, 150, 2084, 248, 0, GumpButtonType.Page, 3 );
            		AddLabel( 129, 170, 90, @"Name: Baroque O Rama" );
	    		AddHtml( 123, 198, 244, 120, @"Info: A merchant over at the local tailor is currently hiring anyone willing to obtain items needed for a festive hat.<BR><BR>Quester: Melanaha<BR><BR>Objective: Slay and collect items from a faerie beetle collector and a verdant sprite.<BR><BR>Reward: 500 experience points<BR><BR>Reward: Small bag of treasure", (bool)false, (bool)true);
            		AddLabel( 127, 351, 90, @"Page 3" );
			AddButton( 357, 324, 2085, 248, 0, GumpButtonType.Page, 5 );

			AddPage( 5 );
			AddButton( 358, 150, 2084, 248, 0, GumpButtonType.Page, 4 );
            		AddLabel( 129, 170, 90, @"Name: Birds Of A Feather" );
	    		AddHtml( 123, 198, 244, 120, @"Info: A local nutjob is harassing passerbys, seeking anyone whose willing to amuse her on a stupid dare.<BR><BR>Quester: Cailla<BR><BR>Objective: Slay 10 harpies.<BR><BR>Reward: 500 experience points<BR><BR>Reward: Small bag of treasure", (bool)false, (bool)true);
            		AddLabel( 127, 351, 90, @"Page 4" );
			AddButton( 357, 324, 2085, 248, 0, GumpButtonType.Page, 6 );

			AddPage( 6 );
			AddButton( 358, 150, 2084, 248, 0, GumpButtonType.Page, 5 );
            		AddLabel( 129, 170, 90, @"Name: Bullfighting... Sort Of" );
	    		AddHtml( 123, 198, 244, 120, @"Info: A man over in on his head needs someone to deal with some bull........ well you get the picture.<BR><BR>Quester: Clehin<BR><BR>Objective: Slay 10 bulls.<BR><BR>Reward: 500 experience points<BR><BR>Reward: Small bag of treasure", (bool)false, (bool)true);
            		AddLabel( 127, 351, 90, @"Page 5" );
			AddButton( 357, 324, 2085, 248, 0, GumpButtonType.Page, 7 );

			AddPage( 7 );
			AddButton( 358, 150, 2084, 248, 0, GumpButtonType.Page, 6 );
            		AddLabel( 129, 170, 90, @"Name: Creepy Crawlies" );
	    		AddHtml( 123, 198, 244, 120, @"Info: A young man seems to be suffering from arachnophobia. Be a dear and help him out.<BR><BR>Quester: Rebinil<BR><BR>Objective: Slay 5 ogumos.<BR><BR>Reward: 500 experience points<BR><BR>Reward: Small bag of treasure", (bool)false, (bool)true);
            		AddLabel( 127, 351, 90, @"Page 6" );
			AddButton( 357, 324, 2085, 248, 0, GumpButtonType.Page, 8 );

			AddPage( 8 );
			AddButton( 358, 150, 2084, 248, 0, GumpButtonType.Page, 7 );
            		AddLabel( 129, 170, 90, @"Name: Evil Eye" );
	    		AddHtml( 123, 198, 244, 120, @"Info: A young woman grows weary over wandering eyes that haunt her nightmares.<BR><BR>Quester: Mielan<BR><BR>Objective: Slay 5 gazer larvas.<BR><BR>Reward: 500 experience points<BR><BR>Reward: Small bag of treasure", (bool)false, (bool)true);
            		AddLabel( 127, 351, 90, @"Page 7" );
			AddButton( 357, 324, 2085, 248, 0, GumpButtonType.Page, 9 );

			AddPage( 9 );
			AddButton( 358, 150, 2084, 248, 0, GumpButtonType.Page, 8 );
            		AddLabel( 129, 170, 90, @"Name: Filthy Pests" );
	    		AddHtml( 123, 198, 244, 120, @"Info: Having become fed up with those bushy tailed nitwits, an exterminator is needed for the task at hand.<BR><BR>Quester: Salaenih<BR><BR>Objective: Slay 10 grey squirrels.<BR><BR>Reward: 500 experience points<BR><BR>Reward: Small bag of treasure", (bool)false, (bool)true);
            		AddLabel( 127, 351, 90, @"Page 8" );
			AddButton( 357, 324, 2085, 248, 0, GumpButtonType.Page, 10 );

			AddPage( 10 );
			AddButton( 358, 150, 2084, 248, 0, GumpButtonType.Page, 9 );
            		AddLabel( 129, 170, 90, @"Name: Forced Migration" );
	    		AddHtml( 123, 198, 244, 120, @"Info: I hate birds. They're loud, annoying pests. And they deficate all over the place. Won't someone help me.<BR><BR>Quester: Saril<BR><BR>Objective: Slay 10 birds.<BR><BR>Reward: 500 experience points<BR><BR>Reward: Small bag of treasure", (bool)false, (bool)true);
            		AddLabel( 127, 351, 90, @"Page 9" );
			AddButton( 357, 324, 2085, 248, 0, GumpButtonType.Page, 11 );

			AddPage( 11 );
			AddButton( 358, 150, 2084, 248, 0, GumpButtonType.Page, 10 );
            		AddLabel( 129, 170, 90, @"Name: Hart Attack" );
	    		AddHtml( 123, 198, 244, 120, @"Info: One gentleman needs someone to procure a few items off of dead great harts.<BR><BR>Quester: Bolaevin<BR><BR>Objective: Collect pieces from various deer corpses.<BR><BR>Reward: 500 experience points<BR><BR>Reward: Small bag of treasure", (bool)false, (bool)true);
            		AddLabel( 127, 351, 90, @"Page 10" );
			AddButton( 357, 324, 2085, 248, 0, GumpButtonType.Page, 12 );

			AddPage( 12 );
			AddButton( 358, 150, 2084, 248, 0, GumpButtonType.Page, 11 );
            		AddLabel( 129, 170, 90, @"Name: King Of Faerie Beetles" );
	    		AddHtml( 123, 198, 244, 120, @"Info: A certain waterspot has become infested with beetles and needs to be cleaned up by any means necessary.<BR><BR>Quester: Braen<BR><BR>Objective: Slay 10 faerie beetle collectors.<BR><BR>Reward: 500 experience points<BR><BR>Reward: Small bag of treasure", (bool)false, (bool)true);
            		AddLabel( 127, 351, 90, @"Page 11" );
			AddButton( 357, 324, 2085, 248, 0, GumpButtonType.Page, 13 );

			AddPage( 13 );
			AddButton( 358, 150, 2084, 248, 0, GumpButtonType.Page, 12 );
            		AddLabel( 129, 170, 90, @"Name: No Good Fish Stealing" );
	    		AddHtml( 123, 198, 244, 120, @"Info: Fed up with his catch being snagged up by lizards, one man is offering funds for anyone willing to deal with them.<BR><BR>Quester: Daelas<BR><BR>Objective: Slay 10 water lizards.<BR><BR>Reward: 500 experience points<BR><BR>Reward: Small bag of treasure", (bool)false, (bool)true);
            		AddLabel( 127, 351, 90, @"Page 12" );
			AddButton( 357, 324, 2085, 248, 0, GumpButtonType.Page, 14 );

			AddPage( 14 );
			AddButton( 358, 150, 2084, 248, 0, GumpButtonType.Page, 13 );
            		AddLabel( 129, 170, 90, @"Name: Overpopulation" );
	    		AddHtml( 123, 198, 244, 120, @"Info: The woodland realm has become overburdened with wild deer and someone, anyone really is needed to quell the population.<BR><BR>Quester: Jusae<BR><BR>Objective: Slay 10 hinds.<BR><BR>Reward: 500 experience points<BR><BR>Reward: Small bag of treasure", (bool)false, (bool)true);
            		AddLabel( 127, 351, 90, @"Page 13" );
			AddButton( 357, 324, 2085, 248, 0, GumpButtonType.Page, 15 );

			AddPage( 15 );
			AddButton( 358, 150, 2084, 248, 0, GumpButtonType.Page, 14 );
            		AddLabel( 129, 170, 90, @"Name: Squishy" );
	    		AddHtml( 123, 198, 244, 120, @"Info: Those good for nothing booger brats. They've wrecked havoc on my equipment and I need someone to help put a stop to them before things get really out of hand.<BR><BR>Quester: Ciala<BR><BR>Objective: Slay 12 green slimes.<BR><BR>Reward: 500 experience points<BR><BR>Reward: Small bag of treasure", (bool)false, (bool)true);
            		AddLabel( 127, 351, 90, @"Page 14" );
			AddButton( 357, 324, 2085, 248, 0, GumpButtonType.Page, 16 );

			AddPage( 16 );
			AddButton( 358, 150, 2084, 248, 0, GumpButtonType.Page, 15 );
            		AddLabel( 129, 170, 90, @"Name: The Perils Of Farming" );
	    		AddHtml( 123, 198, 244, 120, @"Info: A local farmer needs assistance in dealing with vine overgrowth.<BR><BR>Quester: Braen<BR><BR>Objective: Slay 10 swamp vines.<BR><BR>Reward: 1000 experience points<BR><BR>Reward: Small bag of treasure", (bool)false, (bool)true);
            		AddLabel( 127, 351, 90, @"Page 15" );
			AddButton( 357, 324, 2085, 248, 0, GumpButtonType.Page, 17 );

			AddPage( 17 );
			AddButton( 358, 150, 2084, 248, 0, GumpButtonType.Page, 16 );
            		AddLabel( 129, 170, 90, @"Name: They'll Eat Anything" );
	    		AddHtml( 123, 198, 244, 120, @"Info: Not to be confused with the local town guards, someone has a hankering for pork and pork accessories.<BR><BR>Quester: Olaeni<BR><BR>Objective: Slay 20 pigs.<BR><BR>Reward: 500 experience points<BR><BR>Reward: Small bag of treasure", (bool)false, (bool)true);
            		AddLabel( 127, 351, 90, @"Page 16" );
			AddButton( 357, 324, 2085, 248, 0, GumpButtonType.Page, 18 );

			AddPage( 18 );
			AddButton( 358, 150, 2084, 248, 0, GumpButtonType.Page, 17 );
            		AddLabel( 129, 170, 90, @"Name: They're Breeding Like Rabbits" );
	    		AddHtml( 123, 198, 244, 120, @"Info: Do you hate bunny rabbits? Then I might have a job for you.<BR><BR>Quester: Tamm<BR><BR>Objective: Slay 15 rabbits.<BR><BR>Reward: 500 experience points<BR><BR>Reward: Small bag of treasure", (bool)false, (bool)true);
            		AddLabel( 127, 351, 90, @"Page 17" );
			AddButton( 357, 324, 2085, 248, 0, GumpButtonType.Page, 19 );

			AddPage( 19 );
			AddButton( 358, 150, 2084, 248, 0, GumpButtonType.Page, 18 );
            		AddLabel( 129, 170, 90, @"Name: Thinning The Herd" );
	    		AddHtml( 123, 198, 244, 120, @"Info: If anyone reads this message, just keep it on the down low.<BR><BR>Quester: Thallary<BR><BR>Objective: Slay 15 goats.<BR><BR>Reward: 500 experience points<BR><BR>Reward: Small bag of treasure<BR><BR>Shit I shouldn't have mentioned those goats. Now they're definitely know I'm on to them.", (bool)false, (bool)true);
            		AddLabel( 127, 351, 90, @"Page 18" );
			AddButton( 357, 324, 2085, 248, 0, GumpButtonType.Page, 20 );

			AddPage( 20 );
			AddButton( 358, 150, 2084, 248, 0, GumpButtonType.Page, 19 );
            		AddLabel( 129, 170, 90, @"Name: Voracious Plants" );
	    		AddHtml( 123, 198, 244, 120, @"Info: Sup bitches. Bet all you ninjas can't handle what I have in store for you.<BR><BR>Quester: Vilo<BR><BR>Objective: Slay 18 swamp vines.<BR><BR>Reward: 500 experience points<BR><BR>Reward: Small bag of treasure and a medium bag of treasure", (bool)false, (bool)true);
            		AddLabel( 127, 351, 90, @"Page 19" );
			AddButton( 357, 324, 2085, 248, 0, GumpButtonType.Page, 21 );

			AddPage( 21 );
			AddButton( 358, 150, 2084, 248, 0, GumpButtonType.Page, 20 );
            		AddLabel( 129, 170, 90, @"Name: Wild Boar Cull" );
	    		AddHtml( 123, 198, 244, 120, @"Info: There's a boar infestation and its up to anyone to deal with those rapacious thugs.<BR><BR>Quester: Waelian<BR><BR>Objective: Slay 16 boars.<BR><BR>Reward: 500 experience points<BR><BR>Reward: Small bag of treasure", (bool)false, (bool)true);
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
