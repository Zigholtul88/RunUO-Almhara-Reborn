using System;
using System.Collections;
using Server.Items;
using Server.Mobiles;
using Server.Targeting;

namespace Server.Mobiles
{
	[CorpseName( "a giant toad corpse" )]
	[TypeAlias( "Server.Mobiles.Gianttoad" )]
	public class GiantToad : BaseCreature
	{
		public override WeaponAbility GetWeaponAbility()
		{
			return WeaponAbility.DoubleStrike;
		}

		[Constructable]
		public GiantToad() : base( AIType.AI_Melee, FightMode.Closest, 10, 1, 0.2, 0.4 )
		{
			Name = "a giant toad";
			Body = 80;
			BaseSoundID = 0x26B;

			SetStr( 76, 100 );
			SetDex( 6, 25 );
			SetInt( 11, 20 );

			SetHits( 92, 120 );
			SetMana( 0 );

			SetDamage( 5, 17 );

			SetDamageType( ResistanceType.Physical, 100 );

			SetResistance( ResistanceType.Physical, 24 );
			SetResistance( ResistanceType.Fire, 5 );
			SetResistance( ResistanceType.Energy, 5 );

			SetSkill( SkillName.MagicResist, 25.1, 40.0 );
			SetSkill( SkillName.Tactics, 40.1, 60.0 );
			SetSkill( SkillName.Wrestling, 40.1, 60.0 );

			Fame = 1750;
			Karma = -1750;

			Tamable = true;
			ControlSlots = 1;
			MinTameSkill = 37.4;
		}

		public override void GenerateLoot()
		{
			AddLoot( LootPack.Average );
		}

		public override FoodType FavoriteFood{ get{ return FoodType.Fish | FoodType.Meat; } }

                public override void OnCarve( Mobile from, Corpse corpse, Item with )
		{
			if (corpse.Carved == false)
			{
			      base.OnCarve( from, corpse, with );

                        corpse.AddCarvedItem(new RawRibs(2), from);
                        corpse.AddCarvedItem(new SpinedHides(12), from);
                        corpse.AddCarvedItem(new GiantToadEye(), from);

                        from.SendMessage( "You carve up raw ribs, spined hides, and a giant toad eye." );
                        corpse.Carved = true; 
			}
                }

		public GiantToad(Serial serial) : base(serial)
		{
		}

		public override void Serialize(GenericWriter writer)
		{
			base.Serialize(writer);

			writer.Write((int) 1);
		}

		public override void Deserialize(GenericReader reader)
		{
			base.Deserialize(reader);

			int version = reader.ReadInt();
			if ( version < 1 )
			{
					AI = AIType.AI_Melee;
					FightMode = FightMode.Closest;
			}
		}
	}
}