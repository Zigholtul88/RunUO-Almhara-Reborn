using System;
using System.Collections;
using Server.Misc;
using Server.Items;
using Server.Targeting;

namespace Server.Mobiles
{
	[CorpseName( "a ratman archer corpse" )]
	public class RatmanArcher : BaseCreature
	{
		public override InhumanSpeech SpeechType{ get{ return InhumanSpeech.Ratman; } }

		public override WeaponAbility GetWeaponAbility()
		{
			return WeaponAbility.LightningArrow;
		}

		[Constructable]
		public RatmanArcher() : base( AIType.AI_Archer, FightMode.Closest, 8, 1, 0.175, 0.350 )
		{
			Name = NameList.RandomName( "ratman" );
			Body = 0x8E;
			BaseSoundID = 437;

			SetStr( 146, 180 );
			SetDex( 103, 127 );
			SetInt( 116, 138 );

			SetHits( 176, 216 );

			SetDamage( 4, 10 );

			SetDamageType( ResistanceType.Physical, 100 );

			SetResistance( ResistanceType.Physical, 56 );
			SetResistance( ResistanceType.Fire, 10 );
			SetResistance( ResistanceType.Cold, 10 );
			SetResistance( ResistanceType.Poison, 10 );
			SetResistance( ResistanceType.Energy, 10 );

			SetSkill( SkillName.Anatomy, 63.0, 91.5 );
			SetSkill( SkillName.Archery, 77.3, 87.0 );
			SetSkill( SkillName.MagicResist, 67.5, 89.4 );
			SetSkill( SkillName.Tactics, 54.2, 73.6 );
			SetSkill( SkillName.Wrestling, 57.3, 77.0 );

			Fame = 6500;
			Karma = -6500;

			VirtualArmor = 56;

			PackGold( 7, 12 );
			AddItem( new Bow() );
			PackItem( new Arrow( Utility.RandomMinMax( 15, 20 ) ) );

			PackItem( new FishScale( Utility.RandomMinMax( 12, 16 ) ) );
		}

		public override void GenerateLoot()
		{
			AddLoot( LootPack.Rich );
		}

		public override bool CanRummageCorpses{ get{ return true; } }
		public override int Hides{ get{ return 8; } }
		public override HideType HideType{ get{ return HideType.Spined; } }

		public RatmanArcher( Serial serial ) : base( serial )
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

			if ( Body == 42 )
			{
				Body = 0x8E;
				Hue = 0;
			}
		}
	}
}
