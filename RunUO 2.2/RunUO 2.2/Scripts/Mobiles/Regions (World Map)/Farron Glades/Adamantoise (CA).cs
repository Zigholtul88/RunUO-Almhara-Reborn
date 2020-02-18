using System;
using System.Collections;
using System.Collections.Generic;
using Server;
using Server.ContextMenus;
using Server.Items;
using Server.Mobiles;
using Server.Network;
using Server.Targeting;

namespace Server.Mobiles
{
	[CorpseName( "an adamantoise corpse" )]
	public class Adamantoise : BaseCreature
	{
		public override WeaponAbility GetWeaponAbility()
		{
			return WeaponAbility.BleedAttack;
		}

		[Constructable]
		public Adamantoise() : base( AIType.AI_Animal, FightMode.Aggressor, 5, 1, 0.3, 0.6 )
		{
			Name = "an adamantoise";
			Body = 0x113;
			BaseSoundID = 224;
                        Hue = 2119;

			SetStr( 567, 689 );
			SetDex( 133, 152 );
			SetInt( 101, 140 );

			SetHits( 2482, 2516 );

			SetDamage( 15, 20 );

			SetDamageType( ResistanceType.Physical, 25 );
			SetDamageType( ResistanceType.Fire, 25 );
			SetDamageType( ResistanceType.Cold, 25 );
			SetDamageType( ResistanceType.Energy, 25 );

			SetResistance( ResistanceType.Physical, 70 );
			SetResistance( ResistanceType.Fire, 70 );
			SetResistance( ResistanceType.Cold, 70 );
			SetResistance( ResistanceType.Poison, -50 );
			SetResistance( ResistanceType.Energy, 70 );

			SetSkill( SkillName.MagicResist, 80.5, 85.0 );
			SetSkill( SkillName.Tactics, 95.1, 110.0 );
			SetSkill( SkillName.Wrestling, 95.1, 110.0 );

			Fame = 45000;
			Karma = -45000;
		}

		public override void GenerateLoot()
		{
			AddLoot( LootPack.FilthyRich, 5 );
			AddLoot( LootPack.MedScrolls, 10 );
			AddLoot( LootPack.LowScrolls, 10 );
			AddLoot( LootPack.Gems, 8 );
		}

		public override int GetDeathSound()
		{
			return 1218;
		}

		public override FoodType FavoriteFood{ get{ return FoodType.Meat; } }

		public override bool BleedImmune{ get{ return true; } }

                public override void OnCarve( Mobile from, Corpse corpse, Item with )
		{
			if ( corpse.Carved == false )
			{
			      base.OnCarve( from, corpse, with );

			      int amount = 1 + (int)( from.Skills[SkillName.Forensics].Value / 25 );

                              corpse.AddCarvedItem(new AdamantoiseCarapace(), from );
                              corpse.AddCarvedItem(new AdamantoiseEgg(), from );
                              corpse.AddCarvedItem(new AdamantoiseTooth( amount ), from );

                              from.SendMessage( "You carve up some adamantoise parts." );
                              corpse.Carved = true; 
			}
                }

		public Adamantoise( Serial serial ) : base( serial )
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