using System;
using System.Collections;
using Server.Items;
using Server.Targeting;

namespace Server.Mobiles
{
	[CorpseName( "a sickler corpse" )]
	public class Sickler : BaseCreature
	{
		public override WeaponAbility GetWeaponAbility()
		{
			return WeaponAbility.BleedAttack;
		}

		[Constructable]
		public Sickler() : base( AIType.AI_Melee, FightMode.Closest, 8, 1, 0.175, 0.350 )
		{
			Name = "a sickler";
			Body = 306;
                        Hue = 2102;
			BaseSoundID = 0x2A7;

			SetStr( 189, 235 );
			SetDex( 69, 87 );
			SetInt( 62, 76 );

			SetHits( 512, 546 );

			SetDamage( 5, 10 );

			SetDamageType( ResistanceType.Physical, 100 );

			SetResistance( ResistanceType.Physical, 35 );
			SetResistance( ResistanceType.Fire, 15 );
			SetResistance( ResistanceType.Cold, 20 );
			SetResistance( ResistanceType.Poison, 25 );
			SetResistance( ResistanceType.Energy, 25 );

			SetSkill( SkillName.MagicResist, 45.1, 53.8 );
			SetSkill( SkillName.Tactics, 99.1, 118.8 );
			SetSkill( SkillName.Wrestling, 99.3, 111.3 );

			Fame = 18000;
			Karma = -18000;

			PackGold( 620, 823 );
			PackReg( 54, 100 );

			PackItem( new FishScale( Utility.RandomMinMax( 13, 17 ) ) );

			PackItem( new SummonCreatureScroll() );

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
		}

		public override void GenerateLoot()
		{
			AddLoot( LootPack.Gems, 8 );
			AddLoot( LootPack.Potions );
		}

		public override bool BleedImmune{ get{ return true; } }
		public override bool CanRummageCorpses{ get{ return true; } }
		public override int Meat{ get{ return 2; } }

		public Sickler( Serial serial ) : base( serial )
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
