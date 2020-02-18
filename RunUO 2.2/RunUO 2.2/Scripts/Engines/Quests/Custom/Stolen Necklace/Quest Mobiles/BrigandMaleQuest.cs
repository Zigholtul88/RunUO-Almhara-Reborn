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
using Server.ACC.CSS.Systems.Rogue; 

namespace Server.Mobiles
{
	public class BrigandMaleQuest : BaseFastEnemy
	{
                private readonly Timer m_Timer;

		public override bool ClickTitle{ get{ return false; } }

		public override double BoostedSpeed{ get{ return 0.2; } }
		public override bool ReduceSpeedWithDamage{ get{ return false; } }

                private static bool m_Talked;
                string[]BrigandMaleQuestSay = new string[]
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
		public BrigandMaleQuest() : base( AIType.AI_Melee, FightMode.Closest, 16, 1, 0.175, 0.350 )
		{
			CurrentSpeed = BoostedSpeed;
			RangePerception = 500;

			SpeechHue = Utility.RandomDyedHue();
			Name = NameList.RandomName( "male" );
			Body = 0x190;
			Title = "the brigand";
			Hue = Utility.RandomSkinHue();

			SetStr( 100, 150 );
			SetDex( 24, 178 );
			SetInt( 19, 98 );

			SetHits( 100, 150 );

			SetDamage( 1, 2 );

			SetSkill( SkillName.Fencing, 95.0, 97.5 );
			SetSkill( SkillName.Macing, 93.0, 98.5 );
			SetSkill( SkillName.MagicResist, 0.0 );
			SetSkill( SkillName.Swords, 98.0, 99.5 );
			SetSkill( SkillName.Tactics, 89.0, 93.5 );
			SetSkill( SkillName.Wrestling, 63.0, 81.5 );

			Fame = 2000;
			Karma = -2000;

                        this.m_Timer = new InternalTimer(this);
                        this.m_Timer.Start();

			PackGold( 2, 7 );

			new SavageRidgeback().Rider = this;

			AddItem( new Bandana());

			switch ( Utility.Random( 3 ))
			{
				case 0: AddItem( new Shirt() ); break;
				case 1: AddItem( new FancyShirt() ); break;
				case 2: AddItem( new ReinassanceShirt() ); break;
			}

			switch ( Utility.Random( 5 ))
			{
				case 0: AddItem( new FancyPants() ); break;
				case 1: AddItem( new Kilt() ); break;
				case 2: AddItem( new LongPants() ); break;
				case 3: AddItem( new ReinassancePants() ); break;
				case 4: AddItem( new ShortPants() ); break;
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

			Container pack = new Backpack();

			pack.DropItem( new Pitcher( BeverageType.Water ) );
			pack.DropItem( new Gold( Utility.RandomMinMax( 5, 8 ) ) );
			pack.DropItem( new Bandage( Utility.RandomMinMax( 5, 10 ) ) );
			pack.DropItem( new FishScale( Utility.RandomMinMax( 4, 8 ) ) );

			if ( 0.03 > Utility.RandomDouble() )
				pack.DropItem( new OneGoldBar() );

			if ( 0.03 > Utility.RandomDouble() )
				pack.DropItem( new FireOpal() );

			if ( 0.10 > Utility.RandomDouble() )
				pack.DropItem( new RogueCharmScroll() );

			PackItem( pack );

			switch ( Utility.Random( 6 ))
			{
				case 0: AddItem( new Longsword() ); break;
				case 1: AddItem( new Cutlass() ); break;
				case 2: AddItem( new Axe() ); break;
				case 3: AddItem( new Club() ); break;
				case 4: AddItem( new Dagger() ); break;
				case 5: AddItem( new Spear() ); break;
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
			     if ( Core.AOS )
		             BaseRunicTool.ApplyAttributesTo( weapon, 2, 10, 20 ); 

                             PackItem( weapon );
                      }

 		      if ( Utility.RandomDouble() < 0.15 )
                      {
			     BaseClothing clothing = Loot.RandomClothing( true );
			     if ( Core.AOS )
		             BaseRunicTool.ApplyAttributesTo( clothing, 2, 10, 20 ); 

                            PackItem( clothing );
                      }
		}

		public override bool AlwaysMurderer{ get{ return true; } }

		public override int GetHurtSound() { return 1081; } //play male oomph 6
		public override int GetAngerSound() { return 1074; } //play male no
		public override int GetDeathSound() { return 348; } //play male die 3

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
                               SayRandom(BrigandMaleQuestSay, this );
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

		public BrigandMaleQuest( Serial serial ) : base( serial )
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
			private BrigandMaleQuest m_Owner;
			private int m_Count = 0;

			public InternalTimer( BrigandMaleQuest owner ) : base( TimeSpan.FromSeconds( 0.1 ), TimeSpan.FromSeconds( 0.1 ) )
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