using System;
using System.Collections;
using Server.Misc;
using Server.Items;
using Server.Mobiles;
using Server.Targeting;

namespace Server.Mobiles
{
	[CorpseName( "the corpse of Chiikkaha the Toothed" )]
	public class ChiikkahaTheToothed : BaseCreature
	{
		public override InhumanSpeech SpeechType{ get{ return InhumanSpeech.Ratman; } }

		[Constructable]
		public ChiikkahaTheToothed() : base( AIType.AI_Mage, FightMode.Closest, 5, 1, 0.2, 0.4 )
		{
			Name = "Chiikkaha the Toothed";
			Body = 0x8F;
			BaseSoundID = 437;

			SetStr( 450, 476 );
			SetDex( 157, 179 );
			SetInt( 251, 275 );

			SetHits( 400, 425 );
			SetMana( 1025, 1050 );

			SetDamage( 10, 17 );

			SetDamageType( ResistanceType.Physical, 100 );

			SetResistance( ResistanceType.Physical, 40 );
			SetResistance( ResistanceType.Fire, 10 );
			SetResistance( ResistanceType.Cold, 10 );
			SetResistance( ResistanceType.Poison, 10 );
			SetResistance( ResistanceType.Energy, 100 );

			SetSkill( SkillName.EvalInt, 70.1, 80.0 );
			SetSkill( SkillName.Magery, 70.1, 90.0 );
			SetSkill( SkillName.MagicResist, 65.1, 96.0 );
			SetSkill( SkillName.Tactics, 50.1, 75.0 );
			SetSkill( SkillName.Wrestling, 50.1, 75.0 );

			Fame = 7500;
			Karma = -7500;

			PackGold( 10, 14 );
			PackReg( 5, 10 );

			PackItem( new ArcaneStone( Utility.RandomMinMax( 4, 6 ) ) );
			PackItem( new FishScale( Utility.RandomMinMax( 7, 11 ) ) );

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
		public override int Hides{ get{ return 8; } }
		public override HideType HideType{ get{ return HideType.Spined; } }

		public ChiikkahaTheToothed( Serial serial ) : base( serial )
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
