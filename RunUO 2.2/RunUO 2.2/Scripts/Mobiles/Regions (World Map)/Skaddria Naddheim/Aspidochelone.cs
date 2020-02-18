using System;
using System.Collections;
using System.Collections.Generic;
using Server;
using Server.Items;
using Server.Mobiles;
using Server.ContextMenus;

namespace Server.Mobiles
{
	[CorpseName( "an aspidochelone corpse" )]
	public class Aspidochelone : BaseCreature
	{
		[Constructable]
		public Aspidochelone() : base( AIType.AI_Animal, FightMode.Aggressor, 10, 1, 0.175, 0.350 )
		{
			Name = "an aspidochelone";
			Body = 227;
                        Hue = 78;

			SetStr( 421, 560 );
			SetDex( 101, 130 );
			SetInt( 386, 425 );

			SetDamage( 17, 25 );

			SetDamageType( ResistanceType.Physical, 100 );

			SetDamageType( ResistanceType.Physical, 100 );

			SetResistance( ResistanceType.Physical, 50 );
			SetResistance( ResistanceType.Fire, 55 );
			SetResistance( ResistanceType.Cold, 25 );
			SetResistance( ResistanceType.Poison, 25 );
			SetResistance( ResistanceType.Energy, 25 );

			SetSkill( SkillName.MagicResist, 26.9, 35.8 );
			SetSkill( SkillName.Tactics, 97.6, 100.0 );
			SetSkill( SkillName.Wrestling, 91.0, 93.2 );

			Fame = 10000;
			Karma = -10000;

			Tamable = true;
			ControlSlots = 4;
			MinTameSkill = 75.0;

			PackGold( 82, 93 );

			switch ( Utility.Random( 8 ))
			{
				case 0: PackItem( new Amethyst() ); break;
				case 1: PackItem( new Chrysoberyl() ); break;
				case 2: PackItem( new Paraiba() ); break;
				case 3: PackItem( new TigerEye() ); break;
				case 4: PackItem( new Ruby() ); break;
				case 5: PackItem( new Sapphire() ); break;
				case 6: PackItem( new Topaz() ); break;
				case 7: PackItem( new Emerald() ); break;
			}

			PackItem( new Bone( 6 ) );
			PackItem( new FishScale( Utility.RandomMinMax( 42, 55 ) ) );
		}

		public override void GenerateLoot()
		{
			AddLoot( LootPack.MedScrolls, 1 );
			AddLoot( LootPack.LowScrolls, 3 );
			AddLoot( LootPack.Gems, 2 );
		}

		public override int Meat { get { return 60; } }

		public override FoodType FavoriteFood{ get{ return FoodType.Meat | FoodType.Fish; } }

		public Aspidochelone( Serial serial ) : base( serial )
		{
		}

		public override void OnDoubleClick( Mobile from )
		{
			if( from.AccessLevel >= AccessLevel.GameMaster )
				Jump();
		}

		public virtual void Jump()
		{
			if( Utility.RandomBool() )
				Animate( 3, 16, 1, true, false, 0 );
			else
				Animate( 4, 20, 1, true, false, 0 );
		}

		public override void OnThink()
		{
			if( Utility.RandomDouble() < .005 ) // slim chance to jump
				Jump();

			base.OnThink();
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