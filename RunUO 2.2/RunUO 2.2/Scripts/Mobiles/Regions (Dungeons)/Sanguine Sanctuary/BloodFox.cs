using System;
using Server;
using Server.Items;
using Server.Mobiles;

namespace Server.Mobiles
{
	[CorpseName( "a blood fox corpse" )]	
	public class BloodFox : BaseCreature
	{
		[Constructable]
		public BloodFox() : base(AIType.AI_Melee, FightMode.Closest, 10, 1, 0.2, 0.4)
		{
			Name = "a blood fox";
			Body = 246;
			Hue = 0x648;

		        SetStr( 300, 320 );
		        SetDex( 190, 200 );
                        SetInt( 170, 210 );

		        SetHits( 390, 400 );

		        SetDamage( 16, 22 );

                        SetDamageType(ResistanceType.Physical, 100);

                        SetResistance(ResistanceType.Physical, 50);
                        SetResistance(ResistanceType.Fire, 20);
                        SetResistance(ResistanceType.Cold, 55);
                        SetResistance(ResistanceType.Poison, 25);
                        SetResistance(ResistanceType.Energy, 35);

                        SetSkill(SkillName.DetectHidden, 50.0, 60.0);
                        SetSkill(SkillName.MagicResist, 40.0, 50.0);
                        SetSkill(SkillName.Tactics, 50.0, 70.0);
                        SetSkill(SkillName.Wrestling, 75.0, 90.0);

			Fame = 25000;
			Karma = 25000;

                        Tamable = true;
                        ControlSlots = 2;
                        MinTameSkill = 72.0;
		}

		public override void GenerateLoot()
		{
			AddLoot( LootPack.Rich, 2 );
		}

		public override int Meat{ get{ return 5; } }
		public override int Hides{ get{ return 10; } }
		public override HideType HideType{ get{ return HideType.Barbed; } }
		public override FoodType FavoriteFood{ get{ return FoodType.Fish; } }

		public BloodFox( Serial serial ) : base( serial )
		{
		}

		public override int GetIdleSound() { return 0x4DD; }
		public override int GetAngerSound() { return 0x4DE; }
		public override int GetAttackSound() { return 0x4DC; }
		public override int GetHurtSound() { return 0x4DF; }
		public override int GetDeathSound() { return 0x4DB; }

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