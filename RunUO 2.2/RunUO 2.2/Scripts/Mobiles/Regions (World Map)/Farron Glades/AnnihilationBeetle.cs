using System;
using System.Collections;
using System.Collections.Generic;
using Server;
using Server.ContextMenus;
using Server.Items;
using Server.Misc;
using Server.Mobiles;
using Server.Network;
using Server.Targeting;

namespace Server.Mobiles
{
	[CorpseName( "an annihilation beetle corpse" )]
	public class AnnihilationBeetle : BaseCreature
	{
		public override WeaponAbility GetWeaponAbility()
		{
			return WeaponAbility.CrushingBlow;
		}

		[Constructable]
		public AnnihilationBeetle() : base( AIType.AI_Melee, FightMode.Aggressor, 10, 1, 0.2, 0.4 ) 
		{
			Name = "an annihilation beetle";
			Body = 242;
		        Hue = 556;

			SetStr( 536, 660 );
			SetDex( 141, 152 );
			SetInt( 131, 140 );

			SetHits( 612, 633 );
			SetMana( 20 );

			SetDamage( 12, 19 );

			SetDamageType( ResistanceType.Physical, 100 );

			SetResistance( ResistanceType.Physical, 40 );
			SetResistance( ResistanceType.Fire, 30 );
			SetResistance( ResistanceType.Cold, 30 );
			SetResistance( ResistanceType.Poison, -50 );
			SetResistance( ResistanceType.Energy, 35 );

			SetSkill( SkillName.Anatomy, 60.1, 74.0 );
			SetSkill( SkillName.MagicResist, 50.1, 58.0 );
			SetSkill( SkillName.Tactics, 87.1, 97.0 );
			SetSkill( SkillName.Wrestling, 80.1, 90.0 );

			Fame = 18000;
			Karma = -18000;

			if ( Utility.RandomDouble() < .5 )
				PackItem( Engines.Plants.Seed.RandomBonsaiSeed() );
		}

		public override void GenerateLoot()
		{
			AddLoot( LootPack.FilthyRich, 2 );
			AddLoot( LootPack.MedScrolls, 3 );
			AddLoot( LootPack.LowScrolls, 5 );
			AddLoot( LootPack.Gems, 4 );
		}

		public override int GetIdleSound() { return 0x4F2; }
		public override int GetAngerSound() { return 0x4F3; }
		public override int GetAttackSound() { return 0x4F1; }
		public override int GetHurtSound() { return 0x4F4; }
		public override int GetDeathSound() { return 0x4F0; }

                public override void OnCarve( Mobile from, Corpse corpse, Item with )
		{
			if ( corpse.Carved == false )
			{
			      base.OnCarve( from, corpse, with );

                              corpse.AddCarvedItem( new AnnihilationBeetleCarapace(), from );

                              from.SendMessage( "You carve up some beetle parts." );
                              corpse.Carved = true; 
			}
                }


		public override void OnGaveMeleeAttack( Mobile defender )
		{
		      base.OnGaveMeleeAttack( defender );

                      if (0.50 >= Utility.RandomDouble())
		      DoDestroyEquipment( defender );
		}

		public void DoDestroyEquipment( Mobile target )
		{
			if ( 0.10 >= Utility.RandomDouble() ) // 10% to destroy target's equipment
				DestroyEquipment( target );
		}

		#region Destroy Equipment
		private DateTime m_NextDestroy;

		public void DestroyEquipment( Mobile target )
		{
			if ( target == null || Deleted || !Alive || m_NextDestroy > DateTime.Now || 0.005 < Utility.RandomDouble() )
				return;

			if ( target.Player && target.Female && !target.Hidden && CanBeHarmful( target ) )
			{
				DestroyItem( target, Layer.OuterTorso );
				DestroyItem( target, Layer.InnerTorso );
				DestroyItem( target, Layer.MiddleTorso );
				DestroyItem( target, Layer.Pants );
				DestroyItem( target, Layer.Shirt );
				DestroyItem( target, Layer.OneHanded );
				DestroyItem( target, Layer.TwoHanded );
				DestroyItem( target, Layer.Bracelet );
				DestroyItem( target, Layer.Earrings );
				DestroyItem( target, Layer.Neck );
				DestroyItem( target, Layer.Ring );
				DestroyItem( target, Layer.Arms );
				DestroyItem( target, Layer.Cloak );
				DestroyItem( target, Layer.Gloves );
				DestroyItem( target, Layer.Helm );
				DestroyItem( target, Layer.InnerLegs );
				DestroyItem( target, Layer.OuterLegs );
				DestroyItem( target, Layer.Shoes );

                                target.SendMessage( "The death watch beetle has destroyed some of your equipment." );
			}

			m_NextDestroy = DateTime.Now + TimeSpan.FromMinutes( 1 );
		}

		public void DestroyItem( Mobile m, Layer layer )
		{
			Item item = m.FindItemOnLayer( layer );

			if ( item != null && item.Movable )
				m.Delete();
		}
		#endregion

		public override int Hides{ get{ return 8; } }	

		public AnnihilationBeetle( Serial serial ) : base( serial )
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
		}
	}
}