using System;
using Server;
using Server.Items;
using Server.Targeting;

namespace Server.Mobiles
{
	[CorpseName( "an air elemental corpse" )]
	public class AirElemental : BaseCreature
	{
		public override double DispelDifficulty{ get{ return 117.5; } }
		public override double DispelFocus{ get{ return 45.0; } }

		[Constructable]
		public AirElemental () : base( AIType.AI_Mage, FightMode.Closest, 10, 1, 0.2, 0.4 )
		{
			Name = "an air elemental";
			Body = 13;
			Hue = 0x4001;
			BaseSoundID = 655;

			SetStr( 126, 152 );
			SetDex( 166, 185 );
			SetInt( 102, 121 );

			SetHits( 304, 372 );
			SetMana( 510, 605 );

			SetDamage( 8, 10 );

			SetDamageType( ResistanceType.Physical, 20 );
			SetDamageType( ResistanceType.Cold, 40 );
			SetDamageType( ResistanceType.Energy, 40 );

			SetResistance( ResistanceType.Physical, 40 );
			SetResistance( ResistanceType.Fire, 15 );
			SetResistance( ResistanceType.Cold, 10 );
			SetResistance( ResistanceType.Poison, 10 );
			SetResistance( ResistanceType.Energy, 25 );

			SetSkill( SkillName.Magery, 67.1, 78.4 );
			SetSkill( SkillName.MagicResist, 63.8, 74.8 );
			SetSkill( SkillName.Tactics, 62.5, 78.8 );
			SetSkill( SkillName.Wrestling, 66.9, 82.0 );

			Fame = 14500;
			Karma = -14500;

			VirtualArmor = 40;

			PackGold( 21, 27 );

			PackItem( new Beryl() );

			PackItem( new ElementalDust( Utility.RandomMinMax( 5, 8 ) ) );

 			if ( Utility.RandomDouble() < 0.10 )
				PackItem( new SummonAirElementalScroll() );
		}

		public override void GenerateLoot()
		{
			AddLoot( LootPack.Rich, 2 );
			AddLoot( LootPack.Average );
		}

		public override bool BleedImmune{ get{ return true; } }

		public override int GetAttackSound() { return 264; } 
		public override int GetAngerSound() { return 265; } 
		public override int GetDeathSound() { return 267; }
		public override int GetHurtSound() { return 266; } 
		public override int GetIdleSound() { return 263; } 

		public AirElemental( Serial serial ) : base( serial )
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

			if ( BaseSoundID == 263 )
				BaseSoundID = 655;
		}
	}
}
