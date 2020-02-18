using System;
using System.Collections;
using System.Collections.Generic;
using Server;
using Server.Items;
using Server.Mobiles;
using Server.ContextMenus;

namespace Server.Mobiles
{
	[CorpseName( "a taniwha corpse" )]
	public class Taniwha : BaseCreature
	{
		public override WeaponAbility GetWeaponAbility()
		{
			return WeaponAbility.BleedAttack;
		}

		[Constructable]
		public Taniwha() : base( AIType.AI_Animal, FightMode.Aggressor, 10, 1, 0.175, 0.350 )
		{
			Name = "a taniwha";
			Body = 235;
                        Hue = 93;

			SetStr( 215, 225 );
			SetDex( 99, 105 );
			SetInt( 24, 31 );

			SetMana( 0 );

			SetDamage( 6, 13 );

			SetDamageType( ResistanceType.Physical, 100 );

			SetResistance( ResistanceType.Physical, 40 );
			SetResistance( ResistanceType.Fire, 20 );
			SetResistance( ResistanceType.Cold, 20 );
			SetResistance( ResistanceType.Poison, 20 );
			SetResistance( ResistanceType.Energy, 20 );

			SetSkill( SkillName.Anatomy, 0.0 );
			SetSkill( SkillName.MagicResist, 45.1, 59.3 );
			SetSkill( SkillName.Tactics, 73.5, 84.6 );
			SetSkill( SkillName.Wrestling, 71.2, 82.8 );

			CanSwim = true;
			CantWalk = false;

			Fame = 2000;
			Karma = -2000;

			Tamable = true;
			ControlSlots = 1;
			MinTameSkill = 37.9;

                        PackGold( 13, 19 );
			PackItem( new Bone( 2 ) );
			PackItem( new FishScale( Utility.RandomMinMax( 12, 15 ) ) );
		}

		public override int Meat { get { return 1; } }

		public override FoodType FavoriteFood{ get{ return FoodType.Meat | FoodType.Fish; } }

		public Taniwha( Serial serial ) : base( serial )
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