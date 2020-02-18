using System;
using System.Collections;
using System.Collections.Generic;
using Server;
using Server.ContextMenus;
using Server.Gumps;
using Server.Items;
using Server.Misc;
using Server.Mobiles;
using Server.Network;
using Server.Spells;
using Server.Targeting;

namespace Server.Mobiles
{
	[CorpseName( "the corpse of Onix" )]
	public class Onix : BaseGuardian
	{
		public override bool InitialInnocent{ get{ return true; } }

		[Constructable]
		public Onix() : base( AIType.AI_Melee, FightMode.Closest, 10, 1, 0.175, 0.350 )
		{
                        // based off of Grachiosaur mob stats
			Name = "Onix";
			Body = 288;

			SetStr( 421, 560 );
			SetDex( 101, 130 );
			SetInt( 386, 425 );

			SetHits( 466, 512 );

			SetDamage( 20, 28 );

			SetDamageType( ResistanceType.Physical, 100 );

			SetDamageType( ResistanceType.Physical, 100 );

			SetResistance( ResistanceType.Physical, 50 );
			SetResistance( ResistanceType.Fire, 25 );
			SetResistance( ResistanceType.Cold, 35 );
			SetResistance( ResistanceType.Poison, 25 );
			SetResistance( ResistanceType.Energy, 25 );

			SetSkill( SkillName.MagicResist, 49.9, 65.2 );
			SetSkill( SkillName.Tactics, 97.6, 100.0 );
			SetSkill( SkillName.Wrestling, 91.0, 93.2 );

			Fame = 0;
			Karma = 10000;

			PackGold( 210, 346 );

			PackItem( new FertileDirt( Utility.RandomMinMax( 1, 3 ) ) );

			Container pack = Backpack;

			if ( pack != null )
				pack.Delete();

			pack = new StrongBackpack();
			pack.Movable = false;

			AddItem( pack );
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

		public Onix( Serial serial ) : base( serial )
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