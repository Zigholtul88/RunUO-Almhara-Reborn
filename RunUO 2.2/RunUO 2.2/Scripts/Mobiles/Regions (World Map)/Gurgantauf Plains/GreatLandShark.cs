using System;
using System.Collections;
using System.Collections.Generic;
using Server;
using Server.Items;
using Server.Mobiles;
using Server.ContextMenus;

namespace Server.Mobiles
{
	[CorpseName( "a great land shark corpse" )]
	public class GreatLandShark : BaseCreature
	{
		public override WeaponAbility GetWeaponAbility()
		{
			switch ( Utility.Random( 3 ) )
			{
				default:
				case 0: return WeaponAbility.DoubleStrike;
				case 1: return WeaponAbility.WhirlwindAttack;
				case 2: return WeaponAbility.CrushingBlow;
			}
		}

		[Constructable]
		public GreatLandShark() : base( AIType.AI_Animal, FightMode.Aggressor, 10, 1, 0.175, 0.350 )
		{
			Name = "a great land shark";
			Body = 235;
                        Hue = 934;

			SetStr( 124, 142 );
			SetDex( 73, 83 );
			SetInt( 97, 110 );

			SetHits( 220, 254 );

			SetDamage( 8, 12 );

			SetDamageType( ResistanceType.Physical, 100 );

			SetResistance( ResistanceType.Physical, 40 );
			SetResistance( ResistanceType.Fire, 20 );
			SetResistance( ResistanceType.Cold, 20 );
			SetResistance( ResistanceType.Poison, 20 );
			SetResistance( ResistanceType.Energy, 20 );

			SetSkill( SkillName.Anatomy, 0.0 );
			SetSkill( SkillName.MagicResist, 15.1, 18.8 );
			SetSkill( SkillName.Tactics, 73.5, 84.6 );
			SetSkill( SkillName.Wrestling, 71.2, 82.8 );

			Fame = 15000;
			Karma = -15000;

			CanSwim = true;
			CantWalk = false;

			Tamable = true;
			ControlSlots = 1;
			MinTameSkill = 35.5;

                        PackGold( 413, 519 );
		}

		public override int Meat { get { return 1; } }

		public override void GenerateLoot()
		{
			AddLoot( LootPack.Average );

 		        if ( Utility.RandomDouble() < 0.05 )
                        {
			        BaseShield shield = new MetalKiteShield();
			          if ( Core.AOS )
		                BaseRunicTool.ApplyAttributesTo( shield, 5, 25, 30 ); 

                                PackItem( shield );
                        }

 		        if ( Utility.RandomDouble() < 0.05 )
                        {
			        BaseClothing clothing = Loot.RandomClothing( true );
		                BaseRunicTool.ApplyAttributesTo( clothing, 3, 15, 20 );  

                                PackItem( clothing );
                        }

                        if ( Utility.RandomDouble() < 0.05 )
                        {
                                BaseJewel jewel1 = new GoldEarrings();
			          if ( Core.AOS )
		                BaseRunicTool.ApplyAttributesTo( jewel1, 3, 15, 20 ); 

                                PackItem( jewel1 );
		        }

                        if ( Utility.RandomDouble() < 0.05 )
                        {
                                BaseJewel jewel2 = new GoldNecklace();
			          if ( Core.AOS )
		                BaseRunicTool.ApplyAttributesTo( jewel2, 3, 15, 20 ); 

                                PackItem( jewel2 );
		        }

                        if ( Utility.RandomDouble() < 0.05 )
                        {
                                BaseJewel jewel3 = new GoldRing();
			          if ( Core.AOS )
		                BaseRunicTool.ApplyAttributesTo( jewel3, 3, 15, 20 ); 

                                PackItem( jewel3 );
		        }
		}

		public override FoodType FavoriteFood{ get{ return FoodType.Meat; } }

		public GreatLandShark( Serial serial ) : base( serial )
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