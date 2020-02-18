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
	public class RangerGuardOfSkaddria : BaseGuardian
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

                private static bool m_Talked;
                string[]RangerGuardSay = new string[]
       	        {
		"HALT!",
		"STOP RIGHT THERE, CRIMINAL SCUM!",
		"TAKE EM OUT!",
		"TO BATTLE!",
		"DEFEND SKADDRIA AT ALL COSTS!",
		"DON'T LET EM ESCAPE!",
		"WE MUST HOLD AT ALL COSTS!",
		"WE CAN'T FALL BACK NOW!",
		"PREPARE FOR DEATH!",
		"RUN RABBIT RUN!",
		"WHATCHA GONNA DO WHEN WE COME FOR YOU!",
		"INDESTRUCTIBLE, DETERMINATION THAT IS INCORRUPTIBLE!",
		};

		[Constructable] 
		public RangerGuardOfSkaddria() : base( AIType.AI_Archer, FightMode.Closest, 15, 1, 0.1, 0.2 ) 
		{ 
			Title = "Ranger Guard of Skaddria Naddheim"; 

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

                        m_Timer = new MoveTimer( this );
                        ChangeLocation();

			AddItem( new HighBoots(23) );
			AddItem( new PlumeCloak(313) );

			StuddedGorget gorget = new StuddedGorget();
			gorget.Hue = 23;
			gorget.Movable = true;
			AddItem( gorget );

			StuddedArms arms = new StuddedArms();
			arms.Hue = 23;
			arms.Movable = true;
			AddItem( arms );

			StuddedGloves gloves = new StuddedGloves();
			gloves.Hue = 313;
			gloves.Movable = true;
			AddItem( gloves );

			if ( Female = Utility.RandomBool() ) 
			{ 
				Body = 401; 
				Name = NameList.RandomName( "female" );
								
			        FemaleStuddedChest chest = new FemaleStuddedChest();
			        chest.Hue = 313;
			        chest.Movable = true;
			        AddItem( chest );

			        RepeatingCrossbow weapon = new RepeatingCrossbow();
		                BaseRunicTool.ApplyAttributesTo( weapon, 5, 25, 35 );
			        weapon.WeaponAttributes.HitLightning = 25;
                                weapon.Hue = 23;
			        weapon.Movable = true; 
			        weapon.Quality = WeaponQuality.Exceptional; 
			        AddItem( weapon );

			        PackItem( new Bolt( Utility.RandomMinMax( 50, 80 ) ) ); 

			}
			else 
			{ 
				Body = 400; 			
				Name = NameList.RandomName( "male" ); 

			        StuddedChest chest = new StuddedChest();
			        chest.Hue = 313;
			        chest.Movable = true;
			        AddItem( chest );

			        StuddedLegs legs = new StuddedLegs();
			        legs.Hue = 313;
			        legs.Movable = true;
			        AddItem( legs );

			        HeavyCrossbow weapon = new HeavyCrossbow();
		                BaseRunicTool.ApplyAttributesTo( weapon, 5, 25, 35 );
			        weapon.WeaponAttributes.HitLightning = 25;
                                weapon.Hue = 23;
			        weapon.Movable = true; 
			        weapon.Quality = WeaponQuality.Exceptional; 
			        AddItem( weapon );

			        PackItem( new Bolt( Utility.RandomMinMax( 50, 80 ) ) ); 
			}

			Utility.AssignRandomHair( this );
		}

                public void ChangeLocation()
                {
                        this.MoveToWorld( MoveLocations[ Utility.Random( MoveLocations.Length )], Map.Malas );
                        this.Hidden = true; //Arrives Hidden
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

		public RangerGuardOfSkaddria( Serial serial ) : base( serial ) 
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
                        private RangerGuardOfSkaddria m_Owner;

                public MoveTimer(RangerGuardOfSkaddria owner): base(TimeSpan.FromHours(1), TimeSpan.FromHours(1))
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