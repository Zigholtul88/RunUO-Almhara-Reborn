using System;
using System.Collections;
using Server.Items;
using Server.ContextMenus;
using Server.Misc;
using Server.Network;
using Server.Targeting;

namespace Server.Mobiles 
{ 
	public class MountainMiner : BaseCreature 
	{ 

                private static bool m_Talked;
                string[]MountainMinerSay = new string[]
       	        {
		"Alytharr Grass Snakes, I hate them!",
		"Mining for ore is busy work.",
		"Sure is a sunny day, isn't it?",
		"I heard that you can now craft runic hammers.",
		"Smash the bottles and burn the corks!",
		"I'd stay clear of the Glimmerwood if I were you.",
		"If you're going to do any mining, make sure you have a pack horse.",
		"Is it me? or is it getting mighty chilly?",
		"I could settle on some good ale right about now.",
		"Who would expect a blue chicken to be so aggressive?",
		"Quite a lovely day it is.",
		"There's a cave in the Zaythalor region home to mongbats.",
		"The fish around these parts aren't too bad.",
		"Hello who do we have here?",
		"I was once a decent fencer, until that accident happened with my swinging arm!",
		"Have you checked some of the crates around these parts?",
		"I'm starving for a good piece of bread or two!",
		"MONGBATS! Curse those filthy bastards!",
		"I was never much of a cat person, especially with cougars and the like!",
		"Ever been to the Shatterglass Caverns over in the Glimmerwood?",
		"Ye old avian fucker of ocean complexion just roasted my good pants!",
		"Taxes are just there to keep the pale man down!",
		"I'm singing in the rain! I'm singing in the rain!........................",
		"Is it me or are we having a huge bird problem all of a sudden?",
		"Where's a good blacksmith when you need one?",
		"If you need gold fast then snatch it from some Mongbat or two, shoot I don't give a damn!",
		"Apples, apples, rolling down the hill!..........",
		"What's the deal with all these treasure chests lying about?",
		};

		[Constructable] 
		public MountainMiner() : base( AIType.AI_Animal, FightMode.None, 10, 1, 0.2, 0.4 ) 
		{ 
			SetStr( 135, 163 );
			SetDex( 68, 92 );
			SetInt( 26, 46 );

			SetSkill( SkillName.Anatomy, 60.0, 83.0 );
			SetSkill( SkillName.Mining, 65.0, 88.0 );
			SetSkill( SkillName.Parry, 61.0, 93.0 );
			SetSkill( SkillName.Swords, 60.0, 83.0 );
			SetSkill( SkillName.Tactics, 60.0, 83.0 );

			Fame = 10;
			Karma = 1000;

			SpeechHue = Utility.RandomDyedHue(); 

			Hue = Utility.RandomSkinHue(); 

			Utility.AssignRandomHair( this );

			if ( this.Female = Utility.RandomBool() ) 
			{ 
				this.Body = 0x191; 
				this.Name = NameList.RandomName( "female" );
				AddItem( new Skirt( Utility.RandomNeutralHue() ) );
				AddItem( new Shirt( Utility.RandomDyedHue() ) );
				Title = "the miner"; 
			} 
			else 
			{ 
				this.Body = 0x190; 
				this.Name = NameList.RandomName( "male" );
				AddItem( new ShortPants( Utility.RandomNeutralHue() ) ); 
				AddItem( new Shirt( Utility.RandomDyedHue() ) );
				Title = "the miner";
			} 

			AddItem( new Boots( Utility.RandomNeutralHue() ) );

			LeatherGloves gloves = new LeatherGloves();
			gloves.Movable = true;
			AddItem( gloves );

			Pickaxe weapon = new Pickaxe();
			weapon.Movable = true; 
			AddItem( weapon );

			Container pack = new Backpack(); 

			pack.DropItem( new Gold( 10, 15 ) );

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
                             SayRandom(MountainMinerSay, this );
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

		public MountainMiner( Serial serial ) : base( serial ) 
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
