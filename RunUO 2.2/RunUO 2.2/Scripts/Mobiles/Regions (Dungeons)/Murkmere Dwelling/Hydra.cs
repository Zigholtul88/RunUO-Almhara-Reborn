using System;
using Server;
using Server.Items;
using Server.Targeting;

namespace Server.Mobiles
{
	[CorpseName( "a hydra corpse" )]
	public class Hydra : BaseCreature
	{
		[Constructable]
		public Hydra() : base( AIType.AI_Melee, FightMode.Closest, 10, 1, 0.2, 0.4 )
		{
			Name = "a hydra";
			Body = 0x109;
			BaseSoundID = 0x16A;

			SetStr( 801, 828 );
			SetDex( 102, 118 );
			SetInt( 102, 120 );

			SetHits( 1480, 1500 );

			SetDamage( 21, 26 );

			SetDamageType( ResistanceType.Physical, 60 );
			SetDamageType( ResistanceType.Fire, 10 );
			SetDamageType( ResistanceType.Cold, 10 );
			SetDamageType( ResistanceType.Poison, 10 );
			SetDamageType( ResistanceType.Energy, 10 );

			SetResistance( ResistanceType.Physical, 65 );
			SetResistance( ResistanceType.Fire, 70 );
			SetResistance( ResistanceType.Cold, 25 );
			SetResistance( ResistanceType.Poison, 35 );
			SetResistance( ResistanceType.Energy, 36 );

			SetSkill( SkillName.Wrestling, 103.5, 117.4 );
			SetSkill( SkillName.Tactics, 100.1, 109.8 );
			SetSkill( SkillName.Anatomy, 75.4, 79.8 );

			Tamable = true;
			ControlSlots = 5;
			MinTameSkill = 95.5;

			PackGold( 2226, 3043 );
		}

		public override void GenerateLoot()
		{
			AddLoot( LootPack.UltraRich, 3 );
			AddLoot( LootPack.MedScrolls, 5 );
			AddLoot( LootPack.LowScrolls, 5 );
			AddLoot( LootPack.Gems, 15 );
	        }

		public override bool HasBreath { get { return true; } }
		public override int Hides { get { return 40; } }
		public override int Meat { get { return 19; } }
		public override int Scales{ get{ return 12; } }
		public override ScaleType ScaleType{ get{ return (ScaleType)Utility.Random( 4 ); } }
		public override int TreasureMapLevel { get { return 2; } }
		public override bool CanAngerOnTame{ get { return true; } }
		public override FoodType FavoriteFood{ get{ return FoodType.Meat; } }
		public override Poison PoisonImmune{ get{ return Poison.Regular; } }

		public Hydra( Serial serial ) : base( serial )
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

