using System;
using Server;
using Server.Items;

namespace Server.Mobiles
{
	[CorpseName( "a ghostly corpse" )]
	public class Shade : BaseCreature
	{
		[Constructable]
		public Shade() : base( AIType.AI_Mage, FightMode.Closest, 10, 1, 0.2, 0.4 )
		{
			Name = "a shade";
			Body = 26;
			Hue = 0x4001;
			BaseSoundID = 0x482;

			SetStr( 76, 100 );
			SetDex( 76, 94 );
			SetInt( 37, 59 );

			SetHits( 92, 120 );
			SetMana( 185, 295 );

			SetDamage( 7, 11 );

			SetDamageType( ResistanceType.Physical, 50 );
			SetDamageType( ResistanceType.Cold, 50 );

			SetResistance( ResistanceType.Physical, 28 );
			SetResistance( ResistanceType.Cold, 15 );
			SetResistance( ResistanceType.Poison, 10 );

			SetSkill( SkillName.EvalInt, 30.4, 43.6 );
			SetSkill( SkillName.Magery, 58.6, 71.3 );
			SetSkill( SkillName.MagicResist, 55.2, 67.5 );
			SetSkill( SkillName.Tactics, 45.7, 59.4 );
			SetSkill( SkillName.Wrestling, 50.9, 58.4 );

			Fame = 4000;
			Karma = -4000;

			VirtualArmor = 28;

			PackGold( 5, 7 );
			PackReg( 10 );

			PackItem( new ShadowEssence( Utility.RandomMinMax( 8, 12 ) ) );
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

		public Shade( Serial serial ) : base( serial )
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