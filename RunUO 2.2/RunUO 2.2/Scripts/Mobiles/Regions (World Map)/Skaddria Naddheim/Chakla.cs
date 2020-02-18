using System;
using System.Collections;
using System.Collections.Generic;
using Server;
using Server.ContextMenus;
using Server.Items;
using Server.Misc;
using Server.Mobiles;
using Server.Targeting;

namespace Server.Mobiles
{
	[CorpseName( "a cha kla corpse" )]
	public class Chakla : BaseCreature
	{
		[Constructable]
		public Chakla() : base( AIType.AI_Mage, FightMode.Aggressor, 10, 1, 0.2, 0.4 )
		{
			Name = "a  cha kla";
			Body = 0xC9;
			Hue = 2405;
			BaseSoundID = 0x69;

			SetStr( 10 );
			SetDex( 35 );
			SetInt( 96, 120 );

			SetMana( 1150, 1200 );

			SetDamage( 1, 2 );

			SetDamageType( ResistanceType.Physical, 100 );

			SetResistance( ResistanceType.Physical, 5 );

			SetSkill( SkillName.Anatomy, 0.0 );
			SetSkill( SkillName.EvalInt, 76.7, 85.7 );
			SetSkill( SkillName.Magery, 80.0, 98.0 );
			SetSkill( SkillName.MagicResist, 50.0 );
			SetSkill( SkillName.Meditation, 99.2, 99.9 );
			SetSkill( SkillName.Tactics, 45.6, 54.4 );
			SetSkill( SkillName.Wrestling, 50.7, 59.6 );

			Fame = 0;
			Karma = 500;

			Tamable = true;
			ControlSlots = 1;
			MinTameSkill = 25.0;

			PackItem( new ArcaneStone( Utility.RandomMinMax( 5, 8 ) ) );

			Container pack = new Backpack();
			pack.DropItem( new BlackPearl( Utility.RandomMinMax( 1, 10 ) ) );
			pack.DropItem( new Bloodmoss( Utility.RandomMinMax( 1, 10 ) ) );
			pack.DropItem( new Garlic( Utility.RandomMinMax( 1, 10 ) ) );
			pack.DropItem( new Ginseng( Utility.RandomMinMax( 1, 10 ) ) );
			pack.DropItem( new MandrakeRoot( Utility.RandomMinMax( 1, 10 ) ) );
			pack.DropItem( new Nightshade( Utility.RandomMinMax( 1, 10 ) ) );
			pack.DropItem( new SpidersSilk( Utility.RandomMinMax( 1, 10 ) ) );
			pack.DropItem( new SulfurousAsh( Utility.RandomMinMax( 1, 10 ) ) );
			PackItem( pack );
		}

		public override void GenerateLoot()
		{
			AddLoot( LootPack.LowScrolls, 2 );
		}

		public override int GetAngerSound() { return 0x2A2; } 
		public override int GetIdleSound() { return 0x2A3; }
		public override int GetAttackSound() { return 0x2A4; }
		public override int GetHurtSound() { return 0x2A5; } 
		public override int GetDeathSound() { return 0x2A6; } 

		public override int Meat{ get{ return 1; } }
		public override FoodType FavoriteFood{ get{ return FoodType.Meat | FoodType.Fish; } }
		public override PackInstinct PackInstinct{ get{ return PackInstinct.Feline; } }

		public Chakla(Serial serial) : base(serial)
		{
		}

		public override void Serialize(GenericWriter writer)
		{
			base.Serialize(writer);

			writer.Write((int) 0);
		}

		public override void Deserialize(GenericReader reader)
		{
			base.Deserialize(reader);

			int version = reader.ReadInt();
		}
	}
}