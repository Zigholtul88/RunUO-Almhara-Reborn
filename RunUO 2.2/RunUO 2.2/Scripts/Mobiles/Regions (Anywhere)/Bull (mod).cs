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
	[CorpseName( "a bull corpse" )]
	public class Bull : BaseCreature
	{
		public override WeaponAbility GetWeaponAbility()
		{
			return WeaponAbility.BleedAttack;
		}

		[Constructable]
		public Bull() : base( AIType.AI_Animal, FightMode.Aggressor, 10, 1, 0.2, 0.4 )
		{
			Name = "a bull";
			Body = Utility.RandomList( 0xE8, 0xE9 );
			BaseSoundID = 0x64;

			if ( 0.5 >= Utility.RandomDouble() )
				Hue = 0x901;

			SetStr( 80, 109 );
			SetDex( 56, 75 );
			SetInt( 50, 90 );

			SetHits( 100, 128 );
			SetMana( 100 );

			SetDamage( 1, 2 );

			SetDamageType( ResistanceType.Physical, 100 );

			SetResistance( ResistanceType.Physical, 28 );
			SetResistance( ResistanceType.Cold, 10 );

			SetSkill( SkillName.Anatomy, 0.0 );
			SetSkill( SkillName.MagicResist, 17.6, 24.7 );
			SetSkill( SkillName.Tactics, 93.1, 98.6 );
			SetSkill( SkillName.Wrestling, 93.1, 98.6 );

			Fame = 600;
			Karma = 0;

			VirtualArmor = 28;

			Tamable = true;
			ControlSlots = 1;
			MinTameSkill = 30.5;
		}

		public override FoodType FavoriteFood{ get{ return FoodType.GrainsAndHay; } }
		public override PackInstinct PackInstinct{ get{ return PackInstinct.Bull; } }

                public override void OnCarve( Mobile from, Corpse corpse, Item with )
		{
			if (corpse.Carved == false)
			{
			      base.OnCarve( from, corpse, with );

                              corpse.AddCarvedItem(new RawBeefPorterhouse(), from);
                              corpse.AddCarvedItem(new RawBeefPrimeRib(), from);
                              corpse.AddCarvedItem(new RawBeefRibeye(), from);
                              corpse.AddCarvedItem(new RawBeefRibs(), from);
                              corpse.AddCarvedItem(new RawBeefRoast(), from);
                              corpse.AddCarvedItem(new RawBeefSirloin(), from);
                              corpse.AddCarvedItem(new RawBeefTBone(), from);
                              corpse.AddCarvedItem(new RawBeefTenderloin(), from);
                              corpse.AddCarvedItem(new RawGroundBeef(), from);
                              corpse.AddCarvedItem(new Hides(15), from);

                              corpse.Carved = true; 

                              from.SendMessage( "You carve up some bovine parts." ); 
			}
                }

		public Bull(Serial serial) : base(serial)
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