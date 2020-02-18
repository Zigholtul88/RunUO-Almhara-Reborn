using System;
using System.Collections;
using System.Collections.Generic;
using Server;
using Server.Commands;
using Server.ContextMenus;
using Server.Items;
using Server.Gumps;
using Server.Misc;
using Server.Mobiles;
using Server.Network;
using Server.Spells;
using Server.Targeting;

namespace Server.Mobiles 
{ 
	public class SkaddriaNPCA : BaseCreature 
	{ 
                Point3D[] MoveLocations =
                {
                        new Point3D( 1316, 1994, 0 ),//Entrance to Zaythalor Region
                        new Point3D( 1343, 1941, 0 ),//Entrance to Zaythalor Region
                        new Point3D( 1343, 2008, 0 ),//Entrance to Zaythalor Region
                        new Point3D( 1381, 1988, 0 ),//Entrance to Zaythalor Region
                        new Point3D( 1414, 1979, 0 ),//Entrance to Zaythalor Region
                        new Point3D( 1525, 1932, 5 ),//Main City
                        new Point3D( 1545, 1864, 20 ),//Main City
                        new Point3D( 1546, 1886, 20 ),//Main City
                        new Point3D( 1553, 1833, 100 ),//Main City
                        new Point3D( 1559, 1833, 20 ),//Main City
                        new Point3D( 1563, 1838, 100 ),//Main City
                        new Point3D( 1567, 1942, 25 ),//Main City
                        new Point3D( 1597, 1841, 5 ),//Main City
                        new Point3D( 1603, 1904, 5 ),//Main City
                        new Point3D( 1615, 1920, 5 ),//Main City
                        new Point3D( 1630, 1858, 5 ),//Main City
                        new Point3D( 1631, 1923, 10 ),//Main City
                        new Point3D( 1634, 1938, 5 ),//Main City
                        new Point3D( 1635, 1836, 5 ),//Main City
                        new Point3D( 1636, 1929, 10 ),//Main City
                        new Point3D( 1636, 1952, 5 ),//Main City
                        new Point3D( 1648, 1905, 5 ),//Main City
                        new Point3D( 1660, 1938, 5 ),//Main City
                        new Point3D( 1682, 1904, 5 ),//Main City
                        new Point3D( 1685, 1948, 5 ),//Main City
                        new Point3D( 1701, 1786, 30 ),//Main City
                        new Point3D( 1708, 1798, 25 ),//Main City
                        new Point3D( 1713, 1878, 15 ),//Main City
                        new Point3D( 1727, 1953, 34 ),//Main City
                        new Point3D( 1765, 1796, 22 ),//Main City
                        new Point3D( 1770, 1922, 34 ),//Main City
                        new Point3D( 1852, 1893, 25 ),//Main City
                        new Point3D( 1891, 1902, 25 ),//Main City
                        new Point3D( 1898, 1928, 25 ) //Main City
                };

                private MoveTimer m_Timer;

                private static bool m_Talked; // flag to prevent spam 

                string[] kfcsay = new string[] // things to say while greeting 
                { 
                       "I'm too old for this crap.", 
                       "You don't want to live in a society like this, yet you don't want to do anything about it!",  
                       "You must be mad, coming here like this.",  
                       "But you said you didn't see your wife at all that day.", 
                       "If we both stick to the story, they can't prove anything.",
                       "Try focusing more on your life and less on mine.",
                       "Have a nice day",
                       "Please try to persuade him to come, for my sake.",
                       "I goaded him to giving me his steak once. It did not go down so well.",
                       "It sickens me whenever I go over to Samson Swamplands. The bog creepers there are simply too much.",
                       "I'm so fabulous that my cat just suffered a stroke.",
                       "One of these days I will summon that bastard over to my place and give em' a good beatdown.",
                       "Don't chastise me on my life choices buddy. My buddy works with the town guard ya see.",
                       "Check out those huge watermellons over at the farmers market.",
                       "Help! Help! I'm being repressed!",
                       "Liberate your mind! You motherplunker! You're so narrow minded! So narrow minded!",
                       "I like Keljii! I like Keljii! They only come to your knees!",
                       "I saw the prettiest butterfly yesterday. Before I got jumped by a green llama.",
                       "They say this bloke had the voice of an angel. But personally I thought he sounded like rough cardboard.",
                       "Mom! Mom! This fucking cat looks like grandma!",
                       "Everybody in the club getting tipsy.",
                       "I saw my first bog creeper the other day. It was horrible and smelled like dank sewage.",
                       "I like my women like I like my coffee. In a plastic cup.",
                       "Have you considered applying for the academy of shut the hell up.",
                       "LOUD NOISES!",
                       "I like money.",
                       "Deez nuts! Hah! Got em!",
                       "Its swell to own a stiffy. Its divine to own a dick.",
                       "Sit on my face and let my lips embrace you.",
                       "No step on snek.",
                       "Wait that's a doggo. Bamboozled again.",
                       "The best part of waking up. Is coffee in your cup.",
                       "Two to the one to the one to the three. I like good pussy and I like good tree.",
                       "Smoke so much weed you wouldn't believe. And I get more ass than a toilet seat.",
                       "Never gonna give you up. Never gonna let you down.",
                       "What is love. Baby don't hurt me. Don't hurt me. No more.",
                       "Somebody once told me the world is gonna roll me.",
                       "I'm so happy, ha. Happy go lucky me.",
                       "Yo where my ninjas at!",
                       "I show no love to pogo thugs. How you gonna explain fucking a stick?",
                       "So stay woke. Ninjas creepin.",
                       "It's like I don't care about nothing man.",
                       "I was gonna clean my room. Until I got high.",
                       "Mahna mahna.",
                       "I miss you. I wish they took that mothers life instead.",
                       "Move bitch, get out the way. Move bitch, get out the way.",
                       "I miss you. I wish they took that mothers life instead.",
                       "Fuck the police coming straight from the underground. A young nigga got it bad because I'm brown.",
                       "They don't care about my one way mirror. They aren't frightened by my cold exterior.",
                       "Let the bodies hit the floor. Let the bodies hit the floor. RWARRRRRRRRRRRRRRRRRRRRRRRRRRRRRRRR!",
                       "Welcome to Skaddria. I love you.",
                       "I like small butts and I cannot lie. You honkey's can't deny.",
                       "I like big butts and I cannot lie. You other brothers can't deny.",
                       "Give me one good reason why I should wear a dress.",
                       "Would you come to my funeral?",
                       "I've been checking you out.",
                       "You make me feel like I'm not good enough.",
                       "Did you enjoy yourself last night.",
                       "He couldn't have died at a worse time.",
                       "I don't think I could live alone again.",
                       "For some reason, I'm attracted to you.",
                       "Tell me what you saw, for petes sake.",
                       "Please! Stop it! All of you!",
                       "Am I supposed to be scared now?",
                       "What a thing to say - and on my birthday!",
                       "I miss moments like this more than anything.",
                       "Nothing's THAT important, you know.",
                       "You did a bad thing for a good reason.",
                       "Why didn't he come and talk to me himself?",
                       "Where does a child hide in a small town like this?",
                       "Sorry, its just that I get very nervous when someone else is drinking around me.",
                       "They don't understand you like I do.",
                       "H-how long have you been standing there?",
                       "We could get arrested for this.",
                       "I just want a nice, easy life. What's wrong with that?",
                       "You've only heard his point of view. You never asked mine.",
                       "I don't think I could live alone again.",
                       "If you do this, you will be dead to me.",
                       "Cut my life into pieces. This is my last resort.",
                };

		public override bool InitialInnocent{ get{ return true; } }
		public override bool ClickTitle{ get{ return false; } }

		[Constructable] 
		public SkaddriaNPCA () : base( AIType.AI_Animal, FightMode.None, 10, 1, 0.2, 0.4 ) 
		{ 
                        m_Timer = new MoveTimer( this );
                        ChangeLocation();

			SetStr( 150, 250 );
			SetDex( 58, 82 );
			SetInt( 19, 98 );

			SetDamage( 2, 10 );

			SetSkill( SkillName.Anatomy, 71.2, 81.4 );
			SetSkill( SkillName.MagicResist, 25.9, 29.8 );
			SetSkill( SkillName.Wrestling, 76.5, 98.1 );
			SetSkill( SkillName.Tactics, 69.8, 82.6 );

			SpeechHue = 961;

			Hue = Utility.RandomSkinHue(); 

			if ( this.Female = Utility.RandomBool() ) 
			{ 
				this.Body = 0x191; 
				this.Name = NameList.RandomName( "female" );
				AddItem( new FlowerDress( Utility.RandomDyedHue() ) ); 
				this.Title = NameList.RandomName( "jobs" );
			} 
			else 
			{ 
				this.Body = 0x190; 
				this.Name = NameList.RandomName( "male" );
				AddItem( new FancyPants( Utility.RandomNeutralHue() ) ); 
				AddItem( new FormalShirt( Utility.RandomDyedHue() ) );
				this.Title = NameList.RandomName( "jobs" );
			} 

			AddItem( new PlumeCloak( Utility.RandomNeutralHue() ) );
			AddItem( new HeavyBoots( Utility.RandomNeutralHue() ) );

			Utility.AssignRandomHair( this );

			Container pack = new Backpack(); 

			pack.DropItem( new Gold( 10, 15 ) );

			pack.Movable = false; 

			AddItem( pack ); 
		}

                public void ChangeLocation()
                {
                        this.MoveToWorld( MoveLocations[ Utility.Random( MoveLocations.Length )], Map.Malas );
                        this.Hidden = true; //Arrives Hidden
                }

		public override void OnMovement( Mobile m, Point3D oldLocation ) 
                {                                                    
                      if( m_Talked == false ) 
                      { 
                            if ( m.InRange( this, 4 ) ) 
                            {                
                                 m_Talked = true; 
                                 SayRandom( kfcsay, this ); 
                                 this.Move( GetDirectionTo( m.Location ) ); 
                                 // Start timer to prevent spam 
                                 SpamTimer t = new SpamTimer(); 
                                 t.Start(); 
                            } 
                      } 
                } 

                private class SpamTimer : Timer 
                { 
                       public SpamTimer() : base( TimeSpan.FromSeconds( 60 ) ) 
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

		public SkaddriaNPCA( Serial serial ) : base( serial ) 
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

                        m_Timer = new MoveTimer(this);
		}

                private class MoveTimer : Timer
                {
                        private SkaddriaNPCA m_Owner;

                public MoveTimer(SkaddriaNPCA owner): base(TimeSpan.FromHours(1), TimeSpan.FromHours(1))
                {
                        m_Owner = owner;
                        TimerThread.PriorityChange(this, 7);
                }

                protected override void OnTick()
                {
                        if (m_Owner == null)
                        {
                        Stop();
                        return;
                }
                else if (m_Owner.Hits == m_Owner.HitsMax) // IE not in combat at all
                {
                        m_Owner.ChangeLocation();
                }
            }
        }
    }
}