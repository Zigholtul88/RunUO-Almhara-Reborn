using System;
using System.Collections;
using Server.Items;
using Server.ContextMenus;
using Server.Misc;
using Server.Network;
using Server.Targeting;

namespace Server.Mobiles
{
	public class ZaythalorAdventurer : BaseGuardian
	{
		public override double BoostedSpeed{ get{ return 0.2; } }
		public override bool ReduceSpeedWithDamage{ get{ return false; } }

		[Constructable]
		public ZaythalorAdventurer() : base( AIType.AI_Mage, FightMode.Closest, 10, 1, 0.2, 0.4 )
		{
			Title = "the sun elf adventurer"; 

			SetStr( 128, 160 );
			SetDex( 87, 100 );
			SetInt( 250, 300 );

			SetHits( 125, 150 );
			SetMana( 1150, 1200 );

			SetSkill( SkillName.EvalInt, 76.7, 85.7 );
			SetSkill( SkillName.Magery, 82.6, 93.1 );
			SetSkill( SkillName.MagicResist, 55.9, 58.5 );
			SetSkill( SkillName.Meditation, 99.2, 99.9 );
			SetSkill( SkillName.Wrestling, 49.4, 57.6 );

			Fame = -2500;
			Karma = 2500;

			PackReg( 15, 25 );

			AddItem( new GemmedCirclet() );
			AddItem( new Sandals(2129) );

			CrystalStaff weapon = new CrystalStaff();
                        weapon.Hue = 2129;
			weapon.Movable = true;
			AddItem( weapon );

			LeafGloves gloves = new LeafGloves();
			gloves.Hue = 2129;
			gloves.Movable = true;
			AddItem( gloves );

			if ( this.Female = Utility.RandomBool() )
			{
				Body = 606;
				Name = NameList.RandomName( "elven female" );
			        Hue = Utility.RandomList( 1002,1003,1009,1010,1011,1016,1017,1023,1030 );
                                HairHue = Utility.RandomList( 1502,1507,1513,2213,2216,2218 );
                                HairItemID = Utility.RandomList( 12224,12225,12236,12237,12238,12239 );

			        SunElfFancyRobe robe = new SunElfFancyRobe();
			        robe.Hue = 2129;
			        robe.Movable = true;
			        AddItem( robe );
			}
			else
			{
				Body = 605;
				Name = NameList.RandomName( "elven male" );
			        Hue = Utility.RandomList( 1002,1003,1009,1010,1011,1016,1017,1023,1030 );
                                HairHue = Utility.RandomList( 1502,1507,1513,2213,2216,2218 );
                                HairItemID = Utility.RandomList( 12224,12225,12236,12237,12238,12239 );

			        SunElfFancyRobe robe = new SunElfFancyRobe();
			        robe.Hue = 2129;
			        robe.Movable = true;
			        AddItem( robe );
			}

			Container pack = new Backpack();

			pack.DropItem( new Pitcher( BeverageType.Water ) );
			pack.DropItem( new Gold( Utility.RandomMinMax( 5, 8 ) ) );
			pack.DropItem( new BlackPearl( Utility.RandomMinMax( 5, 10 ) ) );
			pack.DropItem( new Bloodmoss( Utility.RandomMinMax( 5, 10 ) ) );
			pack.DropItem( new Garlic( Utility.RandomMinMax( 5, 10 ) ) );
			pack.DropItem( new Ginseng( Utility.RandomMinMax( 5, 10 ) ) );
			pack.DropItem( new MandrakeRoot( Utility.RandomMinMax( 5, 10 ) ) );
			pack.DropItem( new Nightshade( Utility.RandomMinMax( 5, 10 ) ) );
			pack.DropItem( new SpidersSilk( Utility.RandomMinMax( 5, 10 ) ) );
			pack.DropItem( new SulfurousAsh( Utility.RandomMinMax( 5, 10 ) ) );

			PackItem( pack );

			switch ( Utility.Random( 32 ))
			{
					case 0: PackItem( new ClumsyScroll() ); break;
					case 1: PackItem( new CreateFoodScroll() ); break;
					case 2: PackItem( new FeeblemindScroll() ); break;
					case 3: PackItem( new HealScroll() ); break;
					case 4: PackItem( new MagicArrowScroll() ); break;
					case 5: PackItem( new NightSightScroll() ); break;
					case 6: PackItem( new ReactiveArmorScroll() ); break;
					case 7: PackItem( new WeakenScroll() ); break;
					case 8: PackItem( new AgilityScroll() ); break;
					case 9: PackItem( new CunningScroll() ); break;
					case 10: PackItem( new CureScroll() ); break;
					case 11: PackItem( new HarmScroll() ); break;
					case 12: PackItem( new MagicTrapScroll() ); break;
					case 13: PackItem( new MagicUnTrapScroll() ); break;
					case 14: PackItem( new ProtectionScroll() ); break;
					case 15: PackItem( new StrengthScroll() ); break;
					case 16: PackItem( new BlessScroll() ); break;
					case 17: PackItem( new FireballScroll() ); break;
					case 18: PackItem( new MagicLockScroll() ); break;
					case 19: PackItem( new PoisonScroll() ); break;
					case 20: PackItem( new TelekinisisScroll() ); break;
					case 21: PackItem( new TeleportScroll() ); break;
					case 22: PackItem( new UnlockScroll() ); break;
					case 23: PackItem( new WallOfStoneScroll() ); break;
					case 24: PackItem( new ArchCureScroll() ); break;
					case 25: PackItem( new ArchProtectionScroll() ); break;
					case 26: PackItem( new CurseScroll() ); break;
					case 27: PackItem( new FireFieldScroll() ); break;
					case 28: PackItem( new GreaterHealScroll() ); break;
					case 29: PackItem( new LightningScroll() ); break;
					case 30: PackItem( new ManaDrainScroll() ); break;
					case 31: PackItem( new RecallScroll() ); break;
			}

		}

		public override void GenerateLoot()
		{
			AddLoot( LootPack.LowScrolls, 2 );
			AddLoot( LootPack.Average );
			AddLoot( LootPack.Potions );
		}

		public override bool CanRummageCorpses{ get{ return true; } }

		public override void OnDamage( int amount, Mobile from, bool willKill )
		{
			if ( from != null && !willKill && amount > 5 && from.Player && 5 > Utility.Random( 100 ) )
			{
				string[] toSay = new string[]
					{
						"{0}!!  I have had enough of you foolish fiend!",
						"{0}!!  Prepare to face my fury!",
						"{0}!!  Why won't you die?!",
						"{0}!!  Stay and face me fool!"
					};

				this.Say( true, String.Format( toSay[Utility.Random( toSay.Length )], from.Name ) );
			}

			base.OnDamage( amount, from, willKill );
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

		public ZaythalorAdventurer( Serial serial ) : base( serial )
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