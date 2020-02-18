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
	[CorpseName( "a cavern mongbat corpse" )]
	public class CavernMongbatBerserkerQuest : BaseFastEnemy
	{
                private readonly Timer m_Timer;

		public override double BoostedSpeed{ get{ return 0.2; } }
		public override bool ReduceSpeedWithDamage{ get{ return false; } }

                private static bool m_Talked;
                string[]CavernMongbatBerserkerQuestSay = new string[]
       	        {
		"GIVE US BACK THE STAFF!",
		"COME BACK HERE!",
		"EKK EKK!",
		"WE'RE COMING FOR THAT STAFF!",
		"THERE'S NO WHERE TO HIDE NOW!",
		"GET BACK HERE!",
		"BITCH GET OVER HERE!",
		"MASTER SHALL BE AVENGED!",
		"DIE SURFACE DWELLER!",
		};

		public override WeaponAbility GetWeaponAbility()
		{
			return WeaponAbility.CrushingBlow;
		}

		[Constructable]
		public CavernMongbatBerserkerQuest() : base( AIType.AI_Archer, FightMode.Closest, 8, 1, 0.175, 0.350 )
		{
			CurrentSpeed = BoostedSpeed;
			RangePerception = 500;

			SpeechHue = Utility.RandomDyedHue();
			Name = NameList.RandomName( "mongbat" );
			Title = "the cavern mongbat berserker"; 
			Body = 39;
			Hue = Utility.RandomList( 1002,1005,1012,1023,1035,1038,1041,1047,1052,1058 );
			BaseSoundID = 422;

			SetStr( 61, 82 );
			SetDex( 53, 65 );
			SetInt( 23, 35 );

			SetHits( 75, 100 );

			SetDamage( 1, 3 );

			SetDamageType( ResistanceType.Physical, 100 );

			SetResistance( ResistanceType.Physical, 18 );

			SetSkill( SkillName.MagicResist, 23.8, 29.9 );
			SetSkill( SkillName.Tactics, 45.6, 52.3 );
			SetSkill( SkillName.Wrestling, 51.6, 53.2 );

			Fame = 1500;
			Karma = -1500;

                        this.m_Timer = new InternalTimer(this);
                        this.m_Timer.Start();

			PackGold( 6, 8 );

			PackItem( new FishScale( Utility.RandomMinMax( 9, 14 ) ) );

			PackItem( new BattleAxe() );
		}

		public override void GenerateLoot()
		{
			AddLoot( LootPack.Meager, 2 );
		}

		public override void OnHarmfulSpell( Mobile from )
		{
			if ( !Controlled && ControlMaster == null )
				CurrentSpeed = BoostedSpeed;
		}

		public override void OnCombatantChange()
		{
			if ( Combatant == null && !Controlled && ControlMaster == null )
				CurrentSpeed = PassiveSpeed;
		}

                public override void OnMovement( Mobile m, Point3D oldLocation )
                {
                     if( m_Talked == false )
                     {
                          if ( m.InRange( this, 10 ) && m is PlayerMobile && m.Combatant != null )
                          {
                               m_Talked = true;
                               SayRandom(CavernMongbatBerserkerQuestSay, this );
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

                public override void OnCarve( Mobile from, Corpse corpse, Item with )
		{
			if (corpse.Carved == false)
			{
			      base.OnCarve( from, corpse, with );

                              corpse.AddCarvedItem(new RawRibs(), from);
                              corpse.AddCarvedItem(new Hides(6), from);
                              corpse.AddCarvedItem(new CavernMongbatClaw(), from);

                              from.SendMessage( "You carve up a raw rib, some hides and a mongbat claw." );
                              corpse.Carved = true; 
			}
                }

		public CavernMongbatBerserkerQuest( Serial serial ) : base( serial )
		{
                        this.m_Timer = new InternalTimer(this);
                        this.m_Timer.Start();
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );
			writer.Write( (int) 0 );
		}

		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader );
			int version = reader.ReadInt();
		}

		private class InternalTimer : Timer
		{
			private CavernMongbatBerserkerQuest m_Owner;
			private int m_Count = 0;

			public InternalTimer( CavernMongbatBerserkerQuest owner ) : base( TimeSpan.FromSeconds( 0.1 ), TimeSpan.FromSeconds( 0.1 ) )
			{
				m_Owner = owner;
			}

			protected override void OnTick()
			{
				if ( (m_Count++ & 0x999) == 0 )
				{
					m_Owner.Direction = (Direction)(Utility.Random( 5 ) | 0x80);
				}

				m_Owner.Move( m_Owner.Direction );
			}
		}
	}
}