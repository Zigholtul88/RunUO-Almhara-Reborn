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
	public class WastelandMercenary : BaseGuardian
	{ 
		public Timer	m_Timer;

                private static bool m_Talked;
                string[]WastelandMercenarySay = new string[]
       	        {
		"HALT!",
		"STOP RIGHT THERE, CRIMINAL SCUM!",
		"TAKE EM OUT!",
		"TO BATTLE!",
		"DON'T LET EM ESCAPE!",
		"WE MUST HOLD AT ALL COSTS!",
		"WE CAN'T FALL BACK NOW!",
		"PREPARE FOR DEATH!",
		"RUN RABBIT RUN!",
		"WHATCHA GONNA DO WHEN WE COME FOR YOU!",
		"INDESTRUCTIBLE, DETERMINATION THAT IS INCORRUPTIBLE!",
		};

		[Constructable] 
		public WastelandMercenary() : base( AIType.AI_Archer, FightMode.Closest, 15, 1, 0.1, 0.2 ) 
		{ 
			Title = "Wasteland Mercenary"; 

			SetStr( 150, 100 );
			SetDex( 100, 200 );
			SetInt( 100, 200 );

			SetHits( 1500, 2000 );

			SetDamage( 2, 10 );

			SetSkill( SkillName.Anatomy, 100.0, 100.0 );
			SetSkill( SkillName.Archery, 100.0, 100.0 );
			SetSkill( SkillName.Tactics, 100.0, 100.0 );
			SetSkill( SkillName.MagicResist, 100.0, 100.0 );

			Karma = 10000;

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

			        SteelJaw weapon = new SteelJaw();
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

			        SteelJaw weapon = new SteelJaw();
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
                               SayRandom(WastelandMercenarySay, this );
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

		public WastelandMercenary( Serial serial ) : base( serial ) 
		{ 
			m_Timer = new AutokillTimer(this);
			m_Timer.Start();
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

		private class AutokillTimer : Timer
		{
			private WastelandMercenary m_Owner;

			public AutokillTimer( WastelandMercenary owner ) : base( TimeSpan.FromMinutes(10.0) )
			{
				m_Owner = owner;
				Priority = TimerPriority.FiveSeconds;
			}

			protected override void OnTick()
			{
				m_Owner.Delete();
				Stop();
			}
		}
	}
}
