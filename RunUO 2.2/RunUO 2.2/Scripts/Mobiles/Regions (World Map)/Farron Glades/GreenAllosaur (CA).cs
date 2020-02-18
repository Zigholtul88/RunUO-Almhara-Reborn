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
	[CorpseName( "a green allosaur corpse" )]
	public class GreenAllosaur : BaseCreature
	{
		public override WeaponAbility GetWeaponAbility()
		{
			return WeaponAbility.BleedAttack;
		}

		[Constructable]
		public GreenAllosaur() : base( AIType.AI_Animal, FightMode.Closest, 8, 2, 0.175, 0.350 )
		{
			Name = "a green allosaur";
			Body = 295;
			Hue = 67;

			SetStr( 401, 430 );
			SetDex( 133, 152 );
			SetInt( 101, 140 );

			SetHits( 882, 916 );

			SetDamage( 15, 25 );

			SetDamageType( ResistanceType.Physical, 100 );

			SetResistance( ResistanceType.Physical, 50 );
			SetResistance( ResistanceType.Fire, 35 );
			SetResistance( ResistanceType.Cold, 35 );
			SetResistance( ResistanceType.Poison, -50 );
			SetResistance( ResistanceType.Energy, 35 );

			SetSkill( SkillName.MagicResist, 46.9, 55.8 );
			SetSkill( SkillName.Tactics, 97.6, 115.0 );
			SetSkill( SkillName.Wrestling, 91.0, 115.2 );

			Fame = 8000;
			Karma = -8000;

			PackGold( 51, 73 );
		}

		public override void GenerateLoot()
		{
			AddLoot( LootPack.MedScrolls, 3 );
			AddLoot( LootPack.LowScrolls, 5 );
			AddLoot( LootPack.Gems, 4 );
		}

		public override int GetIdleSound() { return 0x621; } // t_rex_I
		public override int GetAngerSound() { return 0x61E; } // t_rex_A
		public override int GetAttackSound() { return 651; }
		public override int GetHurtSound() { return 652; }
		public override int GetDeathSound() { return 653; }

		public override int Meat{ get{ return 28; } }
		public override int Hides{ get{ return 35; } }
		public override HideType HideType{ get{ return HideType.Spined; } }
		public override FoodType FavoriteFood{ get{ return FoodType.Meat | FoodType.Fish; } }

                public override void OnCarve( Mobile from, Corpse corpse, Item with )
		{
			if ( corpse.Carved == false )
			{
			      base.OnCarve( from, corpse, with );

			      int amount = 1 + (int)( from.Skills[SkillName.Forensics].Value / 25 );

                              corpse.AddCarvedItem( new GreenAllosaurClaw(), from );
                              corpse.AddCarvedItem( new GreenAllosaurTooth( amount ), from );

                              from.SendMessage( "You carve up some green allosaur parts." );
                              corpse.Carved = true; 
			}
                }

		public GreenAllosaur(Serial serial) : base(serial)
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