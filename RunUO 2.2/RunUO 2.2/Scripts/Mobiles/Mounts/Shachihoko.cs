using System;
using Server;
using Server.Items;
using Server.Mobiles;

namespace Server.Mobiles
{
	[CorpseName( "a shachihoko corpse" )]
	public class Shachihoko : BaseMount
	{
		public override WeaponAbility GetWeaponAbility()
		{
			return WeaponAbility.BleedAttack;
		}

		[Constructable]
		public Shachihoko() : base( "a shachihoko", 0x11C, 0x3E92, AIType.AI_Animal, FightMode.Aggressor, 10, 1, 0.2, 0.4 )
		{
                        Hue = 88;

			SetStr( 147, 170 );
			SetDex( 21, 26 );
			SetInt( 32, 44 );

			SetDamage( 1, 5 );

			SetDamageType( ResistanceType.Physical, 100 );

			SetResistance( ResistanceType.Physical, 35 );
			SetResistance( ResistanceType.Fire, 70 );
			SetResistance( ResistanceType.Cold, 20 );
			SetResistance( ResistanceType.Poison, 35 );
			SetResistance( ResistanceType.Energy, 15 );

			SetSkill( SkillName.MagicResist, 34.7, 41.2 );
			SetSkill( SkillName.Ninjitsu, 60.0 );
			SetSkill( SkillName.Tactics, 93.1, 98.6 );
			SetSkill( SkillName.Wrestling, 93.1, 98.6 );

			CanSwim = true;
			CantWalk = false;

			Fame = 1500;
			Karma = -1500;

			Tamable = true;
			ControlSlots = 1;
			MinTameSkill = 40.5;

                        PackGold( 13, 19 );
			PackItem( new Bone( 2 ) );
			PackItem( new FishScale( Utility.RandomMinMax( 12, 15 ) ) );
		}

		public override void GenerateLoot()
		{
			AddLoot( LootPack.Gems );
			AddLoot( LootPack.Potions );
		}

		public override int Meat { get { return 1; } }

		public override FoodType FavoriteFood{ get{ return FoodType.Meat | FoodType.Fish; } }

		public override int GetIdleSound() { return 0x517; } 
		public override int GetAngerSound() { return 0x518; } 
		public override int GetAttackSound() { return 0x516; } 
		public override int GetHurtSound() { return 0x519; } 
		public override int GetDeathSound() { return 0x515; }

		public Shachihoko( Serial serial ) : base( serial )
		{
		}

		public override void Serialize( GenericWriter writer )
		{
			base.Serialize( writer );

			writer.Write( (int)0 );
		}

		public override void Deserialize( GenericReader reader )
		{
			base.Deserialize( reader );

			int version = reader.ReadInt();
		}
	}
}