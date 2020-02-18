using System;
using System.Collections;
using Server.Items;
using Server.Mobiles;
using Server.Targeting;

namespace Server.Mobiles
{
	[CorpseName( "a crypt spider corpse" )]
	public class CryptSpider : BaseCreature
	{
		public override double BoostedSpeed{ get{ return 0.1; } }
		public override bool ReduceSpeedWithDamage{ get{ return false; } }

		[Constructable]
		public CryptSpider() : base( AIType.AI_Melee, FightMode.Closest, 8, 1, 0.3, 0.6 )
		{
			Name = "a crypt spider";
			Body = 398;
                        Hue = 1403;
			BaseSoundID = 0x388;

			SetStr( 142, 168 );
			SetDex( 112, 135 );
			SetInt( 53, 79 );

			SetHits( 156, 177 );
			SetMana( 0 );

			SetDamage( 6, 14 );

			SetDamageType( ResistanceType.Physical, 80 );
			SetDamageType( ResistanceType.Poison, 20 );

			SetResistance( ResistanceType.Physical, 20 );
			SetResistance( ResistanceType.Poison, 35 );

			SetSkill( SkillName.Poisoning, 65.7, 81.4 );
			SetSkill( SkillName.MagicResist, 29.9, 42.0 );
			SetSkill( SkillName.Tactics, 41.9, 53.7 );
			SetSkill( SkillName.Wrestling, 62.2, 76.4 );

			Fame = 9000;
			Karma = -9000;

			Tamable = true;
			ControlSlots = 1;
			MinTameSkill = 42.4;

			PackGold( 17, 21 );

 			if ( Utility.RandomDouble() < 0.25 )
				PackItem( new CureScroll() );
		}

		public override void GenerateLoot()
		{
			AddLoot( LootPack.Average );
		}

		public override FoodType FavoriteFood{ get{ return FoodType.Meat; } }
		public override PackInstinct PackInstinct{ get{ return PackInstinct.Arachnid; } }
		public override Poison PoisonImmune{ get{ return Poison.Regular; } }
		public override Poison HitPoison{ get{ return Poison.Regular; } }

		public override void OnHarmfulSpell( Mobile from )
		{
			if ( !Controlled && ControlMaster == null )
				CurrentSpeed = BoostedSpeed;
		}

		public override void OnCombatantChange()
		{
			if ( Combatant == null && !Controlled && ControlMaster == null )
				CurrentSpeed = PassiveSpeed;
		}

                public override void OnCarve( Mobile from, Corpse corpse, Item with )
		{
			if (corpse.Carved == false)
			{
			      base.OnCarve( from, corpse, with );

                        corpse.AddCarvedItem(new SpidersSilk( Utility.RandomMinMax( 5, 7 )), from);
                        corpse.AddCarvedItem(new SpiderEgg( Utility.RandomMinMax( 7, 15 )), from);

                        from.SendMessage( "You carve up some spider silk and spider eggs." ); 
                        corpse.Carved = true;
			}
                }

		public CryptSpider( Serial serial ) : base( serial )
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