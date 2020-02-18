using System;
using System.Collections;
using Server.Items;
using Server.ContextMenus;
using Server.Misc;
using Server.Network;
using Server.Targeting;

namespace Server.Mobiles
{
	public class TavernDrunk : BaseCreature
	{

                private static bool m_Talked;
                string[]TavernDrunkSay = new string[]
       	        {
		"Get off my pint!",
		"Alytharr Grass Snakes, I hate them!",
		"Its your round!!... get the drinks in, ya tight git!",
		"I`ve spilt more ale down my waist coat than you`ve drunk tonight.",
		"Hey!! Wench!!... wheres my curry?",
		"So what do you rekon to this round earth theroy?",
		"I love that new music, you know the music with da rocks init.",
		"Well it looks like its going to rain.",
		"Is it me? or is it cold today?",
		"Im sure that troll bouncer is getting bigger.",
		"Do you ever think that were not really here?",
		"Dam.. I need a pint!",
		"I love you!",
		"I dont know why we come here?",
		"Hullo!",
		"Who`s up for a game of darts?",
		"eh! Up!... barrels round!",
		"I could murder a sausage-in-a-bun.",
		"Watch it you!!",
		"Theres never anyone from the city watch around when you need them.",
		"I dont like cats.",
		"I could do with a holiday.",
		"Ever been to Klatch?",
		"Check out the sweetie over there.",
		"Want a drink?",
		"Im broke!",
		"Taxes!! dont talk to me about taxes!",
		"You know how everyone goes on about the sex of the giant turtle... what ablout the elephants??",
		"You know... if one of them four elephants is a female.. we could be in for some trobble if they start getting jiggy with it.",
		"Theres too much of everything theses days!",
		"Fancy going fishing.",
		"I caught a huge fish the other day... it was this big!",
		"Leave me alone!!",
		};

		[Constructable]
		public TavernDrunk() : base( AIType.AI_Melee, FightMode.None, 10, 1, 0.2, 0.4 )
		{
			SetStr( 15, 61 );
			SetDex( 10, 81 );
			SetInt( 5, 51 );

			SetDamage( 2, 8 );

			SetSkill( SkillName.MagicResist, 5.0, 45.0 );
			SetSkill( SkillName.Tactics, 5.0, 65.0 );
			SetSkill( SkillName.Wrestling, 5.0, 85.0 );

			Fame = 10;
			Karma = 1000;

			SpeechHue = Utility.RandomDyedHue();

			Hue = Utility.RandomSkinHue();

			Utility.AssignRandomHair( this );

			switch(Utility.Random(10))
			{
				case 0: Title = "the drunk"; break;
				case 1: Title = "the liar"; break;
				case 2: Title = "the evil"; break;
				case 3: Title = "the coward"; break;
				case 4: Title = "the drunk ass"; break;
				case 5: Title = "the drunk lard"; break;
				case 6: Title = "the dumbass"; break;
				case 7: Title = "the drunk bastard"; break;
				case 8: Title = "the mildly wasted"; break;
				case 9: break;
			}		
			
			if( this.Female = Utility.RandomBool() )
			{
				this.Body = 0x191;
				this.Name = NameList.RandomName( "female" );
				AddItem( new Kilt( Utility.RandomNeutralHue() ) );
			}
			else
			{
				this.Body = 0x190;
				this.Name = NameList.RandomName( "male" );
				AddItem( new LongPants( Utility.RandomNeutralHue() ) );
			}

			AddItem( new Doublet( Utility.RandomNeutralHue() ) );

			Container pack = new Backpack();

			pack.DropItem( new Gold( 7, 12 ) );

			pack.Movable = false;

			AddItem( pack );
		}

                public override void OnMovement( Mobile m, Point3D oldLocation )
                {
                     if( m_Talked == false )
                     {
                          if ( m.InRange( this, 3 ) && m is PlayerMobile)
                          {
                             m_Talked = true;
                             SayRandom(TavernDrunkSay, this );
                             this.Move( GetDirectionTo( m.Location ) );
                             SpamTimer t = new SpamTimer();
                             t.Start();
                          }
                    }
              }

              private class SpamTimer : Timer
              {
                   public SpamTimer() : base( TimeSpan.FromSeconds( 25 ) )
                   {
                        Priority = TimerPriority.OneSecond;
                   }

                   protected override void OnTick()
                   {
                           m_Talked = false;
                   }
              }

                private static void SayRandom( string[] say, Mobile m )
                {
                     m.Say( say[Utility.Random( say.Length )] );
                }

		public override bool ClickTitle { get { return false; } }

		public TavernDrunk( Serial serial ): base( serial )
		{
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );

			writer.Write( (int)0 ); // version 
		}

		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader );

			int version = reader.ReadInt();
		}
	}
}
