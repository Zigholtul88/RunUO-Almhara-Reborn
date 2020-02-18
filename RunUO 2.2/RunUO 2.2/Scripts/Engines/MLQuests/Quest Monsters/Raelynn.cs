using System;
using System.Collections;
using System.Collections.Generic;
using Server;
using Server.ContextMenus;
using Server.Items;
using Server.Misc;
using Server.Mobiles;
using Server.Spells;
using Server.Targeting;

namespace Server.Mobiles 
{ 
	[CorpseName( "the corpse of Raelynn" )] 
	public class Raelynn : BaseCreature 
	{ 
		[Constructable] 
		public Raelynn() : base( AIType.AI_Mage, FightMode.Closest, 5, 1, 0.2, 0.4 ) 
		{ 
			Name = "Raelynn";
			Title = "the Gravefinder";
			Body = 0x191;
			SpeechHue = Utility.RandomDyedHue();
			Hue = Utility.RandomSkinHue();

			SetStr( 85, 105 );
			SetDex( 94, 114 );
                        SetInt( 96, 120 );

			SetHits( 200, 250 );
			SetMana( 1150, 1200 );

			SetDamage( 1, 5 );

			SetDamageType( ResistanceType.Physical, 100 );

			SetResistance( ResistanceType.Physical, 16 );
			SetResistance( ResistanceType.Fire, 5 );
			SetResistance( ResistanceType.Poison, 5 );
			SetResistance( ResistanceType.Energy, 5 );

			SetSkill( SkillName.EvalInt, 76.7, 85.7 );
			SetSkill( SkillName.MagicResist, 83.2, 88.9 );
			SetSkill( SkillName.Meditation, 99.2, 99.9 );
			SetSkill( SkillName.Necromancy, 80.0, 98.0 );
			SetSkill( SkillName.Tactics, 74.6, 78.2 );
			SetSkill( SkillName.Wrestling, 34.2, 58.7 );

			Fame = 4000;
			Karma = -4000;

			AddItem( new Robe( Utility.RandomHairHue() ) );
			AddItem( new WizardsHat( Utility.RandomMetalHue() ) );
			AddItem( new Sandals( Utility.RandomBirdHue() ) ); 

			PackGold( 205, 398 );
		
			PackItem( new ArcaneStone( Utility.RandomMinMax( 5, 8 ) ) );

			Container pack = new Backpack();
			pack.DropItem( new BlackPearl( Utility.RandomMinMax( 9, 10 ) ) );
			pack.DropItem( new Bloodmoss( Utility.RandomMinMax( 9, 10 ) ) );
			pack.DropItem( new Garlic( Utility.RandomMinMax( 9, 10 ) ) );
			pack.DropItem( new Ginseng( Utility.RandomMinMax( 9, 10 ) ) );
			pack.DropItem( new MandrakeRoot( Utility.RandomMinMax( 9, 10 ) ) );
			pack.DropItem( new Nightshade( Utility.RandomMinMax( 9, 10 ) ) );
			pack.DropItem( new SpidersSilk( Utility.RandomMinMax( 9, 10 ) ) );
			pack.DropItem( new SulfurousAsh( Utility.RandomMinMax( 9, 10 ) ) );
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
		}

		public override bool CanRummageCorpses{ get{ return true; } }
		public override bool AlwaysMurderer{ get{ return true; } }

		public Raelynn( Serial serial ) : base( serial )
		{
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
	}
}
