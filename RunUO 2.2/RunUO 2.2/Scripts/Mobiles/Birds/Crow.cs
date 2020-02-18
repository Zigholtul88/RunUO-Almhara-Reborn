using System;
using Server;
using Server.Items;
using Server.Mobiles;

namespace Server.Mobiles
{
	[CorpseName( "a crow corpse" )]	
	public class Crow : BaseCreature
	{
		[Constructable]
		public Crow() : base( AIType.AI_Animal, FightMode.Aggressor, 10, 1, 0.2, 0.4 )
		{
			Name = "a crow";
			Body = 6;
                        Hue = 1;

			SetStr( 12, 17 );
			SetDex( 9, 14 );
			SetInt( 5, 8 );

			SetHits( 10, 15 );
			SetMana( 100 );

			SetDamage( 2, 5 );

			SetDamageType( ResistanceType.Physical, 100 );

			SetResistance( ResistanceType.Physical, 5 );
			SetResistance( ResistanceType.Fire, 0 );
			SetResistance( ResistanceType.Cold, 0 );
			SetResistance( ResistanceType.Poison, 0 );
			SetResistance( ResistanceType.Energy, 0 );

			SetSkill( SkillName.Tactics, 93.1, 98.6 );
			SetSkill( SkillName.Wrestling, 93.1, 98.6 );
			SetSkill( SkillName.MagicResist, 2.3, 2.7 );

			Fame = 300;
			Karma = 0;

			Tamable = true;
			ControlSlots = 0;
			MinTameSkill = 0.0;

			switch ( Utility.Random( 6 ))
			{
				case 0: PackItem( new Apple() ); break;
				case 1: PackItem( new Banana() ); break;
				case 2: PackItem( new Grapes() ); break;
				case 3: PackItem( new Lemon() ); break;
				case 4: PackItem( new Lime() ); break;
				case 5: PackItem( new Pear() ); break;
			}
		}

		public override MeatType MeatType{ get{ return MeatType.Bird; } }
		public override int Meat{ get{ return 1; } }
		public override int Feathers{ get{ return 25; } }
		public override FoodType FavoriteFood{ get{ return FoodType.FruitsAndVegies; } }

		public Crow( Serial serial ) : base( serial )
		{
		}

		public override int GetIdleSound() { return 0x07D; }
		public override int GetAngerSound() { return 0x07E; }
		public override int GetAttackSound() { return 0x07F; }
		public override int GetHurtSound() { return 0x080; }
		public override int GetDeathSound() { return 0x081; }

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