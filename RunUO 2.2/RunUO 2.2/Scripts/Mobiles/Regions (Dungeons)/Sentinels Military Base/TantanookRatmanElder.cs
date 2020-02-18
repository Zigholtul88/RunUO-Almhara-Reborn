using System;
using System.Collections;
using Server.Misc;
using Server.Items;
using Server.Targeting;

namespace Server.Mobiles
{
	[CorpseName( "Tantanook's corpse" )]
	public class TantanookRatmanElder : BaseCreature
	{
		public override InhumanSpeech SpeechType{ get{ return InhumanSpeech.Ratman; } }

		[Constructable]
		public TantanookRatmanElder() : base( AIType.AI_Mage, FightMode.Closest, 10, 1, 0.175, 0.350 )
		{
			Name = "Tantanook";
			Title = "the Ratman Elder";
			Body = 142;
			BaseSoundID = 437;

			SetStr( 495, 518 );
			SetDex( 175, 180 );
			SetInt( 275, 300 );

			SetHits( 450, 475 );
			SetMana( 1025, 1050 );

			SetDamage( 10, 18 );

			SetDamageType( ResistanceType.Physical, 100 );

			SetResistance( ResistanceType.Physical, 50 );
			SetResistance( ResistanceType.Fire, 10 );
			SetResistance( ResistanceType.Cold, 10 );
			SetResistance( ResistanceType.Poison, 10 );
			SetResistance( ResistanceType.Energy, 100 );

			SetSkill( SkillName.EvalInt, 82.6, 93.2 );
			SetSkill( SkillName.Magery, 93.1, 95.6 );
			SetSkill( SkillName.MagicResist, 93.2, 96.1 );
			SetSkill( SkillName.Tactics, 77.6, 86.4 );
			SetSkill( SkillName.Wrestling, 85.0, 89.1 );

			Fame = 8000;
			Karma = -8000;

			PackGold( 25, 35 );
			PackReg( 20 );

			PackItem( new FishScale( Utility.RandomMinMax( 16, 25 ) ) );

			if ( 0.02 > Utility.RandomDouble() )
				PackStatue();
		}

		public override void GenerateLoot()
		{
			AddLoot( LootPack.Rich, 3 );
			AddLoot( LootPack.Gems, 3 );
			AddLoot( LootPack.LowScrolls, 5 );
			AddLoot( LootPack.Potions );
		}

		public override bool CanRummageCorpses{ get{ return true; } }
		public override int Meat{ get{ return 1; } }
		public override int Hides{ get{ return 8; } }
		public override HideType HideType{ get{ return HideType.Spined; } }

		public TantanookRatmanElder( Serial serial ) : base( serial )
		{
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );
			writer.Write( (int) 0 );
		}

		public override void Deserialize(GenericReader reader)
		{
			base.Deserialize(reader);

			int version = reader.ReadInt();
		}
	}
}