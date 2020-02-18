using System;
using System.Collections;
using System.Collections.Generic;
using Server.ContextMenus;
using Server.Items;
using Server.Mobiles;
using Server.Targeting;

namespace Server.Mobiles
{
	[CorpseName( "a grachiosaur corpse" )]
	public class Grachiosaur : BaseCreature
	{
		[Constructable]
		public Grachiosaur () : base( AIType.AI_Melee, FightMode.Aggressor, 10, 1, 0.175, 0.350 )
		{
			Name = "a grachiosaur";
			Body = 288;

			SetStr( 421, 560 );
			SetDex( 101, 130 );
			SetInt( 386, 425 );

			SetHits( 466, 512 );

			SetDamage( 17, 25 );

			SetDamageType( ResistanceType.Physical, 100 );

			SetDamageType( ResistanceType.Physical, 100 );

			SetResistance( ResistanceType.Physical, 50 );
			SetResistance( ResistanceType.Fire, 15 );
			SetResistance( ResistanceType.Cold, 15 );
			SetResistance( ResistanceType.Poison, 15 );
			SetResistance( ResistanceType.Energy, 15 );

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

			PackItem( new Bone( 2 ) );
			PackItem( new FertileDirt( Utility.RandomMinMax( 1, 3 ) ) );

			Container pack = Backpack;

			if ( pack != null )
				pack.Delete();

			pack = new StrongBackpack();
			pack.Movable = false;

			AddItem( pack );
		}

		public override void GenerateLoot()
		{
			AddLoot( LootPack.FilthyRich );
			AddLoot( LootPack.MedScrolls, 1 );
			AddLoot( LootPack.LowScrolls, 3 );
			AddLoot( LootPack.Gems, 2 );
		}

		public override bool ReacquireOnMovement{ get{ return true; } }
		public override int Meat{ get{ return 35; } }
		public override int Hides{ get{ return 45; } }
		public override HideType HideType{ get{ return HideType.Spined; } }
		public override int Scales{ get{ return 15; } }
		public override ScaleType ScaleType{ get{ return ScaleType.Yellow; } }
		public override FoodType FavoriteFood{ get{ return FoodType.FruitsAndVegies | FoodType.GrainsAndHay; } }

		public override int GetAngerSound() { return 0x4F8; }
		public override int GetIdleSound() { return 0x4F7; }
		public override int GetAttackSound() { return 0x4F6; }  
		public override int GetHurtSound() { return 0x4F9; } 
		public override int GetDeathSound() { return 0x4F5; }

		public Grachiosaur( Serial serial ) : base( serial )
		{
		}

		#region Pack Animal Methods
		public override bool OnBeforeDeath()
		{
			if ( !base.OnBeforeDeath() )
				return false;

			PackAnimal.CombineBackpacks( this );

			return true;
		}

		public override DeathMoveResult GetInventoryMoveResultFor( Item item )
		{
			return DeathMoveResult.MoveToCorpse;
		}

		public override bool IsSnoop( Mobile from )
		{
			if ( PackAnimal.CheckAccess( this, from ) )
				return false;

			return base.IsSnoop( from );
		}

		public override bool OnDragDrop( Mobile from, Item item )
		{
			if ( CheckFeed( from, item ) )
				return true;

			if ( PackAnimal.CheckAccess( this, from ) )
			{
				AddToBackpack( item );
				return true;
			}

			return base.OnDragDrop( from, item );
		}

		public override bool CheckNonlocalDrop( Mobile from, Item item, Item target )
		{
			return PackAnimal.CheckAccess( this, from );
		}

		public override bool CheckNonlocalLift( Mobile from, Item item )
		{
			return PackAnimal.CheckAccess( this, from );
		}

		public override void OnDoubleClick( Mobile from )
		{
			PackAnimal.TryPackOpen( this, from );
		}

		public override void GetContextMenuEntries( Mobile from, List<ContextMenuEntry> list )
		{
			base.GetContextMenuEntries( from, list );

			PackAnimal.GetContextMenuEntries( this, from, list );
		}
		#endregion

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