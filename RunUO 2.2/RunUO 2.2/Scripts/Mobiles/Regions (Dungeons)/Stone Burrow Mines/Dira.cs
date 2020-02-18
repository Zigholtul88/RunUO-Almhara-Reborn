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
	[CorpseName( "a dira corpse" )]
	public class Dira : BaseCreature
	{
		public override WeaponAbility GetWeaponAbility()
		{
			return WeaponAbility.CrushingBlow;
		}

		[Constructable]
		public Dira() : base( AIType.AI_Mage, FightMode.Closest, 10, 1, 0.2, 0.4 )
		{
			Name = "a dira";
			Body = 123;
			Hue = 2591;
			BaseSoundID = 402;

			SetStr( 167, 214 );
			SetDex( 86, 110 );
			SetInt( 349, 431 );

			SetHits( 496, 542 );
			SetMana( 1500, 2600 );

			SetDamage( 8, 12 );

			SetDamageType( ResistanceType.Physical, 100 );

			SetResistance( ResistanceType.Physical, 35 );
			SetResistance( ResistanceType.Fire, 15 );
			SetResistance( ResistanceType.Cold, 20 );
			SetResistance( ResistanceType.Poison, 30 );
			SetResistance( ResistanceType.Energy, 30 );

			SetSkill( SkillName.EvalInt, 42.0, 56.0 );
			SetSkill( SkillName.Magery, 97.3, 118.6 );
			SetSkill( SkillName.MagicResist, 47.9, 61.2 );
			SetSkill( SkillName.Meditation, 95.0, 100.0 );
			SetSkill( SkillName.Ninjitsu, 100.0 );
			SetSkill( SkillName.Tactics, 52.3, 63.6 );
			SetSkill( SkillName.Wrestling, 64.4, 85.2 );

			Fame = 15000;
			Karma = -15000;

			AddItem( new LightSource() );

			PackGold( 324, 430 );
			PackReg( 200 );

			PackItem( new Zircon() );

			PackItem( new FishScale( Utility.RandomMinMax( 11, 15 ) ) );

			PackItem( new AgilityScroll() );

			switch ( Utility.Random( 5 ) )
			{
				case 0: PackItem( new ChromeDiopside() ); break;
				case 1: PackItem( new Peridot() ); break;
				case 2: PackItem( new Demantoid() ); break;
				case 3: PackItem( new Bloodstone() ); break;
				case 4: PackItem( new Jasper() ); break;
			}
		}

		public override void GenerateLoot()
		{
			AddLoot( LootPack.Potions );
			AddLoot( LootPack.MedScrolls, 25 );
		}

		public override int GetIdleSound() { return 918; } 
		public override int GetAngerSound() { return 916; } 
		public override int GetAttackSound() { return 916; }
		public override int GetHurtSound() { return 919; } 
		public override int GetDeathSound() { return 917; }

		public override int Meat{ get{ return 1; } }
		public override int Feathers{ get{ return 50; } }

		public Dira( Serial serial ) : base( serial )
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