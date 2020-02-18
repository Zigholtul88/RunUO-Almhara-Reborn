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
	public class BrigandFemaleQuest : BaseFastEnemy
	{
                private readonly Timer m_Timer;

		public override bool ClickTitle{ get{ return false; } }

		public override double BoostedSpeed{ get{ return 0.2; } }
		public override bool ReduceSpeedWithDamage{ get{ return false; } }

                private static bool m_Talked;
                string[]BrigandFemaleQuestSay = new string[]
       	        {
		"GIVE US BACK THE NECKLACE!",
		"COME BACK HERE!",
		"YEE HAW!",
		"DEATH TO THE LAWFUL!",
		"KEEP MOVING!",
		"DON'T LET EM ESCAPE!",
		"WE CAN'T FALL BACK NOW!",
		"PREPARE FOR DEATH!",
		"RUN RABBIT RUN!",
		};

		[Constructable]
		public BrigandFemaleQuest() : base( AIType.AI_Melee, FightMode.Closest, 16, 1, 0.175, 0.350 )
		{
			CurrentSpeed = BoostedSpeed;
			RangePerception = 500;

			SpeechHue = Utility.RandomDyedHue();
			Name = NameList.RandomName( "female" );
			Body = 0x191;
			Title = "the brigand";
			Hue = Utility.RandomSkinHue();

			SetStr( 50, 100 );
			SetDex( 24, 178 );
			SetInt( 89, 111 );

			SetHits( 100, 150 );
			SetMana( 445, 555 );

			SetDamage( 1 );

			SetSkill( SkillName.MagicResist, 0.0 );
			SetSkill( SkillName.Tactics, 89.0, 93.5 );
			SetSkill( SkillName.Wrestling, 63.0, 81.5 );

			Fame = 2000;
			Karma = -2000;

                        this.m_Timer = new InternalTimer(this);
                        this.m_Timer.Start();

			PackGold( 2, 7 );

			new Ridgeback().Rider = this;

			AddItem( new Bandana());

			switch ( Utility.Random( 5 ))
			{
				case 0: AddItem( new CitizenDress() ); break;
				case 1: AddItem( new CommonerDress() ); break;
				case 2: AddItem( new DancersGarb() ); break;
				case 3: AddItem( new FormalDress() ); break;
				case 4: AddItem( new PlainDress() ); break;
			}

			switch ( Utility.Random( 6 ))
			{
				case 0: AddItem( new Boots() ); break;
				case 1: AddItem( new HeavyBoots() ); break;
				case 2: AddItem( new HighBoots() ); break;
				case 3: AddItem( new LightBoots() ); break;
				case 4: AddItem( new ShortBoots() ); break;
				case 5: AddItem( new ThighBoots() ); break;
			}

			Container pack1 = new Backpack();
			pack1.DropItem( new Pitcher( BeverageType.Water ) );
			pack1.DropItem( new Gold( Utility.RandomMinMax( 5, 8 ) ) );
			pack1.DropItem( new Bandage( Utility.RandomMinMax( 5, 10 ) ) );
			pack1.DropItem( new FishScale( Utility.RandomMinMax( 4, 8 ) ) );

                        Item ScrollLoot1 = Loot.RandomScroll( 0, 10, SpellbookType.Regular );
                        ScrollLoot1.Amount = Utility.Random( 2, 5 );
                        pack1.DropItem( ScrollLoot1 );

                        Item ScrollLoot2 = Loot.RandomScroll( 0, 10, SpellbookType.Regular );
                        ScrollLoot2.Amount = Utility.Random( 2, 5 );
                        pack1.DropItem( ScrollLoot2 );

			if ( 0.03 > Utility.RandomDouble() )
				pack1.DropItem( new OneGoldBar() );

			if ( 0.03 > Utility.RandomDouble() )
				pack1.DropItem( new FireOpal() );

			PackItem( pack1 );

			switch ( Utility.Random( 3 ) )
			{
				case 0: PackItem( new Ribs() ); break;
				case 1: PackItem( new Shaft() ); break;
				case 2: PackItem( new Candle() ); break;
			}

			switch ( Utility.Random( 3 ))
			{
				case 0: AddItem( new GnarledStaff() ); break;
				case 1: AddItem( new QuarterStaff() ); break;
				case 2: AddItem( new BlackStaff() ); break;
				case 3: AddItem( new CrystalStaff() ); break;
			}

			Utility.AssignRandomHair( this );
		}

		public override void GenerateLoot()
		{
			AddLoot( LootPack.Average );
			AddLoot( LootPack.Potions );

 		      if ( Utility.RandomDouble() < 0.15 )
                      {
			     BaseWeapon weapon = Loot.RandomWeapon( true );
			     switch ( Utility.Random( 4 ) )
			     {
			          case 0: weapon = new QuarterStaff(); break;
			          case 1: weapon = new BlackStaff(); break;
			          case 2: weapon = new CrystalStaff(); break;
				  default: weapon = new GnarledStaff(); break;
		             }

		             BaseRunicTool.ApplyAttributesTo( weapon, 2, 10, 20 ); 

                             PackItem( weapon );
                      }
		}

		public override bool AlwaysMurderer{ get{ return true; } }

		public override int GetHurtSound()  { return 806; } //play female oomph 3
		public override int GetAngerSound() { return 802; } //play female no
		public override int GetDeathSound() { return 790; } //play female death 3

		public override bool OnBeforeDeath()
		{
			IMount mount = this.Mount;

			if ( mount != null )
				mount.Rider = null;

			if ( mount is Mobile )
				((Mobile)mount).Delete();

			return base.OnBeforeDeath();
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
                               SayRandom(BrigandFemaleQuestSay, this );
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

		public BrigandFemaleQuest( Serial serial ) : base( serial )
		{
                        this.m_Timer = new InternalTimer(this);
                        this.m_Timer.Start();
		}

                public override void OnDelete()
                {
                        this.m_Timer.Stop();

                        base.OnDelete();
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

		private class InternalTimer : Timer
		{
			private BrigandFemaleQuest m_Owner;
			private int m_Count = 0;

			public InternalTimer( BrigandFemaleQuest owner ) : base( TimeSpan.FromSeconds( 0.1 ), TimeSpan.FromSeconds( 0.1 ) )
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