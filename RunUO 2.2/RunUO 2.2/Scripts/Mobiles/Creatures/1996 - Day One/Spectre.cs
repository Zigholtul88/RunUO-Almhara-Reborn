using System;
using Server;
using Server.Items;

namespace Server.Mobiles
{
	[CorpseName( "a ghostly corpse" )]
	public class Spectre : BaseCreature
	{
		[Constructable]
		public Spectre() : base( AIType.AI_Mage, FightMode.Closest, 10, 1, 0.2, 0.4 )
		{
			Name = "a spectre";
			Body = 26;
			Hue = 0x4001;
			BaseSoundID = 0x482;

			SetStr( 77, 97 );
			SetDex( 76, 93 );
			SetInt( 44, 60 );

			SetHits( 92, 120 );
			SetMana( 220, 300 );

			SetDamage( 7, 11 );

			SetDamageType( ResistanceType.Physical, 50 );
			SetDamageType( ResistanceType.Cold, 50 );

			SetResistance( ResistanceType.Physical, 28 );
			SetResistance( ResistanceType.Cold, 15 );
			SetResistance( ResistanceType.Poison, 10 );

			SetSkill( SkillName.EvalInt, 30.4, 43.6 );
			SetSkill( SkillName.Magery, 59.0, 72.0 );
			SetSkill( SkillName.MagicResist, 56.7, 69.4 );
			SetSkill( SkillName.Tactics, 45.2, 59.6 );
			SetSkill( SkillName.Wrestling, 51.3, 58.8 );

			Fame = 4000;
			Karma = -4000;

			VirtualArmor = 28;

			PackReg( 10 );
			PackGold( 4, 7 );

			PackItem( new ShadowEssence( Utility.RandomMinMax( 7, 12 ) ) );

 			if ( Utility.RandomDouble() < 0.10 )
				PackItem( new MagicTrapScroll() );
		}
				
		public override void GenerateLoot()
		{
			AddLoot( LootPack.Meager );
		}

		public override bool BleedImmune{ get{ return true; } }

		public override OppositionGroup OppositionGroup
		{
			get{ return OppositionGroup.FeyAndUndead; }
		}

		public override Poison PoisonImmune{ get{ return Poison.Lethal; } }

		public Spectre( Serial serial ) : base( serial )
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