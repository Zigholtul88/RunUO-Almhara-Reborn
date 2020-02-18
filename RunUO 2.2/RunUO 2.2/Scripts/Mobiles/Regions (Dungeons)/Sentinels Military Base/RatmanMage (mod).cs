using System;
using System.Collections;
using Server.Misc;
using Server.Items;
using Server.Targeting;

namespace Server.Mobiles
{
	[CorpseName( "a glowing ratman corpse" )]
	public class RatmanMage : BaseCreature
	{
		public override InhumanSpeech SpeechType{ get{ return InhumanSpeech.Ratman; } }

		[Constructable]
		public RatmanMage() : base( AIType.AI_Mage, FightMode.Closest, 5, 1, 0.2, 0.4 )
		{
			Name = NameList.RandomName( "ratman" );
			Body = 0x8F;
			BaseSoundID = 437;

			SetStr( 147, 178 );
			SetDex( 102, 129 );
			SetInt( 187, 209 );

			SetHits( 176, 216 );
                        SetMana( 935, 1045 );

			SetDamage( 7, 14 );

			SetDamageType( ResistanceType.Physical, 100 );

			SetResistance( ResistanceType.Physical, 30 );
			SetResistance( ResistanceType.Fire, 10 );
			SetResistance( ResistanceType.Cold, 10 );
			SetResistance( ResistanceType.Poison, 10 );
			SetResistance( ResistanceType.Energy, 10 );

			SetSkill( SkillName.EvalInt, 30.4, 43.6 );
			SetSkill( SkillName.Magery, 66.3, 76.6 );
			SetSkill( SkillName.MagicResist, 60.2, 74.8 );
			SetSkill( SkillName.Tactics, 50.6, 64.6 );
			SetSkill( SkillName.Wrestling, 49.5, 54.9 );

			Fame = 3500;
			Karma = -3500;

			PackGold( 10, 14 );
			PackReg( 5, 10 );

			PackItem( new ArcaneStone( Utility.RandomMinMax( 4, 6 ) ) );
			PackItem( new FishScale( Utility.RandomMinMax( 7, 11 ) ) );

			if ( 0.02 > Utility.RandomDouble() )
				PackStatue();
		}
		public override void GenerateLoot()
		{
			AddLoot( LootPack.Rich );
			AddLoot( LootPack.LowScrolls );
		}

		public override bool CanRummageCorpses{ get{ return true; } }
		public override int Hides{ get{ return 8; } }
		public override HideType HideType{ get{ return HideType.Spined; } }

		public RatmanMage( Serial serial ) : base( serial )
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
				Body = 0x8F;
				Hue = 0;
			}
		}
	}
}
