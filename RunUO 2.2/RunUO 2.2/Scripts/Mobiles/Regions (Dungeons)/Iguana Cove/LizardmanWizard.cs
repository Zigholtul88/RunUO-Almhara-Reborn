using System;
using System.Collections;
using Server.Items;
using Server.Targeting;
using Server.Misc;

namespace Server.Mobiles
{
	[CorpseName( "a lizardman wizard corpse" )]
	public class LizardmanWizard : BaseCreature
	{
		public override InhumanSpeech SpeechType{ get{ return InhumanSpeech.Lizardman; } }

		[Constructable]
		public LizardmanWizard() : base( AIType.AI_Mage, FightMode.Closest, 6, 1, 0.3, 0.6 )
		{
			Name = NameList.RandomName( "lizardman" );
			Title = "the Lizardman Wizard"; 
                        Body = 33;
			BaseSoundID = 417;

			SetStr( 132, 145 );
			SetDex( 97, 102 );
			SetInt( 157, 163 );

			SetHits( 225, 350 );
			SetMana( 314, 326 );

			SetDamage( 1, 4 );

			SetDamageType( ResistanceType.Physical, 100 );

			SetResistance( ResistanceType.Physical, 28 );
			SetResistance( ResistanceType.Fire, 5 );
			SetResistance( ResistanceType.Cold, 5 );
			SetResistance( ResistanceType.Poison, 15 );

			SetSkill( SkillName.EvalInt, 23.8, 25.6 );
			SetSkill( SkillName.Magery, 45.5, 50.5 );
			SetSkill( SkillName.MagicResist, 39.6, 58.8 );
			SetSkill( SkillName.Tactics, 59.9, 76.4 );
			SetSkill( SkillName.Wrestling, 51.2, 67.5 );

			Fame = 8500;
			Karma = -8500;

			PackGold( 310, 415 );
			PackReg( 50, 95 );

			switch ( Utility.Random( 16 ))
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
			}

			switch ( Utility.Random( 9 ))
			{
				case 0: PackItem( new Agate() ); break;
				case 1: PackItem( new Beryl() ); break;
				case 2: PackItem( new ChromeDiopside() ); break;
				case 3: PackItem( new FireOpal() ); break;
				case 4: PackItem( new MoonstoneCustom() ); break;
				case 5: PackItem( new Onyx() ); break;
				case 6: PackItem( new Opal() ); break;
				case 7: PackItem( new Pearl() ); break;
				case 8: PackItem( new TurquoiseCustom() ); break;
			}

			if ( Utility.RandomDouble() < 0.01 )
        		PackItem( new BigColourfulMarble() );
		}

		public override void GenerateLoot()
		{
			AddLoot( LootPack.LowScrolls );
		}

		public override bool CanRummageCorpses{ get{ return true; } }

                public override void OnCarve( Mobile from, Corpse corpse, Item with )
		{
			if ( corpse.Carved == false )
			{
			      base.OnCarve( from, corpse, with );

                              corpse.AddCarvedItem( new RawRibs(), from );
                              corpse.AddCarvedItem( new SpinedHides(12), from );
                              corpse.AddCarvedItem( new FishScale( Utility.RandomMinMax( 4, 8 ) ), from );
                              corpse.AddCarvedItem( new SerpentScale( Utility.RandomMinMax( 7, 12 ) ), from );

                              from.SendMessage( "You carve up raw ribs, spined hides, and an assortment of various scales." ); 
                              corpse.Carved = true;
			}
                }

		public LizardmanWizard( Serial serial ) : base( serial )
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
