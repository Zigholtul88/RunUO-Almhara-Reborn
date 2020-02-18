using System;
using Server;
using Server.Items;

namespace Server.Mobiles
{
	[CorpseName( "a shatter glass wyrmling corpse" )]
	public class ShatterGlassWyrmling : BaseCreature
	{
		public override WeaponAbility GetWeaponAbility()
		{
			return WeaponAbility.BleedAttack;
		}

		[Constructable]
		public ShatterGlassWyrmling() : base( AIType.AI_Mage, FightMode.Closest, 5, 1, 0.2, 0.4 )
		{
			Name = "a shatter glass wyrmling";
			Body = 718;
                        Hue = 1926;
			BaseSoundID = 362;

			SetStr( 136, 160 );
			SetDex( 51, 65 );
			SetInt( 86, 110 );

			SetHits( 195, 280 );
			SetMana( 250, 300 );

			SetDamage( 9, 12 );

			SetDamageType( ResistanceType.Physical, 80 );
			SetDamageType( ResistanceType.Energy, 20 );

			SetResistance( ResistanceType.Physical, 40 );
			SetResistance( ResistanceType.Fire, 0 );
			SetResistance( ResistanceType.Cold, 40 );
			SetResistance( ResistanceType.Poison, 100 );
			SetResistance( ResistanceType.Energy, 55 );

			SetSkill( SkillName.EvalInt, 40.2, 48.8 );
			SetSkill( SkillName.Magery, 52.5, 55.5 );
			SetSkill( SkillName.Meditation, 23.6, 29.7 );
			SetSkill( SkillName.MagicResist, 45.8, 52.7 );
			SetSkill( SkillName.Tactics, 63.4, 80.0 );
			SetSkill( SkillName.Wrestling, 62.1, 78.3 );

			Fame = 2500;
			Karma = -2500;

                        PackGold( 11, 15 ); 
			PackReg( 12, 15 );

			if ( 0.05 > Utility.RandomDouble() )
				PackItem( new Diamond() );
		}

		public override void GenerateLoot()
		{
			AddLoot( LootPack.Rich );
			AddLoot( LootPack.Potions );
			AddLoot( LootPack.Gems );
		}

		public override bool BleedImmune{ get{ return true; } }
		public override Poison PoisonImmune{ get{ return Poison.Lethal; } }

                public override void OnCarve( Mobile from, Corpse corpse, Item with )
		{
			if (corpse.Carved == false)
			{
			      base.OnCarve( from, corpse, with );

                        corpse.AddCarvedItem(new CrushedShatterGlass(), from);
                        corpse.AddCarvedItem(new DiamondDust( Utility.RandomMinMax( 9, 14 )), from);

                        from.SendMessage( "You carve up some diamond dust and also notice some crushed glass." );
                        corpse.Carved = true; 
			}
                }

		public override int GetAttackSound() { return 1513; }
		public override int GetAngerSound() { return 1558; }
		public override int GetDeathSound()	{ return 1514; }
		public override int GetHurtSound() { return 1515; }
		public override int GetIdleSound() { return 1516; }

		public ShatterGlassWyrmling( Serial serial ) : base( serial )
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