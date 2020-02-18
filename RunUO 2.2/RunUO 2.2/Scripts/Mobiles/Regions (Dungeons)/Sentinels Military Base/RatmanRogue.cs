using System;
using System.Collections;
using Server.Misc;
using Server.Items;
using Server.Targeting;

namespace Server.Mobiles
{
	[CorpseName( "a ratman's corpse" )]
	public class RatmanRogue : BaseCreature
	{
		public override InhumanSpeech SpeechType{ get{ return InhumanSpeech.Ratman; } }

		[Constructable]
		public RatmanRogue() : base( AIType.AI_Melee, FightMode.Closest, 10, 1, 0.175, 0.350 )
		{
			Name = NameList.RandomName( "ratman" );
			Title = "the Ratman Rogue";
			Body = 42;
			BaseSoundID = 437;

			SetStr( 124, 135 );
			SetDex( 145, 220 );
			SetInt( 62, 73 );

			SetHits( 105, 135 );

			SetDamage( 3, 8 );

			SetDamageType( ResistanceType.Physical, 100 );

			SetResistance( ResistanceType.Physical, 35 );
			SetResistance( ResistanceType.Fire, 10 );
			SetResistance( ResistanceType.Cold, 10 );
			SetResistance( ResistanceType.Poison, 10 );
			SetResistance( ResistanceType.Energy, 10 );

			SetSkill( SkillName.Anatomy, 25.5, 35.2 );
			SetSkill( SkillName.Fencing, 73.1, 75.3 );
			SetSkill( SkillName.MagicResist, 62.4, 66.2 );
			SetSkill( SkillName.Tactics, 59.2, 63.1 );
			SetSkill( SkillName.Wrestling, 61.1, 73.5 );

			Fame = 2000;
			Karma = -2000;

			PackGold( 9, 11 );

			AddItem( new Dagger() );

			switch ( Utility.Random( 6 ))
			{
				case 0: PackItem( new ChickenLeg() ); break;
				case 1: PackItem( new CookedBird() ); break;
				case 2: PackItem( new FishSteak() ); break;
				case 3: PackItem( new LambLeg() ); break;
				case 4: PackItem( new Ribs() ); break;
				case 5: PackItem( new Sausage() ); break;
			}

			PackItem( new FishScale( Utility.RandomMinMax( 12, 16 ) ) );

			Container pack = new Backpack();

			pack.DropItem( new Gold( Utility.RandomMinMax( 11, 13 ) ) );
			pack.DropItem( new FishScale( Utility.RandomMinMax( 12, 16 ) ) );
			pack.DropItem( new Lockpick( Utility.RandomMinMax( 2, 5 ) ) );
			pack.DropItem( new Jug( BeverageType.Cider ) );

			PackItem( pack );
		}

		public override void GenerateLoot()
		{
			AddLoot( LootPack.Rich );
		}

		public override bool CanRummageCorpses{ get{ return true; } }
		public override int Hides{ get{ return 8; } }
		public override HideType HideType{ get{ return HideType.Spined; } }

		public RatmanRogue( Serial serial ) : base( serial )
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
