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
	public class InteriorCrocodileAlligator : BaseCreature
	{
		public static TimeSpan TalkDelay = TimeSpan.FromSeconds( 5.0 ); //the delay between talks is 5 seconds
		public DateTime m_NextTalk;

                Point3D[] MoveLocations =
                {
                        new Point3D( 257, 1521, 15 ),//Cactus Hub
                        new Point3D( 695, 1817, 22 ) //Harashi Nabi Tavern
                };

                private MoveTimer m_Timer;

		private DateTime m_MilkedOn;

		[CommandProperty( AccessLevel.GameMaster )]
		public DateTime MilkedOn
		{
			get { return m_MilkedOn; }
			set { m_MilkedOn = value; }
		}

		private int m_Cider;

		[CommandProperty( AccessLevel.GameMaster )]
		public int Cider
		{
			get { return m_Cider; }
			set { m_Cider = value; }
		}

		[Constructable]
		public InteriorCrocodileAlligator() : base( AIType.AI_Melee, FightMode.Aggressor, 10, 1, 0.2, 0.4 )
		{
			Name = "an interior crocodile alligator";
			Body = 0xCA;
			BaseSoundID = 120;

                        m_Timer = new MoveTimer( this );
                        ChangeLocation();

			SetStr( 115, 157 );
			SetDex( 5, 10 );
			SetInt( 4, 7 );

			SetHits( 102, 144 );
			SetStam( 73, 98 );
			SetMana( 0 );

			SetDamage( 5, 15 );

			SetDamageType( ResistanceType.Physical, 100 );

			SetResistance( ResistanceType.Physical, 70 );
			SetResistance( ResistanceType.Fire, 70 );
			SetResistance( ResistanceType.Cold, 70 );
			SetResistance( ResistanceType.Poison, 70 );
			SetResistance( ResistanceType.Energy, 70 );

			SetSkill( SkillName.Anatomy, 15.0 );
			SetSkill( SkillName.MagicResist, 100.7, 105.1 );
			SetSkill( SkillName.Ninjitsu, 60.0 );
			SetSkill( SkillName.Tactics, 48.2, 59.3 );
			SetSkill( SkillName.Wrestling, 53.4, 64.9 );

			Fame = 420;
			Karma = -420;

			PackItem( new EarOfCorn( Utility.RandomMinMax( 3, 7 ) ) );
		}

		public override int Meat{ get{ return 420; } }
		public override int Hides{ get{ return 420; } }
		public override HideType HideType{ get{ return HideType.Spined; } }
		public override FoodType FavoriteFood{ get{ return FoodType.Meat | FoodType.Fish; } }

                public void ChangeLocation()
                {
                        this.MoveToWorld( MoveLocations[ Utility.Random( MoveLocations.Length )], Map.Malas );
                        this.Hidden = true; //Arrives Hidden
                }

		public bool TryMilkingCider( Mobile from )
		{
			if ( !from.InLOS( this ) || !from.InRange( Location, 2 ) )
                                from.SendMessage( "You can not milk the ICA from this location." ); 
			if ( Controlled && ControlMaster != from )
                                from.SendMessage( "The ICA nimbly escapes your attempts to milk it." ); 
			if ( m_Cider == 0 && m_MilkedOn + TimeSpan.FromDays( 1 ) > DateTime.Now )
                                from.SendMessage( "This ICA can not be milked now. Please wait for some time." ); 
			else
			{
				if ( m_Cider == 0 )
					m_Cider = 4;

				m_MilkedOn = DateTime.Now;
				m_Cider--;

				return true;
			}

			return false;
		}

		public override void GenerateLoot()
		{
			AddLoot( LootPack.Meager );
		}

		public override int GetAttackSound() { return 122; } //play cow 3
		public override int GetHurtSound() { return 123; } //play cow 4
		public override int GetAngerSound() { return 122; } //play cow 3
		public override int GetDeathSound() { return 124; } //play cow 5

		public override void OnMovement( Mobile m, Point3D oldLocation )
		{
			if ( DateTime.Now >= m_NextTalk && InRange( m, 4 ) && InLOS( m ) && m is PlayerMobile ) // check if it's time to talk & mobile in range & in los.
			{
				m_NextTalk = DateTime.Now + TalkDelay; // set next talk time 
				switch ( Utility.Random( 28 ))
				{
					case 0: Say("Now baby I'm Tha Rippeeerrrrrr your baby daddy's worst nightmare."); 
						break;
					case 1: Say("Catch me by the Clair I'll be right there."); 
						break;	
					case 2: Say("Niggas copy everything we say."); 
						break;	
					case 3: Say("Louis frames, eyes lower than my GPA."); 
						break;
					case 4: Say("Ridin and Swirvin, kush I'm blowin."); 
						break;	
					case 5: Say("Doors wide, my trunk bump like eddie road."); 
						break;	
					case 6: Say("I don't cake hoes I never tip tha stripper."); 
						break;	
					case 7: Say("I'm rich bitch, but you can call me cheap tha ripper."); 
						break;	
					case 8: Say("Shell toes? Yes!"); 
						break;	
					case 9: Say("P.R.P.S There's a man riding a horse on top of my chest."); 
						break;	
					case 10: Say("Polo fresh, I am z' man."); 
						break;	
					case 11: Say("I be slam dunkin tanqueray shots with Lebron."); 
						break;	
					case 12: Say("I told niggas keep it Carmello ok?"); 
						break;	
					case 13: Say("Rolled past dave's told them hello, inhale."); 
						break;
					case 14: Say("Me and Cash on somthin' holy on 23's hoe."); 
						break;
					case 15: Say("Back windows say MAMA MEL BICHO!"); 
						break;	
					case 16: Say("Skateboarders grind, I grind too."); 
						break;	
					case 17: Say("That's why you can catch me in DC shoes."); 
						break;	
					case 18: Say("I quit the team, but believe I'm ballin."); 
						break;	
					case 19: Say("Want a verse put up a stack or quit callin."); 
						break;	
					case 20: Say("30's on my Chevorlete call me supa dupa."); 
						break;	
					case 21: Say("Garage like roots I got more whips than Kunta."); 
						break;
					case 22: Say("Rivera sittin on the Bulls best hoopa."); 
						break;
					case 23: Say("Ya'll still ridin 20's? ya'll some oompa loompas."); 
						break;
					case 24: Say("Doors swang on niggas that got bad behavior."); 
						break;
					case 25: Say("My 415's woke up thee neighbors."); 
						break;
					case 26: Say("Interior croc-a-dile alli-ga-tor."); 
						break;
					case 27: Say("I drive a Chevrolet movie theater."); 
						break;	
				};
			}
		}

		public InteriorCrocodileAlligator( Serial serial ) : base( serial )
		{
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );

			writer.Write( (int) 1 );

			writer.Write( (DateTime) m_MilkedOn );
			writer.Write( (int) m_Cider );
		}

		public override void Deserialize(GenericReader reader)
		{
			base.Deserialize( reader );

			int version = reader.ReadInt();
                        m_Timer = new MoveTimer(this);

			if ( version > 0 )
			{
				m_MilkedOn = reader.ReadDateTime();
				m_Cider = reader.ReadInt();
			}
		}

                private class MoveTimer : Timer
                {
                        private InteriorCrocodileAlligator m_Owner;

                public MoveTimer(InteriorCrocodileAlligator owner): base(TimeSpan.FromHours(1), TimeSpan.FromHours(1))
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