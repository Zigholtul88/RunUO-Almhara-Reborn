using System;
using Server;
using Server.Items;
using Server.Mobiles;

namespace Server.Mobiles
{
	[CorpseName( "a broucci corpse" )]
	public class Broucci : BaseMount
	{
		[Constructable]
		public Broucci() : base( "a broucci", 0x317, 0x3E97, AIType.AI_Animal, FightMode.Aggressor, 10, 1, 0.2, 0.4 )
		{
			SetStr( 147, 170 );
			SetDex( 21, 26 );
			SetInt( 32, 44 );

			SetHits( 150, 200 );

			SetDamage( 5, 9 );

			SetDamageType( ResistanceType.Physical, 100 );

			SetResistance( ResistanceType.Physical, 35 );
			SetResistance( ResistanceType.Fire, 5 );
			SetResistance( ResistanceType.Cold, 20 );
			SetResistance( ResistanceType.Poison, 35 );
			SetResistance( ResistanceType.Energy, 15 );

			SetSkill( SkillName.MagicResist, 34.7, 41.2 );
			SetSkill( SkillName.Tactics, 93.1, 98.6 );
			SetSkill( SkillName.Wrestling, 93.1, 98.6 );

			Fame = 1200;
			Karma = -1200;

			Tamable = true;
			ControlSlots = 1;
			MinTameSkill = 28.7;
		}

		public override int Meat { get { return 1; } }

		public override FoodType FavoriteFood{ get{ return FoodType.Meat; } }

		public override int GetIdleSound() { return 0x4E7; } 
		public override int GetAngerSound() { return 0x4E8; } 
		public override int GetAttackSound() { return 0x4E6; } 
		public override int GetHurtSound() { return 0x4E9; } 
		public override int GetDeathSound() { return 0x4E5; }

		public Broucci( Serial serial ) : base( serial )
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