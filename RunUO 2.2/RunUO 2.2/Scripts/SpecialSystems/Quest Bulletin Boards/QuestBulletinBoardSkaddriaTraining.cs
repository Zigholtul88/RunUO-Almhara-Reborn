using System;
using System.Collections;
using Server;
using Server.Gumps;
using Server.Network;
using Server.Mobiles;

namespace Server.Items
{
	public class QuestBulletinBoardSkaddriaTraining : Item
	{
		[Constructable]
		public QuestBulletinBoardSkaddriaTraining() : base( 7775 )
		{
			Movable = false;
			Light = LightType.Circle300;
			Name = "Quest Bulletin - Training Quests";
			Hue = 1266;
		}

		public QuestBulletinBoardSkaddriaTraining( Serial serial ) : base( serial )
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
			m.CloseGump( typeof( QuestBulletinBoardSkaddriaTrainingGump ) );
			m.SendGump( new QuestBulletinBoardSkaddriaTrainingGump( m ) );

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

	public class QuestBulletinBoardSkaddriaTrainingGump : Gump
	{
		public QuestBulletinBoardSkaddriaTrainingGump( Mobile owner ) : base( 100, 100 )
		{
  			Closable = true;
  			Disposable = true;
  			Dragable = true;
  			Resizable = false;

			AddPage( 0 );
 			AddImage( 3, 7, 2170 );

			AddPage( 1 );
            		AddLabel( 166, 171, 90, @"Skaddria Training Quests" );
			AddButton( 358, 150, 2085, 248, 0, GumpButtonType.Page, 2 );
	    		AddHtml( 123, 198, 244, 120, @"Click the up arrow to bring up the first page.", (bool)false, (bool)true);
            		AddLabel( 127, 351, 90, @"Index Page" );

			AddPage( 2 );
			AddButton( 358, 150, 2084, 248, 0, GumpButtonType.Page, 1 );
            		AddLabel( 129, 170, 90, @"Name: A Clockwork Puzzle" );
	    		AddHtml( 123, 198, 244, 120, @"Info: Someone in town needs clock parts for reasons not worth mentioning on this bulletin board.<BR><BR>Quester: Nibbet<BR><BR>Objective: Collect 5 clock parts.<BR><BR>Reward: Small bag of treasure", (bool)false, (bool)true);
            		AddLabel( 127, 351, 90, @"Page 1" );
			AddButton( 357, 324, 2085, 248, 0, GumpButtonType.Page, 3 );

			AddPage( 3 );
			AddButton( 358, 150, 2084, 248, 0, GumpButtonType.Page, 2 );
            		AddLabel( 129, 170, 90, @"Name: A Stitch In Time" );
	    		AddHtml( 123, 198, 244, 120, @"Info: I need a special dress like the noble ladies from around the world. Won't someone help me?<BR><BR>Quester: Clairesse<BR><BR>Objective: Collect 1 fancy dress.<BR><BR>Reward: Small bag of treasure", (bool)false, (bool)true);
            		AddLabel( 127, 351, 90, @"Page 2" );
			AddButton( 357, 324, 2085, 248, 0, GumpButtonType.Page, 4 );

			AddPage( 4 );
			AddButton( 358, 150, 2084, 248, 0, GumpButtonType.Page, 3 );
            		AddLabel( 129, 170, 90, @"Name: Bakers Delight" );
	    		AddHtml( 123, 198, 244, 120, @"Info: A baker needs some ingredients for a certain recipe.<BR><BR>Quester: Aniel<BR><BR>Objective: Collect 1 sack flour, 2 eggs, 5 elderberries, 6 strawberries, and 1 bag of sugar.<BR><BR>Reward: 500 experience points<BR><BR>Reward: Small bag of treasure", (bool)false, (bool)true);
            		AddLabel( 127, 351, 90, @"Page 3" );
			AddButton( 357, 324, 2085, 248, 0, GumpButtonType.Page, 5 );

			AddPage( 5 );
			AddButton( 358, 150, 2084, 248, 0, GumpButtonType.Page, 4 );
            		AddLabel( 129, 170, 90, @"Name: Bakers Dozen" );
	    		AddHtml( 123, 198, 244, 120, @"Info: I need someone to gather for me some cookie mix.<BR><BR>Quester: Asandos<BR><BR>Objective: Collect 5 batches of cookie mix.<BR><BR>Reward: Small bag of treasure", (bool)false, (bool)true);
            		AddLabel( 127, 351, 90, @"Page 4" );
			AddButton( 357, 324, 2085, 248, 0, GumpButtonType.Page, 6 );

			AddPage( 6 );
			AddButton( 358, 150, 2084, 248, 0, GumpButtonType.Page, 5 );
            		AddLabel( 129, 170, 90, @"Name: Battered Bucklers" );
	    		AddHtml( 123, 198, 244, 120, @"Info: Any aspiring blacksmiths in the area? I could use your assistance.<BR><BR>Quester: Gervis<BR><BR>Objective: Collect 10 bucklers.<BR><BR>Reward: Small bag of treasure", (bool)false, (bool)true);
            		AddLabel( 127, 351, 90, @"Page 5" );
			AddButton( 357, 324, 2085, 248, 0, GumpButtonType.Page, 7 );

			AddPage( 7 );
			AddButton( 358, 150, 2084, 248, 0, GumpButtonType.Page, 6 );
            		AddLabel( 129, 170, 90, @"Name: Chop Chop On The Double" );
	    		AddHtml( 123, 198, 244, 120, @"Info: Are you a lumberjack and you okay? Will you sleep all night and work all day? Then I got the job for easy pay.<BR><BR>Quester: Hargrove<BR><BR>Objective: Collect 10 logs.<BR><BR>Reward: Small bag of treasure", (bool)false, (bool)true);
            		AddLabel( 127, 351, 90, @"Page 6" );
			AddButton( 357, 324, 2085, 248, 0, GumpButtonType.Page, 8 );

			AddPage( 8 );
			AddButton( 358, 150, 2084, 248, 0, GumpButtonType.Page, 7 );
            		AddLabel( 129, 170, 90, @"Name: Coconut Cacophony" );
	    		AddHtml( 123, 198, 244, 120, @"Info: Someone here in town is obsessed with coconuts. Won't you satisfy their curiosity?<BR><BR>Quester: Tholef<BR><BR>Objective: Collect 25 coconuts.<BR><BR>Reward: 500 experience points<BR><BR>Reward: Small bag of treasure", (bool)false, (bool)true);
            		AddLabel( 127, 351, 90, @"Page 7" );
			AddButton( 357, 324, 2085, 248, 0, GumpButtonType.Page, 9 );

			AddPage( 9 );
			AddButton( 358, 150, 2084, 248, 0, GumpButtonType.Page, 8 );
            		AddLabel( 129, 170, 90, @"Name: Comfortable Seating" );
	    		AddHtml( 123, 198, 244, 120, @"Info: I messed myself up using a saw and will be out for the time being. In the mean time, can someone fetch me a chair?<BR><BR>Quester: Lowel<BR><BR>Objective: Collect 1 straw chair.<BR><BR>Reward: Small bag of treasure", (bool)false, (bool)true);
            		AddLabel( 127, 351, 90, @"Page 8" );
			AddButton( 357, 324, 2085, 248, 0, GumpButtonType.Page, 10 );

			AddPage( 10 );
			AddButton( 358, 150, 2084, 248, 0, GumpButtonType.Page, 9 );
            		AddLabel( 129, 170, 90, @"Name: Delicious Fishes" );
	    		AddHtml( 123, 198, 244, 120, @"Info: Fancy yourself out on the docks, quiet and with fishing rod in hand? Say no more.<BR><BR>Quester: Norton<BR><BR>Objective: Collect 5 fish.<BR><BR>Reward: Small bag of treasure and some peppercorn fishsteaks", (bool)false, (bool)true);
            		AddLabel( 127, 351, 90, @"Page 9" );
			AddButton( 357, 324, 2085, 248, 0, GumpButtonType.Page, 11 );

			AddPage( 11 );
			AddButton( 358, 150, 2084, 248, 0, GumpButtonType.Page, 10 );
            		AddLabel( 129, 170, 90, @"Name: Fifty Shades Of Blue" );
	    		AddHtml( 123, 198, 244, 120, @"Info: Smitten with admiration, one man needs a young adventurer to venture into the Samson Swamplands in order to procure a few roses from its murky depths.<BR><BR>Quester: Aluniol<BR><BR>Objective: Collect 8 ivory roses.<BR><BR>Reward: 500 experience points<BR><BR>Reward: Small bag of treasure", (bool)false, (bool)true);
            		AddLabel( 127, 351, 90, @"Page 10" );
			AddButton( 357, 324, 2085, 248, 0, GumpButtonType.Page, 12 );

			AddPage( 12 );
			AddButton( 358, 150, 2084, 248, 0, GumpButtonType.Page, 11 );
            		AddLabel( 129, 170, 90, @"Name: Flee And Fatigue" );
	    		AddHtml( 123, 198, 244, 120, @"Info: Tired and out of shape after getting ambushed over in Samson Swamplands. Could use a few potions.<BR><BR>Quester: Sadrah<BR><BR>Objective: Collect 10 refresh potions.<BR><BR>Reward: Small bag of treasure", (bool)false, (bool)true);
            		AddLabel( 127, 351, 90, @"Page 11" );
			AddButton( 357, 324, 2085, 248, 0, GumpButtonType.Page, 13 );

			AddPage( 13 );
			AddButton( 358, 150, 2084, 248, 0, GumpButtonType.Page, 12 );
            		AddLabel( 129, 170, 90, @"Name: I Shot An Arrow Into The Air" );
	    		AddHtml( 123, 198, 244, 120, @"Info: I hate sheep and you probably do. Help me and I'll help you.<BR><BR>Quester: Kashiel<BR><BR>Objective: Kill 10 sheep.<BR><BR>Reward: Small bag of treasure", (bool)false, (bool)true);
            		AddLabel( 127, 351, 90, @"Page 12" );
			AddButton( 357, 324, 2085, 248, 0, GumpButtonType.Page, 14 );

			AddPage( 14 );
			AddButton( 358, 150, 2084, 248, 0, GumpButtonType.Page, 13 );
            		AddLabel( 129, 170, 90, @"Name: More Ore Please" );
	    		AddHtml( 123, 198, 244, 120, @"Info: Feel like breaking your back and getting mega rewarded for it? Maybe I can help you out.<BR><BR>Quester: Mugg<BR><BR>Objective: Collect 5 pieces of iron ore.<BR><BR>Reward: Small bag of treasure and a bag capable of holding lots of ingots without weight limitations", (bool)false, (bool)true);
            		AddLabel( 127, 351, 90, @"Page 13" );
			AddButton( 357, 324, 2085, 248, 0, GumpButtonType.Page, 15 );

			AddPage( 15 );
			AddButton( 358, 150, 2084, 248, 0, GumpButtonType.Page, 14 );
            		AddLabel( 129, 170, 90, @"Name: Split Ends" );
	    		AddHtml( 123, 198, 244, 120, @"Info: Damn it I'm out of arrows. Could you spare a bundle or two?<BR><BR>Quester: Andric<BR><BR>Objective: Collect 20 arrows.<BR><BR>Reward: Small bag of treasure", (bool)false, (bool)true);
            		AddLabel( 127, 351, 90, @"Page 14" );
			AddButton( 357, 324, 2085, 248, 0, GumpButtonType.Page, 16 );

			AddPage( 16 );
			AddButton( 358, 150, 2084, 248, 0, GumpButtonType.Page, 15 );
            		AddLabel( 129, 170, 90, @"Name: The Pen Is Mightier" );
	    		AddHtml( 123, 198, 244, 120, @"Info: Know anything about Inscription? I could use a few recall scrolls so I can finally test out those runes strewn all over town.<BR><BR>Quester: Lyle<BR><BR>Objective: Collect 5 recall scrolls.<BR><BR>Reward: Small bag of treasure and a book bound in red leather", (bool)false, (bool)true);
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
