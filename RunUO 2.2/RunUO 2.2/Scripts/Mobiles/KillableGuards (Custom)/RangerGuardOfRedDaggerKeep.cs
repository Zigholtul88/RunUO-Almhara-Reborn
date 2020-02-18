using System;
using System.Collections;
using System.Collections.Generic;
using Server;
using Server.ContextMenus;
using Server.Items;
using Server.Misc;
using Server.Mobiles; 
using Server.Network;
using Server.Targeting;

namespace Server.Mobiles 
{ 
	public class RangerGuardOfRedDaggerKeep : BaseGuardian
	{ 
                private static bool m_Talked;
                string[]RangerGuardSay = new string[]
       	        {
		"HALT!",
		"STOP RIGHT THERE, CRIMINAL SCUM!",
		"TAKE EM OUT!",
		"TO BATTLE!",
		"DEFEND RED DAGGER KEEP WITH ALL OF YOUR MIGHT!",
		"DON'T LET EM ESCAPE!",
		"WE MUST HOLD AT ALL COSTS!",
		"WE CAN'T FALL BACK NOW!",
		"PREPARE FOR DEATH!",
		"RUN RABBIT RUN!",
		"WHATCHA GONNA DO WHEN WE COME FOR YOU!",
		"INDESTRUCTIBLE, DETERMINATION THAT IS INCORRUPTIBLE!",
		};

		[Constructable] 
		public RangerGuardOfRedDaggerKeep() : base( AIType.AI_Archer, FightMode.Closest, 15, 1, 0.1, 0.2 ) 
		{ 
			Title = "Ranger Guard of Red Dagger Keep"; 

			SetStr( 850, 900 );
			SetDex( 500, 700 );
			SetInt( 100, 200 );

			SetHits( 1500, 2000 );

			SetDamage( 19, 35 );

			SetSkill( SkillName.Anatomy, 100.0, 100.0 );
			SetSkill( SkillName.Archery, 100.0, 100.0 );
			SetSkill( SkillName.Tactics, 100.0, 100.0 );
			SetSkill( SkillName.MagicResist, 100.0, 100.0 );

			Karma = 10000;

			AddItem( new HighBoots(643) );
			AddItem( new PlumeCloak(238) );

			StuddedGorget gorget = new StuddedGorget();
			gorget.Hue = 643;
			gorget.Movable = true;
			AddItem( gorget );

			StuddedArms arms = new StuddedArms();
			arms.Hue = 643;
			arms.Movable = true;
			AddItem( arms );

			StuddedGloves gloves = new StuddedGloves();
			gloves.Hue = 238;
			gloves.Movable = true;
			AddItem( gloves );

			EbonyWarBow weapon = new EbonyWarBow();
		        BaseRunicTool.ApplyAttributesTo( weapon, 5, 25, 35 );
			weapon.WeaponAttributes.HitLightning = 25;
                        weapon.Hue = 238;
			weapon.Movable = true; 
			weapon.Quality = WeaponQuality.Exceptional; 
			AddItem( weapon );

			PackItem( new Arrow( Utility.RandomMinMax( 50, 80 ) ) ); 

			if ( Female = Utility.RandomBool() ) 
			{ 
			        Body = 606;
			        Name = NameList.RandomName( "elven female" );
			        Hue = Utility.RandomList( 897,898,899,2405 );
                                HairHue = 1153;
                                HairItemID = Utility.RandomList( 12224,12225,12236,12237,12238,12239 );
								
			        FemaleStuddedChest chest = new FemaleStuddedChest();
			        chest.Hue = 238;
			        chest.Movable = true;
			        AddItem( chest );
			}
			else 
			{ 
			        Body = 605;
			        Name = NameList.RandomName( "elven male" );
			        Hue = Utility.RandomList( 897,898,899,2405 );
                                HairHue = 1153;
                                HairItemID = Utility.RandomList( 12224,12225,12236,12237,12238,12239 );

			        StuddedChest chest = new StuddedChest();
			        chest.Hue = 238;
			        chest.Movable = true;
			        AddItem( chest );

			        StuddedLegs legs = new StuddedLegs();
			        legs.Hue = 238;
			        legs.Movable = true;
			        AddItem( legs );
			}
		}

		public override bool BardImmune{ get{ return !Core.AOS; } }
		public override bool Unprovokable{ get{ return Core.AOS; } }
		public override bool AreaPeaceImmune{ get{ return Core.AOS; } }

                public override void OnMovement( Mobile m, Point3D oldLocation )
                {
                     if( m_Talked == false )
                     {
                          if ( m.InRange( this, 10 ) && m is PlayerMobile && m.Combatant != null )
                          {
                               m_Talked = true;
                               SayRandom(RangerGuardSay, this );
                               this.Move( GetDirectionTo( m.Location ) );
                               SpamTimer t = new SpamTimer();
                               t.Start();
                          }
                     }
                }

                private class SpamTimer : Timer
                {
                    public SpamTimer() : base( TimeSpan.FromSeconds( Utility.Random( 5, 25 ) ) )
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

		public RangerGuardOfRedDaggerKeep( Serial serial ) : base( serial )
		{
		}

		public override void Serialize(GenericWriter writer)
		{
			base.Serialize(writer);

			writer.Write((int) 0);
		}

		public override void Deserialize(GenericReader reader)
		{
			base.Deserialize(reader);

			int version = reader.ReadInt();
		}
	}
}
