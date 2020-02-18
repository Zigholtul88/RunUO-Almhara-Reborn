using System;
using Server;
using System.Collections;
using Server.ContextMenus;
using Server.Items;
using Server.Misc;
using Server.Mobiles;
using Server.Targeting;

namespace Server.Mobiles
{
	[CorpseName( "an oboru jumping spider corpse" )]
	public class OboruJumpingSpider : BaseCreature
	{
		[Constructable]
		public OboruJumpingSpider() : base( AIType.AI_Melee, FightMode.Closest, 5, 1, 0.175, 0.350 )
		{
			Name = "an oborunian jumping spider";
			Body = 736;
                        Hue = 1058;

			SetStr( 58, 87 );
			SetDex( 48, 61 );
			SetInt( 23, 41 );

			SetHits( 105, 120 );
			SetMana( 0 );

			SetDamage( 4, 11 );

			SetDamageType( ResistanceType.Physical, 100 );

			SetResistance( ResistanceType.Physical, 15 );
			SetResistance( ResistanceType.Poison, 20 );

			SetSkill( SkillName.MagicResist, 20.1, 30.5 );
			SetSkill( SkillName.Tactics, 31.5, 41.4 );
			SetSkill( SkillName.Wrestling, 36.9, 51.0 );

			Fame = 500;
			Karma = -500;

			Tamable = true;
			ControlSlots = 1;
			MinTameSkill = 22.9;

			PackGold( 8, 10 );

 			if ( Utility.RandomDouble() < 0.08 )
				PackItem( new CureScroll() );
		}

		public override void GenerateLoot()
		{
			AddLoot( LootPack.Poor );
		}

		public override int GetIdleSound() { return 1605; } 
		public override int GetAngerSound() { return 1602; } 
		public override int GetHurtSound() { return 1604; } 
		public override int GetDeathSound() { return 1603; }

		public override FoodType FavoriteFood{ get{ return FoodType.Meat; } }
		public override PackInstinct PackInstinct{ get{ return PackInstinct.Arachnid; } }
		public override Poison PoisonImmune{ get{ return Poison.Regular; } }

                public override void OnCarve( Mobile from, Corpse corpse, Item with )
		{
			if (corpse.Carved == false)
			{
			      base.OnCarve( from, corpse, with );

                              corpse.AddCarvedItem(new SpiderEgg( Utility.RandomMinMax( 5, 8 )), from);
                              corpse.AddCarvedItem(new OboruSpiderSilk(), from);

                              from.SendMessage( "You carve up some spider eggs and in addition an oboru spider silk." );
                              corpse.Carved = true; 
			}
                }

		public OboruJumpingSpider( Serial serial ) : base( serial )
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