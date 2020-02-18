using System;
using System.Collections;
using Server.Items;
using Server.Mobiles;
using Server.Targeting;

namespace Server.Mobiles
{
	[CorpseName( "a bog creeper corpse" )]
	public class BogCreeper : BaseCreature
	{
		[Constructable]
		public BogCreeper() : base( AIType.AI_Melee, FightMode.Closest, 16, 1, 0.1, 0.2 )
		{
			Name = "a bog creeper";
			Body = 48;
                        Hue = 768;
			BaseSoundID = 397;

			RangePerception = 50;

			SetStr( 165, 179 );
			SetDex( 78, 94 );
			SetInt( 35, 45 );

			SetHits( 175, 245 );
			SetMana( 0 );

			SetDamage( 8, 12 );

			SetDamageType( ResistanceType.Physical, 60 );
			SetDamageType( ResistanceType.Poison, 40 );

			SetResistance( ResistanceType.Physical, 28 );
			SetResistance( ResistanceType.Poison, 40 );

			SetSkill( SkillName.Ninjitsu, 60.0 );
			SetSkill( SkillName.MagicResist, 30.1, 34.9 );
			SetSkill( SkillName.Tactics, 62.4, 73.5 );
			SetSkill( SkillName.Wrestling, 78.9, 86.4 );

			Fame = 1500;
			Karma = -1500;

			Tamable = true;
			ControlSlots = 1;
			MinTameSkill = 42.4;

			PackGold( 13, 16 );
			PackReg( 2, 6 );

 			if ( Utility.RandomDouble() < 0.10 )
				PackItem( new PoisonScroll() );

 			if ( Utility.RandomDouble() < 0.02 )
				PackItem( new CureWand() );

			PackItem( new CurePotion() );
		}

		public override void GenerateLoot()
		{
			AddLoot( LootPack.Gems );
			AddLoot( LootPack.Potions );
		}

		public override FoodType FavoriteFood{ get{ return FoodType.Meat; } }

		public override PackInstinct PackInstinct{ get{ return PackInstinct.Arachnid; } }

                public override void OnCarve( Mobile from, Corpse corpse, Item with )
		{
			if (corpse.Carved == false)
			{
			      base.OnCarve( from, corpse, with );

                              corpse.AddCarvedItem(new RawRibs(), from);
                              corpse.AddCarvedItem(new BogCreeperCarapace(), from);

                              from.SendMessage( "You carve up a raw rib and a creeper carapace." );
                              corpse.Carved = true; 
			}
                }

		public override OppositionGroup OppositionGroup
		{
			get{ return OppositionGroup.ZaythalorPredator; }
		}

		public BogCreeper( Serial serial ) : base( serial )
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