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
	[CorpseName( "an adjule corpse" )]
	public class Adjule : BaseCreature
	{
		public override WeaponAbility GetWeaponAbility()
		{
			return WeaponAbility.BleedAttack;
		}

		[Constructable]
		public Adjule() : base( AIType.AI_Animal, FightMode.Closest, 6, 1, 0.2, 0.4 )
		{
			Name = "an adjule";
			Body = 0xD9;
                        Hue = 1165;
			BaseSoundID = 0x85;

			SetStr( 430, 580 );
			SetDex( 125, 135 );
			SetInt( 15, 30 );

			SetHits( 545, 750 );
			SetMana( 100 );

			SetDamage( 11, 13 );

			SetDamageType( ResistanceType.Physical, 100 );

			SetResistance( ResistanceType.Physical, 35 );
			SetResistance( ResistanceType.Fire, 35 );
			SetResistance( ResistanceType.Cold, 35 );
			SetResistance( ResistanceType.Poison, -50 );
			SetResistance( ResistanceType.Energy, 35 );

			SetSkill( SkillName.MagicResist, 17.6, 19.8 );
			SetSkill( SkillName.Tactics, 93.1, 98.6 );
			SetSkill( SkillName.Wrestling, 93.1, 98.6 );

			Fame = 6000;
			Karma = -6000;

			PackItem( new FishScale( Utility.RandomMinMax( 32, 35 ) ) );
		}

		public override void GenerateLoot()
		{
			AddLoot( LootPack.MedScrolls, 1 );
			AddLoot( LootPack.LowScrolls, 2 );
			AddLoot( LootPack.Gems, 5 );
	        }

		public override bool HasBreath{ get{ return true; } } // cold breath enabled

		public override int BreathPhysicalDamage{ get{ return 0; } }
		public override int BreathFireDamage{ get{ return 0; } }
		public override int BreathColdDamage{ get{ return 0; } }
		public override int BreathPoisonDamage{ get{ return 100; } }
		public override int BreathEnergyDamage{ get{ return 00; } }

		public override int BreathEffectHue{ get{ return 2405; } }
		public override int BreathEffectItemID{ get{ return 0x36D4; } }
		public override int BreathEffectSound{ get{ return 0x160; } }
		public override int BreathAngerSound{ get{ return 0x52D; } }

		public override bool AlwaysMurderer{ get{ return true; } }
		public override int Meat{ get{ return 1; } }
		public override FoodType FavoriteFood{ get{ return FoodType.Meat; } }
		public override PackInstinct PackInstinct{ get{ return PackInstinct.Canine; } }

                public override void OnCarve( Mobile from, Corpse corpse, Item with )
		{
			if ( corpse.Carved == false )
			{
			      base.OnCarve( from, corpse, with );

			      int amount = 1 + (int)( from.Skills[SkillName.Forensics].Value / 25 );

                              corpse.AddCarvedItem( new AdjuleTooth( amount ), from );

                              from.SendMessage( "You carve up some adjule parts." );
                              corpse.Carved = true; 
			}
                }

		public Adjule(Serial serial) : base(serial)
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