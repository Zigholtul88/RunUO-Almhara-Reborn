using System;
using System.Collections;
using Server.ContextMenus;
using Server.Items;
using Server.Misc;
using Server.Network;
using Server.Targeting;

namespace Server.Mobiles
{
	[CorpseName( "a desert rose corpse" )]
	public class DesertRose : BaseCreature
	{
		public override WeaponAbility GetWeaponAbility()
		{
			return WeaponAbility.BleedAttack;
		}

		[Constructable]
		public DesertRose() : base( AIType.AI_Melee, FightMode.Closest, 5, 1, 0.3, 0.6 )
		{
			Name = "a desert rose";
			Body = 789;
                        Hue = 251;
			BaseSoundID = 352;

			SetStr( 102, 131 );
			SetDex( 67, 86 );
			SetInt( 32, 56 );

			SetHits( 155, 170 );

			SetDamage( 3, 6 );

			SetDamageType( ResistanceType.Physical, 70 );
			SetDamageType( ResistanceType.Fire, 30 );

			SetResistance( ResistanceType.Physical, 15 );
			SetResistance( ResistanceType.Fire, 70 );
			SetResistance( ResistanceType.Cold, 0 );
			SetResistance( ResistanceType.Poison, 100 );
			SetResistance( ResistanceType.Energy, 20 );

			SetSkill( SkillName.MagicResist, 59.2, 68.2 );
			SetSkill( SkillName.Tactics, 47.5, 57.9 );
			SetSkill( SkillName.Wrestling, 76.8, 83.7 );

			Fame = 800;
			Karma = -800;

			Tamable = true;
			ControlSlots = 1;
			MinTameSkill = 32.0;

			PackGold( 11, 16 );

			PackItem( new Engines.Plants.Seed() );

			Container pack = new Backpack();

			pack.DropItem( new Pitcher( BeverageType.Water ) );
			pack.DropItem( new Gold( Utility.RandomMinMax( 17, 24 ) ) );
			pack.DropItem( new MandrakeRoot( Utility.RandomMinMax( 5, 10 ) ) );
			pack.DropItem( new SulfurousAsh( Utility.RandomMinMax( 4, 8 ) ) );

 		      if ( Utility.RandomDouble() < 0.05 )
                  {
			     BaseArmor armor = Loot.RandomArmor( true );
		           BaseRunicTool.ApplyAttributesTo( armor, 5, 15, 30 );  

                       armor.Attributes.Luck = 50;

                       pack.DropItem( armor );
                  }

 		      if ( Utility.RandomDouble() < 0.05 )
                  {
			     BaseWeapon weapon = new CrescentBlade();
		           BaseRunicTool.ApplyAttributesTo( weapon, 5, 25, 30 );  

                       pack.DropItem( weapon );
                  }

                  if ( Utility.RandomDouble() < 0.05 )
                  {
                       BaseJewel jewel = new GoldEarrings();
			     if ( Core.AOS )
		           BaseRunicTool.ApplyAttributesTo( jewel, 3, 15, 20 ); 

                       jewel.Resistances.Fire = 9;

                       PackItem( jewel );
		      }

			if ( 0.05 > Utility.RandomDouble() )
				pack.DropItem( new FireOpal() );

			PackItem( pack );
		}

		public override FoodType FavoriteFood{ get{ return FoodType.Fish | FoodType.Meat; } }

		public override void GenerateLoot()
		{
			AddLoot( LootPack.Meager );
		}

		public override int GetAngerSound()
		{
			return 353;
		}

		public override Poison PoisonImmune{ get{ return Poison.Lethal; } }

		public DesertRose( Serial serial ) : base( serial )
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

			if ( BaseSoundID == -1 )
				BaseSoundID = 352;
		}
	}
}