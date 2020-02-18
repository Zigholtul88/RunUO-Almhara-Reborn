using System;
using System.Collections;
using Server.Items;
using Server.ContextMenus;
using Server.Misc;
using Server.Network;
using Server.Targeting;

namespace Server.Mobiles 
{ 
	public class TownPeasant : BaseCreature 
	{ 

                private static bool m_Talked;
                string[]TownPeasantSay = new string[]
       	        {
		"I don't want to talk to you no more, you empty headed animal food trough wiper.",
		"I fart in your general direction.",
		"Your mother was a hamster and your father smelt of elderberries.",
		"Come and see the violence inherent in the system. Help! Help! I'm being repressed!",
		"Oh, what a giveaway! Did you hear that? Did you hear that, eh? That's what I'm on about! Did you see him repressing me? You saw him, Didn't you?",
		"Supreme executive power derives from a mandate from the masses, not from some farcical aquatic ceremony.",
		"You don't frighten us, English pig dogs. Go and boil your bottoms, you sons of a silly person.",
		"Oh, but you can't expect to wield supreme executive power just because some watery tart threw a sword at you.",
		"This new learning amazes me. Explain again how sheep's bladders may be employed to prevent earthquakes.",
		"Please! This is supposed to be a happy occasion. Let's not bicker and argue over who killed who.",
		"I'm French. Why do you think I have this outrageous accent, you silly king?",
		"Well, she turned me into a newt!.............. I got better.",
		"I didn't know we had a king. I thought we were an autonomous collective.",
		"I warned you, but did you listen to me? Oh, no, you knew, didn't you? Oh, it's just a harmless little bunny, isn't it?",
		"Oh but if I went 'round sayin' I was Emperor, just because some moistened bint lobbed a scimitar at me, they'd put me away.",
		"There is a pestilence upon this land, nothing is sacred. Even those who arrange and design shrubberies are under considerable economic stress in this period in history.",
		"Oh, what sad times are these when passing ruffians can say Ni at will to old ladies.",
		"And as the Black Beast lurched forward, escape for Arthur and his knights seemed hopeless, when suddenly, the animator suffered a fatal heart attack!",
		"You must cut down the mightiest tree in the forest... WITH... A HERRING!",
		};

		[Constructable] 
		public TownPeasant() : base( AIType.AI_Animal, FightMode.None, 10, 1, 0.2, 0.4 ) 
		{ 
			SetStr( 55, 125 );
			SetDex( 35, 65 );
			SetInt( 15, 25 );

			SetSkill( SkillName.Anatomy, 31.2, 71.4 );
			SetSkill( SkillName.MagicResist, 3.9, 24.4 );
			SetSkill( SkillName.Wrestling, 46.5, 84.1 );
			SetSkill( SkillName.Tactics, 29.8, 40.3 );

			Fame = 10;
			Karma = 1000;

			SpeechHue = Utility.RandomDyedHue(); 

			Hue = Utility.RandomSkinHue(); 

			Utility.AssignRandomHair( this );

			if ( this.Female = Utility.RandomBool() ) 
			{ 
				this.Body = 0x191; 
				this.Name = NameList.RandomName( "female" );
				AddItem( new PlainDress( Utility.RandomNeutralHue() ) );
				Title = "the peasant"; 
			} 
			else 
			{ 
				this.Body = 0x190; 
				this.Name = NameList.RandomName( "male" );
				AddItem( new Shirt( Utility.RandomNeutralHue() ) ); 
				AddItem( new ShortPants( Utility.RandomDyedHue() ) );
				Title = "the peasant";
			} 

			AddItem( new Boots( Utility.RandomNeutralHue() ) );
			AddItem( new BodySash( Utility.RandomNeutralHue() ) );

			Container pack = new Backpack(); 

			pack.DropItem( new Gold( 8, 11 ) );

			pack.Movable = false; 

			AddItem( pack ); 
		} 


		public override bool ClickTitle{ get{ return false; } }

                public override void OnMovement( Mobile m, Point3D oldLocation )
                {
                     if( m_Talked == false )
                     {
                          if ( m.InRange( this, 3 ) && m is PlayerMobile)
                          {

                             m_Talked = true;
                             SayRandom(TownPeasantSay, this );
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

		public TownPeasant( Serial serial ) : base( serial ) 
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
