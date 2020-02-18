using System;
using System.Collections;
using Server.Items;
using Server.Targeting;

namespace Server.Mobiles
{
	[CorpseName( "a shatter glass slug corpse" )]
	public class ShatterGlassSlug : BaseCreature
	{
		public override WeaponAbility GetWeaponAbility()
		{
			return WeaponAbility.BleedAttack;
		}

		[Constructable]
		public ShatterGlassSlug() : base( AIType.AI_Melee, FightMode.Closest, 2, 1, 0.2, 0.4 )
		{
			Name = "a shatter glass slug";
			Body = 732; 
                        Hue = 1926;

			SetStr( 205, 225 );
			SetDex( 26, 31 );
			SetInt( 36, 39 );

			SetHits( 175, 250 );
			SetMana( 0 );

			SetDamage( 7, 11 );

			SetDamageType( ResistanceType.Physical, 70 );
			SetDamageType( ResistanceType.Energy, 30 );

			SetResistance( ResistanceType.Physical, 35 );
			SetResistance( ResistanceType.Fire, 0 );
			SetResistance( ResistanceType.Cold, 35 );
			SetResistance( ResistanceType.Poison, 35 );
			SetResistance( ResistanceType.Energy, 50 );

			SetSkill( SkillName.MagicResist, 45.8, 52.7 );
			SetSkill( SkillName.Tactics, 63.4, 80.0 );
			SetSkill( SkillName.Wrestling, 72.1, 88.3 );

			Fame = 2000;
			Karma = -2000;

                        PackGold( 11, 15 );
			PackReg( 2, 5 );

			if ( 0.08 > Utility.RandomDouble() )
				PackItem( new Jade() );
		}

		public override void GenerateLoot()
		{
			AddLoot( LootPack.Rich );
		}

		public override int GetIdleSound() { return 1580; } 
		public override int GetAngerSound() { return 1577; } 
		public override int GetHurtSound() { return 1579; } 
		public override int GetDeathSound()	{ return 1578; }

                public override void OnCarve( Mobile from, Corpse corpse, Item with )
		{
			if (corpse.Carved == false)
			{
			      base.OnCarve( from, corpse, with );

                        corpse.AddCarvedItem(new CrushedShatterGlass(), from);
                        corpse.AddCarvedItem(new BeetleEgg( Utility.RandomMinMax( 11, 16 )), from);

                        from.SendMessage( "You carve up some beetle eggs and also notice some crushed glass." );
                        corpse.Carved = true; 
			}
                }

		public ShatterGlassSlug( Serial serial ) : base( serial )
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