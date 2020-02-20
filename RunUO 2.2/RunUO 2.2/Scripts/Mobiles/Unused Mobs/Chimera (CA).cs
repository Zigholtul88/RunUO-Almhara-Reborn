using System;
using Server;
using System.Collections;
using Server.Items;
using Server.Targeting;

namespace Server.Mobiles
{
	[CorpseName( "a chimera corpse" )]
	public class Chimera : BaseCreature
	{
		public override WeaponAbility GetWeaponAbility()
		{
			return WeaponAbility.BleedAttack;
		}

		[Constructable]
		public Chimera() : base( AIType.AI_Melee, FightMode.Closest, 6, 1, 0.175, 0.350 )
		{
			Name = "a chimera";
			Body = 359;

			SetStr( 376, 449 );
			SetDex( 218, 252 );
			SetInt( 138, 164 );

			SetHits( 494, 527 );

			SetDamage( 13, 19 );

			SetDamageType( ResistanceType.Physical, 100 );

			SetResistance( ResistanceType.Physical, 50 );
			SetResistance( ResistanceType.Fire, 40 );
			SetResistance( ResistanceType.Cold, 30 );
			SetResistance( ResistanceType.Poison, 40 );
			SetResistance( ResistanceType.Energy, 40 );

			SetSkill( SkillName.MagicResist, 65.1, 80.0 );
			SetSkill( SkillName.Tactics, 65.4, 88.5 );
			SetSkill( SkillName.Wrestling, 68.8, 81.7 );

			Fame = 5500;
			Karma = -5500;

			Tamable = true;
			ControlSlots = 3;
			MinTameSkill = 82.7;

			PackReg( 25 );
		}

		public override void GenerateLoot()
		{
			AddLoot( LootPack.Rich, 3 );
			AddLoot( LootPack.Gems, 2 );
		}

		public override bool BleedImmune{ get{ return true; } }
		public override Poison PoisonImmune{ get{ return Poison.Greater; } }

		public override bool ReacquireOnMovement{ get{ return true; } }
		public override int Meat{ get{ return 8; } }
		public override int Hides{ get{ return 18; } }
		public override HideType HideType{ get{ return HideType.Horned; } }
		public override FoodType FavoriteFood{ get{ return FoodType.Meat | FoodType.Fish; } }

		public override int GetIdleSound() { return 0x517; } 
		public override int GetAngerSound() { return 0x518; } 
		public override int GetAttackSound() { return 0x516; } 
		public override int GetHurtSound() { return 0x519; } 
		public override int GetDeathSound() { return 0x515; }

		public Chimera( Serial serial ) : base( serial )
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