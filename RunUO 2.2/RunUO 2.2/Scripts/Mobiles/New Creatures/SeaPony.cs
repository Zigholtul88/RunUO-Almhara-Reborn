using System;
using Server.Mobiles;

namespace Server.Mobiles
{
	[CorpseName( "a sea pony corpse" )]
	public class SeaPony : BaseMount
	{
		[Constructable]
		public SeaPony() : base( "a sea pony", 0x114, 0x3E90, AIType.AI_Melee, FightMode.Aggressor, 10, 1, 0.2, 0.35 )
		{
			Hue = Utility.RandomList( 0,3,28,38,48,53,58,63,88,93 );

			SetStr( 296, 320 );
			SetDex( 81, 105 );
			SetInt( 36, 60 );

			SetDamage( 7, 21 );

			SetDamageType( ResistanceType.Physical, 100 );

			SetResistance( ResistanceType.Physical, 28 );
			SetResistance( ResistanceType.Fire, 5 );
			SetResistance( ResistanceType.Cold, 20 );
			SetResistance( ResistanceType.Poison, 5 );
			SetResistance( ResistanceType.Energy, 10 );

			SetSkill( SkillName.MagicResist, 70.0 );
			SetSkill( SkillName.Tactics, 90.0 );
			SetSkill( SkillName.Wrestling, 90.0 );

			Fame = 4500;
			Karma = -4500;

			Tamable = true;
			ControlSlots = 1;
			MinTameSkill = 50.0;
		}

		public override int GetIdleSound() { return 0x478; } 
		public override int GetAngerSound() { return 0x479; } 
		public override int GetAttackSound() { return 0x47A; } 
		public override int GetHurtSound() { return 0x47B; } 
		public override int GetDeathSound() { return 0x47C; }

		public override int Meat{ get{ return 3; } }
		public override FoodType FavoriteFood{ get{ return FoodType.FruitsAndVegies | FoodType.GrainsAndHay; } }

		public SeaPony( Serial serial ) : base( serial )
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