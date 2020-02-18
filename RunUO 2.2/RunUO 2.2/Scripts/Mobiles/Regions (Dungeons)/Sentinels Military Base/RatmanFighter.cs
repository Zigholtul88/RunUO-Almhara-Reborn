using System;
using System.Collections;
using Server.Misc;
using Server.Items;
using Server.Targeting;

namespace Server.Mobiles
{
	[CorpseName( "a ratman's corpse" )]
	public class RatmanFighter : BaseCreature
	{
		public override InhumanSpeech SpeechType{ get{ return InhumanSpeech.Ratman; } }

		public override WeaponAbility GetWeaponAbility()
		{
			switch ( Utility.Random( 3 ) )
			{
				default:
				case 0: return WeaponAbility.DoubleStrike;
				case 1: return WeaponAbility.WhirlwindAttack;
				case 2: return WeaponAbility.CrushingBlow;
			}
		}

		[Constructable]
		public RatmanFighter() : base( AIType.AI_Melee, FightMode.Closest, 5, 1, 0.3, 0.6 )
		{
			Name = NameList.RandomName( "ratman" );
			Title = "the Ratman Fighter";
			Body = Utility.RandomList( 42, 44, 45 );
			BaseSoundID = 437;

   			if (Body == 44) //Axe
   				{
  					DamageMin += 2;
   					DamageMax += 6;
   					RawStr += 10;
   					RawDex -= 10;
					Skills.Lumberjacking.Base += 75;
   				}

   			if (Body == 45) //Sword
   				{
  					DamageMin += 2;
   					DamageMax += 8;
   					RawStr += 10;
   					RawDex -= 10;
					Skills.Swords.Base += 75;
   				}

			SetStr( 150, 175 );
			SetDex( 105, 135 );
			SetInt( 87, 92 );

			SetHits( 125, 165 );

			SetDamage( 8, 12 );

			SetDamageType( ResistanceType.Physical, 100 );

			SetResistance( ResistanceType.Physical, 40 );
			SetResistance( ResistanceType.Fire, 10 );
			SetResistance( ResistanceType.Cold, 10 );
			SetResistance( ResistanceType.Poison, 10 );
			SetResistance( ResistanceType.Energy, 10 );

			SetSkill( SkillName.Anatomy, 73.2, 89.1 );
			SetSkill( SkillName.MagicResist, 73.8, 82.3 );
			SetSkill( SkillName.Tactics, 66.3, 79.2 );
			SetSkill( SkillName.Wrestling, 69.1, 82.1 );

			Fame = 2500;
			Karma = -2500;

			PackGold( 12, 16 );

			PackItem( new FishScale( Utility.RandomMinMax( 12, 16 ) ) );

			switch ( Utility.Random( 6 ))
			{
				case 0: PackItem( new ChickenLeg() ); break;
				case 1: PackItem( new CookedBird() ); break;
				case 2: PackItem( new FishSteak() ); break;
				case 3: PackItem( new LambLeg() ); break;
				case 4: PackItem( new Ribs() ); break;
				case 5: PackItem( new Sausage() ); break;
			}

			switch ( Utility.Random( 6 ))
			{
				case 0: PackItem( new LeatherArms() ); break;
				case 1: PackItem( new LeatherCap() ); break;
				case 2: PackItem( new LeatherChest() ); break;
				case 3: PackItem( new LeatherGloves() ); break;
				case 4: PackItem( new LeatherGorget() ); break;
				case 5: PackItem( new LeatherLegs() ); break;
			}

			Container pack = new Backpack();

			pack.DropItem( new Gold( Utility.RandomMinMax( 11, 13 ) ) );
			pack.DropItem( new Lockpick( Utility.RandomMinMax( 5, 10 ) ) );
			pack.DropItem( new BeverageBottle( BeverageType.Wine ) );

			PackItem( pack );
		}

		public override void GenerateLoot()
		{
			AddLoot( LootPack.Rich );

   			if (Body == 44) //Axe 
   				{
					AddItem( new Axe() );
   				}

   			if (Body == 45) //Sword
   				{
					AddItem( new Longsword() );
   				}
		}

		public override bool CanRummageCorpses{ get{ return true; } }
		public override int Hides{ get{ return 8; } }
		public override HideType HideType{ get{ return HideType.Spined; } }

		public RatmanFighter( Serial serial ) : base( serial )
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
